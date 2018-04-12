<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FYD_FHCK.aspx.cs" Inherits="SiteBll_FormMan_FYD_FHCK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>发运单发货参考</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FormFYD.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
  <div>
     <div style="BORDER:0px;PADDING:0px;MARGIN:0px;width:98%;height:350px;overflow:auto;white-space:nowrap;align:center;">
        <asp:GridView ID="grvFYD" runat="server" AllowSorting="True" AutoGenerateColumns="False"
             width="100%" BorderStyle="None">
            <Columns>
                <asp:BoundField DataField="KHBM" HeaderText="客户编码">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="KHName" HeaderText="客户名称" />
                <asp:BoundField DataField="FYDH" HeaderText="发运单号">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="PCH" HeaderText="批次号">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="HW" HeaderText="货位">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="js" HeaderText="库存件数">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="zl" HeaderText="库存重量">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="fysl" HeaderText="已发货数量">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="WLH" HeaderText="物料号">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="SX" HeaderText="属性">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>

                <asp:BoundField DataField="PCInfo" HeaderText="特殊信息">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="fyrq" HeaderText="发运日期">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                
                <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                <asp:BoundField DataField="vfree2" HeaderText="自由项2">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="vfree3" HeaderText="自由项3">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="White" />
            <HeaderStyle BackColor="#DCE8F4" />
            <AlternatingRowStyle BorderStyle="Solid" BorderWidth="1px" />
        </asp:GridView>
        </div>
    </div>
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="X-Large" 
        ForeColor="Red" Text="" Visible="False"></asp:Label>
   </form>
</body>
</html>
