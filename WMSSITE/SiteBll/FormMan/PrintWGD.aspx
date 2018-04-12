<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintWGD.aspx.cs" Inherits="SiteBll_FormMan_PrintWGD" %>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打印完工单信息</title>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:reportview id="ReportView1" runat="server" Width="100%" Height="900px"></cc1:reportview> 
    </form>
</body>
</html>
