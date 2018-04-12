<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HCDayReport.aspx.cs" Inherits="SiteBll_Report_HCDayReport" %>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>货场日报表</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/FYDList.js" type="text/javascript"></script> 
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
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
					<TD vAlign="middle" align="center" width="92%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="货场日报表"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE id="TABLE2" class="fixColStyle" style="DISPLAY: none" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
    <table class="fixColStyle" id="tblQuery" width="100%" runat="server">
        <tr>
            <td style="height: 24px; width: 10%;">
                &nbsp;仓库：</td>
            <td style="height: 24px; width: 18%;" colspan="2">
                <asp:DropDownList ID="drpStore" runat="server" Width="95%" DataTextField="CKCKName" DataValueField="CKID">
                </asp:DropDownList></td>
            <td style="height: 24px; width: 8%;">
                &nbsp;选择日期：</td>
            <td style="height: 24px;width:20%">
                &nbsp;<asp:TextBox ID="txtTime" runat="server" Width="138px"></asp:TextBox><img onclick="calendar(txtTime);"
                    src="../../Images/icon/calendar.gif" style="cursor: hand" /></td>
            <td width="8%" style="height: 24px">
                排序方式：
             </td>
             <td width="16%" style="height: 24px">
                 <asp:DropDownList ID="drpOrderBy" runat="server" Width="95%">
                     <asp:ListItem Value="0">请选择</asp:ListItem>
                     <asp:ListItem Value="ph">牌号</asp:ListItem>
                     <asp:ListItem Value="gg">规格</asp:ListItem>
                     <asp:ListItem Value="qcsl">期初库存数量</asp:ListItem>
                     <asp:ListItem Value="qczl">期初库存重量</asp:ListItem>
                     <asp:ListItem Value="rkrjs">入库日数量</asp:ListItem>
                     <asp:ListItem Value="rkyljjs">入库累计数量</asp:ListItem>
                     <asp:ListItem Value="rkrzl">入库日重量</asp:ListItem>
                     <asp:ListItem Value="rkyljzl">入库累计重量</asp:ListItem>
                     <asp:ListItem Value="ckrjs">销售日数量</asp:ListItem>
                     <asp:ListItem Value="ckyljjs">销售累计数量</asp:ListItem>
                     <asp:ListItem Value="ckrzl">销售日重量</asp:ListItem>
                     <asp:ListItem Value="ckyljzl">销售累计重量</asp:ListItem>
                     <asp:ListItem Value="kcsl">库存数量</asp:ListItem>
                     <asp:ListItem Value="kczl">库存重量</asp:ListItem>
                     <asp:ListItem Value="clsl">超龄库存数量</asp:ListItem>
                     <asp:ListItem Value="clzl">超龄库存重量</asp:ListItem>
                     <asp:ListItem Value="dpsl">代判数量</asp:ListItem>
                     <asp:ListItem Value="xysl">协议数量</asp:ListItem>
                     <asp:ListItem Value="bhgsl">不合格数量</asp:ListItem>
                 </asp:DropDownList></td>
            <td width="10%" style="height: 24px">
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click"/>
                </td>
            <td width="10%" style="height: 24px">
                <img src="../../Images/icon/print.gif" onclick="OpenPrint();"/></td>
        </tr>
    </table>
    <div style="overflow:auto;width:1100px;height: 550px;">
    <table class="fixHeaderStyle" style="width:1360px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: gainsboro; font-weight: bold; font-size: 10pt;" id="tblGridHeadNew" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" rowspan="2" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 73px; border-bottom: black 1px solid" valign="middle">
                牌号</td>
                <td align="center" rowspan="2" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 72px; border-bottom: black 1px solid" valign="middle">
                规格</td>
                <td align="center" colspan="2" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; border-bottom: black 1px solid; height: 25px" valign="middle">
                    期初库存</td>
                <td align="center" colspan="4" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; border-bottom: black 1px solid; height: 25px" valign="middle">
                    入库</td>
                <td align="center" colspan="4" style="border-right: black 1px solid;
                border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;
                height: 25px" valign="middle">
                    销售</td>
                <td align="center" colspan="2" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; border-bottom: black 1px solid; height: 25px" valign="middle">
                    库存</td>
               <td align="center" colspan="2" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; border-bottom: black 1px solid; height: 25px" valign="middle">
                   超龄库存</td>
            <td style="height: 25px; border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid;" align="center" valign="middle" colspan="3">
                明细（件）</td>
               </tr>
        <tr>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 61px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                件</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 82px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                吨</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 63px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                日（件）</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                累（件）</td>
           <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 84px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
               吨（日）</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 81px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                吨（累）</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 62px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                日（件）</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 63px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                件（累）</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 82px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                吨（日）</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 82px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                吨（累）</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 61px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                件</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 82px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                吨</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 63px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                件</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 82px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                吨</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                待判</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 63px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                协议</td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 63px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                不合格</td>
            </tr>
    </table>
        <asp:GridView ID="grdDayReport" runat="server" AutoGenerateColumns="False" ShowHeader="False" Width="1360px" OnRowDataBound="grdDayReport_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="牌号">
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ph") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="gg" HeaderText="规格" >
                    <ItemStyle Width="70px" />
                    <HeaderStyle Width="70px" />
                </asp:BoundField>
                <asp:BoundField DataField="qcsl" HeaderText="件">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>   
                <asp:BoundField DataField="qczl" HeaderText="吨" >
                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="rkrjs" HeaderText="入日件">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="rkyljjs" HeaderText="入累件" >
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="rkrzl" HeaderText="入日吨">
                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="rkyljzl" HeaderText="入累吨">
                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="ckrjs" HeaderText="销日件">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="ckyljjs" HeaderText="销累件">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="ckrzl" HeaderText="销日吨">
                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="ckyljzl" HeaderText="销累吨">
                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="kcsl" HeaderText="库件">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="kczl" HeaderText="库吨">
                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="clsl" HeaderText="超件">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="clzl" HeaderText="超吨">
                    <ItemStyle Width="80px" HorizontalAlign="Right" />
                    <HeaderStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="dpsl" HeaderText="待判">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="xysl" HeaderText="协议">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
                <asp:BoundField DataField="bhgsl" HeaderText="不合格">
                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                    <HeaderStyle Width="60px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <table width="1360px">
            <tr>
                <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 71px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                </td>
            <td align="center" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 71px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                总计：</td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 59px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblSqcjs" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 80px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblSqczl" runat="server"></asp:Label></td>
           <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 61px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
               <asp:Label ID="lblSrcrjs" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblSrkljs" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 80px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblSrkrzl" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 80px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblSrklzl" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblXrjs" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblXljs" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 80px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblXrzl" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 80px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblXlzl" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblKCjs" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 80px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblKCzl" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblCljs" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 81px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblClzl" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblDp" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 60px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblXY" runat="server"></asp:Label></td>
            <td align="right" style="border-right: black 1px solid; border-top: black 1px solid;
                border-left: black 1px solid; width: 59px; border-bottom: black 1px solid; height: 25px"
                valign="middle">
                <asp:Label ID="lblBhg" runat="server"></asp:Label></td>
            </tr>
        </table>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    </div>
    </form>
</body>
</html>
