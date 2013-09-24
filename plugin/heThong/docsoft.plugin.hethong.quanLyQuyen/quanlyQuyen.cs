using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.frm;
using docsoft;
using docsoft.entities;
using System.Web.UI;
using linh.json;
[assembly: WebResource("docsoft.plugin.hethong.quanLyQuyen.JScript1.js", "text/javascript", PerformSubstitution = true)]
[assembly: WebResource("docsoft.plugin.hethong.quanLyQuyen.htm.htm", "text/html", PerformSubstitution = true)]
namespace docsoft.plugin.hethong.quanLyQuyen
{
    public class Class1:docPlugUI
    {
        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            ClientScriptManager cs = this.Page.ClientScript;
            string _ID = Request["ID"];
            string _CQ_ID = Request["CQ_ID"];
            string _Ten = Request["Ten"];
            string _q = Request["q"];
            string _Loai_Ten = Request["Loai_Ten"];
            string _Loai_ID = Request["Loai_ID"];
            switch (subAct)
            {
                case"get":
                    #region Lấy danh sách
                    if (string.IsNullOrEmpty(jgrsidx)) jgrsidx = "ID";
                    if (string.IsNullOrEmpty(jgrsord)) jgrsord = "asc";
                    RoleCollection ListGet = RoleDal.TreeByUsername(Security.Username, _q, _CQ_ID,"ROLE_" + jgrsidx + " " + jgrsord);
                    List<jgridRow> ListRow = new List<jgridRow>();                    
                    foreach (Role item in ListGet)
                    {
                        ListRow.Add(new jgridRow(item.ID.ToString()
                            , new string[] { 
                            item.ID.ToString(),
                            item.Ten,
                            item.Loai_Ten,
                            item._CoQuan.Ten
                            }));
                    }
                    jgrid grid = new jgrid("1", "1", ListGet.Count.ToString(), ListRow);
                    sb.Append(JavaScriptConvert.SerializeObject(grid));
                        break;
                    #endregion
                case "del":
                    #region Xóa
                        if (!string.IsNullOrEmpty(_ID))
                        {
                            RoleDal.DeleteById(_ID);
                        }
                    break;
                    #endregion
                case "edit":
                    #region chỉnh sửa
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        sb.Append("(" + JavaScriptConvert.SerializeObject(RoleDal.SelectById(Convert.ToInt32(_ID))) + ")");
                    }
                    break;
                    #endregion
                case "save":
                    #region Lưu
                    var ItemSave = new Role();
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = RoleDal.SelectById(Convert.ToInt32(_ID));
                    }
                    ItemSave.Ten = _Ten;
                    ItemSave.CQ_ID =Convert.ToInt32(_CQ_ID);
                    ItemSave.NgayCapNhat = DateTime.Now;
                    ItemSave.Active = true;
                    ItemSave.HeThong = true;
                    if (!string.IsNullOrEmpty(_Loai_ID))
                    {
                        ItemSave.Loai_ID = new Guid(_Loai_ID);                        
                    }
                    ItemSave.Loai_Ten = _Loai_Ten;
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        ItemSave = RoleDal.Update(ItemSave);
                    }
                    else
                    {
                        ItemSave.NgayTao = DateTime.Now;
                        ItemSave.NguoiTao = Security.Username;
                        ItemSave.RowId = Guid.NewGuid();
                        ItemSave = RoleDal.Insert(ItemSave);
                    }
                    sb.Append("1");
                    break;
                    #endregion
                case "getFunction":
                    #region Lấy function theo role
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        FunctionCollection ListFnByRole = FunctionDal.SelectAllFunctionByRole(_ID);
                        if (ListFnByRole.Count > 0)
                        {
                            sb.Append(getTop(ListFnByRole));
                        }
                        else
                        {
                            sb.Append("0");
                        }
                    }
                    break;
                    #endregion
                case "updateFunction":
                    #region Cập nhật thay đổi
                    RoleFunctionDal.UpdateByRoleIdFunctionList(_ID, Request["UpdateList"], Security.Username);
                    sb.Append("1");
                    break;
                    #endregion
                case "getUserByRole":
                #region Lấy thành viên trong nhóm
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        MemberCollection ListUserByRole = MemberDal.SelectByRole(_ID);
                        if (ListUserByRole.Count > 0)
                        {
                            foreach (Member item in ListUserByRole)
                            {
                                sb.AppendFormat(@"<input type=""checkbox"" _username=""{0}"" {2} > <b>{0}</b> [ {1} ] <br/>"
                                    ,item.Username,item.Ten,item.Khoa ? @"checked=""checked""" : "");
                            }
                        }
                        else
                        {
                            sb.Append("0");
                        }
                    }
                    break;
                #endregion
                case "updateUsers":
                    #region Lưu thay đổi thành viên trong nhóm
                    if (!string.IsNullOrEmpty(_ID))
                    {
                        MemberRoleDal.UpdateUserListRole(Request["UpdateList"], _ID, Security.Username);
                        sb.AppendFormat("1");
                    }
                    break;
                    #endregion
                default:
                    #region nạp
                    FunctionCollection ListFn = FunctionDal.SelectByUserAndFNID(Security.Username, fnId);
                    sb.Append(@"<div class=""mdl-head"">
<span class=""mdl-head-searchPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" class=""mdl-head-txt mdl-head-search mdl-head-search-quanLyQuyen"" />
</span>
<a class=""mdl-head-btn mdl-head-add"" id=""quanLyQuyenMdl-addBtn"" href=""javascript:quanLyQuyen.add();"">Thêm</a>
<a class=""mdl-head-btn mdl-head-edit"" id=""quanLyQuyenMdl-editBtn"" href=""javascript:quanLyQuyen.edit();"">Sửa</a>
<a class=""mdl-head-btn mdl-head-del"" id=""quanLyQuyenMdl-delBtn"" href=""javascript:quanLyQuyen.del();"">Xóa</a>
<span class=""mdl-head-filterPnl ui-state-default ui-corner-all"">
<a href=""javascript:;"" class=""mdl-head-clearSearch""></a>
<input type=""text"" _value="""" class=""mdl-head-filter mdl-head-filterQuanLyQuyenByCQID""/>
</span>
</div>
<table id=""quanLyQuyenMdl-List"" class=""mdl-list"">
</table>
<div id=""quanLyQuyenMdl-Pager""></div>

<div class=""sub-mdl quanLyQuyenMdl-subMdl"">
    <ul>
        <li>
            <a id=""quanLyQuyenMdl-functionmdl-subMdlBtn"" href=""#quanLyQuyenMdl-subMdl-mdl1"">Quyền</a>
        </li>
        <li>
            <a id=""quanLyQuyenMdl-usermdl-subMdlBtn"" href=""#quanLyQuyenMdl-subMdl-mdl2"">Người dùng thuộc nhóm</a>
        </li>
    </ul>
    <div id=""quanLyQuyenMdl-subMdl-mdl1"">
        <div id=""quanLyQuyenMdl-functionmdl-roleFnMdl"">
        </div>
    </div>
    <div id=""quanLyQuyenMdl-subMdl-mdl2"">
        <div id=""quanLyQuyenMdl-functionmdl-UserInRoleMdl"">
        </div>
    </div>
</div>

");
                    sb.AppendFormat(@"<script>$.getScript('{0}',function(){1});</script>"
                        , cs.GetWebResourceUrl(typeof(Class1), "docsoft.plugin.hethong.quanLyQuyen.JScript1.js")
                        , "{quanLyQuyen.loadgrid();}");                    
                    sb.AppendFormat("<script>adm.validFn('{0}');</script>", JavaScriptConvert.SerializeObject(ListFn));                    
                    break;
                #endregion
            }
            writer.Write(sb.ToString());
            base.Render(writer);
        }
        #region nghiệp vụ cho coquanfunction
        string getTop(FunctionCollection list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Function item in list)
            {
                if (item.PID == 0)
                {
                    var childInSide = hasChild(item.ID, list);
                    sb.AppendFormat(@"<li id=""phtml_{1}"" _ID=""{1}"" class=""{3}  {2}""><a href=""javascript:;"">{0}</a>"
                        , item.Ten, item.ID, item.Active ? "jstree-checked" : "jstree-unchecked"
                        , childInSide ? "jstree-open" : "");
                    if (childInSide)
                    {
                        sb.Append(getChild(item.ID, list));
                    }
                    sb.AppendFormat("</li>");
                }
            }
            return sb.ToString();
        }
        string getChild(int _Id, FunctionCollection list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ul>");
            foreach (Function item in list)
            {
                if (item.PID == _Id)
                {
                    var childInSide = hasChild(item.ID, list);
                    sb.AppendFormat(@"<li id=""phtml_{1}"" class=""{3} {2}"" _ID=""{1}"" ><a href=""javascript:;"">{0}</a>", item.Ten, item.ID
                        , item.Active ? "jstree-checked" : "jstree-unchecked", childInSide ? "jstree-open" : "");
                    if (childInSide)
                    {
                        sb.Append(getChild(item.ID, list));
                    }
                    sb.AppendFormat("</li>");
                }
            }
            sb.AppendFormat("</ul>");
            return sb.ToString();
        }
        bool hasChild(int _Id, FunctionCollection list)
        {
            bool oke = false;
            foreach (Function item in list)
            {
                if (item.PID == _Id && item.ID != _Id)
                {
                    return true;
                }
            }
            return oke;
        }
        #endregion
    }
}
