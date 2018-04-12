<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FirstPage.aspx.cs" Inherits="FirstPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>系统首页</title>
    <LINK href="css/Input.css" type="text/css" rel="stylesheet">
</head>
<BODY leftMargin="0" topMargin="0">
		<form id="Form1" runat="server">
			<table height="600px" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%" height="2">
						<table height="2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td background="Images/down/Freambg.gif" style="height: 12px"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
				    <td valign="top" width="100%">
				        <table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr vAlign="top">
								<td width="2" background="Images/down/Freambg.gif"></td>
								<td bgColor="#ffffff">
									<!--实际内容-->
									<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
										border="0">
										<tr>
											<td vAlign="top" width="2%" height="100%"></td>
											<td id="Td1" vAlign="top" height="100%" runat="server" style="width: 25%">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<TR>
														<TD height="10"></TD>
													</TR>
													<!-- 当前用户的头信息  -->
													<TR>
														<TD vAlign="middle" align="center" width="100%"><asp:literal id="LitMyInfo" runat="server"></asp:literal></TD>
													</TR>
													<TR>
														<TD>
															<HR color="#9c9c9c">
														</TD>
													</TR>
													<tr>
														<td vAlign="bottom" align="left" width="100%" height="28"><IMG height="30" src="Images/down/tongzhi.gif" width="250" align="middle"></td>
													</tr>
													<!--公告信息-->
													<TR height="330px">
														<TD vAlign="top" align="center" width="100%"><asp:literal id="LitSysAffiche" runat="server"></asp:literal></TD>
													</TR>
													<tr>
														<td vAlign="top" align="left" width="252" height="30"><IMG height="30" src="Images/icon/kqdyw2.gif" width="250" align="middle"></td>
													</tr>
													<!--待处理的单据信息-->
													<TR>
														<TD vAlign="middle" align="center" width="100%">
														    <TABLE rules="rows" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
														        <TR>
														            <TD height="20" width="5%" class="SystemDashedTd" vAlign="middle"><IMG src="Images/down/ImWorkSmall.gif"></TD>
														            <TD height="20" width="95%" class="SystemDashedTd" style="PADDING-TOP: 4px" align="left" >
                                                                        正在处理的完工单有<%=WGDCount %>条</TD>
														        </TR>
														        <TR>
														            <TD height="20" width="5%" class="SystemDashedTd" vAlign="middle"><IMG src="Images/down/ImWorkSmall.gif"></TD>
														            <TD height="20" width="95%" class="SystemDashedTd" style="PADDING-TOP: 4px" align="left" >正在处理的形态转换单有<%=XTZHCount %>条</TD>
														        </TR>
														        <TR>
														            <TD height="20" width="5%" class="SystemDashedTd" vAlign="middle"><IMG src="Images/down/ImWorkSmall.gif"></TD>
														            <TD height="20" width="95%" class="SystemDashedTd" style="PADDING-TOP: 4px" align="left" >正在处理的移库单有<%=YKDCount %>条</TD>
														        </TR>
														        <TR>
														            <TD height="20" width="5%" class="SystemDashedTd" vAlign="middle"><IMG src="Images/down/ImWorkSmall.gif"></TD>
														            <TD height="20" width="95%" class="SystemDashedTd" style="PADDING-TOP: 4px" align="left" >正在处理的盘点单有<%=PDDCount %>条</TD>
														        </TR>
														        <TR>
														            <TD height="20" width="5%" class="SystemDashedTd" vAlign="middle"><IMG src="Images/down/ImWorkSmall.gif"></TD>
														            <TD height="20" width="95%" class="SystemDashedTd" style="PADDING-TOP: 4px" align="left" >正在处理的发运单有<%=FYDCount %>条</TD>
														        </TR>
														    </TABLE>
														</TD>
													</TR>
												</TABLE>
											</td>
											<td vAlign="top" align="center" width="2%" height="100%"></td>
											<!--右边信息-->
											<td vAlign="top" width="69%" height="100%">
												<TABLE id="table1" style="DISPLAY: block" height="100%" cellSpacing="0" cellPadding="0"
													width="100%" align="center" border="0">
													<TR>
														<TD colSpan="2" height="38px"></TD>
													</TR>
													<tr>
														<td vAlign="top" align="left" width="300" height="28"><IMG height="30" src="Images/icon/function.gif" width="250"
																align="middle"></td>
														<TD vAlign="middle" align="left" height="28">
														</TD>
													</tr>
													<TR>
														<TD colSpan="2" height="2"></TD>
													</TR>
													<tr>
													    <td colSpan="2">
													        	<TABLE id="TABLE2" class="fixColStyle" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server">
		                                                            <TR>
			                                                            <TD vAlign="bottom" align="left" width="22%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;系统设置</font></TD>
			                                                            <TD width="78%" bgColor="#dce8f4" height="20"></TD>
		                                                            </TR>
	                                                           </TABLE>
	                                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="lnk__SET_Param" runat="server" OnClick="lnk__SET_Param_Click" >参数设置</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_SET_Store"
                                                                                runat="server" OnClick="lnk_SET_Store_Click">仓库定义</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_SET_Role" runat="server" OnClick="lnk_SET_Role_Click1">角色定义</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;<asp:LinkButton ID="lnkUserRole" runat="server" OnClick="lnkUserRole_Click">用户权限</asp:LinkButton></TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    <asp:LinkButton ID="lnk_Set_KH" runat="server" OnClick="lnk_Set_KH_Click">客户数据</asp:LinkButton>
                                                                        </td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;<asp:LinkButton ID="lnk_exe_itembaseinfo" runat="server" OnClick="lnk_exe_itembaseinfo_Click">物料基础信息</asp:LinkButton></td>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    <asp:LinkButton ID="lnk_SET_HW" runat="server" OnClick="lnk_SET_HW_Click">货位设置</asp:LinkButton>
                                                                        </td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_SysGG" runat="server" OnClick="lnk_SysGG_Click">系统公告</asp:LinkButton></td>
					                                                </TR>
					                                                <tr>
					                                                    <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="lnk_Set_qp" runat="server" OnClick="lnk_Set_qp_Click">去皮设置</asp:LinkButton></TD>
					                                                    <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="lnk_set_bzkz" runat="server" OnClick="lnk_set_bzkz_Click">包装扣重</asp:LinkButton></TD>
					                                                    <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="lnk_Set_door" runat="server" OnClick="lnk_Set_door_Click">门岗设置</asp:LinkButton></TD>
					                                                    <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="Lnk_Set_qzs" runat="server" OnClick="Lnk_Set_qzs_Click">签证室设置</asp:LinkButton></TD>
					                                                    <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="Lnk_Set_SX" runat="server" OnClick="Lnk_Set_SX_Click">属性设置</asp:LinkButton></TD>
					                                                    <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="Lnk_Set_HWGZ" runat="server" OnClick="Lnk_Set_HWGZ_Click">货位规则</asp:LinkButton></TD>
					                                                    <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="Lnk_Set_KCTW" runat="server" OnClick="Lnk_Set_KCTW_Click">头尾材扣重</asp:LinkButton></TD>
					                                                    <TD width="12.5%" align="center" style="height: 26px">&nbsp;</TD>
					                                                </tr>
				                                                </TABLE>
				                                                <TABLE id="TABLE3" class="fixColStyle" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server">
		                                                            <TR>
			                                                            <TD vAlign="bottom" align="left" width="22%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;IC卡</font></TD>
			                                                            <TD width="78%" bgColor="#dce8f4" height="20"></TD>
		                                                            </TR>
	                                                            </TABLE>
	                                                             <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="lnk_ICMAN" runat="server" OnClick="lnk_ICMAN_Click" >IC卡管理</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_INDoor"
                                                                                runat="server" OnClick="lnk_INDoor_Click">进门管理</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_OutDoor" runat="server" OnClick="lnk_OutDoor_Click">出门管理</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
					                                                </TR>
				                                                </TABLE>
				                                                 <TABLE id="TABLE4" class="fixColStyle" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server">
		                                                            <TR>
			                                                            <TD vAlign="bottom" align="left" width="22%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;质量检查</font></TD>
			                                                            <TD width="78%" bgColor="#dce8f4" height="20"></TD>
		                                                            </TR>
	                                                            </TABLE>
	                                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="lnk_QC" runat="server" OnClick="lnk_QC_Click" >质检</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_QR"
                                                                                runat="server" OnClick="lnk_QR_Click">质量原因</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_BZ" runat="server" OnClick="lnk_BZ_Click">标准维护</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;<asp:LinkButton ID="lnk_TXXX" runat="server" OnClick="lnk_TXXX_Click">特殊信息</asp:LinkButton></TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    <asp:LinkButton ID="lnk_JXX" runat="server" OnClick="lnk_JXX_Click">卷信息查询</asp:LinkButton>
                                                                        </td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_fydqr" runat="server" OnClick="lnk_fydqr_Click">签证装车确认</asp:LinkButton></td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
					                                                </TR>
				                                                </TABLE>
				                                                 <TABLE id="TABLE5" class="fixColStyle" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server">
		                                                            <TR>
			                                                            <TD vAlign="bottom" align="left" width="22%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;盘点管理</font></TD>
			                                                            <TD width="78%" bgColor="#dce8f4" height="20"></TD>
		                                                            </TR>
	                                                            </TABLE>
	                                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">盘点粗盘</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_CHOUP"
                                                                                runat="server" OnClick="lnk_CHOUP_Click">盘点抽盘</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_PDUP" runat="server" OnClick="lnk_PDUP_Click">盘点数据上传</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">自由盘点</asp:LinkButton>&nbsp;</TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">盘点参考</asp:LinkButton>&nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
					                                                </TR>
				                                                </TABLE>
				                                                <TABLE id="TABLE7" class="fixColStyle" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server">
		                                                            <TR>
			                                                            <TD vAlign="bottom" align="left" width="22%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;单据管理</font></TD>
			                                                            <TD width="78%" bgColor="#dce8f4" height="20"></TD>
		                                                            </TR>
	                                                            </TABLE>
	                                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" >完工单查询</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_QFYD"
                                                                                runat="server" OnClick="lnk_QFYD_Click">发运单查询</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_ZKD" runat="server" OnClick="lnk_ZKD_Click">转库单查询</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;<asp:LinkButton ID="lnk_QYWD" runat="server" OnClick="lnk_QYWD_Click">移位单查询</asp:LinkButton></TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    <asp:LinkButton ID="lnk_QTH" runat="server" OnClick="lnk_QTH_Click">退货单查询</asp:LinkButton>
                                                                        </td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;<asp:LinkButton ID="lnk_QDP" runat="server" OnClick="lnk_QDP_Click">待判品查询</asp:LinkButton></td>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    <asp:LinkButton ID="lnk_QXT" runat="server" OnClick="lnk_QXT_Click">形态转换单查询</asp:LinkButton>
                                                                        </td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_fydqrsearch" runat="server" OnClick="lnk_fydqrsearch_Click">发运单监控查询</asp:LinkButton></td>
					                                                </TR>
				                                                </TABLE>
				                                                <TABLE id="TABLE8" class="fixColStyle" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server">
		                                                            <TR>
			                                                            <TD vAlign="bottom" align="left" width="22%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;库存管理</font></TD>
			                                                            <TD width="78%" bgColor="#dce8f4" height="20"></TD>
		                                                            </TR>
	                                                            </TABLE>
	                                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="lnk_RK" runat="server" OnClick="lnk_RK_Click" >入库帐簿</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_CK"
                                                                                runat="server" OnClick="lnk_CK_Click">出库帐簿</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_CKC" runat="server" OnClick="lnk_CKC_Click">当前库存</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnkYYL" runat="server" OnClick="lnkYYL_Click">预约量查询</asp:LinkButton></TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    <asp:LinkButton ID="lnk_PC" runat="server" OnClick="lnk_PC_Click">批次管理</asp:LinkButton>&nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    <asp:LinkButton ID="lnk_EXE_QTRK" runat="server" OnClick="lnk_EXE_QTRK_Click">其他入库</asp:LinkButton>&nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_EXE_QTCK" runat="server" OnClick="lnk_EXE_QTCK_Click">其他出库</asp:LinkButton>&nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_HWView" runat="server" OnClick="lnk_HWView_Click">货位视图</asp:LinkButton>&nbsp;</td>
					                                                </TR>
					                                                
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_KCJG" 
                                                                                runat="server" onclick="lnk_KCJG_Click">库存结构</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">&nbsp;</TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
					                                                </TR>
					                                                
				                                                </TABLE>
				                                                 <TABLE id="TABLE9" class="fixColStyle"  cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server">
		                                                            <TR>
			                                                            <TD vAlign="bottom" align="left" width="22%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;统计报表</font></TD>
			                                                            <TD width="78%" bgColor="#dce8f4" height="20"></TD>
		                                                            </TR>
	                                                            </TABLE>
	                                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:LinkButton ID="lnk_FYList" runat="server" OnClick="lnk_FYList_Click">发运清单</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_HCDay"
                                                                                runat="server" OnClick="lnk_HCDay_Click">货场日报表</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_KCList" runat="server" OnClick="lnk_KCList_Click">库存明细</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;<asp:LinkButton ID="lnk_GXM" runat="server" OnClick="lnk_GXM_Click">高线月盘存表</asp:LinkButton></TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    <asp:LinkButton ID="lnk_MPC" runat="server" OnClick="lnk_MPC_Click">月盘存明细表</asp:LinkButton>
                                                                        </td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_WC" runat="server" OnClick="lnk_WC_Click">工作量统计</asp:LinkButton></td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_SXPC" runat="server" OnClick="lnk_SXPC_Click">深加工批次查询</asp:LinkButton></td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
					                                                </TR>
					                                                <TR>
					                                                   <TD width="12.5%" align="center" style="height: 26px">
						                                           &nbsp;<asp:LinkButton ID="lnk_CLHZ" runat="server" OnClick="lnk_CLHZ_Click">产量信息汇总</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                           &nbsp;<asp:LinkButton ID="lnk_CLMX"   runat="server" OnClick="lnk_CLMX_Click">产量信息明细</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
						                                                    &nbsp;</TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
						                                                    &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
					                                                </TR>
				                                                </TABLE>
				                                                <TABLE id="TABLE10" class="fixColStyle" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" runat="server">
		                                                            <TR>
			                                                            <TD vAlign="bottom" align="left" width="22%" bgColor="#dce8f4" height="20"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;数据处理</font></TD>
			                                                            <TD width="78%" bgColor="#dce8f4" height="20"></TD>
		                                                            </TR>
	                                                            </TABLE>
	                                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					                                                <TR>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_MovLog" runat="server" OnClick="lnk_MovLog_Click" >迁移日志浏览</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            <asp:LinkButton ID="lnk_DataReturn"
                                                                                runat="server" OnClick="lnk_DataReturn_Click">数据回迁</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px"><asp:LinkButton ID="lnk_TraLog" runat="server" OnClick="lnk_TraLog_Click">传输日志</asp:LinkButton></TD>
						                                                <TD width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;<asp:LinkButton ID="lnk_TraLogDel" runat="server" OnClick="lnk_TraLogDel_Click">传输日志删除</asp:LinkButton></TD>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            </td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
						                                                <td width="12.5%" align="center" style="height: 26px">
                                                                            &nbsp;</td>
					                                                </TR>
				                                                </TABLE>
													    </td>
													</tr>
												</TABLE>
											</td>
											<td vAlign="top" width="2%" height="100%"></td>
										</tr>
									</TABLE>
									<!--实际内容-->
								</td>
								<td width="3" background="Images/down/Freambg.gif"></td>
							</tr>
						</table>
				    </td>
				</tr>
				<tr>
					<td width="100%" height="3">
						<table height="3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td background="Images/down/Freambg.gif"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</html>
