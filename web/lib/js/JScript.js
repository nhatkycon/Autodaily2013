$(function () {
    $('.cate li').mouseenter(function () {
        $(this).children('ul').show();
    }).mouseleave(function () {
        $(this).children('ul').hide();
    }); ;
});