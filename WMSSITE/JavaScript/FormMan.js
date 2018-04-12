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

//选中PCH复选框时运行的操作
function GetPCH()
{
    var hidPCH=document.getElementById("hidPCH");
    var chkPCH=document.getElementById("chkPCH");
    var drpPCH=document.getElementById("drpPCH");
    if(chkPCH.checked)
    {
        //已经加载过
        if(drpPCH.options.length>0)
        {
            if(hidPCH.value!=""&&hidPCH.value.length>0)
            {
                drpPCH.text=hidPCH.value;
            }
            return;
        }
        if(LoadPCH())
        {
            if(hidPCH.value!=""&&hidPCH.value.length>0)
            {
                drpPCH.text=hidPCH.value;
            }
            return;
        }
    }
    else
    {
        hidPCH.value="";
        if(drpPCH.options!=null)
        {
            drpPCH.options.length = 0;
        }
        drpPCH.text="";
        drpPCH.value="";
    }
    //重新加载特殊信息
    LoadTSXX();
    GetTSXX();
}
//Load批次号
function LoadPCH()
{
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=1";
    var drpPCH=document.getElementById("drpPCH");
    drpPCH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        ClearPCH();
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/PCH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpPCH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpPCH.options.add(newOption); 
　	　	}
　	　	drpPCH.text="请选择";
　	　	return true;
    }
}
//清空批次号下拉框
function ClearPCH()
{
    var drpPCH=document.getElementById("drpPCH");
    if(drpPCH.options!=null)
    {
	    for(var i = 0;i<=drpPCH.options.length -1;i++)
	    {
　　	    drpPCH.remove(i);
　　    }
　　}
}
//改变批次号时保留选中的批次号信息
function ChangePCH()
{
    var drpPCH=document.getElementById("drpPCH");
    var hidPCH=document.getElementById("hidPCH");
    var chkTSXX=document.getElementById("chkTSXX");
    if(chkTSXX.checked)
    {
        LoadTSXX();
    }
    if(drpPCH.value!="" && drpPCH.value.length>0)
    {
        hidPCH.value=drpPCH.value;
    }
    if(drpPCH.value=="" || drpPCH.value.length==0)
        hidPCH.value="";
}
//页面加载时需要运行的代码
function LoapQuWGD()
{
    //加载批次号
    var hidPCH=document.getElementById("hidPCH");
    var chkPCH=document.getElementById("chkPCH");
    if(hidPCH.value!=null && hidPCH.value!="" && hidPCH.value.length>0)
    {
        chkPCH.checked=true;
        GetPCH();//选中上次选中的项
    }
    //加载特殊信息
    var hidTSXX=document.getElementById("hidTSXX");
    var chkTSXX=document.getElementById("chkTSXX");
    if(hidTSXX.value!=null && hidTSXX.value!="" && hidTSXX.value.length>0)
    {
        chkTSXX.checked=true;
        GetTSXX();//选中上次选中的项
    }
    //加载批次类型
    var hidPLX=document.getElementById("hidPLX");
    var chkPLX=document.getElementById("chkPLX");
    if(hidPLX.value!=null && hidPLX.value!="" && hidPLX.value.length>0)
    {
        chkPLX.checked=true;
        GetPLX();//选中上次选中的项
    }
    
    //加载批次属性
    var hidPCSX=document.getElementById("hidPCSX");
    var chkPCSX=document.getElementById("chkPCSX");
    if(hidPCSX.value!=null && hidPCSX.value!="" && hidPCSX.value.length>0)
    {
        chkPCSX.checked=true;
        GetPCSX();//选中上次选中的项
    }
    //加载物料号
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    if(hidWLH.value!=null && hidWLH.value!="" && hidWLH.value.length>0)
    {
        chkWLH.checked=true;
        GetWLH();//选中上次选中的项
    }
    //加载生产线
    var hidSCX=document.getElementById("hidSCX");
    var chkSCX=document.getElementById("chkSCX");
    if(hidSCX.value!=null && hidSCX.value!="" && hidSCX.value.length>0)
    {
        chkSCX.checked=true;
        GetSCX();//选中上次选中的项
    }
    //加载状态（完成标志）
    var hidWCBZ=document.getElementById("hidWCBZ");
    var chkWCBZ=document.getElementById("chkWCBZ");
    if(hidWCBZ.value!=null && hidWCBZ.value!="" && hidWCBZ.value.length>0)
    {
        chkWCBZ.checked=true;
        GetWCBZ();//选中上次选中的项
    }
    //加载牌号
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    if(hidPH.value!=null && hidPH.value!="" && hidPH.value.length>0)
    {
        chkPH.checked=true;
        GetPH();//选中上次选中的项
    }
    //加载规格
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    if(hidGG.value!=null && hidGG.value!="" && hidGG.value.length>0)
    {
        chkGG.checked=true;
        GetGG();//选中上次选中的项
    }
    //加载完工单号
    var hidWGDH=document.getElementById("hidWGDH");
    var chkWGDH=document.getElementById("chkWGDH");
    if(hidWGDH.value!=null && hidWGDH.value!="" && hidWGDH.value.length>0)
    {
        chkWGDH.checked=true;
        GetWGDH();//选中上次选中的项
    }
    //加载待判品
    var hidDPP=document.getElementById("hidDPP");
    var chkDPP=document.getElementById("chkDPP");
    if(hidDPP.value!=null && hidDPP.value!="" && hidDPP.value.length>0)
    {
        chkDPP.checked=true;
        GetDPP();//选中上次选中的项
    }
    //加载待判品
    var hidZJR=document.getElementById("hidZJR");
    var chkZJR=document.getElementById("chkZJR");
    if(hidZJR.value!=null && hidZJR.value!="" && hidZJR.value.length>0)
    {
        chkZJR.checked=true;
        GetZJR();//选中上次选中的项
    }
    //加载自由项
    GetFree3();
    GetFree2();
    GetFree1();
}
//获取特殊信息查询条件
function GetTSXX()
{
    var hidTSXX=document.getElementById("hidTSXX");
    var chkTSXX=document.getElementById("chkTSXX");
    var drpTSXX=document.getElementById("drpTSXX");
    var chkPCH=document.getElementById("chkPCH");
    var drpPCH=document.getElementById("drpPCH");
    if(chkTSXX.checked)
    {
        //已经加载过
        if(drpTSXX.options.length>0)
        {
            if(hidTSXX.value!=""&&hidTSXX.value.length>0)
            {
                drpTSXX.value=hidTSXX.value;
            }
            return;
        }
        if(LoadTSXX())
        {
            if(hidTSXX.value!=""&&hidTSXX.value.length>0)
            {
                drpTSXX.value=hidTSXX.value;
            }
            return;
        }
    }
    else
    {
        hidTSXX.value="";
        drpTSXX.options.length = 0;
       // drpTSXX.disabled=true;
        if(drpTSXX.options!=null)
        {
            drpTSXX.options.length = 0;
        }
        drpTSXX.text="";
        drpTSXX.value="";
    }
}
//加载特殊信息
function LoadTSXX()
{
    //是否已经选择了批次号
    var request=getXmlHttpRequest();
    var pch="";
    var chkPCH=document.getElementById("chkPCH");
    var hidPCH=document.getElementById("hidPCH");
    if(chkPCH.checked)
    {
        var drpPCH=document.getElementById("drpPCH");
        if(drpPCH.value!="请选择")
        {
           pch=drpPCH.value;
        }
    }
    var url="LogincAjax.aspx?TYPE=2&PCH="+pch;
    var drpTSXX=document.getElementById("drpTSXX");
    drpTSXX.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        //ClearTSXX();
        drpTSXX.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/pcinfo");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpTSXX.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpTSXX.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空特殊信息
function ClearTSXX()
{
    var drpTSXX=document.getElementById("drpTSXX");
    if(drpTSXX.options!=null)
    {
	    for(var i = 0;i<=drpTSXX.options.length -1;i++)
	    {
　　	    drpTSXX.remove(i);
　　    }
　　}
}

//改变特殊信息时保留选中的特殊信息
function ChangeTSXX()
{
    var drpTSXX=document.getElementById("drpTSXX");
    var hidTSXX=document.getElementById("hidTSXX");
    if(drpTSXX.value!="请选择")
    {
        hidTSXX.value=drpTSXX.value;
    }
    if(drpTSXX.value=="请选择")
        hidTSXX.value="";
}

//得到批类型信息
function GetPLX()
{
    var hidPLX=document.getElementById("hidPLX");
    var chkPLX=document.getElementById("chkPLX");
    var drpPLX=document.getElementById("drpPLX");
    if(chkPLX.checked)
    {
        //已经加载过
        if(drpPLX.options.length>0)
        {
            if(hidPLX.value!=""&&hidPLX.value.length>0)
            {
                drpPLX.value=hidPLX.value;
            }
            return;
        }
        LoadPLX()
        if(hidPLX.value!=""&&hidPLX.value.length>0)
        {
            drpPLX.value=hidPLX.value;
        }
        return;
    }
    else
    {
        hidPLX.value="";
        drpPLX.options.length = 0;
        drpPLX.disabled=true;
    }
}
//生成批类型
function LoadPLX()
{
    var drpPLX=document.getElementById("drpPLX");
    drpPLX.disabled=false;
    drpPLX.options.length = 0;
    var varItem=new Option("请选择","-1");
    drpPLX.options.add(varItem); 
    var varItem=new Option("普通线材","0");
    drpPLX.options.add(varItem); 
    var varItem=new Option("出口线材","1");
    drpPLX.options.add(varItem); 
}
//改变批类型时保留选中的批次号信息
function ChangePLX()
{
    var drpPLX=document.getElementById("drpPLX");
    var hidPLX=document.getElementById("hidPLX");
    if(drpPLX.value!="请选择")
    {
        hidPLX.value=drpPLX.value;
    }
    if(drpPLX.value=="请选择")
        hidPLX.value="";
}

//选中PCSX复选框时运行的操作
function GetPCSX()
{
    var hidPCSX=document.getElementById("hidPCSX");
    var chkPCSX=document.getElementById("chkPCSX");
    var drpPCSX=document.getElementById("drpPCSX");
    if(chkPCSX.checked)
    {
        //已经加载过
        if(drpPCSX.options.length>0)
        {
            if(hidPCSX.value!=""&&hidPCSX.value.length>0)
            {
                drpPCSX.value=hidPCSX.value;
            }
            return;
        }
        if(LoadPCSX())
        {
            if(hidPCSX.value!=""&&hidPCSX.value.length>0)
            {
                drpPCSX.value=hidPCSX.value;
            }
            return;
        }
    }
    else
    {
        hidPCSX.value="";
        drpPCSX.options.length = 0;
        drpPCSX.disabled=true;
    }
}

//Load批次号
function LoadPCSX()
{
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=3";
    var drpPCSX=document.getElementById("drpPCSX");
    drpPCSX.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpPCSX.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/PCSX");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpPCSX.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpPCSX.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//改变批次属性时保留选中的批次号信息
function ChangePCSX()
{
    var drpPCSX=document.getElementById("drpPCSX");
    var hidPCSX=document.getElementById("hidPCSX");
    if(drpPCSX.value!="请选择")
    {
        hidPCSX.value=drpPCSX.value;
    }
    if(drpPCSX.value=="请选择")
        hidPCSX.value="";
}
//选中PCSX复选框时运行的操作
function GetWLH()
{
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    var drpWLH=document.getElementById("drpWLH");
    if(chkWLH.checked)
    {
        //已经加载过
        if(drpWLH.options.length>0)
        {
            if(hidWLH.value!=""&&hidWLH.value.length>0)
            {
                drpWLH.value=hidWLH.value;
            }
            return;
        }
        if(LoadWLH())
        {
           if(hidWLH.value!=""&&hidWLH.value.length>0)
            {
                drpWLH.value=hidWLH.value;
            }
            return;
        }
    }
    else
    {
        hidWLH.value="";
        if(drpWLH.options!=null)
        {
            drpWLH.options.length = 0;
        }
        drpWLH.disabled=true;
        drpWLH.text="";
    }
}

//Load物料号
function LoadWLH()
{
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=4";
    var drpWLH=document.getElementById("drpWLH");
    drpWLH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpWLH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/WLH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpWLH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpWLH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//改变物料号时保留选中的批次号信息
function ChangeWLH()
{
    var drpWLH=document.getElementById("drpWLH");
    var hidWLH=document.getElementById("hidWLH");
    if(drpWLH.value!="请选择")
    {
        hidWLH.value=drpWLH.value;
    }
    if(drpWLH.value=="请选择")
        hidWLH.value="";
}
//选中SCX复选框时运行的操作
function GetSCX()
{
    var hidSCX=document.getElementById("hidSCX");
    var chkSCX=document.getElementById("chkSCX");
    var drpSCX=document.getElementById("drpSCX");
    if(chkSCX.checked)
    {
        //已经加载过
        if(drpSCX.options.length>0)
        {
            if(hidSCX.value!=""&&hidSCX.value.length>0)
            {
                drpSCX.value=hidSCX.value;
            }
            return;
        }
        if(LoadSCX())
        {
           if(hidSCX.value!=""&&hidSCX.value.length>0)
            {
                drpSCX.value=hidSCX.value;
            }
            return;
        }
    }
    else
    {
        hidSCX.value="";
        drpSCX.options.length = 0;
        drpSCX.disabled=true;
    }
}

//Load生产线
function LoadSCX()
{
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=5";
    var drpSCX=document.getElementById("drpSCX");
    drpSCX.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpSCX.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/SCXBM");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpSCX.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpSCX.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//改变生产线时保留选中的批次号信息
function ChangeSCX()
{
    var drpSCX=document.getElementById("drpSCX");
    var hidSCX=document.getElementById("hidSCX");
    if(drpSCX.value!="请选择")
    {
        hidSCX.value=drpSCX.value;
    }
    if(drpSCX.value=="请选择")
        hidSCX.value="";
}

//得到状态信息（完成标志）
function GetWCBZ()
{
    var hidWCBZ=document.getElementById("hidWCBZ");
    var chkWCBZ=document.getElementById("chkWCBZ");
    var drpWCBZ=document.getElementById("drpWCBZ");
    if(chkWCBZ.checked)
    {
        //已经加载过
        if(drpWCBZ.options.length>0)
        {
            if(hidWCBZ.value!=""&&hidWCBZ.value.length>0)
            {
                drpWCBZ.value=hidWCBZ.value;
            }
            return;
        }
        LoadWCBZ()
        if(hidWCBZ.value!=""&&hidWCBZ.value.length>0)
        {
            drpWCBZ.value=hidWCBZ.value;
        }
        return;
    }
    else
    {
        hidWCBZ.value="";
        drpWCBZ.options.length = 0;
        drpWCBZ.disabled=true;
    }
}
//生成状态（完成标志）
function LoadWCBZ()
{
    var drpWCBZ=document.getElementById("drpWCBZ");
    drpWCBZ.disabled=false;
    drpWCBZ.options.length = 0;
    var varItem0=new Option("请选择","-1");
    drpWCBZ.options.add(varItem0); 
    var varItem1=new Option("未执行","0");
    drpWCBZ.options.add(varItem1); 
    var varItem2=new Option("正在打牌","1");
    drpWCBZ.options.add(varItem2); 
    var varItem3=new Option("打牌完毕","2");
    drpWCBZ.options.add(varItem3); 
    var varItem4=new Option("入库完成","3");
    drpWCBZ.options.add(varItem4); 
}
//改变状态（完成标志）时保留选中的批次号信息
function ChangeWCBZ()
{
    var drpWCBZ=document.getElementById("drpWCBZ");
    var hidWCBZ=document.getElementById("hidWCBZ");
    if(drpWCBZ.value!="请选择")
    {
        hidWCBZ.value=drpWCBZ.value;
    }
    if(drpWCBZ.value=="请选择")
        hidWCBZ.value="";
}
//选中PH复选框时运行的操作
function GetPH()
{
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    var drpPH=document.getElementById("drpPH");
    if(chkPH.checked)
    {
        //已经加载过
        if(drpPH.options.length>0)
        {
            if(hidPH.value!=""&&hidPH.value.length>0)
            {
                drpPH.value=hidPH.value;
            }
            return;
        }
        if(LoadPH())
        {
           if(hidPH.value!=""&&hidPH.value.length>0)
            {
                drpPH.value=hidPH.value;
            }
            return;
        }
    }
    else
    {
        hidPH.value="";
        if(drpPH.options!=null)
        {
            drpPH.options.length = 0;
        }
       // drpPH.disabled=true;
        drpPH.text="";
        drpPH.value="";
    }
}

//Load牌号
function LoadPH()
{
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=6";
    var drpPH=document.getElementById("drpPH");
    drpPH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpPH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/PH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpPH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpPH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//改变牌号时保留选中的批次号信息
function ChangePH()
{
    var drpPH=document.getElementById("drpPH");
    var hidPH=document.getElementById("hidPH");
    if(drpPH.value!="请选择")
    {
        hidPH.value=drpPH.value;
    }
    if(drpPH.value=="请选择")
        hidPH.value="";
}
//选中GG复选框时运行的操作
function GetGG()
{
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    var drpGG=document.getElementById("drpGG");
    if(chkGG.checked)
    {
        //已经加载过
        if(drpGG.options.length>0)
        {
            if(hidGG.value!=""&&hidGG.value.length>0)
            {
                drpGG.value=hidGG.value;
            }
            return;
        }
        if(LoadGG())
        {
           if(hidGG.value!=""&&hidGG.value.length>0)
            {
                drpGG.value=hidGG.value;
            }
            return;
        }
    }
    else
    {
        hidGG.value="";
        if(drpGG.options!=null)
        {
            drpGG.options.length = 0;
        }
        drpGG.disabled=true;
        drpGG.value="";
        drpGG.text="";
    }
}

//Load规格
function LoadGG()
{
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=7";
    var drpGG=document.getElementById("drpGG");
    drpGG.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpGG.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/GG");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpGG.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpGG.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//改变规格时保留选中的批次号信息
function ChangeGG()
{
    var drpGG=document.getElementById("drpGG");
    var hidGG=document.getElementById("hidGG");
    if(drpGG.value!="请选择")
    {
        hidGG.value=drpGG.value;
    }
    if(drpGG.value=="请选择")
        hidGG.value="";
}
//选中WGDH复选框时运行的操作
function GetWGDH()
{
    var hidWGDH=document.getElementById("hidWGDH");
    var chkWGDH=document.getElementById("chkWGDH");
    var drpWGDH=document.getElementById("drpWGDH");
    if(chkWGDH.checked)
    {
        //已经加载过
        if(drpWGDH.options.length>0)
        {
            if(hidWGDH.value!=""&&hidWGDH.value.length>0)
            {
                drpWGDH.value=hidWGDH.value;
            }
            return;
        }
        if(LoadWGDH())
        {
           if(hidWGDH.value!=""&&hidWGDH.value.length>0)
            {
                drpWGDH.value=hidWGDH.value;
            }
            return;
        }
    }
    else
    {
        hidWGDH.value="";
        if(drpWGDH.options!=null)
        {
            drpWGDH.options.length = 0;
        }
        //drpWGDH.disabled=true;
        drpWGDH.value="";
        drpWGDH.text="";
    }
}

//Load完工单号
function LoadWGDH()
{
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=8";
    var drpWGDH=document.getElementById("drpWGDH");
    drpWGDH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpWGDH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/WGDH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpWGDH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpWGDH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//改变完工单号时保留选中的批次号信息
function ChangeWGDH()
{
    var drpWGDH=document.getElementById("drpWGDH");
    var hidWGDH=document.getElementById("hidWGDH");
    if(drpWGDH.value!="请选择")
    {
        hidWGDH.value=drpWGDH.value;
    }
    if(drpWGDH.value=="请选择")
        hidWGDH.value="";
}

//待判品
function GetDPP()
{
    var hidDPP=document.getElementById("hidDPP");
    var chkDPP=document.getElementById("chkDPP");
    var drpDPP=document.getElementById("drpDPP");
    if(chkDPP.checked)
    {
        //已经加载过
        if(drpDPP.options.length>0)
        {
            if(hidDPP.value!=""&&hidDPP.value.length>0)
            {
                drpDPP.value=hidDPP.value;
            }
            return;
        }
        LoadDPP()
        if(hidDPP.value!=""&&hidDPP.value.length>0)
        {
            drpDPP.value=hidDPP.value;
        }
        return;
    }
    else
    {
        hidDPP.value="";
        drpDPP.options.length = 0;
        drpDPP.disabled=true;
    }
}
//待判品
function LoadDPP()
{
    var drpDPP=document.getElementById("drpDPP");
    drpDPP.disabled=false;
    drpDPP.options.length = 0;
    var varItem0=new Option("请选择","-1");
    drpDPP.options.add(varItem0); 
    var varItem1=new Option("未改判","0");
    drpDPP.options.add(varItem1); 
    var varItem2=new Option("已改判","1");
    drpDPP.options.add(varItem2); 
}
//待判品
function ChangeDPP()
{
    var drpDPP=document.getElementById("drpDPP");
    var hidDPP=document.getElementById("hidDPP");
    if(drpDPP.value!="请选择")
    {
        hidDPP.value=drpDPP.value;
    }
    if(drpDPP.value=="请选择")
        hidDPP.value="";
}

//选中ZJR复选框时运行的操作
function GetZJR()
{
    var hidZJR=document.getElementById("hidZJR");
    var chkZJR=document.getElementById("chkZJR");
    var drpZJR=document.getElementById("drpZJR");
    if(chkZJR.checked)
    {
        //已经加载过
        if(drpZJR.options.length>0)
        {
            if(hidZJR.value!=""&&hidZJR.value.length>0)
            {
                drpZJR.value=hidZJR.value;
            }
            return;
        }
        if(LoadZJR())
        {
           if(hidZJR.value!=""&&hidZJR.value.length>0)
            {
                drpZJR.value=hidZJR.value;
            }
            return;
        }
    }
    else
    {
        hidZJR.value="";
        drpZJR.options.length = 0;
        drpZJR.disabled=true;
    }
}

//Load质检人
function LoadZJR()
{
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=9";
    var drpZJR=document.getElementById("drpZJR");
    drpZJR.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpZJR.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/ZJR");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpZJR.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpZJR.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//改变质检人时保留选中的批次号信息
function ChangeZJR()
{
    var drpZJR=document.getElementById("drpZJR");
    var hidZJR=document.getElementById("hidZJR");
    if(drpZJR.value!="请选择")
    {
        hidZJR.value=drpZJR.value;
    }
    if(drpZJR.value=="请选择")
        hidZJR.value="";
}

/*显示或隐藏查询条件*/
function AddQuery() 
{
	var btnQuery = document.getElementById("btnQuery");
	var tblQuery = document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
	
	if(tblQuery.style.display == "block")
	{
		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		tblQuery.style.display = "none";
		hidQuery.value= "none";
	}
	else
	{
		btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
		tblQuery.style.display = "block";
		hidQuery.value = "block";
	}	
}

/*显示或者隐藏列表配置*/
function Addconfig() 
{
	var btnconfig = document.getElementById("btnconfig");
	var tblconfig = document.getElementById("tblconfig");
	if(tblconfig.style.display ==  "block")
	{
		btnconfig.src = "../../images/icon/expand.gif";
		btnconfig.alt = "展开";
		tblconfig.style.display = "none";
	}
	else
	{
		btnconfig.src = "../../images/icon/collapse.gif";
		btnconfig.alt = "关闭";
		tblconfig.style.display = "block";
	}
}
/*显示或者隐藏完工单明细*/
function AddItems()
{
    var btnItem = document.getElementById("btnItem");
	var tblPList= document.getElementById("tblPList");
	var hidItem = document.getElementById("hidItem");
	if(tblPList.style.display == "block")
	{
		btnItem.src = "../../images/icon/expand.gif";
		btnItem.alt = "展开";
		tblPList.style.display = "none";
		hidItem.value= "none";
	}
	else
	{
		btnItem.src = "../../images/icon/collapse.gif";
		btnItem.alt = "关闭";
		tblPList.style.display = "block";
		hidItem.value = "block";
	}	
}
/*页面初始化，完工单查询*/
function Init()
{
	var tblQuery = document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
	var btnQuery = document.getElementById("btnQuery");
	
    var tblconfig = document.getElementById("tblconfig");
    var btnconfig = document.getElementById("btnconfig");
    
    
    var tblPList= document.getElementById("tblPList");
	var hidItem = document.getElementById("hidItem");
	var btnItem = document.getElementById("btnItem");
	
	if(hidQuery.value!="")
	{
		tblQuery.style.display = hidQuery.value;
		if(hidQuery.value=="none")
		{
		    btnQuery.src = "../../images/icon/expand.gif";
		    btnQuery.alt = "展开";
		}
		else
		{
		    btnQuery.src = "../../images/icon/collapse.gif";
		    btnQuery.alt = "关闭";
		}
	}
	else
	{
	    tblQuery.style.display="block";
	    btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
	}
	
    tblconfig.style.display="none";
    btnconfig.src = "../../images/icon/expand.gif";
	btnconfig.alt = "展开";
	
	if(hidItem.value!="")
	{
		tblPList.style.display = hidItem.value;
		if(hidItem.value=="none")
		{
		    btnItem.src = "../../images/icon/expand.gif";
		    btnItem.alt = "展开";
		}
		else
		{
		    btnItem.src = "../../images/icon/collapse.gif";
		    btnItem.alt = "关闭";
		}
	}
	else
	{
	    tblPList.style.display="none";
	    btnItem.src = "../../images/icon/expand.gif";
		btnItem.alt = "展开";
	}
	
	var chkPTime = document.getElementById("chkPTime");
    var txtPSTime=document.getElementById("txtPStartTime");
    var txtPETime=document.getElementById("txtPEndTime");
    
    if(chkPTime.checked)
    {
        txtPSTime.disabled=false;
        txtPETime.disabled=false;
    }
    else
    {
        txtPSTime.disabled=true;
        txtPETime.disabled=true;
    }
    
    var chkRTime = document.getElementById("chkRTime");
    var txtRSTime=document.getElementById("txtRStartTime");
    var txtRETime=document.getElementById("txtREndTime");
    
    if(chkRTime.checked)
    {
        txtRSTime.disabled=false;
        txtRETime.disabled=false;
    }
    else
    {
        txtRSTime.disabled=true;
        txtRETime.disabled=true;
    }
    LoapQuWGD();
}

//察看完工单明细
function GetWGDItem()
{
    var iFrame=document.getElementById("frmList");
    var e = event.srcElement;
    var oldChose=e.checked;
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
    e.checked=oldChose;
    var tblPList= document.getElementById("tblPList");
	var btnItem = document.getElementById("btnItem");
	
	var tblQuery = document.getElementById("tblQuery");
    var btnQuery = document.getElementById("btnQuery");
    
    if(e.checked)
    {
        var tds=tr.all.tags("td");
        var strWGDH=tds[1].innerText;
        iFrame.src="WGDItems.aspx?WGDH="+strWGDH;
        
        
	    tblPList.style.display="block";
	    btnItem.src = "../../images/icon/collapse.gif";
        btnItem.alt = "关闭";
      
	    tblQuery.style.display="none";
	    btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
    }
    else
    {
        tblPList.style.display="none";
	    btnItem.src = "../../images/icon/expand.gif";
        btnItem.alt = "展开";
      
	    tblQuery.style.display="block";
	    btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
    }
}

//选中生产时间可用
function PTimeCan()
{
    var e = event.srcElement;
    var txtPSTime=document.getElementById("txtPStartTime");
    var txtPETime=document.getElementById("txtPEndTime");
    
    if(e.checked)
    {
        txtPSTime.disabled=false;
        txtPETime.disabled=false;
    }
    else
    {
        txtPSTime.disabled=true;
        txtPETime.disabled=true;
    }
}

//选中入库时间控件可用
function RTimeCan()
{
    var e = event.srcElement;
    var txtRSTime=document.getElementById("txtRStartTime");
    var txtRETime=document.getElementById("txtREndTime");
    
    if(e.checked)
    {
        txtRSTime.disabled=false;
        txtRETime.disabled=false;
    }
    else
    {
        txtRSTime.disabled=true;
        txtRETime.disabled=true;
    }
}

//选中自由项目时运行的操作
function GetFree1()
{
    var chkPCH=document.getElementById("chkFree1");
    var txtPCH=document.getElementById("txtFree1");
    if(chkPCH.checked)
    {
        txtPCH.disabled=false;
    }
    else
    {
        txtPCH.value="";
        txtPCH.disabled=true;
    }
}

////选中自由项目时运行的操作
function GetFree2()
{
    var chkPCH=document.getElementById("chkFree2");
    var txtPCH=document.getElementById("txtFree2");
    if(chkPCH.checked)
    {
        txtPCH.disabled=false;
    }
    else
    {
        txtPCH.value="";
        txtPCH.disabled=true;
    }
}
//选中自由项目时运行的操作
function GetFree3()
{
    var chkPCH=document.getElementById("chkFree3");
    var txtPCH=document.getElementById("txtFree3");
    if(chkPCH.checked)
    {
        txtPCH.disabled=false;
    }
    else
    {
        txtPCH.value="";
        txtPCH.disabled=true;
    }
}
