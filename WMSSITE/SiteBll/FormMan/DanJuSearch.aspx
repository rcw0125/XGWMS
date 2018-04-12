<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanJuSearch.aspx.cs" Inherits="SiteBll_FormMan_DanJuSearch" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择形态转换单</title>
     <link href="../../CSS/Input.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../../JavaScript/calendar.js" type="text/javascript"></script>
    <script language="javascript" src="../../JavaScript/CreatAjax.js" type="text/javascript"></script>
        <script type="text/javascript" language="javascript" src="../../JavaScript/XTZHJS.js" ></script>
</head>
<body leftMargin="0" topMargin="0" >
    <form id="form1" runat="server">
    <div>
 <table width="99%" border="0" cellpadding="0" cellspacing="1" bgcolor="#DEEBF7" align="center">
    <tr><td style="height:25px;" bgColor="#dce8f4">&nbsp;选择形态转换单
    </td>
    </tr>
  <tr>
    <td bgcolor="#FFFFFF" style="height:60px" align="center" valign="middle"><table width="90%" border="0" cellspacing="0" cellpadding="0">

      <tr>
        <td style="width:10%; height: 22px;" align="center">单据号</td>
        <td style="width:20%; height: 22px;">
          <asp:TextBox ID="txtDJH" runat="server" Width="95%" />        
        </td>
        <td style="width:10%; height: 22px;" align="center">批次号</td>
        <td style="width: 20%; height: 22px;"><asp:TextBox ID="txtPCH" runat="server" Width="95%" /></td>
        <td style="width: 15%; height: 22px;" align="center">仓库</td>
        <td style="width:30%; height: 22px;"><asp:DropDownList ID="drpCK" runat="server" Width="95%">
            </asp:DropDownList></td>
      </tr>
      <tr>
        <td style="width: 43px">&nbsp;</td>
        <td>&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon/img25.gif" OnClick="ImageButton1_Click" /></td>
        <td>&nbsp;<img src="../../Images/icon/img12.gif" id="IMG1" onclick="return IMG1_onclick()"  style="cursor:hand;"/></td>
        <td style="width: 208px">&nbsp;</td>
        <td style="width: 35px">&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td align="center"></td>
  </tr>

</table><table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td><DIV id="ListDiv" style="BORDER:0px;PADDING:0px;MARGIN:0px;OVERFLOW:auto;WIDTH:100%;HEIGHT:350px;white-space:nowrap;">
                <asp:GridView ID="grvDJCZ" runat="server" AutoGenerateColumns="False" Width="98%" AllowPaging="True"  PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                           <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                               <img src="../../Images/icon/choose.gif" id="imgPrint" style="cursor:hand;" alt="选择该单据" onclick="GetDanju();"/>
                                <input id="hidDJH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.ZHDH") %>'/>
                                <input id="hidPCH" runat="server" type="hidden" value='<%# DataBinder.Eval(Container, "DataItem.PCH") %>'/>
                             
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="转换单号" DataField="zhdh" />
                        <asp:BoundField HeaderText="仓库" DataField="ck" />
                        <asp:BoundField HeaderText="批次号" DataField="pch" />
                        <asp:BoundField HeaderText="物料号" DataField="swlh"/>
                        <asp:BoundField HeaderText="物料名称" DataField="swlmc"/>
                    </Columns>
                    <HeaderStyle BackColor="#DCE8F4" />
                </asp:GridView>
			</DIV></td>
  </tr>
    <tr>
    <td align="center" style="height:30px">&nbsp;
        &nbsp;<img src="../../Images/icon/img20.gif" style="cursor:hand;" onclick="close_win();"/>&nbsp;&nbsp;&nbsp;</td>
  </tr>
</table></div>
    </form>
</body>
</html>
