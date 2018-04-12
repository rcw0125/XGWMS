<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AfficheView.aspx.cs" Inherits="SiteBll_SysMan_AfficheView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>察看公告详情</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
     <TABLE class="fixColStyle" id="Table2" height="28" cellSpacing="0" cellPadding="0" width="100%"
				align="center" background="../../images/icon/topbg.gif" border="0">
				<TR>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					
					<TD vAlign="middle" align="center" width="96%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="公告详细信息"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	    </TABLE>
	    <TABLE id="TABLE1" class="fixColStyle" style="DISPLAY:block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;头信息</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20">
                </TD>
		</TR>
	</TABLE>
	 <table class="fixColStyle" id="tblQuery" width="100%" runat="server">
        <tr>
            <td width="10%" style="height: 16px">
                &nbsp;标题：</td>
            <td colspan="4" style="height: 16px">
                <asp:Label ID="lblTitle" runat="server" Width="100%"></asp:Label></td>
            <td width="17%" style="height: 16px">
                &nbsp;</td>
            <td width="8%" style="height: 16px">
                </td>
            <td width="17%" style="height: 16px">
                </td>
        </tr>
        <tr>
            <td style="height: 16px" width="10%">
                &nbsp;发布人：</td>
            <td style="height: 16px" width="15%">
                <asp:Label ID="lblUserName" runat="server" Width="100%"></asp:Label></td>
            <td style="height: 16px" width="8%">
                发布时间：</td>
            <td colspan="2" style="height: 16px">
                <asp:Label ID="lblTime" runat="server" Width="100%"></asp:Label></td>
            <td style="height: 16px" width="17%">
            </td>
            <td style="height: 16px" width="8%">
            </td>
            <td style="height: 16px" width="17%">
                </td>
        </tr>
    </table>
     <TABLE id="TABLE3" class="fixColStyle" style="DISPLAY:block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细内容</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
	<center>
	<table>
	    <tr>
	        <td valign="middle">
                <asp:Literal ID="liContent" runat="server"></asp:Literal></td>
	    </tr>
	</table>
	</center>
    </form>
</body>
</html>
