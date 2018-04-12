<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuSpecial.aspx.cs" Inherits="SiteBll_CheckQu_QuSpecial" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>特殊信息</title>
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
	
	var frm = document.getElementById("frm");
	if(chazhao.style.display == "block")
	{
		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		chazhao.style.display = "none";
		//hidQuery.value= "none";
		frm.style.height = "400px";
	}
	else
	{
		btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
		chazhao.style.display = "block";
		//hidQuery.value = "block";
		frm.style.height = "200px";
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
    <form id="form1" name="form1" runat="server">
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
					<TD vAlign="middle" align="center" width="60%" style="height: 29px"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">特殊信息</font></TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 29px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%" style="height: 29px"><div id="imgcz" style ="visibility:hidden">
                            查询条件<IMG id="btnQuery" style="CURSOR: hand" onclick="chazhao();" alt="展开" src="../../images/icon/expand.gif"
							align="textTop" border="0"></div>
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
					<TD vAlign="top" align="left" bgColor="#dce8f4" style="height: 89px; width: 35%;"><br><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">
                        <input id="Radio1" type="radio" name="rdtype"checked="CHECKED" onclick="setdispaly();"/>完工单更改
                        <input id="Radio2" type="radio" name="rdtype" onclick="setdispaly();"/>库存更改
                        <br>
                        <br>
                        <div id="tpwgdp">批次号:<input type="text" id="txtpch" size="15" style=" height:21px;"/></div></font></TD>
					<TD width="88%" bgColor="#dce8f4" style="height: 89px"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">
					     <div id="tpkc" style="visibility:hidden;">
					         <input id="Radio3" type="radio" name="rdpcdj" checked="checked" onclick="setdispalytpkc();">批次更改
					         <input id="Radio4" type="radio" name="rdpcdj" onclick="setdispalytpkc();">单卷更改
					         <br>
					         <div id="sx">&nbsp;属性<br>&nbsp;&nbsp;&nbsp;<select id="selsxa" style=" width :150px;"></select></div>
					     </div></font>
                        </TD>
				</TR>
	</TABLE>
  <table class="fixColStyle" id="chazhao" style="DISPLAY: none" cellSpacing="0" cellPadding="0"	width="100%" align="center" border="0" runat="server">
  <tr>
    <td style="height:20px;" bgColor="#dce8f4"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询条件</font></td>
  </tr>
  <tr>
    <td style="height: 175px"><table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="2">
      <tr>
        <td height="25" style="width: 54px;"><input name="chkCK" type="checkbox" id="cbck" onclick="setselvalue('ck','WMS_Bms_Inv_Info','selck');" />仓库</td>
        <td style="width: 100px">
            <select ID="selck" style="width:100px;" unselectable=off></select>
      </td>
        <td style="width:  58px;"><input name="cbsx" type="checkbox" id="chkRKSX"  onclick="setselvalue('sx','WMS_Bms_Inv_Info','selsx');"  />属性</td>
        <td style="width: 94px">
            <select ID="selsx" style="width:100px;"></select>
      </td>
        <td style="width: 69px"><input name="checkbox" type="checkbox" id="cbwlh" />物料</td>
        <td style="width: 93px">
            <input id="selwlh" type="text" /></td>
        <td style="width: 71px"><input name="checkbox" type="checkbox" id="cbph" onclick="setselvalue('ph','WMS_Bms_Inv_Info','selph');"  />牌号</td>
        <td style="width: 100px">
            <select ID="selph" style="width:100px;"></select>
      </td>
      </tr>
      <tr>
        <td height="25" style="width: 54px"><input name="checkbox" type="checkbox" id="cbhw"/>货位</td>
        <td style="width: 100px"> 
            <input id="selhw" style="width: 98px" type="text" /></td>
        <td style="width: 58px"><input name="checkbox" type="checkbox" id="cbgg" onclick="setselvalue('gg','WMS_Bms_Inv_Info','selgg');"  />规格</td>
        <td style="width: 94px">      <select  ID="selgg" style="width:100px;"></select>
      </td>
        <td style="width: 69px"><input name="checkbox" type="checkbox" id="cbbb"onclick="setselvalue('BB','WMS_Bms_Inv_Info','selbb');" />班别</td>
        <td style="width: 93px">      <select  ID="selbb" style="width:100px;">
            </select>
      </td>
        <td style="width: 71px"><input name="checkbox" type="checkbox" id="cbgh" />钩号</td>
        <td style="width: 100px">      
            <input id="selgh" style="width: 100px" type="text" /></td>
      </tr>
      <tr>
        <td style="width: 54px; height: 25px;"><input name="checkbox" type="checkbox" id="cbErrSeason" onclick="setselvalue('ErrSeason','WMS_Bms_Inv_Info','selErrSeason');"  />错因</td>
        <td style="width: 100px; height: 25px;">      <select  ID="selErrSeason" style="width:100px;"></select>
      </td>
        <td style="width: 58px; height: 25px;"><input name="checkbox" type="checkbox" id="cbscx" onclick="LoadSCX();"  />生产线</td>
        <td style="width: 94px; height: 25px;">      <select  ID="drpSCX" style="width:100px;">
            </select>
            </td>
        <td style="height: 25px; width: 69px;"><input name="checkbox" type="checkbox" id="cbpcinfo"onclick="setselvalue('pcinfo','WMS_Bms_Inv_Info','selpcinfo');"  />特殊信息</td>
        <td style="width: 93px; height: 25px;">     <select  ID="selpcinfo" style="width:100px;">
        </select></td>
        <td style="height: 25px; width: 71px;"></td>
        <td style="width: 100px; height: 25px;">
            &nbsp;</td>
      </tr>
      <tr>
        <td style="height: 36px; width: 54px;"><input name="chkRKRQ" type="checkbox" id="chkRKRQ" />日期</td>
        <td colspan="7" style="height: 36px"><input ID="RKRQ_Start" type="text" style=" width:100px;" />
        <img src="../../Images/icon/calendar.gif" onclick="calendar(RKRQ_Start);" style="cursor: hand" />至
      <input type="text" ID="RKRQ_End" style="width:100px" disabled="disabled">
      <img src="../../Images/icon/calendar.gif" onclick="calendar(RKRQ_End);" style="cursor: hand" />&nbsp;&nbsp;&nbsp;&nbsp;<input name="checkbox" type="checkbox" id="chkRKPCH" />批次<input
          id="drpRKPCH" style="width: 89px" type="text" />
            到 &nbsp;<input id="drppchend" style="width: 87px" type="text" />
        &nbsp;&nbsp;&nbsp;&nbsp;<input name="checkbox" type="checkbox" id="cbbarcode" />单卷号<input
            id="selbarcode" type="text" /></td>
      </tr>
    </table><table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
</table></td>
  </tr>
</table>
        &nbsp;&nbsp;&nbsp;<input name="chkRKRQ" type="checkbox" id="cbpcinfoa" onclick="getpcinfo('pcinfo','WMS_Pub_Pcinfo','selpcinfoa');"/>&nbsp;特殊信息<select  ID="selpcinfoa" style="width:414px;"></select>
        新录<input type="text" id="newpcinfo" style=" height:21px; width: 215px;"/><br />
        <table class="fixColStyle" id="Table2" style="DISPLAY: block" cellSpacing="0" cellPadding="0"	width="100%" align="center" border="0" runat="server">
  <tr>
    <td style="height:20px;" bgColor="#dce8f4"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;</font></td>
  </tr>
  <tr>
    <td style="height:20px;" bgColor="#dce8f4"><input type="image" src="../../Images/icon/chanzhao.gif"id="imgquery" onclick="return getbarcode();" /> &nbsp;&nbsp
    <input type="image" src="../../Images/icon/imgChange1.gif"; onclick="return updatepcinfo();" id="Image1"/></td>
  </tr>
</table>
        <div id="frm"align="center" style="overflow:auto; height:400px"><iframe id="ifrmlist" name="ifrmlist" width="99%" height="99%"></iframe></div>
        <input id="Hpch" type="hidden" value=""/>&nbsp;<input id="hbarcode" type="hidden" value=""/>&nbsp;
    </form>
</body>
</html>
