<%@ Page Language="C#" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="ICManage.aspx.cs" Inherits="SiteBll_ICMan_ICManage" %>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<%--徐慧杰--%>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/ICMan.js" type="text/javascript">
	</script>
</head>
<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fixColStyle" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server" style="left: 0px; top: 0px">
				<TR>
					<TD colSpan="2" height="1"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"	align="center" background="../../images/icon/topbg.gif" border="0">
				<TR>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="90%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="IC卡管理"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" style="width: 2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="tblEdit" cellSpacing="0" cellPadding="0"  width="100%" align="center" border="0" runat="server" style="left: 0px; top: 0px">
				<TR>
					<TD style="HEIGHT: 19px" vAlign="bottom" align="left" width="12%" bgColor="#dce8f4">
						<font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">查询条件</font></TD>
					<TD style="HEIGHT: 19px; width: 88%;" vAlign="bottom" bgColor="#dce8f4"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">
                        注：可以组合查询</label></TD>
				</TR>
			</TABLE>
					    <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <TD width="10%" style="height: 25px">IC卡号</TD>
			                    <TD width="15%" align="left" style="height: 25px"><FONT face="宋体">
                                    <asp:TextBox ID="txtICIDSearch" runat="server" Width="100%"></asp:TextBox></FONT></TD>
			                    <TD style="height: 25px; width: 12%;">
                                    </TD>
			                    <TD align="left" style="width: 90px; text-align: center; height: 25px;">
                                    车牌号</TD>
			                    <TD style="height: 25px;">
                                    <%-- <bestcomy:ComboBox ID="DDlistSearchCPH" runat="server" Width="70%" Text="">
                                    </bestcomy:ComboBox>--%>
                                     <asp:DropDownList ID="DDlistSearchCPH" runat="server" Width="70%" >
                                    </asp:DropDownList>
                                    <%--                                    <asp:DropDownList ID="DDlistSearchCPH" runat="server" Width="100px">
                                    </asp:DropDownList>--%>

			                    </TD>
			                    <TD style="height: 25px; width: 121px;" align="center">申请人</TD>
			                    <TD style="height: 25px; width: 114px;"><FONT face="宋体"><asp:DropDownList ID="DDlistSearchProposer" runat="server" Width="100px">
                                </asp:DropDownList></FONT></TD>
		                    </TR>
		                    <TR>
		                        <TD><FONT face="宋体"/>客户</TD>
		                        <TD colspan="2" align="left">
                                    <asp:TextBox ID="txtKHNameSearch" runat="server" Width="80%"></asp:TextBox><img src="../../Images/icon/point.gif" ID="btnKHSearch"  onclick="KHSearch('searchKH')" style="CURSOR: hand" /></TD>
		                        <TD style="width: 90px">
                                    <input id="hidSICID" runat="server" type="hidden" style="width: 14px"/>
                                    <input id="hidKHID" runat="server" type="hidden" style="width: 14px"/>
                                    <input id="hidSProposer" runat="server" type="hidden" style="width: 16px" />
                                    <input id="hidKHBM" runat="server" type="hidden" style="width: 16px" />
                                    <input id="hidchild"  runat="server" type="hidden" style="width: 21px" />
                                    <input id="hidKHLB" runat="server" type="hidden" style="width: 16px"/>
                                    <input id="hidSKHName" runat="server" type="hidden" style="width: 16px" />
                                    <input id="hidsort" type="hidden" runat="server" style="width: 13px" />
                                    <input id="hidStrSort" runat="server" type="hidden" style="width: 16px" />
                                    <input id="DataT" runat="server" type="hidden" style="width: 15px" /></TD>
		                        <TD style="width: 148px"><FONT face="宋体">
		                        <input id="hidSCPH" runat="server" type="hidden" style="width: 17px" />
		                        <input id="hidCValue" runat="server" type="hidden" style="width: 17px" /></FONT></TD>
		                        <TD style="width: 121px"></TD>
		                        <TD style="width: 114px"><FONT face="宋体">
                                    <asp:ImageButton ID="btnSearchIC" ImageUrl="../../Images/icon/img25.gif" runat="server" OnClick="btnSearchIC_Click" /></FONT></TD>
	                        </TR>
	                    </TABLE>
			<DIV id="ListDiv" style="overflow:auto;white-space:nowrap; HEIGHT: 300px">
                <asp:GridView ID="grdInfo" runat="server"  AutoGenerateColumns="False" Width="100%" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="grdInfo_PageIndexChanging" OnSorting="grdInfo_Sorting" OnRowDataBound="grdInfo_RowDataBound">
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                <img src="../../Images/icon/choose.gif" onclick="SetModifyItem()" style="CURSOR: hand"/>
                                <input id="hidValue" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ICID") %>' />
                                <input id="hidUserDesc" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.UserDesc") %>'/>
                                <input id="hidProposerID" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ProposerID") %>'/>
                            </ItemTemplate>
                            <HeaderStyle Width="60px" />
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="KHID" SortExpression="KHID" HeaderText="客户编码" >
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <HeaderStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="KHName" SortExpression="KHID" HeaderText="客户" >
                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                            <HeaderStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CPH" SortExpression="CPH" HeaderText="车号" >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ICNumber" SortExpression="ICNumber" HeaderText="卡号" >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Flag" SortExpression="Flag" HeaderText="状态" >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FK_Time" SortExpression="FK_Time" HeaderText="发卡时间" >
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FK_User" SortExpression="FK_User" HeaderText="发卡人" >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Proposer" SortExpression="Proposer" HeaderText="申请人" >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZT_Time" SortExpression="ZT_Time" HeaderText="挂失时间" >
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZT_User" SortExpression="ZT_User" HeaderText="挂失人" >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页" />
                </asp:GridView>
			</DIV>
			<table id="ICsumtbl" style="width: 100%; background-color: #dce8f4;">
            <tr>
                <td align="right" style="width: 10%" valign="middle">
                总计：</td>
            <td align="right" style="width: 10%" valign="middle">
                <asp:Label ID="lblICsum" runat="server"></asp:Label></td>
                <td style="width: 70%"></td>
                </tr>
                </table>
	    <table width="100%" border="1" cellspacing="1" cellpadding="2">
          <tr>
            <td style="text-align: center; height: 13px;"><asp:Label ID="Label1" runat="server" Text="客户"></asp:Label></td>
            <td style="text-align: left; height: 13px;"><asp:TextBox ID="txtKHName" runat="server" Width="170px"></asp:TextBox>
                <img src="../../Images/icon/point.gif" ID="btnKHSearch2"  OnClick="KHSearch('FKSearchKH')" visible="false"  style="CURSOR: hand" /></td>
            <td style="text-align: center; height: 13px;"><asp:Label ID="Label2" runat="server" Text="IC卡ID"></asp:Label></td>
            <td style="text-align: center; height: 13px;"><asp:TextBox ID="txtICID" runat="server" TextMode="Password"></asp:TextBox></td>
            <td style="text-align: center; height: 13px;"><asp:Label ID="Label3" runat="server" Text="卡号"></asp:Label></td>
            <td style="text-align: center; height: 13px;"><asp:TextBox ID="txtICNumber" runat="server"></asp:TextBox></td>
            <td style="text-align: center; height: 13px;"><asp:Label ID="Label4" runat="server" Text="申请人"></asp:Label></td>
            <td style="text-align: center; height: 13px; width: 134px;"><asp:DropDownList ID="DDListProposer" runat="server" Width="100px">
                </asp:DropDownList></td>
          </tr>
          <tr>
            <td style="text-align: center; height: 37px;"><asp:Label ID="Label5" runat="server" Text="车牌号"></asp:Label></td>
            <td style="height: 37px"><asp:TextBox ID="txtCPH" runat="server" Width="195px"></asp:TextBox></td>
            <td style="text-align: center; height: 37px;">
                <asp:Label ID="lblPassOne" runat="server" Text="密码"></asp:Label></td>
            <td style="text-align: center; height: 37px;">
                <asp:TextBox ID="txtPassOne" runat="server" TextMode="Password"></asp:TextBox></td>
            <td style="text-align: center; height: 37px;">
                <asp:Label ID="lblPassTwo" runat="server" Text="密码确认"></asp:Label></td>
            <td style="text-align: center; height: 37px;">
                <asp:TextBox ID="txtPassTwo" runat="server" TextMode="Password"></asp:TextBox></td>
            <td style="text-align: center; height: 37px;"></td>
            <td style="text-align: center; height: 37px; width: 134px;"></td>
          </tr>
        </table>
        <table width="100%" border="1" cellspacing="1" cellpadding="2" style="background-color: #dce8f4">
          <tr>
            <td style="text-align: center">
                <asp:ImageButton  id="btnCheckFYD"  runat="server" ImageUrl="../../images/icon/chakanFYD.gif"/></td>
            <td style="text-align: center">
                <asp:ImageButton ID="btnPrint" ImageUrl="../../Images/icon/PrintExp.gif" runat="server"/></td>
            <td style="text-align: center"><asp:imagebutton id="btnICFK" runat="server" ToolTip="点击“发卡”，填写IC卡信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/ICFK.gif" OnClick="btnICFK_Click"/></td>
            <td style="text-align: center"><asp:imagebutton id="btnGS" runat="server" ToolTip="点击“挂失”，提交挂失信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/guashi.gif" OnClick="btnGS_Click"/></td>
            <td style="text-align: center"><asp:imagebutton id="btnHF" runat="server" ToolTip="点击“恢复”，提交恢复信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/GShuifu.gif" OnClick="btnHF_Click"/></td>
            <td style="text-align: center"><asp:imagebutton id="btnTK" runat="server" ToolTip="点击“退卡”，提交退卡信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/tuika.gif" OnClick="btnTK_Click"/></td>
			<td style="text-align: center"><asp:imagebutton id="imgCZ" runat="server" 
                    ToolTip="点击“重置”，重置密码。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/img12.gif" onclick="imgCZ_Click"/></td>
			<td style="text-align: center"><asp:imagebutton id="btnSaveFK" runat="server" ToolTip="点击“保存”，提交IC卡信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/save.gif" OnClick="btnSaveFK_Click"/></td>
			<td style="text-align: center; width: 98px;"><asp:imagebutton id="btnCancelFK" runat="server" ToolTip="点击“取消”，撤销发卡操作。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/img22.gif" OnClick="btnCancelFK_Click"/></td>
          </tr>
        </table>            
       </form>
</body>
</html>
