<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QDPP.aspx.cs" Inherits="SiteBll_FormMan_QDPP"  EnableEventValidation="false"%>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>待判品查询</title>
         <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FormDPP.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" onload="loadallDPP();">
    <form id="form1" runat="server">
    <div>
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="待判品查询" ></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%">
                        &nbsp;</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
					
    <table id="chazhao" style="DISPLAY: block" cellSpacing="0" cellPadding="0"	width="100%" align="center" border="0" runat="server">
  <tr>
    <td><table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="2">
      <tr>
        <td width="8%" height="25"><input name="checkbox" type="checkbox" id="chkCKH" onclick="GetCKH();"  runat="server" />仓库</td>
        <td width="15%"><asp:DropDownList ID="drpCKH" runat="server" Width="87%" Enabled="False"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidCKH" runat="server" /></td>
        <td width="8%"><input name="checkbox" type="checkbox" id="chkWLH" onclick="GetWLH();"  runat="server" />物料号</td>
        <td width="16%"><bestcomy:ComboBox ID="drpWLH" runat="server" Width="100%">
            </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidWLH" runat="server" /></td>
        <td width="8%"><input name="checkbox" type="checkbox" id="chkHW" onclick="GetHW();"  runat="server" />货位</td>
        <td style="width: 16%">
            <asp:TextBox ID="txtHW" runat="server"></asp:TextBox>
      <input name="hidden" type="hidden" id="hidHW" runat="server" /></td>
        <td width="8%"><input name="checkbox" type="checkbox" id="chkPCH" onclick="GetPCH();"  runat="server" />批次</td>
        <td width="20%"><bestcomy:ComboBox ID="drpPCH" runat="server" Width="100%">
            </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidPCH" runat="server" /></td>
      </tr>
      <tr>
        <td width="8%" height="25"><input name="chkSX" type="checkbox" id="chkSX" onclick="GetSX();"  runat="server" />属性</td>
        <td width="15%">
            <asp:DropDownList ID="drpSX" runat="server" Width="95%"></asp:DropDownList>
<%--        <bestcomy:ComboBox ID="drpSX" runat="server" Width="100%">
        </bestcomy:ComboBox>--%>
            <input name="hidden" type="hidden" id="hidSX" runat="server" /></td>
        <td width="8%"><input name="chkPH" type="checkbox" id="chkPH" onclick="GetPH();"  runat="server" />牌号</td>
        <td><bestcomy:ComboBox ID="drpPH" runat="server" Width="100%">
            </bestcomy:ComboBox>
            <input name="hidPH" type="hidden" id="hidPH" runat="server" /></td>
        <td width="8%"><input name="checkbox2" type="checkbox" id="chkGG" onclick="GetGG();"  runat="server" />规格</td>
        <td style="width: 162px"><asp:DropDownList ID="drpGG" runat="server" Width="46%" Enabled="False"> </asp:DropDownList>-<asp:DropDownList ID="drpCopyGG" runat="server" Width="46%" Enabled="False"> </asp:DropDownList>
        <input name="hidden" type="hidden" id="hidGG" style="width: 36%" runat="server"/>
        <input name="hidden" type="hidden" id="hidCopyGG" style="width: 41%" runat="server"/></td>
        <td width="10%"><input name="chkPH" type="checkbox" id="chkTSXX" onclick="GetTSXX();"  runat="server" />特殊信息</td>
        <td width="20%"><bestcomy:ComboBox ID="drpTSXX" runat="server" Width="100%">
        </bestcomy:ComboBox>
            <input name="hidden" type="hidden" id="hidTSXX" runat="server" /></td>
      </tr>
        <tr>
            <td height="25" width="9%">
                <input id="chkFree1" runat="server" name="chkFree1" onclick="GetFree1();" type="checkbox" />自由项1</td>
            <td >
                <asp:TextBox ID="txtFree1" runat="server" Width="95%"></asp:TextBox></td>
            <td>
                <input id="chkFree2" runat="server" name="chkFree2" onclick="GetFree2();" type="checkbox" />自由项2</td>
            <td align="center">
                <asp:TextBox ID="txtFree2" runat="server" Width="95%"></asp:TextBox></td>
            <td>
                <input id="chkFree3" runat="server" name="chkFree3" onclick="GetFree3();" type="checkbox" />自由项3</td>
            <td>
                <asp:TextBox ID="txtFree3" runat="server" Width="95%"></asp:TextBox></td>
            <td colspan="2">
            <input name="chkWGP" type="checkbox" id="chkWGP" onclick="GetWGP();"  checked="checked"  runat="server" />未改判<input name="hidWGP" type="hidden" id="hidWGP" runat="server"/></td>
        </tr>
      <tr>
        <td width="9%" height="25"><input name="chkSX" type="checkbox" id="chkRKRQ" onclick="GetRKRQ();"  runat="server" />入库日期</td>
        <td colspan="2"><asp:TextBox ID="RuKu_Start" runat="server" Width="68px" Enabled="false"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(RuKu_Start);" style="cursor: hand" />至
      <asp:TextBox ID="RuKu_End" runat="server" Width="35%" Enabled="false"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(RuKu_End);" style="cursor: hand" />
            <input name="hidRKRQ" type="hidden" id="hidRKRQ" runat="server"/></td>
        <td align="center"></td>
        <td colspan="2"></td>
        <td colspan="2">&nbsp;</td>
      </tr>
    </table><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp;
        <asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
      
      <asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" /></td>
  </tr>
</table></td>
  </tr>
</table><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>
        <uc1:PageControl ID="PageControl1" runat="server" />
    </td>
  </tr>
  <tr>
    <td style="height:337px;" align="center"><DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:100%;height:350px;overflow:auto;white-space:nowrap;">

                <asp:GridView ID="grvDPP" runat="server" AutoGenerateColumns="False" Width="98%" AllowSorting="True" OnSorting="grvDPP_Sorting" OnRowCreated="grvDPP_RowCreated">
                    
                    <Columns>
                        <asp:BoundField DataField="CK" HeaderText="仓库" SortExpression="CK" />
                        <asp:BoundField DataField="HW" HeaderText="货位" SortExpression="HW" />
                        <asp:BoundField HeaderText="物料" DataField="wlh" SortExpression="wlh" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名" DataField="wlmc" SortExpression="wlmc" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批次" DataField="pch" SortExpression="ph" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="ph" SortExpression="ph" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="gg" SortExpression="gg" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="sx" SortExpression="sx" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="卷数" DataField="sl" SortExpression="sl" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="zl" SortExpression="zl" >
                            <HeaderStyle Wrap="False" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WeightRQ" HeaderText="称重日期" SortExpression="MAX(WeightRQ)" />
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" SortExpression="vfree1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" SortExpression="vfree2" />
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" SortExpression="vfree3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV></td>
  </tr><tr>
  <td style="height: 30px">
      <table><tr><td style="width: 305px; height: 20px;">总计：<asp:Label ID="lblSum" runat="server" Text="0"></asp:Label></td><td style="width: 125px; height: 20px;">
          卷数：
          <asp:Label ID="lblSL" runat="server" Text="0"></asp:Label></td><td style="width: 224px; height: 20px">
          重量：<asp:Label ID="lblZL" runat="server">0</asp:Label></td></tr></table></td>
  </tr>
  <tr>
  <td style="height: 30px">&nbsp; &nbsp; &nbsp;&nbsp;<asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../../Images/icon/PrintExp.gif"
                    OnClick="btnPrint_Click" />
  </td>
  </tr>
</table>
			
			
   		    
    </div>
    </form>

</body>
</html>
