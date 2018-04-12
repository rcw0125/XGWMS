<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QWGD.aspx.cs" Inherits="SiteBll_FormMan_QWGD" EnableEventValidation="false" %>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>

<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"
    TagPrefix="uc3" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>完工单查询</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FormMan.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" onload="Init();">
		<form id="Form1" method="post" runat="server">
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="完工单查询"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="AddQuery();" alt="关闭" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">列表配置</label><IMG id="btnconfig" style="CURSOR: hand" onclick="Addconfig();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">明细信息</label><IMG id="btnItem" style="CURSOR: hand" onclick="AddItems();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<!--<TABLE id="TABLE2" class="fixColStyle" style="DISPLAY: none" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		            <TR>
			            <TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
			            <TD width="88%" bgColor="#dce8f4" height="20"></TD>
		            </TR>
	        </TABLE>-->
			<TABLE id="tblQuery" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <TD width="11.5%" style="height: 23px">&nbsp;<input id="chkPCH" type="checkbox" onclick="GetPCH();" runat="server" />批次号</TD>
			                    <TD width="19%" align="left" style="height: 23px"><FONT face="宋体">
                                    <bestcomy:ComboBox ID="drpPCH" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
                                    
                                    <input id="hidPCH" type="hidden" runat="server" /></FONT></TD>
			                    <TD width="15%" style="height: 23px">
                                    &nbsp;<input id="chkTSXX" type="checkbox" onclick="GetTSXX();" runat="server"/>特殊信息</TD>
			                    <TD width="13%" align="left" style="height: 23px">
                                    <bestcomy:ComboBox ID="drpTSXX" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
                                    <input id="hidTSXX" runat="server" type="hidden" /></TD>
			                    <TD width="9%" style="height: 23px"><FONT face="宋体">&nbsp;<input id="chkPLX" type="checkbox" onclick="GetPLX();" runat="server"/>批类型</FONT></TD>
			                    <TD width="11%" style="height: 23px">
                                    <asp:DropDownList ID="drpPLX" runat="server" Width="95%" Enabled="False">
                                    </asp:DropDownList>
                                    <input id="hidPLX" runat="server" type="hidden" /></TD>
			                    <TD width="10%" style="height: 23px"><FONT face="宋体">&nbsp;<input id="chkPCSX" type="checkbox" onclick="GetPCSX();" runat="server" />批属性</FONT></TD>
			                    <TD width="12.5%" style="height: 23px">
                                    <asp:DropDownList ID="drpPCSX" runat="server" Width="95%" Enabled="False">
                                    </asp:DropDownList>
                                    <input id="hidPCSX" runat="server" type="hidden" /></TD>
		                    </TR>
		                    <TR>
		                        <TD style="height: 23px">&nbsp;<input id="chkWLH" type="checkbox" onclick="GetWLH();" runat="server"  />物料号</TD>
		                        <TD align="left" style="height: 23px">
                                    <FONT face="宋体">
                                        <bestcomy:ComboBox ID="drpWLH" runat="server" Width="100%">
                                        </bestcomy:ComboBox>
                                        <input id="hidWLH" runat="server" type="hidden" /></FONT></TD>
                                <td style="height: 23px">
                                    &nbsp;<input id="chkPH" type="checkbox" onclick="GetPH();" runat="server" />牌号</td>
		                        <TD style="height: 23px">
                                    <bestcomy:ComboBox ID="drpPH" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
                                    <input id="hidPH" runat="server" type="hidden" /></TD>
		                        <TD style="width: 147px; height: 23px;"><FONT face="宋体">&nbsp;<input id="chkWCBZ" type="checkbox" onclick="GetWCBZ();" runat="server"  />状态</FONT></TD>
		                        <TD style="height: 23px">
                                    <asp:DropDownList ID="drpWCBZ" runat="server" Width="95%" Enabled="False">
                                    </asp:DropDownList>
                                    <input id="hidWCBZ" runat="server" type="hidden" /></TD>
		                        <TD style="height: 23px"><FONT face="宋体">&nbsp;<input id="chkSCX" type="checkbox" onclick="GetSCX();" runat="server"/>生产线</FONT></TD>
		                        <td style="height: 23px"><FONT face="宋体">
                                    <asp:DropDownList ID="drpSCX" runat="server" Width="95%" Enabled="False">
                                    </asp:DropDownList>
                                    <input id="hidSCX" runat="server" type="hidden" />&nbsp; </FONT></td>
	                        </TR>
                            <tr>
                                <td>
                                    &nbsp;<input id="chkGG" type="checkbox" onclick="GetGG();" runat="server"/>规格</td>
                                <td align="left">
                                    <bestcomy:ComboBox ID="drpGG" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
                                    <input id="hidGG" runat="server" type="hidden" /></td>
                                <td>
                                    &nbsp;<input id="chkWGDH" type="checkbox" onclick="GetWGDH();" runat="server" />完工单号</td>
                                <td>
                                    <bestcomy:ComboBox ID="drpWGDH" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
                                    <input id="hidWGDH" runat="server" type="hidden" /></td>
                                <td style="width: 147px">
                                    &nbsp;<input id="chkDPP" type="checkbox" onclick="GetDPP();" runat="server"/>待判品</td>
                                <td>
                                    <asp:DropDownList ID="drpDPP" runat="server" Width="95%" Enabled="False">
                                    </asp:DropDownList>
                                    <input id="hidDPP" runat="server" type="hidden" /></td>
                                <td>
                                    &nbsp;<input id="chkZJR" type="checkbox" onclick="GetZJR();" runat="server"/>质检人</td>
                                <td>
                                    <asp:DropDownList ID="drpZJR" runat="server" Width="95%" Enabled="False">
                                    </asp:DropDownList>
                                    <input id="hidZJR" runat="server" type="hidden" /></td>
                            </tr>
                            <tr>
                                <td style="height: 18px">
                                    &nbsp;<input id="chkPTime" type="checkbox" runat="server" />生产时间</td>
                                <td align="left" style="height: 18px">
                                    <asp:TextBox ID="txtPStartTime" runat="server" Width="75%" Enabled="False"></asp:TextBox>
                                    <img src="../../Images/icon/calendar.gif" onclick="calendar(txtPStartTime);" style="cursor: hand;" id="imgPSTime"/>至</td>
                                <td><asp:TextBox ID="txtPEndTime" runat="server" Width="80%" Enabled="False"></asp:TextBox>
                                    <img src="../../Images/icon/calendar.gif" onclick="calendar(txtPEndTime);" style="cursor: hand" id="imgPEndTime" /></td>
                                <td style="height: 18px">
                                    <asp:CheckBox ID="chkPaoGou" runat="server" Text="有跑钩标志" /></td>
                                <td style="height: 18px">
                                    &nbsp;<input id="chkFree1" type="checkbox" onclick="GetFree1();" runat="server"/>自由项1</td>
                                <td style="height: 18px">
                                    <asp:TextBox ID="txtFree1" runat="server" Enabled="False" Width="95%"></asp:TextBox></td>
                                <td style="height: 18px">
                                    &nbsp;<input id="chkFree2" type="checkbox" onclick="GetFree2();" runat="server"/>自由项2</td>
                                <td style="height: 18px">
                                    <asp:TextBox ID="txtFree2" runat="server" Enabled="False" Width="95%"></asp:TextBox></td>
                            </tr>
                <tr>
                    <td style="height: 18px">
                                    &nbsp;<input id="chkRTime" type="checkbox" runat="server" />入库时间</td>
                    <td align="left" style="height: 18px">
                                    <asp:TextBox ID="txtRStartTime" runat="server" Enabled="False" Width="75%"></asp:TextBox>
                                    <img src="../../Images/icon/calendar.gif" onclick="calendar(txtRStartTime);" style="cursor: hand" />至</td>
                    <td>
                        <asp:TextBox ID="txtREndTime" runat="server" Enabled="False" Width="80%"></asp:TextBox>
                                    <img src="../../Images/icon/calendar.gif" onclick="calendar(txtREndTime);" style="cursor: hand" /></td>
                    <td style="height: 18px">
                    </td>
                    <td style="height: 18px">
                        &nbsp;<input id="chkFree3" type="checkbox" onclick="GetFree3();" runat="server"/>自由项3</td>
                    <td style="height: 18px">
                        <asp:TextBox ID="txtFree3" runat="server" Enabled="False" Width="95%"></asp:TextBox></td>
                    <td style="height: 18px">
                    </td>
                    <td style="height: 18px">
                    </td>
                </tr>
                            <tr>
                                <td style="height: 18px">
                                </td>
                                <td align="left" colspan="2" style="height: 18px">
                                    <asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
                                    <asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" />&nbsp;&nbsp;&nbsp;</td>
                                <td style="height: 18px">
                                    </td>
                                <td colspan="3" style="height: 18px">
                                    </td>
                                <td style="height: 18px">
                                </td>
                            </tr>
	         </TABLE>
			        <uc3:SetDisplayList id="SetDisplayList1" runat="server">
                    </uc3:SetDisplayList>
			<TABLE  id="tblList" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;浏览信息</font></TD>
					<TD vAlign="bottom" width="88%" bgColor="#dce8f4" height="20"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
			</TABLE>
			<uc2:PageControl id="PageControl1" runat="server">
            </uc2:PageControl>
			<DIV style="OVERFLOW:auto;WIDTH: 100%; HEIGHT: 260px">
                <asp:GridView ID="grvWGD" runat="server" AutoGenerateColumns="False" Width="2000px" AllowSorting="True" OnSorting="grvWGD_Sorting" OnRowCreated="grvWGD_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="查看明细">
                            <ItemTemplate>
                                &nbsp;<input id="Checkbox1" type="checkbox" onclick="GetWGDItem();" runat="server"/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="WGDH" HeaderText="完工单号" SortExpression="WGDH" />
                        <asp:BoundField DataField="scxbm" HeaderText="生产线" SortExpression="scxbm" />
                        <asp:BoundField DataField="PCH" HeaderText="批次" SortExpression="PCH" />
                        <asp:BoundField DataField="PCSX" HeaderText="批次属性" SortExpression="PCSX" />
                        <asp:BoundField DataField="pcinfo" HeaderText="特殊信息" SortExpression="pcinfo" />
                        <asp:BoundField DataField="Desc_PCLX" HeaderText="批次类型" SortExpression="pclx" />
                        <asp:BoundField DataField="PH" HeaderText="牌号" SortExpression="PH" />
                        <asp:BoundField DataField="GG" HeaderText="规格" SortExpression="GG" />
                        <asp:BoundField DataField="WLH" HeaderText="物料号" SortExpression="WLH" />
                        <asp:BoundField DataField="WLMC" HeaderText="物料名称" SortExpression="WLMC" />
                        <asp:BoundField DataField="ZXBZ" HeaderText="执行标准" SortExpression="ZXBZ" />
                        <asp:BoundField DataField="FZDW" HeaderText="辅助单位" SortExpression="FZDW" />
                        <asp:BoundField DataField="PCXH" HeaderText="序号" SortExpression="PCXH" />
                        <asp:BoundField DataField="ZJBZ" HeaderText="质检标志" SortExpression="ZJBZ" />
                        <asp:BoundField DataField="PGBZ" HeaderText="跑钩数目" SortExpression="PGBZ" />
                        <asp:BoundField DataField="Rev_Time" HeaderText="接收时间" SortExpression="Rev_Time" />
                        <asp:BoundField DataField="PEnd_Time" HeaderText="生产完成时间" SortExpression="PEnd_Time" />
                        <asp:BoundField DataField="End_Time" HeaderText="入库完成时间" SortExpression="End_Time" />
                        <asp:BoundField DataField="Desc_wcbz" HeaderText="单据状态" SortExpression="wcbz" />
                        <asp:BoundField DataField="BB" HeaderText="班别" SortExpression="BB" />
                        <asp:BoundField DataField="vfree0" HeaderText="炉号" SortExpression="vfree0" />
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" SortExpression="vfree1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" SortExpression="vfree2" />
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" SortExpression="vfree3" />
                    </Columns>
                    <HeaderStyle CssClass="fixHeaderTest" BackColor="#DCE8F4" />
                </asp:GridView>
			</DIV>
			<table class="fixColStyle" rules="rows" width="100%" align="center" border="1">
				<tr>
					<td width="15%" bgColor="#ebe9ea" style="PADDING-TOP: 5px; height: 22px;">
                        总计：</td>
					<td width="15%" bgColor="#ebe9ea" style="height: 22px">
						<asp:TextBox id="labCount" runat="server" Width="100%" BackColor="#EBE9EA" BorderStyle="None"
							ReadOnly="True" EnableViewState="False">0</asp:TextBox>
					</td>
					<td width="10%" bgColor="#ebe9ea" style="PADDING-TOP: 5px; height: 22px;">
                        跑钩数：</td>
					<td width="25%" bgColor="#ebe9ea" style="height: 22px">
						<asp:TextBox id="lblPaoGou" runat="server" Width="100%" BackColor="#EBE9EA" BorderStyle="None"
							ReadOnly="True" EnableViewState="False">0</asp:TextBox>
					</td>
					<td width="10%" bgColor="#ebe9ea" style="PADDING-TOP: 5px; height: 22px;"></td>
					<td width="25%" bgColor="#ebe9ea" style="height: 22px">
                        &nbsp;</td>
				</tr>
                <tr>
                    <td bgcolor="#ebe9ea" style="padding-top: 5px; height: 22px" width="15%">
                        <input id="hidQuery" runat="server" type="hidden" /></td>
                    <td bgcolor="#ebe9ea" style="height: 22px" width="15%">
                        </td>
                    <td bgcolor="#ebe9ea" style="padding-top: 5px; height: 22px" width="10%">
                        <input id="hidItem" type="hidden" runat="server" /></td>
                    <td bgcolor="#ebe9ea" style="height: 22px" width="25%">
                    </td>
                    <td bgcolor="#ebe9ea" style="padding-top: 5px; height: 22px" width="10%">
                    </td>
                    <td bgcolor="#ebe9ea" style="height: 22px" width="25%">
                    </td>
                </tr>
			</table>
			<TABLE class="fixColStyle" id="tblPList" style="DISPLAY: none" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;明细信息</font></TD>
					<TD vAlign="bottom" width="97%" bgColor="#dce8f4" height="20"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
				<tr>
				    <td colspan="2"><iframe id="frmList" width="100%" height="130px"></iframe></td>
				</tr>
			</TABLE>
			<TABLE class="fixColStyle" id="TABLE3" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<td width="100%" align="center"><asp:ImageButton
                                        ID="btnPrint" runat="server" ImageUrl="../../Images/icon/print.gif" OnClick="btnPrint_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<!--<asp:ImageButton ID="imgBtnExcel" runat="server" ImageUrl="../../Images/icon/img16.gif" OnClick="imgBtnExcel_Click"/>--></td>
				</TR>
			</TABLE>
		</form>
		<!--<script language="JAVASCRIPT">
			LoapQuWGD();
		</script>-->
	</body>
</html>
