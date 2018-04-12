<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataReturn.aspx.cs" Inherits="SiteBll_DataOpern_DataReturn" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>数据回迁</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/DataOper.js" type="text/javascript"></script>
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
					<TD vAlign="middle" align="center" width="92%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="数据回迁"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE id="TABLE2" class="fixColStyle" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20">
                </TD>
		</TR>
	</TABLE>
    <table class="fixColStyle" id="tblQuery" width="100%" runat="server">
        <tr>
            <td width="10%" style="height: 16px">
                &nbsp;批次号：</td>
            <td></td>
            <td style="height: 16px" colspan="2">
                <asp:TextBox ID="txtPCH" runat="server" Width="138px"></asp:TextBox>
            </td>
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
    <TABLE id="TABLE3" class="fixColStyle" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;批次信息</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
	<uc1:PageControl ID="PageControl1" runat="server" />
	<div style="overflow:auto;height:250px; width:100%">
        <asp:GridView ID="grdPCH" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdPCH_RowDataBound" Width="320px" OnRowCommand="grdPCH_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="回迁">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBtnReturn" runat="server" ImageUrl="../../Images/icon/datareturn.gif" CommandName="imgBtnReturn" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="PCH" HeaderText="批次号" />
            </Columns>
            <HeaderStyle CssClass="fixHeaderStyle" BackColor="#DCE8F4" />
        </asp:GridView>  
	</div>
	<TABLE id="TABLE4" class="fixColStyle" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细信息</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
	<iframe id="ifPCHDetail" width="100%" height="230px" style="overflow-x:hidden"></iframe>
    </form>
</body>
</html>
