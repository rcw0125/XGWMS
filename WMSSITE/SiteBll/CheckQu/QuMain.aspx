<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuMain.aspx.cs" Inherits="SiteBll_CheckQu_QuMain" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/QuCheck.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" onload = "Init();">
    <form id="form1" method="post" runat="server">
    <TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
				align="center" background="../../images/icon/topbg.gif" border="0" style="left: 0px; top: 0px">
				<TR>
					<TD vAlign="middle" align="center" width="2%" style="height: 29px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD vAlign="middle" align="center" style="width: 2%; height: 29px;"><IMG id="" style="CURSOR: hand" onclick="AddFull(1);" alt="全屏" src="../../images/icon/arrowleft.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 29px"><IMG id="IMG1" style="CURSOR: hand" onclick="AddFull(0);" alt="返回" src="../../images/icon/arrowright.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 29px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD> 
					<TD vAlign="middle" align="center" width="60%" style="height: 29px"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="质检"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 29px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%" style="height: 29px">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="AddQuery();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%" style="height: 29px"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"></label>
					</TD>
					<TD align="center" width="10%" style="height: 29px"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"></label>
					</TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 29px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="tblQuery" style="DISPLAY: block;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 12%;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></TD>
					<TD width="88%" bgColor="#dce8f4" style="height: 20px"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
					    <TABLE class="fixColStyle" id="tblEdit" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="2">
					    <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="2">
		                    <TR>
			                    <td style="height: 23px">
                                    &nbsp;<input id="chkSCX" type="checkbox" onclick="GetSCX();" runat="server"/>生产线</td>
		                        <TD style="height: 23px">
                                    <asp:DropDownList ID="drpSCX" runat="server" Width="95%" Enabled="False">
                                    </asp:DropDownList>
                                    <input id="hidSCX" runat="server" type="hidden" /></TD>
			                    <TD width="12.5%" style="height: 23px"><asp:DropDownList ID="Drptj" runat="server" Width="95%" Enabled="False">
                                    <asp:ListItem Value="=">等于</asp:ListItem>
                                    <asp:ListItem Value="&lt;&gt;">不等于</asp:ListItem>
                                </asp:DropDownList></TD>
			                    <TD width="12.5%" align="left" style="height: 23px">
                                    &nbsp;<input id="chkPCH" name="chkPCH" type="checkbox" runat="server"/>
                                    批次号</TD>
                                    
			                    <TD width="12.5%" style="height: 23px"><FONT face="宋体">
                                    <asp:TextBox ID="drpPCH" runat="server"></asp:TextBox>                              
                                    <input id="hidPCH" type="hidden" runat="server" /></FONT></TD>
			                    <TD width="12.5%" style="height: 23px">
                                    <input id="chkyzj" type="checkbox"  runat="server"/>已质检&nbsp;</TD>
			                    <TD width="12.5%" style="height: 23px"></TD>
			                    <TD width="12.5%" style="height: 23px">
                                    &nbsp;</TD>
		                    </TR>
                            <tr>
                                <td style="height: 18px">
                                </td>
                                <td align="left" colspan="2" style="height: 18px">
                                    <asp:ImageButton ID="imgBtnQuery"  runat="server" ImageUrl="../../Images/icon/img20.gif" OnClick="imgBtnQuery_Click"/>
                                    <asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img22.gif" OnClick="imgBtnCancle_Click" />&nbsp;&nbsp;&nbsp;</td>
                                <td style="height: 18px">
                                    </td>
                                <td colspan="3" style="height: 18px">
                                    </td>
                                <td style="height: 18px">
                                </td>
                            </tr>
	                    </TABLE>
					        </TD>
				        </TR>
			        </TABLE>
        <input id="hidQuery" runat="server" type="hidden" /></TD>
				</TR>
			</TABLE>
			<TABLE class="fixColStyle" id="TABLE2" style="overflow:auto;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" height="20" style="width: 12%"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;完工单</font></TD>
					<TD vAlign="bottom" bgColor="#dce8f4" height="20" style="width: 92%"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
				<tr valign="top">
				    <td colspan="2" height="150px"><div style="height:150px;overflow:auto; width:95%;">
				       <asp:GridView ID="grvWGD" runat="server" AutoGenerateColumns="False" OnRowDataBound="grvWGD_RowDataBound"
            Width="300%">
            <Columns>
                <asp:BoundField DataField="WGDH" HeaderText="完工单号" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="PCH" HeaderText="批次" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="PCSX" HeaderText="批次属性" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="WLH" HeaderText="物料号" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="WLMC" HeaderText="物料名称" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="PH" HeaderText="牌号" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="GG" HeaderText="规格" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="ZXBZ" HeaderText="执行标准" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>    
                <asp:BoundField HeaderText="自由项1" DataField="Vfree1"><HeaderStyle Width="200px" /></asp:BoundField>
                <asp:BoundField HeaderText="自由项2" DataField="Vfree2"><HeaderStyle Width="200px" /></asp:BoundField>
                <asp:BoundField HeaderText="自由项3" DataField="Vfree3"><HeaderStyle Width="200px" /></asp:BoundField>
                <asp:BoundField DataField="PCInfo" HeaderText="批次特殊信息" >
                    <HeaderStyle Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="YWLH" HeaderText="原物料号" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="YPH" HeaderText="原牌号" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="YGG" HeaderText="原规格" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="NCWLBMID" HeaderText="质检人" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="Rev_Time" HeaderText="接收日期" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="FEW_scx" HeaderText="质检日期" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>  
                <asp:BoundField DataField="FZDW" HeaderText="辅助单位" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="BB" HeaderText="班别" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="质检标志" DataField="ZJBZ" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="PCLX" HeaderText="批次类型" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="ZPDJBZ" HeaderText="整批待检标志" >
                    <HeaderStyle Width="220px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="原自由项1" DataField="yvfree1" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="yvfree2" HeaderText="原自由项2" >
                    <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="yvfree3" HeaderText="原自由项3" >
                    <HeaderStyle Width="220px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="酸洗前钢种" DataField="sxqGZ">
                    <HeaderStyle Width="220px" />
                </asp:BoundField>
                <asp:BoundField DataField="WLHPer" HeaderText="酸洗前物料号前三位">
                    <HeaderStyle Width="220px" />
                </asp:BoundField>
                <asp:BoundField DataField="sxqgg" HeaderText="酸洗前规格">
                <HeaderStyle Width="220px" />
                </asp:BoundField>
                <asp:BoundField DataField="sxqvfree" HeaderText="酸洗前自由项">
                <HeaderStyle Width="220px" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" />
        </asp:GridView>
				    </div></td>
				</tr>
			</TABLE>
			<TABLE class="fixColStyle" id="tblPList" style="overflow:auto;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;明细信息</font></TD>
					<TD vAlign="bottom" bgColor="#dce8f4" height="20" style="width: 87%"><label style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"></label></TD>
				</TR>
				<tr>
				    <td colspan="2" style="height: 100px"><iframe id="frmList" width="95%" height="100px"></iframe>
                        &nbsp;</td>
				</tr>
			</TABLE>
			<Table class="fixColStyle" id="tblPList1" style="overflow:auto; height: 115px;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0">
				<tr><td colspan="5" vAlign="bottom" align="left" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;质检操作</font></td></tr>
				<tr valign="top">
				    <td style="height: 43px; width: 9px;">&nbsp;&nbsp;</td><td style="width: 188px; height: 43px;" align="left">
                        批次属性<br />
                        <select id="selpcsx" style="width: 220px" onchange="changeSX();">
                            <option selected="selected"></option>
                        </select>
                        
                    </TD><TD style="width: 150px; height: 43px;" align="left">
          <div id="capzxbz">执行标准<br />
              <input id="txtzxbz" style="width:150px; background-color: aliceblue;" disabled type="text" /></div>
      </TD><td style="height: 43px; width: 340px;" align="left" valign="top">
             <table>
                  <tr>
                      <td style="width: 104px"><input id="rdpclx" type="radio"  name="rdpclx" value ="0" onclick ="inipcsx();" checked="CHECKED"/>普通线材<br />
                                               <input id="Radio1" type="radio" name="rdpclx" value="1" onclick = "inipcsx();"/>出口线材
                      </td>
                      <td><div id="dvcbgp"><input id="cbgp" type="checkbox" value="1" onclick="setwgdbxx(0);"/>改判</div>
                                        <input type="checkbox" id="cbzpdj" style=" display:none;" value="1"/>
                      </td>
                      <td id="tdsx" style="display:none;">
                          &nbsp;&nbsp;酸洗前钢种:<br/>&nbsp;&nbsp;<select id="selsxqgzf"></select>
                      </td>
                      </tr></table>
          </td><td rowspan="3" style="width: 76px">
              <input id="QuCheck" type="button" name="QuCheck" style=" cursor: hand; background: url(../../Images/icon/check.bmp); width: 100px; background-repeat: repeat; height: 100px;" value="" onclick="return checkqucheck();"/></td>
				</tr>
				<tr valign="top">
				  <td colspan="4" align="left" style="height: 124px" valign="top">
				     <div id="dvzjbxx" style="height:50px;">
				     <table class="fixColStyle" id="tblPList2" style="overflow:auto; height: 50px;" cellSpacing="0" cellPadding="0"
				 align="center" border="0" width="100%">
				  <tr valign="top"> 
				     <td colspan="4" align="left" style="height: 16px" width="100%"><div id="cappdsx">判断完属性</div></td>
			      </tr>
			      <tr valign="top"> 
				     <td colspan="4" align="left" style="height: 16px" width="100%">
				        <select id="selitemph" style="width:auto;" onchange="itemphchange();">
                            <option selected="selected"></option>
                        </select>
				     </td>
			      </tr>
				  <tr valign="top">
				    <td style="height: 27px; width: 16px;" align="left">&nbsp;&nbsp;</td><TD style="width: 200px; height: 27px;" align="left">
                        <select id="selphgg" style="width:auto" onchange="wgditemphggchange();">
                            <option selected="selected"></option>
                        </select>
                    </TD><TD style="width: 165px; height: 27px;" align="left">
                        <select id="selitemsx" style="width:auto">
                            <option selected="selected"></option>
                        </select>
                    </TD><td style="height: 27px; width: 218px;" align="left">
                        <input id="txtitemzxbz" type="text" style="background-color: aliceblue" disabled /></td>
				  </tr>
				  </table></div>
				  <table border="0" cellspacing="0" cellpadding="0" width="800px" style="display:none" id="tbsxqinfo">
	            <tr><td colspan="4"><font color="red">酸洗前线材要求</font></td></tr>		
				<tr>
					<td style="width: 124px; height: 20px">编码前三位<select id="selsxqwlhper" onchange="javascript:getsxqgz();">
					                               <option value=""></option>
					                               <option value="801">801</option>
					                               <option value="802">802</option>
					                               <option value="803">803</option>
					                               <option value="804">804</option>
					                               <option value="805">805</option>
					                               <option value="806">806</option>
					                               <option value="807">807</option>
					                               <option value="808">808</option>
					                               <option value="809">809</option></select></td>
					<td style="height: 20px">钢种<select id="selsxqgz" onchange="javascript:setWgdxqgg();"></select></td>
					<td style="height: 20px">规格<select id="selsxqgg" onchange="javascript:setWgdxqzyx();"></select></td>
					<td style="height: 20px">自由项<select id="selsxqvfree"></select></td>
				</tr>
			</table>
				  </td>
				</tr>
			</Table>
			
		  <input id="hpch" type="hidden" />  
          <input id="hwlh" type="hidden" />
          <input id="hsx" type="hidden"/>
          <input id="hgg" type="hidden"/>
          <input id="hph" type="hidden"/>
          <input id="hwcbz" type="hidden"/>
          <input id="hpclx" type="hidden"/>
          <input id="hzpdjbz" type="hidden"/>
          <input id="hzxbz" type="hidden"/>
          <input id="hitemwlh" type="hidden"/>
          <input id="hitemph" type="hidden"/>
          <input id="hitemgg" type="hidden"/>
          <input id="hitemzxbz" type="hidden"/>
          <input id="hitemsx" type="hidden"/>
        <input id="hitfree1" type="hidden"/>
        <input id="hitfree2" type="hidden"/>
        <input id="hitfree3" type="hidden"/>
          <input id="hsxqgz" type="hidden"/>
          <input id="hsxqgg" type="hidden"/>
          <input id="hsxqwlhper" type="hidden"/>
          <input id="hsxqvfree" type="hidden"/>
          <input id="userno" runat="server" type="hidden" />
    </form>
</body>
</html>
