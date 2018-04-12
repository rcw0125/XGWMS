<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KuCunQuery.aspx.cs" Inherits="SiteBll_StockMan_CuCunQuery"  EnableEventValidation="false"%>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>
<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"  TagPrefix="uc3" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>当前库存</title>
              <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
            <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/KuCunView.js" type="text/javascript"></script>
</head>
<script type="text/javascript">
function check(obj)
{
	var e = event.srcElement;
	var table = e.parentNode.parentNode.parentNode.parentNode;
	var row = table.all.tags("tr");
	var row1 = row[1];
	var texts = row1.all.tags("INPUT")
	if(texts.length == 0)
		return;
	for(var i = 0; i < texts.length;i++)
	{
		texts[i].checked = obj.checked;	
	}
}
/*显示或隐藏查询条件*/
function chazhao1() 
{
	var btnQuery = document.getElementById("btnQuery");
	var chazhao = document.getElementById("chazhao");
	var hidQuery = document.getElementById("hidQuery");
	
	var btnconfig = document.getElementById("btnconfig");
	var tablecon = document.getElementById("tablecon");
	var Hidconfig = document.getElementById("Hidconfig");
	
	if(Hidconfig.value=="block")
	{
	tablecon.style.display="none";
	btnconfig.src = "../../images/icon/expand.gif";
	btnconfig.alt = "展开";
	Hidconfig.value= "none";
	}
	
	if(chazhao.style.display == "block")
	{
		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		chazhao.style.display = "none";
		hidQuery.value= "none";
	}
	else
	{
		btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
		chazhao.style.display = "block";
		hidQuery.value = "block";
	}
	
}

/*显示或者隐藏列表配置*/
function Addconfig() 
{
	var btnconfig = document.getElementById("btnconfig");
	var tablecon = document.getElementById("tablecon");
	var Hidconfig = document.getElementById("Hidconfig");
	
	var hidQuery = document.getElementById("hidQuery");
	var btnQuery = document.getElementById("btnQuery");
	var chazhao = document.getElementById("chazhao");
	if(hidQuery.value=="block")
	{
	chazhao.style.display="none";
	btnQuery.src = "../../images/icon/expand.gif";
	btnQuery.alt = "展开";
	hidQuery.value= "none";
	}
	if(tablecon.style.display ==  "block")
	{
		btnconfig.src = "../../images/icon/expand.gif";
		btnconfig.alt = "展开";
		tablecon.style.display = "none";
		Hidconfig.value= "none";
	}
	else
	{
		btnconfig.src = "../../images/icon/collapse.gif";
		btnconfig.alt = "关闭";
		tablecon.style.display = "block";
		Hidconfig.value= "block";
	}
}




