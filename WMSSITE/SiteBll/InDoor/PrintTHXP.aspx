<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintTHXP.aspx.cs" Inherits="SiteBll_InDoor_PrintTHXP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body leftmargin="0" topmargin="0">
    <object ID='WebBrowser' WIDTH=0 HEIGHT=0 CLASSID='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2'VIEWASTEXT></object>
    <form id="form1" runat="server">
      <table border="0" style="font-weight: bold; width: 277px;">
        <tr>
          <td valign="top" style="width: 230px; height: 329px;"><table border="0" style="width: 288px">
            <tr>
              <td style="text-align: center; font-weight: bold; font-size: 12pt; width: 288px; height: 36px;">邢钢提货小票<br />
                  &nbsp;
              </td>
            </tr>
            <tr>
              <td style="width: 288px; height: 14px;"><table border="0" style="width: 285px">
                <tr>
                  <td style="width: 45px">单号</td>
                  <td style="width: 130px">
                      <asp:TextBox ID="txtFYDH" runat="server" BorderStyle="None" Width="120" Font-Bold="True"></asp:TextBox></td>
                </tr>
                <td style="width: 45px">车号</td>
                  <td style="width: 120px">
                      <asp:TextBox ID="txtCPH" runat="server" BorderStyle="None" Width="110" Font-Bold="True"></asp:TextBox></td>
                </table><table border="0" style="width: 285px">
                <tr>
                  <td style="height: 20px">客户</td>
                  <td style="width: 252px; height: 20px">
                      <asp:TextBox ID="txtKHName" runat="server" BorderStyle="None" Width="230px" Font-Bold="True"></asp:TextBox></td>
                </tr>
              </table><table border="0" style="width: 285px">
                <tr>
                  <td style="width: 60px">制单人</td>
                  <td style="width: 83px">
                      <asp:TextBox ID="txtZDRY" runat="server" BorderStyle="None" Width="80" Font-Bold="True"></asp:TextBox></td>
                 </tr>
                 <tr>
                  <td style="width: 80px">制单日期</td>
                  <td style="width: 121px">
                      <asp:TextBox ID="txtZDRQ" runat="server" BorderStyle="None" Width="100%" Font-Bold="True"></asp:TextBox></td>
                </tr>
              </table>
              <table>
              <tr>
              <td style="height:20px"></td>
              </tr>
              </table>
              </td>
            </tr>
              <asp:Literal ID="Literal1" runat="server"></asp:Literal><tr>
              <td style="height:20px"><Img src="../../Images/icon/line.gif" style="width: 4px; height: 10px"/></td>
              </tr>
              <tr>
              <td style="width: 240px"><table border="0">
                <tr>
                  <td style="width: 36px">合计</td>
                  <td style="width: 55px">计划数量</td>
                  <td style="width: 30px">
                      <asp:TextBox ID="txtHJ_JHSL" runat="server" BorderStyle="None" Width="20px" Font-Bold="True"></asp:TextBox></td>
                  <td style="width: 56px">计划重量</td>
                  <td>
                      <asp:TextBox ID="txtHJ_JHZL" runat="server" BorderStyle="None" Width="55px" Font-Bold="True"></asp:TextBox></td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td style="width: 260px"><table border="0">
                <tr>
                  <td style="width: 46px">操作员</td>
                  <td style="width: 50px">
                      <asp:TextBox ID="txtCZ_User" runat="server" BorderStyle="None" Width="50px" Font-Bold="True"></asp:TextBox></td>
                  <td style="width: 31px">日期</td>
                  <td>
                      <asp:TextBox ID="txtRQ" runat="server" BorderStyle="None" Width="111px" Font-Bold="True"></asp:TextBox></td>
                </tr>
              </table></td>
            </tr>
          </table>
              <table border="0" style="width: 100%">
                  <tr>
                  <td style="font-weight: bold; height: 16px;">货位号</td>
                  <td style="font-weight: bold; height: 16px;">批次号</td>
                  <td style="font-weight: bold; height: 16px;">属性</td>
                  <td style="font-weight: bold; height: 16px; width: 72px;">实发件数</td>
                  </tr>
              </table>
              <Img src="../../Images/icon/line.gif" Width="280px"/></td>
        </tr>
        <tr>
          <td style="width: 230px; height: 200px;"><table border="0" height="200px">
            <tr valign="bottom">
              <td height="200px">
                  <asp:Image ID="Image2" runat="server" ImageUrl="../../Images/icon/line.gif" Width="280px"/></td>
            </tr>
            <tr valign="top">
              <td height="50px"><table width="100%" border="0" height="50px">
                <tr valign="top">
                  <td style="width: 50px" height="50px">发货人</td>
                  <td style="width: 85px"></td>
                  <td style="width: 51px">监管人</td>
                  <td></td>
                </tr>
              </table></td>
            </tr>
          </table></td>
        </tr>
           
            <tr>
              <td style="width: 250px">销售公司特别安全提示：</td> 
            </tr>
            <tr>
            <td style="width: 250px">1、进入厂区的机动车辆，最高车速不得超过30公里/小时，必须按厂内安全标志限速行驶，注意避让行人及非机动车辆。</td>
            </tr>
            <tr>
            <td style="width: 250px">2、机动车辆通过铁道路口时，必须遵循“一停、二看、三确认、四通过”的原则，严禁与火车抢道蛮行。</td>
            </tr>
        <tr>
        <td style="height:20px">
            .</td>
        </tr>
            
      </table>
    </form>
</body>
</html>
<script language="javascript">WebBrowser.ExecWB(7,1); window.opener=null;window.close();</script>
