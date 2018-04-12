// JScript 文件
function AddFull(flag)
{
	if(flag == 1)
	{
		parent.document.body.cols = "*,100%";
	}
	if(flag == 0)
	{
		parent.document.body.cols = "120,*";
	}
}

//打开原始单号选择框
function OpenYSDHWindow(DJLX)
{
    var hidState = document.getElementById("hidState");
    var txtPDDH = document.getElementById("txtPDDH");
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
	var url="YSDHSearch.aspx?DJLX="+DJLX+"&State="+hidState.value+"&PDDH="+txtPDDH.value;
    window.open(url,'YSDHSearch',str);
}

//打开盘点单号选择框
function OpenPDDHWindow(DJLX)
{
    var hidState = document.getElementById("hidState");
    if(hidState.value!="AddPDD")
    {
        var YSDH = document.getElementById("txtYSDH");
        var width=550;
	    var height=350;
        var str = "height=" +500; 
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
        window.open('PDDHSearch.aspx?YSDH='+YSDH.value+'&DJLX='+DJLX+'&State='+hidState.value,'PDDHSearch',str);
    }
}

function OpenWPHWpage()
{
    var hidCKID = document.getElementById("hidCKID");
    var hidYSDH = document.getElementById("hidYSDH");
    if(hidCKID.value == "")
    {
        alert("未选择任何盘点单");
        return;
    }
    var str = "height=200, width=300, top=200, left=200, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no";
    var url="WPHWlist.aspx?CKID="+hidCKID.value+"&YSDH="+hidYSDH.value;
    window.open(url,'KCadjustPYRK',str);
}

//得到原始单号
function GetYSDH()
{    
    var hidDJLX = document.getElementById("hidDJLX");
    var e = event.srcElement;
    var tr = e.parentNode.parentNode;
    var tds=tr.all.tags("td");
    var txtYSDH=window.opener.document.getElementById("txtYSDH");
    var hidState=document.getElementById("hidState");
    var hidPDDH=document.getElementById("hidPDDH");
    txtYSDH.focus();
    if(hidDJLX.value=="粗盘")
    {
        window.opener.document.location="CuPan.aspx?YSDH="+tds[1].innerText+"&State="+hidState.value+"&PDDH="+hidPDDH.value;
	}
	if(hidDJLX.value=="抽盘")
	{
	    window.opener.document.location="ChouPan.aspx?YSDH="+tds[1].innerText+"&State="+hidState.value+"&PDDH="+hidPDDH.value;
	}
	if(hidDJLX.value!="粗盘"&&hidDJLX.value!="抽盘")
	{
	    window.opener.document.getElementById("txtYSDH").value = tds[1].innerText;
	    window.opener.document.getElementById("hidYSDH").value = tds[1].innerText;
	    window.opener.document.getElementById("hidCKID").value = tds[2].innerText;
	}
    window.close();
}

//得到盘点单号
function GetPDDH()
{    
    var hidDJLX = document.getElementById("hidDJLX");
    var hidState = document.getElementById("hidState");
    var e = event.srcElement;
    var tr = e.parentNode.parentNode;
    var tds=tr.all.tags("td");
    if(hidDJLX.value=="粗盘")
    {
        window.opener.document.location="CuPan.aspx?PDDH="+tds[2].innerText+"&State="+hidState.value;
	}
	else
	{
	    window.opener.document.location="ChouPan.aspx?PDDH="+tds[2].innerText+"&State="+hidState.value;
	}
    window.close();
}

function CheckYSDH()
{
    var txtYSDH = document.getElementById("txtYSDH");
    if(txtYSDH.value!="")
    {
        var hidState = document.getElementById("hidState");
        if(hidState.value == "")
        {
            CheckYSDHbrowse();
        }
        else
            if(hidState.value=="AddPDD")
            {
                CheckYSDHadd();
            }
            else
                if(hidState.value=="ModifyPDD")
                {
                    CheckYSDHbrowse();
                }
    }
}