</script>
<body leftMargin="0" topMargin="0" onload="load_AllKUCUN();">
<input id="hidQuery" runat="server" type="hidden" /> <input id="Hidconfig" type="hidden" />
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="当前库存"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="chazhao1();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
<%--					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">列表配置</label><IMG id="btnconfig" style="CURSOR: hand" onclick="Addconfig();" alt="关闭" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>--%>
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
			</TABLE><table id="chazhao" style="DISPLAY: block" cellSpacing="0" cellPadding="0"	width="100%" align="center" border="0" runat="server">
  <tr>
    <td style="height:20px; width: 1203px;" bgColor="#dce8f4"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">查询条件</font></td>
  </tr>
  <tr>
    <td style="width: 1203px"><table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="2">
      <tr>
        <td style="width: 8%; height: 14px;"><input name="chkCK" type="checkbox" id="chkCK" runat="Server" onclick="GetCK();" />仓库<input name="hidden" type="hidden" id="hidCK" runat="server" style="width: 11px" /></td>
        <td style="width: 15%; height: 14px;">
            <asp:DropDownList ID="drpCK" runat="server" Width="100%" Enabled="False"> </asp:DropDownList>
      </td>
        <td style="width: 8%; height: 14px;"><input name="checkbox" type="checkbox" id="chkHW" runat="Server"  onclick="HWread();" />货位</td>
        <td style="width: 15%; height: 14px;">
            <asp:TextBox ID="txtHW" runat="server" Width="100%"></asp:TextBox></td>
        <td style="width: 8%; height: 14px;"><input name="checkbox" type="checkbox" id="chkRKPCH" runat="server" onclick="GetRKPCH();" />批次</td>
        <td width="15%" style="height: 14px">
            <asp:TextBox ID="txtPCH" runat="server" Width="100px"></asp:TextBox></td>
        <td style="width: 8%; height: 14px;">
            <input name="chkRKSX" type="checkbox" id="chkRKSX" runat="Server" onclick="GetRKSX();" />属性</td>
        <td style="width: 15%; height: 14px;">
            <asp:DropDownList ID="drpRKSX" runat="server" Width="90%">
            </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidRKSX" runat="server" style="width: 9px" /></td>
      </tr>
      <tr>
        <td style="width: 8%"><input name="checkbox" type="checkbox" id="chkWLH" runat="Server"  onclick="GetWLH();" />物料</td>
        <td style="width: 15%">
      <asp:TextBox id="txtWLH" runat="server" Width="100%"></asp:TextBox></td>
        <td style="width: 8%"><input name="checkbox" type="checkbox" id="chkTSXX" runat="Server"  onclick="GetTSXX();" />特殊信息</td>
        <td style="width: 15%"><bestcomy:ComboBox ID="drpTSXX" runat="server" Width="90%">
        </bestcomy:ComboBox>
            <input name="hidden" type="hidden" id="hidTSXX" runat="server" style="width: 6px" /></td>
        <td style="width: 8%"><input name="chkTM" type="checkbox" runat="Server" id="chkTM" onclick="GetTM();" />条码</td>
        <td>
            <asp:TextBox ID="txtBarcode" runat="server"></asp:TextBox></td>
        <td style="width: 8%"></td>
        <td style="width: 15%">
            </td>
      </tr>
        <tr>
            <td style="width: 8%">
                <input name="checkbox" type="checkbox" id="chkFree1" runat="Server"  onclick="GetFree1();" />自由项1</td>
            <td style="width: 15%">
                <asp:TextBox ID="txtFree1" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 8%">
                <input name="checkbox" type="checkbox" id="chkFree2" runat="Server"  onclick="GetFree2();" />自由项2</td>
            <td style="width: 15%">
                <asp:TextBox ID="txtFree2" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 8%">
                <input name="checkbox" type="checkbox" id="chkFree3" runat="Server"  onclick="GetFree3();" />自由项3</td>
            <td>
                <asp:TextBox ID="txtFree3" runat="server" Width="100%"></asp:TextBox></td>
            <td style="width: 8%">
            </td>
            <td style="width: 15%">
            </td>
        </tr>
      <tr>
        <td style="width: 8%; height: 21px;"><input name="chkRKRQ" type="checkbox" id="chkRKRQ" runat="server" onclick="GetRKRQ();" />入库日期</td>
        <td colspan="2" style="height: 21px"><asp:TextBox ID="RKRQ_Start" runat="server" Width="35%" Enabled="false"></asp:TextBox>
        <img src="../../Images/icon/calendar.gif" onclick="calendar(RKRQ_Start);" style="cursor: hand" />至
      <asp:TextBox ID="RKRQ_End" runat="server" Width="35%" Enabled="false"></asp:TextBox>
      <img src="../../Images/icon/calendar.gif" onclick="calendar(RKRQ_End);" style="cursor: hand" /><input name="hidRKRQ" type="hidden" id="hidRKRQ" runat="server" style="width: 9px"/></td>
        <td align="left" style="width: 89px; height: 21px"><input name="chkGG" type="checkbox" id="chkGG" runat="Server"  onclick="GetGG();" />规格</td>
        <td colspan="2" style="height: 21px">
        <asp:DropDownList ID="drpGG" runat="server" Width="90%" Enabled="false"></asp:DropDownList><input id="hidGG" runat="server" name="hidden" style="width: 3%" type="hidden" />---</td>
        <td colspan="2" style="height: 21px"><asp:DropDownList ID="drpCopyGG" runat="server" Width="90%" Enabled="false"></asp:DropDownList><input id="hidCopyGG" runat="server" name="hidden" style="width: 3%" type="hidden" /></td>
      </tr>
        <tr>
            <td style="width: 8%; height: 26px;">
                <input name="checkbox" type="checkbox" id="chkRKPH" runat="Server"  onclick="GetRKPH();" />牌号</td>
            <td colspan="2" style="height: 26px">
                <asp:CheckBox ID="chkPHMH" runat="server" Text="是否模糊" /><bestcomy:ComboBox ID="drpRKPH" runat="server" Width="130px">
        </bestcomy:ComboBox><input name="hidden" type="hidden" id="hidRKPH" runat="server" style="width: 1px" /></td>
            <td align="left" style="width: 89px; height: 26px">
            <input name="chkWRQ" type="checkbox" id="chkWRQ" runat="server" onclick="GetWRQ();" />称重日期</td>
            <td colspan="2" style="height: 26px">
                    <asp:TextBox ID="txtWRQfrom" runat="server" Enabled="false" Width="85%"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(txtWRQfrom);" style="cursor: hand" />
                    至<input name="hidWRQ" id="hidWRQ" type="hidden" runat="server" style="width: 9px"/></td>
            <td colspan="2" style="height: 26px">
                    <asp:TextBox ID="txtWRQto" runat="server" Enabled="false" Width="80%"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(txtWRQto);" style="cursor: hand" /></td>
        </tr>
    </table><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td style="height: 25px">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
        &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" /></td>
  </tr>
