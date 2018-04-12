<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fyd_kyhw.aspx.cs" Inherits="SiteBll_FormMan_fyd_kyhw" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>发运单可用货位查看</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FormFYD.js" type="text/javascript"></script>
</head>
<body onload="javascript:loadkyhwinfo();">
    <form id="form1" runat="server">
  <div>
    <input type="hidden" id="hck" value="<%=Request["ck"] %>"/>
    <input type="hidden" id="hwlh" value="<%=Request["wlh"] %>"/>
    <input type="hidden" id="hsx" value="<%=Request["sx"] %>"/>
    <input type="hidden" id="hvfree1" value="<%=Request["vfree1"] %>"/>
    <input type="hidden" id="hvfree2" value="<%=Request["vfree2"] %>"/>
    <input type="hidden" id="hvfree3" value="<%=Request["vfree3"] %>"/>
    <input type="hidden" id="hfydh" value="<%=Request["fydh"] %>"/>
    可用货位信息:<asp:Label ID="Label1" runat="server" Text=""></asp:Label><br/>
    <table border="0">
    <tr><td>仓库</td><td><%=Request["ck"] %></td></tr>
    <tr><td>发运单号</td><td><%=Request["fydh"] %></td></tr>
    <tr><td>物料号</td><td><%=Request["wlh"] %></td></tr>
    <tr><td>属性</td><td><%=Request["sx"] %></td></tr>
    <tr><td>自由项1</td><td><%=Request["vfree1"] %></td></tr>
    <tr><td>自由项2</td><td><%=Request["vfree2"] %></td></tr>
    <tr><td>自由项3</td><td><%=Request["vfree3"] %></td></tr>
    </table>
     <div id="hwinfo" style="width:600px;height:250px; overflow:scroll;">
        <asp:GridView ID="grvFYD" runat="server" AllowSorting="True" AutoGenerateColumns="False"
             width="900px" BorderStyle="Inset" Visible=False>
            <Columns>
                <asp:BoundField DataField="CK" HeaderText="仓库">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="hw" HeaderText="货位" />
                <asp:BoundField DataField="WLH" HeaderText="物料号">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="WLMC" HeaderText="物料名称">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="pch" HeaderText="批次号" />
                <asp:BoundField DataField="SX" HeaderText="属性">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="PH" HeaderText="牌号">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="GG" HeaderText="规格">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="PCInfo" HeaderText="特殊信息">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="zls" HeaderText="重量">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="num" HeaderText="数量">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="vfree1" HeaderText="自由项1">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
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
        </asp:GridView>
        </div>
    </div>
   </form>
</body>
</html>
