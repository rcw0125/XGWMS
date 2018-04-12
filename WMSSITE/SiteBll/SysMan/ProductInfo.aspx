<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductInfo.aspx.cs" Inherits="SiteBll_SysMan_ProductInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>物料基础信息</title>
        <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
        <script language="JAVASCRIPT" src="../../JavaScript/SysMan.js" type="text/javascript">
	    </script>
	    <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript">
	    </script>
		<script language="javascript" type="text/javascript">
	        function khdata()
	        {
	        if(confirm("您要从NC数据库更新WMS系统物料基础信息吗？"))
	        {
	        return true;
	        }
	        return false;
	        }
	
	</script>
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div>
        <TABLE class="fixColStyle" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0"
				runat="server">
				<TR>
					<TD colSpan="2" height="1"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
				align="center" background="../../images/icon/topbg.gif" border="0">
				<TR>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG id="" style="CURSOR: hand" onclick="AddFull(1);" alt="全屏" src="../../images/icon/arrowleft.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG id="IMG1" style="CURSOR: hand" onclick="AddFull(0);" alt="返回" src="../../images/icon/arrowright.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="90%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="物料基础信息"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE><table width="100%" cellpadding="0" cellspacing="0" border="0">
			<tr align="left">
			<td style="height: 28px">
                &nbsp;
                &nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon/import_wl.gif"
                    OnClick="ImageButton1_Click1"  OnClientClick="return khdata();"/>
                &nbsp;&nbsp;
			</td>
			</tr>
			</table>
    <TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="middle" align="left" bgColor="#dce8f4" style="width: 21%; height: 21px;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;数据浏览</font></TD>
					<TD vAlign="middle" width="97%" bgColor="#dce8f4" style="height: 21px" align="right">
                        </TD>
				</TR>
				<TR>
					<TD colSpan="2" height="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="620px" AllowPaging="True"  PageSize="20" ShowFooter="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                     <AlternatingRowStyle ForeColor="Black" BackColor="#FAFAFA" Height="17px"></AlternatingRowStyle>
                    <RowStyle Wrap="True" ForeColor="Black" BackColor="White" Height="17px"></RowStyle>
                    <Columns>
                        <asp:BoundField DataField="wlh" HeaderText="物料编码" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sx" HeaderText="属性" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                    <SelectedRowStyle BackColor="#DCE8F4" />
                    <PagerStyle Font-Size="14pt" />
                </asp:GridView>
                    </TD>
				</TR>
				<tr><td>
                    记录总数：<%=WLCOUNT %></td></tr>
			</TABLE>
    </div>
    </form>
</body>
</html>
