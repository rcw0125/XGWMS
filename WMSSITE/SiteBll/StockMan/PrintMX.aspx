<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintMX.aspx.cs" Inherits="SiteBll_StockMan_PrintMX"  EnableEventValidation="false"%>

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

                <asp:GridView ID="grvCKDMX" runat="server" AutoGenerateColumns="False" Width="98%">
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
             
                        <asp:BoundField HeaderText="批次号" DataField="PCH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性" />
                        <asp:BoundField DataField="WLH" HeaderText="物料号" />
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH" >
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GG" HeaderText="规格">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JHSL" HeaderText="计划数量">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JHZL" HeaderText="计划重量">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJSL" HeaderText="实际数量">
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SJZL" HeaderText="实际重量" />
                        <asp:BoundField DataField="SLDW" HeaderText="数量单位" />
                        <asp:BoundField DataField="ZLDW" HeaderText="重量单位" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			

                
		
    </form>
</body>
</html>
