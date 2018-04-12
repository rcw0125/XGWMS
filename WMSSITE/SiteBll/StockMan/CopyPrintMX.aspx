<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CopyPrintMX.aspx.cs" Inherits="SiteBll_StockMan_CopyPrintMX" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
                             <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
                 <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
          <script language="javascript" src="../../JavaScript/QTCKJS.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%">
                    <Columns>
                                <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                            <img src="../../Images/icon/choose.gif" id="imgPrint" style="cursor:hand;" alt="选择该出库单" onclick="GetChuCk();"/>
                            <input id="hidCKDH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CKDH") %>'/>
                            <input id="hidCK" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CK") %>'/>
                            <input id="hidCPH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CPH") %>'/>
                            <input id="hidCKLX" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CKLX") %>'/>
                            <input id="hidNCDJ" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.NCDJ") %>'/>
                            <input id="hidFYSJ" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.FYSJ") %>'/>
                            <input id="hidAimAdress" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.AimAdress") %>'/>
                            <input id="hidCYS" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CYS") %>'/>
                            <input id="hidSHDW" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.SHDW") %>'/>
                            <input id="hidZDR" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ZDR") %>'/>
                            <input id="hidZDRQ" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ZDRQ") %>'/>
                            <input id="hidSTATUS" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.STATUS") %>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Barcode" HeaderText="单件号" />
                        <asp:BoundField DataField="FYDH" HeaderText="出库单号" />
             
                        <asp:BoundField HeaderText="批次号" DataField="PCH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PH" HeaderText="牌号" />
                        <asp:BoundField DataField="GG" HeaderText="规格">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性" />
                        <asp:BoundField HeaderText="重量" DataField="ZL" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CK" HeaderText="仓库" />
                        <asp:BoundField HeaderText="货位" DataField="HW" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CKRY" HeaderText="出货人员">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GH" HeaderText="钩号">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ProduceData" HeaderText="生产日期">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
    </div>
    </form>
</body>
</html>
