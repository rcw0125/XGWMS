<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KCadjust.aspx.cs" Inherits="SiteBll_PDMan_KCadjust" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>此处不包含由放错货位导致的盘点差异</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
        <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="JAVASCRIPT" src="../../JavaScript/PDMan.js" type="text/javascript">
	</script>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div style="overflow:auto; height:250px; width: 800px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="120%">
            <Columns>
                <asp:BoundField DataField="barcode" HeaderText="单卷号">
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="wlh" HeaderText="物料号">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="wlmc" HeaderText="物料名称">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="pch" HeaderText="批次号">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="gg" HeaderText="规格">
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="ph" HeaderText="牌号">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="sx" HeaderText="属性">
                    <ItemStyle Width="90px" />
                    <HeaderStyle Width="90px" />
                    </asp:BoundField>
                <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
                <asp:BoundField DataField="ck" HeaderText="仓库">
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="hw" HeaderText="货位">
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                    </asp:BoundField>
                <asp:BoundField DataField="zcsl" HeaderText="帐存数量">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="spsl" HeaderText="实盘数量">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="slcy" HeaderText="数量差异">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="zl" HeaderText="重量">
                    <ItemStyle Width="50px" />
                    <HeaderStyle Width="50px" />
                    </asp:BoundField>
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
        <table style="height: 20px; width:100%">
            <tr>
                <td align="center">
                <Img src="../../Images/icon/PanyingRuku.gif" ID="btnPYRK" onclick="KCadjustPYRK()" style="cursor: hand"/><input id="hidYSDH" style="width: 29px" runat="server" type="hidden" /></td>
                <td align="center">
                <Img src="../../Images/icon/PankuiChuku.gif" ID="btnPKCK" onclick="PKCK()" style="cursor: hand"/></td>
                <td align="center">
                <Img src="../../Images/icon/print2.gif" ID="btnPrint" style="cursor: hand" onclick="PrintPDCY()"/></td>
                <td align="center">
                <Img src="../../Images/icon/quit.gif" ID="btnQuit" onclick="window.close();" style="cursor: hand"/></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
