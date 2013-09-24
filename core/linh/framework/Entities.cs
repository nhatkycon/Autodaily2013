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
using linh.core;
namespace linh.frm
{
    #region cài đặt Module
    #region Tab
    #region Tab : Phân loại các cài đặt
    /// <summary>
    /// Tab hiện thị trong phần Admin của Module
    /// </summary>
    public class ModuleSetingTab : BaseEntity
    {

        /// <summary>
        /// Contructor
        /// </summary>
        public ModuleSetingTab() { }
        /// <summary>
        /// Id của Tab
        /// </summary>
        public string TabId { get; set; }
        /// <summary>
        /// Thứ tự tab
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Tên tab
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Các cài đặt trong tab
        /// </summary>
        public ModuleSettingCollection Settings { get; set; }

        public override BaseEntity getFromReader(System.Data.IDataReader rd)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// List các Tab
    /// </summary>
    public class ModuleSetingTabCollection : BaseEntityCollection<ModuleSetingTab>
    {
        public ModuleSetingTabCollection() { }
    }
    #endregion

    #region ModuleSetting : Các cài đặt trong Tab
    /// <summary>
    /// Các cài đặt trong tab
    /// </summary>
    public class ModuleSetting : BaseEntity
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public ModuleSetting() { }
        /// <summary>
        /// List các giá trị nếu cài đặt có nhiều giá trị
        /// </summary>
        public ModuleSettingItemCollection Childrens { get; set; }
        /// <summary>
        /// Tên cài đặt
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Kiểu dữ liệu
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Giá trị
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Tiêu đề của Thuộc tính
        /// </summary>
        public string Title { get; set; }
        public ModuleSetting(string _key, string _type, string _value,string _title)
        {
            Key = _key;
            Type = _type;
            Value = _value;
            Title = _title;
        }
        public ModuleSetting(string _key, string _type, string _value, string _title, ModuleSettingItemCollection _Childrens)
        {
            Key = _key;
            Type = _type;
            Value = _value;
            Title = _title;
            Childrens = _Childrens;
        }

        public override BaseEntity getFromReader(System.Data.IDataReader rd)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// List các cài đặt con
    /// </summary>
    public class ModuleSettingCollection : BaseEntityCollection<ModuleSetting>
    {
        public ModuleSettingCollection() { }
    }
    #endregion

    #region ModuleSettingItem : Nếu một cài đặt có nhiều lựa chọn sẽ sinh ra dạng list các lựa chọn con
    /// <summary>
    /// Các giá trị con trong trường hợp một Cài đặt có nhiều giá trị
    /// </summary>
    public class ModuleSettingItem : BaseEntity
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public ModuleSettingItem() { }
        /// <summary>
        /// Trạng thái được lựa chọn
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Giá trị
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Thứ tự
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Giá trị hiển thị
        /// </summary>
        public string Html { get; set; }
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_selected"></param>
        /// <param name="_value"></param>
        /// <param name="_index"></param>
        public ModuleSettingItem(bool _selected
            , string _value, int _index)
        {
            Selected = _selected;
            Value = _value;
            Index = _index;
        }
        public ModuleSettingItem(bool _selected
            , string _value, int _index,string _Html)
        {
            Selected = _selected;
            Value = _value;
            Index = _index;
            Html = _Html;
        }

        public override BaseEntity getFromReader(System.Data.IDataReader rd)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// List các giá trị con
    /// </summary>
    public class ModuleSettingItemCollection : BaseEntityCollection<ModuleSettingItem>
    {
        public ModuleSettingItemCollection() { }
    }
    #endregion
    #endregion
    #region Phân quyền
    #region ModuleSercurityUser : Phân quyền theo người dùng
    /// <summary>
    /// Người dùng được add vào phân quyền
    /// </summary>
    public class ModuleSercurityUser : BaseEntity
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public ModuleSercurityUser() { }
        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Quyền - 0: Cấm truy cập; 1: Truy cập chỉ đọc; 2: Admin
        /// </summary>
        public int Permision { get; set; }

        public override BaseEntity getFromReader(System.Data.IDataReader rd)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Danh sách người dùng
    /// </summary>
    public class ModuleSercurityUserCollection : BaseEntityCollection<ModuleSercurityUser>
    {
        public ModuleSercurityUserCollection() { }
    }
    #endregion

    #endregion

    #endregion
}
