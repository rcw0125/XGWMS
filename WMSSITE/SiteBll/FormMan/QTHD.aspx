<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QTHD.aspx.cs" Inherits="SiteBll_FormMan_QTHD" EnableEventValidation="false" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>

<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"
    TagPrefix="uc1" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<%--柴艳亮--%>
    <title>退货单查询</title>
     <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FormTHD.js" type="text/javascript"></script>
</head>
<script type="text/javascript">


</script>
<body leftMargin="0" topMargin="0" onload="Init();">
    <form id="form1" runat="server">
    <div><input id="hidQuery" runat="server" type="hidden" /> <input id="Hidconfig" type="hidden" /><input id="hidItem" type="hidden" />
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="退货单查询" Visible="False" meta:resourcekey="m_labTitleResource1"></asp:literal></font></TD>
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
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="tablecon" style="display:none" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;列表配置</font></TD>
					<TD width="88%" bgColor="#dce8f4" height="20"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">  
                        <uc1:SetDisplayList id="SetDisplayList1" runat="server">
                                    </uc1:SetDisplayList>  
		
					</TD>
				</TR>
			</TABLE>
			
			
<table id="chazhao" style="DISPLAY: block" cellSpacing="0" cellPadding="0"	width="100%" align="center" border="0" runat="server">
  <tr>
    <td><table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="2">
      <tr>
        <td width="10%" height="25"><input name="checkbox" type="checkbox" id="chkCKH" onclick="GetCKH();" />仓库</td>
        <td width="16%"><asp:DropDownList ID="drpCKH" runat="server" Width="88%" Enabled="False" meta:resourcekey="drpCKHResource1"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidCKH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkZDR" onclick="GetZDR();" />制单人</td>
        <td width="16%"><asp:DropDownList ID="drpZDR" runat="server" Width="88%" Enabled="False" meta:resourcekey="drpZDRResource1"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidZDR" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkFYDH" onclick="GetFYDH();" />发运单</td>
        <td width="16%"><bestcomy:ComboBox ID="drpFYDH" runat="server" Width="100%" meta:resourcekey="drpFYDHResource1" ReadOnly="False" SelectedValue="" Text="">
        </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidFYDH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkBM" onclick="GetBM();" />部门</td>
        <td width="16%"><asp:DropDownList ID="drpBM" runat="server" Width="88%" Enabled="False" meta:resourcekey="drpBMResource1"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidBM" runat="server" /></td>
      </tr>
      <tr>
        <td width="10%" height="25"><input name="checkbox" type="checkbox" id="chkTHDH" onclick="GetTHDH();" />退货单</td>
        <td><bestcomy:ComboBox ID="drpTHDH" runat="server" Width="100%" meta:resourcekey="drpTHDHResource1" ReadOnly="False" SelectedValue="" Text="">
        </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidTHDH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkPH" onclick="GetPH();" />牌号</td>
        <td><bestcomy:ComboBox ID="drpPH" runat="server" Width="100%" meta:resourcekey="drpPHResource1" ReadOnly="False" SelectedValue="" Text="">
        </bestcomy:ComboBox>
      <input name="hidYWRY" type="hidden" id="hidPH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkWLH" onclick="GetWLH();" />物料号</td>
        <td><bestcomy:ComboBox ID="drpWLH" runat="server" Width="100%" meta:resourcekey="drpWLHResource1" ReadOnly="False" SelectedValue="" Text="">
        </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidWLH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkGG" onclick="GetGG();" />规格</td>
        <td><bestcomy:ComboBox ID="drpGG" runat="server" Width="100%" meta:resourcekey="drpGGResource1" ReadOnly="False" SelectedValue="" Text="">
        </bestcomy:ComboBox><input name="hidden" type="hidden" id="hidGG" runat="server" /></td>
      </tr>
      <tr>
        <td width="10%" height="25"><input name="chkPH" type="checkbox" id="chkSX" onclick="GetSX();" />属性</td>
        <td><bestcomy:ComboBox ID="drpSX" runat="server" Width="100%" meta:resourcekey="drpSXResource1" ReadOnly="False" SelectedValue="" Text="">
        </bestcomy:ComboBox><input name="hidden" type="hidden" id="hidSX" runat="server" /></td>
        <td width="10%"><input name="chkPH" type="checkbox" id="chkKHH" onclick="GetKHH();" />客户号</td>
        <td><bestcomy:ComboBox ID="drpKHH" runat="server" Width="100%" meta:resourcekey="drpKHHResource1" ReadOnly="False" SelectedValue="" Text="">
            </bestcomy:ComboBox>
            <input name="hidden" type="hidden" id="hidKHH" runat="server" />
            </td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkICKH" onclick="GetICKH();" />IC卡号</td>
        <td><asp:TextBox ID="txtICKH" runat="server" ReadOnly="True" meta:resourcekey="txtICKHResource1"></asp:TextBox>
      <input name="hidden"  id="hidICKH" runat="server" /></td>
        <td width="10%"><input id="chkFree1" runat="server" name="chkFree1" onclick="GetFree1();"
                type="checkbox" />自由项1</td>
        <td>
            <asp:TextBox ID="txtFree1" runat="server" Width="95%"></asp:TextBox></td>
      </tr>
      <tr>
        <td width="10%" height="25"><input name="chkTuiHuoRQ" type="checkbox" runat="server" id="chkTuiHuoRQ" onclick="GetTuiHuo();" />退货日期</td>
        <td colspan="2"><asp:TextBox ID="TuiHuo_Start" runat="server" Width="68px" Enabled="False" meta:resourcekey="TuiHuo_StartResource1"></asp:TextBox>
        <img src="../../Images/icon/calendar.gif" onclick="calendar(TuiHuo_Start);" style="cursor: hand" />至
      <asp:TextBox ID="TuiHuo_End" runat="server" Width="35%" Enabled="False" meta:resourcekey="TuiHuo_EndResource1"></asp:TextBox>
      <img src="../../Images/icon/calendar.gif" onclick="calendar(TuiHuo_End);" style="cursor: hand" />
            <input name="hidTuiHuo" type="hidden" id="hidTuiHuo" runat="server" /></td>
        <td align="center"></td>
        <td>
            <input id="chkFree2" runat="server" name="chkFree2" onclick="GetFree2();" type="checkbox" />自由项2</td><td>
                <asp:TextBox ID="txtFree2" runat="server" Width="95%"></asp:TextBox></td>
        <td>
            <input id="chkFree3" runat="server" name="chkFree3" onclick="GetFree3();" type="checkbox" />自由项3</td><td>
                <asp:TextBox ID="txtFree3" runat="server" Width="95%"></asp:TextBox></td>
      </tr>
    </table><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
  <tr>
      <td style="width: 118px">
      </td>
    <td><asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click" meta:resourcekey="imgBtnQueryResource1"/>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
      
      <asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" meta:resourcekey="imgBtnCancleResource1" /></td>
  </tr>
