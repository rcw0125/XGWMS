<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormCheckQuLeftTree.aspx.cs" Inherits="SiteBll_CheckQu_FormCheckQuLeftTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
</head>
<body topmargin="0" leftmargin="0">
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
