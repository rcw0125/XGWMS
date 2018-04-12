<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SXPCSearch.aspx.cs" Inherits="SiteBll_Report_SXPCSearch" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>

<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"
    TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
   <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script> 
    <script language="javascript" src="../../JavaScript/SXPC.js" type="text/javascript"></script>
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
					<TD vAlign="middle" align="center" width="70%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="深加工批次查询"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="AddQuery();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE id="TABLE2" class="fixColStyle" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
    <table class="fixColStyle" id="tblQuery" width="100%" runat="server">
        <tr>
            <td width="10%" style="height: 16px">
                母材批号：</td>
            <td width="15%" style="height: 16px">
                <asp:TextBox ID="txtmcpch" runat="server" Width="90%"></asp:TextBox></td>
            <td width="8%" style="height: 16px">
                母材钢种：</td>
            <td width="17%" style="height: 16px">
                <asp:DropDownList ID="drpmcph" runat="server" Width="95%" DataTextField="mcph" DataValueField="mcph">
                </asp:DropDownList></td>
            <td width="8%" style="height: 16px">
                产品批号：</td>
            <td width="17%" style="height: 16px">
                <asp:TextBox ID="txtpch" runat="server" Width="80%"></asp:TextBox>
                </td>
            <td width="8%" style="height: 16px">
                产品钢种：</td>
            <td width="17%" style="height: 16px"><asp:DropDownList ID="drpph" runat="server" Width="95%" DataTextField="ph" DataValueField="ph">
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 16px" width="10%">
                <asp:CheckBox ID="cbdysj" runat="server" Text="产品打印时间" /></td>
            <td colspan="3" style="height: 16px">
                <asp:TextBox ID="txtStartTime" runat="server" Width="100px"></asp:TextBox><img
                    onclick="calendar(txtStartTime);" src="../../Images/icon/calendar.gif" style="cursor: hand" />至<asp:TextBox
                        ID="txtEndTime" runat="server" Width="100px"></asp:TextBox><img onclick="calendar(txtEndTime);"
                            src="../../Images/icon/calendar.gif" style="cursor: hand" />
            </td>
            <td style="height: 16px" width="8%">
            </td>
            <td style="height: 16px" width="17%">
            </td>
            <td style="height: 16px" width="8%">
            </td>
            <td style="height: 16px" width="17%">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click" /></td>
        </tr>
    </table>
    <TABLE  id="tblList" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;浏览信息</font></TD>
					<TD vAlign="bottom" width="88%" bgColor="#dce8f4" height="20"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
			</TABLE>
    <uc2:PageControl ID="PageControl1" runat="server" />
    <DIV style="BORDER:0px;PADDING:0px;MARGIN:0px;width:99%;height:420px;overflow:auto;white-space:nowrap;">
                <asp:GridView ID="grvFYDList" runat="server" AutoGenerateColumns="False" Width="1200px" OnRowDataBound="grvFYDList_RowDataBound" AllowSorting="True" OnRowCreated="grvFYDList_RowCreated" OnSorting="grvFYDList_Sorting">
                    <Columns>
                        <asp:BoundField DataField="mcbarcode" HeaderText="母材条码" SortExpression="mcbarcode" />
                        <asp:BoundField DataField="mcwlh" HeaderText="母材物料" SortExpression="mcwlh" />
                        <asp:BoundField DataField="mcph" HeaderText="母材钢种" SortExpression="mcph" />
                        <asp:BoundField DataField="mcgg" HeaderText="母材规格" SortExpression="mcgg" />
                        <asp:BoundField DataField="MCSX" HeaderText="母材属性" />
                        <asp:BoundField DataField="barcode" HeaderText="产品条码" SortExpression="barcode" />
                        <asp:BoundField DataField="WLH" HeaderText="产品物料" SortExpression="wlh" />
                        <asp:BoundField DataField="ph" HeaderText="产品钢种" SortExpression="ph" />
                        <asp:BoundField DataField="gg" HeaderText="产品规格" SortExpression="gg" />
                        <asp:BoundField DataField="SX" HeaderText="产品属性" />
                        <asp:BoundField DataField="mczl" HeaderText="母材重量" SortExpression="mczl" />
                        <asp:BoundField DataField="zl" HeaderText="产品重量" SortExpression="zl" />
                        <asp:BoundField DataField="zlxh" HeaderText="重量消耗" SortExpression="zlxh" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderTest" />
             </asp:GridView>
        </DIV>
        <input id="hidQuery" type="hidden" runat="server" />
        <input id="hidConfig" type="hidden" runat="server" />
    </form>
</body>
</html>