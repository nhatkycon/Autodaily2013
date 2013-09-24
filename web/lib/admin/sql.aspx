<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sql.aspx.cs" Inherits="lib_aspx_sql" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    input
    {
        background-color:#333;
        color:#4DCB4E;
        border:solid 1px green;
        font-family:Courier;
        font-weight:bold;
        font-size:6pt;
    }
    </style>
</head>
<body style="background-color:Black; color:#4DCB4E; font-size: 10pt; font-family: Courier; margin:0px;">
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" style="overflow:auto; padding:2px; font-family:Courier; font-size:10pt; margin:2px; border:dashed 1px #4DCB4E; background-color:#333; color:#4DCB4E;" runat="server" Height="100px" TextMode="MultiLine" 
            Width="100%"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="NonQuery" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
            Text="view list" />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Cdlick" Text="Scalar" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="File" />
        <br />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <asp:GridView ID="grd" runat="server" BorderColor="#4DCB4E" 
            BorderStyle="Dashed" />
    </div>
    </form>
</body>
</html>
