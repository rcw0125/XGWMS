<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QPset.aspx.cs" Inherits="SiteBll_SysMan_QPset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>去皮设置</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/QP.js" type="text/javascript"></script>
</head>
<body leftMargin="0" topMargin="0" onload="return getQPInfo('');">
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
					<TD vAlign="middle" align="center" width="60%" style="height: 29px"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">去皮设置</font></TD>
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
 
	    <!--<table width="100%" id="Table2" border="1" cellpadding="1" cellspacing="0" bordercolor ="#dce8f4">
                <tr>
                    <td bgcolor="#dce8f4" style="height: 30px; display:none;">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体"></span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px; width: 100px;">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">物料号</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px; width: 400px;">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">包装标准</span>
                    </td>
                    <td bgcolor="#dce8f4" style="height: 30px">
                        <span style="font-size: 12px; color: #072d52; font-family: 宋体">是否去皮</span>
                    </td>
                </tr>
            </table>
            -->
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
            	<tr>
            		<td style="width: 526px">
            		    <div style="height: 400px;width:500px; overflow: auto;">
            	    	<table width="90%" id="grvstand" border="1" cellpadding="1" cellspacing="0" bordercolor ="#dce8f4">
            	    	<tr>
            	    	<td bgcolor="#dce8f4" style="height: 30px; display:none;"></td>
            	    	<td bgcolor="#dce8f4" style="height: 30px; width: 100px;">物料号</td>
            	    	<td bgcolor="#dce8f4" style="height: 30px; width: 400px;">包装标准</td>
            	    	</tr>
            	    	</table>
            	    	</div>
            		</td>
            		<td>
            		    <div style="height: 400px;width:150px; overflow: auto;">
                		<table width="90%" id="grvbzbz" border="1" cellpadding="1" cellspacing="0" bordercolor ="#dce8f4">
                		<tr>
                		<td bgcolor="#dce8f4" style="height: 30px; width: 100px;">包装标准</td>
                		<td bgcolor="#dce8f4" style="height: 30px; width: 60px;">全置<input type="checkbox" id="ckall"onclick="javascript:setall();"/></td>
                		</tr>
                		</table>
                		</div>
            		</td>
            	</tr>
            </table>
            
            
            
            
            
        
    <TABLE class="fixColStyle" id="TABLE3" style="DISPLAY: block; top: 1px; background-color: #ffffff;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 73%;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;查询</font></TD>
					<TD width="88%" bgColor="#dce8f4" style="height: 20px">
                        </TD>
				</TR>
	</TABLE>
	<div style =" height:50px">
	<br><br>
        &nbsp;&nbsp;物料号：<input type="text" id="selectwlh" onkeypress="javascript:searchqpinfo();"/><input type="hidden" id="hwlh"/><input type="hidden" id="hrownum"/>
    </div>
</body>
</html>
