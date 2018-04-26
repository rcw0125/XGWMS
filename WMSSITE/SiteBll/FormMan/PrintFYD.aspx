<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintFYD.aspx.cs" Inherits="SiteBll_FormMan_PrintFYD" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="ReportView" Namespace="Acctrue.WM_WES.ReportingServices" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>发运单打印页</title>
    <style type="text/css">


table
{
	border-right: medium none;
	border-top:medium none;
	font-size: 9pt;
	border-left: medium none;
	border-bottom: medium none;
	border-collapse: collapse;
	display:inline-block;
	
}

textarea,input,object	{ font-family: Tahoma, 宋体; font-size: 12px;  color: #000000; font-weight: normal; }
select		            { font-family: Tahoma, 宋体; font-size: 12px;  color: #000000; font-weight: normal; }

A:link{COLOR: #336DBD;FONT-SIZE: 9pt;}


A{COLOR: #336DBD;FONT-SIZE: 9pt;TEXT-DECORATION: none}
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
        <cc1:ReportView ID="ReportView1" runat="server" Width="800px" Height="600px" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
			            <rsweb:ReportViewer ID="ReportViewer1" runat="server"
                            BorderColor="Silver" ShowFindControls="False" Width="800px" Height="450px" 
                            ShowParameterPrompts="False" ShowZoomControl="False">
                        </rsweb:ReportViewer>
    </form>
</body>
</html>
