<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControl_Header" %>
<table id="tablex" cellspacing="0" cellpadding="0" width="100%" border="0">
	<tr>
		<td valign="top" width="500" background="images/header/topleft.gif" height="65"></td>
		<td valign="middle" align="right" background="images/header/topcenter.gif" height="65"><asp:label id="LabelX" Width="1" runat="server"></asp:label></td>
		<td align="right" width="230" background="images/header/topright.gif" height="65">
			<table cellSpacing="0" cellPadding="0" width="380" border="0">
				<tr>
					<td vAlign="middle" align="right" height="32"><font size="12" color="#213B52"><span style="font-size: 9pt; font-family: 宋体">
                        <asp:Label ID="lblName" runat="server" ForeColor="White" Text="当前活动用户："></asp:Label></span></font></td>
				</tr>
				<tr>
					<td vAlign="bottom" align="left" height="33">
						<table height="33" cellSpacing="0" cellPadding="0" width="380" border="0">
							<tr>
								<td vAlign="middle" align="right" height="33">
									<asp:Label id="Label2" runat="server" Width="175px"></asp:Label></td>
								<td vAlign="bottom" align="right" width="160" height="33"><IMG height="24" src="images/header/topbtnleft.gif" width="19" align="absBottom" border="0"><IMG style="CURSOR: hand" onclick="showdialog();" height="24" src="images/header/changepassword.gif"
										width="55" align="absBottom" border="0"><IMG height="24" src="images/header/topbtncenter.gif" width="7" align="absBottom" border="0"><asp:imagebutton id="Imagebutton1" Width="55px" runat="server" Height="24px" ImageUrl="../images/header/exit.gif"
										ImageAlign="AbsBottom" OnClick="Imagebutton1_Click"></asp:imagebutton><IMG height="24" src="images/header/topbtncenter.gif" width="7" align="absBottom" border="0">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="38" background="images/header/tiaoleft.gif" height="38"></td>
					<td vAlign="middle" align="center" background="images/header/tiaocenter.gif" height="38"><asp:literal id="litHeader" runat="server"></asp:literal></td>
					<td width="38" background="images/header/tiaoright.gif" height="38">
					</td>
					<td width="24" background="images/header/tiaoright1.gif" height="38" align="center">
						<table cellSpacing="0" cellPadding="0" width="100%" height="100%" border="0">
							<tr>
								<td width="100%" height="42%" align="center" valign="bottom"><IMG style="CURSOR: hand" height="8" src="images/header/up.gif" width="13" border="0"
										onclick="up();" title="隐藏"></td>
							</tr>
							<tr>
								<td width="100%" height="10%"></td>
							</tr>
							<tr>
								<td width="100%" height="48%" align="center" valign="top"><IMG style="CURSOR: hand" height="8" src="images/header/down.gif" width="13" border="0"
										onclick="down();" title="展开"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>