<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InDoor.aspx.cs" Inherits="SiteBll_InDoor_InDoor" %>
<%--徐慧杰--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>进门管理</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="JAVASCRIPT" src="../../JavaScript/IndoorMan.js" type="text/javascript">
	</script>
	<script language="JAVASCRIPT" src="../../JavaScript/SysMan.js" type="text/javascript">
	</script>
	<script language="javascript" type="text/javascript">
	    function showdialog(icNum) {
	        window.showModalDialog('ChangeICPass.aspx?ICNUM=' + icNum,window, "dialogWidth:550px;dialogHeight:300px;status:no;help:no;scroll:no");
	        //window.open('ChangeICPass.aspx?ICNUM='+icNum, '修改密码', str)
	    }
	</script>
</head>
<body leftMargin="0" topMargin="0" onload="InitVisiable()">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fixColStyle" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0"
				runat="server">
				<TR>
					<TD colSpan="2" height="1"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0"
				align="center" background="../../images/icon/topbg.gif" border="0" style="left: 1px; top: 1px; width:99%;">
				<TR>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG id="" style="CURSOR: hand" onclick="AddFull(1);" alt="全屏" src="../../images/icon/arrowleft.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG id="IMG1" style="CURSOR: hand" onclick="AddFull(0);" alt="返回" src="../../images/icon/arrowright.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="90%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="进门管理"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" style="width: 2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
					    <TABLE id="Table3" width="100%" cellSpacing="1" cellPadding="1"  border="0">
		                    <TR>
			                    <TD style="width: 82px; height: 25px;" align="center">IC卡ID</TD>
			                    <TD align="center" style="width: 100px; height: 25px;"><FONT face="宋体">
                                    <asp:TextBox ID="txtICID" runat="server"  Width="140px" TextMode="Password"></asp:TextBox></FONT></TD>
			                    <TD style="width: 43px; height: 25px;" align="center">IC卡号</TD>
			                    <TD align="center" style="width: 100px; height: 25px;">
                                    <asp:TextBox ID="txtICNumber" runat="server" Width="120px" ></asp:TextBox></TD>
			                    <TD style="width: 70px; height: 25px;" align="center"><FONT face="宋体">车牌号</FONT></TD>
			                    <TD align="center" style="width: 100px; height: 25px;">
                                    <asp:TextBox ID="txtCPH" runat="server" Width="120px"></asp:TextBox></TD>
			                    <TD style="width: 41px; height: 25px;" align="center"><FONT face="宋体">密码</FONT></TD>
			                    <TD align="center" style="width: 136px; height: 25px">
                                    <asp:TextBox ID="txtPassword" runat="server" Width="100px" TextMode="Password"></asp:TextBox></TD>
		                    </TR>
		                    <TR>
		                        <TD style="width: 82px;" align="center">
                        <input id="hidCKDH" type="hidden"  runat="server" style="width: 1px" />
                                    <input id="hidICID"  type="hidden" runat="server" style="width: 1px" />
                                    <input id="hidICNumber" type="hidden"  runat="server" style="width: 1px; height: 15px" />
                                    <input id="hidCheckCPH" type="hidden"  runat="server" style="width: 2px; height: 14px" />
                                    <input id="hidVisable" type="hidden"  runat="server" style="width: 1px"/>
                                    <input id="hidPassword" type="hidden"  runat="server" style="width: 1px"/></TD>
		                        <TD colspan="2" align="center">
                                    <FONT face="宋体">
                        <input id="hidCValue" type="hidden" runat="server" style="width: 43px"/>
                                        <input id="hidCPH" type="hidden"  runat="server" style="width: 1px"/>
                                    <input id="hidCK" type="hidden"  runat="server" style="width: 1px"/>
                                        <input id="hidWLH" type="hidden"  runat="server" style="width: 1px" />
                                        <input id="hidSX" type="hidden"  runat="server" style="width: 1px"/>
                                    <input id="hidKHLB" type="hidden"  runat="server" style="width: 1px; height: 12px"/></FONT></TD>
		                        <TD align="center"></TD>
		                        <TD align="center"><FONT face="宋体"></FONT></TD>
		                        <TD style="width: 100px;" align="center"></TD>
		                        <TD align="center" style="width: 41px;">
                                    </TD>
		                        <td style="width: 136px;" align="center"><FONT face="宋体"><asp:imagebutton id="btnSumbit" runat="server" ToolTip="点击“确认”，提交新建信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/img25.gif" OnClick="btnSumbit_Click" TabIndex="22"></asp:imagebutton></FONT></td>
	                        </TR>
	                    </TABLE>
			<TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server" style="left: 0px; top: 0px">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" style="height: 20px"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细信息</font></TD>
					<TD vAlign="bottom" width="97%" bgColor="#dce8f4" style="height: 20px"></TD>
				</TR>
			</TABLE>
			<div style="overflow:auto;width:100%;height: 250px;white-space:nowrap;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                <input id="chkFYDslc" type="checkbox" runat="server" onclick="SetFYD()" />
                                <input id="hidFYDslc" type="hidden"/>       
                                <input id="slcCKDH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.CKDH") %>'/>
                                <input id="slcWLH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.WLH") %>'/>                         
                            </ItemTemplate>
                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="发运单号" DataField="FYDH" >
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="状态" DataField="status">
                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                            <HeaderStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="车牌号" DataField="CPH" >
                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                            <HeaderStyle Width="60px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="客户名称" DataField="KHBM" >
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                            <HeaderStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="CK" >
                            <ItemStyle HorizontalAlign="Left" Width="30px" />
                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC" >
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX" >
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="计划数量" DataField="JHSL" >
                            <ItemStyle HorizontalAlign="Right" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="计划重量" DataField="JHZL" >
                            <ItemStyle HorizontalAlign="Right" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="制单人" DataField="NCZDRY" >
                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                            <HeaderStyle Width="50px" HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
                </asp:GridView>
			</div>
		   <table width="100%" style="background-color: #dce8f4">
            <tr>
                <td align="right" style=" width:15%"
                valign="right">
                    发运单条数总计:</td>
            <td align="left" style=" width:15%" valign="left">
                <asp:Label ID="lblFYDsum" runat="server"></asp:Label></td>
                <td style="width:70%;"></td></tr>
        </table>
        <table border="1" style="background-color: #dce8f4; width:100%;">
          <tr>
            <td style="width:20%; height: 4px; text-align: center;"><Img src="../../Images/icon/print.gif" ID="btnPrint"  onclick="openPrintPage()"  style="CURSOR: hand"/>
                <%--<asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../../Images/icon/print.gif" OnClick="btnPrint_Click"/>--%></td>
            <td style="width:20%; height: 4px; text-align: center;"><asp:ImageButton ID="btnAllowInDoor" runat="server" ImageUrl="../../Images/icon/AllowInDoor.gif"
                    OnClick="btnAllowInDoor_Click" /></td>
            <td style="width:20%; height: 4px; text-align: center;"><asp:ImageButton ID="btnshuaka2" runat="server" ImageUrl="../../Images/icon/shuaka2.gif"
                    OnClick="btnshuaka2_Click" /></td>
            <td style="width:20%; height: 4px; text-align: center;"><img id="btnCheckFYD" onclick="CheckFYD()" src="../../images/icon/chakanFYD.gif"
                    style="cursor: hand" /></td>
            <td  style="width:20%; height: 4px; text-align: center;"><img id="btnModifyPassword" onclick="ModifyPage()" src="../../images/icon/xiugaimima.gif"
                    style="cursor: hand" /></td>
          </tr>
        </table>
        </form>
</body>
</html>
