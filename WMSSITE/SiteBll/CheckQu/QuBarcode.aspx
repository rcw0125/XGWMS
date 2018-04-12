<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuBarcode.aspx.cs" Inherits="SiteBll_CheckQu_QuBarcode" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../CSS/Input.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/QuCheck.js" type="text/javascript"></script>
</head>
<script type="text/javascript">
function check(obj)
{
	var e = event.srcElement;
	var table = e.parentNode.parentNode.parentNode.parentNode;
	var row = table.all.tags("tr");
	var row1 = row[1];
	var texts = row1.all.tags("INPUT")
	if(texts.length == 0)
		return;
	for(var i = 0; i < texts.length;i++)
	{
		texts[i].checked = obj.checked;	
	}
}
/*显示或隐藏查询条件*/
function chazhao() 
{
	var btnQuery = document.getElementById("btnQuery");
	var chazhao = document.getElementById("chazhao");
	var hidQuery = document.getElementById("hidQuery");
	
	var btnconfig = document.getElementById("btnconfig");
	var tablecon = document.getElementById("tablecon");
	var Hidconfig = document.getElementById("Hidconfig");
	
	
	if(chazhao.style.display == "block")
	{
		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		chazhao.style.display = "none";
		hidQuery.value= "none";
	}
	else
	{
		btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
		chazhao.style.display = "block";
		hidQuery.value = "block";
	}
	
}
/*页面初始化，完工单查询*/
function Init()
{
	var chazhao = document.getElementById("chazhao");
	var hidQuery = document.getElementById("hidQuery");
	
    var tablecon = document.getElementById("tablecon");
    var Hidconfig = document.getElementById("Hidconfig");
    
    var tblPList= document.getElementById("tblPList");
	var hidItem = document.getElementById("hidItem");
/*	window.alert(HidBase.value); 调试用的*/
	if(hidQuery.value!="")
	{
		chazhao.style.display = "none";
		if( hidQuery.value== "none")
			chazhao.style.display = "block";
		AddQuery();
	}
	if(Hidconfig.value!="")
	{
		tablecon.style.display = "none";
		if( Hidconfig.value== "none")
			tablecon.style.display = "block";
		Addconfig();
	}
	
	if(hidItem.value!="")
	{
		tblPList.style.display = "none";
		if( hidItem.value== "none")
			tblPList.style.display = "block";
		AddItems();
	}
}


