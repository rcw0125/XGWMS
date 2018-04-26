<%@ Page Language="C#" AutoEventWireup="true" CodeFile="infobarcode.aspx.cs" Inherits="SiteBll_CheckQu_infobarcode" %>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Src="../../UserControl/PageControlPost.ascx" TagName="PageControlPost"
    TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>当前库</title>
    <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="../../JavaScript/QuCheck.js" type="text/javascript"></script>
</head>
<body topmargin="0" leftmargin="0" onload = "setstatus('查询库存数据完毕');">
<form id="form1" method="post" runat="server">
        <cc1:ReportView ID="ReportView1" runat="server" Width="100%" Height="180px"/>
 </form>
</body>
</html>
