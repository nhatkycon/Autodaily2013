using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using docsoft;
using System.Web.UI;
[assembly: WebResource("docsoft.plugin.hethong.banlamviec.js.admin.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.banlamviec.css.Module.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.banlamviec.css.Pages.css", "text/css", PerformSubstitution = true)]

namespace plugin.hethong.banlamviec
{
    public class Class1:PlugUI
    {

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
        public override void AddTabs()
        {
                        
            base.AddTabs();
        }
        public override void LoadSetting(object[] obj)
        {
            
            base.LoadSetting(obj);
        }
        public override void ImportPlugin()
        {
            
            base.ImportPlugin();
        }

    }
}
