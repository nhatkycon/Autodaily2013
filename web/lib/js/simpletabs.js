jQuery.fn.hammer = function (options) {
    return this.each(function () {
        var hammer = new Hammer(this, options);

        var $el = jQuery(this);
        $el.data("hammer", hammer);

        var events = ['hold', 'tap', 'doubletap', 'transformstart', 'transform', 'transformend', 'dragstart', 'drag', 'dragend', 'swipe', 'release'];

        for (var e = 0; e < events.length; e++) {
            hammer['on' + events[e]] = (function (el, eventName) {
                return function (ev) {
                    el.trigger(jQuery.Event(eventName, ev));
                };
            })($el, events[e]);
        }
    });
};

jQuery.simpleTabs = function (container, tabs, headers) {
    //NOTE:see test.htm to see how the HTML should be structured
    //container: selector for the the 'viewport', must have finite width and must be the parent of the sliding div containing the tab bodies
    //tabs: selector for the tab bodies
    //headers: selector for the tab headers
    //For this to work, the browser MUST support History.pushState (most mobile and modern browsers do, no worry)

    var TabManager = function ($container, $tabs, $headers) {
        var _tabs = {},
            _self = this,
            _timer,
            _indexer,
            _activeClassName = "active",
            _tabBodyIdentifierAttr = "data-key";

        var throttle = function (func, wait) {
            var context, args, timeout, result;
            var previous = 0;
            var later = function () {
                previous = new Date;
                timeout = null;
                result = func.apply(context, args);
            };
            return function () {
                var now = new Date;
                var remaining = wait - (now - previous);
                context = this;
                args = arguments;
                if (remaining <= 0) {
                    clearTimeout(timeout);
                    timeout = null;
                    previous = now;
                    result = func.apply(context, args);
                } else if (!timeout) {
                    timeout = setTimeout(later, remaining);
                }
                return result;
            };
        };

        //build a map of id=>{ header:HTMLElement, body:HTMLElement } for fast lookup 
        $headers.each(function (idx, headerElem) {
            var key = $(headerElem).attr("href");
            if (!key) {
                return;
            }

            key = key.replace("#", "");
            var $tab = $tabs.filter("[" + _tabBodyIdentifierAttr + "=" + key + "]");
            if (!$tab.length) {
                return;
            }

            _tabs[key] = { header: headerElem, body: $tab.get(0) /*, eL: $tab.position().left, eW: $tab.outerWidth(true), eR: $tab.position().left + $tab.outerWidth(true) */ };
        });
        //console.log(_tabs);

        //pre-compile a function for faster lookup of the active tab
        this.compileIndexer = function () {
            var srcLines = [];
            var vW = $container.width();
            srcLines.push("var vR = vL + " + vW + ";");
            srcLines.push("\n");
            srcLines.push("switch(true){");
            for (var key in _tabs) {
                if (key) {
                    var $tab = $(_tabs[key].body);
                    var eL = $tab.position().left,
                    eW = $tab.outerWidth(true),
                    eR = eL + eW;
                    srcLines.push("\n");
                    //array.join is faster then string concatenation
                    if (eW <= vW) {
                        //has his left foot in the viewport, or has half his right foot in the viewport
                        srcLines.push(["case (vL <= ", eL, ") || ((vL <= ", eR, ") && ((", eR, " - vL) >= (", (eW / 2), "))):"].join(""));
                    } else {
                        //has his left foot in the viewport, contains the viewport, or still has his right foot over half of the viewport
                        srcLines.push(["case (vL <= ", eL, " && ", eL, " <= vR) || ((", eL, " <= vL) && (vR <= ", eR, ")) || ((vL <= ", eR, ") && (", eR, " <= vR) && ((", eR, " - vL) >= (", (vW / 2), "))):"].join(""));
                    }
                    //srcLines.push("console.log('"+key+"')");
                    srcLines.push("\n");
                    srcLines.push("return '" + key + "';");
                }
            }
            srcLines.push("default: return null;");
            srcLines.push("}");
            var src = srcLines.join("");

            //console.log(src);
            return new Function("vL", src);
        };

        this.lookup = function (vL) {
            if (!_indexer) {
                _indexer = this.compileIndexer();
            }
            return _indexer(vL);
        };

        this.calculateActiveTab = function () {
            var vL = $container.scrollLeft();
            //$("#txtLog").text(vL);
            var activeTabId = _self.lookup(vL);
            if (activeTabId) {
                //** Sync scroll position to page state
                //use history.pushState instead of setting the location.hash to avoid the infinite loop. Setting the hash would trigger scrolling, which will then set another hash.
                history.pushState("", null, "#" + activeTabId);
                var pair = _tabs[activeTabId];
                if (pair) {
                    _self.setActiveClass(pair);
                }
            }
        };

        this.startTrackingScrollPosition = function () {
            if (_timer) {
                return;
            }
            _timer = setInterval(function () {
                _self.calculateActiveTab();
            }, 100);
        };

        this.stopTrackingScrollPosition = function () {
            if (_timer) {
                clearInterval(_timer);
                _timer = null;
            }
        };

        this.setActiveClass = function (pair) {
            $headers.removeClass(_activeClassName);
            $tabs.removeClass(_activeClassName);
            $(pair.header).addClass(_activeClassName);
            $(pair.body).addClass(_activeClassName);
        };

        this.init = function () {
            //calc the current tab, then throttle this function to avoid calling too many times
            _self.calculateActiveTab();
            _self.calculateActiveTab = throttle(_self.calculateActiveTab, 100);

            //recompile the indexer when the window change sizes
            $(window).on("resize", throttle(function () {
                _indexer = _self.compileIndexer();
                _self.calculateActiveTab();
            }, 200));

            //NOTE:this detect the availability of the Touch Event API, not the hardware capability
            if (Modernizr.touch) {
                //start polling for scrolling position when dragging start, and stop when dragging end
                $container.hammer()
                .on("dragstart", _self.startTrackingScrollPosition)
                .on("dragend", _self.stopTrackingScrollPosition);
            } else {
                //use the scroll event on the desktop
                $container.on("scroll", _self.calculateActiveTab);
            }

            //** Sync page state to scroll position
            $(window).on("hashchange", function () {
                var hash = window.location.hash || "", pair;
                hash = hash.replace("#", "");
                if (hash && (pair = _tabs[hash])) {
                    //$container.scrollLeft($(pair.body).position().left);
                    // Add scrollTo for Smooth scrolling
                    //$container.scrollTo($(pair.body).position().left, 500);
                    $container.animate({ scrollLeft: $(pair.body).position().left }, 100);
                    _self.setActiveClass(pair);
                }
            });
        };

        this.init();
    };

    return new TabManager(container, tabs, headers);
};