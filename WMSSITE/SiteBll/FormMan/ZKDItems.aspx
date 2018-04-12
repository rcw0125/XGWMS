<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZKDItems.aspx.cs" Inherits="SiteBll_FormMan_ZKDItems" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>转库单信息</title>
     <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
     <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
     <script language="javascript" src="../../JavaScript/FormZKD.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div>
      <img ID="imgBtnExcel"  src="../../Images/icon/img16.gif" OnClick="imgBtnExcel_Click();"/>
      <asp:GridView ID="grdGridList" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:BoundField DataField="Barcode" HeaderText="卷号" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="PCH" HeaderText="批次号" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="SX" HeaderText="属性" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="WLH" HeaderText="物料号" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ph" HeaderText="牌号" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="gg" HeaderText="规格" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="hw" HeaderText="货位" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="zl" HeaderText="重量" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="CKOperator" HeaderText="转出人员" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="CKTime" HeaderText="转出时间" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="YKOperator" HeaderText="转入人员" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="YKTime" HeaderText="转入时间" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="WLMC" HeaderText="物料名称" >
                    <ItemStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
