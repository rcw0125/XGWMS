<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintPDCY.aspx.cs" Inherits="SiteBll_PDMan_PrintPDCY" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>盘点差异</title>
</head>
<body>
<object ID='WebBrowser' WIDTH=0 HEIGHT=0 CLASSID='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2'VIEWASTEXT></object>
    <form id="form1" runat="server">
          <table style="width: 664px; height: 46px">
              <tr>
                  <td colspan="3" style="height: 43px" align="center">
                      <span style="font-size: 18pt">盘点差异报表（不包含放错货位）</span></td>
              </tr>
              <tr>
                  <td style="width: 412px; height: 14px; text-align: left">
                      &nbsp;&nbsp;<span style="font-size: 10pt"> 盘点单号：</span><asp:Label ID="lblYSDH" runat="server" Width="140px"></asp:Label></td>
                  <td style="width: 339px; height: 14px; text-align: left" align="right">
                      <span style="font-size: 10pt"></span></td>
                  <td style="width: 409px; height: 14px; text-align: left" align="right">
                      <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                          &nbsp; &nbsp; &nbsp;&nbsp; 仓库：<asp:Label ID="lblCKID" runat="server" Width="56px"></asp:Label></span></td>
              </tr>
          </table>
          <div style="width:665px; height:600px">
          <asp:GridView ID="grdPDCY" runat="server" AutoGenerateColumns="False" BorderColor="Black" Width="664px">
              <Columns>
                  <asp:BoundField HeaderText="单卷号" DataField="barcode" >
                      <ItemStyle HorizontalAlign="Left" Width="70px" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="批次号" DataField="pch" >
                      <ItemStyle HorizontalAlign="Left" Width="70px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="PH" HeaderText="牌号">
                      <ItemStyle Width="70px" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="规格" DataField="gg" >
                      <ItemStyle HorizontalAlign="Left" Width="70px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="SX" HeaderText="属性">
                      <ItemStyle Width="70px" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="货位" DataField="HW" >
                      <ItemStyle HorizontalAlign="Right" Width="70px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="ZCSL" HeaderText="帐存数量">
                      <ItemStyle Width="70px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="SPSL" HeaderText="实盘数量">
                      <ItemStyle Width="70px" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="重量" DataField="zl" >
                      <ItemStyle HorizontalAlign="Right" Width="70px" />
                  </asp:BoundField>
              </Columns>
              <RowStyle BorderColor="Black" />
              <HeaderStyle BorderColor="Black" />
          </asp:GridView>
          </div>
          <table style="width: 664px;vertical-align:bottom">
              <tr>
                  <td>制表人：</td>
                  <td style="width: 254px"><asp:Label ID="lblName" runat="server" Width="100px"></asp:Label></td>
                  <td style="width: 109px">制表日期：</td>
                  <td><asp:Label ID="lblDate" runat="server" Width="120px"></asp:Label></td>
              </tr>
          </table>
    </form>  
</body>
</html>
<script language="javascript">WebBrowser.ExecWB(7,1); window.opener=null;window.close();</script>