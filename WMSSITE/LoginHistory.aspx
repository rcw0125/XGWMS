<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginHistory.aspx.cs" Inherits="LoginHistory" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>邢台钢铁有限责任公司WMS仓库管理系统-历史库</title>
    <LINK href="CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript">
		function login()
		{
			window.open('Default.aspx','','left=0px,top=0px,width='+(window.screen.width-10)+',height='+(window.screen.height-50)+',toolbar=no, menubar=no, scrollbars=auto, resizable=yes,location=no, status=yes');
			window.opener=null;
			window.close();
		}
		function fun(x,name)
		{
		    var e = eval("document.all."+ x);
		    e.src="Images/Login/"+name+".gif";
		}
		
		function out(x,name)
		{
		var e = eval("document.all."+ x);
		e.src="Images/Login/"+name+".gif";
		}
		
	</script>
</head>
<body leftMargin=0 background=Images/Login/bg.gif topMargin=0>
		<form id=Form1 method=post runat="server">
			<table height="100%" cellSpacing=0 cellPadding=0 width="100%" border=0>
				<tr>
					<td vAlign=middle align=center>
						<table height=447 cellSpacing=0 cellPadding=0 width=637 background="Images/login/首页H.gif" border=0>
							<tr>
								<td align=center style="height: 214px"></td>
							</tr>
							<tr>
								<td vAlign=middle align=center height=20>
								</td>
							</tr>
							<tr>
							<td vAlign=middle align=center style="height: 6px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:textbox id=txtUserName runat="server" Height="20px" Width="120px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:textbox></td></tr>
							<tr>
								<td vAlign=middle align=center style="height: 30px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                    <asp:textbox id=txtPassword runat="server" Height="20px" Width="120px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC" TextMode="Password"></asp:textbox> 
								</td>
							</tr>
							<tr>
								<td vAlign="bottom" align=center height=42>
                                    &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:imagebutton onmousemove="fun('btnGO','button_2')" id=btnGO onmouseout="out('btnGO','button_1')" runat="server" ImageUrl="Images/Login/button_1.gif" height="28px" width="88px" OnClick="btnGO_Click"></asp:imagebutton></td>
							</tr>
                            <tr>
                                <td align="center" style="height: 24px" valign="bottom">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                    <!--<asp:CheckBox ID="chkHistory" runat="server" Text="登录历史库" />--></td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 24px" valign="bottom">
                                    &nbsp; &nbsp; &nbsp;&nbsp;
                                    <asp:label id=lblMessage runat="server" ForeColor="Red"></asp:label></td>
                            </tr>
							<TR>
								<td style="PADDING-TOP: 10px" vAlign=middle align=center>
                                    <br />
                                    <br />
                                    &nbsp; &nbsp; &nbsp; &nbsp; <span style="font-size: 8pt">1024*768以上分辨率</span></td>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>