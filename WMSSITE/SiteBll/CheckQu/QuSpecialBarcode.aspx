<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuSpecialBarcode.aspx.cs" Inherits="SiteBll_CheckQu_QuSpecialBarcode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>特殊信息单卷</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/QuCheck.js" type="text/javascript"></script>
    
</head>
<body topmargin="0" leftmargin="0">
<form id="form1" method="post" name="form1" runat="server">
        <asp:GridView ID="grdGridList" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="2000px" OnRowDataBound="grdGridList_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Barcode" HeaderText="条码" />
                <asp:BoundField DataField="GH" HeaderText="钩号" />
                <asp:BoundField DataField="PCH" HeaderText="批次号" />
                <asp:BoundField DataField="PH" HeaderText="牌号" />
                <asp:BoundField DataField="ErrSeason" HeaderText="不合格原因" />
                <asp:BoundField DataField="GG" HeaderText="规格" />
                <asp:BoundField DataField="SX" HeaderText="属性" />
                <asp:BoundField DataField="ZL" HeaderText="卷重" />
                <asp:BoundField DataField="BB" HeaderText="班组" />
                <asp:BoundField DataField="WLH" HeaderText="物料号" />
                <asp:BoundField DataField="WLMC" HeaderText="物料名称" />
                <asp:BoundField DataField="WGDH" HeaderText="完工单号" />
                <asp:BoundField DataField="CK" HeaderText="仓库" />
                <asp:BoundField DataField="HW" HeaderText="货位" />
                <asp:BoundField DataField="BZ" HeaderText="执行标准" />
                <asp:BoundField DataField="ProduceData" HeaderText="生产日期" />
                <asp:BoundField DataField="WeightRQ" HeaderText="称重日期" />
                <asp:BoundField DataField="PCInfo" HeaderText="批次特殊信息" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
        <input type="hidden" id="hpch"/>
 </form>
</body>
</html>
