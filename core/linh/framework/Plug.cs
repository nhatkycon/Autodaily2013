using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Data.SqlClient;
namespace linh.frm
{
    public interface IPlug
    {
        #region Thuộc tính

        /// <summary>
        /// Mã của Plugin
        /// </summary>
        string PluginId { get; set; }

        /// <summary>
        /// Id khi render ra
        /// </summary>
        string PluginClientId { get; set; }


        /// <summary>
        /// Vị trí của Module
        /// </summary>
        string PluginIndex { get; set; }

        /// <summary>
        /// Index của Zone
        /// </summary>
        string ZoneIndex { get; set; }

        /// <summary>
        /// Tiêu đề của Plugin
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Ảnh đại diện của Plugin
        /// </summary>
        string PluginIcon { get; set; }
        /// <summary>
        /// Hiển thị
        /// </summary>
        bool Display { get; set; }

        /// <summary>
        /// Hiện viền
        /// </summary>
        bool ShowBorder { get; set; }

        /// <summary>
        /// Hiện Tiêu đề
        /// </summary>
        bool ShowHeader { get; set; }

        /// <summary>
        /// Hiện chân
        /// </summary>
        bool ShowFoot { get; set; }

        /// <summary>
        /// Hạn chế
        /// </summary>
        bool Public { get; set; }
        /// <summary>
        /// Thuộc tính quy định xem  Plugin này có nạp dữ liệu từ file XML gốc hay không
        /// </summary>
        bool IsShared { get; set; }
        /// <summary>
        /// Quy định xem Plugin này có cần add vào danh mục plugin hay không
        /// </summary>
        bool IsInvisible { get; set; }
        /// <summary>
        /// Quy định xem Plugin này là thuộc phần quản trị hay không
        /// </summary>
        bool IsCp { get; set; }
        /// <summary>
        /// Thuộc tính quy định xem Nội dung Plugin này có thể cache lại được không
        /// </summary>
        bool IsCached { get; set; }
        /// <summary>
        /// Kiểu Plugin
        /// </summary>
        string PluginType { get; set; }

        /// <summary>
        /// Đường dẫn FileXml của Plugin
        /// </summary>
        string XmlSourcePath { get; set; }

        /// <summary>
        /// File định nghĩa giao diện của Plugin
        /// </summary>
        string PluginCss { get; set; }
        /// <summary>
        /// Các cài đặt của Plugin
        /// </summary>        
        ModuleSetingTabCollection Tabs { get; set; }

        /// <summary>
        /// Các cài đặt của Plugin dạng XML
        /// </summary>
        XmlNode XmlSetting { get; set; }

        /// <summary>
        /// Văn bản Xml của Plugin
        /// </summary>
        XmlDocument XmlDocSetting { get; set; }
        /// <summary>
        /// Danh sách các người dùng
        /// </summary>
        ModuleSercurityUserCollection Users { get; set; }
        /// <summary>
        /// Nội dung html
        /// </summary>
        string Html { get; set; }
        #endregion

        #region Hàm
        /// <summary>
        /// Nạp Plugin lần đầu tiên chạy; trả về cài đặt của Plugin dạng XML
        /// </summary>
        void ImportPlugin();
        /// <summary>
        /// Nạp các cài đặt cho một Plugin dựa vào XML
        /// </summary>
        /// <param name="SettingNode"></param>
        /// 
        void LoadSetting(XmlNode SettingNode);
        /// <summary>
        /// Nạp cài đặt dựa vào mảng
        /// </summary>
        /// <param name="obj"></param>
        void LoadSetting(object[] obj);
        /// <summary>
        /// Render dạng HTML
        /// </summary>
        /// <returns></returns>        
        string ToHtml();
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// <param name="con"></param>
        void KhoiTao(SqlConnection con);

        void KhoiTao(SqlConnection con, Page page);
        #endregion
    }
}
