<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChouPan.aspx.cs" Inherits="SiteBll_PDMan_ChouPan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>盘点抽盘单</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="JAVASCRIPT" src="../../JavaScript/PDMan.js" type="text/javascript">
	</script>
</head>
<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fixColStyle" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0"
				runat="server">
				<TR>
					<TD colSpan="2" height="1"></TD>
				</TR>
			</TABLE>
            <table id="Table1" align="center" background="../../images/icon/topbg.gif" border="0"
                cellpadding="0" cellspacing="0" class="fixColStyle" height="28" width="100%">
                <tr>
                    <td align="center" style="height: 28px" valign="middle" width="2%">
                        <img align="textTop" src="../../images/icon/compartcenter.gif" />
                    </td>
                    <td align="center" style="height: 28px" valign="middle" width="2%">
                        <img id="" align="textTop" alt="全屏" border="0" onclick="AddFull(1);" src="../../images/icon/arrowleft.gif"
                            style="cursor: hand" />
                    </td>
                    <td align="center" style="height: 28px" valign="middle" width="2%">
                        <img id="IMG1" align="textTop" alt="返回" border="0" onclick="AddFull(0);" src="../../images/icon/arrowright.gif"
                            style="cursor: hand" />
                    </td>
                    <td align="center" style="height: 28px" valign="middle" width="2%">
                        <img align="textTop" src="../../images/icon/compartcenter.gif" />
                    </td>
                    <td align="center" style="width: 60%; height: 28px" valign="middle">
                        <font style="font-size: 12px; color: #072d52; font-family: 宋体">
                            <asp:Literal ID="m_labTitle" runat="server" Text="盘点抽盘单"></asp:Literal></font></td>
                    <td align="center" style="width: 2%; height: 28px" valign="middle">
                        <img align="textTop" src="../../images/icon/compartcenter.gif" />
                    </td>
                </tr>
            </table>
            <table border="0">
                <tr>
                    <td style="width: 64px; height: 40px; text-align: center">
                            原始单号</td>
                    <td style="width: 91px; height: 40px; text-align: center">
                        <table border="0" width="100%">
                            <tr>
                                <td style="width: 80%; text-align: center">
                                    <asp:TextBox ID="txtYSDH" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 20%; text-align: center">
                                    <img id="btnYSDHSearch" onclick="OpenYSDHWindow('抽盘');" src="../../Images/icon/point.gif" style="width: 21px;
                                        cursor: hand; height: 21px" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 70px; height: 40px; text-align: center">
                            盘点单号</td>
                    <td style="width: 100px; height: 40px; text-align: center">
                        <table border="0" width="100%">
                            <tr>
                                <td style="width: 80%; height: 24px; text-align: center">
                                    <asp:TextBox ID="txtPDDH" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 20%; height: 24px; text-align: center">
                                    <img id="btnPDDHSearch" onclick="OpenPDDHWindow('抽盘');" src="../../Images/icon/point.gif" style="cursor: hand" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 57px; height: 40px; text-align: center">
                            仓库<input id="hidCKID" runat="server" style="width: 1px" type="hidden" /></td>
                    <td style="width: 109px; height: 40px; text-align: center">
                        <asp:TextBox ID="txtCK" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 65px; height: 40px; text-align: center">
                            盘点日期</td>
                    <td style="width: 127px; height: 40px; text-align: center">
                        <asp:TextBox ID="txtPDRQ" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 74px; height: 40px; text-align: center">
                            单据状态</td>
                    <td style="width: 115px; height: 40px; text-align: center">
                        <asp:TextBox ID="txtDJZT" runat="server" Width="79px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 64px; height: 27px; text-align: center">
                            制单日期</td>
                    <td style="width: 91px; height: 27px; text-align: center">
                        <asp:TextBox ID="txtZDRQ" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 69px; height: 27px; text-align: center">
                            制单人</td>
                    <td style="width: 100px; height: 27px; text-align: center">
                        <asp:TextBox ID="txtZDRY" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 57px; height: 27px; text-align: center">
                            审核人</td>
                    <td style="width: 109px; height: 27px">
                        <asp:TextBox ID="txtSHRY" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 65px; height: 27px; text-align: center">
                            审核日期</td>
                    <td style="width: 127px; height: 27px">
                        <asp:TextBox ID="txtSHRQ" runat="server" Width="100px" ReadOnly="True"></asp:TextBox></td>
                    <td style="width: 74px; height: 27px; text-align: center">
                        <input id="hidDJLX" runat="server" style="width: 1px" type="hidden" />
                        <input id="hidSearch" runat="server" style="width: 1px" type="hidden" /></td>
                    <td style="width: 115px; height: 27px; text-align: center">
                        <%--<asp:ImageButton ID="btnSearch" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="btnSearch_Click"/>--%>
                        <input id="hidXJDJ" runat="server" style="width: 1px" type="hidden" />
                        <input id="hidYSDH" runat="server" style="width: 1px" type="hidden" /></td>
                </tr>
            </table>
			<TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0" align="center" border="0" runat="server" style="width: 100%">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 952px;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细信息</font></TD>
				</TR>
			</TABLE>
            <div id="ListDiv" style="overflow: auto; white-space: nowrap; height: 250px">
                <asp:GridView ID="grdInfo" runat="server" AutoGenerateColumns="False" Height="2px"
                    Width="98%">
                    <Columns>
                        <asp:BoundField DataField="HW" HeaderText="货位号">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BARCODE" HeaderText="单卷号">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLMC" HeaderText="物料名称">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PCH" HeaderText="批号">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PH" HeaderText="牌号">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GG" HeaderText="规格">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" HeaderText="属性">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" />
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" />
                        <asp:BoundField DataField="ZCSL" HeaderText="帐存数量">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPSL" HeaderText="实存数量">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PDCY" HeaderText="盘差">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JLDW" HeaderText="计量单位">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZL" HeaderText="重量">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZLDW" HeaderText="重量单位">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
                </asp:GridView>
            </div>
            <table id="Table2" runat="server" align="center" border="0" cellpadding="0" cellspacing="0"
                class="fixColStyle" width="100%">
                <tr>
                    <td align="left" bgcolor="#dce8f4" style="width: 10%; height: 20px" valign="bottom">
                        <font style="font-size: 12px; color: #082c50; font-family: 宋体">&nbsp;货位</font></td>
                </tr>
            </table>
            <table border="0" style="width: 100%">
                <tr>
                    <td style="width: 25%; height: 16px; text-align: center">
        未分配货位</td>
                    <td style="width: 25%; height: 16px; text-align: center">
                    </td>
                    <td style="width: 25%; height: 16px; text-align: center">
            已分配货位</td>
                    <td style="width: 23%; height: 16px; text-align: center">
            </td>
                </tr>
                <tr>
                    <td style="width: 25%; text-align: center">
                        <asp:ListBox ID="ListBox1" runat="server" Height="107px" Width="60%"></asp:ListBox></td>
                    <td style="width: 25%; text-align: center">
                        <table border="0" width="100%">
                            <tr>
                                <td style="height: 14px; text-align: center">
                                    <br />
                                    <%--<Img src="../../Images/icon/leftJT.gif" ID="btnGoRight" runat="server" onclick="GotoLst2();" style="CURSOR: hand"/>--%>
                                    <asp:ImageButton ID="btnGoRight" runat="server" ImageUrl="../../Images/icon/leftJT.gif" OnClick="btnGoRight_Click"/></td>
                            </tr>
                            <tr>
                                <td style="height: 14px; text-align: center">
                                    <br />
                                    <%--<Img src="../../Images/icon/rightJT.gif" ID="btnGoLeft"  runat="server" onclick="GotoLst1();" style="CURSOR: hand"/>--%>
                                    <asp:ImageButton ID="btnGoLeft" runat="server" ImageUrl="../../Images/icon/rightJT.gif" OnClick="btnGoLeft_Click"/></td>
                            </tr>
                            <tr>
                                <td style="height: 14px; text-align: center">
                                    <br />
                                    <asp:ImageButton ID="btnGoOK" runat="server" ImageUrl="../../Images/icon/img20.gif" OnClick="btnGoOK_Click"/></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 25%; text-align: center">
                        <asp:ListBox ID="ListBox2" runat="server" Height="109px" Width="60%"></asp:ListBox>
                        <input id="hidnum" runat="server" type="hidden" style="width: 1px; height: 2px;"/>
                        <asp:ListBox ID="ListBox3" runat="server" Visible="false" Width="1%" Height="1px"></asp:ListBox></td>
                    <td style="width: 23%; text-align: center">
                        <img id="btnWPHW" onclick="OpenWPHWpage()" src="../../Images/icon/weipanhuowei.gif"
                            style="cursor: hand" /></td>
                </tr>
            </table>
            <table border="0" style="width: 100%">
                <tr>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnAddPDD" runat="server" ImageUrl="../../Images/icon/imgNew1.gif" OnClick="btnAddPDD_Click"/>
                        <input id="hidState" runat="server" style="width: 1px" type="hidden" /></td>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnModifyPDD" runat="server" ImageUrl="../../Images/icon/srelation.gif" OnClick="btnModifyPDD_Click"/></td>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnDeletePDD" runat="server" ImageUrl="../../Images/icon/img19.gif" OnClick="btnDeletePDD_Click"/></td>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnPrintPDD" runat="server" ImageUrl="../../Images/icon/print.gif" /></td>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnShenhePDD" runat="server" ImageUrl="../../Images/icon/shenhe.gif" OnClick="btnShenhePDD_Click"/></td>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnSavePDD" runat="server" Enabled="false" ImageUrl="../../Images/icon/save.gif" OnClick="btnSavePDD_Click"/></td>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnCancelPDD" runat="server" Enabled="false" ImageUrl="../../Images/icon/img22.gif" OnClick="btnCancelPDD_Click"/></td>
                        <td style="text-align: center">
                        <asp:ImageButton ID="btnlast" runat="server" ImageUrl="../../Images/icon/btnlast.gif" OnClick="btnlast_Click"/></td>
                        <td style="text-align: center">
                        <asp:ImageButton ID="btnnext" runat="server" ImageUrl="../../Images/icon/btnnext.gif" OnClick="btnnext_Click"/></td>
                    <td style="text-align: center">
                        <asp:ImageButton ID="btnFangkaiPDD" runat="server" ImageUrl="../../Images/icon/fangkai.gif" OnClick="btnFangkaiPDD_Click"/></td>
                </tr>
            </table>

		</form>
	</body>
</html>