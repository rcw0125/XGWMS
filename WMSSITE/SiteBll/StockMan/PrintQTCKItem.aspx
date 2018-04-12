<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintQTCKItem.aspx.cs" Inherits="SiteBll_StockMan_PrintQTCKItem" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
      <script language="javascript" src="../../JavaScript/QTCKJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
<TABLE cellSpacing=1 cellPadding=1 width="100%" border=2><TBODY><TR><TD style="WIDTH: 1004px; HEIGHT: 20px" bgColor=#dce8f4>
<asp:LinkButton id="QTCKlink" runat="server" OnClick="QTCKlink_Click">其它出库明细</asp:LinkButton> 
| <A onclick="GetDJMX();" href=""><asp:LinkButton id="DJlink" runat="server" OnClick="DJlink_Click">单卷明细</asp:LinkButton></A><input
        id="hidCKDH" runat="server" type="hidden"/></TD></TR><TR><TD style="WIDTH: 1004px">
                    <asp:GridView id="grvQTCKMX" runat="server" Width="98%" AutoGenerateColumns="False">
                    <Columns>
             
                        <asp:BoundField HeaderText="批次号" DataField="PCH" >
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性" ></asp:BoundField>
                        <asp:BoundField DataField="WLH" HeaderText="物料号" ></asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC" >
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH" >
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="GG" HeaderText="规格">
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="JHSL" HeaderText="计划数量">
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="JHZL" HeaderText="计划重量">
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJSL" HeaderText="实际数量">
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJZL" HeaderText="实际重量" ></asp:BoundField>
                        <asp:BoundField DataField="SLDW" HeaderText="数量单位" ></asp:BoundField>
                        <asp:BoundField DataField="ZLDW" HeaderText="重量单位" ></asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle" />
                    <FooterStyle BackColor="White"  />
                </asp:GridView> <asp:GridView id="grvDJMX" runat="server" Width="98%" AutoGenerateColumns="False" Visible="False">
                    <Columns>
     
                        <asp:BoundField DataField="Barcode" HeaderText="单件号" ></asp:BoundField>
                        <asp:BoundField DataField="FYDH" HeaderText="出库单号" ></asp:BoundField>
             
                        <asp:BoundField HeaderText="批次号" DataField="PCH" >
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="PH" HeaderText="牌号" ></asp:BoundField>
                        <asp:BoundField DataField="GG" HeaderText="规格">
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性" ></asp:BoundField>
                        <asp:BoundField HeaderText="重量" DataField="ZL" >
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="CK" HeaderText="仓库" ></asp:BoundField>
                        <asp:BoundField HeaderText="货位" DataField="HW" >
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="CKRY" HeaderText="出货人员">
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="GH" HeaderText="钩号">
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="ProduceData" HeaderText="生产日期">
                            <HeaderStyle Wrap="False"  />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle" />
                    <FooterStyle BackColor="White"  />
                </asp:GridView></TD></TR></TBODY></TABLE>
    </form>
</body>
</html>