//新建时检查是否填写了原始单号，若填写了，还要检查是否存在此原始单号以及状态
function CheckYSDHadd()
{
    var txtYSDH = document.getElementById("txtYSDH");
    var txtCK = document.getElementById("txtCK");
    var hidCKID = document.getElementById("hidCKID");
    var txtPDRQ = document.getElementById("txtPDRQ");
    if(txtYSDH.value == "")
    {
        alert("请填写原始单号");
    }
    else
    {
        var request=getXmlHttpRequest();
        var url="TestYSDH.aspx?YSDH="+document.all.txtYSDH.value;
        sendRequest(url,"","POST",request);
        var result = request.responseText;
        if(result == "no")
        {
            alert("原始单据不存在或已经盘点，请重新选择原始单据!");
            txtYSDH.value = "";
            txtYSDH.focus();
        }
        else
        {
            hidCKID.value = result.split(",")[0];
            txtCK.value = result.split(",")[1];
            txtPDRQ.value = result.split(",")[2];
        }
    }
}

function CheckYSDHbrowse()
{
    var txtYSDH = document.getElementById("txtYSDH");
    var txtCK = document.getElementById("txtCK");
    var hidCKID = document.getElementById("hidCKID");
    var txtPDRQ = document.getElementById("txtPDRQ");
    
    var txtPDDH = document.getElementById("txtPDDH");
    var txtZDRQ = document.getElementById("txtZDRQ");
    var txtZDRY = document.getElementById("txtZDRY");
    var txtSHRY = document.getElementById("txtSHRY");
    var txtSHRQ = document.getElementById("txtSHRQ");
    var txtDJZT = document.getElementById("txtDJZT");
    
    var request=getXmlHttpRequest();
    var url="getYSDHInfo.aspx?YSDH="+document.all.txtYSDH.value;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result != "no")
    {
        hidCKID.value = result.split(",")[0];
        txtCK.value = result.split(",")[1];
        txtPDRQ.value = result.split(",")[2];
        
        txtPDDH.value = "";
    }
    else
    {
        alert("原始单据不存在或已经盘点，请重新选择原始单据!");
        txtYSDH.value = "";
        txtYSDH.focus();
    }
}

function CheckPDDH(DJLX)
{
    var hidState = document.getElementById("hidState");
    if(hidState.value == "")
    {
        CheckPDDHbrowse(DJLX);
    }
}



function CheckPDDHbrowse(DJLX)
{
    var txtPDDH = document.getElementById("txtPDDH");
    var grdInfo = document.getElementById("grdInfo");
    var txtYSDH = document.getElementById("txtYSDH");
    var txtCK = document.getElementById("txtCK");
    var hidCKID = document.getElementById("hidCKID");
    var txtPDRQ = document.getElementById("txtPDRQ");
    var txtZDRY= document.getElementById("txtZDRY");
    var txtDJZT=document.getElementById("txtDJZT");
    var txtZDRQ=document.getElementById("txtZDRQ");    
    var txtSHRY=document.getElementById("txtSHRY");
    var txtSHRQ=document.getElementById("txtSHRQ");
    var hidDJLX=document.getElementById("hidDJLX");
    var ListBox1 = document.getElementById("ListBox1");
    var ListBox2 = document.getElementById("ListBox2");
    if(txtPDDH.value !="")
    {        
        var request=getXmlHttpRequest();
        var url="TestPDDH.aspx?PDDH="+txtPDDH.value+"&DJLX="+DJLX;
        sendRequest(url,"","POST",request);
        var result = request.responseText;
        if(result != "no")
        {
            txtYSDH.value = result.split(",")[0];
            hidCKID.value = result.split(",")[1];
            txtCK.value = result.split(",")[2];
            txtPDRQ.value = result.split(",")[3];
            txtZDRQ.value = result.split(",")[4];
            txtZDRY.value = result.split(",")[5];
            txtSHRY.value = result.split(",")[6];
            txtSHRQ.value = result.split(",")[8];
            txtDJZT.value = result.split(",")[9];
        }
        else
        {
            alert("盘点单据不存在或已经盘点，请重新选择盘点单据!");
            txtPDDH.value = "";
            grdInfo.innerText = "";
            ListBox1.innerText = "";
            ListBox2.innerText = "";
            txtPDDH.focus();
        }
    }
}


