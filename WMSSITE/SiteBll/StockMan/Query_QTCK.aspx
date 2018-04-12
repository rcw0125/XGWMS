<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Query_QTCK.aspx.cs" Inherits="SiteBll_StockMan_Query_QTCK" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择其它出库单</title>
                 <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
                 <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
          <script language="javascript" src="../../JavaScript/QTCKJS.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div><table class="fixColStyle" width="100%" cellspacing="1" cellpadding="1" border="2">
      <tr>
        <td style="width: 15%">出库单号</td>
        <td style="width: 15%">
        <asp:TextBox ID="txtCKDH" runat="server" Width="90px" ></asp:TextBox></td>
        <td style="width: 9%">车牌号</td>
        <td style="width: 18%">
        <asp:TextBox ID="txtCPH" runat="server" Width="113px" ></asp:TextBox></td>
        <td style="width: 8%">目的地</td>
        <td width="18%">
            <asp:DropDownList ID="drpMDD" runat="server" Width="99%">
            </asp:DropDownList></td>
      </tr>
      <tr>
        <td style="width: 15%">仓库</td>
        <td style="width: 15%">
            <asp:DropDownList ID="drpCK" runat="server" Width="87px">
        </asp:DropDownList></td>
        <td style="width: 9%">状态</td>
        <td style="width: 18%"><asp:DropDownList ID="drpStatus" runat="server" Width="119px">
            <asp:ListItem>请选择</asp:ListItem>
            <asp:ListItem Value="0">新建</asp:ListItem>
            <asp:ListItem Value="1">正在执行</asp:ListItem>
            <asp:ListItem Value="2">完成</asp:ListItem>
        </asp:DropDownList></td>
        <td style="width: 8%">制单人</td>
        <td width="18%"><asp:DropDownList ID="drpZDR" runat="server" Width="99%">
        </asp:DropDownList></td>
      </tr>
      <tr>
          <td style="width: 15%"> 出库类型</td>
          <td style="width: 15%"><asp:DropDownList ID="drpCKLX" runat="server" Width="87px"></asp:DropDownList></td>
          <td style="width: 9%">NC单据</td>
          <td style="width: 18%">
              <asp:DropDownList ID="drpNCDJ" runat="server" Width="120px">
              </asp:DropDownList></td>
          <td style="width: 8%">批次号</td>
          <td width="18%">
              <asp:DropDownList ID="drpPCH" runat="server" Width="99%">
              </asp:DropDownList></td>
      </tr>
      <tr>
        <td style="width: 15%"><input id="chkZDRQ" type="checkbox" onclick="GetZDRQ();"/>制单日期</td>
        <td colspan="3"><asp:TextBox ID="txtZDRQ1" runat="server" Width="90px" Enabled="False"></asp:TextBox><img onclick="calendar(txtZDRQ1);" src="../../Images/icon/calendar.gif" style="cursor: hand" />
            -<asp:TextBox ID="txtZDRQ2" runat="server" Width="90px" Enabled="False"></asp:TextBox><img onclick="calendar(txtZDRQ2);" src="../../Images/icon/calendar.gif" style="cursor: hand" />&nbsp;<input
                id="hidZDRQ" type="hidden" runat="server"/></td>
        <td style="width: 8%"></td>
        <td width="18%">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="ImageButton1_Click" />
            <img src="../../Images/icon/imgCancle1.gif"  onclick="javascript:window.close();" style="cursor:hand;"/></td>
      </tr>
    </table>
 <table width="100%" cellspacing="1" cellpadding="1" border="2">
  <tr>
    <td style="height: 20px" bgColor="#dce8f4">&nbsp;出库单明细</td>
  </tr>
  <tr>
    <td style="height: 255px"><DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:98%;height:240px;overflow:auto;white-space:nowrap;">

                <asp:GridView ID="grvCKDMX" runat="server" AutoGenerateColumns="False" Width="98%">
                    <Columns>
                                <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                            <img src="../../Images/icon/choose.gif" id="imgPrint" style="cursor:hand;" alt="选择该出库单" onclick="GetChuCk();"/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="出库单号" DataField="CKDH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="CK" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="车牌号" DataField="CPH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AimAdress" HeaderText="目的地">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZDR" HeaderText="制单人">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZDRQ" HeaderText="制单日期">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STATUS" HeaderText="状态">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
