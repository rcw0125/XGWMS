<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YYLQuery.aspx.cs" Inherits="SiteBll_StockMan_YYLQuery"  EnableEventValidation="false"%>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>

<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"  TagPrefix="uc3" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>预约量查询</title>
            <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/YYLView.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" onload="loadallyyl();">
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="预约量查询"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="chazhao1();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">列表配置</label><IMG id="btnconfig" style="CURSOR: hand" onclick="Addconfig();" alt="关闭" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>   
			
			<TABLE id="tablecon"  style="display:none"  cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;列表配置</font></TD>
					<TD bgColor="#dce8f4" height="20" style="width: 88%"></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="2">
                        <asp:CheckBox ID="chkConfigCK" runat="server" Text="仓库" Checked="True" />
                        <asp:CheckBox ID="chkConfigPH" runat="server" Text="牌号" Checked="True" />
                        <asp:CheckBox ID="chkConfigGG" runat="server" Text="规格" Checked="True" />
                        <asp:CheckBox ID="chkConfigSX" runat="server" Text="属性" Checked="True"/>
                        <asp:CheckBox ID="chkConfigWLH" runat="server" Text="物料号" Checked="True"/>
                        <asp:CheckBox ID="chkConfigKCSL" runat="server" Text="库存|卷数" Checked="True"/>
                        <asp:CheckBox ID="chkConfigKCZL" runat="server" Text="库存|重量" Checked="True"/>
                        <asp:CheckBox ID="chkConfigYYSL" runat="server" Text="发运单|单据量|卷数" Checked="True"/>
                        <asp:CheckBox ID="chkConfigYYZL" runat="server" Text="发运单|单据量|重量" Checked="True"/>
                        <asp:CheckBox ID="chkConfigZXSL" runat="server" Text="发运单|已执行量|卷数" Checked="True"/><asp:CheckBox ID="chkConfigZXZL" runat="server" Text="发运单|已执行量|重量" Checked="True"/>
                        <asp:CheckBox ID="chkConfigZKYYSL" runat="server" Text="转库单|单据量|卷数" Checked="True"/>
                        <asp:CheckBox ID="chkConfigZKYYZL" runat="server" Text="转库单|单据量|重量" Checked="True"/>
                        <asp:CheckBox ID="chkConfigZKZXSL" runat="server" Text="转库单|已执行量|数量" Checked="True"/>
                        <asp:CheckBox ID="chkConfigZKZXZL" runat="server" Text="转库单|已执行量|重量" Checked="True"/>
                        <asp:CheckBox ID="chkConfigKYSL" runat="server" Text="可用量|卷数" Checked="True"/>
                        <asp:CheckBox ID="chkConfigKYZL" runat="server" Text="可用量|重量" Checked="True"/><asp:ImageButton ID="btnConfigOK" ImageUrl="../../Images/icon/img20.gif" runat="server"/></TD>
				</TR>
			</TABLE><table	width="100%" border="0" align="center" cellPadding="0" cellSpacing="1" bgcolor="#DEEBF7" id="chazhao" style="DISPLAY: block" runat="server">
  <tr>
    <td style="height:20px; width: 954px;" bgColor="#dce8f4"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></td>
  </tr>
  <tr>
    <td bgcolor="#FFFFFF" style="width: 954px"><table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="2">
      <tr>
        <td width="8%" style="height: 58px"><input name="chkCK" type="checkbox" id="chkCK" runat="server" onclick="GetCK();" />仓库</td>
        <td width="13%" style="height: 58px">
            <asp:DropDownList ID="drpCK" runat="server" Width="90%" Enabled="False"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidCK" runat="server" /></td>
        <td width="8%" style="height: 58px"><input name="chkSX" type="checkbox" runat="server"  id="chkSX" onclick="GetSX();" />属性</td>
        <td style="width:16%; height: 58px;">
            <asp:DropDownList ID="drpSX" runat="server" Width="90%" Enabled="False"> </asp:DropDownList>
      <input name="hidSX" type="hidden" id="hidSX" runat="server" /></td>
        <td width="7%" style="height: 58px"><input name="checkbox" type="checkbox" runat="server"  id="chkPH" onclick="GetPH();" />牌号<input name="hidden" type="hidden" id="hidPH" runat="server" style="width: 5px" /></td>
        <td width="20%" style="height: 58px"><bestcomy:ComboBox ID="drpPH" runat="server" Width="90%">
            </bestcomy:ComboBox> </td>
        <td width="6%" style="height: 58px">
            <input id="chkGG" name="chkGG" runat="server"  onclick="GetGG();" type="checkbox" />规格</td>
        <td style="width:25%; height: 58px;"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><input id="hidGG" runat="server" name="hidden" style="width: 14%" type="hidden"/>
        <asp:DropDownList ID="drpGG" runat="server" Width="90px" Enabled="false">
        </asp:DropDownList></td>
    <td>-</td>
    <td><input id="hidCopyGG" runat="server" name="hidden" style="width: 27%"  type="hidden"/>
        <asp:DropDownList ID="drpCopyGG" runat="server" Width="90px" Enabled="false">
        </asp:DropDownList></td>
  </tr>
</table></td>
      </tr>
    </table>
    <table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td bgcolor="#FFFFFF" style="height: 25px">
        <asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
        &nbsp; &nbsp; &nbsp; &nbsp;<asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click"/></td>
  </tr>
</table></td>
  </tr>
</table>
    </div>
        <cc1:ReportView ID="ReportView1" runat="server" Width="100%" Height="400px"/>
    </form>
</body>
</html>
