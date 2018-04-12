<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuStand.aspx.cs" Inherits="SiteBll_CheckQu_QuStand" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/QuCheck.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" onload="return getzxbz();">
    <form id="form1" runat="server" method="post">
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
					<TD vAlign="middle" align="center" width="60%" style="height: 29px"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">标准维护</font></TD>
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
    <TABLE class="fixColStyle" id="tblQuery" style="DISPLAY: block;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 73%;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;</font></TD>
					<TD width="88%" bgColor="#dce8f4" style="height: 20px">
                        </TD>
				</TR>
	</TABLE>
	    <table width="100%" id="Table2" border="1" cellpadding="1" cellspacing="0" bordercolor ="#dce8f4">
                <tr>
                    <td bgcolor="#dce8f4" style="height: 30px">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">牌号</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">标准</span>
                    </td>
                </tr>
            </table>
        <div style=" height:200px;width:800px;background-color: #ffffff; overflow:auto;">
            <table width="90%" height="500px" id="grvstand" border="1" cellpadding="1" cellspacing="0" bordercolor ="#dce8f4">
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
        &nbsp;&nbsp;牌号：<input id="txtph" type="text" />&nbsp;&nbsp;执行标准：<input id="txtzxbz" type="text" />
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
        <input id="htxtph" type="hidden" />
        <input id="htxtzxbz" type="hidden" />
        <input id="hopetype" type="hidden"/>
    </form>
</body>
</html>