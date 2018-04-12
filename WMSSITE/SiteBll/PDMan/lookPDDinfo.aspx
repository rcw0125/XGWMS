<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lookPDDinfo.aspx.cs" Inherits="SiteBll_PDMan_lookPDDinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>查看盘点单信息</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div style="overflow:auto; width:300px; height:200px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
            <Columns>
                <asp:BoundField DataField="YSDH" HeaderText="NC盘点单号">
                    <ItemStyle Width="80px" />
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="PDDH" HeaderText="RF盘点单号">
                    <ItemStyle Width="80px" />
                    <HeaderStyle Width="80px" />
                    </asp:BoundField>
                <asp:BoundField DataField="CK" HeaderText="仓库">
                    <ItemStyle Width="30px" />
                    <HeaderStyle Width="30px" />
                    </asp:BoundField>
                <asp:BoundField DataField="DJZT" HeaderText="状态">
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="DJLX" HeaderText="类型">
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                    </asp:BoundField>
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
