<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AfficheMan.aspx.cs" Inherits="SiteBll_SysMan_AfficheMan" ValidateRequest="false" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发布公告</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/DataOper.js" type="text/javascript"></script>
</head>
<BODY leftMargin="0" topMargin="0">
		<form id="Form1" runat="server">
		 <TABLE class="fixColStyle" id="Table2" height="28" cellSpacing="0" cellPadding="0" width="100%"
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
					<TD vAlign="middle" align="center" width="92%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="编制公告信息"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	    </TABLE>
	    <table cellSpacing="0" cellPadding="0" border="0" width="100%" height="100%">
							<tr vAlign="top">
								<td width="2" background="../../Images/down/Freambg.gif"></td>
								<td bgColor="#ffffff">
									<!--实际内容-->
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="10%" style="HEIGHT: 6px">&nbsp;标题<LABEL style="COLOR: #ff0033">*</LABEL></TD>
											<TD width="70%" style="HEIGHT: 6px">
												<asp:TextBox id="m_txtTitle" runat="server" Width="100%"></asp:TextBox></TD>
											<TD width="20%" align="right" style="HEIGHT: 6px">
                                                &nbsp;</TD>
										</TR>
										<tr>
											<td colspan="3" align="center">
                                                <FTB:FreeTextBox id="FreeTextBox1" runat="server" ButtonPath="../../Images/ftb/office2003/" HelperFilesPath="HelperAffiche"
													AllowHtmlMode="False" AutoConfigure="Default" PasteMode="Default" HtmlModeDefaultsToMonoSpaceFont="False"
													Width="100%" Height="390px"></FTB:FreeTextBox>
											</td>
										</tr>
										<TR>
											<TD align="center" colSpan="3">
                                                &nbsp;</TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3" style="height: 20px">
												<asp:imagebutton id="btnSumbit" runat="server" ToolTip="点击“确认”，提交编制信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
													ImageUrl="../../Images/icon/img20.gif" OnClick="btnSumbit_Click" ></asp:imagebutton>&nbsp;
												<asp:imagebutton id="Imagebutton1" runat="server" ToolTip="点击“确认”，提交编制信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
													ImageUrl="../../Images/icon/img22.gif" CausesValidation="False" OnClick="Imagebutton1_Click"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<!--实际内容-->
								</td>
								<td width="3" background="../../Images/down/Freambg.gif"></td>
							</tr>
						</table>
		</form>
	</BODY>
</html>
