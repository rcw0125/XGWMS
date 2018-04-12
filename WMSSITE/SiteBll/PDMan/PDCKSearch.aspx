<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDCKSearch.aspx.cs" Inherits="SiteBll_PDMan_PDCKSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1"
            runat="server"></ext:PageManager>
    <ext:ContentPanel runat="server" ID="cp1" EnableCollapse="true" Title="查询条件" EnableBackgroundColor="true"><TABLE><TBODY><TR><TD width=30>仓库</TD><TD width=160><ext:DropDownList runat="server" Label="仓库" Width="150px" ID="cmbck"></ext:DropDownList>
 </TD><TD width=80>制单日期范围</TD><TD width=40><ext:CheckBox runat="server" ID="ckzdrq"></ext:CheckBox>
 </TD><TD width=100><ext:DatePicker runat="server" Width="100px" ID="dtprqq"></ext:DatePicker>
 </TD><TD width=10>-</TD><TD width=100><ext:DatePicker runat="server" Width="100px" ID="dtprqz"></ext:DatePicker>
 </TD><TD width=100></TD><TD width=50><ext:Button runat="server" Icon="ApplicationOsxGo" Text="查  询" ID="btnQuery" OnClick="btnQuery_Click"></ext:Button>
 </TD><TD width=100><ext:Button runat="server" Icon="Printer" Text="打  印" ID="Button1" OnClick="Button1_Click" EnableAjax="false" DisableControlBeforePostBack="false"></ext:Button>
 </TD></TR></TBODY></TABLE></ext:ContentPanel>
    <ext:Grid ID="grid" Title="查询结果" runat="server" 
             EnableRowNumber="true" Height="500px" EnableCheckBoxSelect="true" 
             >
            <Columns>
                <ext:BoundField DataField="hw" HeaderText="货位" Width="100px" ColumnID="ct0"/>
                <ext:BoundField DataField="b" HeaderText="盘点类型" Width="100px" 
                    ColumnID="ct1" />
                <ext:BoundField DataField="pddh" HeaderText="盘点单号" Width="100px" ColumnID="ct3" />
                <ext:BoundField DataField="pdtype" HeaderText="实际盘点类型" Width="100px" ColumnID="ct2" />
                <ext:BoundField DataField="djzt" HeaderText="单据状态" Width="100px" ColumnID="ct5" />
            </Columns>
        </ext:Grid>
    </form>
</body>
</html>
