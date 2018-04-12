<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OutDoorOK.aspx.cs" Inherits="SiteBll_InDoor_OutDoorOK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>提示</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/IndoorMan.js" type="text/javascript">
	</script>
</head>
<body>
<form id="Form1" runat="server">
<table width="250" border="0">
  <tr>
    <td style="text-align: center">该发运单存在没有装车的条目，是否出门?</td>
  </tr>
  <tr>
    <td style="text-align: center"><table width="100%" border="0">
      <tr>
        <td>
            <asp:ImageButton ID="btnOK" ImageUrl="../../Images/icon/img20.gif" runat="server" OnClick="btnOK_Click" /></td>
        <td>
            <img src="../../Images/icon/imgcancle1.gif" onclick="CloseCheckFYD()"  style="CURSOR: hand" /></td>
      </tr>
    </table>
        <input id="Hidden1" style="width: 19px" runat="server" type="hidden" /></td>
  </tr>
</table>
</form>
</body>
</html>
