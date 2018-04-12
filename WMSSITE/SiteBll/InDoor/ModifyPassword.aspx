<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyPassword.aspx.cs" Inherits="SiteBll_InDoor_ModifyPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改密码</title>
    <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="Form1" runat="server">
<table width="100%" border="1">
  <tr>
    <td style="text-align: center">
        IC卡ID</td>
    <td style="text-align: center">
        <asp:TextBox ID="txtICID" runat="server" TextMode="Password"></asp:TextBox>
        <input id="hidICID" runat="server" type="hidden"/></td>
  </tr>
  <tr>
    <td style="text-align: center">
        IC卡号</td>
    <td style="text-align: center">
        <asp:TextBox ID="txtICNumber" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td style="text-align: center">
        原密码</td>
    <td style="text-align: center">
        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td style="text-align: center">
        新密码</td>
    <td style="text-align: center">
        <asp:TextBox ID="txtNewPassword1" runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td style="text-align: center">
        确认新密码</td>
    <td style="text-align: center">
        <asp:TextBox ID="txtNewPassword2" runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
  <tr>
    <td style="text-align: center">
        <asp:ImageButton ID="btnOK" ImageUrl="../../Images/icon/img20.gif" runat="server" OnClick="btnOK_Click" /></td>
    <td style="text-align: center">
        <img src="../../Images/icon/imgCancle1.gif" ID="btnCancel" runat="server"  onclick="window.close()" style="CURSOR: hand"/></td>
  </tr>
</table>
</form>
</body>
</html>
