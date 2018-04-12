<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDDHSearch.aspx.cs" Inherits="SiteBll_PDMan_PDDHSearch" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>查找盘点单号</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/PDMan.js" type="text/javascript"></script>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <table class="fixColStyle" id="tblQuery" runat="server" style="width: 388px">
        <tr>
            <td style="text-align: center; width: 20%;">
                原始单号</td>
            <td style="text-align: center; width: 30%;">
                <asp:TextBox ID="txtYSDH" runat="server"></asp:TextBox></td>
            <td style="text-align: center; width: 20%;">
                盘点单号</td>
            <td style="text-align: center; width: 30%;">
                <asp:TextBox ID="txtPDDH" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td style="text-align: center">
            仓库</td>
        <td style="text-align: center">
                <asp:DropDownList ID="drpCK" runat="server" Width="120px">
                </asp:DropDownList></td>
        <td style="text-align: center">
            制单人</td>
        <td style="text-align: center">
            <asp:TextBox ID="txtZDUser" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: center">
            盘点日期</td>
            <td style="text-align: center">
            <asp:TextBox ID="PDRQStart" runat="server" Width="100px"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(PDRQStart);" style="cursor: hand" /></td>
            <td style="text-align: center">
            --至--</td>
            <td style="text-align: center;">
            <asp:TextBox ID="PDRQEnd" runat="server" Width="100px"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(PDRQEnd);" style="cursor: hand" /></td>
        </tr>
        <tr>
        <td style="text-align: center">
            <input id="hidState" runat="server" type="hidden" style="width: 21px" /></td>
        <td style="text-align: center">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click" /></td>
        <td style="text-align: center">
                <img src="../../Images/icon/img22.gif" onclick="window.close();" style="cursor:hand;"/></td>
                <td style="text-align: center">
                    <input id="hidDJLX" style="width: 27px" runat="server" type="hidden" /></td>
        </tr>
    </table>
    <div style="width:386px; overflow:auto; height: 450px;">
    <asp:GridView ID="grvPDDHList" runat="server" AutoGenerateColumns="False" Width="363px" AllowPaging="True" OnPageIndexChanging="grvPDDHList_PageIndexChanging"> 
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                               <img src="../../Images/icon/choose.gif" id="imgPrint" style="cursor:hand;" alt="选择该客户信息" onclick="GetPDDH();"/>
                                <input id="hidCKName" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CKName") %>'/>
                                <input id="hidZDRQ" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ZDRQ") %>'/>
                                <input id="hidSHUser" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.SHUser") %>'/>
                                <input id="hidSHRQ" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.SHRQ") %>'/>
                                <input id="hidDJZT" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.DJZT") %>'/>
                                <input id="hidDJLX" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.DJLX") %>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="YSDH" HeaderText="原始单号" />
                        <asp:BoundField DataField="PDDH" HeaderText="盘点单号" />
                        <asp:BoundField DataField="CK" HeaderText="仓库" />
                        <asp:BoundField DataField="PDRQ" HeaderText="盘点日期" />
                        <asp:BoundField DataField="ZDUser" HeaderText="制单人" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
             </asp:GridView>
    </div>
    </form>
</body>
</html>
