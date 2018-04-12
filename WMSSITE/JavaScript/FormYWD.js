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
function loadallYWD()
{
 //加载仓库
    var hidCKH=document.getElementById("hidCKH");
    var chkCKH=document.getElementById("chkCKH");
    if(hidCKH.value!=null && hidCKH.value!="" && hidCKH.value.length>0)
    {
        chkCKH.checked=true;
        LoadCKH();
        GetCKH();//选中上次选中的项
    }
    //移出货位
    var hidYCHW=document.getElementById("hidYCHW");
    var chkYCHW=document.getElementById("chkYCHW");
    if(hidYCHW.value!=null && hidYCHW.value!="" && hidYCHW.value.length>0)
    {
    chkYCHW.checked=true;
    GetYCHW();
    }
    //单号
    var hidDH=document.getElementById("hidDH");
    var chkDH=document.getElementById("chkDH");
    if(hidDH.value!=null && hidDH.value!="" && hidDH.value.length>0)
    {
    chkDH.checked=true;
    GetDH();
    }
    //移入货位
    var hidYRHW=document.getElementById("hidYRHW");
    var chkYRHW=document.getElementById("chkYRHW");
    if(hidYRHW.value!=null&&hidYRHW.value!=""&&hidYRHW.value.length>0)
    {
    chkYRHW.checked=true;
    GetYRHW();
    }
    //批次
    GetPCH();//选中上次选中的项
    GetFree1();
    GetFree2();
    GetFree3();
    //移位人员
    var hidYWRY=document.getElementById("hidYWRY");
    var chkYWRY=document.getElementById("chkYWRY");
    if(hidYWRY.value!=null && hidYWRY.value!="" && hidYWRY.value.length>0)
    {
    chkYWRY.checked=true;
    //LoadYWRY();
    GetYWRY();
    }
    //牌号
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    if(hidPH.value!=null && hidPH.value!="" && hidPH.value.length>0)
    {
    chkPH.checked=true;
    GetPH();
    }
   //规格
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    if(hidGG.value!=null && hidGG.value!="" && hidGG.value.length>0)
    {
    chkGG.checked=true;
    GetGG();
    }
    //卷号
    var hidJH=document.getElementById("hidJH");
    var chkJH=document.getElementById("chkJH");
    var txtJH=document.getElementById("txtJH");
    if(hidJH.value!=null && hidJH.value!="" && hidJH.value.length>0)
    {
    chkJH.checked=true;
    txtJH.value=hidJH.value;
    }
    //物料号
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    if(hidWLH.value!=null && hidWLH.value!="" && hidWLH.value.length>0)
    {
    chkWLH.checked=true;
    GetWLH();
    }
    //属性
    var hidSX=document.getElementById("hidSX");
    var chkSX=document.getElementById("chkSX");
    if(hidSX.value!=null && hidSX.value!="" && hidSX.value.length>0)
    {
    chkSX.checked=true;
    GetSX();
    }
    //日期
    var YWDRQ_Start=document.getElementById("YWDRQ_Start");
    var YWDRQ_End=document.getElementById("YWDRQ_End");
    var chkYWDRQ=document.getElementById("chkYWDRQ");
    var hidYWDRQ=document.getElementById("hidYWDRQ");
    if(hidYWDRQ.value!="" && hidYWDRQ.value!="" && hidYWDRQ.value.length>0)
    {
    chkYWDRQ.checked=true;
        YWDRQ_Start.disabled=false;
        YWDRQ_End.disabled=false;
    }
    
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
    var url="loadYWD.aspx?TYPE=1";
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
        ClearCKH();
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

//选中YCHW复选框时运行的操作
function GetYCHW()
{
    var hidYCHW=document.getElementById("hidYCHW");
    var chkYCHW=document.getElementById("chkYCHW");
    var drpYCHW=document.getElementById("drpYCHW");
    if(chkYCHW.checked)
    {
        //已经加载过
        if(drpYCHW.options.length>0)
        {
            if(hidYCHW.value!=""&&hidYCHW.value.length>0)
            {
                drpYCHW.value=hidYCHW.value;
            }
            return;
        }
        if(LoadYCHW())
        {
            if(hidYCHW.value!=""&&hidYCHW.value.length>0)
            {
                drpYCHW.value=hidYCHW.value;
            }
            return;
        }
    }
    else
    {
        hidYCHW.value="";
        drpYCHW.options.length = 0;
        drpYCHW.disabled=true;
        drpYCHW.value="";
    }
    //重新加载特殊信息
//    LoadYCHW();
//    GetYCHW();
}
//加载移出货位
function LoadYCHW()
{
    var request=getXmlHttpRequest();
    var hidCKH=document.getElementById("hidCKH");
    var ckh;
    if(hidCKH.value!="" && hidCKH.value!=null && hidCKH.value.lenght>1)
        {
        ckh=hidCKH.value;

        }
        
    var url="loadYWD.aspx?TYPE=2&CKH="+hidCKH.value;
    var drpYCHW=document.getElementById("drpYCHW");
    drpYCHW.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        ClearYCHW();
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/SHW");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpYCHW.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpYCHW.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空移出货位下拉框
function ClearYCHW()
{
    var drpYCHW=document.getElementById("drpYCHW");
	for(var i = 0;i<=drpYCHW.options.length -1;i++)
	{
　　	drpYCHW.remove(i);
　　}
}
//改变移出货位
function ChangeYCHW()
{
    var drpYCHW=document.getElementById("drpYCHW");
    var hidYCHW=document.getElementById("hidYCHW");
    
 
    if(drpYCHW.value!="请选择")
    {
        hidYCHW.value=drpYCHW.value;
    }
    if(drpYCHW.value=="请选择")
        hidYCHW.value="";
}

//选中DH复选框时运行的操作
function GetDH()
{
    var hidDH=document.getElementById("hidDH");
    var chkDH=document.getElementById("chkDH");
    var drpDH=document.getElementById("drpDH");
    if(chkDH.checked)
    {
        //已经加载过
        if(drpDH.options.length>0)
        {
            if(hidDH.value!=""&&hidDH.value.length>0)
            {
                drpDH.value=hidDH.value;
            }
            return;
        }
        if(LoadDH())
        {
            if(hidDH.value!=""&&hidDH.value.length>0)
            {
                drpDH.value=hidDH.value;
            }
            return;
        }
    }
    else
    {
        hidDH.value="";
        drpDH.options.length = 0;
        drpDH.disabled=true;
        drpDH.value="";
    }

}
//加载单号
function LoadDH()
{
    var request=getXmlHttpRequest();
    var url="loadYWD.aspx?TYPE=3";
    var drpDH=document.getElementById("drpDH");
    drpDH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        ClearDH();
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/YWDH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpDH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpDH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空单号下拉框
function ClearDH()
{
    var drpDH=document.getElementById("drpDH");
	for(var i = 0;i<=drpDH.options.length -1;i++)
	{
　　	drpDH.remove(i);
　　}
}
//改变单号
function ChangeDH()
{
    var drpDH=document.getElementById("drpDH");
    var hidDH=document.getElementById("hidDH");
    
 
    if(drpDH.value!="请选择")
    {
        hidDH.value=drpDH.value;
    }
    if(drpDH.value=="请选择")
        hidDH.value="";
}

//选中YRHW复选框时运行的操作
function GetYRHW()
{
    var hidYRHW=document.getElementById("hidYRHW");
    var chkYRHW=document.getElementById("chkYRHW");
    var drpYRHW=document.getElementById("drpYRHW");
    if(chkYRHW.checked)
    {
        //已经加载过
        if(drpYRHW.options.length>0)
        {
            if(hidYRHW.value!=""&&hidYRHW.value.length>0)
            {
                drpYRHW.value=hidYRHW.value;
            }
            return;
        }
        if(LoadYRHW())
        {
            if(hidYRHW.value!=""&&hidYRHW.value.length>0)
            {
                drpYRHW.value=hidYRHW.value;
            }
            return;
        }
    }
    else
    {
        hidYRHW.value="";
        drpYRHW.options.length = 0;
        drpYRHW.disabled=true;
        drpYRHW.value="";
    }

}
//加载移入货位
function LoadYRHW()
{
    var request=getXmlHttpRequest();
    var hidCKH=document.getElementById("hidCKH");
    var ckh;
    if(hidCKH.value!="" && hidCKH.value!=null && hidCKH.value.lenght>1)
        {
        ckh=hidCKH.value;

        }
        
    var url="loadYWD.aspx?TYPE=4&CKH="+hidCKH.value;
    var drpYRHW=document.getElementById("drpYRHW");
    drpYRHW.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        ClearYRHW();
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/SHW");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpYRHW.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpYRHW.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空移入货位下拉框
function ClearYRHW()
{
    var drpYRHW=document.getElementById("drpYRHW");
	for(var i = 0;i<=drpYRHW.options.length -1;i++)
	{
　　	drpYRHW.remove(i);
　　}
}
//改变移入货位
function ChangeYRHW()
{
    var drpYRHW=document.getElementById("drpYRHW");
    var hidYRHW=document.getElementById("hidYRHW");
 
    if(drpYRHW.value!="请选择")
    {
        hidYRHW.value=drpYRHW.value;
    }
    if(drpYRHW.value=="请选择")
        hidYRHW.value="";
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
//加载批次号
function LoadPCH()
{
    var request=getXmlHttpRequest();
    var url="loadYWD.aspx?TYPE=5";
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

//选中YWRY复选框时运行的操作
function GetYWRY()
{
    var hidYWRY=document.getElementById("hidYWRY");
    var chkYWRY=document.getElementById("chkYWRY");
    var drpYWRY=document.getElementById("drpYWRY");
    if(chkYWRY.checked)
    {
        //已经加载过
        if(drpYWRY.options.length>0)
        {
            if(hidYWRY.value!=""&&hidYWRY.value.length>0)
            {
                drpYWRY.value=hidYWRY.value;
            }
            return;
        }
        if(LoadYWRY())
        {
            if(hidYWRY.value!=""&&hidYWRY.value.length>0)
            {
                drpYWRY.value=hidYWRY.value;
            }
            return;
        }
    }
    else
    {
        hidYWRY.value="";
        drpYWRY.options.length = 0;
        drpYWRY.disabled=true;
        drpYWRY.value="";
    }

}
//加载移位人员
function LoadYWRY()
{
    var request=getXmlHttpRequest();
    var url="loadYWD.aspx?TYPE=6";
    var drpYWRY=document.getElementById("drpYWRY");
    drpYWRY.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        ClearYWRY();
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/CZRY");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpYWRY.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpYWRY.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空移位人员下拉框
function ClearYWRY()
{
    var drpYWRY=document.getElementById("drpYWRY");
	for(var i = 0;i<=drpYWRY.options.length -1;i++)
	{
　　	drpYWRY.remove(i);
　　}
}
//改变移位人员
function ChangeYWRY()
{
    var drpYWRY=document.getElementById("drpYWRY");
    var hidYWRY=document.getElementById("hidYWRY");
 
    if(drpYWRY.value!="请选择")
    {
        hidYWRY.value=drpYWRY.value;
    }
    if(drpYWRY.value=="请选择")
        hidYWRY.value="";
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
    var url="loadYWD.aspx?TYPE=7";
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
        drpPH.value="";
    }

}
//加载牌号
function LoadPH()
{
    var request=getXmlHttpRequest();
    var url="loadYWD.aspx?TYPE=8";
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
        ClearPH();
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
    var url="loadYWD.aspx?TYPE=9";
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
        drpGG.value="";
    }

}
//加载规格
function LoadGG()
{
    var request=getXmlHttpRequest();
    var url="loadYWD.aspx?TYPE=10";
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
        ClearGG();
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
function GetJH()
{
    var txtJH=document.getElementById("txtJH");
    var hidJH=document.getElementById("hidJH");
    var chkJH=document.getElementById("chkJH");
    if(chkJH.checked)
     {
            txtJH.readOnly=false;
            txtJH.focus();
        }
     else
       {
            txtJH.readOnly=true;
            hidJH.value="";
            txtJH.value="";
       }

}
function ChangeJH()
{
    var txtJH=document.getElementById("txtJH");
    var hidJH=document.getElementById("hidJH");
    var chkJH=document.getElementById("chkJH");
    if(chkJH.checked)
    {
    hidJH.value=txtJH.value;
    }
}
function GetYWDRQ()
{
    var YWDRQ_Start=document.getElementById("YWDRQ_Start");
    var YWDRQ_End=document.getElementById("YWDRQ_End");
    var chkYWDRQ=document.getElementById("chkYWDRQ");
    var hidYWDRQ=document.getElementById("hidYWDRQ");
    if(chkYWDRQ.checked)
    {
    
      hidYWDRQ.value=true;
        YWDRQ_Start.disabled=false;
        YWDRQ_End.disabled=false;
     }
     else
     {
        hidYWDRQ.value="";
        YWDRQ_Start.disabled=true;
        YWDRQ_End.disabled=true;
        
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
	loadallYWD();
}
