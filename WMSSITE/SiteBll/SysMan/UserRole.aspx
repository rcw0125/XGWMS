<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRole.aspx.cs" Inherits="SiteBll_SysMan_UserRole" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户权限</title>
    <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
     <script language="JAVASCRIPT" src="../../JavaScript/SysMan.js" type="text/javascript">
	</script>
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
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
					<TD vAlign="middle" align="center" width="90%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="用户权限"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="5"></td>
  </tr>
</table>

			<TABLE class="fixColStyle" id="tblEdit" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD style="HEIGHT: 19px" vAlign="bottom" align="left" width="12%" bgColor="#dce8f4"
						height="19"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;新建用户</font></TD>
					<TD style="HEIGHT: 19px" vAlign="bottom" width="88%" bgColor="#dce8f4" height="19"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">注：页面中带*项为必添项</label></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="2">
					    <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <TD width="10%" style="height: 29px">&nbsp;员工编码<FONT face="宋体" color="#ff9966">*</FONT></TD>
			                    <TD width="15%" align="left" style="height: 29px"><FONT face="宋体">
                                    <asp:TextBox ID="UserID" runat="server" Width="90%"></asp:TextBox></FONT></TD>
			                    <TD style="width: 81px; height: 29px;">&nbsp;员工姓名<FONT face="宋体" color="#ff9966">*</FONT></TD>
			                    <TD width="12.5%" align="left" style="height: 29px">
                                    <asp:TextBox ID="UserName" runat="server" Width="90%"></asp:TextBox></TD>
			                    <TD style="width: 104px; height: 29px;"><FONT face="宋体">
                                    所属仓库&nbsp;</FONT></TD>
			                    <TD style="width: 235px; height: 29px;">
                                    <asp:DropDownList ID="ckdropdown" runat="server" Width="95%">
                                    </asp:DropDownList></TD>
			                    <TD width="12.5%" style="height: 29px"><FONT face="宋体">
                                    </FONT></TD>
		                    </TR>
		                    <TR>
		                        <TD><FONT face="宋体">&nbsp;生产线</TD>
		                        <TD><FONT face="宋体">
                                    <asp:DropDownList ID="ScxDropdown" runat="server" DataTextField="SCXBM" DataValueField="SCXNCID"
                                        Width="95%">
                                    </asp:DropDownList></FONT></TD>
		                        <td style="width: 81px">
                                    所任职务<span style="color: #ff9966"></span></td>
		                        <TD>
                                    <asp:TextBox ID="UserDuty" runat="server" Width="90%"></asp:TextBox></TD>
		                        <TD style="width: 104px"><FONT face="宋体">
                                    操作角色</FONT></TD>
		                        <TD style="width: 235px">
                                    <asp:DropDownList ID="drpRole" runat="server" DataTextField="RoleName" DataValueField="RoleName" Width="95%">
                                    </asp:DropDownList></TD>
		                        <TD><FONT face="宋体">
                                    </FONT></TD>
	                        </TR>
	                           <TR>
		                        <TD><FONT face="宋体">&nbsp;员工口令<FONT face="宋体" color="#ff9966">*</FONT></TD>
		                        <TD><FONT face="宋体">
                                    <asp:TextBox ID="UserPass" runat="server" TextMode="Password" Width="90%"></asp:TextBox>
                                    <input id="hidPass" runat="server" type="hidden" /></FONT></TD>
		                        <td style="width: 81px">
                                    重复口令<span style="color: #ff9966">*</span></td>
		                        <TD>
                                    <asp:TextBox ID="EditUserPass" runat="server" Width="90%" TextMode="Password"></asp:TextBox></TD>
		                        <TD style="width: 104px"><FONT face="宋体">所属门岗</FONT></TD>
		                        <TD style="width: 235px"><FONT face="宋体"><asp:DropDownList ID="drpdoor" runat="server" DataTextField="doorname" DataValueField="doorno"
                                        Width="95%">
                                    </asp:DropDownList></FONT>
                                    </TD>
		                        <TD></TD>
	                        </TR>
	                        </TR>
	                           <TR>
		                        <TD></TD>
		                        <TD></TD>
		                        <td style="width: 81px">
                                    </td>
		                        <TD>
                                    </TD>
		                        <TD style="width: 104px"><FONT face="宋体">所属签证室</FONT></TD>
		                        <TD style="width: 235px"><FONT face="宋体"><asp:DropDownList ID="drpqzs" runat="server" DataTextField="qzs_name" DataValueField="qzs_no"
                                        Width="95%">
                                    </asp:DropDownList></FONT>
                                    </TD>
		                        <TD><FONT face="宋体"></FONT></TD>
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

<TABLE   cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server" id="Table2">
				<TR>
					<TD vAlign="bottom" align="right" style=" height: 25px; width: 9px;"></TD>
                       <TD vAlign="bottom" align="left" style=" height: 25px;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;选择仓库：<asp:DropDownList
                            ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Width="25%">
                       </asp:DropDownList></font></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="middle" align="left" bgColor="#dce8f4" style="width: 21%; height: 21px;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;用户权限浏览</font></TD>
					<TD vAlign="middle" width="97%" bgColor="#dce8f4" style="height: 21px" align="right">
                        </TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"> &nbsp; 
			<DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:98%;height:400px;overflow:auto;white-space:nowrap;">
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="#EBE9EA" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                  
                    <Columns>
                        <asp:BoundField DataField="UserID" HeaderText="员工编码" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UserName" HeaderText="员工姓名" />
                        <asp:BoundField HeaderText="生产线" DataField="RFSCX" />
                        <asp:BoundField DataField="UserDuty" HeaderText="员工职务" />
                        <asp:BoundField HeaderText="员工角色" DataField="UserRole" />
                        <asp:BoundField DataField="CK" HeaderText="所属仓库" Visible="False" />
                        <asp:BoundField DataField="UserPass" HeaderText="员工口令" Visible="False" />
                        <asp:BoundField DataField="doorname" HeaderText="门岗" />
                        <asp:BoundField DataField="qzs_name" HeaderText="签证室" />
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
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle"/>
                    <SelectedRowStyle BackColor="#DCE8F4" />
                </asp:GridView>
			</DIV></TD>
				</TR>
			</TABLE>
    </form>
</body>
</html>