//删除粗盘单
function DeletePDD(PDDH)
{
    var txtPDDH = document.getElementById("txtPDDH");
    var grdInfo = document.getElementById("grdInfo");
    var ListBox1 = document.getElementById("ListBox1");
    var ListBox2 = document.getElementById("ListBox2");
    var txtYSDH = document.getElementById("txtYSDH");
    var txtCK = document.getElementById("txtCK");
    var hidCKID = document.getElementById("hidCKID");
    var txtPDRQ = document.getElementById("txtPDRQ");
    var txtZDRY= document.getElementById("txtZDRY");
    var txtDJZT=document.getElementById("txtDJZT");
    var txtZDRQ=document.getElementById("txtZDRQ");    
    var txtSHRY=document.getElementById("txtSHRY");
    var txtSHRQ=document.getElementById("txtSHRQ");
    var hidDJLX=document.getElementById("hidDJLX");
    if (confirm("是否真的要删除该单据吗？")) 
    { 
        var request=getXmlHttpRequest();
        var url="AjaxLogic.aspx?TYPE=1&PDDH="+txtPDDH.value;
        sendRequest(url,"","POST",request);
        var result = request.responseText;
        if(result == "success")
        {
            alert("删除成功！");
            document.location="CuPan.aspx";
        }
        else
        {
            alert("删除失败！");
        }
    } 
    else 
    { 
        return false;
    }
}

//放开已盘单
function fangkaiPDD(PDDH)
{
    var txtPDDH = document.getElementById("txtPDDH");
    var txtDJZT = document.getElementById("txtDJZT");
    if (confirm("是否取消已盘状态？")) 
    { 
        var request=getXmlHttpRequest();
        var url="AjaxLogic.aspx?TYPE=2&PDDH="+txtPDDH.value;
        sendRequest(url,"","POST",request);
        var result = request.responseText;
        if(result == "success")
        {
            alert("取消成功！");
            txtDJZT.value = "在盘";
        }
        else
        {
            alert("取消失败！");
        }
    } 
    else 
    { 
        return false;
    }
}

//删除抽盘单
function DeleteXPD(PDDH)
{
    var txtPDDH = document.getElementById("txtPDDH");
    var grdInfo = document.getElementById("grdInfo");
    var ListBox1 = document.getElementById("ListBox1");
    var ListBox2 = document.getElementById("ListBox2");
    var txtYSDH = document.getElementById("txtYSDH");
    var txtCK = document.getElementById("txtCK");
    var hidCKID = document.getElementById("hidCKID");
    var txtPDRQ = document.getElementById("txtPDRQ");
    var txtZDRY= document.getElementById("txtZDRY");
    var txtDJZT=document.getElementById("txtDJZT");
    var txtZDRQ=document.getElementById("txtZDRQ");    
    var txtSHRY=document.getElementById("txtSHRY");
    var txtSHRQ=document.getElementById("txtSHRQ");
    var hidDJLX=document.getElementById("hidDJLX");
    if (confirm("是否真的要删除该单据吗？")) 
    { 
        var request=getXmlHttpRequest();
        var url="AjaxLogic.aspx?TYPE=3&PDDH="+txtPDDH.value;
        sendRequest(url,"","POST",request);
        var result = request.responseText;
        if(result == "success")
        {
            alert("删除成功！");
            document.location="ChouPan.aspx";
        }
        else
        {
            alert("删除失败！");
        }
    } 
    else 
    { 
        return false;
    }
}


//打开查看盘点单信息页面
function OpenlookPDDinfoWindow()
{
    var hidYSDH = document.getElementById("hidYSDH");
    var width=100;
	var height=100;
    var str = "height=" +200; 
	str += ",width=" + 300; 
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
	var url="lookPDDinfo.aspx?YSDH="+hidYSDH.value;
    window.open(url,'lookPDDinfo',str);
}


function OpenCuoweiWLpage()
{
    var txtYSDH = document.getElementById("txtYSDH");
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?TYPE=4&YSDH="+txtYSDH.value+"&PDDH=0";
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result == "DonePDRK")
    {
        alert("该盘点单已经处理过盘盈入库");
        return;
    }
    else
    {
        var width=100;
	    var height=100;
        var str = "height=" +200; 
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
	    var url="CuoweiWL.aspx?YSDH="+txtYSDH.value;
        window.open(url,'CuoweiWL',str);
    }
}


