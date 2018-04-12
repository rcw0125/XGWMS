<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintFYDDetail.aspx.cs" Inherits="SiteBll_Report_PrintFYDDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打印发运清单明细</title>
</head>
<body>
    <object ID='WebBrowser' WIDTH=0 HEIGHT=0 CLASSID='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2'VIEWASTEXT></object>
    <form id="form1" runat="server">
          <table style="width: 664px; height: 46px">
              <tr>
                  <td colspan="3" style="height: 43px" align="center">
                      <span style="font-size: 18pt">邢钢线材发运清单</span></td>
              </tr>
              <tr>
                  <td style="width: 159px; height: 14px; text-align: left">
                      &nbsp;&nbsp;<span style="font-size: 10pt"> 车号：</span><asp:Label ID="lblCH" runat="server"></asp:Label></td>
                  <td style="width: 125px; height: 14px; text-align: left">
                      <span style="font-size: 10pt">发运类型:<asp:Label ID="lblType" runat="server"></asp:Label></span></td>
                  <td style="width: 409px; height: 14px; text-align: left">
                      <span style="font-size: 10pt">收货单位：<asp:Label ID="lblUnit" runat="server"></asp:Label></span></td>
              </tr>
          </table>
          <asp:GridView ID="grdFYDetail" runat="server" AutoGenerateColumns="False" BorderColor="Black" Width="664px" OnRowDataBound="grdFYDetail_RowDataBound">
              <Columns>
                  <asp:BoundField HeaderText="批次号" DataField="pch" >
                      <ItemStyle HorizontalAlign="Left" Width="133px" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="牌号" DataField="ph" >
                      <ItemStyle HorizontalAlign="Left" Width="133px" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="规格" DataField="gg" >
                      <ItemStyle HorizontalAlign="Left" Width="132px" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="件数" DataField="sl" >
                      <ItemStyle HorizontalAlign="Right" Width="133px" />
                  </asp:BoundField>
                  <asp:BoundField HeaderText="重量(吨)" DataField="zl" >
                      <ItemStyle HorizontalAlign="Right" Width="133px" />
                  </asp:BoundField>
              </Columns>
              <RowStyle BorderColor="Black" />
              <HeaderStyle BorderColor="Black" />
          </asp:GridView>
          <table height="20px" style="width: 664px" cellpadding="0" cellspacing="0">
            <tr><td style="width: 403px; border-left: black 1px solid; border-bottom: black 1px solid; height: 21px;" align="right">
                合计：</td><td style="width: 134px; border-left: black 1px solid; border-bottom: black 1px solid; height: 21px;" align="right">
                    <asp:Label ID="lblSL" runat="server"></asp:Label></td><td style="width: 133px; border-right: black 1px solid;border-left: black 1px solid; border-bottom: black 1px solid; height: 21px;" align="right" colspan="" rowspan="">
                    <asp:Label ID="lblZL" runat="server"></asp:Label></td></tr></table>
          <table style="width: 664px; height: 194px">
              <tr>
                  <td></td>
              </tr>
              <tr>
                  <td style="text-align: left" valign="bottom">
                      &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 经办人：<asp:Label ID="lblName" runat="server"></asp:Label>
                      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                      &nbsp;日期：<asp:Label ID="lblDate" runat="server"></asp:Label>
                      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                      &nbsp; &nbsp; (盖章)</td>
              </tr>
          </table>
    </form>  
</body>
</html>
<script language="javascript">WebBrowser.ExecWB(7,1); window.opener=null;window.close();</script>