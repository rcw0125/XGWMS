<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PICIQuery.aspx.cs" Inherits="SiteBll_StockMan_PICIQuery"  EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>批次管理</title>
           <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
            <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
<script language="javascript">
function AddFull(flag)
{
	if(flag == 1)
	{
		parent.document.body.cols = "*,100%";
	}
	if(flag == 0)
	{
		parent.document.body.cols = "120,*";
	}
}
</script>
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="批次管理"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%">
                        &nbsp;</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE><table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td bgColor="#dce8f4" style="height:23px;">&nbsp;入库记录</td>
  </tr>
  <tr>
    <td><uc2:PageControl id="PageControl1" runat="server">
                        </uc2:PageControl><DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:100%;height:190px;overflow:auto;white-space:nowrap;">

                <asp:GridView ID="grvRKJL" runat="server" AutoGenerateColumns="False" Width="98%">
                    <Columns>
                        <asp:BoundField HeaderText="入库单号" DataField="rkdh" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="CK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批次号" DataField="PCH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料号" DataField="WLH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="卷数" DataField="SL" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="ZL" DataFormatString="{0:N3}" HtmlEncode="False" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle HorizontalAlign="Right" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="货位" DataField="hw" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库日期" DataField="RKTime" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="入库类型" DataField="RKType" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="车牌号" DataField="CPH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VFREE1" HeaderText="自由项1" />
                        <asp:BoundField DataField="VFREE2" HeaderText="自由项2" />
                        <asp:BoundField DataField="VFREE3" HeaderText="自由项3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV></td>
  </tr>
</table>

			<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td bgColor="#dce8f4" style="height:23px;">&nbsp;出库记录</td>
  </tr>
  <tr>
    <td><uc2:PageControl id="PageControl2" runat="server">
                        </uc2:PageControl><DIV id="DIV1" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:100%;height:190px;overflow:auto;white-space:nowrap;">

                <asp:GridView ID="grvCKJL" runat="server" AutoGenerateColumns="False" Width="98%">
                    <Columns>
            
                        <asp:BoundField HeaderText="出库单号" DataField="ckdh" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="CK" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批次号" DataField="PCH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料号" DataField="WLH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="卷数" DataField="SL" >
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="ZL" DataFormatString="{0:N3}" HtmlEncode="False" >
                            <ItemStyle HorizontalAlign="Right" Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库时间" DataField="CKTime" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库类型" DataField="CKType">
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="车牌号" DataField="CPH" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="货位" DataField="HW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="VFREE1" HeaderText="自由项1" />
                        <asp:BoundField DataField="VFREE2" HeaderText="自由项2" />
                        <asp:BoundField DataField="VFREE3" HeaderText="自由项3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV></td>
  </tr>
</table>
        <br />

<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#ADB6D6">
  <tr>
    <td bgColor="#dce8f4" style="height:23px;">&nbsp;查询条件</td>
  </tr>
  <tr>
    <td bgcolor="#FFFFFF" style="height: 60px"><table width="70%" height="30" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td align="right" style="width: 105px">批次号&nbsp;
        </td>
        <td><asp:TextBox ID="txtPCH" runat="server"></asp:TextBox>
            <asp:ImageButton ID="imgBtnQuery" runat="server" ImageUrl="~/Images/icon/chanzhao.gif"
                OnClick="imgBtnQuery_Click"/></td>
      </tr>
    </table></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
