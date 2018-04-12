<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FYListView.aspx.cs" Inherits="SiteBll_Report_FYListView" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>

<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"
    TagPrefix="uc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发运清单</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/FYDList.js" type="text/javascript"></script>
</head>
<body leftmargin="0" topmargin="0" onload="InitLoad();">
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
					<TD vAlign="middle" align="center" width="70%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="发运清单"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="AddQuery();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">列表配置</label><IMG id="imgBtnconfig" style="CURSOR: hand" onclick="AddConfig();" alt="关闭" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE class="fixColStyle" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
    <table class="fixColStyle" id="tblQuery" width="100%" runat="server">
        <tr>
            <td width="10%" style="height: 16px">
                发运单号：</td>
            <td width="15%" style="height: 16px">
                <asp:TextBox ID="txtFYDH" runat="server" Width="90%"></asp:TextBox></td>
            <td width="8%" style="height: 16px">
                仓库：</td>
            <td width="17%" style="height: 16px">
                <asp:DropDownList ID="drpStore" runat="server" Width="95%" DataTextField="CKCKName" DataValueField="CKID">
                </asp:DropDownList></td>
            <td width="8%" style="height: 16px">
                客户：</td>
            <td width="17%" style="height: 16px">
                <asp:TextBox ID="txtKH" runat="server" Width="80%"></asp:TextBox>
                <img id="imgBtnSearchKH" src="../../Images/icon/point.gif" style="cursor:hand" onclick="OpenKHWindow();" /></td>
            <td width="8%" style="height: 16px">
                车牌号：</td>
            <td width="17%" style="height: 16px">
                <asp:TextBox ID="txtCPH" runat="server" Width="90%"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 16px" width="10%">
            </td>
            <td style="height: 16px" width="15%">
            </td>
            <td style="height: 16px" width="8%">
            </td>
            <td style="height: 16px" width="17">
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
    <uc1:SetDisplayList ID="SetDisplayList1" runat="server" />
    <TABLE  id="tblList" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;浏览信息</font></TD>
					<TD vAlign="bottom" width="88%" bgColor="#dce8f4" height="20"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
			</TABLE>
    <uc2:PageControl ID="PageControl1" runat="server" />
    <DIV style="overflow:auto; WIDTH:100%; HEIGHT: 420px">
                <asp:GridView ID="grvFYDList" runat="server" AutoGenerateColumns="False" Width="1200px" OnRowDataBound="grvFYDList_RowDataBound" AllowSorting="True" OnRowCreated="grvFYDList_RowCreated" OnSorting="grvFYDList_Sorting">
                    <Columns>
                        <asp:TemplateField HeaderText="选择打印">
                            <ItemTemplate>
                               <img src="../../Images/icon/print.gif" id="imgPrint" style="cursor:hand;" onclick="PrintFYD();" />
                                <input id="hidFYDH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.FYDH") %>'/>
                                <input id="hidCPH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CPH") %>'/>
                                <input id="hidType" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.YSLB") %>'/>
                                <input id="hidKHName" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.khname") %>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="FYDH" HeaderText="发运单号" SortExpression="FYDH" />
                        <asp:BoundField DataField="khname" HeaderText="客户" SortExpression="KHBM" />
                        <asp:BoundField DataField="CK" HeaderText="仓库" SortExpression="CK" />
                        <asp:BoundField DataField="YSLB" HeaderText="运输类别" SortExpression="YSLB" />
                        <asp:BoundField DataField="CPH" HeaderText="车牌号" SortExpression="CPH" />
                        <asp:BoundField DataField="WLH" HeaderText="物料号" SortExpression="WLH" />
                        <asp:BoundField DataField="WLMC" HeaderText="物料名称" SortExpression="WLMC" />
                        <asp:BoundField DataField="PH" HeaderText="牌号" SortExpression="PH" />
                        <asp:BoundField DataField="GG" HeaderText="规格" SortExpression="GG" />
                        <asp:BoundField DataField="SX" HeaderText="属性" SortExpression="SX" />
                        <asp:BoundField DataField="JHSL" HeaderText="计划数量" SortExpression="JHSL" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JHZL" HeaderText="计划重量" SortExpression="JHZL" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJSL" HeaderText="实际数量" SortExpression="SJSL" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJZL" HeaderText="实际重量" SortExpression="SJZL" >
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
