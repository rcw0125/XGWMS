<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AfficheList.aspx.cs" Inherits="SiteBll_SysMan_AfficheList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>公告列表</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<BODY leftMargin="0" topMargin="0">
		<form id="Form1" runat="server">
			<table cellSpacing="0" cellPadding="0" border="0" width="100%" height="100%">
				<tr>
					<td width="100%" height="2">
						<table cellSpacing="0" cellPadding="0" border="0" width="100%" height="2">
							<tr>
								<td background="../../Images/down/Freambg.gif"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="100%" valign="top">
						<table cellSpacing="0" cellPadding="0" border="0" width="100%" height="100%">
							<tr vAlign="top">
								<td width="2" background="../../../images/down/Freambg.gif"></td>
								<td bgColor="#ffffff">
									<!--实际内容-->
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colspan="2" height="5"></TD>
										</TR>
										<tr>
											<td width="90%" align="center" style="height: 22px"></td>
											<td width="10%" align="right" style="height: 22px">
												<asp:imagebutton id="ImageButton1" runat="server" ImageUrl="../../Images/icon/imgNew1.gif" OnClick="ImageButton1_Click"></asp:imagebutton>&nbsp;</td>
										</tr>
										<TR>
											<TD colspan="2" height="5"></TD>
										</TR>
										<tr>
										<tr>
											<td align="center" colspan="2" vAlign="top">
                                                <asp:GridView ID="grdAffList" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="grdAffList_RowCommand" OnRowDataBound="grdAffList_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="公告ID" />
                                                        <asp:BoundField DataField="UserName" HeaderText="发布人" />
                                                        <asp:BoundField DataField="PTime" HeaderText="发布日期" />
                                                        <asp:BoundField DataField="Title" HeaderText="标题" />
                                                        <asp:BoundField DataField="TypeNbr" HeaderText="类型" />
                                                        <asp:TemplateField HeaderText="修改">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnModify" runat="server" ImageUrl="../../Images/icon/imgChange1.gif" CommandName="imgBtnModify"/>&nbsp;
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="删除">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnDel" runat="server" ImageUrl="../../Images/icon/img19.gif" CommandName="imgBtnDel"/>
                                                                <input id="hidFileName" runat="server" type="hidden" value='<%# Eval("FileName") %>'/>
                                                                <input id="hidGuid" runat="server" type="hidden"  value='<%# Eval("Guid") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="查看">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgBtnCha" runat="server" ImageUrl="../../Images/icon/chankan.gif" CommandName="imgBtnCha" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#DCE8F4" />
                                                </asp:GridView>
                                                &nbsp;
                                                <br />
											</td>
										</tr>
									</TABLE>
									<!--实际内容-->
								</td>
								<td width="3" background="../../Images/down/Freambg.gif"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td width="100%" height="3">
						<table cellSpacing="0" cellPadding="0" border="0" width="100%" height="3">
							<tr>
								<td background="../../images/down/Freambg.gif"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</html>