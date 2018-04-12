<%@ Page Language="C#" AutoEventWireup="true" CodeFile="colorselect.aspx.cs" Inherits="SiteBll_SysMan_HelperAffiche_colorselect" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>颜色选择器</title>
    <script language="JavaScript">
			function colorOver(theTD) {
				previewColor(theTD.style.backgroundColor);
				setTextField(theTD.style.backgroundColor);
			}
			function colorClick(theTD) {
				setTextField(theTD.style.backgroundColor);
				returnColor(theTD.style.backgroundColor);
			}
			function setTextField(ColorString) {
				document.getElementById("ColorText").value = ColorString.toUpperCase();
			}
			function returnColor(ColorString) {
				window.returnValue = ColorString;
				window.close();	
			}		
			function userInput(theinput) {
				previewColor(theinput.value);
			}
			function previewColor(theColor) {
			try {
				PreviewDiv.style.backgroundColor = theColor;
				}		 catch (e) {
								}
			}
	</script>
</head>
<body style="MARGIN:2px; BACKGROUND-COLOR:#d4d0c8">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" align="center">
				<tr>
					<td colspan="3">
						<asp:Literal id="Colors" runat="server" EnableViewState="false" />
					</td>
				</tr>
				<tr>
					<td><input type="text" name="ColorText" id="ColorText" style="WIDTH:60px;HEIGHT:22px" onkeyup="userInput(this);"></td>
					<td align="center"><div id="PreviewDiv" style="BORDER-RIGHT:black 1px solid; BORDER-TOP:black 1px solid; BORDER-LEFT:black 1px solid; WIDTH:50px; BORDER-BOTTOM:black 1px solid; HEIGHT:20px; BACKGROUND-COLOR:#ffffff"></div>
					</td>
					<td align="right"><input type="button" value="确定" onclick="returnColor(ColorText.value);" id="ColorButton"
							style="WIDTH:80px"></td>
				</tr>
			</table>
    </form>
</body>
</html>
