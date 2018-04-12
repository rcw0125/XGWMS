<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuWGD.aspx.cs" Inherits="SiteBll_CheckQu_QuWGD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>特殊信息完工单</title>
    <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../JavaScript/QuCheck.js" type="text/javascript"></script>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" method="post" name="form1" runat="server">
    <div>
        <asp:GridView ID="grvWGD" runat="server" AutoGenerateColumns="False" 
            Width="100%" OnRowDataBound="grvWGD_RowDataBound">
            <Columns>
                <asp:BoundField DataField="WGDH" HeaderText="完工单号" />
                <asp:BoundField DataField="PCH" HeaderText="批次" />
                <asp:BoundField DataField="PCSX" HeaderText="批次属性" />
                <asp:BoundField DataField="WLH" HeaderText="物料号" />
                <asp:BoundField DataField="WLMC" HeaderText="物料名称" />
                <asp:BoundField DataField="PH" HeaderText="牌号" />
                <asp:BoundField DataField="GG" HeaderText="规格" />
                <asp:BoundField DataField="ZXBZ" HeaderText="执行标准" />
                <asp:BoundField DataField="FZDW" HeaderText="辅助单位" />
                <asp:BoundField DataField="BB" HeaderText="班别" />
                <asp:BoundField DataField="PCInfo" HeaderText="特殊信息" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" />
        </asp:GridView>
    
    </div>
    <input type="hidden" id="hpch"/>
    </form>
</body>
</html>
