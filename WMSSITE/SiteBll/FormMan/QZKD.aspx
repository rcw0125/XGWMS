<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QZKD.aspx.cs" Inherits="SiteBll_FormMan_QRUKU" enableEventValidation="false" %>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>
<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"  TagPrefix="uc3" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<%--/柴艳亮--%>
<head runat="server">
    <title>转库单查询</title>
    <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
<script language="javascript" src="../../JavaScript/FormZKD.js" type="text/javascript"></script>
</head>
<body  leftMargin="0" topMargin="0" onload="Init();">
    <form id="form1" runat="server">
    <div>
    <TABLE class="fixColStyle" id="QZKD_TOP" height="28" cellSpacing="0" cellPadding="0" width="100%"
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="转库单查询"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="chazhao1();" alt="展开" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">列表配置</label><IMG id="btnconfig" style="CURSOR: hand" onclick="Addconfig();" alt="关闭" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">明细信息</label><IMG id="btnItem" style="CURSOR: hand" onclick="AddItems();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="tablecon"  style="display:none"  cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;列表配置</font></TD>
					<TD width="88%" bgColor="#dce8f4" height="20"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><uc3:SetDisplayList id="SetDisplayList1" runat="server">
                                    </uc3:SetDisplayList>  
		
					</TD>
				</TR>
			</TABLE><TABLE  id="chazhao" style="DISPLAY: block" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <TD width="10%" style="height: 23px;"><input id="chkZKDH" name="checkbox" onclick="GetZKDH();" type="checkbox" runat="server" />转库单号</TD>
			                    <TD width="17%" align="left" style="height: 23px"><FONT face="宋体"><bestcomy:ComboBox ID="drpZKDH" runat="server" Width="100%">
            </bestcomy:ComboBox></FONT><input name="hidden" type="hidden" id="hidZKDH" runat="server" /></TD>
			                    <TD width="10%" style="height: 23px">
                                    &nbsp;<input id="chkPCH" name="checkbox" onclick="GetPCH();" type="checkbox" runat="server" />批次号</TD>
			                    <TD width="15%" align="left" style="height: 23px">
                                    <asp:TextBox ID="txtPCH" runat="server" Width="95%" Enabled="False"></asp:TextBox></TD>
			                    <TD width="10%" style="height: 23px"><FONT face="宋体">&nbsp;<input id="chkWLH" type="checkbox" onclick="GetWLH();" runat="server"  />物料号</FONT></TD>
			                    <TD width="13%" style="height: 23px">
                                        <bestcomy:ComboBox ID="drpWLH" runat="server" Width="100%">
                                        </bestcomy:ComboBox>
                                        <input id="hidWLH" runat="server" type="hidden" /></TD>
			                    <TD width="12.5%" style="height: 23px"><FONT face="宋体">&nbsp;<input id="chkSX" name="checkbox" onclick="GetSX();" type="checkbox" runat="server" />属性</FONT></TD>
			                    <TD width="12.5%" style="height: 23px">
                                    <asp:DropDownList ID="drpSX" runat="server" Enabled="False" Width="100%">
                                    </asp:DropDownList>
                                    <input id="hidSX" runat="server" name="hidden" type="hidden" /></TD>
		                    </TR>
		                    <TR>
		                        <TD  width="10%" style="height: 23px;"><input id="chkPH" type="checkbox" onclick="GetPH();" runat="server" />牌号</TD>
		                        <TD align="left" style="height: 23px">
                                    <FONT face="宋体">
                                    <bestcomy:ComboBox ID="drpPH" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
                                    <input id="hidPH" runat="server" type="hidden" /></FONT></TD>
                                <td width="10%" style="height: 23px">
                                    &nbsp;<input id="chkGG" type="checkbox" onclick="GetGG();" runat="server"/>规格</td>
		                        <TD style="height: 23px">
                                    <bestcomy:ComboBox ID="drpGG" runat="server" Width="100%">
                                    </bestcomy:ComboBox>
                                    <input id="hidGG" runat="server" type="hidden" /></TD>
		                        <TD width="10%" style="height: 23px;"><FONT face="宋体">&nbsp;<input id="chkZCCK" name="checkbox" onclick="GetZCCK();" type="checkbox" runat="server" />转出仓库</FONT></TD>
		                        <TD style="height: 23px">
                                    <asp:DropDownList ID="drpZCCK" runat="server" Enabled="False" Width="86%">
                                    </asp:DropDownList>
                                    <input id="hidZCCK" runat="server" name="hidden" type="hidden" /></TD>
		                        <TD style="height: 23px"><FONT face="宋体">&nbsp;<input id="chkZRCK" name="checkbox" onclick="GetZRCK();" type="checkbox" runat="server" />转入仓库</FONT></TD>
		                        <td style="height: 23px"><FONT face="宋体"><asp:DropDownList ID="drpZRCK" runat="server" Enabled="False"
                                        Width="100%">
                                    </asp:DropDownList><input id="hidZRCK" runat="server" name="hidden" type="hidden" /></FONT></td>
	                        </TR>
                            <tr>
                                <td width="10%">
                                    <input id="chkCPH" name="checkbox" onclick="GetCPH();" type="checkbox" runat="server" />车牌号码</td>
                                <td align="left"><bestcomy:ComboBox ID="drpCPH" runat="server" Width="100%">
                                </bestcomy:ComboBox>
                                    <input id="hidCPH" runat="server" name="hidden" type="hidden" /></td>
                                <td>
                                    &nbsp;<input id="chkZCZT" name="checkbox" onclick="GetZCZT();" type="checkbox" runat="server" />转出状态</td>
                                <td>
                                    <asp:DropDownList ID="drpZCZT" runat="server" Enabled="False" Width="88%">
                                    </asp:DropDownList><input id="hidZCZT" runat="server" name="hidden" type="hidden" /></td>
                                <td style="width: 147px">
                                    &nbsp;<input id="chkZRZT" name="checkbox" onclick="GetZRZT();" type="checkbox" runat="server" />转入状态</td>
                                <td>
                                    <asp:DropDownList ID="drpZRZT" runat="server" Enabled="False" Width="87%">
                                    </asp:DropDownList><input id="hidZRZT" runat="server" name="hidden" type="hidden" /></td>
                                <td colspan="2"><input id="chkBDY" name="checkbox" onclick="GetBDY();" type="checkbox" runat="server" />
                                    <input id="hidBDY" runat="server" name="hidden" style="width: 24px" type="hidden" />转出数量不等于转入数量</td>
                            </tr>
                <tr>
                    <td width="10%">
                        <input id="chkZCSJ" name="chkZCSJ" onclick="GetZCSJ();" runat="server" type="checkbox" />转出时间</td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="ZCSJ_Start" runat="server" Enabled="false" Width="68px"></asp:TextBox>
                        <img onclick="calendar(ZCSJ_Start);" src="../../Images/icon/calendar.gif" style="cursor: hand" />至
                        <asp:TextBox ID="ZCSJ_End" runat="server" Enabled="false" Width="35%"></asp:TextBox>
                        <img onclick="calendar(ZCSJ_End);" src="../../Images/icon/calendar.gif" style="cursor: hand" /><input
                            id="hidZCSJ" runat="server" name="hidZCSJ" type="hidden" /></td>
                    <td>
                        <input id="chkZRSJ" name="checkbox" runat="server" onclick="GetZRSJ();" type="checkbox" />
                        转入时间</td>
                    <td colspan="2">
                        <asp:TextBox ID="ZRSJ_Start" runat="server" Enabled="false" Width="68px"></asp:TextBox>
                        <img onclick="calendar(ZRSJ_Start);" src="../../Images/icon/calendar.gif" style="cursor: hand" />至<asp:TextBox ID="ZRSJ_End" runat="server" Enabled="false" Width="35%"></asp:TextBox><img onclick="calendar(ZRSJ_End);" src="../../Images/icon/calendar.gif" style="cursor: hand" />
                        <input id="hidZRSJ" runat="server" name="hidRKRQ" type="hidden" /></td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td width="10%">
                        <input id="chkFree1" name="checkbox" onclick="GetFree1();" type="checkbox" runat="server" />自由项1</td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="txtFree1" runat="server" Enabled="False" Width="95%"></asp:TextBox></td>
                    <td>
                        <input id="chkFree2" name="checkbox" onclick="GetFree2();" type="checkbox" runat="server" />自由项2</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFree2" runat="server" Enabled="False" Width="95%"></asp:TextBox></td>
                    <td>
                        <input id="chkFree3" name="checkbox" onclick="GetFree3();" type="checkbox" runat="server" />自由项3</td>
                    <td>
                        <asp:TextBox ID="txtFree3" runat="server" Enabled="False" Width="95%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="8">
                        <table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
        &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" /></td>
  </tr>
