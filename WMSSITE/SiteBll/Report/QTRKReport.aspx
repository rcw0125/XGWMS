<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QTRKReport.aspx.cs" Inherits="SiteBll_Report_QTRKReport"  EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>其它入库</title>
         <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/QTRKJS.js" type="text/javascript"></script>

</head>
<body leftMargin="0" topMargin="0">
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="其它入库" Visible="False"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%">
                        &nbsp;</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fixColStyle">
  <tr>
    <td height="20"  bgColor="#dce8f4">&nbsp;查询条件</td>
  </tr>
  <tr>
    <td><table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="fixColStyle">
      <tr>
        <td style="height: 20px; width: 10%;" align="right">出库类型 &nbsp;</td>
        <td width="15%" style="height: 20px">
            <asp:DropDownList ID="drpCKType" runat="server" Width="95%">
            </asp:DropDownList></td>
        <td width="10%" style="height: 20px" align="right">单据号&nbsp;
        </td>
        <td width="15%" style="height: 20px">
            <asp:TextBox ID="txtDJuHao" runat="server"></asp:TextBox></td>
        <td width="10%" style="height: 20px" align="right">批次号&nbsp;
        </td>
        <td width="15%" style="height: 20px">
            <asp:TextBox ID="txtPCH" runat="server"></asp:TextBox></td>
        <td width="10%" style="height: 20px" align="right">物料号&nbsp;
        </td>
        <td width="15%" style="height: 20px">
            <asp:TextBox ID="txtWLH" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td style="height: 20px; width: 10%;" align="right">牌号 &nbsp;</td>
        <td width="15%" style="height: 20px">
            <asp:DropDownList ID="drpPH" runat="server" Width="95%">
            </asp:DropDownList></td>
        <td width="10%" style="height: 20px" align="right">规格&nbsp;
        </td>
        <td width="15%" style="height: 20px">
            <asp:DropDownList ID="drpGG" runat="server" Width="95%">
            </asp:DropDownList></td>
        <td width="10%" style="height: 20px" align="right">属性&nbsp;
        </td>
        <td width="15%" style="height: 20px">
            <asp:DropDownList ID="drpSX" runat="server" Width="95%">
                <asp:ListItem Value="0">--请选择--</asp:ListItem>
                <asp:ListItem>合格品</asp:ListItem>
                <asp:ListItem>出口材</asp:ListItem>
                <asp:ListItem>黄牌</asp:ListItem>
                <asp:ListItem>整批协议品</asp:ListItem>
                <asp:ListItem>不合格品</asp:ListItem>
            </asp:DropDownList></td>
        <td width="10%" style="height: 20px" align="right">单卷号&nbsp;
        </td>
        <td width="15%" style="height: 20px">
            <asp:TextBox ID="txtDJuanHao" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td style="height: 20px; width: 10%;">&nbsp;</td>
        <td width="15%" style="height: 20px">&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon/img25.gif" OnClick="ImageButton1_Click" /></td>
        <td width="10%" style="height: 20px">&nbsp;</td>
        <td width="15%" style="height: 20px">&nbsp;</td>
        <td width="10%" style="height: 20px">&nbsp;</td>
        <td width="15%" style="height: 20px">&nbsp;</td>
        <td width="10%" style="height: 20px">&nbsp;</td>
        <td width="15%" style="height: 20px">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
    <uc2:PageControl id="PageControl1" runat="server">
                        </uc2:PageControl>
<DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:99%;height:300px;overflow:auto;white-space:nowrap;">

                <asp:GridView ID="grvQTRK" runat="server" AutoGenerateColumns="False" Width="98%" ShowFooter="True">
                    <Columns>
                          <asp:TemplateField HeaderText="  查看物料">
                            <ItemTemplate>
                                &nbsp;<input id="Checkbox1" type="checkbox" onclick="GetZKDItem();"/>
                                <input id="strCK" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CK") %>'/>
                                <input id="strHW" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.HW") %>'/>
                                 <input id="strZL" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ZL","{0:F3}") %>'/>                            
                             </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="条码" DataField="Barcode" />
                        <asp:BoundField HeaderText="批次号" DataField="PCH" />
                        <asp:BoundField HeaderText="完工单号" DataField="RKDH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库单号" DataField="FYDH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="ZL" DataFormatString="{0:F3}" HtmlEncode="False" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="CK" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="货位" DataField="HW" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料号" DataField="WLH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="标准" DataField="BZ" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="班别" DataField="BB" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="钩号" DataField="GH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出口材序号" DataField="CKCXH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库日期" DataField="RQ" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库类别" DataField="Flag" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="出库人员" DataField="CKRY" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="称重日期" DataField="WeightRQ" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="生产日期" DataField="ProduceData" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV>
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="width: 225px; height: 20px">&nbsp;仓库：<asp:DropDownList ID="drpRKCK" runat="server" Width="103px" AutoPostBack="True" OnSelectedIndexChanged="drpRKCK_SelectedIndexChanged">
        </asp:DropDownList></td>
    <td style="width: 181px; height: 20px">&nbsp;货位：<asp:DropDownList ID="drpRKHW" runat="server" Width="123px">
        </asp:DropDownList></td>
    <td style="height: 20px">&nbsp;</td>
  </tr>
  <tr>
    <td style="width: 225px; height: 20px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td style="width: 162px">&nbsp;&nbsp;重量：<asp:TextBox ID="txtRKZL" runat="server" Width="94px">0</asp:TextBox>吨</td>
    <td><table border="0" cellspacing="0" cellpadding="0" style="width: 21px;">
      <tr>
        <td><img src="../../images/header/up.gif" style="CURSOR: hand" onclick="AddZL();" /></td>
      </tr>
      <tr>
        <td><img src="../../images/header/down.gif" style="CURSOR: hand" onclick="DelZL();" /></td>
      </tr>
    </table></td>
  </tr>
</table></td>
    <td style="width: 181px; height: 20px">&nbsp;</td>
    <td style="height: 20px">&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/icon/ruku.gif" /></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
