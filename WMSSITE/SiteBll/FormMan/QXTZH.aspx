<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QXTZH.aspx.cs" Inherits="SiteBll_FormMan_QXTZH"  EnableEventValidation="false"%>

<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>形态转换</title> 
 <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/XTZHJS.js" ></script>
</head>
<body leftMargin="0" topMargin="0" onload="Init();" >
    <form id="form1" runat="server">
    <div>
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="形态转换"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" style="width: 2%">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            </span></span>
					</TD>
					<TD align="center" width="10%">
					</TD>
					<TD align="center" width="10%">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<table width="99%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="25" style="width: 1181px"><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0" bgColor="#dce8f4">
      <tr>
        <td style="height: 25px;width:76px">&nbsp;单据号</td>
        <td style="height: 25px;width:163px"><asp:TextBox ID="txtDanJu" runat="server"></asp:TextBox>
            <img src="../../Images/icon/point.gif" onclick="OpenDJ();" style="cursor:hand;" id="IMG2"/></td>
        <td style="height: 25px;width:41px">批次号</td>
        <td style="height: 25px; width: 432px;">&nbsp;<asp:TextBox ID="txtPiCiHao" runat="server"></asp:TextBox><span id="aaa"></span></td>
        <td style="height: 25px; width: 118px;">&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon/chankan.gif" OnClick="ImageButton1_Click" /></td>
        <td style="height: 25px">&nbsp;<asp:ImageButton ID="imgDelete" runat="server" ImageUrl="../../Images/icon/img19.gif" OnClick="imgDelete_Click"/></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td style="height:250px; width: 1181px;"> <uc2:PageControl id="PageControl1" runat="server">
                        </uc2:PageControl><DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;OVERFLOW:auto;WIDTH:98%;HEIGHT:200px">
                <asp:GridView ID="grvXTZHWL" runat="server" AutoGenerateColumns="False" Width="1200px">
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                           <ItemTemplate>
                              <input id="chkRow" type="checkbox" onclick="GetXTZHItem();" runat="server"/>
                                <input id="strZHDH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.zhdh") %>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="单据号" DataField="zhdh" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="仓库" DataField="ck" />
                        <asp:BoundField HeaderText="批号" DataField="pch" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="原物料号" DataField="swlh" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="原物料名称" DataField="swlmc" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="原牌号" DataField="sph" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="原规格" DataField="sgg" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="原属性" DataField="ssx" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="数量单位" DataField="zjldw" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="重量单位" DataField="fjldw" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="计划数量" DataField="jhsl" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="计划重量" DataField="jhzl" >
                            <ItemStyle Wrap="False" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="整批转?" DataField="pz" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="条目数" DataField="itemNum" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="状态" DataField="Status" >
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="svfree1" HeaderText="自由项1" />
                        <asp:BoundField DataField="svfree2" HeaderText="自由项2" />
                        <asp:BoundField DataField="svfree3" HeaderText="自由项3" />
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="gridHead" />
                </asp:GridView>
			</DIV></td>
  </tr>
  <tr><td style="height:38px; width: 1181px;" align="center">
      &nbsp;<asp:ImageButton ID="imgBtnChange" runat="server" ImageUrl="../../Images/icon/convert.gif" OnClick="imgBtnChange_Click"/>
      <input id="hidURL" runat="server" type="hidden" /></td>
  </tr>
  <tr>
    <td style="width: 1181px"><iframe id="frmList" width="100%" height="150px" runat="server"></iframe></td>
  </tr>
  
</table>   
    </div>
        
    </form>
</body>
</html>