</table></td>
  </tr>
</table>
        <uc2:PageControl id="PageControl1" runat="server"></uc2:PageControl>
        <uc2:PageControl ID="PageControl2" runat="server" Visible="false" />
        <uc2:PageControl ID="PageControl3" runat="server" Visible="false" />
        <uc2:PageControl ID="PageControl4" runat="server" Visible="false" />
<DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:100%;height:300px;overflow:auto;white-space:nowrap;">

                <asp:GridView ID="grvKC_PCH" runat="server" AutoGenerateColumns="False" Width="98%" AllowSorting="True" OnSorting="grvKC_PCH_Sorting">
                    <Columns>
                        <asp:BoundField HeaderText="批次号" DataField="PCH" SortExpression="PCH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="CK"  SortExpression="CK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX"  SortExpression="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH"  SortExpression="MAX(PH)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG"  SortExpression="MAX(GG)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料号" DataField="WLH"  SortExpression="WLH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="卷数" DataField="SL"  SortExpression="COUNT(Barcode)" >
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="SUMZL" DataFormatString="{0:N3}"  SortExpression="SUM(ZL)" >
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库日期" DataField="RKRQ" SortExpression="MAX(RQ)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC"  SortExpression="MAX(WLMC)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VFREE1" HeaderText="自由项1" SortExpression="VFREE1" />
                        <asp:BoundField DataField="VFREE2" HeaderText="自由项2" SortExpression="VFREE2" />
                        <asp:BoundField DataField="VFREE3" HeaderText="自由项3" SortExpression="VFREE3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
                    
                <asp:GridView ID="grvKC_HW" runat="server" AutoGenerateColumns="False" Width="98%" Visible="False" AllowSorting="True" OnSorting="grvKC_HW_Sorting" >
                    <Columns>
                        <asp:BoundField HeaderText="货位" DataField="HW"   SortExpression="HW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="CK"   SortExpression="CK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批次号" DataField="PCH"   SortExpression="PCH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX"   SortExpression="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料号" DataField="WLH"   SortExpression="WLH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH"   SortExpression="MAX(PH)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG"   SortExpression="MAX(GG)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="卷数" DataField="SL"   SortExpression="COUNT(Barcode)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="SUMZL" DataFormatString="{0:N3}"   SortExpression="SUM(ZL)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库日期" DataField="RKRQ"   SortExpression="MAX(RQ)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC"   SortExpression="MAX(WLMC)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VFREE1" HeaderText="自由项1" SortExpression="VFREE1" />
                        <asp:BoundField DataField="VFREE2" HeaderText="自由项2" SortExpression="VFREE2" />
                        <asp:BoundField DataField="VFREE3" HeaderText="自由项3" SortExpression="VFREE３" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
    
                <asp:GridView ID="grvKC_TM" runat="server" AutoGenerateColumns="False" Width="130%" Visible="False" AllowSorting="True" OnSorting="grvKC_TM_Sorting">
                    <Columns>
                        <asp:BoundField HeaderText="单卷号" DataField="Barcode"  SortExpression="Barcode" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HW" HeaderText="货位"  SortExpression="HW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PCH" HeaderText="批次号"  SortExpression="PCH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLH" HeaderText="物料号"  SortExpression="WLH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性"  SortExpression="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="不合格原因" DataField="ErrSeason"  SortExpression="ErrSeason" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH"  SortExpression="PH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG"  SortExpression="GG" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="ZL" DataFormatString="{0:N3}"  SortExpression="ZL" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="标准" DataField="BZ"  SortExpression="BZ" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库日期" DataField="RQ"  SortExpression="RQ" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库单号" DataField="WGDH"  SortExpression="WGDH" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="钩号" DataField="GH"  SortExpression="GH" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="班别" DataField="BB"  SortExpression="BB" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库类型" DataField="RKTYPE"  SortExpression="RKTYPE" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库人员" DataField="RKRY"  SortExpression="RKRY" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批次信息" DataField="PCInfo"  SortExpression="PCInfo" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="称重日期" DataField="weightRQ"  SortExpression="weightRQ" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VFREE1" HeaderText="自由项1" SortExpression="VFREE1" />
                        <asp:BoundField DataField="VFREE2" HeaderText="自由项2" SortExpression="VFREE2" />
                        <asp:BoundField DataField="VFREE3" HeaderText="自由项3" SortExpression="VFREE3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
                <asp:GridView ID="grvKC_WLH" runat="server" AutoGenerateColumns="False" Width="98%" Visible="False" AllowSorting="True" OnSorting="grvKC_WLH_Sorting">
                    <Columns>
                        <asp:BoundField HeaderText="仓库" DataField="CK"  SortExpression="CK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料号" DataField="WLH" SortExpression="WLH"  >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC"  SortExpression="MAX(WLMC)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="货位" DataField="HW"  SortExpression="HW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批次号" DataField="PCH"  SortExpression="PCH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX"  SortExpression="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH"  SortExpression="MAX(PH)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG"  SortExpression="MAX(GG)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="卷数" DataField="SL"  SortExpression="COUNT(Barcode)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="SUMZL" DataFormatString="{0:N3}"  SortExpression="SUM(ZL)" >
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库日期" DataField="RKRQ"  SortExpression="MAX(RQ)" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VFREE1" HeaderText="自由项1" SortExpression="VFREE1" />
                        <asp:BoundField DataField="VFREE2" HeaderText="自由项2" SortExpression="VFREE2" />
                        <asp:BoundField DataField="VFREE3" HeaderText="自由项3" SortExpression="VFREE3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV>
        <table style="width: 800px">
            <tr>
                <td style="height: 18px; width: 60px;" align="right">
                    总计：</td>
                <td style="height: 18px; width: 100px;">
                    <asp:Label ID="lblCount" runat="server" Text="0" Width="100px"></asp:Label></td>
                <td style="height: 18px; width: 60px;" align="right">
                    卷数：</td>
                <td style="width: 3px; height: 18px">
                    <asp:Label ID="lblSL" runat="server" Text="0" Width="100px"></asp:Label></td>
                    <td style="width: 60px; height: 18px" align="right">重量：</td>
                    <td style="width: 63px; height: 18px"><asp:Label ID="lblZL" runat="server" Text="0" Width="100px"></asp:Label></td>
            </tr>
        </table>

			<TABLE class="fixColStyle" id="TABLE1" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<td width="100%">
                        &nbsp; &nbsp;&nbsp;
                        <asp:DropDownList ID="drpVIEW" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpVIEW_SelectedIndexChanged">
                            <asp:ListItem Value="0">按批次显示</asp:ListItem>
                            <asp:ListItem Value="1">按货位显示</asp:ListItem>
                            <asp:ListItem Value="2">按条码显示</asp:ListItem>
                            <asp:ListItem Value="3">按物料显示</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp;
                        <asp:ImageButton
                                        ID="btnPrint" runat="server" ImageUrl="../../Images/icon/PrintExp.gif" OnClick="btnPrint_Click" />
                        &nbsp; &nbsp; &nbsp;&nbsp;
                        <img src="../../Images/icon/storecount.gif" style="cursor:hand" onclick="CountQuery();" /></td>
				</TR>
			</TABLE>
    </div>
    </form>
</body>
</html>
