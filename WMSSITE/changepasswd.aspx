<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changepasswd.aspx.cs" Inherits="changepasswd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改口令</title>
    <LINK href="CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body LEFTMARGIN="0" TOPMARGIN="0">
    <form id="form1"  method="post" runat="server">
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td height="17" width="3" background="../../../images/down/downtiaotop.gif"></td>
			<td height="17" background="../../../images/down/downtiaocenter.gif"><IMG height="1" width="100%" src="Images/down/downtiaocenter.gif"></td>
			<td height="17" width="3" background="../../../images/down/downtiaotop.gif"></td>
		</tr>
	</table>
	<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr vAlign="top">
						<td width="3" background="../../../images/down/downtiaobottom.gif"></td>
						<td bgColor="#ffffff">
							<!--实际内容-->
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<tr>
									<td class="formTitle">用户名:</td>
									<td class="formTitle">
										<asp:Label id="lblName" runat="server"></asp:Label></td>
								</tr>
                                <tr>
                                    <td>
                                        输入旧口令:</td>
                                    <td>
                                        <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" MaxLength="32" Width="100%"></asp:TextBox></td>
                                </tr>
								<tr>
									<td>输入口令:</td>
									<td>
										<asp:TextBox id="txtPassword" runat="server" TextMode="Password" MaxLength="32" Width="100%"></asp:TextBox></td>
								</tr>
								<tr>
									<td>确认口令:</td>
									<td>
										<asp:TextBox id="txtConfirm" runat="server" TextMode="Password" MaxLength="32" Width="100%"></asp:TextBox></td>
								</tr>
								<tr>
									<td colspan="2" align="center"><br>
										<asp:Button id="btnOK" runat="server" Text="修改口令" onclick="btnOK_Click"></asp:Button><br>
										<BR>
									</td>
								</tr>
								<tr>
									<td colspan="2"><asp:Label id="lblResult" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="必须输入口令" EnableViewState="False"
											Display="None" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
										<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="必须确认口令" EnableViewState="False"
											Display="None" ControlToValidate="txtConfirm"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOldPass"
                                            Display="None" EnableViewState="False" ErrorMessage="必须确认口令" Width="134px"></asp:RequiredFieldValidator>
										<asp:ValidationSummary id="ValidationSummary1" runat="server" EnableViewState="False" Height="16px"></asp:ValidationSummary>
										<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="输入口令和确认口令不一致" EnableViewState="False"
											Display="None" ControlToValidate="txtPassword" ControlToCompare="txtConfirm"></asp:CompareValidator>
									</td>
								</tr>
							</TABLE>
							<!--实际内容--></td>
						<td width="3" background="images/down/downtiaobottom.gif"></td>
					</tr>
				</table>
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td width="100%" height="3" background="Images/down/downtiaobottom.gif"></td>
					</tr>
				</table>
    </form>
</body>
</html>