</table>
                    </td>
                </tr>
                        
	         </TABLE>
 <uc2:PageControl id="PageControl1" runat="server">
                        </uc2:PageControl><DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:99%;height:280px;overflow:auto;white-space:nowrap;">
                <asp:GridView ID="grvZKD" runat="server" AutoGenerateColumns="False" Width="100%"  AllowSorting="True" OnSorting="grvZKD_Sorting" OnRowCreated="grvZKD_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                &nbsp;<input id="Checkbox1" type="checkbox" onclick="GetZKDItem();"/>
                                 <input id="strZKDH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ZKDH") %>'/>
                                 <input id="strZRZT" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.status") %>'/>
                                 <input id="strOUUT" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.outstatus") %>'/>
                                  <input id="strZCSL" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.OutNum") %>'/>
                                  <input id="strZRSL" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.InNum") %>'/>
                                  <input id="strJHSL" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.JHSL") %>'/>
                                  <input id="strPCH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.PCH") %>'/>
                                  <input id="strSX" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.SX") %>'/>
                                   <input id="strJHZL" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.JHZL") %>'/>
                                   <input id="strSL" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.SL") %>'/>
                                    <input id="strZL" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ZL") %>'/>
                             </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="转库单号" DataField="ZKDH" SortExpression="ZKDH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CPH" HeaderText="车牌号" SortExpression="CPH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PCH" HeaderText="批次" SortExpression="PCH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLH" HeaderText="物料号" SortExpression="WLH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性" SortExpression="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SCK" HeaderText="原仓库" SortExpression="SCK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="YHW" HeaderText="原货位" SortExpression="YHW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TCK" HeaderText="目的仓库" SortExpression="TCK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MBHW" HeaderText="目的货位" SortExpression="MBHW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZJLDW" HeaderText="辅计量单位" SortExpression="FJLDW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="主计量单位" DataField="fjldw" SortExpression="zjldw" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JHSL" HeaderText="计划数量" SortExpression="JHSL" >
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JHZL" HeaderText="计划重量" DataFormatString="{0:N3}" HtmlEncode="False" SortExpression="JHZL" >
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OutNum" HeaderText="转出卷数(总计)" SortExpression="OutNum" >
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                            <FooterStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OutZL" HeaderText="转出重量(总计)" DataFormatString="{0:N3}" HtmlEncode="False" SortExpression="OutZL" >
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                            <FooterStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="InNum" HeaderText="转入卷数(总计)" SortExpression="InNum" >
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                            <FooterStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="InZL" HeaderText="卷入重量(总计)" SortExpression="InZL" DataFormatString="{0:N3}" HtmlEncode="False">
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                            <FooterStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SL" HeaderText="单车卷数" SortExpression="SL" >
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                            <FooterStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZL" HeaderText="单车重量" SortExpression="ZL" DataFormatString="{0:N3}" HtmlEncode="False">
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                            <FooterStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="desc_zhxlb" HeaderText="转出类别" SortExpression="desc_zhxlb" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="desc_outstatus" HeaderText="转出状态" SortExpression="desc_outstatus" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CKOperator" HeaderText="出库操作" SortExpression="CKOperator" >
                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CKTime" HeaderText="转出时间" SortExpression="CKTime" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="desc_status" HeaderText="转入状态" SortExpression="desc_status" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RKOperator" HeaderText="入库操作" SortExpression="RKOperator" >
                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RKTime" HeaderText="转入时间" SortExpression="RKTime" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLMC" HeaderText="物料名称" SortExpression="WLMC" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" SortExpression="vfree1"><ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" /></asp:BoundField>
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" SortExpression="vfree2"><ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" /></asp:BoundField>
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" SortExpression="vfree3"><ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" /></asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                </asp:GridView>
			</DIV>						<table width="100%" align="center" border="0" height="25px">
				<tr>
                    <td style="height: 16px">
                        总计：<asp:Label ID="lblSUM" runat="server" Text="0"></asp:Label></td>
                    <td style="height: 16px">
                        计划数量：<asp:Label ID="lblJHSL" runat="server" Text="0"></asp:Label></td>
                    <td style="height: 16px">
                        计划重量：<asp:Label ID="lblJHZL" runat="server" Text="0"></asp:Label></td>
                    <td style="height: 16px">
                    &nbsp; &nbsp;&nbsp;</td><td style="height: 16px">卷数：<asp:Label ID="lblSL" runat="server" Text="0"></asp:Label></td><td style="height: 16px">重量：<asp:Label ID="lblZL" runat="server" Text="0"></asp:Label></td><td style="height: 16px"></td>
				</tr>
			</table><input id="hidQuery" runat="server" type="hidden" /> <input id="Hidconfig" type="hidden" /><input id="hidItem" type="hidden" />
			<TABLE class="fixColStyle" id="tblPList"  cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server" style="DISPLAY: none;">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;单卷信息</font></TD>
					<TD vAlign="bottom" width="97%" bgColor="#dce8f4" height="20"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
				<tr>
				    <td colspan="2"><iframe id="frmList" width="99%" height="150px"></iframe></td>
				</tr>
			</TABLE>
			<table cellpadding="0" cellspacing="0" width="100%" style="height: 25px">
			<tr>
			<td style="height: 47px"> &nbsp; &nbsp;&nbsp;<asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../../Images/icon/PrintExp.gif"
                    OnClick="btnPrint_Click" />
                &nbsp; &nbsp;&nbsp;
                <img src="../../Images/icon/img12.gif" id="chongzhi" onclick="GetChongzhi();" style="cursor:hand; "/>
                &nbsp; &nbsp;&nbsp;
                <img src="../../Images/icon/closedanju.gif" id="closedanju" onclick="Closedanju();" style="cursor:hand;" />
                <input id="hidchong" type="hidden" /><input id="hidzcsl" type="hidden" /><input id="hidzrsl" type="hidden" /><input id="hidjhsl" type="hidden" />
                <input id="hidzhdh1" type="hidden" /><input id="hidOUTT" type="hidden" />
                <input id="hidPROCPCH" type="hidden" />
                <input id="hidPROCSX" type="hidden" /></td>
			</tr>
			</table>
    </div>
    </form>
</body>
</html>
