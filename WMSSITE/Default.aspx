<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="UserControl/down.ascx" TagName="down" TagPrefix="uc2" %>

<%@ Register Src="UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>邢台钢铁有限责任公司WMS仓库管理系统</title>
    <link href="CSS/cms.css" rel="stylesheet" type="text/css" />
    <style>
		A { COLOR: #1F3B53; TEXT-DECORATION: none }
		A:hover { COLOR: #ad182b }
	</style>
    <script language="javascript" src="JavaScript/Login.js" type="text/javascript" />
     <script language="javascript">
	    function fun(x,name)
	    {
	        var e = eval("document.all.Header_"+ x);
	        e.src="image/header/"+name+".gif";
	    }
	    function out(x,name)
	    {
	        var e = eval("document.all.Header_"+ x);
	        e.src="image/header/"+name+".gif";
	    }
    </script>
</head>
<body topmargin="0" leftmargin="0" style="OVERFLOW-Y: visible;">
		<form id="Form1" method="post" runat="server">
			<table width="100%" cellpadding="0" cellspacing="0" border="0" align="center" height="100%">
				<tr>
					<td colspan="2" valign="top" height="38">
                        <uc1:Header ID="Header1" runat="server" />
                    </td>
				</tr>
				<tr>
					<td width="5"></td>
					<td valign="top"><iframe id="frm" height="100%" width="100%" frameborder="no" name="frm" src="FirstPage.aspx"></iframe>
					</td>
				</tr>
				<tr>
					<td colspan="2" valign="top" height="20">
                        <uc2:down ID="Down1" runat="server" />
                    </td>
				</tr>
			</table>
		</form>
	</body>
</html>
