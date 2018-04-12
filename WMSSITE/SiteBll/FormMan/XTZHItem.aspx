<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XTZHItem.aspx.cs" Inherits="SiteBll_FormMan_XTZHItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
     <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
        <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/XTZHJS.js" ></script>
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
<DIV id="DIV1" style="BORDER:0px;PADDING:0px;MARGIN:0px;OVERFLOW:auto;WIDTH:100%;HEIGHT:200px">
                <asp:GridView ID="grvCOPYXTZH" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="编号" DataField="ItemID" />
                        <asp:BoundField HeaderText="目标物料号" DataField="TWLH" />
                        <asp:BoundField HeaderText="物料名称" DataField="TWLMC" />
                        <asp:BoundField HeaderText="目标牌号" DataField="TPH" />
                        <asp:BoundField DataField="TGG" HeaderText="目标规格" />
                        <asp:BoundField HeaderText="目标属性" DataField="TSX" />
                        <asp:BoundField HeaderText="计划数量" DataField="JHSL" />
                        <asp:BoundField HeaderText="实际数量" DataField="SJSL" />
                        <asp:BoundField HeaderText="数量单位" DataField="FJLDW" />
                        <asp:BoundField HeaderText="计划重量" DataField="JHZL" />
                        <asp:BoundField HeaderText="实际重量" DataField="SJZL" />
                        <asp:BoundField HeaderText="重量单位" DataField="ZJLDW" />
                        <asp:BoundField HeaderText="状态" DataField="Status" />
                        <asp:BoundField DataField="tvfree1" HeaderText="自由项1" />
                        <asp:BoundField DataField="tvfree2" HeaderText="自由项2" />
                        <asp:BoundField DataField="tvfree3" HeaderText="自由项3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                </asp:GridView>
			</DIV>
    </form>
</body>
</html>
