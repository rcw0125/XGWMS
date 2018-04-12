<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckFYD.aspx.cs" Inherits="SiteBll_InDoor_CheckFYD" %>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发运单查询</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/IndoorMan.js" type="text/javascript"></script>
</head>
<body leftmargin="0" topmargin="0">
<form id="form1" runat="server">
      <div style="overflow:auto;width:100%;height: 500px;white-space:nowrap;">
      <asp:GridView ID="grdFYD" runat="server"  width="1200px" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdFYD_PageIndexChanging" AllowSorting="True" OnSorting="grdFYD_Sorting" PageSize="15" OnDataBound="grdFYD_DataBound">
              <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
              <Columns>              
                  <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                               <%-- <Img src="../../Images/icon/choose.gif" ID="imgBtnslc" runat="server" onclick="SetFYDItem()" style="CURSOR: hand"/>
                                <input id="hidValue" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.FYDH") %>' />--%>
                                <input id="Checkbox1" type="checkbox" runat="server" onclick="SetCheckFYD()"/>
                            </ItemTemplate>
                           <HeaderStyle Width="30px" HorizontalAlign="Center" />
                      <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                  <asp:BoundField DataField="FYDH" SortExpression="FYDH" HeaderText="发运单号" >
                      <ItemStyle Width="70px" HorizontalAlign="Left" />
                      <HeaderStyle Width="70px" HorizontalAlign="Center" />
                  </asp:BoundField>
                  
                  <asp:BoundField DataField="status" SortExpression="status" HeaderText="状态" >
                      <ItemStyle Width="70px" HorizontalAlign="Left" />
                      <HeaderStyle Width="70px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="KHName" SortExpression="KHName" HeaderText="客户名称" >
                      <ItemStyle Width="200px" HorizontalAlign="Left" />
                      <HeaderStyle Width="200px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="WLMC" SortExpression="WLMC" HeaderText="物料名称" >
                      <ItemStyle Width="70px" HorizontalAlign="Left" />
                      <HeaderStyle Width="70px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="SX" SortExpression="SX" HeaderText="属性" >
                      <ItemStyle Width="70px" HorizontalAlign="Left" />
                      <HeaderStyle Width="70px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="CPH" SortExpression="CPH" HeaderText="车牌号" >
                      <ItemStyle Width="70px" HorizontalAlign="Left" />
                      <HeaderStyle Width="70px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="CK" SortExpression="CK" HeaderText="仓库" >
                      <ItemStyle Width="30px" HorizontalAlign="Left" />
                      <HeaderStyle Width="30px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="JHSL" SortExpression="JHSL" HeaderText="应发数" >
                      <ItemStyle Width="50px" HorizontalAlign="Right" />
                      <HeaderStyle Width="50px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="SJSL" SortExpression="SJSL" HeaderText="实发数" >
                      <ItemStyle Width="50px" HorizontalAlign="Right" />
                      <HeaderStyle Width="50px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="JHZL" SortExpression="JHZL" HeaderText="应发重" >
                      <ItemStyle Width="50px" HorizontalAlign="Right" />
                      <HeaderStyle Width="50px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="SJZL" SortExpression="SJZL" HeaderText="实发重" >
                      <ItemStyle Width="50px" HorizontalAlign="Right" />
                      <HeaderStyle Width="50px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="CZ_InTime" SortExpression="CZ_InTime" HeaderText="进厂时间" >
                      <ItemStyle Width="150px" HorizontalAlign="Left" />
                      <HeaderStyle Width="150px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="CZ_OtTime" SortExpression="CZ_OtTime" HeaderText="出厂时间" >
                      <ItemStyle Width="150px" HorizontalAlign="Left" />
                      <HeaderStyle Width="150px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="CZ_InUser" SortExpression="CZ_InUser" HeaderText="进厂人员" >
                      <ItemStyle Width="70px" HorizontalAlign="Left" />
                      <HeaderStyle Width="70px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="CZ_OtUser" SortExpression="CZ_OtUser" HeaderText="出厂人员" >
                      <ItemStyle Width="70px" HorizontalAlign="Left" />
                      <HeaderStyle Width="70px" HorizontalAlign="Center" />
                  </asp:BoundField>

                  <asp:BoundField DataField="NCZDRY" SortExpression="NCZDRY" HeaderText="制单人" >
                      <ItemStyle Width="50px" HorizontalAlign="Left" />
                      <HeaderStyle Width="50px" HorizontalAlign="Center" />
                  </asp:BoundField>

              </Columns>
          <PagerSettings FirstPageText="第一页" LastPageText="最后一页" Mode="NextPreviousFirstLast"
              NextPageText="下一页" PreviousPageText="上一页" />
          </asp:GridView>
          </div>
          <TABLE width="100%" style="background-color: #dce8f4"><TR><TD style=" width:10%" vAlign=middle align=right>
              发运单总数:</TD>
          <TD style="width:10%" vAlign=middle align=left><asp:Label id="lblFYDsum" runat="server"></asp:Label></TD>
          <TD style="width:10%" vAlign=middle align=right>应发数:</TD>
          <TD style="width:10%" vAlign=middle align=left><asp:Label id="lblJHSL" runat="server"></asp:Label></TD>
          <TD style="width:10%" vAlign=middle align=right>实发数:</TD>
          <TD style="width:10%" vAlign=middle align=left><asp:Label id="lblSJSL" runat="server"></asp:Label></TD>
          <TD style="width:10%" vAlign=middle align=right>应发重:</TD>
          <TD style="width:10%" vAlign=middle align=left><asp:Label id="lblJHZL" runat="server"></asp:Label></TD>
          <TD style="width:10%" vAlign=middle align=right>实发重:</TD>
          <TD style="width:10%" vAlign=middle align=left><asp:Label id="lblSJZL" runat="server"></asp:Label></TD>
          </TR>
          </TABLE>
