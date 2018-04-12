<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParamSet.aspx.cs" Inherits="SiteBll_SysMan_ParamSet" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>参数设置</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/SysMan.js" type="text/javascript">
	</script>
</head>
<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="table1" cellSpacing="0" cellPadding="0" width="100%" border="0"
				runat="server">
				<TR>
					<TD colSpan="2" height="1"></TD>
				</TR>
			</TABLE>
			<TABLE id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
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
					<TD vAlign="middle" align="center" width="90%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="系统参数维护"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<TABLE id="tblEdit" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD style="HEIGHT: 19px" vAlign="bottom" align="left" width="12%" bgColor="#dce8f4"
						height="19"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;数据编辑</font></TD>
					<TD style="HEIGHT: 19px" vAlign="bottom" width="88%" bgColor="#dce8f4" height="19"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="left" colSpan="2">
					    <fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">信息纬度</font></legend>
				            <TABLE cellSpacing="0" cellPadding="0" width="600" border="0">
					        <TR>
						        <TD width="15%" style="height: 19px">&nbsp;参数值：<LABEL style="COLOR: #ff0033">*</LABEL></TD>
						        <TD width="85%" style="height: 19px">
                                    <asp:TextBox ID="txtValue" runat="server" Width="95%"></asp:TextBox></TD>
					        </TR>
					        <TR>
						        <TD width="15%" style="height: 19px"><FONT color="#29384e">&nbsp;参数说明</FONT><LABEL style="COLOR: #ff0033">*</LABEL></TD>
						        <TD width="85%" style="height: 19px">
                                    <asp:TextBox ID="txtExp" runat="server" Width="95%"></asp:TextBox></TD>
					        </TR>
					        <tr>
					            <TD align="left" colSpan="2" style="height: 20px">&nbsp;<asp:imagebutton id="Imagebutton1" runat="server" ToolTip="点击“确认”，提交修改信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/img20.gif" OnClick="Imagebutton1_Click"></asp:imagebutton>
						&nbsp;&nbsp; &nbsp;<IMG id="IMG2" style="CURSOR: hand" src="../../images/icon/img12.gif"
							align="absMiddle" border="0" name="btnSearch" onclick="ClearValue();"> &nbsp;<b><asp:label id="Label1" runat="server" ForeColor="Red"></asp:label></b>
					</TD>
					        </tr>
				            </TABLE>
                            <input id="hidCValue" runat="server" type="hidden" /></fieldset>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
			</TABLE>
			<DIV id="ListDiv" style="OVERFLOW:auto; WIDTH: 100%; HEIGHT: 430px">
                <asp:GridView ID="grdInfo" runat="server" AutoGenerateColumns="False" Width="100%" BorderWidth="1px" BorderColor="#EBE9EA" CellPadding="1" BackColor="White">
                    <AlternatingRowStyle ForeColor="Black" BackColor="#FAFAFA"></AlternatingRowStyle>
                    <RowStyle Wrap="True" ForeColor="Black" BackColor="White"></RowStyle>
                    <HeaderStyle Font-Bold="True" ForeColor="#0A2B4E" BackColor="#DCE8F4" CssClass="fixHeaderStyle"></HeaderStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="修改">
                            <ControlStyle Width="90px" />
                            <ItemTemplate>
                                &nbsp;<img src="../../Images/icon/imgChange1.gif" onclick="SetModifyItem();" style="CURSOR: hand"/>
                                <input id="hidValue" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CS_Name") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CS_Value" HeaderText="参数值" >
                            <ControlStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CS_Explain" HeaderText="参数说明" >
                            <ControlStyle Width="500px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
			</DIV>
		</form>
	</body>
</html>
