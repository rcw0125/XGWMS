<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KCTWSet.aspx.cs" Inherits="SiteBll_SysMan_KCTWSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>头尾材扣重设置</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/KCTW.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" onload="getBZBZInfo()"">
    <form id="form1" runat="server" >
    
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
					<TD vAlign="middle" align="center" width="60%" style="height: 29px"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">头尾材扣重设置</font></TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 29px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
					<TD align="center" width="10%" style="height: 29px"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"></label>
					</TD>
					<TD align="center" width="10%" style="height: 29px"><label style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体"></label>
					</TD>
					<TD vAlign="middle" align="center" width="2%" style="height: 29px"><IMG src="../../images/icon/compartcenter.gif" align="textTop">
					</TD>
				</TR>
			</TABLE>
    
	    <table width="100%" id="Table2" border="1" cellpadding="1" cellspacing="0">
                <tr>
                    <td bgcolor="#dce8f4" style="height: 30px;width:16%;>
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">物料编码</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px;width:12%;>
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">品种</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px;width:12%;">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">规格</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px;width:12%;">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">产品价格</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px;width:12%;">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">废品价格()</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px;width:12%;">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">头尾重量(千克)</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px;width:12%;">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">扣重(千克)</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px;width:12%;">
                        <a id="allcheck" style="font-size: 12px; color: #072d52; font-family: 宋体" href="#">全启用</a>
                        <a id="alluncheck" style="font-size: 12px; color: #072d52; font-family: 宋体" href="#">全禁用</a>
                    </td>
                </tr>
            </table>
        <div style=" height:200px;width:100%;background-color: #ffffff; overflow:auto;">
            <table width="100%" id="grvstand" border="1" cellpadding="1" cellspacing="0" bordercolor ="#dce8f4">
                <tbody id="grvstandTbody">
                </tbody>
            </table>
        </div>
    <TABLE class="fixColStyle" id="TABLE3" style="DISPLAY: block; top: 1px; background-color: #ffffff;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 73%;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;维护</font></TD>
					<TD width="88%" bgColor="#dce8f4" style="height: 20px">
                        </TD>
				</TR>
	</TABLE>
	<div style =" height:100px">
	<br><br>
        &nbsp;&nbsp;物料编码:<input id="txt_wlh" type="text" style="width:120px;"/>
        &nbsp;&nbsp;品种：<input id="txt_ph" type="text" style="width:100px;"/>
        &nbsp;&nbsp;规格：<input  id="txt_gg" type="text"style="width:60px;"/>
        &nbsp;&nbsp;产品价格：<input id="txt_pprice" type="text" style="width:60px;"/>元/吨
        &nbsp;&nbsp;废品价格：<input id="txt_fprice" type="text" style="width:60px;" />元/吨
        &nbsp;&nbsp;头尾材重量：<input id="txt_twzl" type="text" style="width:60px;" />千克
    </div>
    <TABLE class="fixColStyle" id="TABLE4" style="DISPLAY: block;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 73%;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;操作</font></TD>
					<TD width="88%" bgColor="#dce8f4" style="height: 20px">
                        </TD>
				</TR>
	</TABLE>
	<br>
	<div style="height:50px;">
        <input type="image" id="btnnew" src="../../Images/icon/imgNew1.gif" onclick="return setbtnstatuszxbz('new');"/><input type="image" id="btnedit" src="../../Images/icon/imgChange1.gif" onclick="return setbtnstatuszxbz('edit');"/>
        <input type="image" id="btnsave"  src="../../Images/icon/save.gif"  onclick="return setbtnstatuszxbz('save');"/><input type="image" id="btncancel"  src="../../Images/icon/imgCancle1.gif" onclick="return setbtnstatuszxbz('cancel');" />
        <input type="image" id="btndel"  src="../../Images/icon/img19.gif" onclick = "return setbtnstatuszxbz('del');" /></div>
        <input id="hopetype" type="hidden"/>
        <input id="hwlh" type="hidden" />
        <input id="hph" type="hidden" />
        <input id="hgg" type="hidden" />
        <input id="hpprice" type="hidden" />
        <input id="hfprice" type="hidden" />
        <input id="htwzl" type="hidden" />
        <input id="hkczl" type="hidden" />
        
         物料号查询： <input id="query_wlh" />
         <input type="image"  src="../../Images/icon/img25.gif"  OnClick="getBZBZInfo();" />
   
    
    </form>
</body>
</html>
