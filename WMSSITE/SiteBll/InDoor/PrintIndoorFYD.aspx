<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintIndoorFYD.aspx.cs" Inherits="SiteBll_InDoor_PrintIndoorFYD" %>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
        <cc1:ReportView ID="ReportView1" runat="server" Width="100%" Height="100%"/>
    </form>
</body>
</html>
