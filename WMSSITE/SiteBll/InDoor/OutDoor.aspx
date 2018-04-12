<%@ Page Language="C#" validateRequest="false" AutoEventWireup="true" CodeFile="OutDoor.aspx.cs" Inherits="SiteBll_InDoor_OutDoor" %>
<%--徐慧杰--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>出门管理</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="JAVASCRIPT" src="../../JavaScript/IndoorMan.js" type="text/javascript">
	</script>
	<script language="JAVASCRIPT" src="../../JavaScript/SysMan.js" type="text/javascript">
	</script>
</head>
<body leftMargin="0" topMargin="0" onload="InitVisiable();">
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
					<TD vAlign="middle" align="center" width="90%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="出门管理"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
					    <TABLE id="Table3" cellSpacing="1" cellPadding="1"  border="0" width="100%">
		                    <TR>
			                    <TD align="center" style="width: 66px; height: 25px;">IC卡ID</TD>
			                    <TD align="center" style="width: 150px; height: 25px;"><FONT face="宋体">
                                    <asp:TextBox ID="txtICID" runat="server" TextMode="Password" Width="130px"></asp:TextBox></FONT></TD>
			                    <TD align="center" style="width: 38px; height: 25px;">IC卡号</TD>
			                    <TD align="center" style="width: 131px; height: 25px;">
                                    <asp:TextBox ID="txtICNumber" runat="server" Width="130px"></asp:TextBox></TD>
			                    <TD style="width: 56px; height: 25px;" align="center"><FONT face="宋体">车牌号</FONT></TD>
			                    <TD style="width: 126px; height: 25px;" align="center">
                                    <asp:TextBox ID="txtCPH" runat="server" Width="130px"></asp:TextBox></TD>
			                    <TD style="width: 33px; height: 25px;" align="center"><FONT face="宋体">密码</FONT></TD>
			                    <TD align="center" style="width: 131px; height: 25px">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="100px" TextMode="Password"></asp:TextBox></TD>
		                    </TR>
		                    <TR>
		                        <TD style="width: 66px; height: 3px;" align="center">
                                    </TD>
		                        <TD colspan="2" align="center" style="height: 3px">
                                    <FONT face="宋体"><input id="hidCValue" style="width:52px" type="hidden" runat="server" />
                                        <input id="hidCPH" style="width:1px" runat="server" type="hidden"/>
                                    <input id="hidICID" runat="server" type="hidden" style="width: 1px"/>
                                        <input id="hidCK" style="width:1px" runat="server"  type="hidden"/>
                                        <input id="hidWLH" type="hidden" runat="server" style="width: 1px" />
                                    <input id="hidICNumber" runat="server" type="hidden" style="width: 1px"/>
                                        <input id="hidCheckCPH" style="width:1px" runat="server" type="hidden"/>
                                    <input id="hidVisable" runat="server" style="width:1px" type="hidden"/>
                                    <input id="hidPassword" style="width:1px" runat="server" type="hidden"/></FONT></TD>
		                        <TD style="width: 131px; height: 3px;" align="center">
                                    <input id="hidFYDH" style="width:1px" runat="server" type="hidden"/>
                                    <input id="hidCKDH" style="width:1px" type="Hidden" runat="server"/>
                                    <input id="hidKHLB" runat="server" type="hidden" style="width: 1px"/>
                                    <input id="hidSX" runat="server" type="hidden" style="width: 1px"/></TD>
		                        <TD style="width: 56px; height: 3px;" align="center"><FONT face="宋体">发运单号</FONT></TD>
		                        <TD style="width: 126px; height: 3px;" align="center">
                                    <asp:TextBox ID="txtFYDH" runat="server" Width="130px"></asp:TextBox></TD>
		                        <TD style="width: 33px; height: 3px;" align="center"><FONT face="宋体">
                                    </FONT></TD>
		                        <td style="width: 131px; height: 3px;" align="center"><FONT face="宋体"><asp:imagebutton id="btnSumbit" runat="server" ToolTip="点击“确认”，提交新建信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/img25.gif" OnClick="btnSumbit_Click"></asp:imagebutton></FONT></td>
	                        </TR>
	                    </TABLE>
			<TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细信息</font></TD>
					<TD vAlign="bottom" width="97%" bgColor="#dce8f4" height="20"></TD>
				</TR>
			</TABLE>
			<div style="overflow:auto;width:100%;height: 250px;white-space:nowrap;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <input id="chkFYDslc" runat="server" onclick="SetFYD3()" type="checkbox" />
                                <input id="hidFYDslc" type="hidden" />
                                <input id="slcWLH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.WLH") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FYDH" HeaderText="发运单号">
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="status" HeaderText="状态">
                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                            <HeaderStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CPH" HeaderText="车牌号">
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KHBM" HeaderText="客户名称">
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                            <HeaderStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CK" HeaderText="仓库">
                            <ItemStyle HorizontalAlign="Left" Width="30px" />
                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLMC" HeaderText="物料名称">
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性">
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJSL" HeaderText="实发数量">
                            <ItemStyle HorizontalAlign="Right" Width="60px" />
                            <HeaderStyle Width="60px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJZL" HeaderText="实发重量">
                            <ItemStyle HorizontalAlign="Right" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CZ_InTime" HeaderText="进厂时间">
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NCZDRY" HeaderText="制单人">
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KHBMH" ShowHeader="False" Visible="False" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
                </asp:GridView>
			</div>
            <table style="background-color: #dce8f4" width="100%">
                <tr>
                    <td align="right" style="width: 15%" valign="right">
                    发运单条数总计:</td>
                    <td align="left" style="width: 15%" valign="left">
                <asp:Label ID="lblFYDsum" runat="server"></asp:Label></td>
                    <td style="width: 70%">
                    </td>
                </tr>
            </table>
        <table width="100%" border="1" style="text-align: center; height: 1px; background-color: #dce8f4;">
          <tr>
            <td style="height: 2px; width: 33%;">
                <img ID="ImageButton1"  Height="20px" src="../../Images/icon/qzqr.gif"
                     Width="66px" onclick="javascript:zhqr();" />&nbsp;&nbsp;
                <asp:ImageButton ID="btn_camer" runat="server" Height="20px" ImageUrl="../../Images/icon/cappic.gif"
                     Width="66px" OnClick="btn_camer_Click" />&nbsp;&nbsp;
                <asp:ImageButton ID="btnAllowOutDoor" runat="server" ImageUrl="../../Images/icon/allowOutDoor.gif" OnClick="btnAllowOutDoor_Click"/></td>
            <td style="height: 2px; width: 34%;"><img id="btnCheckFYD" onclick="CheckFYD()" src="../../images/icon/chakanFYD.gif"
                    style="cursor: hand" /></td>
            <td style="width: 33%; height: 2px;"><img id="btnModifyPassword" onclick="ModifyPage()" src="../../images/icon/xiugaimima.gif"
                    style="cursor: hand" /></td>
          </tr>
        </table>
        <div id="popbox" style="DISPLAY: none; WIDTH: 220px; position:absolute; background-color: menu;">
								<table height="100%" cellSpacing="1" cellPadding="1" width="100%"
									border="1">
									<tr>
										<td align="left" style="height: 18px">
                                            请输入装车数量：</td>
									</tr>
									<tr>
										<td vAlign="top">
                                            <asp:TextBox ID="txtCXH" runat="server" Width="100%"></asp:TextBox></td>
									</tr>
									<tr>
										<td align="center">
                                            &nbsp;<asp:ImageButton ID="btnSCXH" runat="server" ImageUrl="../../Images/icon/queding.gif" OnClick="btnSCXH_Click" />
                                            <img id="imgCloseDiv" src="../../Images/icon/cancel.gif" style="cursor:hand" onclick="closeDiv('popbox');" />
										</td>
									</tr>
								</table>
							</div> 
</form>
</body>
</html>