</script>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
    <input id="hidQuery" runat="server" type="hidden" /> <input id="Hidconfig" type="hidden" /><input id="hidItem" type="hidden" />
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
					<TD vAlign="middle" align="center" width="60%"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">卷信息查询</font></TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            查询条件</span></span><IMG id="btnQuery" style="CURSOR: hand" onclick="chazhao();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0">
					</TD>
					<TD align="center" width="10%">
                        &nbsp;</TD>
					<TD vAlign="middle" align="center" width="2%"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
			<table class="fixColStyle" id="chazhao" style="DISPLAY: block" cellSpacing="0" cellPadding="0"	width="100%" align="center" border="0" runat="server">
  <tr>
    <td style="height:20px;" bgColor="#dce8f4"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></td>
  </tr>
  <tr>
    <td style="height: 150px"><table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="2">
      <tr>
        <td height="25" style="width: 98px;"><input name="chkCK" type="checkbox" id="cbck" onclick="setselvalue('ck','WMS_Bms_Inv_Info','selck');" />仓库</td>
        <td style="width: 100px">
            <select ID="selck" style="width:100px;" unselectable=off></select>
      </td>
        <td style="width:  66px;"><input name="cbsx" type="checkbox" id="chkRKSX"  onclick="setselvalue('sx','WMS_Bms_Inv_Info','selsx');"  />属性</td>
        <td style="width: 97px">
            <select ID="selsx" style="width:100px;"></select>
      </td>
        <td style="width: 72px"><input name="checkbox" type="checkbox" id="cbwlh" />物料</td>
        <td style="width: 85px">
            <input id="selwlh" style="width: 97px" type="text" /></td>
        <td style="width: 56px"><input name="checkbox" type="checkbox" id="cbph" onclick="setselvalue('ph','WMS_Bms_Inv_Info','selph');"  />牌号</td>
        <td style="width: 100px">
            <select ID="selph" style="width:100px;"></select>
      </td>
      </tr>
      <tr>
        <td height="25" style="width: 98px"><input name="checkbox" type="checkbox" id="cbhw"/>货位</td>
        <td style="width: 100px"> 
            <input id="selhw" style="width: 97px" type="text" /></td>
        <td style="width: 66px"><input name="checkbox" type="checkbox" id="cbgg" onclick="setselvalue('gg','WMS_Bms_Inv_Info','selgg');"  />规格</td>
        <td style="width: 97px">      <select  ID="selgg" style="width:100px;"></select>
      </td>
        <td style="width: 72px"><input name="checkbox" type="checkbox" id="cbbb"onclick="setselvalue('BB','WMS_Bms_Inv_Info','selbb');" />班别</td>
        <td style="width: 85px">      <select  ID="selbb" style="width:100px;">
            </select>
      </td>
        <td style="width: 56px"><input name="checkbox" type="checkbox" id="cbgh"/>钩号</td>
        <td style="width: 100px">      
            <input id="selgh" style="width: 99px" type="text" /></td>
      </tr>
      <tr>
        <td style="width: 98px; height: 25px;"><input name="checkbox" type="checkbox" id="cbErrSeason" onclick="setselvalue('ErrSeason','WMS_Bms_Inv_Info','selErrSeason');"  />错因</td>
        <td style="width: 100px; height: 25px;">      <select  ID="selErrSeason" style="width:100px;"></select>
      </td>
        <td style="width: 66px; height: 25px;"><input name="checkbox" type="checkbox" id="cbscx" onclick="LoadSCX();"  />生产线</td>
        <td style="width: 97px; height: 25px;">      <select  ID="drpSCX" style="width:100px;">
            </select>
            </td>
        <td style="height: 25px; width: 72px;"><input name="checkbox" type="checkbox" id="cbpcinfo"onclick="setselvalue('pcinfo','WMS_Bms_Inv_Info','selpcinfo');"  />特殊信息</td>
        <td style="width: 85px; height: 25px;">     <select  ID="selpcinfo" style="width:100px;">
        </select></td>
        <td style="height: 25px; width: 56px;"><input name="checkbox" type="checkbox" id="cbslph" />牌号1</td>
        <td style="width: 100px; height: 25px;">
            <input type="text" id="txtslph" style="width: 99px"/></td>
      </tr>
        <tr>
            <td style="width: 98px; height: 25px"><input name="checkbox" type="checkbox" id="chkFree1" />自由项1</td>
            <td style="width: 100px; height: 25px"><input id="txtFree1" style="width: 97px" type="text" /></td>
            <td style="width: 66px; height: 25px"><input name="checkbox" type="checkbox" id="chkFree2" />自由项2</td>
            <td style="width: 97px; height: 25px"><input id="txtFree2" style="width: 97px" type="text" /></td>
            <td style="width: 72px; height: 25px"><input name="checkbox" type="checkbox" id="chkFree3" />自由项3</td>
            <td style="width: 85px; height: 25px"><input id="txtFree3" style="width: 97px" type="text" /></td>
            <td style="width: 56px; height: 25px">
            </td>
            <td style="width: 100px; height: 25px">
            </td>
        </tr>
      <tr>
        <td style="height: 25px; width: 98px;"><input name="chkRKRQ" type="checkbox" id="chkRKRQ" />日期</td>
        <td colspan="7" style="height: 25px"><input ID="RKRQ_Start" type="text" style=" width:100px;" />
        <img src="../../Images/icon/calendar.gif" onclick="calendar(RKRQ_Start);" style="cursor: hand" />至
      <input type="text" ID="RKRQ_End" style="width:100px" disabled="disabled">
      <img src="../../Images/icon/calendar.gif" onclick="calendar(RKRQ_End);" style="cursor: hand" />&nbsp;&nbsp;&nbsp;&nbsp;<input name="checkbox" type="checkbox" id="chkRKPCH" />批次<input
          id="drpRKPCH" style="width: 95px" type="text" />到<input id="drppchend" style="width: 96px"
              type="text" />
        &nbsp;&nbsp;&nbsp;&nbsp;<input name="checkbox" type="checkbox" id="cbbarcode" />单卷号<input
            id="selbarcode" style="width: 117px" type="text" /></td>
      </tr>
    </table><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td style="height: 17px">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        <!--<input type="image" id="btnnew" src="../../Images/icon/img25.gif" onclick="return searchbarcode();"/>-->
        <img src="../../Images/icon/img25.gif" onclick="searchbarcode()" id="IMG2" />
        &nbsp; &nbsp;
  
        &nbsp; &nbsp;<asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif"/>
    </td>
      <td style="height: 17px">&nbsp;<div id ="status" align="center"></div>
      </td>
  </tr>
</table></td>
  </tr>
</table>

<table width="100%">
   <tr>
   <TD align="left" bgcolor="#dce8f4">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            当前库</span></span>
					</TD>
  </tr>
</table>
<iframe id="frmList" width="100%" height="185px"></iframe>
<table width="100%">
   <tr>
   <TD align="left" bgcolor="#dce8f4">
                        <span style="font-size: 12px"><span style="color: #082c50; background-color: #dce8f4">
                            出库线材</span></span>
					</TD>
  </tr>
</table>
<iframe id="frmOut" width="100%" height="185px"></iframe>
</form>
</body>
</html>
