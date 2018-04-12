// JScript 文件

/*显示或隐藏编辑信息*/
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
function AddNewRole() 
{
	var btnNewRole = document.getElementById("btnNewRole");
	var tblNewRole = document.getElementById("tblNewRole");
	var HidNewRole = document.getElementById("HidNewRole");
	if(tblNewRole.style.display == "block")
	{
		btnNewRole.src = "../../images/icon/expand.gif";
		btnNewRole.alt = "展开";
		tblNewRole.style.display = "none";
		HidNewRole.value= "none";
	}
	else
	{
		btnNewRole.src = "../../images/icon/collapse.gif";
		btnNewRole.alt = "关闭";
		tblNewRole.style.display = "block";
		HidNewRole.value = "block";
	}	
}

//选中ZKDH复选框时运行的操作
function GetZKDH()
{
    var hidZKDH=document.getElementById("hidZKDH");
    var chkZKDH=document.getElementById("chkZKDH");
    var drpZKDH=document.getElementById("drpZKDH");
    if(chkZKDH.checked)
    {
        //已经加载过
        if(drpZKDH.options.length>0)
        {
            if(hidZKDH.value!=""&&hidZKDH.value.length>0)
            {
                drpZKDH.value=hidZKDH.value;
            }
            return;
        }
        if(LoadZKDH())
        {
            if(hidZKDH.value!=""&&hidZKDH.value.length>0)
            {
                drpZKDH.value=hidZKDH.value;
            }
            return;
        }
    }
    else
    {
        hidZKDH.value="";
        drpZKDH.options.length = 0;
        drpZKDH.disabled=true;
        drpZKDH.value="";
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载仓库
function LoadZKDH()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=1";
    var drpZKDH=document.getElementById("drpZKDH");
    drpZKDH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        ClearZKDH();
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/ZKDH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpZKDH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpZKDH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空仓库下拉框
function ClearZKDH()
{
    var drpZKDH=document.getElementById("drpZKDH");
	for(var i = 0;i<=drpZKDH.options.length -1;i++)
	{
　　	drpZKDH.remove(i);
　　}
}
//改变仓库号
function ChangeZKDH()
{
    var drpZKDH=document.getElementById("drpZKDH");
    var hidZKDH=document.getElementById("hidZKDH");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpZKDH.value!="请选择")
    {
        hidZKDH.value=drpZKDH.value;
    }
    if(drpZKDH.value=="请选择")
        hidZKDH.value="";
}

//页面加载时需要运行的代码
function LoadAllZKD()
{
    //加载仓库
    var hidZKDH=document.getElementById("hidZKDH");
    var chkZKDH=document.getElementById("chkZKDH");
    if(hidZKDH.value!=null && hidZKDH.value!="" && hidZKDH.value.length>0)
    {
        chkZKDH.checked=true;
        //LoadZKDH();
        GetZKDH();//选中上次选中的项
    }
    
    //加载物料号s
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    if(hidWLH.value!=null && hidWLH.value!="" && hidWLH.value.length>0)
    {
        chkWLH.checked=true;
        //LoadWLH();
        GetWLH();
    } 
    
        //加载属性
    var hidSX=document.getElementById("hidSX");
    var chkSX=document.getElementById("chkSX");
    if(hidSX.value!=null && hidSX.value!="" && hidSX.value.length>0)
    {
        chkSX.checked=true;
        //LoadSX();
        GetSX();
    } 
    
    GetPCH();//加载批次号
    GetFree1();
    GetFree2();
    GetFree3();
    //加载牌号
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    if(hidPH.value!=null && hidPH.value!="" && hidPH.value.length>0)
    {
        chkPH.checked=true;
        //LoadPH();
        GetPH();
    }
   
    //加载规格s
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    if(hidGG.value!=null &&hidGG.value!="" && hidGG.value.length>0)
    {
        chkGG.checked=true;
        //LoadGG();
        GetGG();
    }
    //加载转出仓库
    var hidZCCK=document.getElementById("hidZCCK");
    var chkZCCK=document.getElementById("chkZCCK");
    if(hidZCCK.value!=null && hidZCCK.value!="" && hidZCCK.value.length>0)
    {
        chkZCCK.checked=true;
        //LoadZCCK();
        GetZCCK();
    
    }
    //加载转入仓库
    var hidZRCK=document.getElementById("hidZRCK");
    var chkZRCK=document.getElementById("chkZRCK");
    if(hidZRCK.value!=null && hidZRCK.value!="" && hidZRCK.value.length>0)
    {
        chkZRCK.checked=true;
        //LoadZRCK();
        GetZRCK();
            
    }
    
    //加载车牌号
    var hidCPH=document.getElementById("hidCPH");
    var chkCPH=document.getElementById("chkCPH");
    if(hidCPH.value!=null && hidCPH.value!="" && hidCPH.value.length>0)
    {
        chkCPH.checked=true;
        //LoadCPH();
        GetCPH();
    
    }
        //加载转出状态
    var hidZCZT=document.getElementById("hidZCZT");
    var chkZCZT=document.getElementById("chkZCZT");
    if(hidZCZT.value!=null && hidZCZT.value!="" && hidZCZT.value.length>0)
    {
        chkZCZT.checked=true;
        //LoadZCZT();
        GetZCZT();
    
    }
            //加载转入状态
    var hidZRZT=document.getElementById("hidZRZT");
    var chkZRZT=document.getElementById("chkZRZT");
    if(hidZRZT.value!=null && hidZRZT.value!="" && hidZRZT.value.length>0)
    {
        chkZRZT.checked=true;
        //LoadZRZT();
        GetZRZT();
    
    }
    //转入不等于转出
  var chkBDY=document.getElementById("chkBDY");
  var hidBDY=document.getElementById("hidBDY");
  if(hidBDY.value!=null && hidBDY.value!="")
    {
    chkBDY.checked=true;
    }
    //转出时间
    var chkZCSJ=document.getElementById("chkZCSJ");
    var hidZCSJ=document.getElementById("hidZCSJ");
    var ZCSJ_Start=document.getElementById("ZCSJ_Start");
    var ZCSJ_End=document.getElementById("ZCSJ_End");
    if(hidZCSJ.value!=null && hidZCSJ.value!="" && hidZCSJ.value.length>0)
    {
    chkZCSJ.checked=true;
    ZCSJ_Start.disabled=false;
    ZCSJ_End.disabled=false;
    }
    
    //转入时间
    var chkZRSJ=document.getElementById("chkZRSJ");
    var hidZRSJ=document.getElementById("hidZRSJ");
    var ZRSJ_Start=document.getElementById("ZRSJ_Start");
    var ZRSJ_End=document.getElementById("ZRSJ_End");
    if(hidZRSJ.value!=null && hidZRSJ.value!="" && hidZRSJ.value.length>0)
    {
    chkZRSJ.checked=true;
    ZRSJ_Start.disabled=false;
    ZRSJ_End.disabled=false;
    }
    
  }
  

//选中PCH复选框时运行的操作
function GetPCH()
{
    var chkPCH=document.getElementById("chkPCH");
    var txtPCH=document.getElementById("txtPCH");
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
//选中PCH复选框时运行的操作
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
//选中PCH复选框时运行的操作
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
//选中PCH复选框时运行的操作
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
//加载批次号
function LoadPCH()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=2";
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
        drpPCH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/pch");
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
//清空仓库下拉框
function ClearPCH()
{
    var drpPCH=document.getElementById("drpPCH");
	for(var i = 0;i<=drpPCH.options.length -1;i++)
	{
　　	drpPCH.remove(i);
　　}
}
//改变仓库号
function ChangePCH()
{
    var drpPCH=document.getElementById("drpPCH");
    var hidPCH=document.getElementById("hidPCH");
    var chkPCH=document.getElementById("chkPCH");
 
    if(drpPCH.value!="请选择")
    {
        hidPCH.value=drpPCH.value;
    }
    if(drpPCH.value=="请选择")
        hidPCH.value="";
}
  
  
  //选中WLH复选框时运行的操作
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
        drpWLH.value="";
    }
}
//加载物料号
function LoadWLH()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=3";
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
        ClearWLH();
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/wlh");
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
//清空物料号下拉框
function ClearWLH()
{
    var drpWLH=document.getElementById("drpWLH");
	for(var i = 0;i<=drpWLH.options.length -1;i++)
	{
　　	drpWLH.remove(i);
　　}
}
//改变物料号
function ChangeWLH()
{
    var drpWLH=document.getElementById("drpWLH");
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
 
    if(drpWLH.value!="请选择")
    {
        hidWLH.value=drpWLH.value;
    }
    if(drpWLH.value=="请选择")
        hidWLH.value="";
}


 //选中SX复选框时运行的操作