</table></td>
  </tr>
</table>
        <uc2:pagecontrol id="PageControl2" runat="server"></uc2:pagecontrol>
                        		<DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:100%;height:300px;overflow:auto;white-space:nowrap;">
                <asp:GridView ID="grvTHD" runat="server" AutoGenerateColumns="False" Width="100%" AllowSorting="True" OnSorting="grvTHD_Sorting" OnRowCreated="grvTHD_RowCreated" meta:resourcekey="grvTHDResource1">
                    <Columns>
                        <asp:BoundField HeaderText="仓库" DataField="CK" SortExpression="CK" meta:resourcekey="BoundFieldResource1" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="单卷号" DataField="Barcode" SortExpression="Barcode" meta:resourcekey="BoundFieldResource2" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批次号" DataField="PCH" SortExpression="PCH" meta:resourcekey="BoundFieldResource3" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX" SortExpression="SX" meta:resourcekey="BoundFieldResource4" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料号" DataField="WLH" SortExpression="WLH" meta:resourcekey="BoundFieldResource5" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH" SortExpression="PH" meta:resourcekey="BoundFieldResource6" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG" SortExpression="GG" meta:resourcekey="BoundFieldResource7" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="ZL" DataFormatString="{0:N3}" SortExpression="ZL" meta:resourcekey="BoundFieldResource8" >
                            <ItemStyle Wrap="False" HorizontalAlign="Right" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="退货日期" DataField="CZRQ" SortExpression="CZRQ" meta:resourcekey="BoundFieldResource9" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="退货人员" DataField="CZRY" SortExpression="CZRY" meta:resourcekey="BoundFieldResource10" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库单号" DataField="CKDH" SortExpression="CKDH" meta:resourcekey="BoundFieldResource11" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库日期" DataField="CKRQ" SortExpression="CKRQ" meta:resourcekey="BoundFieldResource12" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库日期" DataField="RKDH" SortExpression="RKDH" meta:resourcekey="BoundFieldResource13" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="客户编码" DataField="KHBM" SortExpression="KHBM" meta:resourcekey="BoundFieldResource14" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="制单人员" DataField="NCZDRQ" SortExpression="NCZDRQ" meta:resourcekey="BoundFieldResource15" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="制单日期" DataField="NCZDRQ" SortExpression="NCZDRQ" meta:resourcekey="BoundFieldResource16" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="所属部门" DataField="NCBM" SortExpression="NCBM" meta:resourcekey="BoundFieldResource17" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="退货单号" DataField="THDH" SortExpression="THDH" meta:resourcekey="BoundFieldResource18" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" SortExpression="vfree1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" SortExpression="vfree2" />
                        <asp:BoundField DataField="vfree1" HeaderText="自由项３" SortExpression="vfree3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                </asp:GridView>
			</DIV>
    </div>
		<TABLE class="fixColStyle" id="TABLE2" style="DISPLAY: block; left: 0px; top: 0px;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<td width="100%" style="height: 22px"> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
					<asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../../Images/icon/PrintExp.gif" OnClick="btnPrint_Click" meta:resourcekey="btnPrintResource1"/>
                       </td>
				</TR>
			</TABLE>

    </form>

</body>
</html>
