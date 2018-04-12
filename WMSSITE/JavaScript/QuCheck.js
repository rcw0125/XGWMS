// JScript 文件
function getId(objId){
    return document.getElementById(objId);
}
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
        
            if(hidPCH.value!=""&&hidPCH.value.length>0)
            {
                drpPCH.value=hidPCH.value;
            }
            return;
       
    }
    else
    {
        hidPCH.value="";
        
        drpPCH.disabled=true;
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
　	　	return true;
    }
}
//清空批次号下拉框
function ClearPCH()
{
    var drpPCH=document.getElementById("drpPCH");
	for(var i = 0;i<=drpPCH.options.length -1;i++)
	{
　　	drpPCH.remove(i);
　　}
}
//改变批次号时保留选中的批次号信息
function ChangePCH()
{
    var drpPCH=document.getElementById("drpPCH");
    var hidPCH=document.getElementById("hidPCH");
    var chkTSXX=document.getElementById("chkTSXX");
    if (chkTSXX!=null)
    {
      if(chkTSXX.checked)
      {
          LoadTSXX();
       }
    }
    if(drpPCH.value!="请选择")
    {
        hidPCH.value=drpPCH.value;
    }
    if(drpPCH.value=="请选择")
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
        LoadPCH();
        GetPCH();//选中上次选中的项
    }
    //加载特殊信息
    var hidTSXX=document.getElementById("hidTSXX");
    var chkTSXX=document.getElementById("chkTSXX");
    if(hidTSXX.value!=null && hidTSXX.value!="" && hidTSXX.value.length>0)
    {
        chkTSXX.checked=true;
        LoadTSXX();
        GetTSXX();//选中上次选中的项
    }
    //加载批次类型
    var hidPLX=document.getElementById("hidPLX");
    var chkPLX=document.getElementById("chkPLX");
    if(hidPLX.value!=null && hidPLX.value!="" && hidPLX.value.length>0)
    {
        chkPLX.checked=true;
        LoadPLX();
        GetPLX();//选中上次选中的项
    }
    
    //加载批次属性
    var hidPCSX=document.getElementById("hidPCSX");
    var chkPCSX=document.getElementById("chkPCSX");
    if(hidPCSX.value!=null && hidPCSX.value!="" && hidPCSX.value.length>0)
    {
        chkPCSX.checked=true;
        LoadPCSX();
        GetPCSX();//选中上次选中的项
    }
    //加载物料号
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    if(hidWLH.value!=null && hidWLH.value!="" && hidWLH.value.length>0)
    {
        chkWLH.checked=true;
        LoadWLH();
        GetWLH();//选中上次选中的项
    }
    //加载生产线
    var hidSCX=document.getElementById("hidSCX");
    var chkSCX=document.getElementById("chkSCX");
    if(hidSCX.value!=null && hidSCX.value!="" && hidSCX.value.length>0)
    {
        chkSCX.checked=true;
        LoadSCX();
        GetSCX();//选中上次选中的项
    }
    //加载状态（完成标志）
    var hidWCBZ=document.getElementById("hidWCBZ");
    var chkWCBZ=document.getElementById("chkWCBZ");
    if(hidWCBZ.value!=null && hidWCBZ.value!="" && hidWCBZ.value.length>0)
    {
        chkWCBZ.checked=true;
        LoadWCBZ();
        GetWCBZ();//选中上次选中的项
    }
    //加载牌号
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    if(hidPH.value!=null && hidPH.value!="" && hidPH.value.length>0)
    {
        chkPH.checked=true;
        LoadPH();
        GetPH();//选中上次选中的项
    }
    //加载规格
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    if(hidGG.value!=null && hidGG.value!="" && hidGG.value.length>0)
    {
        chkGG.checked=true;
        LoadGG();
        GetGG();//选中上次选中的项
    }
    //加载完工单号
    var hidWGDH=document.getElementById("hidWGDH");
    var chkWGDH=document.getElementById("chkWGDH");
    if(hidWGDH.value!=null && hidWGDH.value!="" && hidWGDH.value.length>0)
    {
        chkWGDH.checked=true;
        LoadWGDH();
        GetWGDH();//选中上次选中的项
    }
    //加载待判品
    var hidDPP=document.getElementById("hidDPP");
    var chkDPP=document.getElementById("chkDPP");
    if(hidDPP.value!=null && hidDPP.value!="" && hidDPP.value.length>0)
    {
        chkDPP.checked=true;
        LoadDPP();
        GetDPP();//选中上次选中的项
    }
    //加载待判品
    var hidZJR=document.getElementById("hidZJR");
    var chkZJR=document.getElementById("chkZJR");
    if(hidZJR.value!=null && hidZJR.value!="" && hidZJR.value.length>0)
    {
        chkZJR.checked=true;
        LoadZJR();
        GetZJR();//选中上次选中的项
    }
}
//获取特殊信息查询条件
function GetTSXX()
{
    var hidTSXX=document.getElementById("hidTSXX");
    var chkTSXX=document.getElementById("chkTSXX");
    var drpTSXX=document.getElementById("drpTSXX");
    var chkPCH=document.getElementById("chkPCH");
    var drpPCH=document.getElementById("drpPCH");
    if (chkTSXX!=null)
    {
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
        drpTSXX.disabled=true;
    }
    }
}
//加载特殊信息
function LoadTSXX()
{
    //是否已经选择了批次号
    var request=getXmlHttpRequest();
    var pch="";
    var chkPCH=document.getElementById("chkPCH");
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
    if (drpTSXX!=null)
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
        if (drpTSXX!=null)
        {
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
　	　	  }
　	　	 return true;
    }
}
//清空特殊信息
function ClearTSXX()
{
    var drpTSXX=document.getElementById("drpTSXX");
	for(var i = 0;i<=drpTSXX.options.length -1;i++)
	{
　　	drpTSXX.remove(i);
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
        drpWLH.options.length = 0;
        drpWLH.disabled=true;
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
    var Drptj = document.getElementById("Drptj");
    if(chkSCX.checked)
    {
        //已经加载过
        if (Drptj!=null)
        {
           Drptj.disabled=false;
        }
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
        if (Drptj!=null)
        {
           Drptj.disabled=true;
        }
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
　　	var items2 = oDoc.selectNodes("//NewDataSet/Table/SCXName");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpSCX.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items2[i].text; 
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
        drpPH.options.length = 0;
        drpPH.disabled=true;
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
        drpGG.options.length = 0;
        drpGG.disabled=true;
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
        drpWGDH.options.length = 0;
        drpWGDH.disabled=true;
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
	var Hidconfig = document.getElementById("Hidconfig");
	if (tblconfig!=null)
	{
	if(tblconfig.style.display ==  "block")
	{
		btnconfig.src = "../../images/icon/expand.gif";
		btnconfig.alt = "展开";
		tblconfig.style.display = "none";
		Hidconfig.value= "none";
	}
	else
	{
		btnconfig.src = "../../images/icon/collapse.gif";
		btnconfig.alt = "关闭";
		tblconfig.style.display = "block";
		Hidconfig.value= "block";
	}
	}
}
/*显示或者隐藏完工单明细*/
function AddItems()
{
    var btnItem = document.getElementById("btnItem");
	var tblPList= document.getElementById("tblPList");
	var hidItem = document.getElementById("hidItem");
	if (tblPList!=null)
	{
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
}
/*页面初始化，完工单查询*/

function Init()
{
	var hidSCX  = document.getElementById("hidSCX");
	var drpSCX = document.getElementById("drpSCX");
	if (hidSCX.value!="")
	{
	    var chkSCX  = document.getElementById("chkSCX");
	    //chkSCX.checked = true;
	    GetSCX();
	    drpSCX.value = hidSCX.value;
	}
	var hidPCH = document.getElementById("hidPCH");
	if (hidPCH.value!="")
	{
	   var drpPCH = document.getElementById("drpPCH");
	   var chkPCH = document.getElementById("chkPCH");
	   //chkPCH.checked = true;
	   GetPCH();
	   drpPCH.value = hidPCH.value;
	}
	
}


//察看完工单明细
function GetWGDItem()
{
    var iFrame=document.getElementById("frmList");
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
    var strPCH=tds[1].innerText;
    iFrame.src="WGDItems.aspx?PCH="+strPCH;
}
function setWgdxqzyx() {
   var selsxqwlhper=document.getElementById("selsxqwlhper");
   var selsxqgz=document.getElementById("selsxqgz");
   var selsxqgg=document.getElementById("selsxqgg");
   var selsxqvfree=document.getElementById("selsxqvfree");
   
   selsxqvfree.options.length=0;
   
   if (selsxqwlhper.value==""||selsxqgz.value==""||selsxqgg.value=="") {
      return;
   }
   var request=getXmlHttpRequest();
   var url="LogincAjax.aspx?TYPE=2902&wlhper="+selsxqwlhper.value+"&sxqgz="+selsxqgz.value+"&sxqgg="+encodeURI(selsxqgg.value);
   sendRequest(url,"","POST",request);
   var result = request.responseText;
   if(result.indexOf("ERROR")!=-1)
   {
        window.alert("数据访问失败，请重试！");
        return "";
   }
   else
   {
      selsxqvfree.options.length=0;  
      var txt = "";
      var oDoc = getXmlDocument();
      oDoc.loadXML(result);
      var items1 = oDoc.selectNodes("//NewDataSet/Table/vfree");
      var itemsLength = items1.length;
      if (itemsLength>0)
      {
              var varItem = new Option("","");
　　	      selsxqvfree.options.add(varItem); 　	  
　　	      for(i=0;i<itemsLength;i++) 
		      { 　　			
			    var newOption = document.createElement("OPTION"); 
　　		    newOption.text=items1[i].text; 
　　		    newOption.value=items1[i].text;
　　		    selsxqvfree.options.add(newOption); 
　	　        }
      }
　	}
}
function setWgdxqgg() {
   var selsxqwlhper=document.getElementById("selsxqwlhper");
   var selsxqgz=document.getElementById("selsxqgz");
   var selsxqgg=document.getElementById("selsxqgg");
   var selsxqvfree=document.getElementById("selsxqvfree");
   var hsxqgg=document.getElementById("hsxqgg");
   var hgg=document.getElementById("hgg");
   selsxqgg.options.length=0;
   selsxqvfree.options.length=0;
   if (selsxqwlhper.value==""||selsxqgz.value=="") {
      return;
   }
   var request=getXmlHttpRequest();
   var url="LogincAjax.aspx?TYPE=2901&wlhper="+selsxqwlhper.value+"&sxqgz="+encodeURI(selsxqgz.value);
   sendRequest(url,"","POST",request);
   var result = request.responseText;
   if(result.indexOf("ERROR")!=-1)
   {
        window.alert("数据访问失败，请重试！");
        return "";
   }
   else
   {
      selsxqgg.options.length=0;  
         var txt = "";
         var oDoc = getXmlDocument();
         oDoc.loadXML(result);
         var items1 = oDoc.selectNodes("//NewDataSet/Table/gg");
         var itemsLength = items1.length;
         if (itemsLength>0)
         {
              var varItem = new Option("","");
　　	      selsxqgg.options.add(varItem); 　	  
　　	      for(i=0;i<itemsLength;i++) 
		      { 　　			
			    var newOption = document.createElement("OPTION"); 
　　		    newOption.text=items1[i].text; 
　　		    newOption.value=items1[i].text;
　　		    selsxqgg.options.add(newOption); 
　	　        }
//　	　        
//　	　        if (trim(hsxqgg.value)!="") {
//　	　            //alert(hsxqgz.value);
//　	　            selsxqgg.value=hsxqgg.value;
//　	　            selsxqgg.text=hsxqgg.value;
//              }
//              else
//              {
//                  
//                  selsxqgg.value=hgg.value;
//　	　            selsxqgg.text=hgg.value;
//              }
         }
   }
}
function setwgdbxqgz(wlhper) {
      if (wlhper=="") {
         return;
      }
      var request=getXmlHttpRequest();
      var selsxqgz = document.getElementById("selsxqgz");
      var hph=document.getElementById("hph");
      var url="LogincAjax.aspx?TYPE=29&wlhper="+wlhper;
      sendRequest(url,"","POST",request);
      var result = request.responseText;
      var hsxqgz=document.getElementById("hsxqgz");
      if(result.indexOf("ERROR")!=-1)
      {
        window.alert("数据访问失败，请重试！");
        return "";
      }
      else
      {
         selsxqgz.options.length=0;  
         var txt = "";
         var oDoc = getXmlDocument();
         oDoc.loadXML(result);
         var items1 = oDoc.selectNodes("//NewDataSet/Table/ph");
         var itemsLength = items1.length;
         if (itemsLength>0)
         {
              var varItem = new Option("","");
　　	      selsxqgz.options.add(varItem); 　	  
　　	      for(i=0;i<itemsLength;i++) 
		      { 　　			
			    var newOption = document.createElement("OPTION"); 
　　		    newOption.text=items1[i].text; 
　　		    newOption.value=items1[i].text;
　　		    selsxqgz.options.add(newOption); 
　	　        }
　	　        
//　	　        if (trim(hsxqgz.value)!="") {
//　	　            //alert(hsxqgz.value);
//　	　            selsxqgz.value=hsxqgz.value;
//　	　            selsxqgz.text=hsxqgz.value;
//              }
//              else
//              {
//                  
//                  selsxqgz.value=hph.value;
//　	　            selsxqgz.text=hph.value;
//              }
         }
      }
  
}
function  trim(str){
    for(var  i  =  0  ;  i<str.length  &&  str.charAt(i)==" "  ;  i++  )  ;
    for(var  j  =str.length;  j>0  &&  str.charAt(j-1)==" "  ;  j--)  ;
    if(i>j)  return  "";  
    return  str.substring(i,j);  
} 
//设置被选择行的颜色
function SelectDataGridRow(DataGridName,rowIndex) 
{ 
     var mytable=document.getElementById(DataGridName);
     var hpch=document.getElementById("hpch");
     var hwlh = document.getElementById("hwlh");
     var hsx = document.getElementById("hsx");
     var hfree1=document.getElementById("hitfree1");
     var hfree2=document.getElementById("hitfree2");
     var hfree3=document.getElementById("hitfree3");
     var hph = document.getElementById("hph");
     var hwcbz = document.getElementById("hwcbz");
     var hpclx = document.getElementById("hpclx");
     var hzpdjbz = document.getElementById("hzpdjbz");
     var hzxbz = document.getElementById("hzxbz");
     var tbsxqinfo=document.getElementById("tbsxqinfo");
     var hsxqgz=document.getElementById("hsxqgz");
     var hsxqgg=document.getElementById("hsxqgg");
     var hsxqwlhper=document.getElementById("hsxqwlhper");
     var hsxqvfree=document.getElementById("hsxqvfree");
     var hgg=document.getElementById("hgg");
     var pch="";
     var e = event.srcElement;
     var tds = null;
     var strPCH=null;
     if(e.tagName=="TD")
       tds= e.parentNode.all.tags("td");
     else
       tds=e.all.tags("td");
     if (hwlh!=null)
     {
        hwlh.value = tds[3].innerText;
     }
     if (hsx!=null)
     {
        hsx.value = tds[2].innerText;
     }
     if(hph!=null)
     {
        hph.value = tds[5].innerText;
     }
     if (hwcbz!=null)
     {
       hwcbz.value= tds[20].innerText;
     }
     if (hpclx!=null)
     {
       hpclx.value=tds[21].innerText;
     }
     if (hzpdjbz!=null)
     {
       hzpdjbz.value=tds[22].innerText;
     }    
     if(hzxbz!=null)
     {
       hzxbz.value=tds[7].innerText;
     }
     if(hfree1!=null)
     {
        hfree1.value=tds[8].innerTest;
     }
      if(hfree2!=null)
     {
        hfree2.value=tds[9].innerTest;
     }
      if(hfree3!=null)
     {
        hfree3.value=tds[10].innerTest;
     }
     hgg.value=tds[6].innerText;
     hsxqgz.value=tds[26].innerText;
     hsxqwlhper.value=tds[27].innerText;
     hsxqgg.value=tds[28].innerText;
     hsxqvfree.value=tds[29].innerText;
     if (hpch!=null)
     {
        hpch.value=tds[1].innerText; 
        var iFrame=document.getElementById("frmList");
        iFrame.src="WGDItems.aspx?PCH="+hpch.value;  
        pch=hpch.value; 
        if (pch.substring(0,1)=="9"||pch.substring(0,1)=="A"||pch.substring(0,1)=="B") {
            tbsxqinfo.style.display="block";
            //setwgdbxqgz();
        }
        else     tbsxqinfo.style.display="none";
     }
     
     for(var i=1;i<mytable.rows.length;i++)
     {
         if(i!=rowIndex)
         {
            mytable.rows[i].style.backgroundColor="#FFFFFF";
         }
     }
     if(rowIndex!=0)
     {
       mytable.rows[rowIndex].oldcolor=mytable.rows[rowIndex].style.backgroundColor;
       mytable.rows[rowIndex].style.backgroundColor='#C8F7FF';
       
     }
     iniwgdshow();
     
     
} 

function changepcph()
{
   var selpcph = document.getElementById("selpcph");
   var selpcfree1 = document.getElementById("selpcfree1");
   var selpcfree2 = document.getElementById("selpcfree2");
   var selpcfree3 = document.getElementById("selpcfree3");
}
function changepcfree1()
{
   var selpcfree1 = document.getElementById("selpcfree1");
   var selpcfree2 = document.getElementById("selpcfree2");
   var selpcfree3 = document.getElementById("selpcfree3");
}
function changepcfree2()
{
   var selpcfree2 = document.getElementById("selpcfree2");
   var selpcfree3 = document.getElementById("selpcfree3");
}
function changepcfree3()
{
   var selpcfree3 = document.getElementById("selpcfree3");
}
function changeSX()
{
   var selpcsx = document.getElementById("selpcsx");
   //var rbl=document.getElementById("rbl");
   var rdpclx = document.getElementsByName("rdpclx");
   var pclx = 0;
   //clearOption("selpcsx");
   var len = 0;
   len=rdpclx.length;
   for(var i=0;i<len;i++)   
   {   
      if(rdpclx[i].checked)
      {
         pclx = rdpclx[i].value;
      }   
   }   
   var pcsx = selpcsx.value;
   if(pcsx=="CK")
   {
      pclx=1;
      rdpclx[1].checked=true;
      inipcsx();//重新绑定属性
   }
   if (pclx==0)
   {      
　　  setwgdbxx(0);  
   }
   else
   { 
　　  setwgdbxx(2);  
   }
}
function clearOption(SelectName)  //移除select 的 option
{
   var select = document.getElementById(SelectName);
   var colls = [];
   if (select!=null)
   {
       colls = select.options;
       for(var i=colls.length;i>=0;i--)
       {
          colls.remove(i);
       }
   }
}
//获取物料牌号对应的执行标准
function setphzxbz(txtname,fph)
{
   var txt = document.getElementById(txtname);
   var ph = fph;//document.getElementById("hph");
   
   if (txt!=null && ph!=null)
   {
      var request = getXmlHttpRequest();
      var strph = ph;
      var url = "LogincAjax.aspx?TYPE=11&fname="+encodeURI(strph);
      sendRequest(url,"","POST",request);
      var result = request.responseText;
      if (result.indexOf("ERROR")!=-1)
      {
        window.alert("数据访问失败，请重试！");
        return false;
      }
      else
      {
         txt.value="";
         var oDoc = getXmlDocument();
         oDoc.loadXML(result);
         var items1 = oDoc.selectNodes("//NewDataSet/Table/ZXBZValue");
         var itemsLength = items1.length;
         if (itemsLength>0)
         {
            txt.value = items1[0].text;
         }
         return true;
      }
   }
}
//获取物料号对应的属性
function setwlhzxbz(selname,fwlh,type)
{
    var sel = document.getElementById(selname);
    var wlh = fwlh;//document.getElementById("hwlh");
    if(fwlh=="") return;
    if ((sel!=null)&&(wlh!=null))
    {
       var request=getXmlHttpRequest();
       var strwlh = wlh;
       var url = "LogincAjax.aspx?TYPE=10&fname=" + encodeURI(strwlh) + "&STYPE=" + type;
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
        window.alert("数据访问失败，请重试！");
        return false;
       }
       else
       {
          sel.options.length = 0;
          var oDoc=getXmlDocument();
          oDoc.loadXML(result);
　　	  var items1 = oDoc.selectNodes("//NewDataSet/Table/SX");
　　	  var itemsLength=items1.length; 
　　	  if(itemsLength>0)
　　	  {
　　	      var varItem = new Option("请选择","请选择");
　　	      sel.options.add(varItem); 　	  
　　	      for(i=0;i<itemsLength;i++) 
		      { 　　			
			    var newOption = document.createElement("OPTION"); 
　　		    newOption.text=items1[i].text; 
　　		    newOption.value=items1[i].text;
　　		    sel.options.add(newOption); 
　	　        }
　	　        
　	　        sel.value = "A";
　	　    }
　	　    else
　	　    {
　	　       alert("缺少物料属性！");
　	　       return false;
　	　    }
　	　	  return true;
       }
    }
}
//获取完工单备选项的组合
function setwgditemzh()
{
   var sel = document.getElementById("selphgg");
   var selph = document.getElementById("selitemph");
   var hpch = document.getElementById("hpch");
   if (sel!=null && hpch!=null && selph!=null)
   {
       var request = getXmlHttpRequest();
       var strpch = hpch.value;
       var url = "LogincAjax.aspx?TYPE=26&pch="+encodeURI(strpch);
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
          window.alert("数据访问失败，请重试！");
          return false;
       }
       else
       {
          selph.options.length=0;
          var oDoc = getXmlDocument();
          oDoc.loadXML(result);
          var itemsph = oDoc.selectNodes("//NewDataSet/Table/ph");
          var itemsLengthph = itemsph.length;
          if (itemsLengthph>0)
          {
             //var newOptionemp = document.createElement("OPTION");
             //newOptionemp.text="";
　　		 //newOptionemp.value="";
　　		 //selph.options.add(newOptionemp);
　　		 
             for(i=0;i<itemsLengthph;i++)
             {
                var newOption = document.createElement("OPTION");
                newOption.text=itemsph[i].text;
　　		    newOption.value=itemsph[i].text;
　　		    selph.options.add(newOption); 
             }
             selph.value= document.getElementById("hph").value;
             //selph.selectedIndex=0;
             itemphchange();
          }
       }
       return;
       var url = "LogincAjax.aspx?TYPE=12&fname="+encodeURI(strpch);
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
          window.alert("数据访问失败，请重试！");
          return false;
       }
       else
       {
          sel.options.length=0;
          var oDoc = getXmlDocument();
          oDoc.loadXML(result);
          var items1 = oDoc.selectNodes("//NewDataSet/Table/ZHX");
          var items2 = oDoc.selectNodes("//NewDataSet/Table/zjbxbz");
          var itemsLength = items1.length;
          var itemslength2 = items2.length;
          if (itemsLength>0)
          {
             for(i=0;i<itemsLength;i++)
             {
                var newOption = document.createElement("OPTION");
                newOption.text=items1[i].text;
　　		    newOption.value=items1[i].text;
　　		    sel.options.add(newOption); 
             }
             sel.selectedIndex=0;
             for(i=0;i<itemslength2;i++)
             {
                if (items2[i].text=="1")
                {
                   sel.selectedIndex = i;
                }
             }
                
          }
          
       }
   }
}
//初始化批次属性对应值
function inipcsx()
{
   //var selpcsx = document.getElementById("selpcsx");//不需要再重新绑定
   //var rbl=document.getElementById("rbl");
   var rdpclx = document.getElementsByName("rdpclx");
   var pclx = 0;
   //clearOption("selpcsx");
   var hph = document.getElementById("hph");
   var hwlh = document.getElementById("hwlh");
   var len = 0;
   len=rdpclx.length;
   for(var i=0;i<len;i++)   
   {   
      if(rdpclx[i].checked)
      {
         pclx = rdpclx[i].value;
      }   
   }   
   //selpcsx.length = 0;
   document.getElementById("hpclx").value=pclx;
   if (pclx==0)
   {
      //setwlhzxbz("selpcsx",hwlh.value,1);
      setphzxbz("txtzxbz",hph.value);     
　　  var selzxbz = null;
　　  document.getElementById("capzxbz").style.display = "block";  
　　  document.getElementById("dvcbgp").style.display = "block";
　　  setwgdbxx(0);
　　  document.getElementById("cappdsx").innerText="改判物料";
   }
   else {
      // setwlhzxbz("selpcsx", hwlh.value, 1);
      document.getElementById("cbgp").checked=false;
//      var newOption = document.createElement("OPTION"); 
//　　		newOption.text="出口材"; 
//　　		newOption.value="出口材"; 
//　　		selpcsx.options.add(newOption);
//　　  var newOption1 = document.createElement("OPTION"); 
//　　		newOption1.text="待判"; 
//　　		newOption1.value="待判"; 
//　　		selpcsx.options.add(newOption1); 
　　  var selzxbz = null;
　　  document.getElementById("capzxbz").style.display = "none";
　　  document.getElementById("dvcbgp").style.display = "none";
　　  setwgdbxx(2);
　　  document.getElementById("cappdsx").innerText="判断完属性";
   }
}
//
function wgditemphggchange()
{
   var selphgg=document.getElementById("selphgg");
   setwlhzxbz("selitemsx",splitZHX(0),1);
   var hitemzxbz=document.getElementById("hitemzxbz");
   var titemzxbz=document.getElementById("txtitemzxbz");
   if(hitemzxbz!=null && titemzxbz!=null)
   {
       titemzxbz.value=splitZHX(3);
       hitemzxbz.value=splitZHX(3);
   }
   //setphzxbz("txtitemzxbz",splitZHX(1));
}
//分解完工单组合项
function splitZHX(tempn)
{
  var tvstr = "";
  var zhsel = document.getElementById("selphgg");
  if (zhsel!=null)
  {
    var zhstr = zhsel.value;
    if(zhstr=="")
    { 
       return "";
    }
    else
    {
       if(zhstr==undefined) 
       {
           return;
        }
       else
       {
           var vv = new Array();
           vv = zhstr.split("|");
           tvstr = vv[tempn].toString();
        }
    }
    
  }
  return tvstr;
}
function setwgdbxx(ntype)
{
   var dvzjbxx = document.getElementById("dvzjbxx");
   var cbgp = document.getElementById("cbgp");
   var itemsx = document.getElementById("selitemsx");
   var itemphgg= document.getElementById("selphgg");
   var itemzxbz = document.getElementById("txtitemzxbz");
   var itemzxbzcap = document.getElementById("itemzxbzcap");
   if (ntype==0)    //普通材                                      
   {
//     if (cbgp.checked)
//     {
//        dvzjbxx.style.display = "block";
//     }
//     else
//     {
//        dvzjbxx.style.display = "none";
//     }
//     
     
     if (document.getElementById("selpcsx").value=="DP")
     {
        if (cbgp.checked)
        {
           document.getElementById("selitemph").style.display = "block";
           itemphgg.style.display = "block";
           itemzxbz.style.display = "block";
        }
        else
        {
           document.getElementById("selitemph").style.display = "none";
           itemphgg.style.display = "none";
           itemzxbz.style.display = "none";
           
        }
        itemsx.style.display ="block";
     }
     else 
     {
        if (cbgp.checked)
        {
           document.getElementById("selitemph").style.display = "block";
           itemphgg.style.display = "block";
           itemzxbz.style.display = "block";
           itemsx.style.display ="block";
        }
        else
        {
           document.getElementById("selitemph").style.display = "none";
           itemphgg.style.display = "none";
           itemzxbz.style.display = "none";
           itemsx.style.display ="none";
        }
     }
     
        
   }
   else   //出口材
   {
      
         //dvzjbxx.style.display = "block"; 
         itemsx.style.display="block";  
          itemphgg.style.display = "block";
           itemzxbz.style.display = "block"; 
           document.getElementById("selitemph").style.display = "block";    
   }
   
}
//初始化质检信息，选择完工单的时候根据完工单状态 初始化界面
//如果未质检，以普通材初始化
//如果已质检，给各输入框赋值
function iniwgdshow()
{
      //alert("1");
      var wcbz = "";
      wcbz = getwgdstatus();
      //alert(wcbz);
      //属性为待判时 整批待检标志被选中
      
      var cbzpdjbz = document.getElementById("cbzpdj");
      var selpcsx = document.getElementById("selpcsx");
      var txtzxbz = document.getElementById("txtzxbz");
      var rdpclxs = document.getElementsByName("rdpclx");
      var cbgp = document.getElementById("cbgp");
      var selphgg = document.getElementById("selphgg");
      var selitemsx = document.getElementById("selitemsx");
      var txtitemzxbz = document.getElementById("txtitemzxbz");
      
      var sx = document.getElementById("hsx");
      var hwlh = document.getElementById("hwlh");
      var hph = document.getElementById("hph");
      var hpclx = document.getElementById("hpclx");
      var hzxbz = document.getElementById("hzxbz");
      selpcsx.options.length=0;
      selphgg.options.length = 0;
      selitemsx.options.length = 0;
      txtzxbz.value = "";
      cbgp.checked = false;
      txtitemzxbz.value = "";
      
      //var selsxqgzf=document.getElementById("selsxqgzf");
      
      rdpclxs[0].Checked = true;
      if (sx.value=="DP")
      {
         cbzpdjbz.checked=true;
      }
      else
      {
         cbzpdjbz.checked=false;
      }
      if (wcbz==0)  //未质检的完工单  
      {
          rdpclxs[0].checked = true;   //默认为普通材
          //设置物料属性，设置执行标准 
          //alert(hwlh.value);
          setwlhzxbz("selpcsx",hwlh.value,0);//默认为单卷属性
          txtzxbz.value=hzxbz.value;
          //setphzxbz("txtzxbz",hph.value);//执行标准改为带过来的
          setwgdbxx(0);
      }
      else   //已质检的完工单
      {
         var strpclx = hpclx.value;
         setwlhzxbz("selpcsx",hwlh.value,0);
         if (strpclx=="0")
         {
             rdpclxs[0].checked = true;
             var strpcsx = sx.value;
             selpcsx.value = strpcsx;
             txtzxbz.value = hzxbz.value;
             if (isgp())
             {
               cbgp.checked=true;
             }
             else
             {
               cbgp.checked=false;
             }
             getwgdzjbxx();      
             setwgdbxx(0);
             document.getElementById("capzxbz").style.display = "block";
　　         document.getElementById("dvcbgp").style.display = "block";
         }
         else
         { 
             rdpclxs[1].checked = true; 
             var strpcsx = sx.value;
             selpcsx.value = strpcsx;
             txtzxbz.value = hzxbz.value;
             setwgdbxx(1);
             document.getElementById("capzxbz").style.display = "none";
　　         document.getElementById("dvcbgp").style.display = "none";
　　         
　　         
         }
         
      }
      setwgditemzh();  //设置完工单备选项 组合信息  
      wgditemphggchange(); //设置完工单质检备选项
      //getwgdzjbxx();  //设置完工单质检备选项
      
      var vsx=getdefaultSx();
      var selitemsx=document.getElementById("selitemsx");
      if(selitemsx.options.length>0)
      {
         if(vsx!="")
         {
            selitemsx.value=vsx;
         }
         else
         {
            selitemsx.value="A";
         }
      }
      
}
function setItemsx()
{
      var win=window.parent.document.frames["frmList"]; 
      if(win!=null)
      {
         var tblist = win.document.getElementById("grdGridList");
         if(tblist!=null)
         {
             var selitemsx=win.parent.document.getElementById("selitemsx");
             var itemsx = tblist.rows[1].cells[4].innerText;
             if(itemsx!="" && itemsx!=" ")
                selitemsx.value=itemsx;
         }
      }
}
//获取完工单状态
function getwgdstatus()
{
   //var wcbz = null;
   var hwcbz=document.getElementById("hwcbz");
   var PCH = document.getElementById("Hpch");
//   if (hwcbz!=null)
//   {
      var requestT=getXmlHttpRequest();
      var strPch = PCH.value;
      var url="LogincAjax.aspx?TYPE=13&fname="+strPch;
      sendRequest(url,"","POST",requestT);
      var result = requestT.responseText;
      
      if(result.indexOf("ERROR")!=-1)
      {
        window.alert("数据访问失败，请重试！");
        return "";
      }
      else
      {
         var txt = "";
         var oDoc = getXmlDocument();
         oDoc.loadXML(result);
         var items1 = oDoc.selectNodes("//NewDataSet/Table/zjbz");
         var itemsLength = items1.length;
         if (itemsLength>0)
         {
            txt = items1[0].text;
            hwcbz.value = txt;
         }
         return txt;
      }
//   }
}
function isgp()//判断是否是改判信息
{
   var cbgp = document.getElementById("cbgp");
   var strpch = document.getElementById("hpch").value;
   var url = "LogincAjax.aspx?TYPE=15&fname="+strpch;
   var request=getXmlHttpRequest();
   sendRequest(url,"","POST",request);
   var result = request.responseText;
   if(result.indexOf("ERROR")!=-1)
   {
          window.alert("数据访问失败，请重试！");
          return false;
   }
   else
   {
         if (result=="1")
           return true;
         else
           return false;
   }
   
}
function getwgdzjbxx()    //获取质检备选项信息
{          
   var hitemwlh = document.getElementById("hitemwlh");
   var hitemph = document.getElementById("hitemph");
   var hitemgg = document.getElementById("hitemgg");
   var hitemzxbz = document.getElementById("hitemzxbz");
   var hitemsx = document.getElementById("hitemsx");
   var hitfree1=document.getElementById("hitfree1");
   var hitfree2=document.getElementById("hitfree2");
   var hitfree3=document.getElementById("hitfree3");
   var hpch = document.getElementById("hpch");
   if (hpch!=null)
   {
       var request = getXmlHttpRequest();
       var strpch = hpch.value;
       var url = "LogincAjax.aspx?TYPE=14&fname="+strpch;
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
          window.alert("数据访问失败，请重试！");
          return false;
       }
       else
       {          
          var oDoc = getXmlDocument();
          oDoc.loadXML(result);
          var itemswlh = oDoc.selectNodes("//NewDataSet/Table/wlh");
          var itemsph = oDoc.selectNodes("//NewDataSet/Table/ph");
          var itemsgg = oDoc.selectNodes("//NewDataSet/Table/gg");
          var itemszxbz = oDoc.selectNodes("//NewDataSet/Table/zxbz");
          var itemssx = oDoc.selectNodes("//NewDataSet/Table/sx");
          var itemfree1=oDoc.selectNodes("//NewDataSet/Table/Vfree1");
          var itemfree2=oDoc.selectNodes("//NewDataSet/Table/Vfree2");
          var itemfree3=oDoc.selectNodes("//NewDataSet/Table/Vfree3");
          var itemsLength = itemswlh.length;
          if (itemsLength>0)
          {
              hitemwlh.value = itemswlh[0].text;
              hitemph.value = itemsph[0].text;
              hitemgg.value = itemsgg[0].text;
              if (itemszxbz.length>0)
                hitemzxbz.value = itemszxbz[0].text;
              else
                hitemzxbz.value = "";
              if (itemssx.length>0)
                hitemsx.value = itemssx[0].text;
              else 
                hitemsx.value = "";
              if(itemfree1.length>0)
                hitfree1.value=itemfree1[0].text;
              else
                hitfree1.value="";
              if(itemfree2.length>0)
                hitfree2.value=itemfree2[0].text;
              else
                hitfree2.value="";
              if(itemfree3.length>0)
                hitfree3.value=itemfree3[0].text;
              else
                hitfree3.value="";
              return true;
          }
          else
          {
              hitemwlh.value = "";
              hitemph.value = "";
              hitemgg.value = "";
              hitemzxbz.value = "";
              hitemsx.value = "";
              hitfree1.value="";
              hitfree2.value="";
              hitfree3.value="";
              return false;
          }
          
       }
   }
}
function getwgdsczt()
{
   var PCH = document.getElementById("Hpch");
   if (PCH!=null)
   {
      var request=getXmlHttpRequest();
      var strPch = PCH.value;
      var url="LogincAjax.aspx?TYPE=16&fname="+strPch;
      sendRequest(url,"","POST",request);
      var result = request.responseText;
      if(result.indexOf("ERROR")!=-1)
      {
        window.alert("数据访问失败，请重试！");
        return "";
      }
      else
      {
         var txt = "";
         var oDoc = getXmlDocument();
         oDoc.loadXML(result);
         var items1 = oDoc.selectNodes("//NewDataSet/Table/wcbz");
         var itemsLength = items1.length;
         if (itemsLength>0)
         {
            txt = items1[0].text;
         }
         return txt;
      }
   }
}
function checkqucheck()
{
  var wgdgrv = document.getElementById("grvWGD");
  var hwcbz = document.getElementById("hwcbz");
  var hpch = document.getElementById("hpch");
  var hpclx = document.getElementById("hpclx");
  //var selsxqgzf=document.getElementById("selsxqgzf");
  var selsxqwlhper=document.getElementById("selsxqwlhper");
  var selsxqgz=document.getElementById("selsxqgz");
  var selsxqgg=document.getElementById("selsxqgg");
  var selsxqvfree=document.getElementById("selsxqvfree");
  
  if (hpch.value.substring(0,1)=="9"||hpch.value.substring(0,1)=="A"||hpch.value.substring(0,1)=="B") {
            if (selsxqwlhper.value=="") {
                alert("不锈钢酸洗线材请确定酸洗前的物料前三位");
                return false;
            }
            if (selsxqgz.value=="") {
                alert("不锈钢酸洗线材请确定酸洗前的钢种");
                return false;
            }
            if (selsxqgg.value=="") {
                alert("不锈钢酸洗线材请确定酸洗前的规格");
                return false;
            }
            if (selsxqvfree.value=="") {
                alert("不锈钢酸洗线材请确定酸洗前的自由项");
                return false;
            }
        }
  
  //selsxqgzf.text="ML35";
  //selsxqgzf.value="ML35";
  //alert(sxqgz);
  var wcbz= "0";
  var msg="";
  if (wgdgrv==null)
  {
     alert("没有完工单数据，请查询！");
     return false;
  }                                   
  if (wgdgrv.rows.length<=1)
  {
     alert("没有完工单数据，请查询！");
     return false;
  }
  if (hpch.value=="")
  {
    alert("请选择完工单！");
    return false;
  }
  //getwgdstatus();
  wcbz = getwgdsczt();
  if (wcbz!="0")
  {
    alert("该完工单已经在生产，不能质检！");
    return false;
  }
  var pclx = hpclx.value;            //批次类型
  var pcsx = document.getElementById("selpcsx").value;  //批次属性
  var isgp   //改判标志
  if (document.getElementById("cbgp").checked)
    isgp = "1";
  else isgp = "0";
  var zpdj ="0";                                      //整批待检标志
  if (pcsx=="DP")
    zpdj = "1";
  else zpdj = "0"; 
  var zxbz = document.getElementById("txtzxbz").value //执行标准
  var wgditemzh = document.getElementById("selphgg").value;   //质检备选项组合信息
  
  var wgditemwlh = "";  //质检备选项物料号
  var wgditemph = "";  //质检备选项牌号
  var wgditemgg ="";   //质检备选项规格
  var wgditemzxbz= "";  //质检备选项执行标准
  var wgditemsx = "";
  var wgditemfree1="";
  var wgditemfree2="";
  var wgditemfree3="";
  var wgditemfree4="";
  
  if (wgditemzh!="")
  {
     wgditemwlh=splitZHX(0);
     wgditemph=splitZHX(1);
     wgditemgg=splitZHX(2);
     wgditemzxbz=document.getElementById("txtitemzxbz").value;
     wgditemsx=document.getElementById("selitemsx").value;
     //*******
     wgditemfree1=splitZHX(3);//document.getElementById("hitfree1").value;
     wgditemfree2=splitZHX(4);//document.getElementById("hitfree2").value;
     wgditemfree3=splitZHX(5);
  }
  if(pcsx=="请选择")  
  {
    alert("选择批次属性！");
    return false;
  }
  
  if(pclx=="0")    //普通材
  {
     //if(zxbz=="")
     //{
       // alert("普通材没有对应的执行标准，请进入执行标准维护模块进行维护！");
       // return false;
     //}
     if (isgp=="1")
     {
        if (wgditemzh=="")
        {
          alert("请选择改判物料！");
          return false;
        }
        if (wgditemsx=="请选择")
        {
          alert("选择改判批次属性！");
          return false;
        }
//        if (wgditemzxbz=="")
//        {
//          alert("改判物料对应的执行标准不存在，请进入执行标准维护模块进行维护！");
//          return false;
//        }
     }
     if(pcsx=="CK")
     {
        alert("属性为出口材时请确定批次类型为出口材！");
        return false;
     }
  }
  else   //出口材
  {
      if (!(pcsx=="CK"||pcsx=="DP"))
      {
         alert("出口材属性不合法！");
         return false;
      }
      if(wgditemzh=="")
      {
         alert("请确认转内销牌号");
         return false;
      }
      if (wgditemsx=="请选择")
        {
          alert("选择转内销批次属性！");
          return false;
        }
      if (wgditemzxbz=="")
      {
          alert("转内销物料对应的执行标准不存在，请进入执行标准维护模块进行维护！");
          return false;
      }   
  }
  if (hwcbz.value=="1")
    msg="已经质检，是否再次质检？";
  else
    msg="是否质检？";  
  
  if (confirm(msg))
  {
    var request = getXmlHttpRequest();
    var strpch = hpch.value;
    var userno = document.getElementById("userno");
    var url = "LogincAjax.aspx?TYPE=17&fname="+strpch+"&pch="+hpch.value+"&pclx="+pclx+"&pcsx="+encodeURI(pcsx)+"&zxbz="+encodeURI(zxbz)+
              "&isgp="+isgp+"&zpdjbz="+zpdj+"&itemwlh="+wgditemwlh+"&itemph="+encodeURI(wgditemph)+"&itemgg="+encodeURI(wgditemgg)+"&itemzxbz="
              +encodeURI(wgditemzxbz)+"&itemsx="+encodeURI(wgditemsx)+"&userno="+userno.value+"&free1="+encodeURI(wgditemfree1)+"&free2="+encodeURI(wgditemfree2)+
              "&free3="+encodeURI(wgditemfree3)+"&sxqgz="+encodeURI(selsxqgz.value)+"&sxqgg="+encodeURI(selsxqgg.value)+
              "&wlhper="+selsxqwlhper.value+"&selsxqvfree="+encodeURI(selsxqvfree.value);
    sendRequest(url,"","POST",request);   
    var result = request.responseText;
    if (result=="0")
      alert("质检成功！");
    else
    {
      alert("质检失败："+result);
      return false;     
    }
    var btn_qry = document.getElementById("imgBtnQuery");
    if (btn_qry!=null)
       btn_qry.click();
    return true;
  }
  else
    return false;
}
function getsxqgz() {
   var selsxqwlhper=document.getElementById("selsxqwlhper");
   var selsxqgz=document.getElementById("selsxqgz");
   var selsxqgg=document.getElementById("selsxqgg");
   var selsxqvfree=document.getElementById("selsxqvfree");
   selsxqgz.options.length=0;
   selsxqgg.options.length=0;
   selsxqvfree.options.length=0;
   
   setwgdbxqgz(selsxqwlhper.value);
}
//不合格原因
function getReasonType()
{
   var rdreasontype = document.getElementsByName("rdreason");
   if (rdreasontype[0].checked)
   {
      getbhgReason("0");
   }
   if (rdreasontype[1].checked)
   {
      getbhgReason("1");
   }
   if(rdreasontype[2].checked)
   {
      getbhgReason("2")
   }
   setbtnstatus("query");   
}
function deleteRow(tbname,saverowno)  //删除表格行
{
   var obj=document.getElementById(tbname);
   var rowIndex=obj.childNodes[0].childNodes.length;
   if(rowIndex>saverowno)
   {  
      var delnum = rowIndex-parseInt(saverowno);
      for (i=rowIndex;i>saverowno;i--)
      {
        obj.deleteRow(i-1);
      }
   }
}
function insertRow(tbname,txt,rowno)
{
 // var obj=document.getElementById(tbname);
  //var rowIndex=obj.childNodes[0].childNodes.length;
  //var objTR=obj.insertRow(rowIndex);
  //var objTD1=objTR.insertCell();
  //objTD1.innerHTML=txt;
  //var seltr = obj.rows(rowIndex);
  //seltr.onClick="selecttbrow("+rowno+")";
tableobj=document.getElementById("grvreasonTbody"); 
trobj=document.createElement("tr"); 
tdobj=document.createElement("td"); 
trobj.id="tr"+rowno;
tdtextobj=document.createTextNode(txt); 
tdobj.appendChild(tdtextobj);
trobj.appendChild(tdobj);  
trobj.onclick=function()
{
   selecttbrow(rowno);
} 
tableobj.appendChild(trobj); 

}
function getbhgReason(ntype)
{
    var grvreason = document.getElementById("grvReason");
    if (grvreason!=null)
    {
       //清空数据
       deleteRow("grvReason",1);
       var request = getXmlHttpRequest();
       var url = "LogincAjax.aspx?TYPE=18&fname="+ntype;
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
          window.alert("数据访问失败，请重试！");
          return false;
       }
       else
       {
          
          var oDoc = getXmlDocument();
          oDoc.loadXML(result);
          var items1 = oDoc.selectNodes("//NewDataSet/Table/Reason");      
          var itemsLength = items1.length;
          for (i=0;i<itemsLength;i++)
          {
              var reason = items1[i].text;
              insertRow("grvReason",reason,i+1);
              //addTr();
          }
       }
    }
}
function selecttbrow(rowIndex) 
{ 
     var mytable=document.getElementById("grvReason");
     var txtreason=document.getElementById("txtreason");     
     var tds = null;    
     if (txtreason!=null)
     {
        txtreason.value=mytable.rows[rowIndex].cells[0].innerText;  
     }
     mytable.rows[rowIndex].style.backgroundColor='#C8F7FF';
     for(var i=0;i<mytable.rows.length;i++)
     {
         if(i!=rowIndex)
         {
            mytable.rows[i].style.backgroundColor="#FFFFFF";
         }
     }
     document.getElementById("htxtreason").value = mytable.rows[rowIndex].cells[0].innerText;
     
} 
function reasonaddnew()
{
   return false;
}
function settbedable(boo)
{
   var tb = document.getElementById("grvreason");
   var trr = null;
   var rowscount = 0;
   rowscount = tb.childNodes[0].childNodes.length;
   if(boo)
   {
      for (i=1;i<rowscount;i++)
      {
         trr=document.getElementById("tr"+i);
         trr.disabled = false;
      }
   }
   else
   {
      for (i=1;i<rowscount;i++)
      {
         trr=document.getElementById("tr"+i);
         trr.disabled = true;
      }
   }
   
}
function setbtnstatus(opetype)
{
   var tb = document.getElementById("grvreason");
   var btnnew = document.getElementById("btnnew");
   var btnedit = document.getElementById("btnedit");
   var btncancel = document.getElementById("btncancel");
   var btnsave = document.getElementById("btnsave");
   var btndel = document.getElementById("btndel");
   var txtreason = document.getElementById("txtreason");
   var hopetype = document.getElementById("hopetype");
   var rowscount = 0;
   var reasontype = "0";
   var ot = document.getElementsByName("rdreason");
   if (ot[0].checked)
       reasontype="0";
   if (ot[1].checked)
       reasontype="1";
   if (ot[2].checked)
       reasontype="2";
   if (opetype=="query")
   {
      settbedable(true);
      rowscount = tb.childNodes[0].childNodes.length;
      hopetype.value = "query";
      txtreason.disabled = true;
      btnnew.disabled = false;
      if (rowscount>1)
        btnedit.disabled = false;
      else
        btnedit.disabled = true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      
      return false;
   }
   if (opetype=="new")
   {
      settbedable(false);
      hopetype.value = "new";
      txtreason.disabled = false;
      txtreason.value = "";
      btnnew.disabled = true;
      btnedit.disabled = true;
      btncancel.disabled = false;
      btnsave.disabled = false;
      btndel.disabled = true;
      return false;
   }
   if(opetype=="edit")
   {
      if(document.getElementById("htxtreason").value=="")
      {
         alert("请选择需要修改的质量原因！");
         return false;
      }
      settbedable(false);
      hopetype.value = "edit";
      txtreason.disabled = false;
      btnnew.disabled = true;
      btnedit.disabled = true;
      btncancel.disabled = false;
      btnsave.disabled = false;
      btndel.disabled = true;
      return false;
   }
   if(opetype=="cancel")
   {
      settbedable(true);
      hopetype.value = "cancel";
      rowscount = tb.childNodes[0].childNodes.length;
      txtreason.disabled = true;
      txtreason.value = document.getElementById("htxtreason").value;
      btnnew.disabled = false;
      if (rowscount>1)
        btnedit.disabled = false;
      else
        btnedit.disabled = true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      return false;
   }
   if(opetype=="save")
   {  
      //检测
      if (txtreason.value=="")
      {
         alert("填写质量原因！");
         txtreason.focus();
         return false;
      }
      //保存
      if(!confirm("是否保存？"))
         return false;
      
      if (hopetype.value == "new")
      {
          var request = getXmlHttpRequest();
          var url = "LogincAjax.aspx?TYPE=19&fname="+encodeURI(txtreason.value)+"&itype=0&reasontype="+reasontype+
                         "&oldreason="+document.getElementById("htxtreason").value;
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="0")
             {
                 alert("保存成功！");
             }
             else
             {
                if(result=="1")
                
                  alert("数据重复！");
                else
                  alert("保存失败："+result);
                return false;
             }
          }
      }
      else
      {
        if(hopetype.value == "edit")
        {
          var request = getXmlHttpRequest();
    
          var url = "LogincAjax.aspx?TYPE=19&fname="+encodeURI(txtreason.value)+"&itype=1&reasontype="+reasontype+
                         "&oldreason="+encodeURI(document.getElementById("htxtreason").value);
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="0")
             {
                 alert("保存成功！");
             }
             else
             {
                if(result=="1")
                  alert("数据重复！");
                else
                  alert("保存失败："+result);
                return false;
             }
          }
        }
        else
        {
           alert("不在编辑状态！");
           return false;
        }
      }
      settbedable(true);
      txtreason.disabled = true;
      btnnew.disabled = false;
      btnedit.disabled = false;
      btncancel.disabled = true;
      btnsave.disabled = true;
      btndel.disabled = false;
      txtreason.value="";
      getReasonType();
      hopetype.value = "query";
      document.getElementById("htxtreason").value="";
      return false;
   }
   if(opetype=="del")
   {
           
      if(document.getElementById("htxtreason").value=="")
      {
         alert("请选择需要删除的质量原因！");
         return false;
      }
      //操作
      if(!confirm("是否删除？"))
        return false;
      var request = getXmlHttpRequest();
    
          var url = "LogincAjax.aspx?TYPE=20&fname="+encodeURI(txtreason.value)+"&reasontype="+reasontype;
                         
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="0")
             {
                 alert("删除成功！");
             }
             else
             {
                
                  alert("删除失败："+result);
                return false;
             }
          }
      document.getElementById("txtreason").value="";
      document.getElementById("htxtreason").value="";
      getReasonType();
      rowscount = tb.childNodes[0].childNodes.length;
      settbedable(true);
      txtreason.disabled = true;
      btnnew.disabled = false;
      if(rowscount>1)
        btnedit.disabled = false;
      else
        btnedit.disabled=true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      hopetype.value = "query";
      return false;
   }
   
   return false;
}
//*****end不合格原因*********
//******执行标准维护**********
function insertRowzxbz(tbname,txt,txt1,rowno)
{
 // var obj=document.getElementById(tbname);
  //var rowIndex=obj.childNodes[0].childNodes.length;
  //var objTR=obj.insertRow(rowIndex);
  //var objTD1=objTR.insertCell();
  //objTD1.innerHTML=txt;
  //var seltr = obj.rows(rowIndex);
  //seltr.onClick="selecttbrow("+rowno+")";
  tableobj=document.getElementById("grvstandTbody"); 
  trobj=document.createElement("tr"); 
  tdobj=document.createElement("td");
  tdobj.height = "15";
  tdobj1 = document.createElement("td"); 
  trobj.id="tr"+rowno;
  tdtextobj=document.createTextNode(txt); 
  tdtextobj1 = document.createTextNode(txt1);
  tdobj1.appendChild(tdtextobj1);
  tdobj.appendChild(tdtextobj);
  trobj.appendChild(tdobj); 
  trobj.appendChild(tdobj1);
  trobj.onclick=function()
  {
     selecttbrowzxbz(rowno);
  } 
  tableobj.appendChild(trobj); 

}
function getzxbz()  //获取执行标准
{
    var grvstand = document.getElementById("grvstand");
    if (grvstand!=null)
    {
       //清空数据
       deleteRow("grvstand",0);
       var request = getXmlHttpRequest();
       var url = "LogincAjax.aspx?TYPE=21";
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
          window.alert("数据访问失败，请重试！");
          return false;
       }
       else
       {
          
          var oDoc = getXmlDocument();
          oDoc.loadXML(result);
          var items1 = oDoc.selectNodes("//NewDataSet/Table/ZXBZPH");  
          var items2 = oDoc.selectNodes("//NewDataSet/Table/ZXBZValue");     
          var itemsLength = items1.length;
          for (i=0;i<itemsLength;i++)
          {
              var txt = items1[i].text;
              var txt1 = items2[i].text;
              insertRowzxbz("",txt,txt1,i);
              //addTr();
          }
       }
    }
    setbtnstatuszxbz("query");
}
function selecttbrowzxbz(rowIndex) 
{ 
     var mytable=document.getElementById("grvstand");
     var txtph = document.getElementById("txtph");
     var txtzxbz=document.getElementById("txtzxbz");     
     var tds = null;    
     if (txtph!=null)
     {
        txtph.value=mytable.rows[rowIndex].cells[0].innerText;  
        txtzxbz.value=mytable.rows[rowIndex].cells[1].innerText;  
     }
     mytable.rows[rowIndex].style.backgroundColor='#C8F7FF';
     for(var i=0;i<mytable.rows.length;i++)
     {
         if(i!=rowIndex)
         {
            mytable.rows[i].style.backgroundColor="#FFFFFF";
         }
     }
     document.getElementById("htxtph").value = mytable.rows[rowIndex].cells[0].innerText;
     document.getElementById("htxtzxbz").value = mytable.rows[rowIndex].cells[1].innerText;
     
} 
function setbtnstatuszxbz(opetype)
{
   var tb = document.getElementById("grvstand");
   var btnnew = document.getElementById("btnnew");
   var btnedit = document.getElementById("btnedit");
   var btncancel = document.getElementById("btncancel");
   var btnsave = document.getElementById("btnsave");
   var btndel = document.getElementById("btndel");
   var txtph = document.getElementById("txtph");
   var hopetype = document.getElementById("hopetype");
   var txtzxbz = document.getElementById("txtzxbz");
   var htxtph = document.getElementById("htxtph");
   var htxtzxbz = document.getElementById("htxtzxbz");
   var rowscount = 0;
   var reasontype = "0";

   if (opetype=="query")
   {
      settbedablezxbz(true);
      rowscount = tb.childNodes[0].childNodes.length;
      hopetype.value = "query";
      txtph.disabled = true;
      txtzxbz.disabled = true;
      btnnew.disabled = false;
      if (rowscount>1)
        btnedit.disabled = false;
      else
        btnedit.disabled = true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      
      return false;
   }
   if (opetype=="new")
   {
      settbedablezxbz(false);
      hopetype.value = "new";
      txtph.disabled = false;
      txtzxbz.disabled = false;
      txtph.value = "";
      txtzxbz.value = "";
      btnnew.disabled = true;
      btnedit.disabled = true;
      btncancel.disabled = false;
      btnsave.disabled = false;
      btndel.disabled = true;
      return false;
   }
   if(opetype=="edit")
   {
      if(document.getElementById("htxtph").value=="")
      {
         alert("请选择需要修改的执行标准！");
         return false;
      }
      settbedablezxbz(false);
      hopetype.value = "edit";
      txtph.disabled = false;
      txtzxbz.disabled = false;
      btnnew.disabled = true;
      btnedit.disabled = true;
      btncancel.disabled = false;
      btnsave.disabled = false;
      btndel.disabled = true;
      return false;
   }
   if(opetype=="cancel")
   {
      settbedablezxbz(true);
      hopetype.value = "cancel";
      rowscount = tb.childNodes[0].childNodes.length;
      txtph.disabled = true;
      txtzxbz.disabled = true;
      txtph.value = document.getElementById("htxtph").value;
      txtzxbz.value = document.getElementById("htxtzxbz").value;
      btnnew.disabled = false;
      if (rowscount>1)
        btnedit.disabled = false;
      else
        btnedit.disabled = true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      return false;
   }
   if(opetype=="save")
   {  
      //检测
      if (txtph.value=="")
      {
         alert("填写牌号！");
         txtph.focus();
         return false;
      }
      if (txtzxbz.value=="")
      {
         alert("填写牌号！");
         txtzxbz.focus();
         return false;
      }
      //保存
      if(!confirm("是否保存？"))
         return false;
      
      if (hopetype.value == "new")
      {
          var request = getXmlHttpRequest();
          //Response["zxbz"],Response["ph"],Response["opetype"],Response["oldph"],Response["oldzxbz"]);
          var url = "LogincAjax.aspx?TYPE=22&ph="+encodeURI(txtph.value)+"&opetype=0&zxbz="+encodeURI(txtzxbz.value)+"&oldph="+encodeURI(htxtph.value)+"&oldzxbz="+encodeURI(htxtzxbz.value);
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="0")
             {
                 alert("保存成功！");
             }
             else
             {
                if(result=="1")
                
                  alert("数据重复！");
                else
                  alert("保存失败："+result);
                return false;
             }
          }
      }
      else
      {
        if(hopetype.value == "edit")
        {
          var request = getXmlHttpRequest();
    
          var url = "LogincAjax.aspx?TYPE=22&ph="+encodeURI(txtph.value)+"&opetype=1&zxbz="+encodeURI(txtzxbz.value)+"&oldph="+encodeURI(htxtph.value)+"&oldzxbz="+encodeURI(htxtzxbz.value);
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="0")
             {
                 alert("保存成功！");
             }
             else
             {
                if(result=="1")
                  alert("数据重复！");
                else
                  alert("保存失败："+result);
                return false;
             }
          }
        }
        else
        {
           alert("不在编辑状态！");
           return false;
        }
      }
      settbedablezxbz(true);
      txtph.disabled = true;
      txtzxbz.disabled = true;
      btnnew.disabled = false;
      btnedit.disabled = false;
      btncancel.disabled = true;
      btnsave.disabled = true;
      btndel.disabled = false;
      txtph.value="";
      txtzxbz.value = "";
      getzxbz();
      hopetype.value = "query";
      document.getElementById("htxtph").value="";
      document.getElementById("htxtzxbz").value="";
      return false;
   }
   if(opetype=="del")
   {
           
      if(document.getElementById("htxtph").value=="")
      {
         alert("请选择需要删除的牌号标准！");
         return false;
      }
      //操作
      if(!confirm("是否删除？"))
        return false;
      var request = getXmlHttpRequest();
    
          var url = "LogincAjax.aspx?TYPE=23&ph="+encodeURI(txtph.value)+"&zxbz="+encodeURI(txtzxbz.value);
                         
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="0")
             {
                 alert("删除成功！");
             }
             else
             {
                
                  alert("删除失败："+result);
                return false;
             }
          }
      document.getElementById("txtph").value="";
      document.getElementById("htxtph").value="";
      document.getElementById("txtzxbz").value="";
      document.getElementById("htxtzxbz").value="";
      getzxbz();
      rowscount = tb.childNodes[0].childNodes.length;
      settbedablezxbz(true);
      txtph.disabled = true;
      txtzxbz.disabled = true;
      btnnew.disabled = false;
      if(rowscount>1)
        btnedit.disabled = false;
      else
        btnedit.disabled=true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      hopetype.value = "query";
      return false;
   }
   
   return false;
}
function settbedablezxbz(boo)
{
   var tb = document.getElementById("grvstand");
   var trr = null;
   var rowscount = 0;
   rowscount = tb.childNodes[0].childNodes.length;
   if(boo)
   {
      for (i=0;i<rowscount;i++)
      {
         trr=document.getElementById("tr"+i);
         trr.disabled = false;
      }
   }
   else
   {
      for (i=0;i<rowscount;i++)
      {
         trr=document.getElementById("tr"+i);
         trr.disabled = true;
      }
   }
   
}
//******end执行标准**********
//卷信息查询setselvalue('ck','WMS_Bms_Inv_Info','drpCK')
function setselvalue(fname,tbname,selname)
{
    var sele = document.getElementById(selname);
    var drppchend = document.getElementById("drppchend");
    if (sele!=null)
    {
       sele.options.length=0;
       if (fname=="pch")
       {
          if(drppchend!=null)
             drppchend.options.length = 0;
       }
       var e = event.srcElement;
       if(e.checked)
       {
           var request=getXmlHttpRequest();
           var url = "LogincAjax.aspx?TYPE=24&fname="+fname+"&tbname="+tbname;
           sendRequest(url,"","POST",request);
           var result = request.responseText;
           if(result.indexOf("ERROR")!=-1)
           {
              window.alert("数据访问失败，请重试！");
              return false;
           }
           else
           {
              
              var oDoc = getXmlDocument();
              oDoc.loadXML(result);
              var items1 = oDoc.selectNodes("//NewDataSet/Table/"+fname);   
              var itemsLength = items1.length;
              
              if(itemsLength>0)
　　	      {
　　	        var varItem = new Option("请选择","请选择");
　　	        sele.options.add(varItem); 
　　	        for(i=0;i<itemsLength;i++) 
		        { 　　			
			        var newOption = document.createElement("OPTION"); 
　　		        newOption.text=items1[i].text; 
　　		        newOption.value=items1[i].text;
　　		        sele.options.add(newOption); 
　	　	        }
　	　	        if(fname=="pch")
　	　	        {
　	　	            if(drppchend!="")
　	　	            {
　	　	                var varItem1 = new Option("请选择","请选择");
　　	                drppchend.options.add(varItem1); 
　　	                for(i=0;i<itemsLength;i++) 
		                { 　　			
			                var newOption1 = document.createElement("OPTION"); 
　　		                newOption1.text=items1[i].text; 
　　		                newOption1.value=items1[i].text;
　　		                drppchend.options.add(newOption1); 
　	　	                }
　	　	            }
　	　	        }
　　	      }
    　　	
           }
       }
    }
}
function getsqlfilter()//卷信息查询
{
    var sqlfilter= "";
    if(document.getElementById("cbck").checked && document.getElementById("selck").value!="" &&document.getElementById("selck").value!="请选择")
		sqlfilter = sqlfilter+"&ck="+document.getElementById("selck").value;
	if(document.getElementById("cbsx").checked && document.getElementById("selsx").value!="" &&document.getElementById("selsx").value!="请选择")
		sqlfilter = sqlfilter+"&sx="+encodeURI(document.getElementById("selsx").value);
	if(document.getElementById("cbwlh").checked && document.getElementById("selwlh").value!="" &&document.getElementById("selwlh").value!="请选择")
		sqlfilter = sqlfilter+"&wlh="+document.getElementById("selwlh").value;
	if(document.getElementById("cbph").checked && document.getElementById("selph").value!="" &&document.getElementById("selph").value!="请选择")
		sqlfilter = sqlfilter+"&ph="+document.getElementById("selph").value;
	if(document.getElementById("cbhw").checked && document.getElementById("selhw").value!="" &&document.getElementById("selhw").value!="请选择")
		sqlfilter = sqlfilter+"&hw="+document.getElementById("selhw").value;
	if(document.getElementById("cbgg").checked && document.getElementById("selgg").value!="" &&document.getElementById("selgg").value!="请选择")
		sqlfilter = sqlfilter+"&gg="+encodeURI(document.getElementById("selgg").value);
	if(document.getElementById("cbbb").checked && document.getElementById("selbb").value!="" &&document.getElementById("selbb").value!="请选择")
		sqlfilter = sqlfilter+"&bb="+encodeURI(document.getElementById("selbb").value);
	if(document.getElementById("cbgh").checked && document.getElementById("selgh").value!="" &&document.getElementById("selgh").value!="请选择")
		sqlfilter = sqlfilter+"&gh="+document.getElementById("selgh").value;
	if(document.getElementById("cbErrSeason").checked && document.getElementById("selErrSeason").value!="" &&document.getElementById("selErrSeason").value!="请选择")
		sqlfilter = sqlfilter+"&ErrSeason="+encodeURI(document.getElementById("selErrSeason").value);
	if(document.getElementById("cbscx").checked && document.getElementById("drpSCX").value!="" &&document.getElementById("drpSCX").value!="请选择")
		sqlfilter = sqlfilter+"&SCXBM="+document.getElementById("drpSCX").value;
	if(document.getElementById("cbpcinfo").checked && document.getElementById("selpcinfo").value!="" &&document.getElementById("selpcinfo").value!="请选择")
		sqlfilter = sqlfilter+"&pcinfo="+encodeURI(document.getElementById("selpcinfo").value);
	if(document.getElementById("cbbarcode").checked && document.getElementById("selbarcode").value!="" &&document.getElementById("selbarcode").value!="请选择")
		sqlfilter = sqlfilter+"&barcode="+document.getElementById("selbarcode").value;
    if(document.getElementById("chkFree1").checked && document.getElementById("txtFree1").value!="" &&document.getElementById("txtFree1").value!="请选择")
		sqlfilter = sqlfilter+"&free1="+encodeURI(document.getElementById("txtFree1").value);
	if(document.getElementById("chkFree2").checked && document.getElementById("txtFree2").value!="" &&document.getElementById("txtFree2").value!="请选择")
		sqlfilter = sqlfilter+"&free2="+encodeURI(document.getElementById("txtFree2").value);
	if(document.getElementById("chkFree3").checked && document.getElementById("txtFree3").value!="" &&document.getElementById("txtFree3").value!="请选择")
		sqlfilter = sqlfilter+"&free3="+encodeURI(document.getElementById("txtFree3").value);
	if(document.getElementById("chkRKPCH").checked)
	{
		var pchs = document.getElementById("drpRKPCH").value;
		var pche = document.getElementById("drppchend").value;
		if((pchs!="" && pchs!="请选择") && (pche!="" && pche!="请选择"))
			sqlfilter = sqlfilter +"&MPCH="+pche+"&MIPCH="+pchs;
        if((pchs!="" && pchs!="请选择") && (pche=="" || pche=="请选择"))
			sqlfilter = sqlfilter +"&PCH="+pchs;
		if((pchs=="" || pchs=="请选择") && (pche!="" && pche!="请选择"))
			sqlfilter = sqlfilter +"&PCH="+pche;
	}
	if (document.getElementById("chkRKRQ").checked)
	{
		var rqs = document.getElementById("RKRQ_Start").value;
		var rqe = document.getElementById("RKRQ_End").value;
		var regS = new RegExp("-","gi");
		if (rqs!="" && rqe!="")
		{
			sqlfilter = sqlfilter +"&MP="+rqe.replace(regS,".")+"&MIP="+rqs.replace(regS,".");
		} 
		if (rqs!="" && rqe=="")
		{
            sqlfilter = sqlfilter +"&MIP="+rqs.replace(regS,".");
		}
		if (rqs=="" && rqe!="")
		{
            sqlfilter = sqlfilter +"&MP="+rqe.replace(regS,".");
		}
	}
	if (document.getElementById("cbslph").checked&&document.getElementById("txtslph").value!="") {
	    var txtslph=document.getElementById("txtslph");
	    sqlfilter = sqlfilter+"&ph="+encodeURI(txtslph.value);
	}
	return sqlfilter;
}
function getsqlfilterSpec()//特殊信息库存修改查询
{
    var sqlfilter= "";
    if(document.getElementById("cbck").checked && document.getElementById("selck").value!="" &&document.getElementById("selck").value!="请选择")
		sqlfilter = sqlfilter+" and ck='"+document.getElementById("selck").value+"'";
	if(document.getElementById("cbsx").checked && document.getElementById("selsx").value!="" &&document.getElementById("selsx").value!="请选择")
		sqlfilter = sqlfilter+" and sx='"+encodeURI(document.getElementById("selsx").value)+"'";
	if(document.getElementById("cbwlh").checked && document.getElementById("selwlh").value!="" &&document.getElementById("selwlh").value!="请选择")
		sqlfilter = sqlfilter+" and wlh='"+document.getElementById("selwlh").value+"'";
	if(document.getElementById("cbph").checked && document.getElementById("selph").value!="" &&document.getElementById("selph").value!="请选择")
		sqlfilter = sqlfilter+" and ph='"+document.getElementById("selph").value+"'";
	if(document.getElementById("cbhw").checked && document.getElementById("selhw").value!="" &&document.getElementById("selhw").value!="请选择")
		sqlfilter = sqlfilter+" and hw='"+document.getElementById("selhw").value+"'";
	if(document.getElementById("cbgg").checked && document.getElementById("selgg").value!="" &&document.getElementById("selgg").value!="请选择")
		sqlfilter = sqlfilter+" and gg='"+encodeURI(document.getElementById("selgg").value)+"'";
	if(document.getElementById("cbbb").checked && document.getElementById("selbb").value!="" &&document.getElementById("selbb").value!="请选择")
		sqlfilter = sqlfilter+" and bb='"+encodeURI(document.getElementById("selbb").value)+"'";
	if(document.getElementById("cbgh").checked && document.getElementById("selgh").value!="" &&document.getElementById("selgh").value!="请选择")
		sqlfilter = sqlfilter+" and gh='"+document.getElementById("selgh").value+"'";
	if(document.getElementById("cbErrSeason").checked && document.getElementById("selErrSeason").value!="" &&document.getElementById("selErrSeason").value!="请选择")
		sqlfilter = sqlfilter+" and ErrSeason='"+encodeURI(document.getElementById("selErrSeason").value)+"'";
	if(document.getElementById("cbscx").checked && document.getElementById("drpSCX").value!="" &&document.getElementById("drpSCX").value!="请选择")
		sqlfilter = sqlfilter+" and SCXBM='"+document.getElementById("drpSCX").value+"'";
	if(document.getElementById("cbpcinfo").checked && document.getElementById("selpcinfo").value!="" &&document.getElementById("selpcinfo").value!="请选择")
		sqlfilter = sqlfilter+" and pcinfo='"+encodeURI(document.getElementById("selpcinfo").value)+"'";
	if(document.getElementById("cbbarcode").checked && document.getElementById("selbarcode").value!="" &&document.getElementById("selbarcode").value!="请选择")
		sqlfilter = sqlfilter+" and barcode='"+document.getElementById("selbarcode").value+"'";
	if(document.getElementById("chkRKPCH").checked)
	{
		var pchs = document.getElementById("drpRKPCH").value;
		var pche = document.getElementById("drppchend").value;
		if((pchs!="" && pchs!="请选择") && (pche!="" && pche!="请选择"))
			sqlfilter = sqlfilter +" and PCH<='"+pche+"' and PCH>='"+pchs+"'";
        if((pchs!="" && pchs!="请选择") && (pche=="" || pche=="请选择"))
			sqlfilter = sqlfilter +" and PCH='"+pchs+"'";
		if((pchs=="" || pchs=="请选择") && (pche!="" && pche!="请选择"))
			sqlfilter = sqlfilter +" and PCH='"+pche+"'";
	}
	if (document.getElementById("chkRKRQ").checked)
	{
		var rqs = document.getElementById("RKRQ_Start").value;
		var rqe = document.getElementById("RKRQ_End").value;
		var regS = new RegExp("-","gi");
		if (rqs!="" && rqe!="")
		{
			sqlfilter = sqlfilter +" and RQ<='"+rqe.replace(regS,".")+"' and RQ>='"+rqs.replace(regS,".")+"'";
		} 
		if (rqs!="" && rqe=="")
		{
            sqlfilter = sqlfilter +" and RQ='"+rqs.replace(regS,".")+"'";
		}
		if (rqs=="" && rqe!="")
		{
            sqlfilter = sqlfilter +" and RQ='"+rqe.replace(regS,".")+"'";
		}
	}
	return sqlfilter;
}
function searchbarcode()
{
	var sqlfil = getsqlfilter();
	var status = document.getElementById("status");
	if (sqlfil=="")
	{
		alert("请设置查询条件！");
		return false;
	}
    var iframe = document.getElementById("frmList");
    var iframe1 = document.getElementById("frmOut");
    var rdck = document.getElementsByName("rdkc");
   setstatus("正在查询库存数据....");
   iframe.src = "infobarcode.aspx?TYPE=1"+sqlfil;

   setstatus("正在查询出库数据....");
   iframe1.src = "outfobarcode.aspx?TYPE=2"+sqlfil;
    
    return false;
}
function setstatus(ms)
{
   var status = window.parent.document.getElementById("status");
   if (status!=null)
   {    
         status.innerText=ms;     
   }
}
//*******end卷信息查询********
//******特殊信息********
function setdispaly(ntype)
{
   var rdtypes = document.getElementsByName("rdtype");
   var rdpcdjs = document.getElementsByName("rdpcdj");
   var tpkc = document.getElementById("tpkc");
   var tpwgdp = document.getElementById("tpwgdp");
   var chazhao = document.getElementById("chazhao");
   var imgcz = document.getElementById("imgcz");
   var btnQuery = document.getElementById("btnQuery");
   var sx = document.getElementById("sx");
   var frm = document.getElementById("frm");
   
   var hpch = document.getElementById("hpch");
   var hbarcode = document.getElementById("hbarcode");
   hpch.value="";
   hbarcode.value="";
   
   
   if (rdtypes[0].checked)  //完工单查询
   {
      tpkc.style.visibility="hidden";
      tpwgdp.style.visiblity = "visible";
      tpwgdp.visible = true;
      tpwgdp.style.cssText = "VISIBILITY: visible;";
      chazhao.style.display = "none";
      
      btnQuery.src = "../../images/icon/expand.gif";
	  btnQuery.alt = "展开";
	  
      imgcz.visible = false;
      imgcz.style.cssText = "VISIBILITY: hidden;";
      frm.style.height="400px";
      frm.height = "400px";
      sx.style.visiblity = "hidden";
      sx.visible = false;
      sx.style.cssText = "VISIBILITY: hidden;";
      
   }
   if (rdtypes[1].checked)
   {
      tpkc.style.visibility="visible";
      tpwgdp.style.visiblity = "hidden";
      tpwgdp.visible = false;
      tpwgdp.style.cssText = "VISIBILITY: hidden;";
      
      
      imgcz.style.visiblity = "visible";
      imgcz.visible = true;
      imgcz.style.cssText = "VISIBILITY: visible;";
      
      rdpcdjs[0].check = true;
      
      sx.style.visiblity = "visible";
      sx.visible = true;
      sx.style.cssText = "VISIBILITY: visible;";
      frm.style.height="400px";
      frm.height="400px";
      var selsxa = document.getElementById("selsxa");
      //if (selsxa.options.length!=0)
      //{
         // getpcinfo("sx","Wms_bms_Inv_info",'selsxa');
      //} 
         getsxspec("sx","Wms_bms_Inv_info",'selsxa');
   }
   var frmlist = document.getElementById("ifrmlist");
     frmlist.src = "infobarcode.aspx?Sqlfilter="+" and 1=2";
     frmlist.src = "QuWGD.aspx?Sqlfilter="+" and 1=2";
   return false;
}
function setdispalytpkc()
{
    var rdpcdjs = document.getElementsByName("rdpcdj");
    var sx = document.getElementById("sx");
    if (rdpcdjs[0].checked)
    {        
        sx.style.visiblity = "visible";
        sx.visible = true;
        sx.style.cssText = "VISIBILITY: visible;";
    }
    if (rdpcdjs[1].checked)
    {        
        sx.style.visiblity = "hidden";
        sx.visible = false;
        sx.style.cssText = "VISIBILITY: hidden;";
    }
}
function getpcinfo(fname,tbname,selname)
{
    var sele = document.getElementById(selname);
    if (sele!=null)
    {
       sele.options.length=0;
       var cbpcinfoa = document.getElementById("cbpcinfoa");
       if(cbpcinfoa.checked)
       {
           var request=getXmlHttpRequest();
           var url = "LogincAjax.aspx?TYPE=24&fname="+encodeURI(fname)+"&tbname="+encodeURI(tbname);
           sendRequest(url,"","POST",request);
           var result = request.responseText;
           if(result.indexOf("ERROR")!=-1)
           {
              window.alert("数据访问失败，请重试！");
              return false;
           }
           else
           {
              
              var oDoc = getXmlDocument();
              oDoc.loadXML(result);
              var items1 = oDoc.selectNodes("//NewDataSet/Table/"+fname);   
              var itemsLength = items1.length;
              
              if(itemsLength>0)
　　	      {
　　	        var varItem = new Option("请选择","请选择");
　　	        sele.options.add(varItem); 
　　	        for(i=0;i<itemsLength;i++) 
		        { 　　			
			        var newOption = document.createElement("OPTION"); 
　　		        newOption.text=items1[i].text; 
　　		        newOption.value=items1[i].text;
　　		        sele.options.add(newOption); 
　	　	        }
　　	      }
    　　	
           }
           var newpcinfo = document.getElementById("newpcinfo");
           newpcinfo.value="";
           sele.disabled = false;
           newpcinfo.disabled = true;
       }
       else
       {
           sele.options.length=0;
           if (selname!="selsxa")
             sele.disabled = true;
           var newpcinfo = document.getElementById("newpcinfo");
           newpcinfo.value="";
           newpcinfo.disabled = false;
       }
    }
}
function getsxspec(fname,tbname,selname)
{
    var sele = document.getElementById(selname);
    if (sele!=null)
    {
       sele.options.length=0;
       
           var request=getXmlHttpRequest();
           var url = "LogincAjax.aspx?TYPE=24&fname="+encodeURI(fname)+"&tbname="+tbname;
           sendRequest(url,"","POST",request);
           var result = request.responseText;
           if(result.indexOf("ERROR")!=-1)
           {
              window.alert("数据访问失败，请重试！");
              return false;
           }
           else
           {
              
              var oDoc = getXmlDocument();
              oDoc.loadXML(result);
              var items1 = oDoc.selectNodes("//NewDataSet/Table/"+fname);   
              var itemsLength = items1.length;
              
              if(itemsLength>0)
　　	      {
　　	        var varItem = new Option("请选择","请选择");
　　	        sele.options.add(varItem); 
　　	        for(i=0;i<itemsLength;i++) 
		        { 　　			
			        var newOption = document.createElement("OPTION"); 
　　		        newOption.text=items1[i].text; 
　　		        newOption.value=items1[i].text;
　　		        sele.options.add(newOption); 
　	　	        }
　　	      }
    　　	
           }
           
    }
}
function getslqfilter()  //特殊信息查询
{
    var sqlf = "";
    var rdtypes = document.getElementsByName("rdtype");
    if (rdtypes[0].checked)
    {
       if (document.getElementById("txtpch").value!="")
         sqlf = " and pch like '%25"+document.getElementById("txtpch").value+"%25'"
    }  
    if (rdtypes[1].checked)
       sqlf = getsqlfilterSpec();
    return sqlf;
}

