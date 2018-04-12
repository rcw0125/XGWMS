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
function loadallTHD()
{
 //加载仓库
    var hidCKH=document.getElementById("hidCKH");
    var chkCKH=document.getElementById("chkCKH");
    if(hidCKH.value!=null && hidCKH.value!="" && hidCKH.value.length>0)
    {
        chkCKH.checked=true;
        GetCKH();//选中上次选中的项
    }
     //加载制单人
    var hidZDR=document.getElementById("hidZDR");
    var chkZDR=document.getElementById("chkZDR");
    if(hidZDR.value!=null && hidZDR.value!="" && hidZDR.value.length>0)
    {
        chkZDR.checked=true;
        GetZDR();//选中上次选中的项
    }
         //加载发运单
    var hidFYDH=document.getElementById("hidFYDH");
    var chkFYDH=document.getElementById("chkFYDH");
    if(hidFYDH.value!=null && hidFYDH.value!="" && hidFYDH.value.length>0)
    {
        chkFYDH.checked=true;
        GetFYDH();//选中上次选中的项
    }
        //加载部门
    var hidBM=document.getElementById("hidBM");
    var chkBM=document.getElementById("chkBM");
    if(hidBM.value!=null && hidBM.value!="" && hidBM.value.length>0)
    {
        chkBM.checked=true;
        GetBM();//选中上次选中的项
    }
         //加载退货单
    var hidTHDH=document.getElementById("hidTHDH");
    var chkTHDH=document.getElementById("chkTHDH");
    if(hidTHDH.value!=null && hidTHDH.value!="" && hidTHDH.value.length>0)
    {
        chkTHDH.checked=true;
        GetTHDH();//选中上次选中的项
    }
         //加载牌号
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    if(hidPH.value!=null && hidPH.value!="" && hidPH.value.length>0)
    {
        chkPH.checked=true;
        GetPH();//选中上次选中的项
    }
         //加载物料号
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    if(hidWLH.value!=null && hidWLH.value!="" && hidWLH.value.length>0)
    {
        chkWLH.checked=true;
        GetWLH();//选中上次选中的项
    }
         //加载规格
    var hidGG=document.getElementById("hidGG");
    var chkGG=document.getElementById("chkGG");
    if(hidGG.value!=null && hidGG.value!="" && hidGG.value.length>0)
    {
        chkGG.checked=true;
        GetGG();//选中上次选中的项
    }
         //加载属性
    var hidSX=document.getElementById("hidSX");
    var chkSX=document.getElementById("chkSX");
    if(hidSX.value!=null && hidSX.value!="" && hidSX.value.length>0)
    {
        chkSX.checked=true;
        GetSX();//选中上次选中的项
    }
         //加载客户号
    var hidKHH=document.getElementById("hidKHH");
    var chkKHH=document.getElementById("chkKHH");
    if(hidKHH.value!=null && hidKHH.value!="" && hidKHH.value.length>0)
    {
        chkKHH.checked=true;
        GetKHH();//选中上次选中的项
    }
    //加载IC卡号
    var hidICKH=document.getElementById("hidICKH");
    var txtICKH=document.getElementById("txtICKH");
    var chkICKH=document.getElementById("chkICKH");
    if(hidICKH.value!=null&& hidICKH.value!=""&&hidICKH.value.length>0)
    {
        chkICKH.checked=true;
        txtICKH.value=hidICKH.value;
    }
    //加载时间
    
    chkTuiHuoRQ=document.getElementById("chkTuiHuoRQ");
    TuiHuo_Start=document.getElementById("TuiHuo_Start");
    TuiHuo_End=document.getElementById("TuiHuo_End");
    hidTuiHuo=document.getElementById("hidTuiHuo");
    if(hidTuiHuo.vlaue!="" && hidTuiHuo.value!=null && hidTuiHuo.value.length>0)
    {
      chkTuiHuoRQ.checked=true;
        TuiHuo_Start.disabled=false;
        TuiHuo_End.disabled=false;
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
    var url="loadTHD.aspx?TYPE=1";
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
        drpCKH.options.length = 0;
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

//选中ZDR复选框时运行的操作
function GetZDR()
{
    var hidZDR=document.getElementById("hidZDR");
    var chkZDR=document.getElementById("chkZDR");
    var drpZDR=document.getElementById("drpZDR");
    if(chkZDR.checked)
    {
        //已经加载过
        if(drpZDR.options.length>0)
        {
            if(hidZDR.value!=""&&hidZDR.value.length>0)
            {
                drpZDR.value=hidZDR.value;
            }
            return;
        }
        if(LoadZDR())
        {
            if(hidZDR.value!=""&&hidZDR.value.length>0)
            {
                drpZDR.value=hidZDR.value;
            }
            return;
        }
    }
    else
    {
        hidZDR.value="";
        drpZDR.options.length = 0;
        drpZDR.disabled=true;
    }
    //重新加载特殊信息
    //LoadZDR();
    //GetZDR();
}
//加载制单人
function LoadZDR()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=2";
    var drpZDR=document.getElementById("drpZDR");
    drpZDR.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpZDR.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/NCZDRY");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpZDR.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpZDR.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空制单人下拉框
function ClearZDR()
{
    var drpZDR=document.getElementById("drpZDR");
	for(var i = 0;i<=drpZDR.options.length -1;i++)
	{
　　	drpZDR.remove(i);
　　}
}
//改变制单人
function ChangeZDR()
{
    var drpZDR=document.getElementById("drpZDR");
    var hidZDR=document.getElementById("hidZDR");
    
 
    if(drpZDR.value!="请选择")
    {
        hidZDR.value=drpZDR.value;
    }
    if(drpZDR.value=="请选择")
        hidZDR.value="";
}

//选中FYDH复选框时运行的操作
function GetFYDH()
{
    var hidFYDH=document.getElementById("hidFYDH");
    var chkFYDH=document.getElementById("chkFYDH");
    var drpFYDH=document.getElementById("drpFYDH");
    if(chkFYDH.checked)
    {
        //已经加载过
        if(drpFYDH.options.length>0)
        {
            if(hidFYDH.value!=""&&hidFYDH.value.length>0)
            {
                drpFYDH.value=hidFYDH.value;
            }
            return;
        }
        if(LoadFYDH())
        {
            if(hidFYDH.value!=""&&hidFYDH.value.length>0)
            {
                drpFYDH.value=hidFYDH.value;
            }
            return;
        }
    }
    else
    {
        hidFYDH.value="";
        drpFYDH.options.length = 0;
        drpFYDH.disabled=true;
    }
    //重新加载特殊信息
    //LoadFYDH();
    //GetFYDH();
}
//加载发运单号
function LoadFYDH()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=3";
    var drpFYDH=document.getElementById("drpFYDH");
    drpFYDH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpFYDH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/CKDH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpFYDH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpFYDH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空发运单号下拉框
function ClearFYDH()
{
    var drpFYDH=document.getElementById("drpFYDH");
	for(var i = 0;i<=drpFYDH.options.length -1;i++)
	{
　　	drpFYDH.remove(i);
　　}
}
//改变发运单号号
function ChangeFYDH()
{
    var drpFYDH=document.getElementById("drpFYDH");
    var hidFYDH=document.getElementById("hidFYDH");
    
 
    if(drpFYDH.value!="请选择")
    {
        hidFYDH.value=drpFYDH.value;
    }
    if(drpFYDH.value=="请选择")
        hidFYDH.value="";
}

//选中BM复选框时运行的操作
function GetBM()
{
    var hidBM=document.getElementById("hidBM");
    var chkBM=document.getElementById("chkBM");
    var drpBM=document.getElementById("drpBM");
    if(chkBM.checked)
    {
        //已经加载过
        if(drpBM.options.length>0)
        {
            if(hidBM.value!=""&&hidBM.value.length>0)
            {
                drpBM.value=hidBM.value;
            }
            return;
        }
        if(LoadBM())
        {
            if(hidBM.value!=""&&hidBM.value.length>0)
            {
                drpBM.value=hidBM.value;
            }
            return;
        }
    }
    else
    {
        hidBM.value="";
        drpBM.options.length = 0;
        drpBM.disabled=true;
    }
    //重新加载特殊信息
    //LoadBM();
    //GetBM();
}
//加载部门
function LoadBM()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=4";
    var drpBM=document.getElementById("drpBM");
    drpBM.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
       drpBM.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/NCBM");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpBM.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpBM.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空部门下拉框
function ClearBM()
{
    var drpBM=document.getElementById("drpBM");
	for(var i = 0;i<=drpBM.options.length -1;i++)
	{
　　	drpBM.remove(i);
　　}
}
//改变部门号
function ChangeBM()
{
    var drpBM=document.getElementById("drpBM");
    var hidBM=document.getElementById("hidBM");
    
 
    if(drpBM.value!="请选择")
    {
        hidBM.value=drpBM.value;
    }
    if(drpBM.value=="请选择")
        hidBM.value="";
}

//选中THDH复选框时运行的操作
function GetTHDH()
{
    var hidTHDH=document.getElementById("hidTHDH");
    var chkTHDH=document.getElementById("chkTHDH");
    var drpTHDH=document.getElementById("drpTHDH");
    if(chkTHDH.checked)
    {
        //已经加载过
        if(drpTHDH.options.length>0)
        {
            if(hidTHDH.value!=""&&hidTHDH.value.length>0)
            {
                drpTHDH.value=hidTHDH.value;
            }
            return;
        }
        if(LoadTHDH())
        {
            if(hidTHDH.value!=""&&hidTHDH.value.length>0)
            {
                drpTHDH.value=hidTHDH.value;
            }
            return;
        }
    }
    else
    {
        hidTHDH.value="";
        drpTHDH.options.length = 0;
        drpTHDH.disabled=true;
    }
    //重新加载特殊信息
    //LoadTHDH();
    //GetTHDH();
}
//加载退货单号
function LoadTHDH()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=5";
    var drpTHDH=document.getElementById("drpTHDH");
    drpTHDH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpTHDH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/THDH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpTHDH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpTHDH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空退货单号下拉框
function ClearTHDH()
{
    var drpTHDH=document.getElementById("drpTHDH");
	for(var i = 0;i<=drpTHDH.options.length -1;i++)
	{
　　	drpTHDH.remove(i);
　　}
}
//改变退货单号
function ChangeTHDH()
{
    var drpTHDH=document.getElementById("drpTHDH");
    var hidTHDH=document.getElementById("hidTHDH");
    
 
    if(drpTHDH.value!="请选择")
    {
        hidTHDH.value=drpTHDH.value;
    }
    if(drpTHDH.value=="请选择")
        hidTHDH.value="";
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
    //重新加载特殊信息
    //LoadPH();
    //GetPH();
}
//加载牌号
function LoadPH()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=6";
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
    }
    //重新加载特殊信息
    //LoadWLH();
    //GetWLH();
}
//加载物料号
function LoadWLH()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=7";
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
    }
    //重新加载特殊信息
    //LoadGG();
    //GetGG();
}
//加载规格
function LoadGG()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=8";
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
    //重新加载特殊信息
    //LoadSX();
    //GetSX();
}
//加载属性
function LoadSX()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=9";
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
         drpSX.options.length = 0;
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