function shenhe()
{
    var txtYSDH = document.getElementById("txtYSDH");
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?TYPE=5&YSDH="+txtYSDH.value+"&PDDH=0";
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result == "NoRole")
    {
        alert("您没有审核权限");
        return;
    }
    if(result == "yipan")
    {
        alert("该单据已经被审核，不能再进行审核");
        return;
    }
    if(result == "bucunzai")
    {
        alert("原始单号不存在！");
        txtYSDH.focus();
        return;
    }
    if (confirm("是否审核该盘点单据？")) 
    { 
        if(result=="daipan")
        {
            if (confirm("该盘点单在RF系统尚未进行过盘点,是否审核？")) 
            {
                    var request2=getXmlHttpRequest();
                    var url2="AjaxLogic.aspx?TYPE=6&YSDH="+txtYSDH.value+"&PDDH=0";
                    sendRequest(url2,"","POST",request2);
                    var result2 = request2.responseText;
                    if(result2=="success")
                    {
                        alert("审核成功");
                    }
                    else
                    {
                        alert(result2);
                        return;
                    }
            }
            else
            {
                return false;
            }
        }
    } 
    else 
    { 
        return false;
    }
}


function KCadjust()
{
    var str = "height=300, width=810, top=200, left=200, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no";
    var txtYSDH = document.getElementById("txtYSDH");
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?TYPE=7&YSDH="+txtYSDH.value+"&PDDH=0";
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result == "NoRole")
    {
        alert("您没有调整库存的权限");
        return;
    }
    if(result=="bucunzai")
    {
        alert("没有可调整的单据");
        return;
    }
    if(result != "DJZTOK")
    {
        alert("只有审核过的单据才能进行库存调整");
        return;
    }
    var url="KCadjust.aspx?YSDH="+txtYSDH.value;
    window.open(url,'KCadjust',str);
}


function KCadjustPYRK()
{
    var hidYSDH = document.getElementById("hidYSDH");
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?TYPE=10&YSDH="+hidYSDH.value+"&PDDH=0";
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result == "fail1")
    {
        alert("生成盘盈入库单时发生错误");
        return;
    }
    if(result == "pyrkbzNot0")
    {    
        var str = "height=250, width=650, top=200, left=200, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no";
        var url="KCadjustPYRK.aspx?YSDH="+hidYSDH.value;
        window.open(url,'KCadjustPYRK',str);
    }
}

//盘亏出库
function PKCK()
{
    var hidYSDH = document.getElementById("hidYSDH");
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?TYPE=8&YSDH="+hidYSDH.value+"&PDDH=0";
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result == "PKCKed")
    {
        alert("该单据已经进行过盘亏出库处理，不能重复操作");
        return;
    }
    else
    {
        if (confirm("确实要进行盘亏出库处理吗？")) 
        {
                var request2=getXmlHttpRequest();
                var url2="AjaxLogic.aspx?TYPE=9&YSDH="+hidYSDH.value+"&PDDH=0";
                sendRequest(url2,"","POST",request2);
                var result2 = request2.responseText;
                if(result2=="fail")
                {
                    alert("盘亏出库过程发生错误");
                    return;   
                }
                else
                {
                    alert("盘亏出库成功完成，如果尚未进行盘盈入库，请进行盘盈入库操作");
                    return;
                }
        }
        else
        {
            return false;
        }
    }
}


function xiugaiHW()
{
    var hidYSDH = document.getElementById("hidYSDH");
    var hidbarcode = document.getElementById("hidbarcode");
    var hidpch = document.getElementById("hidpch");
    var hidsx = document.getElementById("hidsx");
    var hidck = document.getElementById("hidck");
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?TYPE=11&YSDH="+hidYSDH.value;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result == "PyrkbzIs2")
    {
        alert("该盘点单已经处理过盘盈入库，不能修改货位");
        return;
    }
    if(hidbarcode.value=="")
    {
        alert("没有需要调整的货位");
        return;
    }
    var str = "height=200, width=400, top=200, left=200, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no";
    var url="selhw.aspx?YSDH="+hidYSDH.value+"&barcode="+hidbarcode.value+"&pch="+hidpch.value+"&sx="+encodeURI(hidsx.value)+"&ck="+hidck.value;
    window.open(url,'KCadjustPYRK',str);
}


