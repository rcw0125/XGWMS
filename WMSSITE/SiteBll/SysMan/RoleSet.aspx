<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleSet.aspx.cs" Inherits="SiteBll_SysMan_RoleSet" %>

<%@ Register Src="UserControl/RoleEditControl.ascx" TagName="RoleEditControl" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色定义</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="JAVASCRIPT" src="../../JavaScript/SysMan.js" type="text/javascript">
	</script>
</head>
<body leftMargin="0" topMargin="0" onload="Init();">
    <form id="form1" runat="server">
        <TABLE class="fixColStyle" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
		    <TR>
		        <TD colSpan="2" height="1"></TD>
		    </TR>
	    </TABLE>
	    <TABLE class="fixColStyle" id="Table1" height="28" cellSpacing="0" cellPadding="0" width="100%"
				align="center" background="../../images/icon/topbg.gif" border="0">
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
					<TD vAlign="middle" align="center" width="78%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"><asp:literal id="m_labTitle" runat="server" Text="角色信息维护"></asp:literal></font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">新建角色</label><IMG id="btnNewRole" style="CURSOR: hand" onclick="AddNewRole();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
		</TABLE>
		<TABLE class="fixColStyle" id="tblNewRole" style="DISPLAY: none" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD style="HEIGHT: 19px" vAlign="bottom" align="left" width="12%" bgColor="#dce8f4"
						height="19"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;编制信息</font></TD>
					<TD style="HEIGHT: 19px" vAlign="bottom" width="88%" bgColor="#dce8f4" height="19"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 32px" align="center" colSpan="2">
                        <uc1:RoleEditControl ID="RoleEditControl1" runat="server" />
					    
					</TD>
				</TR>
				<TR>
					<TD align="left" colSpan="2">&nbsp;<asp:imagebutton id="btnSumbit" runat="server" ToolTip="点击“确认”，提交编制信息。" BorderWidth="0px" ImageAlign="AbsMiddle"
							ImageUrl="../../images/icon/imgNew1.gif" OnClick="btnSumbit_Click"></asp:imagebutton>
						&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="imgBtnReset" runat="server" ImageUrl="../../images/icon/img12.gif" OnClick="imgBtnReset_Click"/>
                        &nbsp;&nbsp;<b></b>
					</TD>
				</TR>
		</TABLE>
		<TABLE class="fixColStyle" id="tblList" style="DISPLAY: block" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" width="12%" bgColor="#dce8f4" style="height: 20px"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;浏览信息</font></TD>
					<TD vAlign="bottom" width="97%" bgColor="#dce8f4" style="height: 20px"></TD>
				</TR>
		</TABLE>
			<DIV id="ListDiv" style="OVERFLOW-Y: visible; OVERFLOW-X: visible; WIDTH: 2600px; HEIGHT: 100%">
                <table border="1" bgcolor="#dce8f4">
                    <tr>
                        <td align="center" rowspan="2" style="font-weight: bold; left: expression(this.offsetParent.scrollLeft);
                            position: relative; background-color: #dce8f4; width: 110px;">
                            删除</td>
                        <td align="center" rowspan="2" style="font-weight: bold; left: expression(this.offsetParent.scrollLeft);
                            width: 108px; position: relative; background-color: #dce8f4">
                            修改</td>
                        <td align="center" rowspan="2" style="font-weight: bold; left: expression(this.offsetParent.scrollLeft);
                            position: relative; background-color: #dce8f4; width: 160px;">
                            角色名</td>
                        <td align="center" colspan="12" style="font-weight: bold; height: 14px">
                            系统设置</td>
                        <td align="center" rowspan="2" style="font-weight: bold; width: 39px;">
                            库存管理</td>
                        <td align="center" rowspan="2" style="font-weight: bold; width: 40px;">
                            称重打印</td>
                        <td align="center" rowspan="2" style="font-weight: bold; width: 40px;">
                            质检</td>
                        <td align="center" rowspan="2" style="font-weight: bold; width: 40px;">
                            单据作废</td>
                        <td align="center" rowspan="2" style="font-weight: bold; width: 44px;">
                            标准设置</td>
                        <td align="center" colspan="12" style="font-weight: bold; height: 14px">
                            终端操作</td>
                        <td align="center" colspan="18" style="font-weight: bold; height: 14px">
                            单据查询</td>
                        <td align="center" colspan="4" style="font-weight: bold; height: 14px">
                            IC卡管理</td>
                        <td align="center" style="font-weight: bold; height: 14px; width: 39px;">
                        </td>
                        <td align="center" colspan="4" style="font-weight: bold; height: 14px">
                            盘点管理</td>
                        <td align="center" colspan="2" style="font-weight: bold; height: 14px">
                            车辆</td>
                        <td align="center" colspan="3" style="font-weight: bold; height: 14px">
                            数据处理</td>
                    </tr>
                    <tr>
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            参数设置</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            仓库定义</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            角色定义</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            生产线</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            客户数据</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            物料基础</td>
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            去皮设置</td>   
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            包装标准</td>        
                        <td style="height: 14px; font-weight: bold; width: 41px;" align="center">
                            用户设置</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            货位设置</td>     
                        <td align="center" style="font-weight: bold; width: 40px; height: 14px">
                            发布公告</td>
                        <td align="center" style="font-weight: bold; width: 40px; height: 14px">
                            门岗维护</td>
                        <td align="center" style="font-weight: bold; width: 40px; height: 14px">
                            签证室</td>
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            货位视图</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            单卷入库</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            整批入库</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            销售出库</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            单卷出库</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            整批出库</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            盘点粗盘</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            盘点抽盘</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            移位</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            形态转换</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            退货</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            期初入库</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            关闭转库单</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            完工单</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            发运单</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center" >
                            移位单</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            转库单</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            退货单</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            待判品查询</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            传输日志</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            重发单据</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            取消发运单完成</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            修改发运单车厢号</td>
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            深加工批次查询</td>       
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            删除形态转换单</td>
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            发运单货管确认</td> 
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            发运单质检确认</td> 
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            发运单门岗确认</td> 
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            发运单确认查询</td>      
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            发放</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            挂失</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            暂停</td> 
                        <td style="height: 14px; font-weight: bold; width: 38px;" align="center">
                            注销</td>    
                        <td style="height: 14px; font-weight: bold; width: 39px;" align="center">
                            粗盘抽盘单</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            制单</td>     
                        <td style="height: 14px; font-weight: bold; width: 37px;" align="center">
                            审核</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            库存调整</td>     
                        <td style="height: 14px; font-weight: bold; width: 38px;" align="center">
                            上传</td>     
                        <td style="height: 14px; font-weight: bold; width: 40px;" align="center">
                            入门</td>     
                        <td style="height: 14px; font-weight: bold; width: 38px;" align="center">
                            出门</td>  
                        <td align="center" style="font-weight: bold; width: 40px; height: 14px">
                            数据迁移</td>
                        <td align="center" style="font-weight: bold; width: 38px; height: 14px">
                            日志删除</td>
                        <td align="center" style="font-weight: bold; width: 39px; height: 14px">
                            迁移日志浏览</td>
                    </tr>
                </table>
                <asp:GridView ID="grvRole" runat="server" AutoGenerateColumns="False" CellPadding="0" ShowHeader="False" OnRowDataBound="grvRole_RowDataBound" OnRowCommand="grvRole_RowCommand" OnSelectedIndexChanged="grvRole_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                &nbsp;<asp:ImageButton ID="imgBtnDel" runat="server" ImageUrl="../../Images/icon/img19.gif" CommandName="imgBtnDel" />
                            </ItemTemplate>
                            <ItemStyle Width="100px" CssClass="fixColStyle" HorizontalAlign="Center" BackColor="#DCE8F4" ForeColor="Black" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="fixColStyle" BackColor="#DCE8F4" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改">
                            <ItemTemplate>
                                &nbsp;<asp:ImageButton ID="imgBtnMod" runat="server" ImageUrl="../../Images/icon/imgChange1.gif" CommandName="imgBtnMod" />
                            </ItemTemplate>
                            <ItemStyle Width="95px" CssClass="fixColStyle" HorizontalAlign="Center" BackColor="#DCE8F4" ForeColor="Black" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="fixColStyle" BackColor="#DCE8F4" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="角色名">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="150px" CssClass="fixColStyle" BackColor="#DCE8F4" />
                            <HeaderStyle HorizontalAlign="Center" CssClass="fixColStyle" BackColor="#DCE8F4" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="参数设置">
                            <ItemTemplate>
                                <asp:CheckBox ID="set_Param" runat="server" Checked=<%# Bind("SET_Param") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="仓库定义">
                            <ItemTemplate>
                                <asp:CheckBox ID="SET_Store" runat="server" Checked=<%# Bind("SET_Store") %> Enabled="false" />
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="角色定义">
                            <ItemTemplate>
                                <asp:CheckBox ID="SET_Role" runat="server" Checked=<%# Bind("SET_Role") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="生产线">
                            <ItemTemplate>
                                <asp:CheckBox ID="SET_SCX" runat="server" Checked=<%# Bind("SET_SCX") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="客户数据">
                            <ItemTemplate>
                                <asp:CheckBox ID="SET_KH" runat="server" Checked=<%# Bind("SET_KH") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="物料基础">
                            <ItemTemplate>
                                <asp:CheckBox ID="exe_itembaseinfo" runat="server" Checked=<%# Bind("exe_itembaseinfo") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="去皮设置">
                            <ItemTemplate>
                                <asp:CheckBox ID="syschqp" runat="server" Checked=<%# Bind("syschqp") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="包装标准">
                            <ItemTemplate>
                                <asp:CheckBox ID="sysbzbz" runat="server" Checked=<%# Bind("sysbzbz") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用户设置">
                            <ItemTemplate>
                                <asp:CheckBox ID="SET_User" runat="server" Checked=<%# Bind("SET_User") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="货位设置">
                            <ItemTemplate>
                                <asp:CheckBox ID="SET_HW" runat="server" Checked=<%# Bind("SET_HW") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发布公告">
                            <ItemTemplate>
                                <asp:CheckBox ID="Publish_Affiche" runat="server" Checked=<%# Bind("Publish_Affiche") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="门岗维护">
                            <ItemTemplate>
                                <asp:CheckBox ID="DoorManage" runat="server" Checked=<%# Bind("DoorManage") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="签证室">
                            <ItemTemplate>
                                <asp:CheckBox ID="QZSManag" runat="server" Checked=<%# Bind("QZSManage") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="货位视图">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_HWVIEW" runat="server" Checked=<%# Bind("EXE_HWVIEW") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="库存管理">
                            <ItemTemplate>
                                <asp:CheckBox ID="Q_KC" runat="server" Checked=<%# Bind("Q_KC") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="称重打印">
                            <ItemTemplate>
                                <asp:CheckBox ID="Bar_Print" runat="server" Checked=<%# Bind("Bar_Print") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="质检">
                            <ItemTemplate>
                                <asp:CheckBox ID="CHE_QU" runat="server" Checked=<%# Bind("CHE_QU") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="单据作废">
                            <ItemTemplate>
                                <asp:CheckBox ID="CANCELBILL" runat="server" Checked=<%# Bind("CANCELBILL") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="标准设置">
                            <ItemTemplate>
                                <asp:CheckBox ID="Bar_BZ" runat="server" Checked=<%# Bind("Bar_BZ") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="单卷入库">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_BARRK" runat="server" Checked=<%# Bind("EXE_BARRK") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="整批入库">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_PCHRK" runat="server" Checked=<%# Bind("EXE_PCHRK") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="销售出库">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_SELL_CK" runat="server" Checked=<%# Bind("EXE_SELL_CK") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="单卷出库">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_BARCK" runat="server" Checked=<%# Bind("EXE_BARCK") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="整批出库">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_PCHCK" runat="server" Checked=<%# Bind("EXE_PCHCK") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="盘点粗盘">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_PCHPD" runat="server" Checked=<%# Bind("EXE_PCHPD") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="盘点抽盘">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_BARPD" runat="server" Checked=<%# Bind("EXE_BARPD") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="移位">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_YW" runat="server" Checked=<%# Bind("EXE_YW") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="形态转换">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_SHAPE" runat="server" Checked=<%# Bind("EXE_SHAPE") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="退货">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_TH" runat="server" Checked=<%# Bind("EXE_TH") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="期初入库">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_QCRK" runat="server" Checked=<%# Bind("EXE_QCRK") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="关闭转库单">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_CLOSE_ZKD" runat="server" Checked=<%# Bind("EXE_CLOSE_ZKD") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="完工单">
                            <ItemTemplate>
                                <asp:CheckBox ID="Q_WGD" runat="server" Checked=<%# Bind("Q_WGD") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发运单">
                            <ItemTemplate>
                                <asp:CheckBox ID="Q_FYD" runat="server" Checked=<%# Bind("Q_FYD") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="移位单">
                            <ItemTemplate>
                                <asp:CheckBox ID="Q_YWD" runat="server" Checked=<%# Bind("Q_YWD") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="转库单">
                            <ItemTemplate>
                                <asp:CheckBox ID="Q_ZKD" runat="server" Checked=<%# Bind("Q_ZKD") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="退货单">
                            <ItemTemplate>
                                <asp:CheckBox ID="Q_THD" runat="server" Checked=<%# Bind("Q_THD") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="待判品查寻">
                            <ItemTemplate>
                                <asp:CheckBox ID="exe_dpqry" runat="server" Checked=<%# Bind("exe_dpqry") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="传输日志">
                            <ItemTemplate>
                                <asp:CheckBox ID="BILLSENDLOG" runat="server" Checked=<%# Bind("BILLSENDLOG") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="重发单据">
                            <ItemTemplate>
                                <asp:CheckBox ID="RESENDBILL" runat="server" Checked=<%# Bind("RESENDBILL") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="取消发运单完成">
                            <ItemTemplate>
                                <asp:CheckBox ID="FYD_CancelFinish" runat="server" Checked=<%# Bind("FYD_CancelFinish") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改发运单车厢号">
                            <ItemTemplate>
                                 <asp:CheckBox ID="FYD_UpdateCXH" runat="server" Checked=<%# Bind("FYD_UpdateCXH") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="深加工批次查询">
                            <ItemTemplate>
                                 <asp:CheckBox ID="Q_SXPC" runat="server" Checked=<%# Bind("Q_SXPC") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除形态转换单">
                            <ItemTemplate>
                                <asp:CheckBox ID="exe_delxtzhd" runat="server" Checked=<%# Bind("exe_delxtzhd") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发运单货管确认">
                            <ItemTemplate>
                                <asp:CheckBox ID="fyd_hgqr" runat="server" Checked=<%# Bind("fyd_hgqr") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发运单质检确认">
                            <ItemTemplate>
                                <asp:CheckBox ID="fyd_zjqr" runat="server" Checked=<%# Bind("fyd_zjqr") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发运单门岗确认">
                            <ItemTemplate>
                                <asp:CheckBox ID="fyd_mgqr" runat="server" Checked=<%# Bind("fyd_mgqr") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发运单确认查询">
                            <ItemTemplate>
                                <asp:CheckBox ID="FYD_QRSearch" runat="server" Checked=<%# Bind("FYD_QRSearch") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="发放">
                            <ItemTemplate>
                                <asp:CheckBox ID="IC_FK" runat="server" Checked=<%# Bind("IC_FK") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="挂失">
                            <ItemTemplate>
                                <asp:CheckBox ID="IC_GS" runat="server" Checked=<%# Bind("IC_GS") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="暂停">
                            <ItemTemplate>
                                <asp:CheckBox ID="IC_ZT" runat="server" Checked=<%# Bind("IC_ZT") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="注销">
                            <ItemTemplate>
                                <asp:CheckBox ID="IC_ZX" runat="server" Checked=<%# Bind("IC_ZX") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="粗盘抽盘单">
                            <ItemTemplate>
                                 <asp:CheckBox ID="Q_PDD" runat="server" Checked=<%# Bind("Q_PDD") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="制单">
                            <ItemTemplate>
                                <asp:CheckBox ID="M_PDD" runat="server" Checked=<%# Bind("M_PDD") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="审核">
                            <ItemTemplate>
                                <asp:CheckBox ID="SH_PDD" runat="server" Checked=<%# Bind("SH_PDD") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="库存调整">
                            <ItemTemplate>
                                <asp:CheckBox ID="EXE_KCTZ" runat="server" Checked=<%# Bind("EXE_KCTZ") %> Enabled="false"/>
                            </ItemTemplate>
                             <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上传">
                            <ItemTemplate>
                                <asp:CheckBox ID="UP_PDD" runat="server" Checked=<%# Bind("UP_PDD") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="入门">
                            <ItemTemplate>
                                <asp:CheckBox ID="Car_In" runat="server" Checked=<%# Bind("Car_In") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="出门">
                            <ItemTemplate>
                                <asp:CheckBox ID="Car_Out" runat="server" Checked=<%# Bind("Car_Out") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="数据回迁">
                            <ItemTemplate>
                                <asp:CheckBox ID="Data_return" runat="server" Checked=<%# Bind("Data_return") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="日志删除">
                            <ItemTemplate>
                                <asp:CheckBox ID="Log_Delete" runat="server" Checked=<%# Bind("Log_Delete") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="迁移日志浏览">
                            <ItemTemplate>
                                <asp:CheckBox ID="Data_MoveLog" runat="server" Checked=<%# Bind("Data_MoveLog") %> Enabled="false"/>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
			</DIV>	
        <input id="HidNewRole" runat="server" type="hidden" />
    </form>
</body>
</html>
