<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CKZBView.aspx.cs" Inherits="SiteBll_StockMan_CKZBView"  EnableEventValidation="false"%>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>

<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"  TagPrefix="uc3" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>出库帐簿</title>
          <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
            <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CKZBView.js" type="text/javascript"></script>
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

/*页面初始化查询*/
function Init()
{
	var chazhao = document.getElementById("chazhao");
	var hidQuery = document.getElementById("hidQuery");
	
    var tablecon = document.getElementById("tablecon");
    var Hidconfig = document.getElementById("Hidconfig");
    
    var tblPList= document.getElementById("tblPList");
	var hidItem = document.getElementById("hidItem");
/*	window.alert(HidBase.value); 调试用的*/
	if(hidQuery.value!="")
	{
		chazhao.style.display = "none";
		if( hidQuery.value== "none")
			chazhao.style.display = "block";
		chazhao1();
	}
	if(Hidconfig.value!="")
	{
		tablecon.style.display = "none";
		if( Hidconfig.value== "none")
			tablecon.style.display = "block";
		Addconfig();
	}
	load_Allckzb();
}


</script>
</head>
<body leftMargin="0" topMargin="0" onload="Init();">
    <form id="form1" runat="server">
    <div>
    <input id="hidQuery" runat="server" type="hidden" /> <input id="Hidconfig" type="hidden" /><input id="hidItem" type="hidden" />
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="出库帐簿"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件 </span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="chazhao1();" alt="展开" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">列表配置</label><IMG id="btnconfig" style="CURSOR: hand" onclick="Addconfig();" alt="关闭" src="../../images/icon/expand.gif"
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
			</TABLE><table id="chazhao" style="DISPLAY: block" cellSpacing="0" cellPadding="0"	width="100%" align="center" border="0" runat="server">
  <tr>
    <td style="height:20px;" bgColor="#dce8f4"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">查询条件</font></td>
  </tr>
  <tr>
    <td><table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="2">
      <tr>
        <td width="10%" height="25"><input name="chkCK" type="checkbox" id="chkCK" onclick="GetCK();" runat="server" />发运仓库</td>
        <td width="16%">
            <asp:DropDownList ID="drpCK" runat="server" Width="90%" Enabled="False"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidCK" runat="server" /></td>
        <td width="10%"><input name="chkRKSX" type="checkbox" id="chkRKSX" onclick="GetRKSX();" runat="server" />属性</td>
        <td width="16%">
            <asp:DropDownList ID="drpRKSX" runat="server" Width="80%" Enabled="false">
            </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidRKSX" runat="server" /></td>
        <td width="9%"><input name="checkbox" type="checkbox" id="chkRKDH" onclick="GetRKDH();" runat="server" />出库单号</td>
        <td width="16%"> 
            <asp:TextBox ID="txtCKDH" runat="server"></asp:TextBox>
            <input name="hidden" type="hidden" id="hidRKDH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkRKPH" onclick="GetRKPH();" runat="server" />牌号</td>
        <td style="width: 127px"> <bestcomy:ComboBox ID="drpRKPH" runat="server" Width="100%">
            </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidRKPH" runat="server" /></td>
      </tr>
      <tr>
        <td width="10%" height="25"><input name="checkbox" type="checkbox" id="chkRKPCH" onclick="GetRKPCH();" runat="server" />批次</td>
        <td>   
            <asp:TextBox ID="txtPCH" runat="server"></asp:TextBox>
            <input name="hidden" type="hidden" id="hidRKPCH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkRKGG" onclick="GetRKGG();" runat="server" />规格</td>
        <td> <bestcomy:ComboBox ID="drpRKGG" runat="server" Width="80%">
            </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidRKGG" runat="server" /></td>
        <td width="9%"><input name="checkbox" type="checkbox" id="chkWLH" onclick="GetWLH();" runat="server" />物料</td>
        <td>  <bestcomy:ComboBox ID="drpWLH" runat="server" Width="80%">
            </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidWLH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkCPH" onclick="GetCPH();" runat="server" />车牌号码</td>
        <td style="width: 127px">
            <asp:TextBox ID="txtCPH" runat="server"></asp:TextBox>
      <input name="hidden" type="hidden" id="hidCPH" runat="server" /></td>
      </tr>
        <tr>
            <td height="25" width="10%">
                <input name="checkbox" type="checkbox" id="chkFree1" onclick="GetFree1();" runat="server" />自由项1</td>
            <td>
                <asp:TextBox ID="txtFree1" runat="server"></asp:TextBox>
                <input name="hidden" type="hidden" id="hidFree1" runat="server" /></td>
            <td width="10%">
                <input name="checkbox" type="checkbox" id="chkFree2" onclick="GetFree2();" runat="server" />自由项2</td>
            <td>
                <asp:TextBox ID="txtFree2" runat="server"></asp:TextBox>
                <input name="hidden" type="hidden" id="hidFree2" runat="server" /></td>
            <td width="9%">
                <input name="checkbox" type="checkbox" id="chkFree3" onclick="GetFree3();" runat="server" />自由项3</td>
            <td>
                <asp:TextBox ID="txtFree3" runat="server"></asp:TextBox>
                <input name="hidden" type="hidden" id="hidFree3" runat="server" /></td>
            <td width="10%">
            </td>
            <td style="width: 127px">
            </td>
        </tr>
      <tr>
        <td width="10%" height="25"><input name="checkbox" type="checkbox" id="chkRKType" onclick="GetRKType();" runat="server" />出库类型</td>
        <td>      <asp:DropDownList ID="drpRKType" runat="server" Width="90%" Enabled="False"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidRKType" runat="server" /></td>
        <td width="10%"><input name="chkRKRQ" type="checkbox" id="chkRKRQ" runat="server" onclick="GetRKRQ();" />出库日期</td>
        <td colspan="2"><asp:TextBox ID="RKRQ_Start" runat="server" Width="68px" Enabled="false"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(RKRQ_Start);" style="cursor: hand" />至
      <asp:TextBox ID="RKRQ_End" runat="server" Width="35%" Enabled="false"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(RKRQ_End);" style="cursor: hand" /><input name="hidRKRQ" type="hidden" id="hidRKRQ" runat="server"/></td>
        <td>      &nbsp;</td>
        <td width="10%"></td>
        <td style="width: 127px">
            &nbsp;</td>
      </tr>
    </table><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
        &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" /></td>
  </tr>
