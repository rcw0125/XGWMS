<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HWView.aspx.cs" Inherits="SiteBll_StockMan_HWView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>货位视图</title>
    <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../JavaScript/HWView.js" type="text/javascript"></script>
</head>
<body leftmargin="0" topmargin="0" onload="Init();">
    <form id="form1" runat="server">
    <TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
				align="center" background="../../images/icon/topbg.gif" border="0">
				<TR>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" style="width: 2%"><IMG id="" style="CURSOR: hand" onclick="AddFull(1);" alt="全屏" src="../../images/icon/arrowleft.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG id="IMG1" style="CURSOR: hand" onclick="AddFull(0);" alt="返回" src="../../images/icon/arrowright.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="80%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="查看货位视图"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="AddQuery();" alt="关闭" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<table width="100%">
	    <TR>
			<TD vAlign="bottom" align="left" width="100%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
		</TR>
	</table>
	<TABLE class="fixColStyle" id="tblQuery" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD align="center" colSpan="2" style="height: 80px">
					    <TABLE class="fixColStyle" id="tblEdit" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				            <TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="2">
					    <TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="2">
		                    <TR>
			                    <TD width="10%" style="height: 19px" align="left">
                                    &nbsp;&nbsp;
                                    仓库：</TD>
			                    <TD width="10%" align="left"><FONT face="宋体"><asp:DropDownList ID="drpStore" runat="server" Width="95%" DataTextField="CKID" DataValueField="CKID">
                                    </asp:DropDownList></FONT></TD>
			                    <TD style="width: 10%;">
                                    最小行：</TD>
			                    <TD width="10%" align="left"  colspan="0" rowspan="0">
                                    <table style="width: 100%; height: 100%">
                                        <tr>
                                            <td rowspan="2">
                                                <asp:TextBox ID="txtMinRow" runat="server" Width="90%">1</asp:TextBox></td>
                                            <td style="height: 12px">
                                                <img src="../../images/header/up.gif" style="CURSOR: hand" onclick="AddMinRow();" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 31px;">
                                                <img src="../../images/header/down.gif" style="CURSOR: hand" onclick="SubtractMinRow();" /></td>
                                        </tr>
                                    </table>   
                                </TD>
			                    <TD width="10%"><FONT face="宋体">最大行：</FONT></TD>
			                    <TD width="10%">
                                    <table style="width: 100%; height: 100%">
                                        <tr>
                                            <td rowspan="2">
                                                <asp:TextBox ID="txtMaxRow" runat="server" Width="90%">99</asp:TextBox></td>
                                            <td>
                                                <img src="../../images/header/up.gif" style="CURSOR: hand" onclick="AddMaxRow();" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 31px;">
                                                <img src="../../images/header/down.gif" style="CURSOR: hand" onclick="SubtractMaxRow();" /></td>
                                        </tr>
                                    </table>
                                </TD>
			                    <TD width="10%"><FONT face="宋体">最小列：</FONT></TD>
			                    <TD width="10%">
			                        <table style="width: 100%; height: 100%">
                                        <tr>
                                            <td rowspan="2">
                                                <asp:TextBox ID="txtMinCol" runat="server" Width="90%">1</asp:TextBox></td>
                                            <td>
                                                <img src="../../images/header/up.gif" style="CURSOR: hand" onclick="AddMinCol();" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 31px;">
                                                <img src="../../images/header/down.gif" style="CURSOR: hand" onclick="SubtractMinCol();" /></td>
                                        </tr>
                                    </table>
                                </TD>
                                <td>
                                    最大列：</td>
                                <td width="10%">
                                    <table style="width: 100%; height: 100%">
                                        <tr>
                                            <td rowspan="2">
                                                <asp:TextBox ID="txtMaxCol" runat="server" Width="90%">99</asp:TextBox></td>
                                            <td>
                                                <img src="../../images/header/up.gif" style="CURSOR: hand" onclick="AddMaxCol();" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 31px;">
                                                <img src="../../images/header/down.gif" style="CURSOR: hand" onclick="SubtractMaxCol();"/></td>
                                        </tr>
                                    </table>
                                </td>
		                    </TR>
                            <tr>
                                <td width="10%">
                                    货位区域大小：</td>
                                <td align="left" width="10%">
                                    宽：<asp:TextBox ID="txtWidth" runat="server" Width="26px">180</asp:TextBox>高：<asp:TextBox
                                        ID="txtHeight" runat="server" Width="27px">120</asp:TextBox></td>
                                <td style="width: 10%;">
                                    <input id="hidQuery" runat="server" type="hidden" /></td>
                                <td align="left" colspan="2">
                                    </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td width="10%">
                                </td>
                                <td>
                                </td>
                                <td>
                                    <img src="../../Images/icon/img20.gif" style="cursor:hand;" onclick="GetHWView();" id="IMG2" />&nbsp;</td>
                            </tr>
	                    </TABLE>
					        </TD>
				        </TR>
			        </TABLE>
					</TD>
				</TR>
			</TABLE>
			<iframe id="iframeHW" src="" width="100%" height="400px" scrolling="auto"></iframe>
    </form>
</body>
</html>
