<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataMoveBrowse.aspx.cs" Inherits="SiteBll_DataOpern_DataMoveBrowse" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据迁移日志浏览</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/DataOper.js" type="text/javascript"></script>
</head>
<body topmargin="0" leftmargin="0">
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
					<TD vAlign="middle" align="center" width="92%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="数据迁移日志浏览"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE id="TABLE2" class="fixColStyle" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20">
                上次迁移时间：<asp:Label ID="lblLastTime" runat="server"></asp:Label></TD>
		</TR>
	</TABLE>
    <table class="fixColStyle" id="tblQuery" width="100%" runat="server">
        <tr>
            <td width="10%" style="height: 16px">
                &nbsp;迁移执行时间：</td>
            <td style="height: 16px" colspan="3">
                <asp:TextBox ID="txtSTime" runat="server" Width="138px"></asp:TextBox><img onclick="calendar(txtSTime);"
                    src="../../Images/icon/calendar.gif" style="cursor: hand" />至<asp:TextBox ID="txtETime"
                        runat="server" Width="138px"></asp:TextBox>
                <img onclick="calendar(txtETime);"
                    src="../../Images/icon/calendar.gif" style="cursor: hand" /></td>
            <td width="8%" style="height: 16px">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click" /></td>
            <td width="17%" style="height: 16px">
                &nbsp;</td>
            <td width="8%" style="height: 16px">
                </td>
            <td width="17%" style="height: 16px">
                </td>
        </tr>
    </table>
    <TABLE id="TABLE3" class="fixColStyle" style="DISPLAY: none" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细信息</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
        <uc1:PageControl ID="PageControl1" runat="server" />
        <br />
        <asp:GridView ID="grvDataMoveLog" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundField DataField="Ope_TableName" HeaderText="迁移表名" />
                <asp:BoundField DataField="Beigin_Time" HeaderText="开始时间" />
                <asp:BoundField DataField="End_Time" HeaderText="结束时间" />
                <asp:BoundField DataField="Data_TimePoint" HeaderText="迁移时间点" />
                <asp:BoundField DataField="Record_Count" HeaderText="迁移记录数" />
                <asp:BoundField DataField="IsSuccess" HeaderText="是否迁移成功" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" />
        </asp:GridView>
    </form>
</body>
</html>
