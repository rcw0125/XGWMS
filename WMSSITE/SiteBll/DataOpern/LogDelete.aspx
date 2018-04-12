<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogDelete.aspx.cs" Inherits="SiteBll_DataOpern_LogDelete" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>日志删除</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/DataOper.js" type="text/javascript"></script>
    <style>   
    .ctl
    {   
        table-layout:fixed; 
    }   
     .ctl  td{text-overflow:ellipsis;overflow:hidden;white-space:   nowrap;}    
  </style>   
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
					<TD vAlign="middle" align="center" width="92%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="日志删除"></asp:literal></font></TD>
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
                &nbsp;单据类型：</td>
            <td width="15%">
                <asp:DropDownList ID="drpType" runat="server" Width="90%">
                    <asp:ListItem Value="0">请选择</asp:ListItem>
                    <asp:ListItem Value="A4">A4 完工单</asp:ListItem>
                    <asp:ListItem Value="7F">7F 发运单</asp:ListItem>
                    <asp:ListItem Value="4R">4R 盘点单</asp:ListItem>
                    <asp:ListItem Value="4N">4N 形态转换单</asp:ListItem>
                    <asp:ListItem Value="4U">4U 调拨订单</asp:ListItem>
                    <asp:ListItem Value="4K">4K 转库单</asp:ListItem>
                </asp:DropDownList></td>
            <td style="height: 16px" width="8%">
                &nbsp;单据号：</td>
            <td width="10%" style="height: 16px">
                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox></td>
            <td width="8%">
                仓库：</td>
            <td width="18%">
                <asp:DropDownList ID="drpCK" runat="server" width="95%" DataTextField="CKCKName" DataValueField="CKID">
                </asp:DropDownList></td>
            <td width="16%" style="height: 16px">
                &nbsp;</td>
            <td width="16%" style="height: 16px">
                &nbsp;</td>
            <td width="5%" style="height: 16px">
                </td>
        </tr>
        <tr>
            <td style="height: 16px" width="6%">
                &nbsp;发送日期：</td>
            <td width="10%">
                <asp:TextBox ID="txtSTime" runat="server" width="80%"></asp:TextBox>
                <img onclick="calendar(txtSTime);" src="../../Images/icon/calendar.gif" style="cursor: hand" /></td>
            <td colspan="2" style="height: 16px">
                至<asp:TextBox ID="txtETime" runat="server"></asp:TextBox>
                <img onclick="calendar(txtETime);" src="../../Images/icon/calendar.gif" style="cursor: hand" /></td>
            <td width="5%">
            </td>
            <td width="18%">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click" /></td>
            <td width="6%">
            </td>
            <td style="height: 16px" width="16%">
            </td>
            <td style="height: 16px" width="16%">
            </td>
            <td style="height: 16px" width="8%">
            </td>
        </tr>
    </table>
     <TABLE id="TABLE3" class="fixColStyle" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;日志信息</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
        <uc1:PageControl ID="PageControl1" runat="server" />
        <div style="overflow:auto;height:400px; width:100%">
        <asp:GridView ID="grdLog" runat="server" AutoGenerateColumns="False" CssClass="ctl" Width="1000px" OnRowDataBound="grdLog_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_Delete" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="DOCID" HeaderText="单据号" >
                    <ItemStyle Width="100px" />
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="ckname" HeaderText="仓库" >
                    <ItemStyle Width="200px" />
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="DOCType" HeaderText="单据类型" >   
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="ComDes" HeaderText="发送结果">    
                </asp:BoundField>
                <asp:BoundField DataField="ComTime" HeaderText="发送时间" >    
                </asp:BoundField>
                <asp:BoundField DataField="ComXML" HeaderText="文件名称" >    
                    <ItemStyle Width="250px" />
                    <HeaderStyle Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="ComResult" HeaderText="返回代码" >    
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="Comid" HeaderText="COMID" Visible="False" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
            <RowStyle CssClass="showFlowOver" />
        </asp:GridView> 
        </div>
    <TABLE class="fixColStyle" id="TABLE5" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<td width="100%" align="center" valign="bottom">
                        &nbsp;<asp:CheckBox ID="checkAll" runat="server" Text="全选" />
                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:ImageButton ID="imgBtnDelC" runat="server" ImageUrl="../../Images/icon/deletechecked.gif" OnClick="imgBtnDelC_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton ID="imgBtnDelA" runat="server" ImageUrl="../../Images/icon/deleteall.gif" OnClick="imgBtnDelA_Click"  /></td>
				</TR>
			</TABLE>  
    </form>
</body>
</html>
