<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StoreSet.aspx.cs" Inherits="SiteBll_SysMan_StoreSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>仓库定义</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/SysMan.js" type="text/javascript">
	</script>
</head>
<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fixColStyle" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0"
				runat="server">
				<TR>
					<TD colSpan="2" height="1"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
				align="center" background="../../images/icon/topbg.gif" border="0">
				<TR>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG id="" style="CURSOR: hand" onclick="AddFull(1);" alt="全屏" src="../../images/icon/arrowleft.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG id="IMG1" style="CURSOR: hand" onclick="AddFull(0);" alt="返回" src="../../images/icon/arrowright.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="90%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="系统仓库维护"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="tblEdit" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD style="HEIGHT: 19px" vAlign="bottom" align="left" width="12%" bgColor="#dce8f4"
						height="19"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;新建仓库</font></TD>
					<TD style="HEIGHT: 19px" vAlign="bottom" width="88%" bgColor="#dce8f4" height="19"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">注：页面中带*项为必添项</label></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="2">
					    <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <TD width="10%" style="height: 25px">&nbsp;仓库编码<FONT face="宋体" color="#ff9966">*</FONT></TD>
			                    <TD width="15%" align="left" style="height: 25px"><FONT face="宋体">
                                    <asp:TextBox ID="txtCKID" runat="server" Width="40%" MaxLength="3"></asp:TextBox></FONT></TD>
			                    <TD width="12.5%" style="height: 25px">&nbsp;NC标识<FONT face="宋体" color="#ff9966">*</FONT></TD>
			                    <TD width="12.5%" align="left" style="height: 25px">
                                    <asp:TextBox ID="txtNCID" runat="server" Width="90%"></asp:TextBox></TD>
			                    <TD style="width: 147px; height: 25px;"><FONT face="宋体">&nbsp;</FONT></TD>
			                    <TD width="12.5%" style="height: 25px"></TD>
			                    <TD width="12.5%" style="height: 25px"><FONT face="宋体">&nbsp;</FONT></TD>
			                    <TD width="12.5%" style="height: 25px"></TD>
		                    </TR>
		                    <TR>
		                        <TD><FONT face="宋体">&nbsp;仓库名称<FONT face="宋体" color="#ff9966">*</FONT></TD>
		                        <TD colspan="2" align="left">
                                    <asp:TextBox ID="txtCKName" runat="server" Width="90%"></asp:TextBox><FONT face="宋体"></FONT></TD>
		                        <TD></TD>
		                        <TD style="width: 147px"><FONT face="宋体"></FONT></TD>
		                        <TD></TD>
		                        <TD><FONT face="宋体"></FONT></TD>
		                        <td><FONT face="宋体"></FONT></td>
	                        </TR>
	                    </TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="left" colSpan="2" style="height: 20px">&nbsp;<asp:imagebutton id="imgBtnSumbit" runat="server" ToolTip="点击“新建”，提交新建信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/imgNew1.gif" OnClick="imgBtnSumbit_Click"></asp:imagebutton>
						&nbsp;&nbsp; &nbsp;
                        <asp:ImageButton ID="imgBtnReset" runat="server" ToolTip="点击“重置”，把编制信息还原成初始状态。" ImageUrl="../../images/icon/img12.gif" OnClick="imgBtnReset_Click"/>
                        &nbsp;<b><asp:label id="m_labError" runat="server" ForeColor="Red"></asp:label></b>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细信息</font></TD>
					<TD vAlign="bottom" width="97%" bgColor="#dce8f4" height="20"></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
			</TABLE>
			<DIV id="ListDiv" style="OVERFLOW-Y: visible; OVERFLOW-X: visible; WIDTH: 100%; HEIGHT: 100%">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="511px" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CKID" HeaderText="仓库编码" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CKNCID" HeaderText="NC标识" />
                        <asp:BoundField DataField="CKName" HeaderText="仓库名称" />
                        <asp:TemplateField HeaderText="修改">
                            <ItemTemplate>
                              <asp:ImageButton ID="imgBtnModify" runat="server" ImageUrl="../../Images/icon/imgChange1.gif" CommandName="imgBtnModify" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnDelete" runat="server" CommandName="imgBtnDelete" ImageUrl="../../Images/icon/img19.gif" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                    <SelectedRowStyle BackColor="#DCE8F4" />
                </asp:GridView>
			</DIV>
		</form>
	</body>
</html>
