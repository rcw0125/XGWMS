// JScript 文件
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

//初始化显示
function InitLoad()
{
    var tblQuery=document.getElementById("tblQuery");
    var tblConfig=document.getElementById("tblconfig");
    var hidQuery=document.getElementById("hidQuery");
    var hidConfig=document.getElementById("hidConfig");
    var imgBtnQuery=document.getElementById("btnQuery");
    var imgBtnConfig=document.getElementById("imgBtnconfig");
    
    if(hidQuery.value!="" && hidQuery.value.length>0)
    {
        if(hidQuery.value=="no")
        {
            imgBtnQuery.alt="展开";
            imgBtnQuery.src="../../images/icon/expand.gif";
            tblQuery.style.display="none";
        }
        else
        {
            imgBtnQuery.alt="关闭";
            imgBtnQuery.src="../../images/icon/collapse.gif";
            tblQuery.style.display="block";
        }
    }
    else
    {
        imgBtnQuery.alt="关闭";
        imgBtnQuery.src="../../images/icon/collapse.gif";
        tblQuery.style.display="block";
    }
    if(hidConfig.value!="" && hidConfig.value.length>0)
    {
        if(hidConfig.value=="no")
        {
            imgBtnConfig.alt="展开";
            imgBtnConfig.src="../../images/icon/expand.gif";
            tblConfig.style.display ="none";
        }
        else
        {
            imgBtnConfig.alt="关闭";
            imgBtnConfig.src="../../images/icon/collapse.gif";
            tblConfig.style.display ="block";
        }
    }
    else
    {
        imgBtnConfig.alt="展开";
        imgBtnConfig.src="../../images/icon/expand.gif";
        tblConfig.style.display="none";
    }
}

/*显示或者隐藏查询条件*/
function AddQuery()
{
    var btnQuery = document.getElementById("btnQuery");
	var tblQuery= document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
	if(tblQuery.style.display == "block")
	{
		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		tblQuery.style.display = "none";
		hidQuery.value= "no";
	}
	else
	{
		btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
		tblQuery.style.display = "block";
		hidQuery.value = "yes";
	}	
}
/*显示或者隐藏列表配置*/
function AddConfig()
{
    var imgBtnconfig = document.getElementById("imgBtnconfig");
	var tblconfig= document.getElementById("tblconfig");
	var hidConfig = document.getElementById("hidConfig");
	if(tblconfig.style.display == "block")
	{
		imgBtnconfig.src = "../../images/icon/expand.gif";
		imgBtnconfig.alt = "展开";
		tblconfig.style.display = "none";
		hidConfig.value= "no";
	}
	else
	{
		imgBtnconfig.src = "../../images/icon/collapse.gif";
		imgBtnconfig.alt = "关闭";
		tblconfig.style.display = "block";
		hidConfig.value = "yes";
	}	
}

//打开客户选择框
function OpenKHWindow()
{
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
	var url="../../Common/SearchKH.aspx";
    window.open(url,'liangliang',str);
}
//获取绝对路径
function GetAbsoluteLocation(element) 
{
     if ( element == null ) 
     { 
        return null; 
     }
    var offsetTop = element.offsetTop; 
    var offsetLeft = element.offsetLeft; 
    while( element = element.offsetParent ) 
    {
         offsetTop += element.offsetTop; 
         offsetLeft += element.offsetLeft; 
    } 
    return offsetLeft+','+offsetTop; 
}

//得到客户编码
function GetKHBM()
{
    var e = event.srcElement;
    var tr = e.parentNode.parentNode;
    var tds=tr.all.tags("td");
    var txtKHBM=window.opener.document.getElementById("txtKH");
    txtKHBM.value=tds[1].innerText;
    window.close();
}

/*点击全选或全不选操作，例如列表屏蔽列的时候使用ControlSetHeard.ascx*/
function check(obj)
{
	var e = event.srcElement;
	var table = e.parentNode.parentNode.parentNode.parentNode;
	var row = table.all.tags("tr");
	var row1 = row[1];
	var texts = row1.all.tags("INPUT")
	if(texts.length == 0)
		return;
	for(var i = 0; i < texts.length;i++)
	{
		texts[i].checked = obj.checked;	
	}
}

//打印发运单
function PrintFYD()
{
    var e = event.srcElement;
    var td=e.parentNode;
    var inputs=td.all.tags("INPUT");
    var fydh=inputs[0].value;
    var cph=inputs[1].value;
    var fylx=inputs[2].value;
    var khname=inputs[3].value;
    var url="PrintFYDDetail.aspx?FYDH="+fydh+"&CPH="+cph+"&KHNAME="+encodeURI(khname)+"&TYPE="+fylx;
    window.open(url,"","toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes");
}

//打印预览日报表
function OpenPrint()
{
    var store=document.getElementById("drpStore");
    if(store.value=="0")
    {
        window.alert("请选择仓库！");
        return;
    }
    var date=document.getElementById("txtTime");
    window.open("DayReport.aspx?STORE="+store.value+"&DATE="+date.value,"","toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes");
}

