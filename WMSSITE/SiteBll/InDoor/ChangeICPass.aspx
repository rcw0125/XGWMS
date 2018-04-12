<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeICPass.aspx.cs" Inherits="SiteBll_InDoor_ChangeICPass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改初始密码</title>
    <LINK href="CSS/Input.css" type="text/css" rel="stylesheet">
       <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
    <script language=javascript type="text/javascript">
        function ChangePass()
        {
            var txtPass = document.getElementById("txtPassword");
            var txtConfirm = document.getElementById("txtConfirm");
            var lblNum = document.getElementById("lblICNum"); 
            if(txtPass.value==null || txtPass.value=="")
            {
                alert("密码不能为空！");
                return;
            }
            if(txtConfirm.value==null || txtConfirm.value=="")
            {
                alert("确认密码不能为空！");
                return;
            }
            if(txtPass.value!=txtConfirm.value)
            {
                alert("密码和确认密码不一致！");
                return;
            }
            if(txtPass.value=="1")
            {
                alert("密码不能为初始密码！");
                return;
            }
            var request=getXmlHttpRequest();
            var url = "ChageAjax.aspx.aspx?TYPE=1&ICNUM=" + lblNum.value + "&ICPASS=" + txtPass.value;
            sendRequest(url,"","POST",request);
            alert("修改成功!");
            window.close();
        }
    </script>
</head>
<base target="_self" />
<body>
    <form id="form1" runat="server">
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td height="17" width="3" background="../../../images/down/downtiaotop.gif"></td>
			<td height="17" background="../../../images/down/downtiaocenter.gif"><IMG height="1" width="100%" src="Images/down/downtiaocenter.gif"></td>
			<td height="17" width="3" background="../../../images/down/downtiaotop.gif"></td>
		</tr>
	</table>
	<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr vAlign="top">
						<td width="3" background="../../../images/down/downtiaobottom.gif"></td>
						<td bgColor="#ffffff">
							<!--实际内容-->
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<tr>
									<td align="center" colspan=2>您的密码为初始密码，请修改密码！</td>
								</tr>
								<tr>
									<td class="formTitle">客户名称:</td>
									<td class="formTitle">
										<asp:Label id="lblName" runat="server"></asp:Label></td>
								</tr>
                                <tr>
                                    <td>
                                        IC卡号：</td>
                                    <td>
										<asp:Label id="lblICNum" runat="server"></asp:Label></td>
                                </tr>
								<tr>
									<td>输入口令:</td>
									<td>
										<asp:TextBox id="txtPassword" runat="server" TextMode="Password" MaxLength="32" Width="100%"></asp:TextBox></td>
								</tr>
								<tr>
									<td>确认口令:</td>
									<td>
										<asp:TextBox id="txtConfirm" runat="server" TextMode="Password" MaxLength="32" Width="100%"></asp:TextBox></td>
								</tr>
								<tr>
									<td colspan="2" align="center"><br>
                                        <!--<input id="btnOk" type="button" value="修改口令" onclick="ChangePass();"/>-->
										<asp:Button id="btnOK" runat="server" Text="修改口令" onclick="btnOK_Click"></asp:Button>
                                        <br>
										<BR>
									</td>
								</tr>
								<tr>
									<td colspan="2"><asp:Label id="lblResult" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="必须输入口令" EnableViewState="False"
											Display="None" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
										<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="必须确认口令" EnableViewState="False"
											Display="None" ControlToValidate="txtConfirm"></asp:RequiredFieldValidator>
										<asp:ValidationSummary id="ValidationSummary1" runat="server" EnableViewState="False" Height="16px"></asp:ValidationSummary>
										<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="输入口令和确认口令不一致" EnableViewState="False"
											Display="None" ControlToValidate="txtPassword" ControlToCompare="txtConfirm"></asp:CompareValidator>
									</td>
								</tr>
							</TABLE>
							<!--实际内容--></td>
						<td width="3" background="images/down/downtiaobottom.gif"></td>
					</tr>
				</table>
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td width="100%" height="3" background="Images/down/downtiaobottom.gif"></td>
					</tr>
				</table>
    </form>
</body>
</html>
