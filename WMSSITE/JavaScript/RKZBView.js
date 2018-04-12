// JScript 文件
//柴艳亮
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
function load_Allrkzb()
{
    // 加载仓库
    var hidCK=document.getElementById("hidCK");
    var chkCK=document.getElementById("chkCK");
    if(chkCK.checked)
    {
        GetCK();
    }
    //加载属性
    var hidRKSX=document.getElementById("hidRKSX");
    var chkRKSX=document.getElementById("chkRKSX");
    var drpRKSX=document.getElementById("drpRKSX");
    if(chkRKSX.checked)
    {
        GetRKSX();
    }
    //加载单号
    var chkRKDH=document.getElementById("chkRKDH");
    var txtRKDH=document.getElementById("txtRKDH");
    if(chkRKDH.checked==false)
    {
        txtRKDH.readOnly = true;
    }
    //牌号
    var chkRKPH=document.getElementById("chkRKPH");
    if(chkRKPH.checked==true)
    {
        LoadRKPH();
    }
    //批次
    var chkRKPCH=document.getElementById("chkRKPCH");
    var txtPCH=document.getElementById("txtPCH");
    if(chkRKPCH.checked==false)
    {
        txtPCH.readOnly = true;
    }
    //规格
        var hidRKGG=document.getElementById("hidRKGG");
    var chkRKGG=document.getElementById("chkRKGG");
    var drpRKGG=document.getElementById("drpRKGG");
    if(chkRKGG.checked)
    {
        LoadRKGG(); 
    }
    //物料
    var chkWLH=document.getElementById("chkWLH");
    if(chkWLH.checked==true)
    {
        LoadWLH();
    }
    //车号
    var chkCPH=document.getElementById("chkCPH");
    var txtCPH=document.getElementById("txtCPH");
    if(chkCPH.checked==false)
    {
        txtCPH.readOnly=true;
    }
    //入库类型
    var hidRKType=document.getElementById("hidRKType");
    var chkRKType=document.getElementById("chkRKType");
    var drpRKType=document.getElementById("drpRKType");
    if(hidRKType.value!="" && hidRKType.value!=null)
    {
        chkRKType.checked=true;
        GetRKType();
    }
    // 生产线
        var hidRKscx=document.getElementById("hidRKscx");
    var chkRKscx=document.getElementById("chkRKscx");
    var drpRKscx=document.getElementById("drpRKscx");
    if(hidRKscx.value!=""&& hidRKscx.value!=null && hidRKscx.value.length>0)
    {
        chkRKscx.checked=true;
        GetRKscx();
        
    }
    //班别
        var hidBB=document.getElementById("hidBB");
    var chkBB=document.getElementById("chkBB");
    var drpBB=document.getElementById("drpBB");
    if(hidBB.value!="" && hidBB.value!=null && hidBB.value.length>0)
    {
        chkBB.checked=true;
        GetBB();
    }
    //特殊信息
    var chkTSXX=document.getElementById("chkTSXX");
    var drpTSXX=document.getElementById("drpTSXX");
    if(chkTSXX.checked==true)
    {
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
    GetFree1();
    GetFree2();
    GetFree3();
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
    var url="loadRKZB.aspx?TYPE=1";
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
    var url="loadRKZB.aspx?TYPE=2";
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

//选中RKDH复选框时运行的操作
function GetRKDH()
{
    var chkRKDH=document.getElementById("chkRKDH");
    var txtRKDH=document.getElementById("txtRKDH");
    if(chkRKDH.checked)
    {
        txtRKDH.readOnly = false;
    }
    else
    {
        txtRKDH.value = "";
        txtRKDH.readOnly = true;
    }
}
//加载属性
function LoadRKDH()
{
    var request=getXmlHttpRequest();
    var url="loadRKZB.aspx?TYPE=3";
    var drpRKDH=document.getElementById("drpRKDH");
    drpRKDH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
         drpRKDH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/RKDH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpRKDH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpRKDH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空属性下拉框
function ClearRKDH()
{
    var drpRKDH=document.getElementById("drpRKDH");
	for(var i = 0;i<=drpRKDH.options.length -1;i++)
	{
　　	drpRKDH.remove(i);
　　}
}
//改变属性号
function ChangeRKDH()
{
    var drpRKDH=document.getElementById("drpRKDH");
    var hidRKDH=document.getElementById("hidRKDH");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpRKDH.value!="请选择")
    {
        hidRKDH.value=drpRKDH.value;
    }
    if(drpRKDH.value=="请选择")
        hidRKDH.value="";
}

//选中RKPH复选框时运行的操作
function GetRKPH()
{
    var hidRKPH=document.getElementById("hidRKPH");
    var chkRKPH=document.getElementById("chkRKPH");
    var drpRKPH=document.getElementById("drpRKPH");
    if(chkRKPH.checked)
    {
        LoadRKPH();
    }
    else
    {
        drpRKPH.value = "";
        drpRKPH.options.length = 0;
    }
}
//加载属性
function LoadRKPH()
{
    var request=getXmlHttpRequest();
    var url="loadRKZB.aspx?TYPE=4";
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
    var url="loadRKZB.aspx?TYPE=5";
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
    var chkRKGG=document.getElementById("chkRKGG");
    var drpRKGG=document.getElementById("drpRKGG");
    if(chkRKGG.checked)
    {
        LoadRKGG();
    }
    else
    {
        drpRKGG.value = "";
        drpRKGG.options.length = 0;
    }
}
//加载规格
function LoadRKGG()
{
    var request=getXmlHttpRequest();
    var url="loadRKZB.aspx?TYPE=6";
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
//选中WLH复选框时运行的操作
function GetWLH()
{
    var chkWLH=document.getElementById("chkWLH");
    var drpWLH=document.getElementById("drpWLH");
    if(chkWLH.checked)
    {
        LoadWLH();
    }
    else
    {
        drpWLH.value = "";
        drpWLH.options.length = 0;
    }
}
//加载物料
function LoadWLH()
{
    var request=getXmlHttpRequest();
    var url="loadRKZB.aspx?TYPE=7";
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
    var chkCPH=document.getElementById("chkCPH");
    var txtCPH=document.getElementById("txtCPH");
    if(chkCPH.checked)
    {
        txtCPH.readOnly = false;
    }
    else
    {
        txtCPH.value = "";
        txtCPH.readOnly = true;
    }
}
//加载车号
function LoadCPH()
{
    var request=getXmlHttpRequest();
    var url="loadRKZB.aspx?TYPE=8";
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
    var url="loadRKZB.aspx?TYPE=9";
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
    var url="loadRKZB.aspx?TYPE=10";
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
        drpRKscx.options.length = 0
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
    var url="loadRKZB.aspx?TYPE=11";
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
    var chkTSXX=document.getElementById("chkTSXX");
    var drpTSXX=document.getElementById("drpTSXX");
    if(chkTSXX.checked)
    {
        LoadTSXX();
    }
    else
    {
        drpTSXX.value = "";
        drpTSXX.options.length = 0;
    }
}
//加载入库类型
function LoadTSXX()
{
    var request=getXmlHttpRequest();
    var url="loadRKZB.aspx?TYPE=12";
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