</table></td>
  </tr>
</table><uc2:PageControl id="PageControl1" runat="server">
                        </uc2:PageControl>
<DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:100%;height:300px;overflow:auto;white-space:nowrap;">

                <asp:GridView ID="grvCKZB" runat="server" AutoGenerateColumns="False" Width="98%" AllowSorting="True" OnSorting="grvCKZB_Sorting" OnRowCreated="grvCKZB_RowCreated">
                    <Columns>
             
                        <asp:BoundField HeaderText="出库单号" DataField="CKDH" SortExpression="CKDH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="CK" SortExpression="CK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="车牌号" DataField="CPH" SortExpression="CPH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批次号" DataField="PCH" SortExpression="PCH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX" SortExpression="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLH" HeaderText="物料号" SortExpression="WLH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH" SortExpression="PH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG" SortExpression="GG" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="卷数" DataField="SL" SortExpression="SL" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="ZL" DataFormatString="{0:N3}" HtmlEncode="False" SortExpression="ZL" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库日期" DataField="CKTime" SortExpression="CKTime" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库类型" DataField="CKType" SortExpression="CKType" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HW" HeaderText="货位" SortExpression="HW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC" SortExpression="WLMC" >
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
			<table width="100%" align="center" border="0" height="25px">
				<tr><td style="height: 16px">
                    &nbsp; &nbsp;总计：<asp:Label ID="lblSUM" runat="server" Text="0"></asp:Label></td><td style="height: 16px">卷数：<asp:Label ID="lblSL" runat="server" Text="0"></asp:Label></td><td style="height: 16px">重量：<asp:Label ID="lblZL" runat="server" Text="0"></asp:Label></td><td style="height: 16px"></td>
				</tr>
			</table>
				<TABLE class="fixColStyle" id="TABLE1" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<td width="100%" style="height: 22px"><asp:ImageButton
                                        ID="btnPrint" runat="server" ImageUrl="../../Images/icon/PrintExp.gif" OnClick="btnPrint_Click" /><%--<asp:ImageButton ID="imgBtnExcel" runat="server" ImageUrl="../../Images/icon/img16.gif" OnClick="imgBtnExcel_Click"/>--%></td>
				</TR>
			</TABLE>
    </div>
    </form>
</body>
</html>