function HWisOK()
{
    var hidYSDH = document.getElementById("hidYSDH");
    var drpHW = document.getElementById("drpHW");
    var hidbarcode = document.getElementById("hidbarcode");
    var hidpch = document.getElementById("hidpch");
    var hidsx = document.getElementById("hidsx");
    var hidck = document.getElementById("hidck");
    if(drpHW.value==""||drpHW.value=="请选择")
    {
        alert("请选择货位");
        return;
    }    
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?TYPE=12&YSDH="+hidYSDH.value+"&PDDH=0&barcode="+hidbarcode.value+"&pch="+hidpch.value+"&sx="+encodeURI(hidsx.value)+"&ck="+hidck.value+"&drpHW="+drpHW.value;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result != "HWisOK")
    {
        alert("该货位已存放其他属性的物料,请重新选择货位");
        return;
    }
    else
    {
        var request2=getXmlHttpRequest();
        var url2="AjaxLogic.aspx?TYPE=13&YSDH="+hidYSDH.value+"&PDDH=0&barcode="+hidbarcode.value+"&pch="+hidpch.value+"&sx="+encodeURI(hidsx.value)+"&ck="+hidck.value+"&drpHW="+drpHW.value;
        sendRequest(url2,"","POST",request2);
        var result2 = request2.responseText;
        if(result2 == "success")
        {
            window.opener.document.location="KCadjustPYRK.aspx?YSDH="+hidYSDH.value+"&barcode="+hidbarcode.value+"&pch="+hidpch.value+"&sx="+encodeURI(hidsx.value)+"&ck="+hidck.value+"&HW=HWxiugaiOK";
            window.close();
        }
    }
}


function SetPYRK()
{
    var hidbarcode = document.getElementById("hidbarcode");
    var hidpch = document.getElementById("hidpch");
    var hidsx = document.getElementById("hidsx");
    var e = event.srcElement;
    var td = e.parentNode;
    var tr=td.parentNode;
    var table=tr.parentNode;
    var inputs=table.all.tags("INPUT");
    for(var i=0;i<inputs.length;i++)
    {
        if(inputs[i].type == "checkbox")
        {
            inputs[i].checked=false;
        }
    }
    e.checked=true;
    var tds=tr.all.tags("td");
    hidbarcode.value=tds[1].innerText;
    hidpch.value=tds[3].innerText;
    hidsx.value=tds[6].innerText;
}



function chooseCK()
{
    var drpCK = document.getElementById("drpCK");
    var txtYSDH = document.getElementById("txtYSDH");
    var txtPDRQ = document.getElementById("txtPDRQ");
    var txtDJZT = document.getElementById("txtDJZT");
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?TYPE=14&YSDH="+txtYSDH.value+"&PDDH=0";
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result!="fail")
    {
        txtYSDH.value = result.split(",")[0];
        drpCK.options.value = result.split(",")[1];
        txtPDRQ.value = result.split(",")[2];
        txtDJZT.value = result.split(",")[3];
    }
}


function PrintPDCY()
{
    var hidYSDH = document.getElementById("hidYSDH");
    window.open("PrintPDCY.aspx?YSDH="+hidYSDH.value);
}

function PrintPYRK()
{
    var hidYSDH = document.getElementById("hidYSDH");
    window.open("PrintPYRK.aspx?YSDH="+hidYSDH.value);
}









//function GoOK()
//{
//    var lst2 = document.getElementById("ListBox2");
//    var hidHW2List = document.getElementById("hidHW2List");
//    var HW2 = "";
//    for(var i = 0;i<= lst2.options.length-1;i++)
//    {
//        HW2 += lst2.options[i].value+",";
//    }
//    HW2 = HW2.substring(0,HW2.length-1);
//    hidHW2List.value = HW2;
//}

