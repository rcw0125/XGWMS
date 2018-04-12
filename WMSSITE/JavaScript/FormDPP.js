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
function loadallDPP()
{
 //加载仓库
    var hidCKH=document.getElementById("hidCKH");
    var chkCKH=document.getElementById("chkCKH");
    if(hidCKH.value!=null && hidCKH.value!="" && hidCKH.value.length>0)
    {
        chkCKH.checked=true;
       // LoadCKH();
        GetCKH();//选中上次选中的项
    }
         //加载物料号
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    if(hidWLH.value!=null && hidWLH.value!="" && hidWLH.value.length>0)
    {
        chkWLH.checked=true;
       // LoadWLH();
        GetWLH();//选中上次选中的项
    }
    //货位
   var txtHW=document.getElementById("txtHW");
    var chkHW=document.getElementById("chkHW");
    if(chkHW.checked==false)
    {
        txtHW.readOnly = true;
    }
    //批次
    var hidPCH=document.getElementById("hidPCH");
    var chkPCH=document.getElementById("chkPCH");
    if(hidPCH.value!=null && hidPCH.value!="" && hidPCH.value.length>0)
    {
        chkPCH.checked=true;
        //LoadPCH();
        GetPCH();//选中上次选中的项
    }
    
              //加载属性
    var hidSX=document.getElementById("hidSX");
    var chkSX=document.getElementById("chkSX");
    if(hidSX.value!=null && hidSX.value!="" && hidSX.value.length>0)
    {
        chkSX.checked=true;
        //LoadSX();
        GetSX();//选中上次选中的项
    }    
    //加载牌号
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    if(hidPH.value!=null && hidPH.value!="" && hidPH.value.length>0)
    {
        chkPH.checked=true;
        //LoadPH();
        GetPH();//选中上次选中的项
    }

         //加载规格
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    var hidCopyGG=document.getElementById("hidCopyGG")
    if((hidGG.value!=null||hidCopyGG.value!=null) && (hidGG.value!=""||hidCopyGG.value!=""))
    {
        chkGG.checked=true;
        //LoadGG();
        GetGG();//选中上次选中的项
        //LoadCopyGG();
        GetCopyGG();

     }

     //特殊信息
     var chkTSXX=document.getElementById("chkTSXX");
     if(chkTSXX.checked)
     { 
        GetTSXX();//选中上次选中的项
     
     }
     //未改判
     var hidWGP=document.getElementById("hidWGP");
     var chkWGP=document.getElementById("chkWGP");
     if(hidWGP.value!=null && hidWGP.value!="" &&hidWGP.value.length>0)
     {
     chkWGP.checked=false;
     }
     else
     {
     chkWGP.checked=true;
     }
    var chkRKRQ=document.getElementById("chkRKRQ");
    var hidRKRQ=document.getElementById("hidRKRQ");
    var RuKu_Start=document.getElementById("RuKu_Start");
    var RuKu_End=document.getElementById("RuKu_End");
    if(hidRKRQ.value!=null && hidRKRQ.value!="" && hidRKRQ.value.length>0)
    {
    chkRKRQ.checked=true;
    RuKu_Start.disabled=false;
    RuKu_End.disabled=false;
    }
    GetFree1();
    GetFree2();
    GetFree3();
 }
 
 //选中CKH复选框时运行的操作
