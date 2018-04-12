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

	    load_AllKUCUN();
}

function load_AllKUCUN()
{
    //加载仓库
    var hidCK=document.getElementById("hidCK");
    var chkCK=document.getElementById("chkCK");
    if(hidCK.value!="" && hidCK.value!=null && hidCK.value.length>0)
    {
        chkCK.checked=true;
        GetCK();
    }
    //加载属性
    var hidRKSX=document.getElementById("hidRKSX");
    var chkRKSX=document.getElementById("chkRKSX");
    var drpRKSX=document.getElementById("drpRKSX");
    if(hidRKSX.value!="" && hidRKSX.value!=null && hidRKSX.value.length>0)
    {
        chkRKSX.checked=true;
        GetRKSX();
    }
    //牌号
    var hidRKPH=document.getElementById("hidRKPH");
    var chkRKPH=document.getElementById("chkRKPH");
    var drpRKPH=document.getElementById("drpRKPH");
    if(chkRKPH.checked==true)
    {
        LoadRKPH();
        drpRKPH.value = hidRKPH.value;
    }
            //加载规格
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    var hidCopyGG=document.getElementById("hidCopyGG")
    if((chkGG.checked))
    {
        GetGG();//选中上次选中的项
        GetCopyGG();
    }

    //特殊信息
        var hidTSXX=document.getElementById("hidTSXX");
    var chkTSXX=document.getElementById("chkTSXX");
    var drpTSXX=document.getElementById("drpTSXX");
    if(hidTSXX.value!="" && hidTSXX.value!=null && hidTSXX.value.length>0)
    {
        chkTSXX.checked=true;
        GetTSXX();
    }
    //入库日期
        var chkRKRQ=document.getElementById("chkRKRQ");
    var hidRKRQ=document.getElementById("hidRKRQ");
    var RKRQ_Start=document.getElementById("RKRQ_Start");
    var RKRQ_End=document.getElementById("RKRQ_End");
      if(hidRKRQ.value!=null && hidRKRQ.value!="" && hidRKRQ.value.length>0)
    {
        chkRKRQ.checked=true;
        RKRQ_Start.disabled=false;
        RKRQ_End.disabled=false;
     }
    //称重日期
    var chkWRQ=document.getElementById("chkWRQ");
    var hidWRQ=document.getElementById("hidWRQ");
    var txtWRQfrom=document.getElementById("txtWRQfrom");
    var txtWRQto=document.getElementById("txtWRQto");
    if(hidWRQ.value!=null && hidWRQ.value!="" && hidWRQ.value.length>0)
    {
        chkWRQ.checked=true;
        txtWRQfrom.disabled=false;
        txtWRQto.disabled=false;
     }
     
    var chkHW=document.getElementById("chkHW");
    var txtHW=document.getElementById("txtHW");
    if(chkHW.checked==false)
    {
        txtHW.readOnly = true;
    }
    var chkrkpch=document.getElementById("chkrkpch");
    var txtPCH=document.getElementById("txtPCH");
    if(chkrkpch.checked==false)
    {
        txtPCH.readOnly = true;
    }
    var chkTM=document.getElementById("chkTM");
    var txtBarcode=document.getElementById("txtBarcode");
    if(chkTM.checked==false)
    {
        txtBarcode.readOnly = true;
    }
    var chkWLH=document.getElementById("chkWLH");
    var txtWLH=document.getElementById("txtWLH");
    if(chkWLH.checked==false)
    {
        txtWLH.readOnly = true;
    }
    var chkFree1=document.getElementById("chkFree1");
    var txtFree1=document.getElementById("txtFree1");
    if(chkFree1.checked==false)
    {
        txtFree1.readOnly = true;
    }
    var chkFree2=document.getElementById("chkFree2");
    var txtFree2=document.getElementById("txtFree2");
    if(chkFree2.checked==false)
    {
        txtFree2.readOnly = true;
    }
   var chkFree3=document.getElementById("chkFree3");
    var txtFree3=document.getElementById("txtFree3");
    if(chkFree3.checked==false)
    {
        txtFree3.readOnly = true;
    }
}


