<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KCList.aspx.cs" Inherits="SiteBll_Report_KCList" %>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>库存明细表</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/FYDList.js" type="text/javascript"></script> 
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
					<TD vAlign="middle" align="center" width="92%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="库存明细表"></asp:literal></font></TD>
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
            <td style="height: 24px; width: 10%;">
                &nbsp;仓库：</td>
            <td style="height: 24px; width: 18%;" colspan="2">
                <asp:DropDownList ID="drpStore" runat="server" Width="95%" DataTextField="CKCKName" DataValueField="CKID" AutoPostBack="True" OnSelectedIndexChanged="drpStore_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="height: 24px; width: 8%;">
                &nbsp;批次号：</td>
            <td style="height: 24px;width:20%">
                &nbsp;<asp:DropDownList ID="drpPCH" runat="server" Width="95%">
                    <asp:ListItem Value="0">请选择</asp:ListItem>
                </asp:DropDownList></td>
            <td width="8%" style="height: 24px">
                排序方式：
             </td>
             <td width="16%" style="height: 24px">
                 <asp:DropDownList ID="drpOrderBy" runat="server" Width="95%">
                     <asp:ListItem Value="WeightRQ">请选择</asp:ListItem>
                     <asp:ListItem Value="CK">仓库</asp:ListItem>
                     <asp:ListItem Value="PH">牌号</asp:ListItem>
                     <asp:ListItem Value="GG">规格</asp:ListItem>
                     <asp:ListItem Value="SX">属性</asp:ListItem>
                     <asp:ListItem Value="HW">货位</asp:ListItem>
                     <asp:ListItem Value="qcsl">初库存数量</asp:ListItem>
                     <asp:ListItem Value="qczl">初库存重量</asp:ListItem>
                     <asp:ListItem Value="SL">现库存数量</asp:ListItem>
                     <asp:ListItem Value="ZL">现库存重量</asp:ListItem>
                     <asp:ListItem Value="WeightRQ">生产日期</asp:ListItem>
                 </asp:DropDownList></td>
            <td width="10%" style="height: 24px">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click"/>
                </td>
            <td width="10%" style="height: 24px">
                </td>
        </tr>
    </table>
    <cc1:ReportView ID="ReportView1" runat="server" Width="100%" Height="550px" />
    </form>
</body>
</html>
