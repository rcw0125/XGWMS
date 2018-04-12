<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDLeftTree.aspx.cs" Inherits="SiteBll_PDMan_PDLeftTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>盘点管理目录</title>
    <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <TABLE class="WorkForm" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100"
				border="0">
				<TR>
					<TD valign="top" style="width: 49px">
                        <asp:TreeView ID="TreeView1" runat="server">
                            <SelectedNodeStyle BackColor="#DCE8F4" />
                        </asp:TreeView>
					</TD>
				</TR>
	</TABLE>
    </form>
</body>
</html>