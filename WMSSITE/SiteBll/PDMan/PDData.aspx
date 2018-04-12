<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDData.aspx.cs" Inherits="SiteBll_PDMan_PDData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>盘点粗盘单</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="JAVASCRIPT" src="../../JavaScript/PDMan.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE class="fixColStyle" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0"
				runat="server" style="left: 0px; top: 0px">
				<TR>
					<TD colSpan="2" style="height: 1px"></TD>
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
                            <asp:Literal ID="m_labTitle" runat="server" Text="盘点数据上传"></asp:Literal></font></td>
                    <td align="center" style="height: 28px; width: 2%;" valign="middle">
                        <img align="textTop" src="../../images/icon/compartcenter.gif" />
                    </td>
                </tr>
            </table>
            <table border="0" style="width:100%">
                <tr>
                    <td style="text-align: center; width: 90px; height: 42px;" align="center">
                            原始单号</td>
                    <td style="text-align: center; width: 150px; height: 42px;" align="center">
                        <table border="0" style="width: 100%">
                            <tr>
                                <td style="width: 80%; text-align: center; height: 24px;">
                                    <asp:TextBox ID="txtYSDH" runat="server"></asp:TextBox></td>
                                <td style="width: 20%; text-align: center">
                                    <img src="../../Images/icon/point.gif" id="btnYSDHSearch" onclick="OpenYSDHWindow('');" style="cursor: hand" /></td>
                            </tr>
                        </table>
                    </td>
                    <td style="text-align: center; width: 60px; height: 42px;" align="center">
                        仓库</td>
                    <td style="text-align: center; width: 150px; height: 42px;" align="center">
                    <asp:DropDownList ID="drpCK" runat="server" Width="150px"></asp:DropDownList>
                    </td>
                    <td style="text-align: center; width: 100px; height: 42px;" align="center">
                        <asp:ImageButton ID="btnDoSearch" runat="server" ImageUrl="../../Images/icon/chankan.gif"
                            OnClick="btnDoSearch_Click" /></td>
                    <td style="text-align: center; width: 90px; height: 42px;" align="center">
                        <%--<Img src="../../Images/icon/shenhe.gif" ID="btnShenhePDD" onclick="shenhe()" style="cursor: hand"/>--%>
                        <asp:ImageButton ID="btnShenhePDD" ImageUrl="../../Images/icon/shenhe.gif" runat="server" OnClick="btnShenhePDD_Click" /></td>
                    <td style="width: 90px; height: 42px; text-align: center" align="center">
                        <asp:ImageButton ID="btndataUp" runat="server" ImageUrl="../../Images/icon/dataUp.gif" OnClick="btndataUp_Click"/></td>
                    <td style="text-align: center; width: 90px; height: 42px;" align="center">
                        <Img src="../../Images/icon/KCshift.gif" ID="btnKCadjust" onclick="KCadjust()" style="cursor: hand"/></td>
                </tr>
                <tr>
                    <td style="text-align: center; width: 90px; height: 24px;" align="center">
                            盘点日期</td>
                    <td style="text-align: center; height: 24px; width: 150px;" align="center">
                        <asp:TextBox ID="txtPDRQ" runat="server" Width="140px"></asp:TextBox></td>
                    <td style="text-align: center; height: 24px; width: 60px;" align="center">
                            状态</td>
                    <td style="text-align: center; height: 24px; width: 150px;" align="center">
                        <asp:TextBox ID="txtDJZT" runat="server" Width="120px"></asp:TextBox></td>
                    <td style="text-align: center; height: 24px; width: 100px;" align="center">
                        <Img src="../../Images/icon/lookPDDinfo.gif" ID="btnlookPDDinfo" onclick="OpenlookPDDinfoWindow()" style="cursor:hand;"/></td>
                    <td style="text-align: center; height: 24px; width: 90px;" align="center">
                        <input id="hidState" style="width: 45px" runat="server" type="hidden" /></td>
                    <td align="center" style="height: 24px; width: 90px;"><input id="txtPDDH" style="width: 1px" runat="server" type="hidden" />
                        <input id="hidYSDH" style="width: 1px; height: 10px;" type="hidden" runat="server" />&nbsp;
                        <input id="hidsort" style="width: 1px" runat="server" type="hidden" />
                        <input id="hidCKID" style="width: 1px; height: 10px;" type="hidden" runat="server"/></td>
                    <td style="text-align: center; height: 24px; width: 90px;" align="center">
                        <input id="hiddrpDJH" style="width: 1px" type="Hidden"  runat="server"  />
                        <input id="hidWLH" style="width: 1px" type="Hidden"  runat="server" />
                        <input id="hidPCH" style="width: 1px"  type="Hidden" runat="server" />
                        <input id="hidSX" style="width: 1px"  type="Hidden" runat="server" />
                        <input id="hidNoNcWL" style="width: 1px" type="Hidden" runat="server" />
                        <input id="hidStrSort" style="width: 1px" type="Hidden" runat="server" /></td>
                </tr>
            </table>
			<TABLE class="fixColStyle" id="tblList" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server" style="left: 0px; top: 0px">
                <tr>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" style="height: 20px"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;详细信息</font></TD>
					<TD vAlign="bottom" width="97%" bgColor="#dce8f4" style="font-size: 9pt; height: 20px;"></TD>
                </tr>
			</TABLE>
            <div id="div1" style="overflow: auto; white-space: nowrap; height: 146px; width:auto;">
                <asp:GridView ID="grd1" runat="server" AutoGenerateColumns="False" Height="2px"
                    Width="98%" AllowSorting="True" OnSorting="grd1_Sorting">
                    <Columns>
                        <asp:BoundField DataField="BARCODE" SortExpression="BARCODE" HeaderText="物料号">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PCH" SortExpression="PCH" HeaderText="批次号">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" SortExpression="SX" HeaderText="属性">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" SortExpression="vfree1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" SortExpression="vfree2" />
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" SortExpression="vfree3" />
                        <asp:BoundField DataField="ZCSL" SortExpression="ZCSL" HeaderText="帐存数量">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPSL" SortExpression="SPSL" HeaderText="盘点数量">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PDCY" SortExpression="PDCY" HeaderText="盘点差异">
                            <ItemStyle Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JLDW" SortExpression="JLDW" HeaderText="计量单位">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZCZL" SortExpression="ZCZL" HeaderText="帐存重量">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPZL" SortExpression="SPZL" HeaderText="实盘重量">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
                </asp:GridView>
            </div>
