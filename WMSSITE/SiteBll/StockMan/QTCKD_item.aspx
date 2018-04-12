<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QTCKD_item.aspx.cs"  Inherits="SiteBll_StockMan_QTCKD_item" EnableEventValidation="false"%>

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
<body leftMargin="0" topMargin="0" onload="loadAll()">
    <form id="form1" runat="server">
    <DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:100%;height:150px;overflow:auto;white-space:nowrap;">
                <asp:GridView ID="grvCKZB" runat="server" AutoGenerateColumns="False" Width="98%" OnRowDataBound="grvCKZB_RowDataBound" OnRowCommand="grvCKZB_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemStyle Width="40px" />
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                        <asp:ImageButton ID="imgBtnModify" runat="server" ImageUrl="../../Images/icon/imgChange1.gif" CommandName="imgBtnModify"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="选择">
                            <ItemStyle Width="40px" />
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                            <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="../../Images/icon/img19.gif" CommandName="imgBtnDelete"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="批次号" DataField="PCH" />
                        <asp:BoundField HeaderText="属性" DataField="SX" />
                        <asp:BoundField DataField="WLH" HeaderText="物料号" />
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC" />
                        <asp:BoundField HeaderText="牌号" DataField="PH" />
                        <asp:BoundField HeaderText="规格" DataField="GG" />
                        <asp:BoundField HeaderText="计划数量" DataField="JHSL" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="计划重量" DataField="JHZL" DataFormatString="{0:N3}" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="实际数量" DataField="SJSL" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="实际重量" DataField="SJZL" >
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="数量单位" DataField="SLDW" />
                        <asp:BoundField DataField="ZLDW" HeaderText="重量单位" />
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4"  CssClass="fixHeaderStyle"/>
                    <FooterStyle BackColor="White" />
                </asp:GridView>
                </DIV>
        <table width="60%">
            <tr>
                <td>
                    &nbsp;<Img src="../../Images/icon/add.gif" ID="imgAddMX" onclick="AddItem()" style="cursor: hand"/>
                    <input id="hidRowIndex" runat="server"  type="hidden" />
                    <input id="hidMXZT" runat="server"  type="hidden" /></td>
            </tr>
        </table>
        <table id="tableMX" width="95%" style="display:none; text-align:right" runat="server">
            <tr>
                <td style="width: 8%">
                    批次号</td>
                <td style="width: 12%">
                    <%--<asp:DropDownList ID="drpPCH" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="drpPCH_SelectedIndexChanged"></asp:DropDownList>--%>
                    <asp:TextBox ID="txtPCH" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtPCH_TextChanged"></asp:TextBox>
                </td>
                <td style="width: 8%">
                    属性</td>
                <td style="width: 12%">
                    <asp:DropDownList ID="drpSX" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="drpSX_SelectedIndexChanged"></asp:DropDownList></td>
                    <td style="width: 8%">物料号</td>
                    <td style="width: 12%">
                        <asp:TextBox ID="txtWLH" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 8%">物料名称</td>
                    <td style="width: 12%"><asp:TextBox ID="txtWLMC" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 8%">牌号</td>
                    <td style="width: 12%"><asp:TextBox ID="txtPH" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 8%">
                    规格</td>
                <td style="width: 12%">
                    <asp:TextBox ID="txtGG" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
                <td style="width: 8%">
                    数量单位</td>
                <td style="width: 12%">
                    <asp:TextBox ID="txtSLDW" runat="server" Width="100%" ReadOnly="True">件【线材】</asp:TextBox></td>
                <td style="width: 8%">
                    重量单位</td>
                <td style="width: 12%">
                    <asp:TextBox ID="txtZLDW" runat="server" Width="100%" ReadOnly="True">吨</asp:TextBox></td>
                <td style="width: 8%">
                    计划数量</td>
                <td style="width: 12%">
                    <asp:TextBox ID="txtJHSL" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width: 8%">
                    计划重量</td>
                <td style="width: 12%">
                    <asp:TextBox ID="txtJHZL" runat="server" Width="100%"></asp:TextBox></td>
            </tr>           
            <tr>
                <td style="width: 8%">
                    自由项1</td>
                <td style="width: 12%">
                    <asp:DropDownList ID="drpFree1" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="drpSX_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="width: 8%">
                    自由项2</td>
                <td style="width: 12%">
                    <asp:DropDownList ID="drpFree2" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="drpSX_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="width: 8%">
                    自由项3</td>
                <td style="width: 12%">
                    <asp:DropDownList ID="drpFree3" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="drpSX_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td style="width: 8%">
                </td>
                <td style="width: 12%">
                </td>
                <td style="width: 8%">
                </td>
                <td style="width: 12%">
                </td>
            </tr>
            <tr>
                <td style="width: 8%">
                    <asp:ImageButton ID="btnItemOK" runat="server" ImageUrl="../../Images/icon/img20.gif" OnClick="btnItemOK_Click1"/></td>
                <td>
                    <img onclick="cancelMX()" src="../../Images/icon/imgCancle1.gif" style="cursor: hand" id="IMG1" /></td>
                <td><input id="hidCKDH" runat="server"  type="hidden" />
                    </td>
                    <td><input id="hidCK" runat="server"  type="hidden" /></td>
                    <td></td>
                    <td><input id="hidZT" runat="server" type="hidden" /></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
            </tr>
        </table>
    </form>
</body>
</html>