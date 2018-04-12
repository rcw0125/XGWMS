<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KHSlc.aspx.cs" Inherits="SiteBll_ICMan_KHSlc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>查找客户</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/ICMan.js" type="text/javascript"></script>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <table class="fixColStyle" id="tblQuery" runat="server" style="width: 388px">
        <tr>
            <td style="height: 7px; width: 65px;">
                客户编码：</td>
            <td style="height: 7px; width: 71px;">
                <asp:TextBox ID="txtKHBM" runat="server"></asp:TextBox></td>
            <td style="height: 7px">
                客户名称：</td>
            <td style="height: 7px">
                <asp:TextBox ID="txtKHMC" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 16px; width: 65px;">
            </td>
            <td style="height: 16px; text-align: center; width: 71px;">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click" /></td>
            <td style="height: 16px; text-align: center;" width="8%">
                <img src="../../Images/icon/img22.gif" onclick="window.close();" style="CURSOR: hand"/></td>
            <td style="height: 16px" width="17">
            </td>
        </tr>
    </table>
    <div style="width:386px; overflow:auto; height: 340px;">
    <asp:GridView ID="grvKHList" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="grvKHList_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                               <img src="../../Images/icon/choose.gif" id="imgPrint" style="cursor:hand;" alt="选择该客户信息" onclick="GetKHInfo()"/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="KHID" HeaderText="客户编码" >
                            <ItemStyle Width="65px" />
                            <HeaderStyle Width="65px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KHName" HeaderText="客户名称" >
                            <ItemStyle Width="120px" />
                            <HeaderStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KHAdress" HeaderText="地址" >
                            <ItemStyle Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KHLB" HeaderText="类别" >
                            <ItemStyle Width="40px" />
                            <HeaderStyle Width="40px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
             </asp:GridView>
    </div>
    </form>
</body>
</html>