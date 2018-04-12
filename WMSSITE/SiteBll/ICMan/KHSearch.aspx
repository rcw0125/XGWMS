<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KHSearch.aspx.cs" Inherits="SiteBll_ICMan_KHSearch" %>
<%--徐慧杰--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择客户</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/ICMan.js" type="text/javascript"></script>
</head>
<body>
<form runat="server">
<table width="480px" border="1">
  <tr>
    <td>
    <asp:Panel ID="Panel1" runat="server" Height="400px" Width="100%" ScrollBars=Auto>
        <asp:GridView ID="grdKHInfo" runat="server" AutoGenerateColumns="False" Width="100%" Font-Size="Medium">
        <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle"  />
        <Columns>
            <asp:BoundField DataField="KHID" HeaderText="客户编码" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="KHName" HeaderText="客户名称" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="KHAdress" HeaderText="客户地址" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="KHLB" HeaderText="客户类别" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <Img src="../../Images/icon/choose.gif" ID="btnChoose"  onclick="SetKHSlc()" style="CURSOR: hand"/>
                    <input id="hidValue" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.KHID") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
        </asp:Panel>
    </td>
  </tr>
  <tr>
    <td><table width="100%" border="1">
      <tr>
        <td style="text-align: center">客户编码</td>
        <td style="text-align: center"><asp:TextBox ID="txtKHID" runat="server"></asp:TextBox></td>
        <td style="text-align: center"><asp:ImageButton ID="btnSearch" runat="server" ImageUrl="../../images/icon/img25.gif" OnClick="btnSearch_Click"/></td>
      </tr>
      <tr>
        <td style="text-align: center">客户名称</td>
        <td style="text-align: center"><asp:TextBox ID="txtKHName" runat="server"></asp:TextBox></td>
        <td style="text-align: center"><img id="btnCancelslc" onclick="ClosePage()" src="../../images/icon/img22.gif" style="cursor: hand" /></td>
      </tr>
    </table></td>
  </tr>
</table>
  <input id="hidCValue"  runat="server" type="hidden" />
  <input id="hidKHName"  runat="server" type="hidden" />
  <input id="hidKHLB"  runat="server" type="hidden" />
</form>
</body>
</html>
