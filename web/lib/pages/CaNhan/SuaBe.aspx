<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="SuaBe.aspx.cs" Inherits="lib_pages_CaNhan_SuaBe" %>

<%@ Register src="../../ui/CaNhan/SuaBe.ascx" tagname="SuaBe" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<div class="full-content effect6">
    <h2>
        <a href="/lib/pages/CaNhan/QuanLyBe.aspx" class="btn btn-default btn-large">
            <i class="icon icon-back icon-large"></i>
            Quay lại
        </a>
    </h2>
    <hr/> 
    <div class="" id="SuaBeForm">
        <uc1:SuaBe ID="SuaBe1" runat="server" />
    </div>   
</div>    
</asp:Content>

