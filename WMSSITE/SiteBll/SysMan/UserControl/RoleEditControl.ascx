<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoleEditControl.ascx.cs" Inherits="SiteBll_SysMan_UserControl_RoleEditControl" %>
<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<td width="1%"></td>
		<td width="98%" valign="top">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
				<TR>
					<TD width="10%">&nbsp;角色名称: </TD>
					<TD width="90%"><asp:TextBox ID="txtRoleName" runat="server" Width="90%"></asp:TextBox></TD>
			    </TR>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td colspan="2" height="6"><FONT face="宋体"></FONT></td>
				</tr>
			</TABLE>
			<fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">系统设置</font></legend>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:CheckBox ID="chk_SET_Param" runat="server" Text="参数设置" /></TD>
						<TD width="12.5%" align="center" style="height: 26px">
                            <asp:CheckBox ID="chk_SET_Store" runat="server" Text="仓库定义" /></TD>
						<TD width="12.5%" align="center" style="height: 26px">&nbsp;<asp:CheckBox ID="chk_SET_Role" runat="server" Text="角色定义" /></TD>
						<TD width="12.5%" align="center" style="height: 26px">
                            <asp:CheckBox ID="chk_SET_SCX" runat="server" Text="生产线定义" /></TD>
						<td width="12.5%" align="center" style="height: 26px">
                            <asp:CheckBox ID="chk_Set_KH" runat="server" Text="客户数据" /></td>
						<td width="12.5%" align="center" style="height: 26px">
                            <asp:CheckBox ID="chk_SET_User" runat="server" Text="用户设置" /></td>
						<td width="12.5%" align="center" style="height: 26px">
                            <asp:CheckBox ID="chk_SET_HW" runat="server" Text="货位设置" /></td>
						<td width="12.5%" align="center" style="height: 26px">
                            <asp:CheckBox ID="chk_EXE_HWVIEW" runat="server" Text="货位图" /></td>
					</TR>
                    <tr>
                        <td align="center" style="height: 25px" width="12.5%">
                            <asp:CheckBox ID="chk_exe_itembaseinfo" runat="server" Text="物料信息" /></td>
                        <td align="center" style="height: 25px" width="12.5%">
                            <asp:CheckBox ID="chk_SET_COMNC" runat="server" Text="交换日志" /></td>
                        <td align="center" style="height: 25px" width="12.5%"><asp:CheckBox ID="chk_Publish_Affiche" runat="server" Text="发布公告" /></td>
                        <td align="center" style="height: 25px" width="12.5%">
                            <asp:CheckBox ID="chk_Login_History" runat="server" Text="登录历史库" /></td>
                        <td align="center" style="height: 25px" width="12.5%">
                            <asp:CheckBox ID="chk_SYSBZBZ" runat="server" Text="包装标准" />
                        </td>
                        <td align="center" style="height: 25px" width="12.5%">
                            <asp:CheckBox ID="chk_SYSCHQP" runat="server" Text="存货去皮" />
                        </td>
                        <td align="center" style="height: 25px" width="12.5%">
                            <asp:CheckBox ID="chk_DoorManage" runat="server" Text="门岗维护" />
                        </td>
                        <td align="center" style="height: 25px" width="12.5%">
                            <asp:CheckBox ID="chk_QZSManage" runat="server" Text="签证室" />
                        </td>
                    </tr>
				</TABLE>
			</fieldset>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td colspan="2" height="6"><FONT face="宋体"></FONT></td>
				</tr>
			</TABLE>
			<fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">仓库操作</font></legend>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="12.5%" align="center">&nbsp;<asp:CheckBox ID="chk_Bar_Print" runat="server" Text="称重打标" /></TD>
						<TD width="12.5%" align="center">
                            <asp:CheckBox ID="chk_EXE_BARRK" runat="server" Text="单卷入库" /></TD>
						<TD width="12.5%" align="center">&nbsp;<asp:CheckBox ID="chk_EXE_PCHRK" runat="server" Text="整批入库" /></TD>
						<TD width="12.5%" align="center">
                            <asp:CheckBox ID="chk_EXE_SELL_CK" runat="server" Text="销售出库" /></TD>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_EXE_BARCK" runat="server" Text="单卷转库" /></td>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_EXE_PCHCK" runat="server" Text="整批转库" /></td>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_EXE_QTCK" runat="server" Text="其他出库单" /></td>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_Bar_BZ" runat="server" Text="标准设置" /></td>
					</TR>
                    <tr>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_EXE_PCHPD" runat="server" Text="盘点粗盘" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_EXE_BARPD" runat="server" Text="盘点抽盘" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_EXE_SHAPE" runat="server" Text="形态转换" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_Q_KC" runat="server" Text="库存管理" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_EXE_YW" runat="server" Text="移位操作" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_EXE_ZYPD" runat="server" Text="自由盘点单" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_EXE_TH" runat="server" Text="终端退货" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_CANCELBILL" runat="server" Text="单据作废" /></td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_CHE_QU" runat="server" Text="质检" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_EXE_QCRK" runat="server" Text="期初入库" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_EXE_QTRK" runat="server" Text="其他入库" /></td>
                        <td align="center" colspan="2" style="height: 20px">
                            <asp:CheckBox ID="chk_EXE_CLOSE_ZKD" runat="server" Text="终端关闭转库单" /></td>
                        <td align="center" style="height: 20px" width="12.5%">
                            <asp:CheckBox ID="chk_Q_SXPC" runat="server" Text="深加工对应批次查询" /></td>
                        </td>
                        <td align="center" style="height: 20px" width="12.5%">
                        </td>
                        <td align="center" style="height: 20px" width="12.5%">
                        </td>
                    </tr>
				</TABLE>
			</fieldset>
			<fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">单据查询</font></legend>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="12.5%" align="center">&nbsp;<asp:CheckBox ID="chk_Q_WGD" runat="server" Text="完工单查询" /></TD>
						<TD align="center" style="width: 13%">
                            <asp:CheckBox ID="chk_Q_FYD" runat="server" Text="发运单查询" /></TD>
						<TD width="12.5%" align="center">&nbsp;<asp:CheckBox ID="chk_Q_ZKD" runat="server" Text="转库单查询" /></TD>
						<TD width="12.5%" align="center">
                            <asp:CheckBox ID="chk_exe_dpqry" runat="server" Text="待判品查询" /></TD>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_BILLSENDLOG" runat="server" Text="单据传输日志" /></td>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_RESENDBILL" runat="server" Text="传输日志重发" /></td>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_Q_THD" runat="server" Text="退货单查询" /></td>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_Q_YWD" runat="server" Text="移位单查询" /></td>
					</TR>
                    <tr>
                        <td align="center" style="height: 29px" colspan="1">
                            <asp:CheckBox ID="chk_FYD_CancelFinish" runat="server" Text="取消发运单完成状态" /></td>
                        <td align="center" colspan="1" style="height: 29px">
                            <asp:CheckBox ID="chk_FYD_UpdateCXH" runat="server" Text="修改发运单车厢号" /></td>
                        <td align="center" style="height: 29px" width="12.5%">
                            <asp:CheckBox ID="chk_exe_delxtzhd" runat="server" Text="删除形态转换单" /></td>
                        <td align="center" style="height: 29px" width="12.5%">
                            <asp:CheckBox ID="chk_fyd_hgqr" runat="server" Text="发运单货管确认" /></td>
                        <td align="center" style="height: 29px" width="12.5%">
                            <asp:CheckBox ID="chk_fyd_zjqr" runat="server" Text="发运单质检确认" /></td>
                        <td align="center" style="height: 29px" width="12.5%">
                            <asp:CheckBox ID="chk_fyd_mgqr" runat="server" Text="发运单门岗确认" /></td>
                        <td align="center" style="height: 29px" width="12.5%">
                            <asp:CheckBox ID="chk_FYD_QRSearch" runat="server" Text="发运单确认查询" /></td>
                        <td align="center" style="height: 29px" width="12.5%"></td>
                    </tr>
				</TABLE>
			</fieldset>
			<fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">IC卡管理</font></legend>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="12.5%" align="center" >&nbsp;<asp:CheckBox ID="chk_IC_FK" runat="server" Text="IC卡发放" /></TD>
						<TD align="center" style="width: 13%;">
                            <asp:CheckBox ID="chk_IC_GS" runat="server" Text="IC卡挂失" /></TD>
						<TD width="12.5%" align="center" >&nbsp;<asp:CheckBox ID="chk_IC_ZT" runat="server" Text="IC卡退卡" /></TD>
						<TD width="12.5%" align="center">
                            <asp:CheckBox ID="chk_IC_ZX" runat="server" Text="IC卡注销" /></TD>
						<td width="12.5%" align="center">
                            </td>
						<td width="12.5%" align="center">
                            </td>
						<td width="12.5%" align="center">
                            </td>
						<td width="12.5%" align="center">
                            </td>
					</TR>
				</TABLE>
			</fieldset>
			<fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">盘点管理</font></legend>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="12.5%" align="center" >&nbsp;<asp:CheckBox ID="chk_Q_PDD" runat="server" Text="粗盘抽盘单" /></TD>
						<TD align="center" style="width: 13%;">
                            <asp:CheckBox ID="chk_M_PDD" runat="server" Text="盘点制单" /></TD>
						<TD width="12.5%" align="center" >&nbsp;<asp:CheckBox ID="chk_SH_PDD" runat="server" Text="盘点审核" /></TD>
						<TD width="12.5%" align="center">
                            <asp:CheckBox ID="chk_UP_PDD" runat="server" Text="数据上传" /></TD>
						<td width="12.5%" align="center">
                            <asp:CheckBox ID="chk_EXE_KCTZ" runat="server" Text="库存调整" /></td>
						<td width="12.5%" align="center">
                            </td>
						<td width="12.5%" align="center">
                            </td>
						<td width="12.5%" align="center">
                            </td>
					</TR>
				</TABLE>
			</fieldset>
			<fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">车辆管理</font></legend>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="12.5%" align="center" >&nbsp;<asp:CheckBox ID="chk_Car_In" runat="server" Text="入门管理" /></TD>
						<TD align="center" style="width: 13%;">
                            <asp:CheckBox ID="chk_Car_Out" runat="server" Text="出门管理" /></TD>
						<TD width="12.5%" align="center" >&nbsp;</TD>
						<TD width="12.5%" align="center">
                            </TD>
						<td width="12.5%" align="center">
                            </td>
						<td width="12.5%" align="center">
                            </td>
						<td width="12.5%" align="center">
                            </td>
						<td width="12.5%" align="center">
                            </td>
					</TR>
				</TABLE>
			</fieldset>
			<fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">单据制作</font></legend>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="12.5%" align="center" style="height: 20px" >&nbsp;<asp:CheckBox ID="chk_zd_ZZWGD" runat="server" Text="完工单" /></TD>
						<TD align="center" style="width: 13%; height: 20px;">
                            <asp:CheckBox ID="chk_zd_ZZFYD" runat="server" Text="发运单" /></TD>
						<TD width="12.5%" align="center" style="height: 20px" >&nbsp;<asp:CheckBox ID="chk_zd_ZZXTZHD" runat="server" Text="形态转换单" /></TD>
						<TD width="12.5%" align="center" style="height: 20px">
                            <asp:CheckBox ID="chk_zd_ZZZKD" runat="server" Text="转库单" /></TD>
						<td width="12.5%" align="center" style="height: 20px">
                            <asp:CheckBox ID="chk_zd_ZYPD" runat="server" Text="自由盘点单" /></td>
						<td width="12.5%" align="center" style="height: 20px">
                            <asp:CheckBox ID="chk_ZD_QTCK" runat="server" Text="其它出库单" /></td>
						<td width="12.5%" align="center" style="height: 20px">
                            <asp:CheckBox ID="chk_zd_HBFYD" runat="server" Text="后补发运单" /></td>
						<td width="12.5%" align="center" style="height: 20px">
                            <asp:CheckBox ID="chk_zd_HBZKD" runat="server" Text="后补转库单" /></td>
					</TR>
				</TABLE>
			</fieldset>
			<fieldset><legend><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">数据处理</font></legend>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="12.5%" align="center" style="height: 20px" >&nbsp;<asp:CheckBox ID="chk_DataReturn" runat="server" Text="数据回迁" /></TD>
						<TD align="center" style="width: 13%; height: 20px;"><asp:CheckBox ID="chk_DataMoveLog" runat="server" Text="数据迁移日志查询" /></TD>
						<TD width="12.5%" align="center" style="height: 20px" ><asp:CheckBox ID="chk_Log_Delete" runat="server" Text="日志删除" />&nbsp;</TD>
						<TD width="12.5%" align="center" style="height: 20px">
                            </TD>
						<td width="12.5%" align="center" style="height: 20px">
                            </td>
						<td width="12.5%" align="center" style="height: 20px">
                            </td>
						<td width="12.5%" align="center" style="height: 20px">
                            </td>
						<td width="12.5%" align="center" style="height: 20px">
                            </td>
					</TR>
				</TABLE>
			</fieldset>
		</td>
		<td width="1%"></td>
	</TR>
</TABLE>