////将ListBox1的项移到ListBox2
//function GotoLst2()
//{
//    var hidHW2List = document.getElementById("hidHW2List");
//    var lst1=window.document.getElementById("ListBox1");
//    var lstindex=lst1.selectedIndex;
//    if(lstindex<0)
//        return;
//    var v = lst1.options[lstindex].value;
//    var t = lst1.options[lstindex].text;
//    var lst2=window.document.getElementById("ListBox2");
//    lst2.options[lst2.options.length] = new Option(t,v,true,true);
//    DelLst1();
////    if(lst1.options.length>=0)
////    {
////        ///不知道怎么把焦点置回HW1
////    }
//}

////将ListBox1的项移到ListBox2
//function GotoLst1()
//{
//    var lst2=window.document.getElementById("ListBox2");
//    var lstindex=lst2.selectedIndex;
//    if(lstindex<0)
//        return;
//    var v = lst2.options[lstindex].value;
//    var t = lst2.options[lstindex].text;
//    var lst1=window.document.getElementById("ListBox1");
//    lst1.options[lst1.options.length] = new Option(t,v,true,true);
//    DelLst2();
//}

////删除从ListBox1移到ListBox2的项
//function DelLst1()
//{
//    var lst1=window.document.getElementById("ListBox1");
//    var lstindex=lst1.selectedIndex;
//    if(lstindex>=0)
//    {
//        var v = lst1.options[lstindex].value+";";
//        lst1.options[lstindex].parentNode.removeChild(lst1.options[lstindex]);
//    }
//}

////删除从ListBox2移到ListBox1的项
//function DelLst2()
//{
//    var lst2=window.document.getElementById("ListBox2");
//    var lstindex=lst2.selectedIndex;
//    if(lstindex>=0)
//    {
//        var v = lst2.options[lstindex].value+";";
//        lst2.options[lstindex].parentNode.removeChild(lst2.options[lstindex]);
//    }
//}


function SavePDD()
{
    var YSDH = document.getElementById("txtYSDH");
    var PDDH = document.getElementById("txtPDDH");
    var CKID = document.getElementById("hidCKID");
    var PDRQ = document.getElementById("txtPDRQ");
    var ZDRQ = document.getElementById("txtZDRQ");
    var ZDRY = document.getElementById("txtZDRY");
    var lst2 = document.getElementById("ListBox2");
    var hidHW2List = document.getElementById("hidHW2List");
    var HW2 = "";
    for(var i = 0;i<= lst2.options.length-1;i++)
    {
        HW2 += lst2.options[i].value+",";
    }
    HW2 = HW2.substring(0,HW2.length-1);
    hidHW2List.value = HW2;
    var request=getXmlHttpRequest();
    var url="AjaxLogic.aspx?YSDH="+YSDH.value+"&PDDH="+PDDH.value+"&CKID="+CKID.value+"&PDRQ="+PDRQ.value+"&ZDRQ="+ZDRQ.value+"&ZDRY="+ZDRY.value+"&HW2="+HW2;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result=="success")
    {
        alert("保存成功！");
    }
    else
    {
        alert("保存失败！请重试！");
    }
}

//打印粗盘单
function OpenPrintCP()
{
    var txtPDDH = document.getElementById("txtPDDH");
    if(txtPDDH.value != "")
    {
        window.open("PrintCPD.aspx?PDDH="+txtPDDH.value,"","toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes");
    }
    else
    {
        alert("未选择盘点单号");
        return;
    }
}

//打印抽盘单
function OpenPrintXP()
{
    var txtPDDH = document.getElementById("txtPDDH");
    if(txtPDDH.value != "")
    {
        window.open("PrintXPD.aspx?PDDH="+txtPDDH.value,"","toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes");
    }
    else
    {
        alert("未选择盘点单号");
        return;
    }
}

//打印盘点单上传界面的盘点差异表
function OpenPrintPDCYB()
{
    var hidYSDH = document.getElementById("hidYSDH");
    var hidCKID = document.getElementById("hidCKID");
    if(hidYSDH.value != "")
    {
        window.open("PrintPDCYB.aspx?YSDH="+hidYSDH.value+"&CKID="+hidCKID.value,"","toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes");
    }
    else
    {
        alert("未选择原始单号");
        return;
    }
}