<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkLoadCount.aspx.cs" Inherits="SiteBll_Report_WorkLoadCount" %>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>工作量统计</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FYDList.js" type="text/javascript"></script>
</head>
<body leftmargin="0" topmargin="0">
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
					<TD vAlign="middle" align="center" width="92%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="高线月盘存表"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE id="TABLE2" class="fixColStyle" style="DISPLAY: none" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
    <table class="fixColStyle" id="tblQuery" width="100%" runat="server">
        <tr>
            <td style="height: 24px; width: 8%;">
                &nbsp;操作员：</td>
            <td style="height: 24px; width: 15%;" colspan="2">
                <asp:DropDownList ID="drpOpern" runat="server" Width="95%" DataTextField="UserName" DataValueField="UserName">
                </asp:DropDownList></td>
            <td style="height: 24px; width: 8%;" colspan="2">
                &nbsp;操作类型：</td>
            <td style="height: 24px; width: 15%;">
                &nbsp;<asp:DropDownList ID="drpType" runat="server" Width="90%" DataTextField="opetype" DataValueField="opetype">
                </asp:DropDownList></td>
            <td style="height: 24px;width:8%">
                &nbsp;操作时间：</td>
            <td style="height: 24px" colspan="4">
                &nbsp;<asp:TextBox ID="txtStartTime" runat="server" Width="40%"></asp:TextBox><img
                    onclick="calendar(txtStartTime);" src="../../Images/icon/calendar.gif" style="cursor: hand" />至<asp:TextBox
                        ID="txtEndTime" runat="server" Width="40%"></asp:TextBox><img onclick="calendar(txtEndTime);"
                            src="../../Images/icon/calendar.gif" style="cursor: hand" /></td>
            <td width="10%" style="height: 24px; text-align: center;">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click"/></td>
        </tr>
    </table>
        <cc1:reportview id="ReportView1" runat="server" Width="100%" Height="600px"></cc1:reportview>
    </form>
</body>
</html>
