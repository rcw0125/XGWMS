<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageControlPost.ascx.cs" Inherits="UserControl_PageControlPost" %>
<TABLE id="PageControl" height="23" cellSpacing="0" cellPadding="0" width="100%" align="center"
							border="0">
		<tr>
			<TD style="PADDING-TOP: 1px" vAlign="middle" align="center" width="90"><asp:dropdownlist id="ddlListCount" runat="server" Width="80px" AutoPostBack="True" OnSelectedIndexChanged="ddlListCount_SelectedIndexChanged">
										<asp:ListItem Value="10">每页10条</asp:ListItem>
										<asp:ListItem Value="20">每页20条</asp:ListItem>
										<asp:ListItem Value="30">每页30条</asp:ListItem>
										<asp:ListItem Value="40">每页40条</asp:ListItem>
										<asp:ListItem Value="50">每页50条</asp:ListItem>
										<asp:ListItem Value="100">每页100条</asp:ListItem>
									</asp:dropdownlist></TD>
			<td vAlign="middle" align="left" width="145"><asp:imagebutton id="imgBtnFirst" runat="server" BorderWidth="0px" ImageAlign="Middle" ImageUrl="../images/icon/firstPage.gif"
										CommandName="FirstPage" OnClick="imgBtnFirst_Click"></asp:imagebutton>&nbsp;<asp:imagebutton id="imgBtnPrePage" runat="server" BorderWidth="0px" ImageAlign="Middle" ImageUrl="../images/icon/prePage.gif"
										CommandName="PrePage" OnClick="imgBtnPrePage_Click"></asp:imagebutton></td>
								<td vAlign="middle" align="left" width="145"><asp:imagebutton id="imgBtnNextPage" runat="server" BorderWidth="0px" ImageAlign="Middle" ImageUrl="../images/icon/nextPage.gif"
										CommandName="NextPage" OnClick="imgBtnNextPage_Click"></asp:imagebutton>&nbsp;<asp:imagebutton id="imgBtnLastPage" runat="server" BorderWidth="0px" ImageAlign="Middle" ImageUrl="../images/icon/lastPage.gif"
										CommandName="LastPage" OnClick="imgBtnLastPage_Click"></asp:imagebutton></td>
								<td style="WIDTH: 28px; PADDING-TOP: 2px" vAlign="middle" align="left" width="28"><asp:dropdownlist id="ddlPageCount" runat="server" Width="50px" Height="15px"></asp:dropdownlist></td>
								<td style="PADDING-TOP: 3px" vAlign="middle" align="left" width="15">页</td>
								<td vAlign="middle" align="left" width="70"><asp:imagebutton id="imgBtnGo" runat="server" BorderWidth="0px" ImageAlign="Middle" ImageUrl="../images/icon/go.gif" OnClick="imgBtnGo_Click"></asp:imagebutton></td>
								<td style="MARGIN-TOP: 0px; PADDING-TOP: 3px" align="left">&nbsp;第<asp:literal id="m_page" runat="server"></asp:literal>页/共<asp:literal id="m_topage" runat="server"></asp:literal>页（<asp:literal id="m_count" runat="server"></asp:literal>条记录）
								</td>
							</tr>
</TABLE>