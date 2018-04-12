<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZYPDData.aspx.cs" Inherits="SiteBll_PDMan_ZYPDData" %>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>自由盘点单</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FormZypd.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" onload="Init();">
    <form id="form1" runat="server" method="post">
		<TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
				align="center" background="../../images/icon/topbg.gif" border="0">
				<TR>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" style="width: 2%"><IMG id="" style="CURSOR: hand" onclick="AddFull(1);" alt="全屏" src="../../images/icon/arrowleft.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG id="IMG1" style="CURSOR: hand" onclick="AddFull(0);" alt="返回" src="../../images/icon/arrowright.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="自由盘点查询"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="AddQuery();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">明细信息</label><IMG id="btnItem" style="CURSOR: hand" onclick="AddItems();" alt="展开" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE id="tblQuery" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <TD width="10%" style="height: 23px"><input name="checkbox" type="checkbox" id="chkCKH" onclick="GetCKH();" runat="server" />仓库</TD>
			                    <TD width="19%" align="left" style="height: 23px"><FONT face="宋体">
      <asp:DropDownList ID="drpCKH" runat="server" Width="95%" DataTextField="CKCKName" DataValueField="CKID"> </asp:DropDownList></FONT></TD>
			                    <TD width="13%" style="height: 23px">
                                    <input name="checkbox2" type="checkbox" id="chkZDR" onclick="GetZDR();" runat="server"/>制单人</TD>
			                    <TD width="15%" align="left" style="height: 23px">
                                    <asp:DropDownList ID="drpZDR" runat="server" Width="95%" Enabled="False" DataTextField="PDUSERName" DataValueField="PDUSER"> </asp:DropDownList></TD>
			                    <TD width="9%" style="height: 23px"><input name="checkbox2" type="checkbox" id="chkWCBZ" onclick="GetWCBZ();" runat="server">状态</TD>
			                    <TD width="11%" style="height: 23px">
                                    <asp:DropDownList ID="drpWCBZ" runat="server" Width="95%" Enabled="False"> 
                                        <asp:ListItem Value="0">新建</asp:ListItem>
                                        <asp:ListItem Value="1">执行</asp:ListItem>
                                        <asp:ListItem Value="2">完成</asp:ListItem>
                                    </asp:DropDownList></TD>
			                    <TD width="11.5%" style="height: 23px"><FONT face="宋体">
                                    </FONT></TD>
			                    <TD width="12.5%" style="height: 23px">
                                    &nbsp;</TD>
		                    </TR>
                            <tr>
                                <td style="height: 18px">
                                    <input name="chkMakeTime" type="checkbox" id="chkMakeTime" onclick="GetMakeTime();" runat="server"/>制单日期</td>
                                <td align="left" style="height: 18px">
                                    <asp:TextBox ID="MakeStartTime" runat="server" Width="80%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(MakeStartTime);" style="cursor: hand" />至</td>
                                <td><asp:TextBox ID="MakeEndTime" runat="server" Width="85%" Enabled="False"></asp:TextBox><img src="../../Images/icon/calendar.gif" onclick="calendar(MakeEndTime);" style="cursor: hand" /></td>
                                <td style="height: 18px">
                                    </td>
                                <td colspan="3" style="height: 18px">
        </td>
                                <td style="height: 18px">
                                    </td>
                            </tr>
                            <tr>
                                <td style="height: 18px">
                                </td>
                                <td align="left" colspan="2" style="height: 18px">
                                    &nbsp; &nbsp;<asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
      
      </td>
                                <td style="height: 18px">
                                    </td>
                                <td colspan="3" style="height: 18px">
                                    </td>
                                <td style="height: 18px">
                                </td>
                            </tr>
	         </TABLE>
  <uc2:PageControl id="PageControl1" runat="server">
                        </uc2:PageControl>
                        		<DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:98%;height:270px;overflow:auto;white-space:nowrap;align:center;">
                <asp:GridView ID="grvFYD" runat="server" AutoGenerateColumns="False"  Width="100%" >
                    <Columns>
                        <asp:BoundField HeaderText="日期" DataField="PDDay"  >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CKid" HeaderText="仓库">
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hw" HeaderText="货位">
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="itypename" HeaderText="类型" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="pdusername" HeaderText="操作人" SortExpression="ZJLDW" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PDTimeStar" HeaderText="操作时间" />
                        <asp:BoundField DataField="statusms" HeaderText="状态" />
                        <asp:BoundField DataField="pch" HeaderText="批次号" />
                        <asp:BoundField DataField="wlh" HeaderText="物料号" />
                        <asp:BoundField DataField="wlmc" HeaderText="物料名称" />
                        <asp:BoundField DataField="ph" HeaderText="牌号" />
                        <asp:BoundField DataField="gg" HeaderText="规格" />
                        <asp:BoundField DataField="sx" HeaderText="属性" />
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
                        <asp:BoundField DataField="zcsl" HeaderText="帐存数量" />
                        <asp:BoundField DataField="sl" HeaderText="数量" />
                        <asp:BoundField DataField="pc" HeaderText="盘差" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                    <FooterStyle BackColor="White" />
                </asp:GridView>
			</DIV>
					<TABLE class="fixColStyle" id="TABLE2" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<tr>
				    <td colspan="2" style="height: 22px">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <input id="hidFYDHitem" type="hidden" runat="server" />
                        <input id="hidStatus" type="hidden" runat="server" />
                        <input id="hidyslb" type="hidden" runat="server" />
                        <input id="hidItem" type="hidden" runat="server"/><input id="Hidconfig" type="hidden" runat="server"/><input id="hidQuery" runat="server" type="hidden" />
                        
                    </td>
				</tr>
			</TABLE>
    </form>
</body>
</html>
