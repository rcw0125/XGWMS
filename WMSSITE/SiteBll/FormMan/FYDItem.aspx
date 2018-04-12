<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FYDItem.aspx.cs" Inherits="SiteBll_FormMan_FYDItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>发运单信息</title>
     <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div>
      <asp:GridView ID="grdGridList" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="grdGridList_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="卷号" DataField="Barcode" />
                <asp:BoundField HeaderText="批次" DataField="pch" />
                <asp:BoundField HeaderText="特殊信息" DataField="PCInfo" />
                <asp:BoundField HeaderText="物料号" DataField="wlh" />
                <asp:BoundField HeaderText="属性" DataField="SX" />
                <asp:BoundField DataField="PH" HeaderText="牌号" />
                <asp:BoundField HeaderText="规格" DataField="GG" />
                <asp:BoundField HeaderText="标准" DataField="BZ" />
                <asp:BoundField HeaderText="货位" DataField="HW" />
                <asp:BoundField HeaderText="重量" DataField="ZL" />
                <asp:BoundField HeaderText="出库人员" DataField="CKRY" />
                <asp:BoundField HeaderText="出库日期" DataField="RQ" />
                <asp:BoundField HeaderText="火车车厢号" DataField="CXH" />
                <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
    </div>
    <table style="width: 691px">
        <tr>
            <td style="width: 46px">
                总计</td>
            <td style="width: 196px">
                记录数：<asp:Label ID="lblCount" runat="server"></asp:Label></td>
            <td style="width: 534px">
                合计重量：<asp:Label ID="lblSZL" runat="server"></asp:Label></td>
        </tr>
    </table>
    </form>
</body>
</html>
