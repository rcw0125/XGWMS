using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Acctrue.WM_WES.DataAccess;
using System.Data.SqlClient;

namespace ACCTRUE.WMSBLL.Model
{
    public class WeightQCFunction
    {
        public WeightQCFunction()
		{}
		private string _username;
		private string _usercname;
		private string _userpassword;
		private string _scx;
		private bool _pgmanage=false;
		private bool _weightsearch=false;
		private bool _weightparam=false;
		private bool _dvexchange=false;
		private bool _qudel=false;
		private bool _standmanage=false;
		private bool _weightbd=false;
		private bool _ismanager=false;
		private bool _searchwgd=false;
		private bool _bhgyy=false;
		private bool _recheck=false;
		private bool _delwgd=false;
		private bool _printmodle=false;
		private bool _updown=false;
		private bool _wgd=false;
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserCname
		{
			set{ _usercname=value;}
			get{return _usercname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userpassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCX
		{
			set{ _scx=value;}
			get{return _scx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool PGManage
		{
			set{ _pgmanage=value;}
			get{return _pgmanage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool WeightSearch
		{
			set{ _weightsearch=value;}
			get{return _weightsearch;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool WeightParam
		{
			set{ _weightparam=value;}
			get{return _weightparam;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool DVExchange
		{
			set{ _dvexchange=value;}
			get{return _dvexchange;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool QuDel
		{
			set{ _qudel=value;}
			get{return _qudel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool StandManage
		{
			set{ _standmanage=value;}
			get{return _standmanage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool WeightBD
		{
			set{ _weightbd=value;}
			get{return _weightbd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isManager
		{
			set{ _ismanager=value;}
			get{return _ismanager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool SearchWGD
		{
			set{ _searchwgd=value;}
			get{return _searchwgd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool BHGYY
		{
			set{ _bhgyy=value;}
			get{return _bhgyy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ReCheck
		{
			set{ _recheck=value;}
			get{return _recheck;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool DelWgd
		{
			set{ _delwgd=value;}
			get{return _delwgd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool PrintModle
		{
			set{ _printmodle=value;}
			get{return _printmodle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool UPDown
		{
			set{ _updown=value;}
			get{return _updown;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool WGD
		{
			set{ _wgd=value;}
			get{return _wgd;}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static WeightQCFunction GetWeightFunction(string userID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * from WMS_Bms_Rec_WGD_Manage ");
			strSql.Append(" where username=@username");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar)};
            parameters[0].Value = userID;
            WeightQCFunction model = new WeightQCFunction();
            AdoHelper ado = new SqlHelp();
            DataSet ds = ado.ExecuteDataset(Common.GetConnectString(), CommandType.Text, strSql.ToString(), parameters);
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{
				model.UserCname=ds.Tables[0].Rows[0]["UserCname"].ToString();
				model.userpassword=ds.Tables[0].Rows[0]["userpassword"].ToString();
				model.SCX=ds.Tables[0].Rows[0]["SCX"].ToString();
				if(ds.Tables[0].Rows[0]["PGManage"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["PGManage"].ToString()=="1")||(ds.Tables[0].Rows[0]["PGManage"].ToString().ToLower()=="true"))
					{
						model.PGManage=true;
					}
					else
					{
						model.PGManage=false;
					}
				}

				if(ds.Tables[0].Rows[0]["WeightSearch"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["WeightSearch"].ToString()=="1")||(ds.Tables[0].Rows[0]["WeightSearch"].ToString().ToLower()=="true"))
					{
						model.WeightSearch=true;
					}
					else
					{
						model.WeightSearch=false;
					}
				}

				if(ds.Tables[0].Rows[0]["WeightParam"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["WeightParam"].ToString()=="1")||(ds.Tables[0].Rows[0]["WeightParam"].ToString().ToLower()=="true"))
					{
						model.WeightParam=true;
					}
					else
					{
						model.WeightParam=false;
					}
				}

				if(ds.Tables[0].Rows[0]["DVExchange"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["DVExchange"].ToString()=="1")||(ds.Tables[0].Rows[0]["DVExchange"].ToString().ToLower()=="true"))
					{
						model.DVExchange=true;
					}
					else
					{
						model.DVExchange=false;
					}
				}

				if(ds.Tables[0].Rows[0]["QuDel"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["QuDel"].ToString()=="1")||(ds.Tables[0].Rows[0]["QuDel"].ToString().ToLower()=="true"))
					{
						model.QuDel=true;
					}
					else
					{
						model.QuDel=false;
					}
				}

				if(ds.Tables[0].Rows[0]["StandManage"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["StandManage"].ToString()=="1")||(ds.Tables[0].Rows[0]["StandManage"].ToString().ToLower()=="true"))
					{
						model.StandManage=true;
					}
					else
					{
						model.StandManage=false;
					}
				}

				if(ds.Tables[0].Rows[0]["WeightBD"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["WeightBD"].ToString()=="1")||(ds.Tables[0].Rows[0]["WeightBD"].ToString().ToLower()=="true"))
					{
						model.WeightBD=true;
					}
					else
					{
						model.WeightBD=false;
					}
				}

				if(ds.Tables[0].Rows[0]["isManager"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["isManager"].ToString()=="1")||(ds.Tables[0].Rows[0]["isManager"].ToString().ToLower()=="true"))
					{
						model.isManager=true;
					}
					else
					{
						model.isManager=false;
					}
				}

				if(ds.Tables[0].Rows[0]["SearchWGD"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["SearchWGD"].ToString()=="1")||(ds.Tables[0].Rows[0]["SearchWGD"].ToString().ToLower()=="true"))
					{
						model.SearchWGD=true;
					}
					else
					{
						model.SearchWGD=false;
					}
				}

				if(ds.Tables[0].Rows[0]["BHGYY"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["BHGYY"].ToString()=="1")||(ds.Tables[0].Rows[0]["BHGYY"].ToString().ToLower()=="true"))
					{
						model.BHGYY=true;
					}
					else
					{
						model.BHGYY=false;
					}
				}

				if(ds.Tables[0].Rows[0]["ReCheck"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["ReCheck"].ToString()=="1")||(ds.Tables[0].Rows[0]["ReCheck"].ToString().ToLower()=="true"))
					{
						model.ReCheck=true;
					}
					else
					{
						model.ReCheck=false;
					}
				}

				if(ds.Tables[0].Rows[0]["DelWgd"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["DelWgd"].ToString()=="1")||(ds.Tables[0].Rows[0]["DelWgd"].ToString().ToLower()=="true"))
					{
						model.DelWgd=true;
					}
					else
					{
						model.DelWgd=false;
					}
				}

				if(ds.Tables[0].Rows[0]["PrintModle"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["PrintModle"].ToString()=="1")||(ds.Tables[0].Rows[0]["PrintModle"].ToString().ToLower()=="true"))
					{
						model.PrintModle=true;
					}
					else
					{
						model.PrintModle=false;
					}
				}

				if(ds.Tables[0].Rows[0]["UPDown"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["UPDown"].ToString()=="1")||(ds.Tables[0].Rows[0]["UPDown"].ToString().ToLower()=="true"))
					{
						model.UPDown=true;
					}
					else
					{
						model.UPDown=false;
					}
				}

				if(ds.Tables[0].Rows[0]["WGD"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["WGD"].ToString()=="1")||(ds.Tables[0].Rows[0]["WGD"].ToString().ToLower()=="true"))
					{
						model.WGD=true;
					}
					else
					{
						model.WGD=false;
					}
				}
			}
            return model;
		}
    }
}