<table border="1" style="font-size: 9pt; width:100%; background-color: #dce8f4;">
  <tr>
    <td style="text-align: center; width: 100px; height: 24px;" align="center">
        单据号</td>
    <td style="text-align: center; width: 150px; height: 24px;" align="center">
        <asp:DropDownList ID="drpDJH" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="drpDJH_SelectedIndexChanged">
        </asp:DropDownList></td>
    <td style="text-align: center; width: 150px; height: 24px;" align="center">
    <%--<input id="chkWLGL" type="checkbox" runat="server" onclick="chkWLGL()"/>物料关联--%>
    <asp:CheckBox ID="chkWLGL" runat="server" Text="物料关联" AutoPostBack="true" OnCheckedChanged="chkWLGL_CheckedChanged"/></td>
    <td style="text-align: center; width: 150px; height: 24px;" align="center">
        <asp:CheckBox id="chkNoNCWL" runat="server" Text="非NC物料" AutoPostBack="true" OnCheckedChanged="chkNoNCWL_CheckedChanged"></asp:CheckBox></td>
    <td style="text-align: center; height: 24px;" align="center"><%--<asp:ImageButton ID="btnExp" runat="server" ImageUrl="../../Images/icon/btnExp.gif" OnClick="btnExp_Click"/>--%>
        <asp:ImageButton ID="btnPrintExp" runat="server" ImageUrl="../../Images/icon/PrintExp.gif" OnClick="btnPrintExp_Click"/></td>
    <td style="text-align: center; height: 24px;" align="center"><Img src="../../Images/icon/cuoweiWL.gif" ID="btncuoweiWL" onclick="OpenCuoweiWLpage()" style="cursor:hand;"/></td>
  <td><asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../../Images/icon/PrintCY.gif" /></td>
  </tr>
</table>
            <div id="div2" style="overflow: auto; white-space: nowrap; height: 220px">
                <asp:GridView ID="grd2" runat="server" AutoGenerateColumns="False" Width="98%" AllowSorting="True" OnSorting="grd2_Sorting">
                    <Columns>
                        <asp:BoundField DataField="PDDH" SortExpression="wms_che_pdd_detail.PDDH" HeaderText="单据号">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLH" SortExpression="WLH" HeaderText="物料号">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WLMC" SortExpression="WLMC" HeaderText="物料名称">
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HW" SortExpression="HW" HeaderText="货位">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PCH" SortExpression="PCH" HeaderText="批次号">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SX" SortExpression="SX" HeaderText="属性">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="vfree1" HeaderText="自由项1" SortExpression="vfree1" />
                        <asp:BoundField DataField="vfree2" HeaderText="自由项2" SortExpression="vfree2" />
                        <asp:BoundField DataField="vfree3" HeaderText="自由项3" SortExpression="vfree3" />
                        <asp:BoundField DataField="ZCSL" SortExpression="ZCSL" HeaderText="帐存数量">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPSL" SortExpression="SPSL" HeaderText="盘点数量">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ZCZL" SortExpression="ZCZL" HeaderText="帐存重量">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SPZL" SortExpression="SPZL" HeaderText="实盘重量">
                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                            <HeaderStyle Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UserName" HeaderText="操作人" />
                        <asp:BoundField DataField="operdate" HeaderText="操作时间" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderStyle" />
                </asp:GridView>
            </div>
            <table style="width:auto; background-color: #dce8f4;">
            <tr>
                <td align="right" style="width: 140px;" valign="middle">
                    总计:</td>
            <td align="left" style="width: 136px;" valign="middle"></td>
            <td align="right" style="width: 145px;" valign="middle"></td>
            <td align="left" style="width: 101px;" valign="middle"></td>
           <td align="right" style="width: 94px;" valign="middle"></td>
            <td align="left" style="width: 100px;" valign="middle"></td>
            <td align="center" style="width: 121px;" valign="middle">
                <asp:Label ID="lblzcsl" runat="server" ></asp:Label></td>
            <td align="center" style="width: 116px;" valign="middle">
                <asp:Label ID="lblspsl" runat="server"></asp:Label></td>
            <td align="center" style="width: 121px;" valign="middle">
                <asp:Label ID="lblzczl" runat="server" ></asp:Label></td>
            <td align="center" style="width: 108px;" valign="middle">
                <asp:Label ID="lblspzl" runat="server" ></asp:Label></td>
            </tr>
        </table>
		</form>
	</body>
</html>
