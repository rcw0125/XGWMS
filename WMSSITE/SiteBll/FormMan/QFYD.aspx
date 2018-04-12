<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QFYD.aspx.cs" Inherits="SiteBll_FormMan_QFYD"  EnableEventValidation="false"%>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>


<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"
    TagPrefix="uc3" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发运单查询</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FormFYD.js" type="text/javascript"></script>
    
</head>
<body leftMargin="0" topMargin="0" onload="Init();">
    <form id="form1" runat="server" method="post">
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="发运单查询"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="AddQuery();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">列表配置</label><IMG id="btnconfig" style="CURSOR: hand" onclick="Addconfig();" alt="关闭" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">明细信息</label><IMG id="btnItem" style="CURSOR: hand" onclick="AddItems();" alt="展开" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE id="tblQuery" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <TD width="10%" style="height: 23px"><input name="checkbox" type="checkbox" id="chkCKH" onclick="GetCKH();" runat="server" />仓库</TD>
			                    <TD width="19%" align="left" style="height: 23px"><FONT face="宋体">
      <asp:DropDownList ID="drpCKH" runat="server" Width="95%" DataTextField="CKCKName" DataValueField="CKID"> </asp:DropDownList></FONT></TD>
			                    <TD width="13%" style="height: 23px">
          <input name="checkbox2" type="checkbox" id="chkFYD" onclick="GetFYD();" runat="server"/>发运单</TD>
			                    <TD width="15%" align="left" style="height: 23px">
        <bestcomy:ComboBox ID="drpFYD" runat="server" Width="100%">
        </bestcomy:ComboBox><input name="hidden" type="hidden" id="hidFYD" runat="server" /></TD>
			                    <TD width="9%" style="height: 23px"><FONT face="宋体">
                                    <input name="checkbox2" type="checkbox" id="chkZDR" onclick="GetZDR();" runat="server"/>制单人</FONT></TD>
			                    <TD width="11%" style="height: 23px">
                                    <asp:DropDownList ID="drpZDR" runat="server" Width="95%" Enabled="False" DataTextField="NCZDRY" DataValueField="NCZDRY"> </asp:DropDownList></TD>
			                    <TD width="11.5%" style="height: 23px"><FONT face="宋体">
                                    <input name="checkbox2" type="checkbox" id="chkTSXX" onclick="GetTSXX();" runat="server"/>特殊信息</FONT></TD>
			                    <TD width="12.5%" style="height: 23px">
                                    <bestcomy:ComboBox ID="drpTSXX" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
        <input name="hidden" type="hidden" id="hidTSXX" runat="server" style="width: 58px" /></TD>
		                    </TR>
		                    <TR>
		                        <TD style="height: 23px">
                                    <input name="checkbox2" type="checkbox" id="chkGG" onclick="GetGG();" runat="server" />规格</TD>
		                        <TD align="left" style="height: 23px">
                                    <FONT face="宋体">
                                    <asp:DropDownList ID="drpGG" runat="server" Width="45%" Enabled="False" DataTextField="GG" DataValueField="GG"> </asp:DropDownList>-<asp:DropDownList ID="drpCopyGG" runat="server" Width="46%" Enabled="False" DataTextField="GG" DataValueField="GG"> </asp:DropDownList></FONT></TD>
                                <td style="height: 23px">
                                    <input name="checkbox2" type="checkbox" id="chkWLH" onclick="GetWLH();" runat="server"/>物料号</td>
		                        <TD style="height: 23px">
                                    <bestcomy:ComboBox ID="drpWLH" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
                                    <input id="hidWLH" runat="server" type="hidden" /></TD>
		                        <TD style="width: 147px; height: 23px;"><FONT face="宋体"><input name="checkbox2" type="checkbox" id="chkWCBZ" onclick="GetWCBZ();" runat="server">状态</FONT></TD>
		                        <TD style="height: 23px">
                                    <asp:DropDownList ID="drpWCBZ" runat="server" Width="95%" Enabled="False"> 
                                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                                        <asp:ListItem Value="0">未执行</asp:ListItem>
                                        <asp:ListItem Value="1">已进门</asp:ListItem>
                                        <asp:ListItem Value="2">装车完毕</asp:ListItem>
                                        <asp:ListItem Value="3">已出门</asp:ListItem>
                                        <asp:ListItem Value="4">已作废</asp:ListItem>
                                        <asp:ListItem Value="5">正在装车</asp:ListItem>
                                    </asp:DropDownList></TD>
		                        <TD style="height: 23px"><FONT face="宋体"><input name="checkbox2" type="checkbox" id="chkPH" onclick="GetPH();" runat="server" />牌号</FONT></TD>
		                        <td style="height: 23px"><FONT face="宋体">
                                    <bestcomy:ComboBox ID="drpPH" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
        <input name="hidden" type="hidden" id="hidPH" runat="server" /></FONT></td>
	                        </TR>
                            <tr>
                                <td>
                                    <input name="checkbox2" type="checkbox" id="chkSX" onclick="GetSX();" runat="server"/>属性</td>
                                <td align="left">
                                    <asp:DropDownList ID="drpSX" runat="server" Width="95%" Enabled="False" DataTextField="SX" DataValueField="SX"> </asp:DropDownList></td>
                                <td>
                                    <input name="checkbox2" type="checkbox" id="chkCPH" onclick="GetCPH();" runat="server">车牌号</td>
                                <td>
        <bestcomy:ComboBox ID="drpCPH" runat="server" Width="100%">
        </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidCPH" runat="server" /></td>
                                <td style="width: 147px">
          <input name="checkbox2" type="checkbox" id="chkBM" onclick="GetBM();" runat="server" />部门</td>
                                <td>
                                    <asp:DropDownList ID="drpBM" runat="server" Width="95%" Enabled="False" DataTextField="NCBM" DataValueField="NCBM"> </asp:DropDownList></td>
                                <td>
                                    <input name="checkbox2" type="checkbox" id="chkKHH" onclick="GetKHH();" runat="server"/>客户号</td>
                                <td>
                                    <bestcomy:ComboBox ID="drpKHH" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
        <input name="hidden" type="hidden" id="hidKHH" runat="server" /></td>
                            </tr>
            <tr>
                <td>
                    <input name="chktxtPC" type="checkbox" id="chktxtPC" onclick="GettxtPC();" runat="server"/>批次</td>
                <td align="left">
                    <asp:TextBox ID="txtPC" runat="server" Width="95%"></asp:TextBox></td>
                <td>
                    <input name="chkADD" type="checkbox" id="chkADD" onclick="GetADD();" runat="server"/>地址</td>
                <td>
                    <bestcomy:ComboBox ID="drpADD" runat="server" Width="100%">
                    </bestcomy:ComboBox><input name="hidden" type="hidden" id="hidADD" runat="server" /></td>
                <td style="width: 147px">
                    <input name="chkJMKH" type="checkbox" id="chkJMKH" onclick="GetJMKH();" runat="server"/>进门卡号</td>
                <td>
                    <asp:TextBox ID="txtJMKH" runat="server" Width="95%"></asp:TextBox>
                </td>
                <td>
                    <input name="checkbox2" type="checkbox" id="chkCMKH" onclick="GetCMKH();" runat="server"/>出门卡号</td>
                <td>
                    <asp:TextBox ID="txtCMKH" runat="server" Width="95%"></asp:TextBox></td>
            </tr>
                            <tr>
                                <td style="height: 18px">
                                    <input name="chkMakeTime" type="checkbox" id="chkMakeTime" onclick="GetMakeTime();" runat="server"/>制单日期</td>
                                <td align="left" style="height: 18px">
                                    <asp:TextBox ID="MakeStartTime" runat="server" Width="80%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(MakeStartTime);" style="cursor: hand" />至</td>
                                <td><asp:TextBox ID="MakeEndTime" runat="server" Width="85%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(MakeEndTime);" style="cursor: hand" /></td>
                                <td style="height: 18px">
                                    <input name="chkChuKuTime" type="checkbox" id="chkChuKuTime" onclick="GetChuKuTime();" runat="server"/>出库时间</td>
                                <td colspan="3" style="height: 18px">
                                    <asp:TextBox ID="ChuKuStartTime" runat="server" Width="31%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(ChuKuStartTime);" style="cursor: hand" />至<asp:TextBox ID="ChuKuEndTime" runat="server" Width="31%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(ChuKuEndTime);" style="cursor: hand" />
        </td>
                                <td style="height: 18px">
                                    <input type="checkbox" ID="chkSFS0" runat="server"/>实发数0</td>
                            </tr>
            <tr>
                <td style="height: 18px">
                    <input name="chkGoTime" type="checkbox" id="chkGoTime" onclick="GetGoTime();" runat="server"/>出门时间</td>
                <td align="left" style="height: 18px">
                
                    <asp:TextBox ID="GoStartTime" runat="server" Width="80%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(GoStartTime);" style="cursor: hand" />至
                </td>
                <td>
                    <asp:TextBox ID="GoEndtime" runat="server" Width="85%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(GoEndtime);" style="cursor: hand" /></td>
                <td style="height: 18px">
                    <input name="chkInTime" type="checkbox" id="chkInTime" onclick="GetInTime();" runat="server"/>入门时间</td>
                <td colspan="3" style="height: 18px">
                    <asp:TextBox ID="InStartTime" runat="server" Width="31%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(InStartTime);" style="cursor: hand" />至<asp:TextBox ID="InEndTime" runat="server" Width="31%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(InEndTime);" style="cursor: hand" />
        </td>
                <td style="height: 18px">
                </td>
            </tr>
             <tr>
                                <td>
                                    <input name="checkbox2" type="checkbox" id="chkChuanShu" onclick="GetChuanShu();" runat="server"/>运输</td>
                                <td align="left">
                                    <asp:DropDownList ID="drpChuanShu" runat="server" Width="95%" Enabled="False"> 
                                        <asp:ListItem Value="0" Selected="True">请选择</asp:ListItem>
                                        <asp:ListItem Value="1">汽车发运</asp:ListItem>
                                        <asp:ListItem Value="2">火车发运</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td><input name="chkFree1" type="checkbox" id="chkFree1" onclick="GettxtFree1();" runat="server"/>自由项1</td>
                                <td>
                                    <asp:TextBox ID="txtFree1" runat="server" Width="95%"></asp:TextBox></td>
                                <td style="width: 147px"><input name="chkFree2" type="checkbox" id="chkFree2" onclick="GettxtFree2();" runat="server"/>自由项2</td>
                                <td>
                                    <asp:TextBox ID="txtFree2" runat="server" Width="95%"></asp:TextBox></td>
                                <td><input name="chkFree3" type="checkbox" id="chkFree3" onclick="GettxtFree3();" runat="server"/>自由项3</td>
                                <td>
                                    <asp:TextBox ID="txtFree3" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 18px">
                                </td>
                                <td align="left" colspan="2" style="height: 18px">
                                    &nbsp; &nbsp;<asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
      
      <asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" /></td>
                                <td style="height: 18px">
                                    </td>
                                <td colspan="3" style="height: 18px">
                                    </td>
                                <td style="height: 18px">
                                </td>
                            </tr>
                            
	         </TABLE>
	         
             <uc3:SetDisplayList id="SetDisplayList1" runat="server"></uc3:SetDisplayList>
  <uc2:PageControl id="PageControl1" runat="server">
                        </uc2:PageControl>
                        		<DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:98%;height:270px;overflow:auto;white-space:nowrap;align:center;">
                        		<asp:GridView ID="grvFYD" runat="server" AutoGenerateColumns="False"  AllowSorting="True" Width="100%" OnSorting="grvFYD_Sorting" OnRowCreated="grvFYD_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="查看明细">
                            <ItemTemplate>
                                &nbsp;<asp:CheckBox ID="chkCFYD" runat="server" onClick="GetFYDItem();"/>
                                <input id="strFYDH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.FYDH") %>'/>
                                <input id="strYSLB" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.yslb") %>'/>
                                <input id="strStatus" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.status") %>'/>
                                <input id="strCK" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CK") %>'/>
                                <input id="strWLH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.WLH") %>'/>
                                <input id="strSX" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.SX") %>'/>
                                <input id="strCPH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CPH") %>'/>
                                <input id="strVfree1" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.vfree1") %>'/>
                                <input id="strVfree2" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.vfree2") %>'/>
                                <input id="strVfree3" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.vfree3") %>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="发运单号" DataField="FYDH" SortExpression="FYDH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CK" HeaderText="仓库" SortExpression="CK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CPH" HeaderText="车牌号" SortExpression="CPH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Desc_yslb" HeaderText="运输类别" SortExpression="yslb" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLH" HeaderText="物料号" SortExpression="WLH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLMC" HeaderText="物料名称" SortExpression="WLMC" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性" SortExpression="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PH" HeaderText="牌号" SortExpression="PH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GG" HeaderText="规格" SortExpression="GG" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PCInfo" HeaderText="特殊信息" SortExpression="PCInfo" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZJLDW" HeaderText="辅计量单位" SortExpression="FJLDW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="zJHZL" HeaderText="计划重量" SortExpression="JHZL" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="zSJZL" HeaderText="实际重量" SortExpression="SJZL" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FJLDW" HeaderText="主计量单位" SortExpression="ZJLDW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JHSL" HeaderText="计划数量" SortExpression="JHSL" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJSL" HeaderText="实际数量" SortExpression="SJSL" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KHBM" HeaderText="客户编码" SortExpression="KHBM" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="khname" HeaderText="客户名称" SortExpression="khname" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CZ_InTime" HeaderText="入门时间" SortExpression="CZ_InTime" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CZ_InUser" HeaderText="入门操作人" SortExpression="CZ_InUser" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出门时间" DataField="CZ_OtTime" SortExpression="CZ_OtTime" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CZ_OtUser" HeaderText="出门操作人" SortExpression="CZ_OtUser" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="执行状态" DataField="Desc_status" SortExpression="Desc_status" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="制单人员" DataField="nczdry" SortExpression="nczdry" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="制单日期" DataField="NCZDRQ" SortExpression="NCZDRQ" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="所属部门" DataField="NCBM" SortExpression="NCBM" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="目的地址" DataField="AimAdress" SortExpression="AimAdress" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作废人" DataField="ZFR" SortExpression="ZFR" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="作废时间" DataField="ZFTime" SortExpression="ZFTime" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库时间" DataField="CKRQ" SortExpression="CKRQ" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="进门卡号" DataField="indoorid" SortExpression="indoorid" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出门卡号" DataField="outdoorid" SortExpression="outdoorid" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" SortExpression="vfree1" >
                        <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" SortExpression="vfree2" >
                        <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" SortExpression="vfree3" >
                        <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV>
			<table class="fixColStyle" rules="rows" width="100%" align="center" border="1">
  <tr>
    <td width="10%" style="height: 18px">总计:</td>
    <td width="10%" style="height: 18px"><asp:Label ID="lblCount" runat="server" Text="0"></asp:Label></td>
    <td width="10%" style="height: 18px">计划数量</td>
    <td width="10%" style="height: 18px"><asp:Label ID="jhsl" runat="server" Text="0"></asp:Label>
                       </td>
    <td width="10%" style="height: 18px">实际数量</td>
    <td width="10%" style="height: 18px"><asp:Label ID="sjsl" runat="server" Text="0"></asp:Label></td>
    <td width="10%" style="height: 18px">计划重量</td>
    <td width="10%" style="height: 18px">&nbsp; <asp:Label ID="jhzl" runat="server" Text="0"></asp:Label>
                        </td>
    <td width="10%" style="height: 18px">实际重量</td>
    <td width="10%" style="height: 18px"><asp:Label ID="sjzl" runat="server" Text="0"></asp:Label></td>
  </tr>
