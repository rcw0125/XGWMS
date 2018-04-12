<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WGDItems.aspx.cs" Inherits="SiteBll_FormMan_WGDItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>完工单明细</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
        <asp:GridView ID="grdGridList" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="PH" HeaderText="牌号" />
                <asp:BoundField DataField="GG" HeaderText="规格" />
                <asp:BoundField DataField="WLH" HeaderText="物料号" />
                <asp:BoundField DataField="WLMC" HeaderText="物料名称" />
                <asp:BoundField DataField="SX" HeaderText="属性" />
                <asp:BoundField DataField="zxbz" HeaderText="执行标准" />
                <asp:BoundField DataField="ZJBXBZ" HeaderText="质检备选" />
                <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
    </form>
</body>
</html>