function GetSX()
{
    var hidSX=document.getElementById("hidSX");
    var chkSX=document.getElementById("chkSX");
    var drpSX=document.getElementById("drpSX");
    if(chkSX.checked)
    {
        //已经加载过
        if(drpSX.options.length>0)
        {
            if(hidSX.value!=""&&hidSX.value.length>0)
            {
                drpSX.value=hidSX.value;
            }
            return;
        }
        if(LoadSX())
        {
            if(hidSX.value!=""&&hidSX.value.length>0)
            {
                drpSX.value=hidSX.value;
            }
            return;
        }
    }
    else
    {
        hidSX.value="";
        drpSX.options.length = 0;
        drpSX.disabled=true;
    }
}
//加载属性
function LoadSX()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=4";
    var drpSX=document.getElementById("drpSX");
    drpSX.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        ClearSX();
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/sx");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpSX.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpSX.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空属性下拉框
function ClearSX()
{
    var drpSX=document.getElementById("drpSX");
	for(var i = 0;i<=drpSX.options.length -1;i++)
	{
　　	drpSX.remove(i);
　　}
}
//改变属性
function ChangeSX()
{
    var drpSX=document.getElementById("drpSX");
    var hidSX=document.getElementById("hidSX");
    var chkSX=document.getElementById("chkSX");
 
    if(drpSX.value!="请选择")
    {
        hidSX.value=drpSX.value;
    }
    if(drpSX.value=="请选择")
        hidSX.value="";
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
        drpPH.value="";
        
    }
}
//加载牌号
function LoadPH()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=5";
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
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/ph");
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
//清空牌号下拉框
function ClearPH()
{
    var drpPH=document.getElementById("drpPH");
	for(var i = 0;i<=drpPH.options.length -1;i++)
	{
　　	drpPH.remove(i);
　　}
}
//改变牌号
function ChangePH()
{
    var drpPH=document.getElementById("drpPH");
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
 
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
//加载规格
function LoadGG()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=6";
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
        drpGG.options.length=0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/gg");
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
//清空规格下拉框
function ClearGG()
{
    var drpGG=document.getElementById("drpGG");
	for(var i = 0;i<=drpGG.options.length -1;i++)
	{
　　	drpGG.remove(i);
　　}
}
//改变规格
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

 //选中ZCCK复选框时运行的操作
function GetZCCK()
{
    var hidZCCK=document.getElementById("hidZCCK");
    var chkZCCK=document.getElementById("chkZCCK");
    var drpZCCK=document.getElementById("drpZCCK");
    if(chkZCCK.checked)
    {
        //已经加载过
        if(drpZCCK.options.length>0)
        {
            if(hidZCCK.value!=""&&hidZCCK.value.length>0)
            {
                drpZCCK.value=hidZCCK.value;
            }
            return;
        }
        if(LoadZCCK())
        {
            if(hidZCCK.value!=""&&hidZCCK.value.length>0)
            {
                drpZCCK.value=hidZCCK.value;
            }
            return;
        }
    }
    else
    {
        hidZCCK.value="";
        drpZCCK.options.length = 0;
        drpZCCK.disabled=true;
    }
}
//加载转出仓库
function LoadZCCK()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=7";
    var drpZCCK=document.getElementById("drpZCCK");
    drpZCCK.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpZCCK.options.length=0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/CKID");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpZCCK.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpZCCK.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空转出仓库下拉框
function ClearZCCK()
{
    var drpZCCK=document.getElementById("drpZCCK");
	for(var i = 0;i<=drpZCCK.options.length -1;i++)
	{
　　	drpZCCK.remove(i);
　　}
}
//改变转出仓库
function ChangeZCCK()
{
    var drpZCCK=document.getElementById("drpZCCK");
    var hidZCCK=document.getElementById("hidZCCK");
 
    if(drpZCCK.value!="请选择")
    {
        hidZCCK.value=drpZCCK.value;
    }
    if(drpZCCK.value=="请选择")
        hidZCCK.value="";
}

 //选中ZRCK复选框时运行的操作
function GetZRCK()
{
    var hidZRCK=document.getElementById("hidZRCK");
    var chkZRCK=document.getElementById("chkZRCK");
    var drpZRCK=document.getElementById("drpZRCK");
    if(chkZRCK.checked)
    {
        //已经加载过
        if(drpZRCK.options.length>0)
        {
            if(hidZRCK.value!=""&&hidZRCK.value.length>0)
            {
                drpZRCK.value=hidZRCK.value;
            }
            return;
        }
        if(LoadZRCK())
        {
            if(hidZRCK.value!=""&&hidZRCK.value.length>0)
            {
                drpZRCK.value=hidZRCK.value;
            }
            return;
        }
    }
    else
    {
        hidZRCK.value="";
        drpZRCK.options.length = 0;
        drpZRCK.disabled=true;
    }
}
//加载转入仓库
function LoadZRCK()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=8";
    var drpZRCK=document.getElementById("drpZRCK");
    drpZRCK.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpZRCK.options.length=0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/CKID");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpZRCK.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpZRCK.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空转入仓库下拉框
function ClearZRCK()
{
    var drpZRCK=document.getElementById("drpZRCK");
	for(var i = 0;i<=drpZRCK.options.length -1;i++)
	{
　　	drpZRCK.remove(i);
　　}
}
//改变转入仓库
function ChangeZRCK()
{
    var drpZRCK=document.getElementById("drpZRCK");
    var hidZRCK=document.getElementById("hidZRCK");
 
    if(drpZRCK.value!="请选择")
    {
        hidZRCK.value=drpZRCK.value;
    }
    if(drpZRCK.value=="请选择")
        hidZRCK.value="";
}

 //选中CPH复选框时运行的操作
function GetCPH()
{
    var hidCPH=document.getElementById("hidCPH");
    var chkCPH=document.getElementById("chkCPH");
    var drpCPH=document.getElementById("drpCPH");
    if(chkCPH.checked)
    {
        //已经加载过
        if(drpCPH.options.length>0)
        {
            if(hidCPH.value!=""&&hidCPH.value.length>0)
            {
                drpCPH.value=hidCPH.value;
            }
            return;
        }
        if(LoadCPH())
        {
            if(hidCPH.value!=""&&hidCPH.value.length>0)
            {
                drpCPH.value=hidCPH.value;
            }
            return;
        }
    }
    else
    {
        hidCPH.value="";
        drpCPH.options.length = 0;
        drpCPH.disabled=true;
        drpCPH.value="";
    }
}
//加载车牌号
function LoadCPH()
{
    var request=getXmlHttpRequest();
    var url="loadZKD.aspx?TYPE=9";
    var drpCPH=document.getElementById("drpCPH");
    drpCPH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpCPH.options.length=0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/CPH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpCPH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpCPH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空车牌号下拉框
function ClearCPH()
{
    var drpCPH=document.getElementById("drpCPH");
	for(var i = 0;i<=drpCPH.options.length -1;i++)
	{
　　	drpCPH.remove(i);
　　}
}
//改变车牌号
function ChangeCPH()
{
    var drpCPH=document.getElementById("drpCPH");
    var hidCPH=document.getElementById("hidCPH");
 
    if(drpCPH.value!="请选择")
    {
        hidCPH.value=drpCPH.value;
    }
    if(drpCPH.value=="请选择")
        hidCPH.value="";
} 

//获取转出状态
function GetZCZT()
{
    var chkZCZT=document.getElementById("chkZCZT");
    var drpZCZT=document.getElementById("drpZCZT");
    var hidZCZT=document.getElementById("hidZCZT");

    if(chkZCZT.checked)
    {

        //已经加载过
        if(drpZCZT.options.length>0)
        {
            if(hidZCZT.value!=""&&hidZCZT.value.length>0)
            {
                drpZCZT.value=hidZCZT.value;
            }
            return;
        }
        LoadZCZT()
        if(hidZCZT.value!=""&&hidZCZT.value.length>0)
        {
            drpZCZT.value=hidZCZT.value;
        }
        return;
    }
    else
    {
        hidZCZT.value="";
        drpZCZT.options.length = 0;
        drpZCZT.disabled=true;

    }
}
//生成转出状态
function LoadZCZT()
{
 
    var drpZCZT=document.getElementById("drpZCZT");
    drpZCZT.disabled=false;
    drpZCZT.options.length = 0;
    var varItem0=new Option("请选择","-1");
    drpZCZT.options.add(varItem0); 
    var varItem1=new Option("未转出","0");
    drpZCZT.options.add(varItem1); 
    var varItem2=new Option("转出完毕","1");
    drpZCZT.options.add(varItem2); 

}
//改变转出状态
function ChangeZCZT()
{
    var drpZCZT=document.getElementById("drpZCZT");
    var hidZCZT=document.getElementById("hidZCZT");
    if(drpZCZT.value!="请选择")
    {
        hidZCZT.value=drpZCZT.value;
    }
    if(drpZCZT.value=="请选择")
        hidZCZT.value="";

}

//获取转入状态
function GetZRZT()
{
    var chkZRZT=document.getElementById("chkZRZT");
    var drpZRZT=document.getElementById("drpZRZT");
    var hidZRZT=document.getElementById("hidZRZT");

    if(chkZRZT.checked)
    {

        //已经加载过
        if(drpZRZT.options.length>0)
        {
            if(hidZRZT.value!=""&&hidZRZT.value.length>0)
            {
                drpZRZT.value=hidZRZT.value;
            }
            return;
        }
        LoadZRZT()
        if(hidZRZT.value!=""&&hidZRZT.value.length>0)
        {
            drpZRZT.value=hidZRZT.value;
        }
        return;
    }
    else
    {
        hidZRZT.value="";
        drpZRZT.options.length = 0;
        drpZRZT.disabled=true;

    }
}
//生成转入状态
function LoadZRZT()
{
 
    var drpZRZT=document.getElementById("drpZRZT");
    drpZRZT.disabled=false;
    drpZRZT.options.length = 0;
    var varItem0=new Option("请选择","-1");
    drpZRZT.options.add(varItem0); 
    var varItem1=new Option("未转入","0");
    drpZRZT.options.add(varItem1); 
    var varItem2=new Option("转入完毕","1");
    drpZRZT.options.add(varItem2); 

}
//改变转入状态
function ChangeZRZT()
{
    var drpZRZT=document.getElementById("drpZRZT");
    var hidZRZT=document.getElementById("hidZRZT");
    if(drpZRZT.value!="请选择")
    {
        hidZRZT.value=drpZRZT.value;
    }
    if(drpZRZT.value=="请选择")
        hidZRZT.value="";

}   
//转入不等于转出
function GetBDY()
{
  var chkBDY=document.getElementById("chkBDY");
  var hidBDY=document.getElementById("hidBDY");
    if(chkBDY.checked)
    {
        hidBDY.value="true";
    }
    else
    {
        hidBDY.value="";
    }
} 
//模糊ph
function GetMOHU()
{
    var chkMOHU=document.getElementById("chkMOHU");
    var hidMOHU=document.getElementById("hidMOHU");
    if(chkMOHU.checked)
    {
        hidMOHU.value="true";
    }
    else
    {
        hidMOHU.value="";
    }
}  

//转出时间
function GetZCSJ()
{
    var chkZCSJ=document.getElementById("chkZCSJ");
    var hidZCSJ=document.getElementById("hidZCSJ");
    var ZCSJ_Start=document.getElementById("ZCSJ_Start");
    var ZCSJ_End=document.getElementById("ZCSJ_End");
    if(chkZCSJ.checked)
    {
        hidZCSJ.value=true;
        ZCSJ_Start.disabled=false;
        ZCSJ_End.disabled=false;
     }
     else
     {
       hidZCSJ.value="";
        ZCSJ_Start.disabled=true;
        ZCSJ_End.disabled=true;
        
     }

}
//转入时间
function GetZRSJ()
{
var chkZRSJ=document.getElementById("chkZRSJ");
    var hidZRSJ=document.getElementById("hidZRSJ");
    var ZRSJ_Start=document.getElementById("ZRSJ_Start");
    var ZRSJ_End=document.getElementById("ZRSJ_End");
    if(chkZRSJ.checked)
    {
        hidZRSJ.value=true;
        ZRSJ_Start.disabled=false;
        ZRSJ_End.disabled=false;
     }
     else
     {
       hidZRSJ.value="";
        ZRSJ_Start.disabled=true;
        ZRSJ_End.disabled=true;
        
     }
}
function AutomateExcel(tb)
{
    var djlistf=document.getElementById(tb);
    if(djlistf==null)
    {
       alert("没有数据");
       return;
    }
    if(djlistf.rows.length<=1)
    {
       alert("没有数据");
       return;
    }
    try
    {
        var oXL = new ActiveXObject("Excel.Application"); //创建应该对象  
    }
    catch(err)
    {
       alert("没有安装excel或者IE安全性设置不允许使用Active");
       return;
    }
    var oWB = oXL.Workbooks.Add();//新建一个Excel工作簿
    var oSheet = oWB.ActiveSheet;//指定要写入内容的工作表为活动工作表
    var table = djlistf;//指定要写入的数据源的id
    var hang = table.rows.length;//取数据源行数
    var lie = table.rows(0).cells.length;//取数据源列数

// Add table headers going cell by cell.
    for (i=0;i<hang;i++)
    {//在Excel中写行
        for (j=0;j<lie;j++)
        {//在Excel中写列
//定义格式
            oSheet.Cells(i+1,j+1).NumberFormatLocal = "@";
//!!!!!!!上面这一句是将单元格的格式定义为文本
            oSheet.Cells(i+1,j+1).Font.Bold = false;//加粗
            oSheet.Cells(i+1,j+1).Font.Size = 10;//字体大小
            oSheet.Cells(i+1,j+1).value = table.rows(i).cells(j).innerText;//向单元格写入值
        }
     }
     oXL.Visible = true;
     oXL.UserControl = true;
}
function imgBtnExcel_Click() {
    var zkdlisttb=document.getElementById("grdGridList");
    if (zkdlisttb==null) {
       return;
    }
    AutomateExcel("grdGridList");
}
//察看转库单明细
function GetZKDItem()
{
    var iFrame=document.getElementById("frmList");
     var e = event.srcElement;
    var cheStatus=e.checked;
    
    var e = event.srcElement;
    var td = e.parentNode;
    var tr=td.parentNode;
    var table=tr.parentNode;
    var inputs=table.all.tags("INPUT");
    var hidchong=document.getElementById("hidchong");//转入状态
    var hidzcsl=document.getElementById("hidzcsl");//转出数量
    var hidzrsl=document.getElementById("hidzrsl");//转入数量
    var hidjhsl=document.getElementById("hidjhsl");//计划数量
    var chongzhi=document.getElementById("chongzhi");//重置按钮显示
    var hidzhdh1=document.getElementById("hidzhdh1");//转库单号
    var hidOUTT=document.getElementById("hidOUTT");//转出状态
    var hidPROCPCH=document.getElementById("hidPROCPCH");//批次号
    var hidPROCSX=document.getElementById("hidPROCSX");//属性
    
	var btnQuery = document.getElementById("btnQuery");
	var chazhao = document.getElementById("chazhao");
	var hidQuery = document.getElementById("hidQuery");
	
	var btnItem = document.getElementById("btnItem");
	var tblPList= document.getElementById("tblPList");
	var hidItem = document.getElementById("hidItem");

		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		chazhao.style.display = "none";
		hidQuery.value= "none";
		
        btnItem.src = "../../images/icon/collapse.gif";
		btnItem.alt = "关闭";
		tblPList.style.display = "block";
		hidItem.value = "block";	
	if(cheStatus)
    {
    for(var i=0;i<inputs.length;i++)
    {
        if(inputs[i].type == "checkbox")
        {
            inputs[i].checked=false;
        }
    }
    e.checked=true;
    var tds=tr.all.tags("td");
    var inputs2=tr.all.tags("INPUT"); 
    var strZKDH= inputs2[1].value;
    hidzhdh1.value=inputs2[1].value;//转库单号
    hidchong.value=inputs2[2].value;//转入状态
    hidOUTT.value=inputs2[3].value;//转出状态
    hidzcsl.value=inputs2[4].value;  //转出数量
    hidzrsl.value=inputs2[5].value;//转入数量   
    hidjhsl.value=inputs2[6].value;//计划数量
    hidPROCPCH.value=inputs2[7].value;//获取PCH
    hidPROCSX.value=inputs2[8].value;//获取SX

//    chongzhi.style.display="block";
    iFrame.src="ZKDItems.aspx?action=item&ZKDH="+strZKDH;
    }
}
//重置
function GetChongzhi()
{
    var hidchong=document.getElementById("hidchong");//转入状态
      var hidzhdh1=document.getElementById("hidzhdh1");//转库单号
    var hidzcsl=document.getElementById("hidzcsl");//转出数量
    var hidzrsl=document.getElementById("hidzrsl");//转入数量
    var hidjhsl=document.getElementById("hidjhsl");//计划数量
    var hidPROCPCH=document.getElementById("hidPROCPCH");//批次号
    var hidPROCSX=document.getElementById("hidPROCSX");//属性
    if(hidchong.value=="")
    {
    alert('未选定可用的单据');
    return false;
    }
    if (hidchong.value=="False")
    {
    alert("本单据尚未转入完毕，不需要重置!");
    return false;
    }
    if(hidzcsl.value==hidzrsl.value&& hidzrsl.value==hidjhsl.value)
    {
    alert("转入数据、转出数量与计划数量相等，您不需要重置该单据处于可转入状态！");
    return false;
    }
    if(!confirm("您是否要确认重置转库单吗？"))
    {
    return false;
    }
    url="loadZKD.aspx?type=chongzhi&ZKDH="+hidzhdh1.value+"&PCH="+hidPROCPCH.value+"&SX="+encodeURI(hidPROCSX.value);
    //alert(url);
    var request=getXmlHttpRequest();
    sendRequest(url,"","POST",request); 
    var result = request.responseText;
    if(result=="success")
    {
    alert("单据重置完毕，现在可以重新进行转入操作！");
    return false;
    }
    if(result=="wrongcz")
    {
     alert("数据库操作错误，单据重置失败！");
     return false;
    }
}
//关闭单据
function Closedanju()
{
    var hidzhdh1=document.getElementById("hidzhdh1");//转库单号
   var hidOUTT=document.getElementById("hidOUTT");//转出状态
    if(hidzhdh1.value=="")
   {
        alert("请先选择要关闭的转库单");
        return false;
   }
   if(hidOUTT.value=="True")
   {
        alert("该单据已经被执行，不能关闭");
        return false;
   }
   if(!confirm("是否要关闭该单据?"))
    {
    return false;
    }
    url="loadZKD.aspx?type=closedj&ZKDH="+hidzhdh1.value;
   //window.location=url;
    //alert(url);
    var request=getXmlHttpRequest();
    sendRequest(url,"","POST",request); 
    var result = request.responseText;
    if(result=="close")
    {
    alert("单据已关闭!");
    }
    
}

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

/*显示或隐藏查询条件*/
function chazhao1() 
{
	var btnQuery = document.getElementById("btnQuery");
	var chazhao = document.getElementById("chazhao");
	var hidQuery = document.getElementById("hidQuery");
	
	var btnconfig = document.getElementById("btnconfig");
	var tablecon = document.getElementById("tablecon");
	var Hidconfig = document.getElementById("Hidconfig");
	
	if(Hidconfig.value=="block")
	{
	tablecon.style.display="none";
	btnconfig.src = "../../images/icon/expand.gif";
	btnconfig.alt = "展开";
	Hidconfig.value= "none";
	}
	
	if(chazhao.style.display == "block")
	{
		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		chazhao.style.display = "none";
		hidQuery.value= "none";
	}
	else
	{
		btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
		chazhao.style.display = "block";
		hidQuery.value = "block";
	}
	
}

/*显示或者隐藏列表配置*/
function Addconfig() 
{
	var btnconfig = document.getElementById("btnconfig");
	var tablecon = document.getElementById("tablecon");
	var Hidconfig = document.getElementById("Hidconfig");
	
	var hidQuery = document.getElementById("hidQuery");
	var btnQuery = document.getElementById("btnQuery");
	var chazhao = document.getElementById("chazhao");
	if(hidQuery.value=="block")
	{
	chazhao.style.display="none";
	btnQuery.src = "../../images/icon/expand.gif";
	btnQuery.alt = "展开";
	hidQuery.value= "none";
	}
	if(tablecon.style.display ==  "block")
	{
		btnconfig.src = "../../images/icon/expand.gif";
		btnconfig.alt = "展开";
		tablecon.style.display = "none";
		Hidconfig.value= "none";
	}
	else
	{
		btnconfig.src = "../../images/icon/collapse.gif";
		btnconfig.alt = "关闭";
		tablecon.style.display = "block";
		Hidconfig.value= "block";
	}
}
/*显示或者隐藏明细*/
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
/*页面初始化查询*/
function Init()
{
	var chazhao = document.getElementById("chazhao");
	var hidQuery = document.getElementById("hidQuery");
	
    var tablecon = document.getElementById("tablecon");
    var Hidconfig = document.getElementById("Hidconfig");
    
    var tblPList= document.getElementById("tblPList");
	var hidItem = document.getElementById("hidItem");
/*	window.alert(HidBase.value); 调试用的*/
	if(hidQuery.value!="")
	{
		chazhao.style.display = "none";
		if( hidQuery.value== "none")
			chazhao.style.display = "block";
		chazhao1();
	}
	
	if(Hidconfig.value!="")
	{
		tablecon.style.display = "none";
		if( Hidconfig.value== "none")
			tablecon.style.display = "block";
		Addconfig();
	}
	
	if(hidItem.value!="")
	{
		tblPList.style.display = "none";
		if( hidItem.value== "none")
			tblPList.style.display = "block";
		AddItems();
	}
	 LoadAllZKD();
}