</table>
			<TABLE class="fixColStyle" id="tblPList" cellSpacing="0" cellPadding="0" style="display:none"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;单卷信息</font></TD>
					<TD vAlign="bottom" width="97%" bgColor="#dce8f4" height="20"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
				<tr>
				    <td colspan="2"><iframe id="frmList" width="98%" height="150px"></iframe></td>
				</tr>
			</TABLE>
					<TABLE class="fixColStyle" id="TABLE2" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<tr>
				    <td colspan="2">
                        &nbsp;<img src="../../Images/icon/print.gif" onclick="displayDivP('divPrint');" id="imgPrint" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgBtnFei" runat="server" ImageUrl="../../Images/icon/zuofei.gif" OnClick="imgBtnFei_Click" />
                        &nbsp;
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="btnCancle" runat="server" ImageUrl="../../Images/icon/cancelwc.gif" OnClick="btnCancle_Click"/>
                        &nbsp;
                        &nbsp; &nbsp;
                        <img src="../../Images/icon/che.gif" id="che" onclick="displayDiv('popbox');" style="cursor:hand; "/>
                        &nbsp;
                        &nbsp; &nbsp;
                        <asp:ImageButton ID="btnKyhw" runat="server" ImageUrl="../../Images/icon/kyhw.gif" OnClick="btnKyhw_Click" Visible="False"/>
                        
                        <img src="../../Images/icon/kyhw.gif" id="Img3" onclick="javascript:showkyhw();" style="cursor:hand; "/>
                        <img src="../../Images/icon/imgFHCK.gif" id="Img4" onclick="javascript:showFHTJ();" style="cursor:hand; "/>
                        <input id="hidFYDHitem" type="hidden" runat="server" />
                        <input id="hidStatus" type="hidden" runat="server" />
                        <input id="hidyslb" type="hidden" runat="server" />
                        <input id="hidItem" type="hidden" runat="server"/><input id="Hidconfig" type="hidden" runat="server"/><input id="hidQuery" runat="server" type="hidden" />
                        
                    </td>
				</tr>
			</TABLE>
			<div id="divPrint" style="DISPLAY: none; WIDTH: 150px;position:absolute; background-color: menu;">
								<table height="100%" cellSpacing="1" cellPadding="1" width="100%"
									border="1">
									<tr>
										<td align="left" style="height: 18px">
                                            选择打印预览报表</td>
									</tr>
									<tr>
										<td vAlign="top" align="center">                                            
										    <asp:RadioButtonList ID="rdoReport" runat="server">
                                                <asp:ListItem Value="0">装车明细</asp:ListItem>
                                                <asp:ListItem Value="1">发运单列表</asp:ListItem>
                                                <asp:ListItem Value="2">单卷信息</asp:ListItem>
                                                <asp:ListItem Value="3">装车明细新</asp:ListItem>
                                            </asp:RadioButtonList></td>
									</tr>
									<tr> 
										<td align="center">
                                            &nbsp;<asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../../Images/icon/queding.gif" OnClick="btnPrint_Click" /><img id="img2" src="../../Images/icon/cancel.gif" style="cursor:hand" onclick="closeDiv('divPrint');" />
										</td>
									</tr>
								</table>
							</div>
			<div id="popbox" style="DISPLAY: none; WIDTH: 220px; position:absolute; background-color: menu;">
								<table height="100%" cellSpacing="1" cellPadding="1" width="100%"
									border="1">
									<tr>
										<td align="left" style="height: 18px">请输入车厢号：</td>
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
