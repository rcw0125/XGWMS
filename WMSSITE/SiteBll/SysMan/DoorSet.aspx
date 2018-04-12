<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoorSet.aspx.cs" Inherits="SiteBll_SysMan_DoorSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/DoorSet.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
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
					<TD vAlign="middle" align="center" width="60%" style="height: 29px"><font style="FONT-SIZE: 12px; COLOR: #072d52; FONT-FAMILY: 宋体">门岗设置</font></TD>
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
			<div style="height:300px; overflow:auto">
        <asp:GridView ID="grvdoor" runat="server" AutoGenerateColumns="False" 
             Width="100%" OnRowDataBound="grvdoor_RowDataBound">
            <Columns>
                <asp:BoundField DataField="doorno" HeaderText="门岗编号" SortExpression="WGDH" />
                <asp:BoundField DataField="doorname" HeaderText="门岗名称" SortExpression="scxbm" />
                <asp:BoundField DataField="serverip" HeaderText="IP" SortExpression="pcinfo" />
                <asp:BoundField DataField="port" HeaderText="端口" SortExpression="pclx" />
            </Columns>
            <HeaderStyle BackColor="#DCE8F4" CssClass="fixHeaderTest" />
        </asp:GridView>
        </div>
        <br />
        
    
    <TABLE class="fixColStyle" id="TABLE3" style="DISPLAY: block; top: 1px; background-color: #ffffff;" cellSpacing="0" cellPadding="0"
				width="100%" align="center" border="0" runat="server">
				<TR>
					<TD vAlign="bottom" align="left" bgColor="#dce8f4" style="height: 20px; width: 73%;"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;维护</font></TD>
					<TD width="88%" bgColor="#dce8f4" style="height: 20px">
                        </TD>
				</TR>
	</TABLE>
	
	<div style=" height:200px; width: 404px;float:left;">
	<br/>&nbsp;&nbsp;门岗编号：<input id="txtdoorno" type="text" runat="server" /><br/>
	&nbsp;&nbsp;门岗名称：<input type="text" id="txtdoorname" runat="server"/><br />
    &nbsp;&nbsp;IP地&nbsp;&nbsp;址：<input type="text" id="txtip" runat="server"/>    <br />
    &nbsp;&nbsp;端&nbsp;&nbsp;&nbsp;&nbsp;口：<input type="text" id="txtport" runat="server"/><br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;<input type="image" id="btnnew" src="../../Images/icon/imgNew1.gif" onclick="javascript:adddoor();"/>
        <input type="image" id="btnsave"  src="../../Images/icon/save.gif" runat="Server" onserverclick="btnsave_ServerClick" onclick="javascript:savedoor();"/>
	</div>
	<div style=" height:200px; width: 404px; display:none">
	<br/>&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;门岗：<asp:DropDownList ID="ddlmg"
            runat="server" OnSelectedIndexChanged="ddlmg_SelectedIndexChanged" OnDataBound="ddlmg_DataBound" onchange="javascript:sethidvalue();">
        </asp:DropDownList>
	<br/>&nbsp;&nbsp;摄像头名称：<input type="text" id="txtdcname" runat="Server"/>
	<br/>&nbsp;&nbsp;摄像头地址：<input type="text" id="txtdcip" runat="Server"/>
	<br/>&nbsp;&nbsp;摄像头端口：<input type="text" id="txtdcport" runat="Server"/><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;<input type="image" id="Image1" src="../../Images/icon/imgNew1.gif" onclick="javascript:adddoorcamer();"/>
        <input type="image" id="Image2"  src="../../Images/icon/save.gif" runat="Server" onserverclick="Image2_ServerClick" />
    </div>
	<br>
	<br>
	<div style="height:50px;">
        </div>
        <input id="hdcno" type="hidden" runat="Server"/>
        <input id="htxtmgno" type="hidden" runat="server" />
        <input id="hbzxx" type="hidden" />
        <input id="hbzsx" type="hidden" />
        <input id="hclkz" type="hidden" />
        <input id="hbz" type="hidden" />
        <input id="hopetype" type="hidden"/>
    </form>
</body>
</html>
