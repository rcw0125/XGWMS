<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FYDCheck.aspx.cs" Inherits="SiteBll_ICMan_FYDCheck" %>
<%--徐慧杰--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发运单情况</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/ICMan.js" type="text/javascript">
	</script>
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" method="post" runat="server">
            <asp:GridView ID="grdInfo" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField HeaderText="发运单号" DataField="FYDH" />
                    <asp:BoundField HeaderText="仓库" DataField="CK" />
                    <asp:BoundField HeaderText="客户" DataField="KHBM" />
                    <asp:BoundField HeaderText="运输类型" DataField="YSLB" />
                    <asp:BoundField HeaderText="车牌号" DataField="CPH" />
                    <asp:BoundField HeaderText="计划数量" DataField="JHSL" />
                    <asp:BoundField HeaderText="实际数量" DataField="SJSL" />
                    <asp:BoundField HeaderText="计划重量" DataField="JHZL" />
                    <asp:BoundField HeaderText="实际重量" DataField="SJZL" />
                    <asp:BoundField HeaderText="入门时间" DataField="CZ_InTime" />
                    <asp:BoundField HeaderText="出门时间" DataField="CZ_OtTime" />
                    <asp:BoundField HeaderText="状态" DataField="Status" />
                </Columns>
                <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
            </asp:GridView>
    </form>
</body>
</html>
