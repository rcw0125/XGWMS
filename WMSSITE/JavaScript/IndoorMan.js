// JScript 文件
//徐慧杰

//根据ICID获取ICNumber、车牌号、客户类别等信息
function getICNumber()
{
    if( event.keyCode == 13) 
    { 
        document.getElementById("hidICID").value = document.all.txtICID.value;
        var request=getXmlHttpRequest();
        var url="getICNumber.aspx?icid="+document.all.txtICID.value;
        sendRequest(url,"","POST",request);
        var result = request.responseText;
        if(result==null||result=="")
        {
            document.getElementById("txtICID").value="";        
            window.alert("该IC卡ID不存在！");
            document.getElementById("txtICID").focus();
            return;
        }
        else
        {
            document.getElementById("txtICNumber").innerText=result.split(",")[0];
            document.getElementById("hidICNumber").value=result.split(",")[0];
            document.getElementById("hidKHLB").value=result.split(",")[2];
            if(document.getElementById("hidKHLB").value=="0")
            {
                document.getElementById("txtCPH").innerText=result.split(",")[1];
                document.getElementById("hidCheckCPH").value=result.split(",")[1];
                document.getElementById("txtCPH").readOnly = true;
                document.getElementById("hidVisable").value="true";
                document.getElementById("txtPassword").focus();
                event.keyCode = 34;
                
            }
            else
            {
                document.getElementById("txtCPH").readOnly = false;
                document.getElementById("hidVisable").value="false";
                document.getElementById("txtCPH").value = "";
                document.getElementById("txtCPH").focus();
                event.keyCode = 34;
            }
        }
    }
}

//刷卡后获取信息并将焦点置到密码框
function enterkey() 
{ 
    if( event.keyCode == 13) 
    { 
        event.keyCode = 9;
        getICNumber();
        document.getElementById("txtCPH").focus();
    }
} 

function enterCPH() 
{ 
    if( event.keyCode == 13) 
    { 
        event.keyCode = 9;
    }
} 


//根据选择的发运单获取相关信息(进门)
function SetFYD()
{
    var CKDH = document.getElementById("hidCKDH");
    var FYDH = document.getElementById("hidCValue");
    var CPH = document.getElementById("hidCPH");
    var CK = document.getElementById("hidCK");
    var WLH = document.getElementById("hidWLH");
    var SX = document.getElementById("hidSX");
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
    FYDH.value=tds[1].innerText;
    CPH.value=tds[3].innerText;
    CK.value=tds[5].innerText;
    SX.value=tds[7].innerText;
    var inputs2=tr.all.tags("INPUT");
    CKDH.value = inputs2[2].value;
    WLH.value= inputs2[3].value;
}
function closeDiv( menuId)
{
	if ( (menu = document.getElementById(menuId)) != null )
	{
		menu.style.display="none";
    }
    return( true);
}
//根据选择的发运单获取相关信息(出门)
function SetFYD2()
{
    var FYDH = document.getElementById("hidCValue");
    var CPH = document.getElementById("hidCPH");
    var CK = document.getElementById("hidCK");
    var WLH = document.getElementById("hidWLH");
    var SX = document.getElementById("hidSX");
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
    FYDH.value=tds[1].innerText;
    CPH.value=tds[3].innerText;
    CK.value=tds[5].innerText;
    SX.value=tds[8].innerText;
    var inputs2=tr.all.tags("INPUT");
    WLH.value= inputs2[2].value;
    
    
    
    
}
function SetFYD3()
{
    var FYDH = document.getElementById("hidCValue");
    var CPH = document.getElementById("hidCPH");
    var CK = document.getElementById("hidCK");
    var WLH = document.getElementById("hidWLH");
    var SX = document.getElementById("hidSX");
    var e = event.srcElement;
    var td = e.parentNode;
    var tr=td.parentNode;
    var table=tr.parentNode;
    var inputs=table.all.tags("INPUT");
    
    FYDH.value="";
    var fydhlist="";
    var trs=table.all.tags("tr");
    
    for(var i=1;i<trs.length;i++)
    {
        var inputss=trs[i].all.tags("INPUT");
        if (inputss[0].type=="checkbox") {
           if (inputss[0].checked) {
              var tdss=trs[i].all.tags("td");
              var strFYDH=tdss[1].innerText;
              fydhlist=fydhlist+strFYDH+",";
           }
           
           
        }
    }
    if (fydhlist!="") {
       fydhlist=fydhlist.substring(0,fydhlist.length-1);
    }  
    FYDH.value=fydhlist;
    
    var tds=tr.all.tags("td");
    //FYDH.value=tds[1].innerText;
    CPH.value=tds[3].innerText;
    CK.value=tds[5].innerText;
    SX.value=tds[8].innerText;
    var inputs2=tr.all.tags("INPUT");
    WLH.value= inputs2[2].value;
    
    
    
    
}
function zhqr() {
   var FYDH = document.getElementById("hidCValue");
   if (FYDH.value=="") {
      alert("请选择发运单！");
      return;
   }
   var request=getXmlHttpRequest();
    var url="../CheckQu/LogincAjax.aspx?TYPE=39&fydh="+FYDH.value;
    var txtCXH=document.getElementById("txtCXH");
    txtCXH.value="";
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if (result!="") {
       alert(result);
        //e.checked=false;
    }
    else
    {
       displayDiv('popbox');
    }
}
function displayDiv(menuId)
{	
    var hidFYDHitem=document.getElementById("hidCValue");//发送单号
    if(hidFYDHitem.value==null || hidFYDHitem.value.length==0)
    {
        alert("请选择要进行装货确认的发运单！");
        //return;
    }
    
	var e = window.event;
	var menu = document.getElementById(menuId);
    menu.style.filter="alpha(opacity=0)";
	adjustPosition(e, menu);
	displayLater(menuId);
}
function displayLater( menuId)
{
	document.getElementById(menuId).style.filter="alpha(opacity=100)";
}
function adjustPosition(e, element)
{
	wnd_height=document.body.clientHeight;
	wnd_width=document.body.clientWidth;
	tooltip_width =(element.style.pixelWidth) ? element.style.pixelWidth  : element.offsetWidth;
	tooltip_height=(element.style.pixelHeight)? element.style.pixelHeight : element.offsetHeight;
	offset_y = (e.clientY + tooltip_height - document.body.scrollTop + 30 >= wnd_height) ? - 5 - tooltip_height: 5;
//	element.style.left = Math.min(wnd_width - tooltip_width - 5 , Math.max(3, e.clientX + 6)) + document.body.scrollLeft + 'px';
//	element.style.top = e.clientY + offset_y + document.body.scrollTop + 'px';
    element.style.left=document.body.clientWidth/2-150;
    element.style.top=document.body.clientHeight/2+100;
	element.style.display = "block";
}
//（发运单查询页面）根据选择的发运单获取相关信息
function SetCheckFYD()
{
    var FYDH = document.getElementById("hidCheckFYDSlc");
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
    FYDH.value=tds[1].innerText;
}

