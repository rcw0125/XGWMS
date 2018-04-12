<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CuPan.aspx.cs" Inherits="SiteBll_PDMan_CuPan" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>盘点粗盘单</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="JAVASCRIPT" src="../../JavaScript/PDMan.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fixColStyle" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0"
				runat="server">
				<TR>
					<TD colSpan="2" style="height: 1px"></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
				align="center" background="../../images/icon/topbg.gif" border="0">
				<TR>
					<TD vAlign="middle" align="center" width="2%" style="height: 28px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 28px"><IMG id="" style="CURSOR: hand" onclick="AddFull(1);" alt="全屏" src="../../images/icon/arrowleft.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 28px"><IMG id="IMG1" style="CURSOR: hand" onclick="AddFull(0);" alt="返回" src="../../images/icon/arrowright.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 28px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" style="width: 60%; height: 28px"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="盘点粗盘单"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 28px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
					<table border="0">
                      <tr>
                        <td style="width: 64px; text-align: center; height: 40px;">
                            原始单号</td>
                        <td style="width: 91px; text-align: center; height: 40px;">
                        <table width="100%" border="0">
                          <tr>
                            <td style="width: 80%; text-align: center">
                                <asp:TextBox ID="txtYSDH" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 20%; text-align: center">
                                <img src="../../Images/icon/point.gif" ID="btnYSDHSearch" onclick="OpenYSDHWindow('粗盘');" style="CURSOR: hand; width: 21px; height: 21px;" /></td>
                          </tr>
                        </table>
                        </td>
                        <td style="width: 70px; text-align: center; height: 40px;">
                            盘点单号</td>
                        <td style="width: 100px; text-align: center; height: 40px;">
                        <table width="100%" border="0">
                          <tr>
                            <td style="width: 80%; text-align: center; height: 24px;">
                                <asp:TextBox ID="txtPDDH" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                            <td style="width: 20%; text-align: center; height: 24px;">
                                <IMG style="CURSOR: hand" id="btnPDDHSearch" src="../../Images/icon/point.gif" onclick="OpenPDDHWindow('粗盘');"/></td>
                          </tr>
                        </table>
                        </td>
                        <td style="width: 57px; text-align: center; height: 40px;">
                            仓库<input id="hidCKID" runat="server" type="hidden" style="width: 29px" /></td>
                        <td style="width: 109px; text-align: center; height: 40px;">
                            <asp:TextBox ID="txtCK" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 65px; text-align: center; height: 40px;">
                            盘点日期</td>
                        <td style="width: 127px; text-align: center; height: 40px;">
                            <asp:TextBox ID="txtPDRQ" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 71px; text-align: center; height: 40px;">
                            单据状态</td>
                        <td style="width: 115px; text-align: center; height: 40px;">
                            <asp:TextBox ID="txtDJZT" runat="server" Width="81px" ReadOnly="True"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td style="width: 64px; text-align: center; height: 27px;">
                            制单日期</td>
                        <td style="width: 91px; text-align: center; height: 27px;">
                            <asp:TextBox ID="txtZDRQ" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 70px; text-align: center; height: 27px;">
                            制单人</td>
                        <td style="width: 100px; text-align: center; height: 27px;">
                            <asp:TextBox ID="txtZDRY" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 57px; text-align: center; height: 27px;">
                            审核人</td>
                        <td style="width: 109px; height: 27px;">
                            <asp:TextBox ID="txtSHRY" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 65px; text-align: center; height: 27px;">
                            审核日期</td>
                        <td style="width: 127px; height: 27px;">
                            <asp:TextBox ID="txtSHRQ" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                        <td style="width: 71px; text-align: center; height: 27px;">
                            <input id="hidDJLX" runat="server" type="hidden" style="width: 1px"/>
                        <input id="hidSearch" runat="server" type="hidden" style="width: 1px" /></td>
                        <td style="width: 115px; text-align: center; height: 27px;">
                            <%--<asp:ImageButton ID="btnSearch" ImageUrl="../../Images/icon/img25.gif"  runat="server" OnClick="btnSearch_Click" />--%>
                            <input id="hidXJDJ" runat="server" type="hidden" style="width: 1px"/>
                            <input id="hidYSDH" runat="server" type="hidden" style="width: 1px"/></td>
                      </tr>
                    </table>
			<TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 12%;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细信息</font></TD>
					<TD vAlign="bottom" bgColor="#dce8f4" style="font-size: 9pt; height: 20px; width: 97%;"></TD>
				</TR>
			</TABLE>
<DIV id="ListDiv" style="overflow:auto;white-space:nowrap; HEIGHT: 250px">
			<asp:GridView ID="grdInfo" runat="server" AutoGenerateColumns="False" Width="98%" Height="2px">
                    <Columns>
                        <asp:BoundField HeaderText="货位号" DataField="HW">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="物料名称" DataField="WLMC">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="批号" DataField="PCH">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="牌号" DataField="PH">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="规格" DataField="GG">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="属性" DataField="SX">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
                        <asp:BoundField HeaderText="帐存数量" DataField="ZCSL">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="实存数量" DataField="SPSL">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="盘差" DataField="PDCY">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="计量单位" DataField="JLDW">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="帐存重量" DataField="ZCZL">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="实盘重量" DataField="SPZL">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量单位" DataField="ZLDW">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
                </asp:GridView>
                </DIV><TABLE class="fixColStyle" id="Table2" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
                    <TR>
                        <TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 10%;">
                            <font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;货位</font></td>
                        <TD vAlign="bottom" bgColor="#dce8f4" style="font-size: 9pt; height: 20px; width: 97%;">
                            </td>
                    </tr>
                </table>