function GetCKH()
{
    var hidCKH=document.getElementById("hidCKH");
    var chkCKH=document.getElementById("chkCKH");
    var drpCKH=document.getElementById("drpCKH");
    if(chkCKH.checked)
    {
        //已经加载过
        if(drpCKH.options.length>0)
        {
            if(hidCKH.value!=""&&hidCKH.value.length>0)
            {
                drpCKH.value=hidCKH.value;
            }
            return;
        }
        if(LoadCKH())
        {
            if(hidCKH.value!=""&&hidCKH.value.length>0)
            {
                drpCKH.value=hidCKH.value;
            }
            return;
        }
    }
    else
    {
        hidCKH.value="";
        drpCKH.options.length = 0;
        drpCKH.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载仓库
function LoadCKH()
{
    var request=getXmlHttpRequest();
    var url="loadDPP.aspx?TYPE=1";
    var drpCKH=document.getElementById("drpCKH");
    drpCKH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpCKH.options.length=0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/CKID");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpCKH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpCKH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空仓库下拉框
function ClearCKH()
{
    var drpCKH=document.getElementById("drpCKH");
	for(var i = 0;i<=drpCKH.options.length -1;i++)
	{
　　	drpCKH.remove(i);
　　}
}
//改变仓库号
function ChangeCKH()
{
    var drpCKH=document.getElementById("drpCKH");
    var hidCKH=document.getElementById("hidCKH");
    
 
    if(drpCKH.value!="请选择")
    {
        hidCKH.value=drpCKH.value;
    }
    if(drpCKH.value=="请选择")
        hidCKH.value="";
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
    }
    //重新加载特殊信息
    //LoadWLH();
    //GetWLH();
}
//加载物料号
function LoadWLH()
{
    var request=getXmlHttpRequest();
    var url="loadDPP.aspx?TYPE=2";
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
        drpWLH.options.length=0;
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
    
 
    if(drpWLH.value!="请选择")
    {
        hidWLH.value=drpWLH.value;
    }
    if(drpWLH.value=="请选择")
        hidWLH.value="";
}


//选中HW复选框时运行的操作
function GetHW()
{
    var txtHW=document.getElementById("txtHW");
    var chkHW=document.getElementById("chkHW");
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
//加载货位
function LoadHW()
{
    var request=getXmlHttpRequest();
    var hidCKH=document.getElementById("hidCKH");
    var ckid="";
    if(hidCKH.value!=""&&hidCKH.value!=null)
    {
    ckid=hidCKH.value;
    } 
    var url="loadDPP.aspx?TYPE=3&ckid="+ckid;
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
       drpHW.options.length=0;
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
//清空货位下拉框
function ClearHW()
{
    var drpHW=document.getElementById("drpHW");
	for(var i = 0;i<=drpHW.options.length -1;i++)
	{
　　	drpHW.remove(i);
　　}
}
//改变货位
function ChangeHW()
{
    var drpHW=document.getElementById("drpHW");
    var hidHW=document.getElementById("hidHW");
    
 
    if(drpHW.value!="请选择")
    {
        hidHW.value=drpHW.value;
    }
    if(drpHW.value=="请选择")
        hidHW.value="";
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
                drpPCH.value=hidPCH.value;
            }
            return;
        }
        if(LoadPCH())
        {
            if(hidPCH.value!=""&&hidPCH.value.length>0)
            {
                drpPCH.value=hidPCH.value;
            }
            return;
        }
    }
    else
    {
        hidPCH.value="";
        drpPCH.options.length = 0;
        drpPCH.disabled=true;
    }
    //重新加载特殊信息
    //LoadPCH();
    //GetPCH();
}
//加载批次号
function LoadPCH()
{
    var request=getXmlHttpRequest();
    var url="loadDPP.aspx?TYPE=4";
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
        drpPCH.options.length=0;
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
//改变批次号
function ChangePCH()
{
    var drpPCH=document.getElementById("drpPCH");
    var hidPCH=document.getElementById("hidPCH");
    
 
    if(drpPCH.value!="请选择")
    {
        hidPCH.value=drpPCH.value;
    }
    if(drpPCH.value=="请选择")
        hidPCH.value="";
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
    var url="loadDPP.aspx?TYPE=5";
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
        drpSX.options.length=0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/SX");
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
    }

}
//加载牌号
function LoadPH()
{
    var request=getXmlHttpRequest();
    var url="loadDPP.aspx?TYPE=6";
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
        drpPH.options.length=0;
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
    }

}
//加载规格
function LoadGG()
{
    var request=getXmlHttpRequest();
    var url="loadDPP.aspx?TYPE=7";
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
//清空规格下拉框
function ClearGG()
{
    var drpGG=document.getElementById("drpGG");
	for(var i = 0;i<=drpGG.options.length -1;i++)
	{
　　	drpGG.remove(i);
　　}
}

//改变GG
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
    //重新加载特殊信息
    //LoadCopyGG();
    //GetCopyGG();
}
//加载GG
function LoadCopyGG()
{
    var request=getXmlHttpRequest();
    var url="loadDPP.aspx?TYPE=7";
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
        drpCopyGG.options.length=0;
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
//清空GG下拉框
function ClearCopyGG()
{
    var drpCopyGG=document.getElementById("drpCopyGG");
	for(var i = 0;i<=drpCopyGG.options.length -1;i++)
	{
　　	drpCopyGG.remove(i);
　　}
}
//改变GG
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
    }
    //重新加载特殊信息
    //LoadTSXX();
    //GetTSXX();
}
//加载特殊信息
function LoadTSXX()
{
    var request=getXmlHttpRequest();
     var hidCKH=document.getElementById("hidCKH");
    var hidPCH=document.getElementById("hidPCH");
    var hidSX=document.getElementById("hidSX");
     var hidWLH=document.getElementById("hidWLH");
     var hidHW=document.getElementById("hidHW");
     var ckh="";
     var pch="";
     var sx="";
     var wlh="";
     var hw="";
     if(hidCKH.value!="" && hidCKH.value!=null)
     {
        ckh=hidCKH.value;     
     }
     if(hidPCH.value!="" && hidPCH.value!=null)
     {
        pch=hidPCH.value;
     }
     if(hidSX.value!="" && hidSX.value!=null)
     {
        sx=hidSX.value;
     }
     if(hidWLH.value!="" && hidWLH.value!=null)
     {
        wlh=hidWLH.value;
     }
     if(hidHW.value!="" && hidHW.value!=null)
     {
        hw=hidHW.value;
     }
    var url="loadDPP.aspx?TYPE=8";//&ckh="+hidCKH.value+"&pch="+hidPCH.value+"&sx="+hidSX.value+"&wlh="+hidWLH.value+"&hw="+hidHW.value;
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
        drpTSXX.options.length=0;
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
//清空特殊信息下拉框
function ClearTSXX()
{
    var drpTSXX=document.getElementById("drpTSXX");
	for(var i = 0;i<=drpTSXX.options.length -1;i++)
	{
　　	drpTSXX.remove(i);
　　}
}
//改变特殊信息
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

function GetWGP()
{
    var hidWGP=document.getElementById("hidWGP");
    var chkWGP=document.getElementById("chkWGP");
    if(chkWGP.checked)
    {
    hidWGP.value="";
    }
    else
    {
    hidWGP.value=true;
    }
}
//入库日期
function GetRKRQ()
{
    var chkRKRQ=document.getElementById("chkRKRQ");
    var hidRKRQ=document.getElementById("hidRKRQ");
    var RuKu_Start=document.getElementById("RuKu_Start");
    var RuKu_End=document.getElementById("RuKu_End");
    if(chkRKRQ.checked)
    {
        hidRKRQ.value=true;
        RuKu_Start.disabled=false;
        RuKu_End.disabled=false;
     }
     else
     {
       hidRKRQ.value="";
        RuKu_Start.disabled=true;
        RuKu_End.disabled=true;
        
     }

}

//选中
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
//选中
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
//选中
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