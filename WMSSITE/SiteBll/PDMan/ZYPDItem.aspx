<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZYPDItem.aspx.cs" Inherits="SiteBll_PDMan_ZYPDItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>发运单信息</title>
     <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div>
      <asp:GridView ID="grdGridList" runat="server" AutoGenerateColumns="False" ShowFooter="True">
            <Columns>
                <asp:BoundField HeaderText="批次" DataField="pch" />
                <asp:BoundField HeaderText="物料号" DataField="wlh" />
                <asp:BoundField HeaderText="属性" DataField="SX" />
                <asp:BoundField DataField="PH" HeaderText="牌号" />
                <asp:BoundField HeaderText="规格" DataField="GG" />
                <asp:BoundField HeaderText="数量" DataField="sl" />
                <asp:BoundField DataField="zcsl" HeaderText="帐存数量" />
                <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
                <asp:BoundField DataField="pc" HeaderText="盘差" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
