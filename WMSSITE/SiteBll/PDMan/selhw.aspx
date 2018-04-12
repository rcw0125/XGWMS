<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selhw.aspx.cs" Inherits="SiteBll_PDMan_selhw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择货位</title>
        <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
        <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="JAVASCRIPT" src="../../JavaScript/PDMan.js" type="text/javascript">
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0">
    <tr>
    <td style="width: 80px; height: 50px" align="center">
        请选择货位</td>
    <td style="width: 130px; height: 50px" align="center">
        <asp:DropDownList ID="drpHW" runat="server" Width="120px">
        </asp:DropDownList>
        <input id="hidYSDH" style="width: 1px; height: 13px" type="hidden" runat="server" />
        <input id="hidbarcode" style="width: 1px; height: 13px" type="hidden" runat="server" />
        <input id="hidpch" style="width: 1px; height: 13px" type="hidden" runat="server" />
        <input id="hidsx" style="width: 1px; height: 13px" type="hidden" runat="server" />
        <input id="hidck" style="width: 1px; height: 13px" runat="server" type="hidden" /></td>
    <td style="height: 50px; width: 100px;" align="center"><table border="0"><tr><td align="center" style="width: 69px; height: 41px">
        <Img src="../../Images/icon/img20.gif" ID="btnOK"  runat="server" onclick="HWisOK()" style="cursor: hand"/></td></tr><tr><td align="center" style="width: 69px; height: 3px">
            <Img src="../../Images/icon/img22.gif" ID="btncancel" onclick="window.close();"  runat="server" style="cursor: hand"/></td></tr></table></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
