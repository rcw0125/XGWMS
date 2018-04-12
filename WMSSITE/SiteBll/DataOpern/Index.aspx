<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="SiteBll_DataOpern_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>数据处理首页</title>
</head>
<frameset cols="120,*" frameborder="1" border="0" framespacing="8" rows="*">
		<frame name="LeftFrame" scrolling="auto" src="DataOpenLeftTree.aspx?TYPE=<%=TYPE %>" frameborder="YES"
			bordercolor="#e1e1e1">
		<frame name="RightFrame" scrolling="no" src="<%=RigthURL %>" frameborder="YES">
	</frameset>
</html>