//选中KHH复选框时运行的操作
function GetKHH()
{
    var hidKHH=document.getElementById("hidKHH");
    var chkKHH=document.getElementById("chkKHH");
    var drpKHH=document.getElementById("drpKHH");
    if(chkKHH.checked)
    {
        //已经加载过
        if(drpKHH.options.length>0)
        {
            if(hidKHH.value!=""&&hidKHH.value.length>0)
            {
                drpKHH.value=hidKHH.value;
            }
            return;
        }
        if(LoadKHH())
        {
            if(hidKHH.value!=""&&hidKHH.value.length>0)
            {
                drpKHH.value=hidKHH.value;
            }
            return;
        }
    }
    else
    {
        hidKHH.value="";
        drpKHH.options.length = 0;
        drpKHH.disabled=true;
    }
    //重新加载特殊信息
    //LoadKHH();
    //GetKHH();
}
//加载客户号
function LoadKHH()
{
    var request=getXmlHttpRequest();
    var url="loadTHD.aspx?TYPE=10";
    var drpKHH=document.getElementById("drpKHH");
    drpKHH.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpKHH.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/KHHNAME");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpKHH.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpKHH.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
//清空客户号下拉框
function ClearKHH()
{
    var drpKHH=document.getElementById("drpKHH");
	for(var i = 0;i<=drpKHH.options.length -1;i++)
	{
　　	drpKHH.remove(i);
　　}
}
//改变客户号
function ChangeKHH()
{
    var drpKHH=document.getElementById("drpKHH");
    var hidKHH=document.getElementById("hidKHH");
    
 
    if(drpKHH.value!="请选择")
    {
        hidKHH.value=drpKHH.value;
    }
    if(drpKHH.value=="请选择")
        hidKHH.value="";
}
//获取IC卡号
function GetICKH()
{
    var txtICKH=document.getElementById("txtICKH");
    var hidICKH=document.getElementById("hidICKH");
    var chkICKH=document.getElementById("chkICKH");
    if(chkICKH.checked)
    {
        txtICKH.readOnly=false;
        txtICKH.focus();
    }
}
function ChangeICKH()
{
     var txtICKH=document.getElementById("txtICKH");
    var hidICKH=document.getElementById("hidICKH");
    var chkICKH=document.getElementById("chkICKH");
    if(txtICKH.value!="")
        {
            hidICKH.value=txtICKH.value;
        }
    else
        {
        hidICKH.value="";
        }
}

function GetTuiHuo()
{
    chkTuiHuoRQ=document.getElementById("chkTuiHuoRQ");
    TuiHuo_Start=document.getElementById("TuiHuo_Start");
    TuiHuo_End=document.getElementById("TuiHuo_End");
    hidTuiHuo=document.getElementById("hidTuiHuo");
    if(chkTuiHuoRQ.checked)
    {
      hidTuiHuo.value=true;
        TuiHuo_Start.disabled=false;
        TuiHuo_End.disabled=false;
     }
     else
     {
        hidTuiHuo.value="";
        TuiHuo_Start.disabled=true;
        TuiHuo_End.disabled=true;
        
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
		AddQuery();
	}
	if(Hidconfig.value!="")
	{
		tablecon.style.display = "none";
		if( Hidconfig.value== "none")
			tablecon.style.display = "block";
		Addconfig();
	}
	
	   loadallTHD();
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