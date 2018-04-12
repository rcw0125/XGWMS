// JScript 文件
//徐慧杰
//将选择的列表中的值显示到页面下部的文本框中
function SetModifyItem()
{
    var hidName=document.getElementById("hidCValue");
    var ICID=document.getElementById("txtICID");
    var KHBM=document.getElementById("hidKHBM");
    var KHName=document.getElementById("txtKHName");
    var ICNumber=document.getElementById("txtICNumber");
    var Proposer=document.getElementById("DDListProposer");
    var CPH=document.getElementById("txtCPH");
    var e = event.srcElement;
    var td = e.parentNode;
    var texts =td.all.tags("INPUT");
    hidName.value=texts[0].value;
//  var sIndex=Proposer.selectedIndex;
//  Proposer.options[sIndex].value=texts[2].value;
    var tr=td.parentNode;
    var tds=tr.all.tags("td");
    ICID.value=tds[4].innerText;
    ICNumber.value=tds[4].innerText;
    KHBM.value=tds[1].innerText;
    KHName.value=tds[2].innerText;
    CPH.value=tds[3].innerText;
    Proposer.options.value=texts[2].value;
}


//清空值
function ClearValue()
{
    var hidName=document.getElementById("hidCValue");
    var ICID=document.getElementById("txtICID");
    var KHName=document.getElementById("txtKHName");
    hidName.value="";
    ICID.value="";
    ICID.value="";
    var tdPassOne=document.getElementById("tdPassOne");
    var tdPassTwo=document.getElementById("tdPassTwo");
    var PassOne=document.getElementById("txtPassOne");
    var PassTwo=document.getElementById("txtPassTwo");
    tdPassOne.innerText="";
    tdPassTwo.innerText="";
    PassOne.style.display="none";
    PassTwo.style.display="none";
}

function ShowPassEnter()
{
    var tdPassOne=document.getElementById("tdPassOne");
    var tdPassTwo=document.getElementById("tdPassTwo");
    var PassOne=document.getElementById("txtPassOne");
    var PassTwo=document.getElementById("txtPassTwo");
    tdPassOne.innerText="密码";
    tdPassTwo.innerText="密码确认";
    PassOne.style.display="block";
    PassTwo.style.display="block";
}

//打开客户选择框
function KHSearch(idt)
{
    document.getElementById("hidchild").value=idt;
    var width=550;
	var height=350;
    var str = "height=" +400; 
	str += ",width=" + 400; 
	if (window.screen)
	{ 
		var ah = screen.availHeight - 30; 
		var aw = screen.availWidth - 10; 
		var xc = (aw) / 2; 
		var yc = (ah - height) / 2; 
		str += ",left=" + xc + ",screenX=" + xc; 
		str += ",top=" + yc + ",screenY=" + yc;
		str+=",scrollbars=no";
	}
	var url="KHSlc.aspx";
    window.open(url,'KHSlc',str);
}

//关闭当前页
function ClosePage()
{
    window.close();
}

//得到客户信息
function GetKHInfo()
{
    var e = event.srcElement;
    var tr = e.parentNode.parentNode;
    var tds=tr.all.tags("td");
    var hidKHID=window.opener.document.all.hidKHID;
    var txtKHName=window.opener.document.all.txtKHName;
    var hidKHLB=window.opener.document.all.hidKHLB;
    var txtKHNameSearch=window.opener.document.all.txtKHNameSearch;
    if(window.opener.document.all.hidchild.value=="searchKH")
    {
        txtKHNameSearch.value=tds[2].innerText;
        window.close();
    }
    else
    {
        hidKHID.value=tds[1].innerText;
        txtKHName.value=tds[2].innerText;
        hidKHLB.value=tds[4].innerText;
        window.close();
    }
}

//弹出发运单查询页并将客户编码和车牌号传值
function FYDCheck()
{
    if(document.getElementById("hidKHBM").value==null||document.getElementById("hidKHBM").value=="")
    {
        window.alert("您没有选中IC卡，无法查询！");
        return;
    }
    else
    {
        window.open('FYDCheck.aspx?khbm='+document.getElementById("hidKHBM").value+'&cph='+document.getElementById("txtCPH").value, 'KHSC', 'height=500, width=950, top=100, left=50, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no');
    }
}


function PrintIC()
{
    var hidSICID = document.getElementById("hidSICID");
    var hidSKHName = document.getElementById("hidSKHName");
    var hidSCPH = document.getElementById("hidSCPH");
    var hidSProposer = document.getElementById("hidSProposer");
    var Proposer = "";
    if(hidSProposer.value != "请选择")
    {
        Proposer = hidSProposer.value;
    }
    window.open("PrintIC.aspx?ICID="+hidSICID.value+"&KHName="+hidSKHName.value+"&CPH="+hidSCPH.value+"&Proposer="+Proposer,"","toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes");
}


function SelectDataGridRow(DataGridName,rowIndex) 
{
    var mytable=document.getElementById(DataGridName);
     var e = event.srcElement;
     var tds = null;
     var strPCH=null;
     if(e.tagName=="TD")
       tds= e.parentNode.all.tags("td");
     else
       tds=e.all.tags("td");
     mytable.rows[rowIndex].oldcolor=mytable.rows[rowIndex].style.backgroundColor;
     mytable.rows[rowIndex].style.backgroundColor='#C8F7FF';
     for(var i=0;i<mytable.rows.length;i++)
     {
         if(i!=rowIndex)
         {
            mytable.rows[i].style.backgroundColor="#FFFFFF";
         }
     }
}

//刷卡后获取信息
function enterkey() 
{ 
    if( event.keyCode == 13) 
    { 
        event.keyCode = 9;
        //document.getElementById("txtCPH").focus();
    }
} 