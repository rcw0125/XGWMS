<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KCJG.aspx.cs" Inherits="SiteBll_StockMan_KCJG" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>库存结构</title>
            <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/YYLView.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0">
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="库存结构"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        
					</TD>
					<TD align="center" width="10%">
					</TD>
					<TD vAlign="middle" align="center" width="2%">
					</TD>
				</TR>
			</TABLE>   
			<table>
			    <tr>
			        <td>
                        <asp:DropDownList ID="drpType" runat="server" Height="23px" Width="215px" 
                            onselectedindexchanged="drpType_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">锈蚀品信息</asp:ListItem>
                            <asp:ListItem Value="2">库存结构</asp:ListItem>
                            <asp:ListItem Value="3">分属性的线材库存结构</asp:ListItem>
                            <asp:ListItem Value="4">库龄分析</asp:ListItem>
                        </asp:DropDownList>
                    </td>
			    </tr>
			    <tr>
			        <td width="100%">
			            <rsweb:ReportViewer ID="ReportViewer1" runat="server"
                            BorderColor="Silver" ShowFindControls="False" Width="800px" Height="450px" 
                            ShowParameterPrompts="False" ShowZoomControl="False">
                        </rsweb:ReportViewer>
			        </td>
			    </tr>
			</table>
    </div>
    </form>
</body>
</html>
