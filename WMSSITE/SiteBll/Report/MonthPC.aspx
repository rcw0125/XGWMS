<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthPC.aspx.cs" Inherits="SiteBll_Report_MonthPC" %>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>月盘存明细</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
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
					<TD vAlign="middle" align="center" width="92%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="月盘存明细表"></asp:literal></font></TD>
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
                &nbsp;生产线：</td>
            <td style="height: 24px; width: 30%;" colspan="2">
                <asp:DropDownList ID="drpSCX" runat="server" Width="95%" DataTextField="SCXDESC" DataValueField="SCXBM">
                </asp:DropDownList></td>
            <td style="height: 24px; width: 6%;">
                &nbsp;年份：</td>
            <td style="height: 24px;width:10%">
                &nbsp;<asp:DropDownList ID="drpYear" runat="server" Width="95%">
                    <asp:ListItem Value="0">请选择</asp:ListItem>
                </asp:DropDownList></td>
            <td width="6%" style="height: 24px">
                月份：
             </td>
             <td width="10%" style="height: 24px">
                 <asp:DropDownList ID="drpMonth" runat="server" Width="95%">
                     <asp:ListItem>1</asp:ListItem>
                     <asp:ListItem>2</asp:ListItem>
                     <asp:ListItem>3</asp:ListItem>
                     <asp:ListItem>4</asp:ListItem>
                     <asp:ListItem>5</asp:ListItem>
                     <asp:ListItem>6</asp:ListItem>
                     <asp:ListItem>7</asp:ListItem>
                     <asp:ListItem>8</asp:ListItem>
                     <asp:ListItem>9</asp:ListItem>
                     <asp:ListItem>10</asp:ListItem>
                     <asp:ListItem>11</asp:ListItem>
                     <asp:ListItem>12</asp:ListItem>
                 </asp:DropDownList></td>
            <td width="10%" style="height: 24px">
                &nbsp;排序条件：</td>
            <td width="10%" style="height: 24px">
                <asp:DropDownList ID="drpOrderKey" runat="server" Width="95%">
                    <asp:ListItem Value="SCX">请选择</asp:ListItem>
                    <asp:ListItem Value="PH">钢种</asp:ListItem>
                    <asp:ListItem Value="GG">规格</asp:ListItem>
                    <asp:ListItem Value="qcsl">期初件数</asp:ListItem>
                    <asp:ListItem Value="qczl">期初重量</asp:ListItem>
                    <asp:ListItem Value="bqrksl">本期入库数量</asp:ListItem>
                    <asp:ListItem Value="byrkzl">本期入库重量</asp:ListItem>
                    <asp:ListItem Value="bqcksl">本期出库数量</asp:ListItem>
                    <asp:ListItem Value="bqckzl">本期出库重量</asp:ListItem>
                    <asp:ListItem Value="qmsl">期末数量</asp:ListItem>
                    <asp:ListItem Value="qmzl">期末重量</asp:ListItem>
                </asp:DropDownList></td>
            <td width="10%" style="height: 24px; text-align: center;">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click"/></td>
        </tr>
    </table>
        <cc1:reportview id="ReportView1" runat="server" Width="100%" Height="550px"></cc1:reportview>
    </form>
</body>
</html>
