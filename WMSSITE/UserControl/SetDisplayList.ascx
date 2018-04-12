<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SetDisplayList.ascx.cs" Inherits="UserControl_SetDisplayList" %>
<FONT face="宋体">
	<TABLE id="tblconfig" cellSpacing="0" cellPadding="0" width="100%" border="0" style="DISPLAY:block">
		<TR>
			<TD style="PADDING-TOP: 2px" vAlign="middle" align="left" width="12%" bgColor="#ebe9ea"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体"><strong>&nbsp;列表配置 &nbsp;&nbsp;</strong></font>
                </TD>
            <td width="8%">
                <asp:checkbox id="checkAll" onclick="check(this);" runat="server" Text="全选" Checked="True"></asp:checkbox></td>
			<TD style="PADDING-TOP: 2px" vAlign="middle" align="left" width="11%" bgColor="#ebe9ea"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;标题字体：&nbsp;</font></TD>
            <td width="10%"><asp:DropDownList
                    ID="drpHeadFont" runat="server">
                <asp:ListItem Selected="True">9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                </asp:DropDownList></td>
            <td width="11%">
                <span style="font-size: 9pt; color: #082c50">表格字体：</span></td>
            <TD style="PADDING-TOP: 2px" vAlign="middle" align="left" width="12%" bgColor="#ebe9ea"><font style="FONT-SIZE: 12px; COLOR: #082c50; FONT-FAMILY: 宋体">&nbsp;<asp:DropDownList
                    ID="drpListFont" runat="server">
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                </asp:DropDownList>&nbsp;</font></TD>
			<TD vAlign="middle" align="left" width="36%" bgColor="#ebe9ea"><asp:imagebutton id="ImageButton1" runat="server" ImageUrl="../images/icon/img20.gif" OnClick="ImageButton1_Click"></asp:imagebutton></TD>
		</TR>
		<TR>
			<TD align="left" colSpan="7"><asp:placeholder id="m_pnlInfo" runat="server"></asp:placeholder></TD>
		</TR>
		<tr>
			<td align="left" colSpan="7"><INPUT id="hidPageNbr" type="hidden" name="ListLenth" runat="server">
                <input id="hidShowList" runat="server" type="hidden" /></td>
		</tr>
	</TABLE>
</FONT>
