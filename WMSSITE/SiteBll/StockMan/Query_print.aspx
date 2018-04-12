<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Query_print.aspx.cs" Inherits="SiteBll_StockMan_Query_print"  EnableEventValidation="false"%>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>统计打印选择</title>
                     <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
                 <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
          <script language="javascript" src="../../JavaScript/QTCKJS.js" type="text/javascript"></script>
</head>
<body  leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div>
    <table class="fixColStyle" width="100%" cellspacing="1" cellpadding="1" border="2">
      <tr>
        <td style="width: 15%">出库单号</td>
        <td style="width: 15%">
        <asp:TextBox ID="txtCKDH" runat="server" Width="90px" ></asp:TextBox></td>
        <td style="width: 9%">车牌号</td>
        <td style="width: 18%">
        <asp:TextBox ID="txtCPH" runat="server" Width="113px" ></asp:TextBox></td>
        <td style="width: 8%">
            承运商</td>
        <td width="18%">
            <asp:DropDownList ID="drpCYS" runat="server" Width="120px">
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
            <asp:ListItem Value="0">初始</asp:ListItem>
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
              <bestcomy:ComboBox ID="drpNCDJ" runat="server" Width="95%">
              </bestcomy:ComboBox></td>
          <td style="width: 8%">
              收货单位</td>
          <td width="18%">
              <asp:DropDownList ID="drpSHDW" runat="server" Width="122px">
            </asp:DropDownList></td>
      </tr>
      <tr>
        <td style="width: 15%">制单日期</td>
        <td colspan="3"><asp:TextBox ID="txtZDRQ1" runat="server" Width="90px"></asp:TextBox><img onclick="calendar(txtZDRQ1);" src="../../Images/icon/calendar.gif" style="cursor: hand" />
            -<asp:TextBox ID="txtZDRQ2" runat="server" Width="90px"></asp:TextBox><img onclick="calendar(txtZDRQ2);" src="../../Images/icon/calendar.gif" style="cursor: hand" />&nbsp;</td>
        <td style="width: 8%"></td>
        <td width="18%">
            <asp:ImageButton ID="btnQuery" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="btnQuery_Click"/></td>
      </tr>
    </table>
    <table width="100%" cellspacing="1" cellpadding="1" border="2">
  <tr>
    <td style="height: 20px; width: 1004px;" bgColor="#dce8f4">&nbsp;出库单明细</td>
  </tr>
</table>
        <DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:98%;height:180px;overflow:auto;white-space:nowrap;">

                <asp:GridView ID="grvPrintCKDMX" runat="server" AutoGenerateColumns="False" Width="98%">
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                <input id="Checkbox1" type="checkbox" onclick="GetItem();"/>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField>
             
                        <asp:BoundField HeaderText="出库单号" DataField="CKDH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CKLX" HeaderText="出库类型" />
                        <asp:BoundField DataField="NCDJ" HeaderText="NC单据号" />
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
                        <asp:BoundField DataField="CYS" HeaderText="承运商" />
                        <asp:BoundField DataField="FYSJ" HeaderText="发货时间" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV>
        <iframe id="frameItem" runat="server" height="450" src="PrintQTCKItem.aspx" style="height: 200px"
            width="100%"></iframe>
</DIV>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><input id="hidCKDH" runat="server" type="hidden"/>
        <asp:DropDownList ID="drpPrintType" runat="server" Width="100px">
            <asp:ListItem Value="0">其它出库单</asp:ListItem>
            <asp:ListItem Value="1">出库单单件</asp:ListItem>
            <asp:ListItem Value="2">其他出库单汇总</asp:ListItem>
        </asp:DropDownList>
        <asp:ImageButton ID="BtnPrintOK" runat="server" ImageUrl="../../Images/icon/print2.gif" OnClick="BtnPrintOK_Click"/>
        <%--<img id="imgBtnQuery" alt="" src="../../Images/icon/print2.gif"  onclick="PrintOK();" style="cursor:hand;"/>--%>
        <img id="imgcancel" src="../../Images/icon/cancel.gif" onclick="javascript:window.close();"/></td>
  </tr>
</table>
</FORM>
</BODY>
</HTML>