<table width="100%" border="1" style="left: 0px; top: 0px; background-color: #dce8f4;">
        <tr>
          <td style="width: 12.5%; text-align: center;">
              <%--<input id="chkStatus" type="checkbox" style="display:none" onclick="GetStatus()"/>--%>状态</td>
          <td style="width: 12.5%; text-align: left;"><asp:DropDownList ID="drpStatus" runat="server" Width="80%">
              <asp:ListItem>请选择</asp:ListItem>
              <asp:ListItem Value="0">尚未执行</asp:ListItem>
              <asp:ListItem Value="1">已入厂</asp:ListItem>
              <asp:ListItem Value="2">装车完毕</asp:ListItem>
              <asp:ListItem Value="3">已出厂</asp:ListItem>
              <asp:ListItem Value="4">作废</asp:ListItem>
              <asp:ListItem Value="5">正在装车</asp:ListItem>
          </asp:DropDownList>
              <input id="hidStatus" type="hidden" runat="server"/><%--<input id="hidStatus" runat="server" type="hidden"/>--%></td>
          <td style="width: 12.5%; text-align: center;">
              日期</td>
          <td style="width: 12.5%; text-align:left;">
              <asp:TextBox ID="txtRQStart" runat="server" Width="80%"></asp:TextBox>
              <img src="../../Images/icon/calendar.gif" onclick="calendar(txtRQStart)" style="cursor: hand" />
              <input id="hidRQStart" type="hidden" runat="server"/></td>
          <td style="width: 12.5%; text-align: center;">
              ----至----</td>
          <td style="width: 12.5%; text-align: left;">
              <asp:TextBox ID="txtRQEnd" runat="server" Width="80%"></asp:TextBox>
              <img src="../../Images/icon/calendar.gif" onclick="calendar(txtRQEnd)" style="cursor: hand" />
              <input id="hidRQEnd" type="hidden" runat="server"/></td>
        </tr>
        <tr>
          <td style="width: 12.5%; text-align: center;">
              <asp:RadioButtonList ID="RadioInOut" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True">进</asp:ListItem>
                  <asp:ListItem>出</asp:ListItem>
              </asp:RadioButtonList></td>
          <td style="width: 12.5%; text-align: left;"><asp:DropDownList ID="drpCZ_User" runat="server" Width="80%"></asp:DropDownList>
              <input id="hidInOt" type="hidden" runat="server"/>
              <input id="hidCZ_User" type="hidden" runat="server"/></td>
          <td style="width: 12.5%; text-align: center;">
              发运单号</td>
          <td style="width: 12.5%; text-align: left;">
              <bestcomy:ComboBox ID="drpFYDH" runat="server" Width="95%">
              </bestcomy:ComboBox></td>
          <td style="width: 12.5%; text-align: center;">
              车牌号</td>
          <td style="width: 12.5%; text-align: left;"><asp:TextBox ID="txtCPH" runat="server" Width="80%"></asp:TextBox>
              <input id="hidCPH" type="hidden" runat="server"/></td>
        </tr>
        <tr>
          <td style="width: 12.5%; text-align: center;"><asp:ImageButton ID="btnQueryFYD" ImageUrl="../../Images/icon/img25.gif" runat="server" OnClick="btnQueryFYD_Click" /></td>
          <td style="width: 12.5%; text-align: center;"><Img src="../../Images/icon/print.gif" ID="btnPrintFYD" onclick="PrintFYD()" style="CURSOR: hand"/></td>
          <td style="width: 12.5%; text-align: center;"><asp:ImageButton ID="btnCancelInDoor" ImageUrl="../../Images/icon/cancelInDoor.gif" runat="server" OnClick="btnCancelInDoor_Click" />
              <input id="hidCheckFYDSlc" type="hidden"  runat="server"/></td>
          <td style="width: 12.5%; text-align: center;"><Img src="../../Images/icon/quit.gif" ID="btnExit" onclick="CloseCheckFYD()" style="cursor: hand"/></td>
          <td style="width: 12.5%; text-align: center;">
              <input id="hidFYDH" type="hidden" runat="server" style="width: 8px"/>
              <input id="hidsort" type="hidden"  runat="server" style="width: 13px"/>
              <input id="hidStrSort" type="hidden" runat="server" style="width: 10px"/></td>
          <td style="width: 12.5%; text-align: center;"></td>
        </tr>
      </table>
</form>
<%--		<script language="JAVASCRIPT">
			LoapFYD();
		</script>--%>
</body>
</html>