function getbarcode()
{
   var rdtypes = document.getElementsByName("rdtype");
   var sqlfil = getslqfilter();
   if (sqlfil=="")
   {
      alert("请设置查询条件！");
      return false;
   }
   var ifrm = document.getElementById("ifrmlist");
   if (rdtypes[1].checked)
     ifrm.src = "QuSpecialBarcode.aspx?Sqlfilter="+encodeURI(sqlfil);
   else
     ifrm.src = "QuWGD.aspx?Sqlfilter="+encodeURI(sqlfil);
   var hpch = document.getElementById("hpch");
   var hbarcode = document.getElementById("hbarcode");
   hpch.value="";
   hbarcode.value="";
   return false;
}
function SelectDataGridRowSpec(DataGridName,rowIndex) 
{ 
     var mytable=document.getElementById(DataGridName);
     var e = event.srcElement;
     var tds = null;
     var hpch = document.getElementById("hpch");
     
     
     if(e.tagName=="TD")
       tds= e.parentNode.all.tags("td");
     else
       tds=e.all.tags("td");
     if(DataGridName=="grvWGD")
     {
        hpch.value=tds[1].innerText;
     }
     else
     {
        window.parent.document.getElementById("hbarcode").value=tds[0].innerText;
        hpch.value=tds[2].innerText;
     }
     mytable.rows[rowIndex].oldcolor=mytable.rows[rowIndex].style.backgroundColor;
     mytable.rows[rowIndex].style.backgroundColor='#C8F7FF';
     for(var i=0;i<mytable.rows.length;i++)
     {
         if(i!=rowIndex)
         {
            mytable.rows[i].style.backgroundColor="#FFFFFF";
         }
     }
     window.parent.document.getElementById("hpch").value=hpch.value;
} 