<table border="0" style="width: 99%">
    <tr><td style="width:25%;text-align: center; height: 16px;">
        未分配货位</td><td style="width:25%;text-align: center; height: 16px;"></td><td style="width:25%;text-align: center; height: 16px;">
            已分配货位</td><td style="width:23%;text-align: center; height: 16px;">
                </td></tr>
      <tr>
        <td style="width:25%;text-align: center">
            <asp:ListBox ID="ListBox1" runat="server" Width="60%" Height="107px"></asp:ListBox></td>
        <td style="width:25%;text-align: center"><table width="100%" border="0">
          <tr>
            <td style="height: 14px; text-align: center">
                <br />
                <%--<Img src="../../Images/icon/leftJT.gif" ID="btnGoRight" runat="server" onclick="GotoLst2();" style="CURSOR: hand"/>--%>
                <asp:ImageButton ID="btnGoRight" ImageUrl="../../Images/icon/leftJT.gif" runat="server" OnClick="btnGoRight_Click"/></td>
          </tr>
          <tr>
            <td style="height: 14px; text-align: center">
                <br />
                <%--<Img src="../../Images/icon/rightJT.gif" ID="btnGoLeft"  runat="server" onclick="GotoLst1();" style="CURSOR: hand"/>--%>
                <asp:ImageButton ID="btnGoLeft" ImageUrl="../../Images/icon/rightJT.gif" runat="server" OnClick="btnGoLeft_Click"/></td>
          </tr>
          <tr>
            <td style="height: 14px; text-align: center">
                <br />
                <asp:ImageButton ID="btnGoOK" ImageUrl="../../Images/icon/img20.gif" runat="server" OnClick="btnGoOK_Click"/></td>
          </tr>
        </table></td>
        <td style="width:25%;text-align: center">
            <asp:ListBox ID="ListBox2" runat="server" Width="60%" Height="109px"></asp:ListBox>
            <asp:ListBox ID="ListBox3" runat="server" Visible="false" Width="1%" Height="1px"></asp:ListBox>
            <input id="hidnum" runat="server" type="hidden" style="width: 1px; height: 1px;"/></td>
        <td style="width:23%;text-align: center">
            &nbsp;<img src="../../Images/icon/weipanhuowei.gif" id="btnWPHW" onclick="OpenWPHWpage()" style="CURSOR: hand"/></td>
      </tr>
    </table>
    <table border="0" style="width: 98%">
      <tr>
        <td style="text-align: center"><asp:ImageButton ID="btnAddPDD" ImageUrl="../../Images/icon/imgNew1.gif" runat="server" OnClick="btnAddPDD_Click" />
            <input id="hidState" style="width: 1px" type="hidden" runat="server" /></td>
        <td style="text-align: center"><asp:ImageButton ID="btnModifyPDD" ImageUrl="../../Images/icon/srelation.gif" runat="server" OnClick="btnModifyPDD_Click" /></td>
        <td style="text-align: center;"><asp:ImageButton ID="btnDeletePDD" ImageUrl="../../Images/icon/img19.gif" runat="server" OnClick="btnDeletePDD_Click" /></td>
        <td style="text-align: center"><asp:ImageButton ID="btnPrintPDD" ImageUrl="../../Images/icon/print.gif" runat="server" /></td>
        <td style="text-align: center"><asp:ImageButton ID="btnShenhePDD" ImageUrl="../../Images/icon/shenhe.gif" runat="server" OnClick="btnShenhePDD_Click" /></td>
        <td style="text-align: center"><asp:ImageButton ID="btnSavePDD" ImageUrl="../../Images/icon/save.gif" runat="server" OnClick="btnSavePDD_Click" Enabled="false"/></td>
        <td style="text-align: center;"><asp:ImageButton ID="btnCancelPDD" ImageUrl="../../Images/icon/img22.gif" runat="server" OnClick="btnCancelPDD_Click" Enabled="false"/></td>
        <td style="text-align: center;"><asp:ImageButton ID="btnlast" ImageUrl="../../Images/icon/btnlast.gif" runat="server" OnClick="btnlast_Click"/></td>
        <td style="text-align: center"><asp:ImageButton ID="btnnext" ImageUrl="../../Images/icon/btnnext.gif" runat="server" OnClick="btnnext_Click"/></td>
        <td style="text-align: center;"><asp:ImageButton ID="btnFangkaiPDD" ImageUrl="../../Images/icon/fangkai.gif" runat="server" OnClick="btnFangkaiPDD_Click" /></td>
      </tr>
    </table>
		</form>
	</body>
</html>
