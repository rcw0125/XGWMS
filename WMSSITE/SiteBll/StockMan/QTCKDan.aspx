<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QTCKDan.aspx.cs" Inherits="SiteBll_StockMan_QTCKDan"  EnableEventValidation="false"%>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>其它出库单</title>
    <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/QTCKJS.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div><TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="其它出库单"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%">
                        &nbsp;</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="20" bgColor="#dce8f4">
        &nbsp;出库单</td>
  </tr>
  <tr>
    <td><table width="100%" cellspacing="1" cellpadding="1" border="2">
      <tr>
        <td style="height: 20px">出库单号</td>
        <td style="height: 20px">
            <asp:TextBox ID="txtCKDH" runat="server" ReadOnly="True"></asp:TextBox></td>
        <td style="height: 20px">发货仓库</td>
        <td style="height: 20px">
            <asp:DropDownList ID="drpFHCK" runat="server" Width="123px" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="drpFHCK_SelectedIndexChanged">
            </asp:DropDownList></td>
        <td style="height: 20px">车牌号</td>
        <td style="height: 20px; width: 179px;">
            <asp:TextBox ID="txtCPH" runat="server" ReadOnly="True"></asp:TextBox></td>
        <td style="height: 20px">出库类型</td>
        <td style="height: 20px">
            <bestcomy:ComboBox ID="drpCKLX" runat="server" Width="90%" Enabled="false">
            </bestcomy:ComboBox></td>
      </tr>
      <tr>
        <td style="height: 20px">NC单据</td>
        <td style="height: 20px">
            <asp:TextBox ID="txtNCDJ" runat="server" ReadOnly="True"></asp:TextBox></td>
        <td style="height: 20px">发运日期</td>
        <td style="height: 20px">
            <asp:TextBox ID="txtFYRQ" runat="server" Width="124px" ReadOnly="True"></asp:TextBox><img onclick="calendar(txtFYRQ);" src="../../Images/icon/calendar.gif" style="cursor: hand" /></td>
        <td style="height: 20px">目的地</td>
        <td style="height: 20px; width: 179px;">
            <asp:TextBox ID="txtMDD" runat="server" ReadOnly="True"></asp:TextBox></td>
        <td style="height: 20px">承运商</td>
        <td style="height: 20px">
            <asp:DropDownList ID="drpCYS" runat="server" Enabled="False" Width="120px">
            </asp:DropDownList></td>
      </tr>
      <tr>
        <td style="height: 20px">收货单位</td>
        <td style="height: 20px">
        <bestcomy:ComboBox id="drpSHDW" runat="server" Width="90%" Enabled="false">
            </bestcomy:ComboBox></td>
        <td style="height: 20px">制单人</td>
        <td style="height: 20px">
            <asp:TextBox ID="txtZDR" runat="server" ReadOnly="True"></asp:TextBox></td>
        <td style="height: 20px">制单日期</td>
        <td style="height: 20px; width: 179px;"><asp:TextBox ID="txtZDRQ" runat="server" ReadOnly="True"></asp:TextBox></td>
        <td style="height: 20px">状态</td>
        <td style="height: 20px"><asp:TextBox ID="txtStatus" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
      </tr>
    </table></td>
  </tr>
</table><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="width:11%"><img id="imgBtnQuery" alt="" src="../../Images/icon/img25.gif"  onclick="SelectCKD();" style="cursor:hand;"/></td>
    <td style="width:11%"><asp:ImageButton ID="ImgNewButton" runat="server" ImageUrl="../../Images/icon/newdj.gif" OnClick="ImgNewButton_Click"/></td>
    <td style="width:11%"><asp:ImageButton ID="ImgModifybtn" runat="server" ImageUrl="../../Images/icon/modidj.gif" OnClick="ImgModifybtn_Click" /></td>
    <td style="width:11%"><asp:ImageButton ID="ImgDeleteCKD" runat="server" ImageUrl="../../Images/icon/deldj.gif" OnClick="ImgDeleteCKD_Click" /></td>
    <td style="width:11%"><asp:ImageButton ID="ImgCZDJbtn" runat="server" ImageUrl="../../Images/icon/canceldj.gif" OnClick="ImgCZDJbtn_Click" /></td>
    <td style="width:11%"><asp:ImageButton ID="ImgQXWCbtn" runat="server" ImageUrl="../../Images/icon/cancelwc.gif" OnClick="ImgQXWCbtn_Click" /></td>
    <td style="width:11%"><asp:ImageButton ID="imgSave" runat="server" ImageUrl="../../Images/icon/lsave.gif" OnClick="imgSave_Click" Enabled="False"/></td>
    <td style="width:11%"><asp:ImageButton ID="imgCancel" runat="server"  Enabled="false" ImageUrl="../../Images/icon/cancel.gif" OnClick="imgCancel_Click"/></td>
    <td style="width:11%"><img id="ImgPrintBtn" alt="" src="../../Images/icon/tjdy.gif"  onclick="PrintCKD();" style="cursor:hand;"/>
    <input id="hidZT"  runat="server" type="hidden" /></td>
  </tr>
</table><table width="100%" cellspacing="1" cellpadding="1" border=2>
  <tr>
    <td style="height: 20px; width: 1200px;" bgColor="#dce8f4">&nbsp;出库单明细</td>
  </tr>
  <tr>
  <td style="width: 1200px; height: 154px;">
  <iframe id = "frameItem" src = "QTCKD_item.aspx" width="100%" height="450px" style="height: 200px" runat="server"/>
  </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
