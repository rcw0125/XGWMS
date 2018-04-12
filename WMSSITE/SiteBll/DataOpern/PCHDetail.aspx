<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PCHDetail.aspx.cs" Inherits="SiteBll_DataOpern_PCHDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>批次的详细信息</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
     <asp:GridView ID="grdPCHDetails" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="PCH" HeaderText="批次号" />
                <asp:BoundField DataField="WLH" HeaderText="物料号" />
                <asp:BoundField DataField="WLMC" HeaderText="物料名称" />
                <asp:BoundField DataField="SX" HeaderText="属性" />
                <asp:BoundField DataField="PH" HeaderText="牌号" />
                <asp:BoundField DataField="GG" HeaderText="规格" />
                <asp:BoundField DataField="BB" HeaderText="班别" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
    </form>
</body>
</html>
