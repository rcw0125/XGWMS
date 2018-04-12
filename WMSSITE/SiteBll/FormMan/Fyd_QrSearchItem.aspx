<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fyd_QrSearchItem.aspx.cs" Inherits="SiteBll_FormMan_Fyd_QrSearchItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div style="BORDER:0px;PADDING:0px;MARGIN:0px;width:98%;height:212px;overflow:auto;white-space:nowrap;align:center;">
    <TABLE  cellSpacing="1" cellPadding="1" width="100%" border="2">
    <tr><td>确认结果</td><td style="width: 328px">签证室车牌</td><td>签证室车体</td><td>门岗车牌</td><td>门岗车体</td></tr>
           <tr><td><asp:GridView ID="grvqr" runat="server" AutoGenerateColumns="False"  Width="46%" Height="180px" BorderStyle="Solid" BorderWidth="1px">
        <Columns>
            <asp:BoundField HeaderText="角色" DataField="rolename" SortExpression="indoorid" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField HeaderText="确认时间" DataField="qrsj" SortExpression="outdoorid" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="qrrname" HeaderText="确认人" SortExpression="vfree1" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="sl" HeaderText="确认数量" SortExpression="vfree2" >
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" />
        <HeaderStyle BackColor="#DCE8F4" />
    </asp:GridView></td><td style="width: 328px">
               <asp:Image ID="imgqzscph" runat="server" Height="150px" Width="200px" onclientclick="window.open('http://t.douban.com/lpic/s4119038.jpg ')"/><br />
        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">查看大图</asp:HyperLink></td>
               <td><asp:Image ID="imgqzsbody" runat="server" Height="150px" Width="200px" /><br />
        <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank">查看大图</asp:HyperLink></td>
               <td><asp:Image ID="imgdoorcph" runat="server" Height="150px" Width="200px" /><br />
        <asp:HyperLink ID="HyperLink3" runat="server" Target="_blank">查看大图</asp:HyperLink></td>
               <td><asp:Image ID="imgdoorbody" runat="server" Height="150px" Width="200px" /><br />
        <asp:HyperLink ID="HyperLink4" runat="server" Target="_blank">查看大图</asp:HyperLink></td></tr>
           
        </TABLE>
        </div>
    </form>
</body>
</html>
