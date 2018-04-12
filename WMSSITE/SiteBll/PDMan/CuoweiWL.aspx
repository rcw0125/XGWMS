<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CuoweiWL.aspx.cs" Inherits="SiteBll_PDMan_CuoweiWL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>以下物料实物位置与帐存位置不符</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div style="overflow:auto">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="barcode" HeaderText="单卷号">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="pch" HeaderText="批次号">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="ph" HeaderText="牌号">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="gg" HeaderText="规格">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="sx" HeaderText="属性">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="pck" HeaderText="盘点仓库">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="phw" HeaderText="盘点货位">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="yck" HeaderText="帐存仓库">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="yhw" HeaderText="帐存货位">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
