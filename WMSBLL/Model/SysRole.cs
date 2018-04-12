using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Acctrue.WM_WES.DataAccess;

namespace ACCTRUE.WMSBLL.Model
{
    public class SysRole
    {
        public SysRole()
		{}
		private string _rolename;
		private bool _exe_pchrk=false;
		private bool _exe_barrk=false;
		private bool _exe_sell_ck=false;
        private bool _exe_pchck = false;
        private bool _exe_barck = false;
        private bool _exe_pchpd = false;
        private bool _exe_barpd = false;
        private bool _exe_yw = false;
        private bool _exe_shape = false;
        private bool _ic_fk = false;
        private bool _ic_gs = false;
        private bool _ic_zx = false;
        private bool _ic_zt = false;
        private bool _car_in = false;
        private bool _car_out = false;
        private bool _bar_print = false;
        private bool _bar_bz = false;
        private bool _q_wgd = false;
        private bool _q_fyd = false;
        private bool _q_zkd = false;
        private bool _q_pdd = false;
        private bool _m_ywd = false;
        private bool _q_ywd = false;
        private bool _m_pdd = false;
        private bool _sh_pdd = false;
        private bool _up_pdd = false;
        private bool _q_outkc = false;
        private bool _q_kc = false;
        private bool _set_param = false;
        private bool _set_role = false;
        private bool _set_user = false;
        private bool _set_store = false;
        private bool _set_hw = false;
        private bool _set_kh = false;
        private bool _set_comnc = false;
        private bool _set_scx = false;
        private bool _cancelbill = false;
        private bool _che_qu = false;
        private bool _resendbill = false;
        private bool _billsendlog = false;
        private bool _exe_hwview = false;
        private bool _exe_kctz = false;
        private bool _q_thd = false;
        private bool _exe_th = false;
        private bool _exe_qcrk = false;
        private bool _exe_qtck = false;
        private bool _exe_close_zkd = false;
        private bool _exe_zypd = false;
        private bool _zd_hbfyd = false;
        private bool _zd_hbzkd = false;
        private bool _zd_zzwgd = false;
        private bool _zd_zzfyd = false;
        private bool _zd_zzzkd = false;
        private bool _zd_zzxtzhd = false;
        private bool _zd_zypd = false;
        private bool _zd_qtck = false;
        private bool _fyd_cancelfinish = false;
        private bool _fyd_updatecxh = false;
        private bool _exe_qtrk = false;
        private bool _exe_delxtzhd = false;
        private bool _exe_dpqry = false;
        private bool _exe_itembaseinfo = false;
        private bool _data_return = false;
        private bool _data_movelog = false;
        private bool _log_delete = false;
        private bool _publish_affiche = false;
        private bool _login_history = false;
        private bool _syschqp = false;
        private bool _sysbzbz = false;
        private bool _Q_SXPC = false;
        private bool _fyd_hgqr = false;//发运单货管确认
        private bool _fyd_zjqr = false;//发运单质检确认
        private bool _fyd_mgqr = false;//发运单门岗确认
        private bool _FYD_QRSearch = false;//发运单确认查询
        private bool _doormanage = false;//门岗维护
        private bool _qzsmanage = false;//签证室维护
		/// <summary>
		/// 角色名称
		/// </summary>
        /// 
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
        /// <summary>
        /// 发运单确认查询
        /// </summary>
        public bool FYD_QRSearch
        {
            set { _FYD_QRSearch = value; }
            get { return _FYD_QRSearch; }
        }
        /// <summary>
        /// 门岗维护
        /// </summary>
        public bool DoorManage
        {
            set { _doormanage = value; }
            get { return _doormanage; }
        }
        /// <summary>
        /// 签证室维护
        /// </summary>
        public bool QZSManage
        {
            set { _qzsmanage = value; }
            get { return _qzsmanage; }
        }
        /// <summary>
        /// 货管确认
        /// </summary>
        public bool FYD_HGQR
        {
            set { _fyd_hgqr = value; }
            get { return _fyd_hgqr; }
        }
        /// <summary>
        /// 质检确认
        /// </summary>
        public bool FYD_ZJQR
        {
            set { _fyd_zjqr = value; }
            get { return _fyd_zjqr; }
        }
        /// <summary>
        /// 门岗确认
        /// </summary>
        public bool FYD_MGQR
        {
            set { _fyd_mgqr = value; }
            get { return _fyd_mgqr; }
        }
        public bool Q_SXPC
        {
            set { _Q_SXPC = value; }
            get { return _Q_SXPC; }
        }
        public bool SYSCHQP
        {
            set { _syschqp = value; }
            get { return _syschqp; }
        }
        public bool SYSBZBZ
        {
            set { _sysbzbz = value; }
            get { return _sysbzbz; }
        }
		/// <summary>
        /// 终端整批入库
		/// </summary>
		public bool EXE_PCHRK
		{
			set{ _exe_pchrk=value;}
			get{return _exe_pchrk;}
		}
		/// <summary>
        /// 终端单卷入库
		/// </summary>
		public bool EXE_BARRK
		{
			set{ _exe_barrk=value;}
			get{return _exe_barrk;}
		}
		/// <summary>
        /// 终端销售出库
		/// </summary>
		public bool EXE_SELL_CK
		{
			set{ _exe_sell_ck=value;}
			get{return _exe_sell_ck;}
		}
		/// <summary>
        /// 终端整批出库
		/// </summary>
		public bool EXE_PCHCK
		{
			set{ _exe_pchck=value;}
			get{return _exe_pchck;}
		}
		/// <summary>
        /// 终端单卷出库
		/// </summary>
		public bool EXE_BARCK
		{
			set{ _exe_barck=value;}
			get{return _exe_barck;}
		}
		/// <summary>
        /// 终端盘点粗盘
		/// </summary>
		public bool EXE_PCHPD
		{
			set{ _exe_pchpd=value;}
			get{return _exe_pchpd;}
		}
		/// <summary>
        /// 终端盘点抽盘
		/// </summary>
		public bool EXE_BARPD
		{
			set{ _exe_barpd=value;}
			get{return _exe_barpd;}
		}
		/// <summary>
        /// 终端移位
		/// </summary>
		public bool EXE_YW
		{
			set{ _exe_yw=value;}
			get{return _exe_yw;}
		}
		/// <summary>
        /// 终端形态转换
		/// </summary>
		public bool EXE_SHAPE
		{
			set{ _exe_shape=value;}
			get{return _exe_shape;}
		}
		/// <summary>
        /// IC卡发放
		/// </summary>
		public bool IC_FK
		{
			set{ _ic_fk=value;}
			get{return _ic_fk;}
		}
		/// <summary>
        /// IC卡挂失
		/// </summary>
		public bool IC_GS
		{
			set{ _ic_gs=value;}
			get{return _ic_gs;}
		}
		/// <summary>
        /// IC卡注销
		/// </summary>
		public bool IC_ZX
		{
			set{ _ic_zx=value;}
			get{return _ic_zx;}
		}
		/// <summary>
        /// IC卡暂停
		/// </summary>
		public bool IC_ZT
		{
			set{ _ic_zt=value;}
			get{return _ic_zt;}
		}
		/// <summary>
        /// 车辆入门管理
		/// </summary>
		public bool Car_In
		{
			set{ _car_in=value;}
			get{return _car_in;}
		}
		/// <summary>
        /// 车辆出门管理
		/// </summary>
		public bool Car_Out
		{
			set{ _car_out=value;}
			get{return _car_out;}
		}
		/// <summary>
        /// 称重打标
		/// </summary>
		public bool Bar_Print
		{
			set{ _bar_print=value;}
			get{return _bar_print;}
		}
		/// <summary>
		/// 标准设置
		/// </summary>
		public bool Bar_BZ
		{
			set{ _bar_bz=value;}
			get{return _bar_bz;}
		}
		/// <summary>
        /// 完工单查询
		/// </summary>
		public bool Q_WGD
		{
			set{ _q_wgd=value;}
			get{return _q_wgd;}
		}
		/// <summary>
        /// 发运单查询
		/// </summary>
		public bool Q_FYD
		{
			set{ _q_fyd=value;}
			get{return _q_fyd;}
		}
		/// <summary>
        /// 转库单查询
		/// </summary>
		public bool Q_ZKD
		{
			set{ _q_zkd=value;}
			get{return _q_zkd;}
		}
		/// <summary>
        /// 抽盘粗盘单
		/// </summary>
		public bool Q_PDD
		{
			set{ _q_pdd=value;}
			get{return _q_pdd;}
		}
		/// <summary>
        /// 移位单生成
		/// </summary>
		public bool M_YWD
		{
			set{ _m_ywd=value;}
			get{return _m_ywd;}
		}
		/// <summary>
        /// 移位单查询
		/// </summary>
		public bool Q_YWD
		{
			set{ _q_ywd=value;}
			get{return _q_ywd;}
		}
		/// <summary>
        /// 盘点单生成
		/// </summary>
		public bool M_PDD
		{
			set{ _m_pdd=value;}
			get{return _m_pdd;}
		}
		/// <summary>
        /// 盘点单审核
		/// </summary>
		public bool SH_PDD
		{
			set{ _sh_pdd=value;}
			get{return _sh_pdd;}
		}
		/// <summary>
        /// 盘点数据上传
		/// </summary>
		public bool UP_PDD
		{
			set{ _up_pdd=value;}
			get{return _up_pdd;}
		}
		/// <summary>
        /// 线材出库查询
		/// </summary>
		public bool Q_OutKC
		{
			set{ _q_outkc=value;}
			get{return _q_outkc;}
		}
		/// <summary>
        /// 库存管理
		/// </summary>
		public bool Q_KC
		{
			set{ _q_kc=value;}
			get{return _q_kc;}
		}
		/// <summary>
        /// 系统参数设置
		/// </summary>
		public bool SET_Param
		{
			set{ _set_param=value;}
			get{return _set_param;}
		}
		/// <summary>
        /// 系统角色定义
		/// </summary>
		public bool SET_Role
		{
			set{ _set_role=value;}
			get{return _set_role;}
		}
		/// <summary>
        /// 系统用户设置
		/// </summary>
		public bool SET_User
		{
			set{ _set_user=value;}
			get{return _set_user;}
		}
		/// <summary>
        /// 系统仓库设置
		/// </summary>
		public bool SET_Store
		{
			set{ _set_store=value;}
			get{return _set_store;}
		}
		/// <summary>
        /// 仓库货位设置
		/// </summary>
		public bool SET_HW
		{
			set{ _set_hw=value;}
			get{return _set_hw;}
		}
		/// <summary>
        /// 客户维护
		/// </summary>
		public bool SET_KH
		{
			set{ _set_kh=value;}
			get{return _set_kh;}
		}
		/// <summary>
		/// 交换日志
		/// </summary>
		public bool SET_COMNC
		{
			set{ _set_comnc=value;}
			get{return _set_comnc;}
		}
		/// <summary>
		/// 设置生产线
		/// </summary>
		public bool SET_SCX
		{
			set{ _set_scx=value;}
			get{return _set_scx;}
		}
		/// <summary>
		/// 单据作废
		/// </summary>
		public bool CANCELBILL
		{
			set{ _cancelbill=value;}
			get{return _cancelbill;}
		}
		/// <summary>
		/// 质检
		/// </summary>
		public bool Che_Qu
		{
			set{ _che_qu=value;}
			get{return _che_qu;}
		}
		/// <summary>
		/// 重发单据
		/// </summary>
		public bool RESENDBILL
		{
			set{ _resendbill=value;}
			get{return _resendbill;}
		}
		/// <summary>
		/// 传输志日
		/// </summary>
		public bool BILLSENDLOG
		{
			set{ _billsendlog=value;}
			get{return _billsendlog;}
		}
		/// <summary>
		/// 货位视图
		/// </summary>
		public bool EXE_HWVIEW
		{
			set{ _exe_hwview=value;}
			get{return _exe_hwview;}
		}
		/// <summary>
		/// 库存调整
		/// </summary>
		public bool EXE_KCTZ
		{
			set{ _exe_kctz=value;}
			get{return _exe_kctz;}
		}
		/// <summary>
		/// 退货单
		/// </summary>
		public bool Q_THD
		{
			set{ _q_thd=value;}
			get{return _q_thd;}
		}
		/// <summary>
		/// 终端退货
		/// </summary>
		public bool EXE_TH
		{
			set{ _exe_th=value;}
			get{return _exe_th;}
		}
		/// <summary>
		/// 期初入库
		/// </summary>
		public bool EXE_QCRK
		{
			set{ _exe_qcrk=value;}
			get{return _exe_qcrk;}
		}
		/// <summary>
		/// 其它出库单
		/// </summary>
		public bool EXE_QTCK
		{
			set{ _exe_qtck=value;}
			get{return _exe_qtck;}
		}
		/// <summary>
		/// 终端关闭转库单
		/// </summary>
		public bool EXE_CLOSE_ZKD
		{
			set{ _exe_close_zkd=value;}
			get{return _exe_close_zkd;}
		}
		/// <summary>
		/// 自由盘点单
		/// </summary>
		public bool EXE_ZYPD
		{
			set{ _exe_zypd=value;}
			get{return _exe_zypd;}
		}
		/// <summary>
		/// 后补发运单
		/// </summary>
		public bool ZD_HBFYD
		{
			set{ _zd_hbfyd=value;}
			get{return _zd_hbfyd;}
		}
		/// <summary>
		/// 后补转库单
		/// </summary>
		public bool ZD_HBZKD
		{
			set{ _zd_hbzkd=value;}
			get{return _zd_hbzkd;}
		}
		/// <summary>
		/// 完工单（单据制作）
		/// </summary>
		public bool ZD_ZZWGD
		{
			set{ _zd_zzwgd=value;}
			get{return _zd_zzwgd;}
		}
		/// <summary>
		/// 发运单（单据制作）
		/// </summary>
		public bool ZD_ZZFYD
		{
			set{ _zd_zzfyd=value;}
			get{return _zd_zzfyd;}
		}
		/// <summary>
		/// 转库单（单据制作）
		/// </summary>
		public bool ZD_ZZZKD
		{
			set{ _zd_zzzkd=value;}
			get{return _zd_zzzkd;}
		}
		/// <summary>
		/// 形态转换单（单据制作）
		/// </summary>
		public bool ZD_ZZXTZHD
		{
			set{ _zd_zzxtzhd=value;}
			get{return _zd_zzxtzhd;}
		}
		/// <summary>
		/// 自由盘点
		/// </summary>
		public bool ZD_ZYPD
		{
			set{ _zd_zypd=value;}
			get{return _zd_zypd;}
		}
		/// <summary>
		/// 其他出库单
		/// </summary>
		public bool ZD_QTCK
		{
			set{ _zd_qtck=value;}
			get{return _zd_qtck;}
		}
		/// <summary>
		/// 取消发运单完成
		/// </summary>
		public bool FYD_CancelFinish
		{
			set{ _fyd_cancelfinish=value;}
			get{return _fyd_cancelfinish;}
		}
		/// <summary>
		/// 修改发运单车箱号
		/// </summary>
		public bool FYD_UpdateCXH
		{
			set{ _fyd_updatecxh=value;}
			get{return _fyd_updatecxh;}
		}
		/// <summary>
		/// 其它入库
		/// </summary>
		public bool EXE_QTRK
		{
			set{ _exe_qtrk=value;}
			get{return _exe_qtrk;}
		}
		/// <summary>
		/// 删除形态转换单
		/// </summary>
		public bool exe_delxtzhd
		{
			set{ _exe_delxtzhd=value;}
			get{return _exe_delxtzhd;}
		}
		/// <summary>
		/// 待判品查询
		/// </summary>
		public bool exe_dpqry
		{
			set{ _exe_dpqry=value;}
			get{return _exe_dpqry;}
		}
		/// <summary>
		/// 物料基础信息
		/// </summary>
		public bool exe_itembaseinfo
		{
			set{ _exe_itembaseinfo=value;}
			get{return _exe_itembaseinfo;}
		}
        /// <summary>
        /// 数据回迁
        /// </summary>
        public bool Data_return
        {
            set { _data_return = value; }
            get { return _data_return; }
        }
        /// <summary>
        /// 迁移日志浏览
        /// </summary>
        public bool Data_MoveLog
        {
            set { _data_movelog = value; }
            get { return _data_movelog; }
        }
        /// <summary>
        /// 日志删除
        /// </summary>
        public bool Log_Delete
        {
            set { _log_delete = value; }
            get { return this._log_delete; }
        }
        /// <summary>
        /// 发布系统公告信息
        /// </summary>
        public bool Publish_Affiche
        {
            set { _publish_affiche = value; }
            get { return this._publish_affiche; }
        }
        /// <summary>
        /// 登录历史库
        /// </summary>
        public bool Login_History
        {
            set { _login_history = value; }
            get { return this._login_history; }
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public static List<SysRole> GetRoleList()
        {
            List<SysRole> roles = new List<SysRole>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from WMS_Pub_Role ");
            strSql.Append(" order by RoleName ");
            AdoHelper dataHelp = new SqlHelp();
            using (SqlDataReader sdr = (SqlDataReader)dataHelp.ExecuteReader(Common.GetConnectString(), CommandType.Text, strSql.ToString()))
            {
                while (sdr.Read())
                {
                    SysRole role = new SysRole();
                    role.Bar_BZ = Convert.ToBoolean(sdr["Bar_BZ"]);
                    role.Bar_Print = Convert.ToBoolean(sdr["Bar_Print"]);
                    role.Bar_Print = Convert.ToBoolean(sdr["Bar_Print"]);
                    role.BILLSENDLOG = Convert.ToBoolean(sdr["BILLSENDLOG"]);
                    role.CANCELBILL = Convert.ToBoolean(sdr["CANCELBILL"]);
                    role.Car_In = Convert.ToBoolean(sdr["Car_In"]);
                    role.Car_Out = Convert.ToBoolean(sdr["Car_Out"]);
                    role.Che_Qu = Convert.ToBoolean(sdr["Che_Qu"]);
                    role.EXE_BARCK = Convert.ToBoolean(sdr["EXE_BARCK"]);
                    role.EXE_BARPD = Convert.ToBoolean(sdr["EXE_BARPD"]);
                    role.EXE_BARRK = Convert.ToBoolean(sdr["EXE_BARRK"]);
                    role.EXE_CLOSE_ZKD = Convert.ToBoolean(sdr["EXE_CLOSE_ZKD"]);
                    role.exe_delxtzhd = Convert.ToBoolean(sdr["exe_delxtzhd"]);
                    role.exe_dpqry = Convert.ToBoolean(sdr["exe_dpqry"]);
                    role.EXE_HWVIEW = Convert.ToBoolean(sdr["EXE_HWVIEW"]);
                    role.exe_itembaseinfo = Convert.ToBoolean(sdr["exe_itembaseinfo"]);
                    role.EXE_KCTZ = Convert.ToBoolean(sdr["EXE_KCTZ"]);
                    role.EXE_PCHCK = Convert.ToBoolean(sdr["EXE_PCHCK"]);
                    role.EXE_PCHPD = Convert.ToBoolean(sdr["EXE_PCHPD"]);
                    role.EXE_PCHRK = Convert.ToBoolean(sdr["EXE_PCHRK"]);
                    role.EXE_QCRK = Convert.ToBoolean(sdr["EXE_QCRK"]);
                    role.EXE_QTCK = Convert.ToBoolean(sdr["EXE_QTCK"]);
                    role.EXE_QTRK = Convert.ToBoolean(sdr["EXE_QTRK"]);
                    role.EXE_SELL_CK = Convert.ToBoolean(sdr["EXE_SELL_CK"]);
                    role.EXE_SHAPE = Convert.ToBoolean(sdr["EXE_SHAPE"]);
                    role.EXE_TH = Convert.ToBoolean(sdr["EXE_TH"]);
                    role.EXE_YW = Convert.ToBoolean(sdr["EXE_YW"]);
                    role.EXE_ZYPD = Convert.ToBoolean(sdr["EXE_ZYPD"]);
                    role.FYD_CancelFinish = Convert.ToBoolean(sdr["FYD_CancelFinish"]);
                    role.FYD_UpdateCXH = Convert.ToBoolean(sdr["FYD_UpdateCXH"]);
                    role.IC_FK = Convert.ToBoolean(sdr["IC_FK"]);
                    role.IC_GS = Convert.ToBoolean(sdr["IC_GS"]);
                    role.IC_ZT = Convert.ToBoolean(sdr["IC_ZT"]);
                    role.IC_ZX = Convert.ToBoolean(sdr["IC_ZX"]);
                    role.M_PDD = Convert.ToBoolean(sdr["M_PDD"]);
                    role.M_YWD = Convert.ToBoolean(sdr["M_YWD"]);
                    role.Q_FYD = Convert.ToBoolean(sdr["Q_FYD"]);
                    role.Q_KC = Convert.ToBoolean(sdr["Q_KC"]);
                    role.Q_OutKC = Convert.ToBoolean(sdr["Q_OutKC"]);
                    role.Q_PDD = Convert.ToBoolean(sdr["Q_PDD"]);
                    role.Q_THD = Convert.ToBoolean(sdr["Q_THD"]);
                    role.Q_WGD = Convert.ToBoolean(sdr["Q_WGD"]);
                    role.Q_YWD = Convert.ToBoolean(sdr["Q_YWD"]);
                    role.Q_ZKD = Convert.ToBoolean(sdr["Q_ZKD"]);
                    role.RESENDBILL = Convert.ToBoolean(sdr["RESENDBILL"]);
                    role.RoleName =sdr["RoleName"].ToString();
                    role.SET_COMNC = Convert.ToBoolean(sdr["SET_COMNC"]);
                    role.SET_HW = Convert.ToBoolean(sdr["SET_HW"]);
                    role.SET_KH = Convert.ToBoolean(sdr["SET_KH"]);
                    role.SET_Param = Convert.ToBoolean(sdr["SET_Param"]);
                    role.SET_Role = Convert.ToBoolean(sdr["SET_Role"]);
                    role.SET_SCX = Convert.ToBoolean(sdr["SET_SCX"]);
                    role.SET_Store = Convert.ToBoolean(sdr["SET_Store"]);
                    role.SET_User = Convert.ToBoolean(sdr["SET_User"]);
                    role.SH_PDD = Convert.ToBoolean(sdr["SH_PDD"]);
                    role.UP_PDD = Convert.ToBoolean(sdr["UP_PDD"]);
                    role.ZD_HBFYD = Convert.ToBoolean(sdr["ZD_HBFYD"]);
                    role.ZD_HBZKD = Convert.ToBoolean(sdr["ZD_HBZKD"]);
                    role.ZD_QTCK = Convert.ToBoolean(sdr["ZD_QTCK"]);
                    role.ZD_ZYPD = Convert.ToBoolean(sdr["ZD_ZYPD"]);
                    role.ZD_ZZFYD = Convert.ToBoolean(sdr["ZD_ZZFYD"]);
                    role.ZD_ZZWGD = Convert.ToBoolean(sdr["ZD_ZZWGD"]);
                    role.ZD_ZZXTZHD = Convert.ToBoolean(sdr["ZD_ZZXTZHD"]);
                    role.ZD_ZZZKD = Convert.ToBoolean(sdr["ZD_ZZZKD"]);
                    role.Data_return = Convert.ToBoolean(sdr["Data_return"]);
                    role.Data_MoveLog = Convert.ToBoolean(sdr["Data_MoveLog"]);
                    role.Log_Delete = Convert.ToBoolean(sdr["Log_Delete"]);
                    role.Publish_Affiche = Convert.ToBoolean(sdr["Publish_Affiche"]);
                    role.Login_History = Convert.ToBoolean(sdr["Login_History"]);
                    role.SYSBZBZ = Convert.ToBoolean(sdr["SYSBZBZ"]);
                    role.SYSCHQP = Convert.ToBoolean(sdr["SYSCHQP"]);
                    role.Q_SXPC = Convert.ToBoolean(sdr["Q_SXPC"]);
                    role.FYD_HGQR = Convert.ToBoolean(sdr["FYD_HGQR"]);
                    role.FYD_ZJQR = Convert.ToBoolean(sdr["FYD_ZJQR"]);
                    role.FYD_MGQR = Convert.ToBoolean(sdr["FYD_MGQR"]);
                    role.DoorManage = Convert.ToBoolean(sdr["DoorManage"]);
                    role.QZSManage = Convert.ToBoolean(sdr["qzsmanage"]);
                    role.FYD_QRSearch = Convert.ToBoolean(sdr["fyd_qrsearch"]);
                    roles.Add(role);

                }
                sdr.Dispose();
            }
            if (roles.Count > 0)
                return roles;
            return null;
        }

        /// <summary>
        /// 获取角色实体
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public static SysRole GetRole(string roleName)
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from WMS_Pub_Role ");
			strSql.Append(" where RoleName=@RoleName");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar)};
            parameters[0].Value = roleName;
            SysRole role=null;
            AdoHelper dataHelp=new SqlHelp();
            using (SqlDataReader sdr = (SqlDataReader)dataHelp.ExecuteReader(Common.GetConnectString(), CommandType.Text,strSql.ToString(),parameters))
            {
                if (sdr.Read())
                {
                    role = new SysRole();
                    role = new SysRole();
                    role.Bar_BZ = Convert.ToBoolean(sdr["Bar_BZ"]);
                    role.Bar_Print = Convert.ToBoolean(sdr["Bar_Print"]);
                    role.Bar_Print = Convert.ToBoolean(sdr["Bar_Print"]);
                    role.BILLSENDLOG = Convert.ToBoolean(sdr["BILLSENDLOG"]);
                    role.CANCELBILL = Convert.ToBoolean(sdr["CANCELBILL"]);
                    role.Car_In = Convert.ToBoolean(sdr["Car_In"]);
                    role.Car_Out = Convert.ToBoolean(sdr["Car_Out"]);
                    role.Che_Qu = Convert.ToBoolean(sdr["Che_Qu"]);
                    role.EXE_BARCK = Convert.ToBoolean(sdr["EXE_BARCK"]);
                    role.EXE_BARPD = Convert.ToBoolean(sdr["EXE_BARPD"]);
                    role.EXE_BARRK = Convert.ToBoolean(sdr["EXE_BARRK"]);
                    role.EXE_CLOSE_ZKD = Convert.ToBoolean(sdr["EXE_CLOSE_ZKD"]);
                    role.exe_delxtzhd = Convert.ToBoolean(sdr["exe_delxtzhd"]);
                    role.exe_dpqry = Convert.ToBoolean(sdr["exe_dpqry"]);
                    role.EXE_HWVIEW = Convert.ToBoolean(sdr["EXE_HWVIEW"]);
                    role.exe_itembaseinfo = Convert.ToBoolean(sdr["exe_itembaseinfo"]);
                    role.EXE_KCTZ = Convert.ToBoolean(sdr["EXE_KCTZ"]);
                    role.EXE_PCHCK = Convert.ToBoolean(sdr["EXE_PCHCK"]);
                    role.EXE_PCHPD = Convert.ToBoolean(sdr["EXE_PCHPD"]);
                    role.EXE_PCHRK = Convert.ToBoolean(sdr["EXE_PCHRK"]);
                    role.EXE_QCRK = Convert.ToBoolean(sdr["EXE_QCRK"]);
                    role.EXE_QTCK = Convert.ToBoolean(sdr["EXE_QTCK"]);
                    role.EXE_QTRK = Convert.ToBoolean(sdr["EXE_QTRK"]);
                    role.EXE_SELL_CK = Convert.ToBoolean(sdr["EXE_SELL_CK"]);
                    role.EXE_SHAPE = Convert.ToBoolean(sdr["EXE_SHAPE"]);
                    role.EXE_TH = Convert.ToBoolean(sdr["EXE_TH"]);
                    role.EXE_YW = Convert.ToBoolean(sdr["EXE_YW"]);
                    role.EXE_ZYPD = Convert.ToBoolean(sdr["EXE_ZYPD"]);
                    role.FYD_CancelFinish = Convert.ToBoolean(sdr["FYD_CancelFinish"]);
                    role.FYD_UpdateCXH = Convert.ToBoolean(sdr["FYD_UpdateCXH"]);
                    role.IC_FK = Convert.ToBoolean(sdr["IC_FK"]);
                    role.IC_GS = Convert.ToBoolean(sdr["IC_GS"]);
                    role.IC_ZT = Convert.ToBoolean(sdr["IC_ZT"]);
                    role.IC_ZX = Convert.ToBoolean(sdr["IC_ZX"]);
                    role.M_PDD = Convert.ToBoolean(sdr["M_PDD"]);
                    role.M_YWD = Convert.ToBoolean(sdr["M_YWD"]);
                    role.Q_FYD = Convert.ToBoolean(sdr["Q_FYD"]);
                    role.Q_KC = Convert.ToBoolean(sdr["Q_KC"]);
                    role.Q_OutKC = Convert.ToBoolean(sdr["Q_OutKC"]);
                    role.Q_PDD = Convert.ToBoolean(sdr["Q_PDD"]);
                    role.Q_THD = Convert.ToBoolean(sdr["Q_THD"]);
                    role.Q_WGD = Convert.ToBoolean(sdr["Q_WGD"]);
                    role.Q_YWD = Convert.ToBoolean(sdr["Q_YWD"]);
                    role.Q_ZKD = Convert.ToBoolean(sdr["Q_ZKD"]);
                    role.RESENDBILL = Convert.ToBoolean(sdr["RESENDBILL"]);
                    role.RoleName =sdr["RoleName"].ToString();
                    role.SET_COMNC = Convert.ToBoolean(sdr["SET_COMNC"]);
                    role.SET_HW = Convert.ToBoolean(sdr["SET_HW"]);
                    role.SET_KH = Convert.ToBoolean(sdr["SET_KH"]);
                    role.SET_Param = Convert.ToBoolean(sdr["SET_Param"]);
                    role.SET_Role = Convert.ToBoolean(sdr["SET_Role"]);
                    role.SET_SCX = Convert.ToBoolean(sdr["SET_SCX"]);
                    role.SET_Store = Convert.ToBoolean(sdr["SET_Store"]);
                    role.SET_User = Convert.ToBoolean(sdr["SET_User"]);
                    role.SH_PDD = Convert.ToBoolean(sdr["SH_PDD"]);
                    role.UP_PDD = Convert.ToBoolean(sdr["UP_PDD"]);
                    role.ZD_HBFYD = Convert.ToBoolean(sdr["ZD_HBFYD"]);
                    role.ZD_HBZKD = Convert.ToBoolean(sdr["ZD_HBZKD"]);
                    role.ZD_QTCK = Convert.ToBoolean(sdr["ZD_QTCK"]);
                    role.ZD_ZYPD = Convert.ToBoolean(sdr["ZD_ZYPD"]);
                    role.ZD_ZZFYD = Convert.ToBoolean(sdr["ZD_ZZFYD"]);
                    role.ZD_ZZWGD = Convert.ToBoolean(sdr["ZD_ZZWGD"]);
                    role.ZD_ZZXTZHD = Convert.ToBoolean(sdr["ZD_ZZXTZHD"]);
                    role.ZD_ZZZKD = Convert.ToBoolean(sdr["ZD_ZZZKD"]);
                    role.Data_return = Convert.ToBoolean(sdr["Data_return"]);
                    role.Data_MoveLog = Convert.ToBoolean(sdr["Data_MoveLog"]);
                    role.Log_Delete = Convert.ToBoolean(sdr["Log_Delete"]);
                    role.Publish_Affiche = Convert.ToBoolean(sdr["Publish_Affiche"]);
                    role.Login_History = Convert.ToBoolean(sdr["Login_History"]);
                    role.SYSBZBZ = Convert.ToBoolean(sdr["SYSBZBZ"]);
                    role.SYSCHQP = Convert.ToBoolean(sdr["SYSCHQP"]);
                    role.Q_SXPC = Convert.ToBoolean(sdr["Q_SXPC"]);
                    role.FYD_HGQR = Convert.ToBoolean(sdr["FYD_HGQR"]);
                    role.FYD_ZJQR = Convert.ToBoolean(sdr["FYD_ZJQR"]);
                    role.FYD_MGQR = Convert.ToBoolean(sdr["FYD_MGQR"]);
                    role.DoorManage = Convert.ToBoolean(sdr["DoorManage"]);
                    role.QZSManage = Convert.ToBoolean(sdr["qzsmanage"]);
                    role.FYD_QRSearch = Convert.ToBoolean(sdr["fyd_qrsearch"]);
                }
                sdr.Dispose();
            }
            return role;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public bool Exists()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WMS_Pub_Role");
			strSql.Append(" where RoleName= @RoleName");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar)
				};
			parameters[0].Value = this.RoleName;
            AdoHelper dataHelp = new SqlHelp();
            object obj = dataHelp.ExecuteScalar(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
			int cmdresult;
			if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
			{
				cmdresult=0;
			}
			else
			{
				cmdresult=int.Parse(obj.ToString());
			}
			if(cmdresult==0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WMS_Pub_Role(");
            strSql.Append("RoleName,EXE_PCHRK,EXE_BARRK,EXE_SELL_CK,EXE_PCHCK,EXE_BARCK,EXE_PCHPD,EXE_BARPD,EXE_YW,EXE_SHAPE,IC_FK,IC_GS,IC_ZX,IC_ZT,Car_In,Car_Out,Bar_Print,Bar_BZ,Q_WGD,Q_FYD,Q_ZKD,Q_PDD,M_YWD,Q_YWD,M_PDD,SH_PDD,UP_PDD,Q_OutKC,Q_KC,SET_Param,SET_Role,SET_User,SET_Store,SET_HW,SET_KH,SET_COMNC,SET_SCX,CANCELBILL,Che_Qu,RESENDBILL,BILLSENDLOG,EXE_HWVIEW,EXE_KCTZ,Q_THD,EXE_TH,EXE_QCRK,EXE_QTCK,EXE_CLOSE_ZKD,EXE_ZYPD,ZD_HBFYD,ZD_HBZKD,ZD_ZZWGD,ZD_ZZFYD,ZD_ZZZKD,ZD_ZZXTZHD,ZD_ZYPD,ZD_QTCK,FYD_CancelFinish,FYD_UpdateCXH,EXE_QTRK,exe_delxtzhd,exe_dpqry,exe_itembaseinfo,Data_return,Data_MoveLog,Log_Delete,Publish_Affiche,Login_History,SYSCHQP,SYSBZBZ,Q_SXPC,doormanage,qzsmanage,fyd_qrsearch)");
			strSql.Append(" values (");
            strSql.Append("@RoleName,@EXE_PCHRK,@EXE_BARRK,@EXE_SELL_CK,@EXE_PCHCK,@EXE_BARCK,@EXE_PCHPD,@EXE_BARPD,@EXE_YW,@EXE_SHAPE,@IC_FK,@IC_GS,@IC_ZX,@IC_ZT,@Car_In,@Car_Out,@Bar_Print,@Bar_BZ,@Q_WGD,@Q_FYD,@Q_ZKD,@Q_PDD,@M_YWD,@Q_YWD,@M_PDD,@SH_PDD,@UP_PDD,@Q_OutKC,@Q_KC,@SET_Param,@SET_Role,@SET_User,@SET_Store,@SET_HW,@SET_KH,@SET_COMNC,@SET_SCX,@CANCELBILL,@Che_Qu,@RESENDBILL,@BILLSENDLOG,@EXE_HWVIEW,@EXE_KCTZ,@Q_THD,@EXE_TH,@EXE_QCRK,@EXE_QTCK,@EXE_CLOSE_ZKD,@EXE_ZYPD,@ZD_HBFYD,@ZD_HBZKD,@ZD_ZZWGD,@ZD_ZZFYD,@ZD_ZZZKD,@ZD_ZZXTZHD,@ZD_ZYPD,@ZD_QTCK,@FYD_CancelFinish,@FYD_UpdateCXH,@EXE_QTRK,@exe_delxtzhd,@exe_dpqry,@exe_itembaseinfo,@Data_return,@Data_MoveLog,@Log_Delete,@Publish_Affiche,@Login_History,@SYSCHQP,@SYSBZBZ,@Q_SXPC,@doormanage,@qzsmanage,@fyd_qrsearch)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar),
					new SqlParameter("@EXE_PCHRK", SqlDbType.Bit),
					new SqlParameter("@EXE_BARRK", SqlDbType.Bit),
					new SqlParameter("@EXE_SELL_CK", SqlDbType.Bit),
					new SqlParameter("@EXE_PCHCK", SqlDbType.Bit),
					new SqlParameter("@EXE_BARCK", SqlDbType.Bit),
					new SqlParameter("@EXE_PCHPD", SqlDbType.Bit),
					new SqlParameter("@EXE_BARPD", SqlDbType.Bit),
					new SqlParameter("@EXE_YW", SqlDbType.Bit),
					new SqlParameter("@EXE_SHAPE", SqlDbType.Bit),
					new SqlParameter("@IC_FK", SqlDbType.Bit),
					new SqlParameter("@IC_GS", SqlDbType.Bit),
					new SqlParameter("@IC_ZX", SqlDbType.Bit),
					new SqlParameter("@IC_ZT", SqlDbType.Bit),
					new SqlParameter("@Car_In", SqlDbType.Bit),
					new SqlParameter("@Car_Out", SqlDbType.Bit),
					new SqlParameter("@Bar_Print", SqlDbType.Bit),
					new SqlParameter("@Bar_BZ", SqlDbType.Bit),
					new SqlParameter("@Q_WGD", SqlDbType.Bit),
					new SqlParameter("@Q_FYD", SqlDbType.Bit),
					new SqlParameter("@Q_ZKD", SqlDbType.Bit),
					new SqlParameter("@Q_PDD", SqlDbType.Bit),
					new SqlParameter("@M_YWD", SqlDbType.Bit),
					new SqlParameter("@Q_YWD", SqlDbType.Bit),
					new SqlParameter("@M_PDD", SqlDbType.Bit),
					new SqlParameter("@SH_PDD", SqlDbType.Bit),
					new SqlParameter("@UP_PDD", SqlDbType.Bit),
					new SqlParameter("@Q_OutKC", SqlDbType.Bit),
					new SqlParameter("@Q_KC", SqlDbType.Bit),
					new SqlParameter("@SET_Param", SqlDbType.Bit),
					new SqlParameter("@SET_Role", SqlDbType.Bit),
					new SqlParameter("@SET_User", SqlDbType.Bit),
					new SqlParameter("@SET_Store", SqlDbType.Bit),
					new SqlParameter("@SET_HW", SqlDbType.Bit),
					new SqlParameter("@SET_KH", SqlDbType.Bit),
					new SqlParameter("@SET_COMNC", SqlDbType.Bit),
					new SqlParameter("@SET_SCX", SqlDbType.Bit),
					new SqlParameter("@CANCELBILL", SqlDbType.Bit),
					new SqlParameter("@Che_Qu", SqlDbType.Bit),
					new SqlParameter("@RESENDBILL", SqlDbType.Bit),
					new SqlParameter("@BILLSENDLOG", SqlDbType.Bit),
					new SqlParameter("@EXE_HWVIEW", SqlDbType.Bit),
					new SqlParameter("@EXE_KCTZ", SqlDbType.Bit),
					new SqlParameter("@Q_THD", SqlDbType.Bit),
					new SqlParameter("@EXE_TH", SqlDbType.Bit),
					new SqlParameter("@EXE_QCRK", SqlDbType.Bit),
					new SqlParameter("@EXE_QTCK", SqlDbType.Bit),
					new SqlParameter("@EXE_CLOSE_ZKD", SqlDbType.Bit),
					new SqlParameter("@EXE_ZYPD", SqlDbType.Bit),
					new SqlParameter("@ZD_HBFYD", SqlDbType.Bit),
					new SqlParameter("@ZD_HBZKD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZZWGD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZZFYD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZZZKD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZZXTZHD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZYPD", SqlDbType.Bit),
					new SqlParameter("@ZD_QTCK", SqlDbType.Bit),
					new SqlParameter("@FYD_CancelFinish", SqlDbType.Bit),
					new SqlParameter("@FYD_UpdateCXH", SqlDbType.Bit),
					new SqlParameter("@EXE_QTRK", SqlDbType.Bit),
					new SqlParameter("@exe_delxtzhd", SqlDbType.Bit),
					new SqlParameter("@exe_dpqry", SqlDbType.Bit),
					new SqlParameter("@exe_itembaseinfo", SqlDbType.Bit),
                    new SqlParameter("@Data_return",SqlDbType.Bit),
                    new SqlParameter("@Data_MoveLog",SqlDbType.Bit),
                    new SqlParameter("@Log_Delete",SqlDbType.Bit),
                    new SqlParameter("@Publish_Affiche",SqlDbType.Bit),
                    new SqlParameter("@Login_History",SqlDbType.Bit),
                    new SqlParameter("@SYSCHQP",SqlDbType.Bit),
                    new SqlParameter("@SYSBZBZ",SqlDbType.Bit),
                    new SqlParameter("@Q_SXPC",SqlDbType.Bit),
                    new SqlParameter("@FYD_HGQR",SqlDbType.Bit),
                    new SqlParameter("@FYD_ZJQR",SqlDbType.Bit),
                    new SqlParameter("@FYD_MGQR",SqlDbType.Bit),
                    new SqlParameter("@doormanage",SqlDbType.Bit),
                    new SqlParameter("@qzsmanage",SqlDbType.Bit),
                    new SqlParameter("@fyd_qrsearch",SqlDbType.Bit)
            };
			parameters[0].Value = this.RoleName;
			parameters[1].Value = this.EXE_PCHRK;
			parameters[2].Value = this.EXE_BARRK;
			parameters[3].Value = this.EXE_SELL_CK;
			parameters[4].Value = this.EXE_PCHCK;
			parameters[5].Value = this.EXE_BARCK;
			parameters[6].Value = this.EXE_PCHPD;
			parameters[7].Value = this.EXE_BARPD;
			parameters[8].Value = this.EXE_YW;
			parameters[9].Value = this.EXE_SHAPE;
			parameters[10].Value = this.IC_FK;
			parameters[11].Value = this.IC_GS;
			parameters[12].Value = this.IC_ZX;
			parameters[13].Value = this.IC_ZT;
			parameters[14].Value = this.Car_In;
			parameters[15].Value = this.Car_Out;
			parameters[16].Value = this.Bar_Print;
			parameters[17].Value = this.Bar_BZ;
			parameters[18].Value = this.Q_WGD;
			parameters[19].Value = this.Q_FYD;
			parameters[20].Value = this.Q_ZKD;
			parameters[21].Value = this.Q_PDD;
			parameters[22].Value = this.M_YWD;
			parameters[23].Value = this.Q_YWD;
			parameters[24].Value = this.M_PDD;
			parameters[25].Value = this.SH_PDD;
			parameters[26].Value = this.UP_PDD;
			parameters[27].Value = this.Q_OutKC;
			parameters[28].Value = this.Q_KC;
			parameters[29].Value = this.SET_Param;
			parameters[30].Value = this.SET_Role;
			parameters[31].Value = this.SET_User;
			parameters[32].Value = this.SET_Store;
			parameters[33].Value = this.SET_HW;
			parameters[34].Value = this.SET_KH;
			parameters[35].Value = this.SET_COMNC;
			parameters[36].Value = this.SET_SCX;
			parameters[37].Value = this.CANCELBILL;
			parameters[38].Value = this.Che_Qu;
			parameters[39].Value = this.RESENDBILL;
			parameters[40].Value = this.BILLSENDLOG;
			parameters[41].Value = this.EXE_HWVIEW;
			parameters[42].Value = this.EXE_KCTZ;
			parameters[43].Value = this.Q_THD;
			parameters[44].Value = this.EXE_TH;
			parameters[45].Value = this.EXE_QCRK;
			parameters[46].Value = this.EXE_QTCK;
			parameters[47].Value = this.EXE_CLOSE_ZKD;
			parameters[48].Value = this.EXE_ZYPD;
			parameters[49].Value = this.ZD_HBFYD;
			parameters[50].Value = this.ZD_HBZKD;
			parameters[51].Value = this.ZD_ZZWGD;
			parameters[52].Value = this.ZD_ZZFYD;
			parameters[53].Value = this.ZD_ZZZKD;
			parameters[54].Value = this.ZD_ZZXTZHD;
			parameters[55].Value = this.ZD_ZYPD;
			parameters[56].Value = this.ZD_QTCK;
			parameters[57].Value = this.FYD_CancelFinish;
			parameters[58].Value = this.FYD_UpdateCXH;
			parameters[59].Value = this.EXE_QTRK;
			parameters[60].Value = this.exe_delxtzhd;
			parameters[61].Value = this.exe_dpqry;
			parameters[62].Value = this.exe_itembaseinfo;
            parameters[63].Value = this.Data_return;
            parameters[64].Value = this.Data_MoveLog;
            parameters[65].Value = this.Log_Delete;
            parameters[66].Value = this.Publish_Affiche;
            parameters[67].Value = this.Login_History;
            parameters[68].Value = this.SYSCHQP;
            parameters[69].Value = this.SYSBZBZ;
            parameters[70].Value = this.Q_SXPC;
            parameters[71].Value = this.FYD_HGQR;
            parameters[72].Value = this.FYD_ZJQR;
            parameters[73].Value = this.FYD_MGQR;
            parameters[74].Value = this.DoorManage;
            parameters[75].Value = this.QZSManage;
            parameters[76].Value = this.FYD_QRSearch;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WMS_Pub_Role set ");
			strSql.Append("EXE_PCHRK=@EXE_PCHRK,");
			strSql.Append("EXE_BARRK=@EXE_BARRK,");
			strSql.Append("EXE_SELL_CK=@EXE_SELL_CK,");
			strSql.Append("EXE_PCHCK=@EXE_PCHCK,");
			strSql.Append("EXE_BARCK=@EXE_BARCK,");
			strSql.Append("EXE_PCHPD=@EXE_PCHPD,");
			strSql.Append("EXE_BARPD=@EXE_BARPD,");
			strSql.Append("EXE_YW=@EXE_YW,");
			strSql.Append("EXE_SHAPE=@EXE_SHAPE,");
			strSql.Append("IC_FK=@IC_FK,");
			strSql.Append("IC_GS=@IC_GS,");
			strSql.Append("IC_ZX=@IC_ZX,");
			strSql.Append("IC_ZT=@IC_ZT,");
			strSql.Append("Car_In=@Car_In,");
			strSql.Append("Car_Out=@Car_Out,");
			strSql.Append("Bar_Print=@Bar_Print,");
			strSql.Append("Bar_BZ=@Bar_BZ,");
			strSql.Append("Q_WGD=@Q_WGD,");
			strSql.Append("Q_FYD=@Q_FYD,");
			strSql.Append("Q_ZKD=@Q_ZKD,");
			strSql.Append("Q_PDD=@Q_PDD,");
			strSql.Append("M_YWD=@M_YWD,");
			strSql.Append("Q_YWD=@Q_YWD,");
			strSql.Append("M_PDD=@M_PDD,");
			strSql.Append("SH_PDD=@SH_PDD,");
			strSql.Append("UP_PDD=@UP_PDD,");
			strSql.Append("Q_OutKC=@Q_OutKC,");
			strSql.Append("Q_KC=@Q_KC,");
			strSql.Append("SET_Param=@SET_Param,");
			strSql.Append("SET_Role=@SET_Role,");
			strSql.Append("SET_User=@SET_User,");
			strSql.Append("SET_Store=@SET_Store,");
			strSql.Append("SET_HW=@SET_HW,");
			strSql.Append("SET_KH=@SET_KH,");
			strSql.Append("SET_COMNC=@SET_COMNC,");
			strSql.Append("SET_SCX=@SET_SCX,");
			strSql.Append("CANCELBILL=@CANCELBILL,");
			strSql.Append("Che_Qu=@Che_Qu,");
			strSql.Append("RESENDBILL=@RESENDBILL,");
			strSql.Append("BILLSENDLOG=@BILLSENDLOG,");
			strSql.Append("EXE_HWVIEW=@EXE_HWVIEW,");
			strSql.Append("EXE_KCTZ=@EXE_KCTZ,");
			strSql.Append("Q_THD=@Q_THD,");
			strSql.Append("EXE_TH=@EXE_TH,");
			strSql.Append("EXE_QCRK=@EXE_QCRK,");
			strSql.Append("EXE_QTCK=@EXE_QTCK,");
			strSql.Append("EXE_CLOSE_ZKD=@EXE_CLOSE_ZKD,");
			strSql.Append("EXE_ZYPD=@EXE_ZYPD,");
			strSql.Append("ZD_HBFYD=@ZD_HBFYD,");
			strSql.Append("ZD_HBZKD=@ZD_HBZKD,");
			strSql.Append("ZD_ZZWGD=@ZD_ZZWGD,");
			strSql.Append("ZD_ZZFYD=@ZD_ZZFYD,");
			strSql.Append("ZD_ZZZKD=@ZD_ZZZKD,");
			strSql.Append("ZD_ZZXTZHD=@ZD_ZZXTZHD,");
			strSql.Append("ZD_ZYPD=@ZD_ZYPD,");
			strSql.Append("ZD_QTCK=@ZD_QTCK,");
			strSql.Append("FYD_CancelFinish=@FYD_CancelFinish,");
			strSql.Append("FYD_UpdateCXH=@FYD_UpdateCXH,");
			strSql.Append("EXE_QTRK=@EXE_QTRK,");
			strSql.Append("exe_delxtzhd=@exe_delxtzhd,");
			strSql.Append("exe_dpqry=@exe_dpqry,");
			strSql.Append("exe_itembaseinfo=@exe_itembaseinfo,");
            strSql.Append("Data_return=@Data_return,");
            strSql.Append("Data_MoveLog=@Data_MoveLog,");
            strSql.Append("Log_Delete=@Log_Delete,");
            strSql.Append("Publish_Affiche=@Publish_Affiche,");
            strSql.Append("Login_History=@Login_History,");
            strSql.Append("syschqp=@SYSCHQP,");
            strSql.Append("sysbzbz=@SYSBZBZ,");
            strSql.Append("Q_SXPC=@Q_SXPC,");
            strSql.Append("FYD_HGQR=@FYD_HGQR,");
            strSql.Append("FYD_ZJQR=@FYD_ZJQR,");
            strSql.Append("FYD_MGQR=@FYD_MGQR,");
            strSql.Append("doormanage=@doormanage,");
            strSql.Append("qzsmanage=@qzsmanage,");
            strSql.Append("fyd_qrsearch=@fyd_qrsearch");
			strSql.Append(" where RoleName=@RoleName");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar),
					new SqlParameter("@EXE_PCHRK", SqlDbType.Bit),
					new SqlParameter("@EXE_BARRK", SqlDbType.Bit),
					new SqlParameter("@EXE_SELL_CK", SqlDbType.Bit),
					new SqlParameter("@EXE_PCHCK", SqlDbType.Bit),
					new SqlParameter("@EXE_BARCK", SqlDbType.Bit),
					new SqlParameter("@EXE_PCHPD", SqlDbType.Bit),
					new SqlParameter("@EXE_BARPD", SqlDbType.Bit),
					new SqlParameter("@EXE_YW", SqlDbType.Bit),
					new SqlParameter("@EXE_SHAPE", SqlDbType.Bit),
					new SqlParameter("@IC_FK", SqlDbType.Bit),
					new SqlParameter("@IC_GS", SqlDbType.Bit),
					new SqlParameter("@IC_ZX", SqlDbType.Bit),
					new SqlParameter("@IC_ZT", SqlDbType.Bit),
					new SqlParameter("@Car_In", SqlDbType.Bit),
					new SqlParameter("@Car_Out", SqlDbType.Bit),
					new SqlParameter("@Bar_Print", SqlDbType.Bit),
					new SqlParameter("@Bar_BZ", SqlDbType.Bit),
					new SqlParameter("@Q_WGD", SqlDbType.Bit),
					new SqlParameter("@Q_FYD", SqlDbType.Bit),
					new SqlParameter("@Q_ZKD", SqlDbType.Bit),
					new SqlParameter("@Q_PDD", SqlDbType.Bit),
					new SqlParameter("@M_YWD", SqlDbType.Bit),
					new SqlParameter("@Q_YWD", SqlDbType.Bit),
					new SqlParameter("@M_PDD", SqlDbType.Bit),
					new SqlParameter("@SH_PDD", SqlDbType.Bit),
					new SqlParameter("@UP_PDD", SqlDbType.Bit),
					new SqlParameter("@Q_OutKC", SqlDbType.Bit),
					new SqlParameter("@Q_KC", SqlDbType.Bit),
					new SqlParameter("@SET_Param", SqlDbType.Bit),
					new SqlParameter("@SET_Role", SqlDbType.Bit),
					new SqlParameter("@SET_User", SqlDbType.Bit),
					new SqlParameter("@SET_Store", SqlDbType.Bit),
					new SqlParameter("@SET_HW", SqlDbType.Bit),
					new SqlParameter("@SET_KH", SqlDbType.Bit),
					new SqlParameter("@SET_COMNC", SqlDbType.Bit),
					new SqlParameter("@SET_SCX", SqlDbType.Bit),
					new SqlParameter("@CANCELBILL", SqlDbType.Bit),
					new SqlParameter("@Che_Qu", SqlDbType.Bit),
					new SqlParameter("@RESENDBILL", SqlDbType.Bit),
					new SqlParameter("@BILLSENDLOG", SqlDbType.Bit),
					new SqlParameter("@EXE_HWVIEW", SqlDbType.Bit),
					new SqlParameter("@EXE_KCTZ", SqlDbType.Bit),
					new SqlParameter("@Q_THD", SqlDbType.Bit),
					new SqlParameter("@EXE_TH", SqlDbType.Bit),
					new SqlParameter("@EXE_QCRK", SqlDbType.Bit),
					new SqlParameter("@EXE_QTCK", SqlDbType.Bit),
					new SqlParameter("@EXE_CLOSE_ZKD", SqlDbType.Bit),
					new SqlParameter("@EXE_ZYPD", SqlDbType.Bit),
					new SqlParameter("@ZD_HBFYD", SqlDbType.Bit),
					new SqlParameter("@ZD_HBZKD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZZWGD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZZFYD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZZZKD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZZXTZHD", SqlDbType.Bit),
					new SqlParameter("@ZD_ZYPD", SqlDbType.Bit),
					new SqlParameter("@ZD_QTCK", SqlDbType.Bit),
					new SqlParameter("@FYD_CancelFinish", SqlDbType.Bit),
					new SqlParameter("@FYD_UpdateCXH", SqlDbType.Bit),
					new SqlParameter("@EXE_QTRK", SqlDbType.Bit),
					new SqlParameter("@exe_delxtzhd", SqlDbType.Bit),
					new SqlParameter("@exe_dpqry", SqlDbType.Bit),
					new SqlParameter("@exe_itembaseinfo", SqlDbType.Bit),
                    new SqlParameter("@Data_return",SqlDbType.Bit),
                    new SqlParameter("@Data_MoveLog",SqlDbType.Bit),
                    new SqlParameter("@Log_Delete",SqlDbType.Bit),
                    new SqlParameter("@Publish_Affiche",SqlDbType.Bit),
                    new SqlParameter("@Login_History",SqlDbType.Bit),
                    new SqlParameter("@SYSCHQP",SqlDbType.Bit),
                    new SqlParameter("@SYSBZBZ",SqlDbType.Bit),
                    new SqlParameter("@Q_SXPC",SqlDbType.Bit),
                new SqlParameter("@FYD_HGQR",SqlDbType.Bit),
                    new SqlParameter("@FYD_ZJQR",SqlDbType.Bit),
                    new SqlParameter("@FYD_MGQR",SqlDbType.Bit),
                    new SqlParameter("@doormanage",SqlDbType.Bit),
                    new SqlParameter("@qzsmanage",SqlDbType.Bit),
                    new SqlParameter("@fyd_qrsearch",SqlDbType.Bit)
            };
			parameters[0].Value = this.RoleName;
			parameters[1].Value = this.EXE_PCHRK;
			parameters[2].Value = this.EXE_BARRK;
			parameters[3].Value = this.EXE_SELL_CK;
			parameters[4].Value = this.EXE_PCHCK;
			parameters[5].Value = this.EXE_BARCK;
			parameters[6].Value = this.EXE_PCHPD;
			parameters[7].Value = this.EXE_BARPD;
			parameters[8].Value = this.EXE_YW;
			parameters[9].Value = this.EXE_SHAPE;
			parameters[10].Value = this.IC_FK;
			parameters[11].Value = this.IC_GS;
			parameters[12].Value = this.IC_ZX;
			parameters[13].Value = this.IC_ZT;
			parameters[14].Value = this.Car_In;
			parameters[15].Value = this.Car_Out;
			parameters[16].Value = this.Bar_Print;
			parameters[17].Value = this.Bar_BZ;
			parameters[18].Value = this.Q_WGD;
			parameters[19].Value = this.Q_FYD;
			parameters[20].Value = this.Q_ZKD;
			parameters[21].Value = this.Q_PDD;
			parameters[22].Value = this.M_YWD;
			parameters[23].Value = this.Q_YWD;
			parameters[24].Value = this.M_PDD;
			parameters[25].Value = this.SH_PDD;
			parameters[26].Value = this.UP_PDD;
			parameters[27].Value = this.Q_OutKC;
			parameters[28].Value = this.Q_KC;
			parameters[29].Value = this.SET_Param;
			parameters[30].Value = this.SET_Role;
			parameters[31].Value = this.SET_User;
			parameters[32].Value = this.SET_Store;
			parameters[33].Value = this.SET_HW;
			parameters[34].Value = this.SET_KH;
			parameters[35].Value = this.SET_COMNC;
			parameters[36].Value = this.SET_SCX;
			parameters[37].Value = this.CANCELBILL;
			parameters[38].Value = this.Che_Qu;
			parameters[39].Value = this.RESENDBILL;
			parameters[40].Value = this.BILLSENDLOG;
			parameters[41].Value = this.EXE_HWVIEW;
			parameters[42].Value = this.EXE_KCTZ;
			parameters[43].Value = this.Q_THD;
			parameters[44].Value = this.EXE_TH;
			parameters[45].Value = this.EXE_QCRK;
			parameters[46].Value = this.EXE_QTCK;
			parameters[47].Value = this.EXE_CLOSE_ZKD;
			parameters[48].Value = this.EXE_ZYPD;
			parameters[49].Value = this.ZD_HBFYD;
			parameters[50].Value = this.ZD_HBZKD;
			parameters[51].Value = this.ZD_ZZWGD;
			parameters[52].Value = this.ZD_ZZFYD;
			parameters[53].Value = this.ZD_ZZZKD;
			parameters[54].Value = this.ZD_ZZXTZHD;
			parameters[55].Value = this.ZD_ZYPD;
			parameters[56].Value = this.ZD_QTCK;
			parameters[57].Value = this.FYD_CancelFinish;
			parameters[58].Value = this.FYD_UpdateCXH;
			parameters[59].Value = this.EXE_QTRK;
			parameters[60].Value = this.exe_delxtzhd;
			parameters[61].Value = this.exe_dpqry;
			parameters[62].Value = this.exe_itembaseinfo;
            parameters[63].Value = this.Data_return;
            parameters[64].Value = this.Data_MoveLog;
            parameters[65].Value = this.Log_Delete;
            parameters[66].Value = this.Publish_Affiche;
            parameters[67].Value = this.Login_History;
            parameters[68].Value = this.SYSCHQP;
            parameters[69].Value = this.SYSBZBZ;
            parameters[70].Value = this.Q_SXPC;
            parameters[71].Value = this.FYD_HGQR;
            parameters[72].Value = this.FYD_ZJQR;
            parameters[73].Value = this.FYD_MGQR;
            parameters[74].Value = this.DoorManage;
            parameters[75].Value = this.QZSManage;
            parameters[76].Value = this.FYD_QRSearch;
            AdoHelper dataHelp = new SqlHelp();
            dataHelp.ExecuteNonQuery(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
		}

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Delete()
        {
            StringBuilder strSql=new StringBuilder();
			strSql.Append("delete WMS_Pub_Role ");
			strSql.Append(" where RoleName=@RoleName");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar)
				};
			parameters[0].Value = RoleName;
            AdoHelper dataHelp=new SqlHelp();
			dataHelp.ExecuteNonQuery(Common.GetConnectString(),CommandType.Text,strSql.ToString(),parameters);
        }
    }
}
