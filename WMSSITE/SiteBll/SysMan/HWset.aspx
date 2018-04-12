<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HWset.aspx.cs" Inherits="SiteBll_SysMan_HWset" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>货位设置</title>
      <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
     <script language="JAVASCRIPT" src="../../JavaScript/SysMan.js" type="text/javascript">
	</script>
	<script type="text/javascript" language="javascript" src="../../JavaScript/HWprint.js">
	

	</script>
</head >
<body leftmargin=0 topmargin=0 onload="Init();">
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="货位设置"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%"><span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">数据编辑</span></span><IMG id="imgData" style="CURSOR: hand" onclick="AddQuery();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">  打印配置</label><IMG id="imgPrint" style="CURSOR: hand" onclick="Addconfig();" alt="关闭" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="5"></td>
  </tr>
</table>

			<TABLE class="fixColStyle" id="dataedit" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server" style="DISPLAY:block ">
				<TR>
					<TD style="HEIGHT: 19px" vAlign="bottom" align="left" width="12%" bgColor="#dce8f4"
						height="19"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;数据编辑</font></TD>
					<TD style="HEIGHT: 19px" vAlign="bottom" width="88%" bgColor="#dce8f4" height="19"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">注：页面中带*项为必添项</label></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="2">
					    <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <TD style="height: 29px; width: 78px;"><FONT face="宋体" color="#ff9966"><span style="color: #000000">
                                    所属仓库<FONT face="宋体" color="#ff9966">*</FONT>&nbsp;</span></FONT></TD>
			                    <TD width="15%" align="left" style="height: 29px"><FONT face="宋体">
                                    <asp:DropDownList ID="ckdropdown" runat="server" Width="95%">
                                    </asp:DropDownList></FONT></TD>
			                    <TD align="center" style="height: 29px; width: 7%;">
                                    备注</TD>
			                    <TD style="height: 29px;" colspan="3" align=left><FONT face="宋体">
                                    <asp:TextBox ID="HWmemo" runat="server"></asp:TextBox></FONT></TD>
		                    </TR>
		                    <TR>
		                        <TD style="width: 78px" valign=top align=left><FONT face="宋体">&nbsp;录入方式</TD>
		                        <TD valign=top><FONT face="宋体">
                                    <asp:DropDownList ID="Rrfsdrop" runat="server"
                                        Width="95%" OnSelectedIndexChanged="Rrfsdrop_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList></FONT></TD>
		                        <TD colspan="4" align=left>
		                        <div id="dgfangshi" runat=server>
                                    货位行号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWrow1" runat="server"></asp:TextBox>货位列号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWcolumn1" runat="server"></asp:TextBox></div><div id="cpfangshi" runat=server>
                                        最小行号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWminrow" runat="server"></asp:TextBox>最大行号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWmaxrow"
                                            runat="server"></asp:TextBox><br />
                                        最小列号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWmincolumn" runat="server"></asp:TextBox>最大列号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWmaxcolumn"
                                            runat="server"></asp:TextBox></div>
                                    </TD>
	                        </TR>
                      </TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="left" colSpan="2" style="height: 20px">&nbsp;<asp:imagebutton id="imgBtnSumbit" runat="server" ToolTip="点击“新建”，提交新建信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/imgNew1.gif" OnClick="imgBtnSumbit_Click" ></asp:imagebutton>
						&nbsp;&nbsp; &nbsp;
                        <asp:ImageButton ID="imgBtnReset" runat="server" ToolTip="点击“重置”，把编制信息还原成初始状态。" ImageUrl="../../images/icon/img12.gif" OnClick="imgBtnReset_Click"/>
                        &nbsp;<b><asp:label id="m_labError" runat="server" ForeColor="Red"></asp:label></b>&nbsp;&nbsp;
                        </TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="Print1" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server" style="DISPLAY: none" > 
				<TR>
					<TD style="HEIGHT: 19px" vAlign="bottom" align="left" width="12%" bgColor="#dce8f4"
						height="19"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;打印配置</font></TD>
					<TD style="HEIGHT: 19px; width: 88%;" vAlign="bottom" bgColor="#dce8f4" height="19"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">注：页面中带*项为必添项</label></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="2">
			<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="99%" border="2">
		                    <TR>
			                    <TD style="height: 29px;" align="left">
			                    <FONT face="宋体" color="#ff9966"><span style="color: #000000">&nbsp;选择仓库&nbsp;<span style="height: 29px; "><font face="宋体"> </font></span></span></FONT><asp:DropDownList ID="chkPrintDrp" runat="server" Width="116px"> </asp:DropDownList>
			                   </TD>
		                    </TR>
		                    <TR>
		                        <TD valign=top align=left>&nbsp;打印方式&nbsp;<span style="height: 29px; "><font face="宋体"> </font></span>
		                          <asp:DropDownList ID="Drpprint" runat="server" Width="116px"  AutoPostBack="True" OnSelectedIndexChanged="Drpprint_SelectedIndexChanged">
                                    <asp:ListItem></asp:ListItem>
                                  </asp:DropDownList>
		                       </TD>
	                        </TR>
		                    <TR>
		                      <TD valign=top align=left><div id="Printdiv1" runat=server>
                                  &nbsp;<span style="height: 29px; "><font face="宋体"> 输入行号<asp:TextBox ID="txtROW1" runat="server"></asp:TextBox></font></span>&nbsp;<span style="height: 29px; "><font face="宋体"> 输入列号<asp:TextBox ID="txtCOLUMN1" runat="server"></asp:TextBox></font></span></div>
                                    <div id="Printdiv2" runat=server>
                                        &nbsp;<span style="height: 29px; "><font face="宋体"> 起始行号
                                        <asp:TextBox ID="txtminROW" runat="server"></asp:TextBox></font></span>&nbsp;<span style="height: 29px; "><font face="宋体"> 终止行号<asp:TextBox ID="txtmaxROW" runat="server"></asp:TextBox></font></span><br />&nbsp;<span style="height: 29px; "><font face="宋体"> 起始列号
                                        <asp:TextBox ID="txtminColumn" runat="server"></asp:TextBox></font></span>&nbsp;<span style="height: 29px; "><font face="宋体"> 终止列号<asp:TextBox ID="txtmaxColumn" runat="server"></asp:TextBox></font></span> </div></TD></TR>
                      </TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="left" colSpan="2" style="height: 20px">&nbsp; &nbsp;<img src="../../Images/icon/print.gif" onclick="checkprint();" style="cursor:hand"/>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imgcancel" runat="server" ImageUrl="~/Images/icon/img22.gif" />
                        &nbsp;<b><asp:label id="Label1" runat="server" ForeColor="Red"></asp:label></b>&nbsp;&nbsp;
                        </TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
			</TABLE>

