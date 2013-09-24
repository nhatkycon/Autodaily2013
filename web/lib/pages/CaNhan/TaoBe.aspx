<%@ Page Title="" Language="C#" MasterPageFile="~/lib/master/Content.master" AutoEventWireup="true" CodeFile="TaoBe.aspx.cs" Inherits="lib_pages_CaNhan_TaoBe" %>

<%@ Register src="../../ui/heThong/TaoBe.ascx" tagname="TaoBe" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<div class="full-content effect6">
    <h2>
        <a href="/lib/pages/CaNhan/QuanLyBe.aspx" class="btn btn-default btn-large">
            <i class="icon icon-back icon-large"></i>
            Quay lại
        </a>
    </h2>
    <hr/> 
    <div class="" id="TaobeForm">
        <uc1:TaoBe ID="TaoBe1" runat="server" />        
    </div>   
</div>
</asp:Content>

