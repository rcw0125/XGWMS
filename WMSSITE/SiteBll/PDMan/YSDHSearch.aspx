<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YSDHSearch.aspx.cs" Inherits="SiteBll_PDMan_YSDHSearch" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>查找原始单号</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/PDMan.js" type="text/javascript"></script>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <table class="fixColStyle" id="tblQuery" runat="server" style="width: 388px">
        <tr>
            <td style="text-align: center; width: 110px;">
                原始单号</td>
            <td style="text-align: center; width: 143px;">
                <asp:TextBox ID="txtYSDH" runat="server"></asp:TextBox></td>
            <td style="width: 69px; text-align: center;">
                仓库</td>
            <td style="text-align: center;">
                <asp:DropDownList ID="drpCK" runat="server" Width="120px">
                </asp:DropDownList></td>
        </tr>
        <tr>
        <td style="text-align: center; width: 110px;">
            盘点日期</td>
        <td style="text-align: center; width: 143px;">
            <asp:TextBox ID="PDRQStart" runat="server" Width="100px"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(PDRQStart);" style="cursor: hand" /></td>
        <td style="width: 69px; text-align: center">
            --至--</td>
        <td style="text-align: center">
            <asp:TextBox ID="PDRQEnd" runat="server" Width="100px"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(PDRQEnd);" style="cursor: hand" /></td>
        </tr>
        <tr>
            <td style="text-align: center; width: 110px;">
                <input id="hidState" runat="server" type="hidden" style="width: 33px"/></td>
            <td style="text-align: center; width: 143px;">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click" /></td>
            <td style="text-align: center; width: 69px;">
                <img src="../../Images/icon/img22.gif" onclick="window.close();" style="cursor:hand;"/></td>
            <td style="text-align: center;" width="17">
                <input id="hidDJLX" runat="server" style="width: 17px" type="hidden" />
                <input id="hidPDDH" runat="server" type="hidden" style="width: 33px"/></td>
        </tr>
    </table>
    <div style="width:386px; overflow:auto; height: 320px;">
    <asp:GridView ID="grvYSDHList" runat="server" AutoGenerateColumns="False" Width="362px" AllowPaging="True" OnPageIndexChanging="grvYSDHList_PageIndexChanging"> 
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                               <img src="../../Images/icon/choose.gif" id="imgPrint" style="cursor:hand;" alt="选择该客户信息" onclick="GetYSDH();"/>
                                <input id="hidCKName" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CKName") %>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="YSDH" HeaderText="单据号" />
                        <asp:BoundField DataField="CK" HeaderText="仓库" />
                        <asp:BoundField DataField="PDRQ" HeaderText="盘点日期" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
             </asp:GridView>
    </div>
    </form>
</body>
</html>