function ModifyPage()
{
    window.open('ModifyPassword.aspx', 'ModifyPassword', 'height=300, width=400, top=300, left=300, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
}

//验证车牌号输入框只读属性
function InitVisiable()
{
    var isReadly=document.getElementById("hidVisable").value;
    if(isReadly=="true")
    {
        document.getElementById("txtCPH").readOnly = true;
    }
    else
    {
        document.getElementById("txtCPH").readOnly = false;
    }
}

function CheckFYD()
{
     window.open('CheckFYD.aspx', 'CheckFYD', 'height=600, width=800, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=yes,location=no, status=no');
}

function CloseCheckFYD()
{
    window.close();
}

function openPrintPage()
{
    var FYDH = document.getElementById('hidCValue').value;
    var CKDH = document.getElementById('hidCKDH').value;
    var CK = document.getElementById('hidCK').value;
    var WLH = document.getElementById('hidWLH').value;
    var SX = document.getElementById('hidSX').value;
    window.open('PrintTHXP.aspx?fydh='+FYDH+'&ckdh='+CKDH+'&ck='+CK+'&wlh='+WLH+'&sx='+SX);
}

function PrintFYD()
{
    var hidFYDH = document.getElementById('hidFYDH');
    var hidCPH = document.getElementById('hidCPH');
    var hidCZ_User = document.getElementById('hidCZ_User');
    var hidInOt = document.getElementById('hidInOt');
    var hidStatus = document.getElementById('hidStatus');
    var hidRQStart = document.getElementById('hidRQStart');
    var hidRQEnd = document.getElementById('hidRQEnd');
      window.open("PrintIndoorFYD.aspx?FYDH="+hidFYDH.value+"&CPH="+encodeURI(hidCPH.value)+"&CZ_User="+encodeURI(hidCZ_User.value)+"&InOt="+encodeURI(hidInOt.value)+"&Status="+hidStatus.value+"&RQStart="+hidRQStart.value+"&RQEnd="+hidRQEnd.value,"","toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes");
}