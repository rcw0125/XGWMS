<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModiCXH.aspx.cs" Inherits="SiteBll_FormMan_ModiCXH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>车厢号</title>
     <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
<script language=javascript type="text/javascript">
    function getTXTCXH()
    {
    var txtCXH=document.getElementById("txtCXH");
    var txtFYDH=document.getElementById("txtFYDH");
    if(txtCXH.value=="")
    {
    alert("车厢号不能为空！");
    return false;
    }
    url="SaveCXH.aspx?CXH="+txtCXH.value+"&cxfydh="+txtFYDH.value;
    window.location=url;
    }
</script>
</head>

<body leftMargin="0" topMargin="0">
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 163px">
                    请输入火车车厢号</td>
                <td style="width: 219px">
                    <asp:TextBox ID="txtCXH" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 163px; height: 26px;"><img src="../../Images/icon/img20.gif"  ID="imgBtnQuery" onclick="getTXTCXH();" /><%--<asp:ImageButton ID="imgBtnQuery" runat="server" src="../../Images/icon/img20.gif" OnClick="imgBtnQuery_Click1"/>--%>
                </td>
                <td style="width: 219px; height: 26px;">
                    <input id="txtFYDH" type="hidden"  value="<%=fydh %>"/>
                <asp:ImageButton ID="imgBtnCancle" runat="server" ImageUrl="../../Images/icon/img12.gif" OnClick="imgBtnCancle_Click" /></td>
            </tr>
            <tr>
                <td style="width: 163px">
                </td>
                <td style="width: 219px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