////选中CK复选框时运行的操作
function GetCK()
{
    var hidCK=document.getElementById("hidCK");
    var chkCK=document.getElementById("chkCK");
    var drpCK=document.getElementById("drpCK");
    if(chkCK.checked)
    {
        //已经加载过
        if(drpCK.options.length>0)
        {
            if(hidCK.value!=""&&hidCK.value.length>0)
            {
                drpCK.value=hidCK.value;
            }
            return;
        }
        if(LoadCK())
        {
            if(hidCK.value!=""&&hidCK.value.length>0)
            {
                drpCK.value=hidCK.value;
            }
            return;
        }
    }
    else
    {
        hidCK.value="";
        drpCK.options.length = 0;
        drpCK.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载仓库
function LoadCK()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=1";
    var drpCK=document.getElementById("drpCK");
    drpCK.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpCK.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/CKID");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpCK.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpCK.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空仓库下拉框
function ClearCK()
{
    var drpCK=document.getElementById("drpCK");
	for(var i = 0;i<=drpCK.options.length -1;i++)
	{
　　	drpCK.remove(i);
　　}
}
//改变仓库号
function ChangeCK()
{
    var drpCK=document.getElementById("drpCK");
    var hidCK=document.getElementById("hidCK");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpCK.value!="请选择")
    {
        hidCK.value=drpCK.value;
    }
    if(drpCK.value=="请选择")
        hidCK.value="";
}

function HWread()
{
    var txtHW = document.getElementById("txtHW");
    var chkHW = document.getElementById("chkHW");
    if(chkHW.checked)
    {
        txtHW.readOnly = false;
    }
    else
    {
        txtHW.value = "";
        txtHW.readOnly = true;
    }
}








//选中RKSX复选框时运行的操作
function GetRKSX()
{
    var hidRKSX=document.getElementById("hidRKSX");
    var chkRKSX=document.getElementById("chkRKSX");
    var drpRKSX=document.getElementById("drpRKSX");
    if(chkRKSX.checked)
    {
        //已经加载过
        if(drpRKSX.options.length>0)
        {
            if(hidRKSX.value!=""&&hidRKSX.value.length>0)
            {
                drpRKSX.value=hidRKSX.value;
            }
            return;
        }
        if(LoadRKSX())
        {
            if(hidRKSX.value!=""&&hidRKSX.value.length>0)
            {
                drpRKSX.value=hidRKSX.value;
            }
            return;
        }
    }
    else
    {
        hidRKSX.value="";
        drpRKSX.options.length = 0;
        drpRKSX.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载属性
function LoadRKSX()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=4";
    var drpRKSX=document.getElementById("drpRKSX");
    drpRKSX.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
         drpRKSX.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/SX");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpRKSX.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpRKSX.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空属性下拉框
function ClearRKSX()
{
    var drpRKSX=document.getElementById("drpRKSX");
	for(var i = 0;i<=drpRKSX.options.length -1;i++)
	{
　　	drpRKSX.remove(i);
　　}
}
//改变属性号
function ChangeRKSX()
{
    var drpRKSX=document.getElementById("drpRKSX");
    var hidRKSX=document.getElementById("hidRKSX");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpRKSX.value!="请选择")
    {
        hidRKSX.value=drpRKSX.value;
    }
    if(drpRKSX.value=="请选择")
        hidRKSX.value="";
}

//选中HW复选框时运行的操作
function GetHW()
{
    var hidHW=document.getElementById("hidHW");
    var chkHW=document.getElementById("chkHW");
    var drpHW=document.getElementById("drpHW");
    if(chkHW.checked)
    {
        //已经加载过
        if(drpHW.options.length>0)
        {
            if(hidHW.value!=""&&hidHW.value.length>0)
            {
                drpHW.value=hidHW.value;
            }
            return;
        }
        if(LoadHW())
        {
            if(hidHW.value!=""&&hidHW.value.length>0)
            {
                drpHW.value=hidHW.value;
            }
            return;
        }
    }
    else
    {
        hidHW.value="";
        drpHW.options.length = 0;
        drpHW.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载属性
function LoadHW()
{
    var request=getXmlHttpRequest();
    var hidCK=document.getElementById("hidCK");
    var url="loadKuCun.aspx?TYPE=2&ck="+hidCK.value;
    var drpHW=document.getElementById("drpHW");
    drpHW.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpHW.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/HW");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpHW.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpHW.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空属性下拉框
function ClearHW()
{
    var drpHW=document.getElementById("drpHW");
	for(var i = 0;i<=drpHW.options.length -1;i++)
	{
　　	drpHW.remove(i);
　　}
}
//改变属性号
function ChangeHW()
{
    var drpHW=document.getElementById("drpHW");
    var hidHW=document.getElementById("hidHW");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpHW.value!="请选择")
    {
        hidHW.value=drpHW.value;
    }
    if(drpHW.value=="请选择")
        hidHW.value="";
}

//选中RKPH复选框时运行的操作
function GetRKPH()
{
    var hidRKPH=document.getElementById("hidRKPH");
    var chkRKPH=document.getElementById("chkRKPH");
    var drpRKPH=document.getElementById("drpRKPH");
    if(chkRKPH.checked)
    {
        //已经加载过
        if(drpRKPH.options.length>0)
        {
            if(hidRKPH.value!=""&&hidRKPH.value.length>0)
            {
                drpRKPH.value=hidRKPH.value;
            }
            return;
        }
        if(LoadRKPH())
        {
            if(hidRKPH.value!=""&&hidRKPH.value.length>0)
            {
                drpRKPH.value=hidRKPH.value;
            }
            return;
        }
    }
    else
    {
        hidRKPH.value="";
        drpRKPH.options.length = 0;
        drpRKPH.disabled=true;
        drpRKPH.value = "";
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载属性
function LoadRKPH()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=8";
    var drpRKPH=document.getElementById("drpRKPH");
    drpRKPH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpRKPH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/PH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpRKPH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpRKPH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空属性下拉框
function ClearRKPH()
{
    var drpRKPH=document.getElementById("drpRKPH");
	for(var i = 0;i<=drpRKPH.options.length -1;i++)
	{
　　	drpRKPH.remove(i);
　　}
}
//改变属性号
function ChangeRKPH()
{
    var drpRKPH=document.getElementById("drpRKPH");
    var hidRKPH=document.getElementById("hidRKPH");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpRKPH.value!="请选择")
    {
        hidRKPH.value=drpRKPH.value;
    }
    if(drpRKPH.value=="请选择")
        hidRKPH.value="";
}
//选中RKPCH复选框时运行的操作
function GetRKPCH()
{
    var chkRKPCH=document.getElementById("chkRKPCH");
    var txtPCH=document.getElementById("txtPCH");
    if(chkRKPCH.checked)
    {
        txtPCH.readOnly = false;
    }
    else
    {
        txtPCH.value = "";
        txtPCH.readOnly = true;
    }
}
//加载批次
function LoadRKPCH()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=3";
    var drpRKPCH=document.getElementById("drpRKPCH");
    drpRKPCH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpRKPCH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/PCH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpRKPCH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpRKPCH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空批次下拉框
function ClearRKPCH()
{
    var drpRKPCH=document.getElementById("drpRKPCH");
	for(var i = 0;i<=drpRKPCH.options.length -1;i++)
	{
　　	drpRKPCH.remove(i);
　　}
}
//改变批次号
function ChangeRKPCH()
{
    var drpRKPCH=document.getElementById("drpRKPCH");
    var hidRKPCH=document.getElementById("hidRKPCH");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpRKPCH.value!="请选择")
    {
        hidRKPCH.value=drpRKPCH.value;
    }
    if(drpRKPCH.value=="请选择")
        hidRKPCH.value="";
}
//选中RKGG复选框时运行的操作
function GetRKGG()
{
    var hidRKGG=document.getElementById("hidRKGG");
    var chkRKGG=document.getElementById("chkRKGG");
    var drpRKGG=document.getElementById("drpRKGG");
    if(chkRKGG.checked)
    {
        //已经加载过
        if(drpRKGG.options.length>0)
        {
            if(hidRKGG.value!=""&&hidRKGG.value.length>0)
            {
                drpRKGG.value=hidRKGG.value;
            }
            return;
        }
        if(LoadRKGG())
        {
            if(hidRKGG.value!=""&&hidRKGG.value.length>0)
            {
                drpRKGG.value=hidRKGG.value;
            }
            return;
        }
    }
    else
    {
        hidRKGG.value="";
        drpRKGG.options.length = 0;
        drpRKGG.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载规格
function LoadRKGG()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=6";
    var drpRKGG=document.getElementById("drpRKGG");
    drpRKGG.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
         drpRKGG.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/GG");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpRKGG.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpRKGG.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空规格下拉框
function ClearRKGG()
{
    var drpRKGG=document.getElementById("drpRKGG");
	for(var i = 0;i<=drpRKGG.options.length -1;i++)
	{
　　	drpRKGG.remove(i);
　　}
}
//改变规格号
function ChangeRKGG()
{
    var drpRKGG=document.getElementById("drpRKGG");
    var hidRKGG=document.getElementById("hidRKGG");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpRKGG.value!="请选择")
    {
        hidRKGG.value=drpRKGG.value;
    }
    if(drpRKGG.value=="请选择")
        hidRKGG.value="";
}
//加载物料
function LoadWLH()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=7";
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
//清空物料下拉框
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
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpWLH.value!="请选择")
    {
        hidWLH.value=drpWLH.value;
    }
    if(drpWLH.value=="请选择")
        hidWLH.value="";
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
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载车号
function LoadCPH()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=8";
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
        drpCPH.options.length = 0;
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
//清空车号下拉框
function ClearCPH()
{
    var drpCPH=document.getElementById("drpCPH");
	for(var i = 0;i<=drpCPH.options.length -1;i++)
	{
　　	drpCPH.remove(i);
　　}
}
//改变车号
function ChangeCPH()
{
    var drpCPH=document.getElementById("drpCPH");
    var hidCPH=document.getElementById("hidCPH");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpCPH.value!="请选择")
    {
        hidCPH.value=drpCPH.value;
    }
    if(drpCPH.value=="请选择")
        hidCPH.value="";
}

//选中RKType复选框时运行的操作
function GetRKType()
{
    var hidRKType=document.getElementById("hidRKType");
    var chkRKType=document.getElementById("chkRKType");
    var drpRKType=document.getElementById("drpRKType");
    if(chkRKType.checked)
    {
        //已经加载过
        if(drpRKType.options.length>0)
        {
            if(hidRKType.value!=""&&hidRKType.value.length>0)
            {
                drpRKType.value=hidRKType.value;
            }
            return;
        }
        if(LoadRKType())
        {
            if(hidRKType.value!=""&&hidRKType.value.length>0)
            {
                drpRKType.value=hidRKType.value;
            }
            return;
        }
    }
    else
    {
        hidRKType.value="";
        drpRKType.options.length = 0;
        drpRKType.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载入库类型
function LoadRKType()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=9";
    var drpRKType=document.getElementById("drpRKType");
    drpRKType.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpRKType.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/RKType");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpRKType.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpRKType.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空入库类型下拉框
function ClearRKType()
{
    var drpRKType=document.getElementById("drpRKType");
	for(var i = 0;i<=drpRKType.options.length -1;i++)
	{
　　	drpRKType.remove(i);
　　}
}
//改变入库类型
function ChangeRKType()
{
    var drpRKType=document.getElementById("drpRKType");
    var hidRKType=document.getElementById("hidRKType");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpRKType.value!="请选择")
    {
        hidRKType.value=drpRKType.value;
    }
    if(drpRKType.value=="请选择")
        hidRKType.value="";
}
//选中RKscx复选框时运行的操作
function GetRKscx()
{
    var hidRKscx=document.getElementById("hidRKscx");
    var chkRKscx=document.getElementById("chkRKscx");
    var drpRKscx=document.getElementById("drpRKscx");
    if(chkRKscx.checked)
    {
        //已经加载过
        if(drpRKscx.options.length>0)
        {
            if(hidRKscx.value!=""&&hidRKscx.value.length>0)
            {
                drpRKscx.value=hidRKscx.value;
            }
            return;
        }
        if(LoadRKscx())
        {
            if(hidRKscx.value!=""&&hidRKscx.value.length>0)
            {
                drpRKscx.value=hidRKscx.value;
            }
            return;
        }
    }
    else
    {
        hidRKscx.value="";
        drpRKscx.options.length = 0;
        drpRKscx.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载入库类型
function LoadRKscx()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=10";
    var drpRKscx=document.getElementById("drpRKscx");
    drpRKscx.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
       drpRKscx.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/scxbm");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpRKscx.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpRKscx.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空入库类型下拉框
function ClearRKscx()
{
    var drpRKscx=document.getElementById("drpRKscx");
	for(var i = 0;i<=drpRKscx.options.length -1;i++)
	{
　　	drpRKscx.remove(i);
　　}
}
//改变入库类型
function ChangeRKscx()
{
    var drpRKscx=document.getElementById("drpRKscx");
    var hidRKscx=document.getElementById("hidRKscx");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpRKscx.value!="请选择")
    {
        hidRKscx.value=drpRKscx.value;
    }
    if(drpRKscx.value=="请选择")
        hidRKscx.value="";
}

//选中BB复选框时运行的操作
function GetBB()
{
    var hidBB=document.getElementById("hidBB");
    var chkBB=document.getElementById("chkBB");
    var drpBB=document.getElementById("drpBB");
    if(chkBB.checked)
    {
        //已经加载过
        if(drpBB.options.length>0)
        {
            if(hidBB.value!=""&&hidBB.value.length>0)
            {
                drpBB.value=hidBB.value;
            }
            return;
        }
        if(LoadBB())
        {
            if(hidBB.value!=""&&hidBB.value.length>0)
            {
                drpBB.value=hidBB.value;
            }
            return;
        }
    }
    else
    {
        hidBB.value="";
        drpBB.options.length = 0;
        drpBB.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载入库类型
function LoadBB()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=11";
    var drpBB=document.getElementById("drpBB");
    drpBB.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpBB.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/bb");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpBB.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpBB.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空入库类型下拉框
function ClearBB()
{
    var drpBB=document.getElementById("drpBB");
	for(var i = 0;i<=drpBB.options.length -1;i++)
	{
　　	drpBB.remove(i);
　　}
}
//改变入库类型
function ChangeBB()
{
    var drpBB=document.getElementById("drpBB");
    var hidBB=document.getElementById("hidBB");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpBB.value!="请选择")
    {
        hidBB.value=drpBB.value;
    }
    if(drpBB.value=="请选择")
        hidBB.value="";
}

//选中TSXX复选框时运行的操作
function GetTSXX()
{
    var hidTSXX=document.getElementById("hidTSXX");
    var chkTSXX=document.getElementById("chkTSXX");
    var drpTSXX=document.getElementById("drpTSXX");
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
        drpTSXX.value = "";
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载入库类型
function LoadTSXX()
{
    var request=getXmlHttpRequest();
    var hidCK=document.getElementById("hidCK");
    var txtPCH=document.getElementById("txtPCH");
    var hidRKSX=document.getElementById("hidRKSX");
    var txtWLH=document.getElementById("txtWLH");
    var txtHW=document.getElementById("txtHW");
    var url="loadKuCun.aspx?TYPE=6&ck="+hidCK.value+"&pch="+txtPCH.value+"&sx="+hidRKSX.value+"&wlh="+txtWLH.value+"&hw="+txtHW.value;
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
//清空入库类型下拉框
function ClearTSXX()
{
    var drpTSXX=document.getElementById("drpTSXX");
	for(var i = 0;i<=drpTSXX.options.length -1;i++)
	{
　　	drpTSXX.remove(i);
　　}
}
//改变入库类型
function ChangeTSXX()
{
    var drpTSXX=document.getElementById("drpTSXX");
    var hidTSXX=document.getElementById("hidTSXX");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpTSXX.value!="请选择")
    {
        hidTSXX.value=drpTSXX.value;
    }
    if(drpTSXX.value=="请选择")
        hidTSXX.value="";
}
//入库日期
function GetRKRQ()
{
    var chkRKRQ=document.getElementById("chkRKRQ");
    var hidRKRQ=document.getElementById("hidRKRQ");
    var RKRQ_Start=document.getElementById("RKRQ_Start");
    var RKRQ_End=document.getElementById("RKRQ_End");
    if(chkRKRQ.checked)
    {
    hidRKRQ.value=true;
    RKRQ_Start.disabled=false;
    RKRQ_End.disabled=false;  
    }
    else
    {
    hidRKRQ.value="";
    RKRQ_Start.disabled=true;
    RKRQ_End.disabled=true;
    }
}

//称重日期
function GetWRQ()
{
    var chkWRQ=document.getElementById("chkWRQ");
    var hidWRQ=document.getElementById("hidWRQ");
    var txtWRQfrom=document.getElementById("txtWRQfrom");
    var txtWRQto=document.getElementById("txtWRQto");
    if(chkWRQ.checked)
    {
    hidWRQ.value=true;
    txtWRQfrom.disabled=false;
    txtWRQto.disabled=false;  
    }
    else
    {
    hidWRQ.value="";
    txtWRQfrom.disabled=true;
    txtWRQto.disabled=true;
    }
}
//选中WLH复选框时运行的操作
function GetWLH()
{
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    var txtWLH=document.getElementById("txtWLH");
    if(chkWLH.checked)
    {
        txtWLH.readOnly = false;
    }
    else
    {
        txtWLH.value = "";
        txtWLH.readOnly = true;
    }
}
//选自由项1复选框时运行的操作
function GetFree1()
{
    var chkFree=document.getElementById("chkFree1");
    var txtFree=document.getElementById("txtFree1");
    if(chkFree.checked)
    {
        txtFree.readOnly = false;
    }
    else
    {
        txtFree.value = "";
        txtFree.readOnly = true;
    }
}
//选中自由项2复选框时运行的操作
function GetFree2()
{
    var chkFree=document.getElementById("chkFree2");
    var txtFree=document.getElementById("txtFree2");
    if(chkFree.checked)
    {
        txtFree.readOnly = false;
    }
    else
    {
        txtFree.value = "";
        txtFree.readOnly = true;
    }
}
//选中自由项3复选框时运行的操作
function GetFree3()
{
    var chkFree=document.getElementById("chkFree3");
    var txtFree=document.getElementById("txtFree3");
    if(chkFree.checked)
    {
        txtFree.readOnly = false;
    }
    else
    {
        txtFree.value = "";
        txtFree.readOnly = true;
    }
}
//加载属性
function LoadWLH()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=5";
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
//清空属性下拉框
function ClearWLH()
{
    var drpWLH=document.getElementById("drpWLH");
	for(var i = 0;i<=drpWLH.options.length -1;i++)
	{
　　	drpWLH.remove(i);
　　}
}
//改变属性号
function ChangeWLH()
{
    var drpWLH=document.getElementById("drpWLH");
    var hidWLH=document.getElementById("hidWLH");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpWLH.value!="请选择")
    {
        hidWLH.value=drpWLH.value;
    }
    if(drpWLH.value=="请选择")
        hidWLH.value="";
}

//获取规格
function GetGG()
{
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    var drpGG=document.getElementById("drpGG");
      var drpCopyGG=document.getElementById("drpCopyGG");
    var hidCopyGG=document.getElementById("hidCopyGG");
    if(chkGG.checked)
    {
         GetCopyGG();
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
        hidCopyGG.value="";
        drpCopyGG.options.length = 0;
        drpCopyGG.disabled=true;
        drpGG.value = "";
        drpCopyGG.value = "";
    }
    
}

//加载规格
function LoadGG()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=9";
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
    var drpCopyGG=document.getElementById("drpCopyGG");
    var hidCopyGG=document.getElementById("hidCopyGG");

    if(drpCopyGG.value!="请选择")
    {
        hidCopyGG.value=drpCopyGG.value;
    }
    if(drpCopyGG.value=="请选择")
        hidCopyGG.value="";

}

//获取规格
function GetCopyGG()
{
    var hidCopyGG=document.getElementById("hidCopyGG");
    var chkGG=document.getElementById("chkGG");
    var drpCopyGG=document.getElementById("drpCopyGG");
    if(chkGG.checked)
    {
        //已经加载过
        if(drpCopyGG.options.length>0)
        {
            if(hidCopyGG.value!=""&&hidCopyGG.value.length>0)
            {
                drpCopyGG.value=hidCopyGG.value;
            }
            return;
        }
        if(LoadCopyGG())
        {
           if(hidCopyGG.value!=""&&hidCopyGG.value.length>0)
            {
                drpCopyGG.value=hidCopyGG.value;
            }
            return;
        }
    }
    else
    {
        hidCopyGG.value="";
        drpCopyGG.options.length = 0;
        drpCopyGG.disabled=true;
    }
}

//加载规格
function LoadCopyGG()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=9";
    var drpCopyGG=document.getElementById("drpCopyGG");
    drpCopyGG.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpCopyGG.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/GG");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpCopyGG.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpCopyGG.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//改变规格2
function ChangeCopyGG()
{

    var drpCopyGG=document.getElementById("drpCopyGG");
    var hidCopyGG=document.getElementById("hidCopyGG");

    if(drpCopyGG.value!="请选择")
    {
        hidCopyGG.value=drpCopyGG.value;
    }
    if(drpCopyGG.value=="请选择")
        hidCopyGG.value="";

}
//选中TM复选框时运行的操作
function GetTM()
{
    var hidTM=document.getElementById("hidTM");
    var chkTM=document.getElementById("chkTM");
    var txtBarcode=document.getElementById("txtBarcode");
    if(chkTM.checked)
    {
        txtBarcode.readOnly = false;
    }
    else
    {
        txtBarcode.value = "";
        txtBarcode.readOnly = true;
    }
}
//加载属性
function LoadTM()
{
    var request=getXmlHttpRequest();
    var url="loadKuCun.aspx?TYPE=10";
    var drpTM=document.getElementById("drpTM");
    drpTM.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpTM.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/barcode");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpTM.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpTM.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空属性下拉框
function ClearTM()
{
    var drpTM=document.getElementById("drpTM");
	for(var i = 0;i<=drpTM.options.length -1;i++)
	{
　　	drpTM.remove(i);
　　}
}
//改变属性号
function ChangeTM()
{
    var drpTM=document.getElementById("drpTM");
    var hidTM=document.getElementById("hidTM");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpTM.value!="请选择")
    {
        hidTM.value=drpTM.value;
    }
    if(drpTM.value=="请选择")
        hidTM.value="";
}
//模糊
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

function CountQuery()
{
    window.open("StoreCount.aspx","","toolbar=no,menubar=no,scrollbars=auto, resizable=yes,location=no, status=yes");
}