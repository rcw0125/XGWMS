<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZYPDItem.aspx.cs" Inherits="SiteBll_PDMan_ZYPDItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>���˵���Ϣ</title>
     <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div>
      <asp:GridView ID="grdGridList" runat="server" AutoGenerateColumns="False" ShowFooter="True">
            <Columns>
                <asp:BoundField HeaderText="����" DataField="pch" />
                <asp:BoundField HeaderText="���Ϻ�" DataField="wlh" />
                <asp:BoundField HeaderText="����" DataField="SX" />
                <asp:BoundField DataField="PH" HeaderText="�ƺ�" />
                <asp:BoundField HeaderText="���" DataField="GG" />
                <asp:BoundField HeaderText="����" DataField="sl" />
                <asp:BoundField DataField="zcsl" HeaderText="�ʴ�����" />
                <asp:BoundField DataField="vfree1" HeaderText="������1" />
                <asp:BoundField DataField="vfree2" HeaderText="������2" />
                <asp:BoundField DataField="vfree3" HeaderText="������3" />
                <asp:BoundField DataField="pc" HeaderText="�̲�" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
