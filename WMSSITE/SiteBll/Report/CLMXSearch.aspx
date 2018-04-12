<%@ page language="C#" autoeventwireup="true" CodeFile="CLMXSearch.aspx.cs" inherits="SiteBll_Report_CLMXSearch" %>
<%@ Register Src="../../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
      <script language="javascript" src="../../JavaScript/jquery-1.9.1.min.js" type="text/javascript"></script>
      <script language="javascript" type="text/javascript" src="../../JavaScript/My97DatePicker/WdatePicker.js"></script>
      <script language="javascript" type="text/javascript">

          function AddFull(flag) {
              if (flag == 1) {
                  parent.document.body.cols = "*,100%";
              }
              if (flag == 0) {
                  parent.document.body.cols = "120,*";
              }
          }
      </script>
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
					<TD vAlign="middle" align="center" width="70%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="产量信息明细查询"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="AddQuery();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
	</TABLE>
	<TABLE id="TABLE2" class="fixColStyle" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
		<TR>
			<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
			<TD width="88%" bgColor="#dce8f4" height="20"></TD>
		</TR>
	</TABLE>
	   <table class="fixColStyle" id="tblQuery" width="100%" runat="server">
        <tr>
            <td width="8%" style="height: 16px">
                日期：</td>
            <td width="20%" style="height: 16px">
                 <asp:TextBox ID="txtStartTime" runat="server" Width="100px"></asp:TextBox><img
                    onclick="WdatePicker({el:'txtStartTime'})" src="../../Images/icon/calendar.gif" style="cursor: hand" />
                            </td>
            <td width="8%" style="height: 16px">
                车间：</td>
            <td width="15%" style="height: 16px">
                <asp:DropDownList ID="drpscx" runat="server" Width="95%" DataTextField="scx" DataValueField="scxid">
                </asp:DropDownList></td>
            <td width="8%" style="height: 16px">
                班次：</td>
            <td width="15%" style="height: 16px"><asp:DropDownList ID="drpbc" runat="server" Width="95%" DataTextField="bc" DataValueField="bc">
            </asp:DropDownList></td>
             <td width="26%" style="height: 16px" >
                <asp:ImageButton ID="imgBtnOK" runat="server" ImageUrl="../../Images/icon/img25.gif" OnClick="imgBtnOK_Click" /></td>
        </tr>
    </table>
        <TABLE  id="tblList" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;浏览信息</font></TD>
					<TD vAlign="bottom" width="88%" bgColor="#dce8f4" height="20"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
			</TABLE>
    <uc2:PageControl ID="PageControl1" runat="server" />
    <DIV style="BORDER:0px;PADDING:0px;MARGIN:0px;width:99%;height:420px;overflow:auto;white-space:nowrap;">
                <asp:GridView ID="grvFYDList" runat="server" AutoGenerateColumns="False" 
                    OnRowDataBound="grvFYDList_RowDataBound" AllowSorting="True" 
                    OnRowCreated="grvFYDList_RowCreated" OnSorting="grvFYDList_Sorting" 
                    HorizontalAlign="Right" style=" min-width:1200px; width:100%">
                    <Columns>
                        <asp:BoundField DataField="jhddh" HeaderText="计划订单号" SortExpression="jhddh" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ph" HeaderText="钢种1" SortExpression="ph" >
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField DataField="pch" HeaderText="批号" SortExpression="pch" >
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField DataField="heatid" HeaderText="炉号" SortExpression="heatid" >
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="gg" HeaderText="规格" SortExpression="gg">
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="wczl" HeaderText="完成吨数" DataFormatString="{0:F4}" />
                        <asp:BoundField DataField="wcsl" HeaderText="完成件数"/>
                        <asp:BoundField DataField="bhgzl" HeaderText="不合格吨数" 
                            DataFormatString="{0:F4}" />
                        <asp:BoundField DataField="bhgsl" HeaderText="不合格件数" />
                        <asp:BoundField DataField="xyzl" HeaderText="协议品吨数" DataFormatString="{0:F4}" />
                        <asp:BoundField DataField="xysl" HeaderText="协议品件数"/>
                        <%--<asp:BoundField DataField="twczl" HeaderText="零星加工材吨数"  
                            DataFormatString="{0:F4}"  />
                        <asp:BoundField DataField="twcsl" HeaderText="零星加工材件数" />--%>
                        <asp:BoundField DataField="wlh_zl" HeaderText="物料号改判吨数"  
                            DataFormatString="{0:F4}"  />
                        <asp:BoundField DataField="wlh_sl" HeaderText="物料号改判件数" />
                        <asp:BoundField DataField="vfree1_zl" HeaderText="自由项1改判吨数"  
                            DataFormatString="{0:F4}" />
                        <asp:BoundField DataField="vfree1_sl" HeaderText="自由项1改判件数"/>
                         <asp:BoundField DataField="vfree2_zl" HeaderText="自由项2改判吨数"  
                            DataFormatString="{0:F4}" />
                        <asp:BoundField DataField="vfree2_sl" HeaderText="自由项2改判件数"/>
                         <asp:BoundField DataField="vfree3_zl" HeaderText="自由项3改判吨数"  
                            DataFormatString="{0:F4}" />
                        <asp:BoundField DataField="vfree3_sl" HeaderText="自由项3改判件数"/>
                         <asp:BoundField DataField="pcinfo_zl" HeaderText="特殊信息改判吨数"  
                            DataFormatString="{0:F4}" />
                        <asp:BoundField DataField="pcinfo_sl" HeaderText="特殊信息改判件数"/>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderTest" />
             </asp:GridView>
        </DIV>
    </form>
</body>
</html>
