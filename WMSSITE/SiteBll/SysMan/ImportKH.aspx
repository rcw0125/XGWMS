<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportKH.aspx.cs" Inherits="SiteBll_SysMan_ImportKH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打印标签</title>
     <LINK href="../../CSS/Input.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div><table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="25">&nbsp;打印方式
      <asp:DropDownList ID="Rrfsdrop" runat="server" Width="32%" OnSelectedIndexChanged="Rrfsdrop_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem></asp:ListItem>
      </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="25">&nbsp;选对仓库
    <asp:DropDownList ID="ckdropdown" runat="server" Width="34%"></asp:DropDownList></td>
  </tr>
        <tr>
            <td height="40" valign="top">   <div id="dgfangshi" runat=server>
                                    货位行号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWrow1" runat="server"></asp:TextBox>货位列号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWcolumn1" runat="server"></asp:TextBox></div><div id="cpfangshi" runat=server>
                                        最小行号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWminrow" runat="server"></asp:TextBox>最大行号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWmaxrow"
                                            runat="server"></asp:TextBox><br />
                                        最小列号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWmincolumn" runat="server"></asp:TextBox>最大列号<FONT face="宋体" color="#ff9966">*</FONT><asp:TextBox ID="HWmaxcolumn"
                                            runat="server"></asp:TextBox></div>          </td>
        </tr>
  <tr>
    <td>&nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon/img20.gif" OnClick="ImageButton1_Click" /> &nbsp;<asp:ImageButton ID="imgBtnReset" runat="server" ToolTip="点击“重置”，把编制信息还原成初始状态。" ImageUrl="../../images/icon/imgCancle1.gif" OnClick="imgBtnReset_Click"/></td>
  </tr>
</table>
    
    </div>
    </form>
</body>
</html>