function updatepcinfo()
{
   var hpch = document.getElementById("hpch");
   var hbarcode = document.getElementById("hbarcode");
   var rdtypes = document.getElementsByName("rdtype");
   var kctypes= document.getElementsByName("rdpcdj");
   var rdtype = "";
   var xgsx = document.getElementById("selsxa").value;
   if(rdtypes[0].checked)  //完工单批次修改
      rdtype = "0";
   else
   {
      rdtype="1";          //库存修改
      if (kctypes[0].checked)  
         rdtype="2";         //库存批次按属性修改
      else
         rdtype="3";          //库存单卷修改
   }
   var pch = hpch.value;
   var barcode = hbarcode.value;
   //pcinfo = document.getElementById("").value;
   if (rdtype=="0")
   {
      if (pch=="")
      {
         alert("选择要修改的完工单！");
         return false;
      }
      
   }
   if(rdtype=="2")
   {
      if (pch=="")
      {
         alert("选择要修改的数据！");
         return false;
      }   
      if(xgsx=="请选择" ||xgsx=="")
      {
         alert("选择要修改的批次属性");
         return false;
      }
   }
   if(rdtype=="3")
   {
      if(barcode=="")
      {
         alert("选择要修改的数据！");
         return false;  
      }
   }
   var cbpcinfoa = document.getElementById("cbpcinfoa");
   var selpcinfoa = document.getElementById("selpcinfoa");
   var newpcinfo = document.getElementById("newpcinfo");
   selpcinfovalue = selpcinfoa.value;
   newpcinfovalue = newpcinfo.value;
   if (cbpcinfoa.checked)
   {
      if (selpcinfovalue=="请选择"||selpcinfovalue=="")
      {
         alert("选择要修改的特殊信息！");
         return false;
      }
   }
   else
   {
       if (newpcinfovalue=="")
       {
          if(!confirm("是否清除？"))
          {
             newpcinfo.focus();
             return false;
          }
       }
   }
   var res ="";
   if (confirm("是否进行设置？"))
  {
    var request = getXmlHttpRequest();
    var strpch = hpch.value;
    var userno = document.getElementById("userno");
    //QuCheck.SetPcInfo(Request["itype"], Request["pch"], Request["barcode"], Request["selpcinfo"], Request["newpcinfo"], Request["sx"]);
    var url = "LogincAjax.aspx?TYPE=25&itype="+rdtype+"&pch="+pch+"&barcode="+barcode+"&selpcinfo="+encodeURI(selpcinfovalue)+"&newpcinfo="+encodeURI(newpcinfovalue)+
              "&sx="+encodeURI(xgsx);
    sendRequest(url,"","POST",request);   
    var result = request.responseText;
    if (result=="0")
    {
      alert("设置成功！");
      getbarcode();
    }
    else
    {
      alert("设置失败："+result);
      return false;     
    }
    
  }
   return false;
}
//*******end特殊信息********
function itemphchange()
{
   var request = getXmlHttpRequest();
   var sel = document.getElementById("selphgg");
   var selph = document.getElementById("selitemph");
   var hpch = document.getElementById("hpch");
   var strpch=hpch.value;
   if (sel!=null && hpch!=null && selph!=null)
   {
       var url = "LogincAjax.aspx?TYPE=12&fname="+encodeURI(strpch)+"&ph="+encodeURI(selph.value);
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
          window.alert("数据访问失败，请重试！");
          return false;
       }
       else
       {
          sel.options.length=0;
          var oDoc = getXmlDocument();
          oDoc.loadXML(result);
          var items1 = oDoc.selectNodes("//NewDataSet/Table/ZHX");
          var items2 = oDoc.selectNodes("//NewDataSet/Table/zjbxbz");
          var items3 = oDoc.selectNodes("//NewDataSet/Table/zjbxSX");
          var itemsLength = items1.length;
          var itemslength2 = items2.length;
          var itemslength3=items3.length;
          if (itemsLength>0)
          {
             for(i=0;i<itemsLength;i++)
             {
                var newOption = document.createElement("OPTION");
                newOption.text=items1[i].text;
　　		    newOption.value=items1[i].text;
　　		    sel.options.add(newOption); 
             }
             var itemphggstr= getdefaultItem();
             if(itemphggstr=="")
             sel.selectedIndex=0;
             else  sel.value =    itemphggstr;         
          }
          
          wgditemphggchange();
       }
   }
}
function getdefaultItem()
{
    var selph = document.getElementById("selitemph");
    var hpch = document.getElementById("hpch");
    if(hpch.value=="") return;
    if(selph.value=="") return;
    var request = getXmlHttpRequest();
    var url = "LogincAjax.aspx?TYPE=27&pch="+encodeURI(hpch.value)+"&ph="+selph.value;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
          window.alert("数据访问失败，请重试！");
          return false;
    }
    else 
    {
         return   result;     
    } 
}
function getdefaultSx()
{
    var hpch=document.getElementById("hpch");
    if(hpch.value=="") return;
    var request = getXmlHttpRequest();
    var url = "LogincAjax.aspx?TYPE=28&pch="+encodeURI(hpch.value);
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
          window.alert("数据访问失败，请重试！");
          return false;
    }
    else 
    {
         return   result;     
    } 
}