<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QYWD.aspx.cs" Inherits="SiteBll_FormMan_QYWD" enableEventValidation="false"%>

<%@ Register Assembly="Bestcomy.Web.UI.WebControls" Namespace="Bestcomy.Web.UI.WebControls"
    TagPrefix="bestcomy" %>

<%@ Register Src="../../UserControl/SetDisplayList.ascx" TagName="SetDisplayList"  TagPrefix="uc3" %>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<%--/柴艳亮--%>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>移位单查询</title>
        <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
<script language="javascript" src="../../JavaScript/FormYWD.js" type="text/javascript"></script>
</head>
<body  leftMargin="0" topMargin="0" onload="Init();">
    <form id="form1" runat="server">
    <TABLE class="fixColStyle" id="QZKD_TOP" height="28" cellSpacing="0" cellPadding="0" width="100%"
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="移位单查询"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="chazhao1();" alt="展开" src="../../images/icon/collapse.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">列表配置</label><IMG id="btnconfig" style="CURSOR: hand" onclick="Addconfig();" alt="关闭" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
						<TABLE class="fixColStyle" id="tablecon"  style="display:none"  cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;列表配置</font></TD>
					<TD width="88%" bgColor="#dce8f4" height="20"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"> 
                       <uc3:SetDisplayList id="SetDisplayList1" runat="server">
                                    </uc3:SetDisplayList>  
		
					</TD>
				</TR>
			</TABLE>
			<input id="hidQuery" runat="server" type="hidden" /> <input id="Hidconfig" type="hidden" /><input id="hidItem" type="hidden" />
<table id="chazhao" style="DISPLAY: block" cellSpacing="0" cellPadding="0"	width="100%" align="center" border="0" runat="server">
  <tr>
    <td><table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="2">
      <tr>
        <td width="10%" height="25"><input name="checkbox" type="checkbox" id="chkCKH" onclick="GetCKH();" />仓库</td>
        <td width="16%"><asp:DropDownList ID="drpCKH" runat="server" Width="88%" Enabled="False"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidCKH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkYCHW" onclick="GetYCHW();" />移出货位</td>
        <td width="16%"><bestcomy:ComboBox id="drpYCHW" runat="server" Width="100%">
        </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidYCHW" runat="server" /></td>
        <td width="7%"><input name="checkbox" type="checkbox" id="chkDH" onclick="GetDH();" />单号</td>
        <td width="16%"><bestcomy:ComboBox ID="drpDH" runat="server" Width="100%">
        </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidDH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkYRHW" onclick="GetYRHW();" />移入货位</td>
        <td width="16%"><bestcomy:ComboBox id="drpYRHW" runat="server" Width="100%">
        </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidYRHW" runat="server" /></td>
      </tr>
      <tr>
        <td width="10%" height="25"><input name="checkbox" type="checkbox" id="chkPCH" onclick="GetPCH();" runat="server" />批次</td>
        <td>
            <asp:TextBox ID="txtPCH" runat="server" Width="95%"></asp:TextBox></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkYWRY" onclick="GetYWRY();" />移位人员</td>
        <td> <bestcomy:ComboBox id="drpYWRY" runat="server" Width="100%">
        </bestcomy:ComboBox>
      <input name="hidYWRY" type="hidden" id="hidYWRY" runat="server" /></td>
        <td width="7%"><input name="chkSX" type="checkbox" id="chkSX" onclick="GetSX();" />属性</td>
        <td>      <asp:DropDownList ID="drpSX" runat="server" Width="87%" Enabled="False"> </asp:DropDownList>
      <input name="hidden" type="hidden" id="hidSX" runat="server" /></td>
        <td width="10%"><input name="chkPH" type="checkbox" id="chkPH" onclick="GetPH();" />牌号</td>
        <td> <bestcomy:ComboBox ID="drpPH" runat="server" Width="100%">
            </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidPH" runat="server" /></td>
      </tr>
      <tr>
        <td width="10%" height="25"><input name="checkbox" type="checkbox" id="chkWLH" onclick="GetWLH();" />物料号</td>
        <td><bestcomy:ComboBox ID="drpWLH" runat="server" Width="100%">
            </bestcomy:ComboBox>
      <input name="hidden" type="hidden" id="hidWLH" runat="server" /></td>
        <td width="10%"><input name="checkbox" type="checkbox" id="chkGG" onclick="GetGG();" />规格</td>
        <td>      <bestcomy:ComboBox ID="drpGG" runat="server" Width="100%">
        </bestcomy:ComboBox>
            <input name="hidden" type="hidden" id="hidGG" runat="server" /></td>
        <td width="7%"><input name="checkbox" type="checkbox" id="chkJH" onclick="GetJH();" />卷号</td>
        <td><asp:TextBox ID="txtJH" runat="server" Width="90%" ReadOnly="true"></asp:TextBox>
      <input name="hidden" type="hidden" id="hidJH" runat="server" /></td>
        <td width="10%"><input name="chkFree1" type="checkbox" id="chkFree1" onclick="GetFree1();" runat="server" />自由项1</td>
        <td>
            <asp:TextBox ID="txtFree1" runat="server" Width="95%"></asp:TextBox></td>
      </tr>
      <tr>
        <td width="10%" height="25">
            <input id="chkYWDRQ" name="checkbox" runat="server" onclick="GetYWDRQ();" type="checkbox" />日期</td>
        <td colspan="2"><asp:TextBox ID="YWDRQ_Start" runat="server" Width="68px" Enabled="False"></asp:TextBox>
        <img src="../../Images/icon/calendar.gif" onclick="calendar(YWDRQ_Start);" style="cursor: hand" />至
      <asp:TextBox ID="YWDRQ_End" runat="server" Width="35%" Enabled="False"></asp:TextBox>
      <img src="../../Images/icon/calendar.gif" onclick="calendar(YWDRQ_End);" style="cursor: hand" />
            <input id="hidYWDRQ" runat="server" name="hidRKRQ" type="hidden" /></td>
        <td align="center"></td>
        <td><input name="chkFree2" type="checkbox" id="chkFree2" onclick="GetFree2();" runat="server" />自由项2</td>
        <td>
            <asp:TextBox ID="txtFree2" runat="server" Width="95%"></asp:TextBox></td>
        <td><input name="chkFree3" type="checkbox" id="chkFree3" onclick="GetFree3();" runat="server" />自由项3</td>
        <td>
            <asp:TextBox ID="txtFree3" runat="server" Width="95%"></asp:TextBox></td>
      </tr>
    </table><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:ImageButton ID="imgBtnQuery" runat="server"  ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnQuery_Click"/>
        &nbsp; &nbsp;&nbsp;
      
      <asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" /></td>
  </tr>
