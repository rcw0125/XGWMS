<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KCadjustPYRK.aspx.cs" Inherits="SiteBll_PDMan_KCadjustPYRK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>盘盈入库</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
        <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="JAVASCRIPT" src="../../JavaScript/PDMan.js" type="text/javascript">
	</script>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <div style="overflow:auto; height:200px; width: 619px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="130px" Width="130%">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <input id="chkFYDslc" type="checkbox" runat="server" onclick="SetPYRK()" />                      
                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                    <ItemStyle Width="30px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Barcode" HeaderText="单卷号">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="HW" HeaderText="货位">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="PCH" HeaderText="批次号">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="WLH" HeaderText="物料号">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="WLMC" HeaderText="物料名称">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    </asp:BoundField>
                <asp:BoundField DataField="SX" HeaderText="属性">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="PH" HeaderText="牌号">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="GG" HeaderText="规格">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="ZL" HeaderText="重量">
                    <ItemStyle Width="60px" />
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
        <table style="height: 20px; width:100%">
            <tr>
                <td align="center">
                <Img src="../../Images/icon/xiugaiHW.gif" ID="btnPYRK" onclick="xiugaiHW()" style="cursor: hand"/>
                <input id="hidYSDH" style="width: 123px" type="hidden" runat="server"/><input id="hidbarcode" style="width: 66px" type="hidden" runat="server"  /><input id="hidpch" style="width: 76px" type="hidden" runat="server"/><input id="hidsx" style="width: 75px" type="hidden" runat="server"/>
                    <input id="hidck" style="width: 103px" type="hidden" runat="server"/></td>
                <td align="center">
                    <asp:ImageButton ID="btnPYRK" ImageUrl="../../Images/icon/ruku.gif" runat="server" OnClick="btnPYRK_Click" /></td>
                <td align="center">
                <Img src="../../Images/icon/print2.gif" ID="btnPrint" onclick="PrintPYRK()" style="cursor: hand"/></td>
                <td align="center">
                <Img src="../../Images/icon/quit.gif" ID="btnQuit" onclick="window.close();" style="cursor: hand"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
