<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>邢台钢铁有限责任公司WMS仓库管理系统</title>
    <link href="CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="JavaScript/Login.js" type="text/javascript"></script>
    <script language="javascript">
        function login() {   //打开页面  url地址，target为空，fartrue特点 宽度屏幕-10 高度屏幕-10 
            window.open('Default.aspx', '', 'left=0px,top=0px,width=' + (window.screen.width - 10) + ',height=' + (window.screen.height - 50) + ',toolbar=no, menubar=no, scrollbars=auto, resizable=yes,location=no, status=yes');
            window.opener = null;

            window.close();
        }
        function fun(x, name) {
            var e = eval("document.all." + x);
            e.src = "Images/Login/" + name + ".gif";
        }

        function out(x, name) {
            var e = eval("document.all." + x);
            e.src = "Images/Login/" + name + ".gif";
        }
    </script>
</head>
<body leftmargin="0" background="Images/Login/bg.gif" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <%-- //全局table--%>
        <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td valign="middle" align="center">
                    <%-- //居中table--%>
                    <table height="447" cellspacing="0" cellpadding="0" width="637" background="Images/login/首页3.gif" border="0">
                        <tr>
                            <%--//登录历史库 靠右对齐--%>
                            <td align="right" style="height: 214px" valign="top">&nbsp;<br />
                                <br />
                                <img id="imgHistory" runat="server" src="Images/login/LoginHistory.gif" style="cursor: hand;" /></td>
                        </tr>
                        <tr>
                            <td valign="middle" align="center" height="28"></td>
                        </tr>
                        <tr>
                            <td valign="middle" align="center" style="height: 6px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtUserName" runat="server" Height="20px" Width="90px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" align="center" style="height: 30px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtPassword" runat="server" Height="20px" Width="90px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <%-- //登陆按钮 底部对齐--%>
                            <td valign="bottom" align="center" height="46">&nbsp; &nbsp; 
                                    <asp:ImageButton onmousemove="fun('btnGO','button_2')" ID="btnGO" onmouseout="out('btnGO','button_1')" runat="server" ImageUrl="Images/Login/button_1.gif" Height="28px" Width="88px" OnClick="btnGO_Click"></asp:ImageButton></td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 24px" valign="bottom">&nbsp; &nbsp; &nbsp;&nbsp;
                                    <!--<asp:CheckBox ID="chkHistory" runat="server" Text="登录历史库" />-->
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 24px" valign="bottom">&nbsp; &nbsp; &nbsp;&nbsp;
                                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="padding-top: 10px" valign="middle" align="center">
                                <br />
                                <br />
                                &nbsp; &nbsp; &nbsp; &nbsp; <span style="font-size: 8pt">1024*768以上分辨率</span></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