</table></td>
  </tr>
</table><uc2:PageControl id="PageControl1" runat="server">
                        </uc2:PageControl>
                        <DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;width:99%;height:280px;overflow:auto;white-space:nowrap;">
                <asp:GridView ID="grvYWD" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%" OnSorting="grvYWD_Sorting" OnRowCreated="grvYWD_RowCreated">
                    <Columns>
                        <asp:BoundField HeaderText="移位单号" DataField="YWDH" SortExpression="YWDH" />
                        <asp:BoundField DataField="CK" HeaderText="仓库" SortExpression="CK" />
                        <asp:BoundField HeaderText="原货位" DataField="SHW" SortExpression="SHW" />
                        <asp:BoundField HeaderText="目标货位" DataField="THW" SortExpression="THW" />
                        <asp:BoundField HeaderText="单卷号" DataField="Barcode" SortExpression="Barcode" />
                        <asp:BoundField HeaderText="批次号" DataField="PCH" SortExpression="PCH" />
                        <asp:BoundField HeaderText="物料号" DataField="WLH" SortExpression="WLH" />
                        <asp:BoundField HeaderText="属性" DataField="SX" SortExpression="SX" />
                        <asp:BoundField HeaderText="牌号" DataField="PH" SortExpression="PH" />
                        <asp:BoundField HeaderText="规格" DataField="GG" SortExpression="GG" />
                        <asp:BoundField HeaderText="重量" DataField="ZL" SortExpression="ZL" DataFormatString="{0:N3}" HtmlEncode="False"/>
                        <asp:BoundField HeaderText="执行人员" DataField="CZRY" SortExpression="CZRY" />
                        <asp:BoundField HeaderText="操作时间" DataField="CZRQ" SortExpression="CZRQ" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                </asp:GridView>
			</DIV>
			<table width="100%" align="center" border="0" height="25px">
				<tr>
                    <td style="width: 106px; height: 16px">
                    </td>
                    <td style="height: 16px; width: 366px;">
                        总 计：<asp:Label ID="lblSUM" runat="server" Text="0"></asp:Label></td>
                    <td style="height: 16px">重量：<asp:Label ID="lblZL" runat="server" Text="0"></asp:Label></td><td style="height: 16px"></td>
				</tr>
			</table>
		   <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="../../Images/icon/print.gif" OnClick="btnPrint_Click"/>
       
    </form>

</body>
</html>