<TABLE   cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server" id="Table2">
				<TR>
					<TD vAlign="bottom" align="right" style=" height: 25px; width: 9px;"></TD>
                       <TD vAlign="bottom" align="left" style=" height: 25px;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;选择仓库：<asp:DropDownList
                            ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" runat="server" Width="25%">
                       </asp:DropDownList></font></TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="middle" align="left" bgColor="#dce8f4" style="width: 21%; height: 21px;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;货位浏览</font></TD>
					<TD vAlign="middle" width="97%" bgColor="#dce8f4" style="height: 21px" align="right">
                        </TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3"></TD>
				</TR>
			</TABLE>
			<DIV id="ListDiv" style="OVERFLOW-Y: visible; OVERFLOW-X: visible; WIDTH: 620px; HEIGHT: 80%" >
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="620px" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                  <AlternatingRowStyle ForeColor="Black" BackColor="#FAFAFA" Height="17px"></AlternatingRowStyle>
                    <RowStyle Wrap="True" ForeColor="Black" BackColor="White" Height="17px"></RowStyle>

                    <Columns>
                        <asp:BoundField DataField="HWID" HeaderText="货位编码" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CK" HeaderText="仓库" Visible="False" />
                        <asp:BoundField DataField="HWRow" HeaderText="货位行号" />
                        <asp:BoundField HeaderText="货位列号" DataField="HWColumn" />
                        <asp:BoundField DataField="HWBZ" HeaderText="备注信息" />
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
                <table width="620px" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td style="height: 20px; width: 209px;" align=center>
        总计</td>
  
    <td style="height: 20px;"><%=hwcount %>个货位</td>
  </tr>
</table>
    <input id="hidData" type="hidden" runat="server"/><input id="hidPrint" type="hidden" runat="server"/>
    </DIV>
    </form>
</body>
</html>
