<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="lib_ajax_Game_Default" %>
<%@ Register src="~/lib/ui/auto/game/templates/GameItem.ascx" tagname="GameItem" tagprefix="uc1" %>
<%@ Register src="~/lib/ui/auto/game/templates/QuestionItem.ascx" tagname="QuestionItem" tagprefix="uc1" %>
<%@ Register src="../../ui/Auto/Game/templates/AnswerList.ascx" tagname="AnswerList" tagprefix="uc2" %>
<%@ Register src="../../ui/Auto/Game/templates/AnswerItem.ascx" tagname="AnswerItem" tagprefix="uc3" %>
<uc1:GameItem ID="GameItem1" runat="server" Visible="False" />
<uc1:QuestionItem ID="QuestionItem1" runat="server" Visible="False" />
<uc2:AnswerList ID="AnswerList1" runat="server" Visible="False"  />
<uc3:AnswerItem ID="AnswerItem1" runat="server" Visible="False"  />

