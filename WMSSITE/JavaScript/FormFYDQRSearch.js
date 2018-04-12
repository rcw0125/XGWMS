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
/*显示或者隐藏列表配置*/
function Addconfig() 
{
//	var btnconfig = document.getElementById("btnconfig");
//	var tblconfig = document.getElementById("tblconfig");
//	if(tblconfig.style.display ==  "block")
//	{
//		btnconfig.src = "../../images/icon/expand.gif";
//		btnconfig.alt = "展开";
//		tblconfig.style.display = "none";
//	}
//	else
//	{
//		btnconfig.src = "../../images/icon/collapse.gif";
//		btnconfig.alt = "关闭";
//		tblconfig.style.display = "block";
//	}
}

/*页面初始化，完工单查询*/
function Init()
{
	var tblQuery = document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
	var btnQuery = document.getElementById("btnQuery");
	
//	var tblconfig = document.getElementById("tblconfig");
//    var btnconfig = document.getElementById("btnconfig");
    
    
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
	
	//tblconfig.style.display="none";
    //btnconfig.src = "../../images/icon/expand.gif";
	//btnconfig.alt = "展开";
	
	
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
	
	LoadAllFYD();
}
//选中CKH复选框时运行的操作
function GetCKH()
{
    var chkCKH=document.getElementById("chkCKH");
    var drpCKH=document.getElementById("drpCKH");
    if(chkCKH.checked)
    {
        drpCKH.disabled=false;
    }
    else
    {
        drpCKH.disabled=true;
        drpCKH.value="请选择";
    }
}

//页面加载时需要运行的代码
function LoadAllFYD()
{
    //加载发运单
    var hidFYD=document.getElementById("hidFYD");
    var chkFYD=document.getElementById("chkFYD");
    if(hidFYD.value!=null && hidFYD.value!="" && hidFYD.value.length>0)
    {
        chkFYD.checked=true;
        GetFYD();
    }
        //加载车牌号
    var hidCPH=document.getElementById("hidCPH");
    var chkCPH=document.getElementById("chkCPH");
    if(hidCPH.value!=null && hidCPH.value!="" && hidCPH.value.length>0)
    {
        chkCPH.checked=true;
        GetCPH();  
    }
    //加载物料号
    var hidWLH=document.getElementById("hidWLH");
    var chkWLH=document.getElementById("chkWLH");
    if(hidWLH.value!=null && hidWLH.value!="" && hidWLH.value.length>0)
    {
        chkWLH.checked=true;
        GetWLH();
    }  
    //加载牌号
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    if(hidPH.value!=null && hidPH.value!="" && hidPH.value.length>0)
    {
        chkPH.checked=true;
        GetPH();//选中上次选中的项
    }
 
    //加载特殊信息
    var hidTSXX=document.getElementById("hidTSXX");
    var chkTSXX=document.getElementById("chkTSXX");
    if(hidTSXX.value!=null && hidTSXX.value!="" && hidTSXX.value.length>0)
    {
        chkTSXX.checked=true;
        GetTSXX();//选中上次选中的项
    }
    //加载客户号
    var hidKHH=document.getElementById("hidKHH");
    var chkKHH=document.getElementById("chkKHH");
    if(hidKHH.value!=null && hidKHH.value!="" && hidKHH.value.length>0)
    {
        chkKHH.checked=true;
        GetKHH();//选中上次选中的项
    }
     //加载地址
    var hidADD=document.getElementById("hidADD");
    var chkADD=document.getElementById("chkADD");
    if(hidADD.value!=null && hidADD.value!="" && hidADD.value.length>0)
    {
        chkADD.checked=true;
        GetADD();//选中上次选中的项
    }
    
    //加载仓库
    var chkCKH=document.getElementById("chkCKH");
    var drpCKH=document.getElementById("drpCKH");
    if(chkCKH.checked)
    {
        drpCKH.disabled=false;
    }
    else
        drpCKH.disabled=true;
        
    //加载制单人
    var chkZDR=document.getElementById("chkZDR");
    var drpZDR=document.getElementById("drpZDR");
    if(chkZDR.checked)
        drpZDR.disabled=false;
    else
        drpZDR.disabled=true;
        
    var chkGG=document.getElementById("chkGG");
    var drpGG=document.getElementById("drpGG");
    var drpGG2=document.getElementById("drpCopyGG");
    if(chkGG.checked)
    {
        drpGG.disabled=false;
        drpGG2.disabled=false;
    }
    else
    {
        drpGG.disabled=true;
        drpGG2.disabled=true;
    }
    
    //加载状态
    var chkWCBZ=document.getElementById("chkWCBZ");
    var drpWCBZ=document.getElementById("drpWCBZ");
    if(chkWCBZ.checked)
        drpWCBZ.disabled=false;
    else
        drpWCBZ.disabled=true;
    
    //加载属性
    var chkSX=document.getElementById("chkSX");
    var drpSX=document.getElementById("drpSX");
    if(chkSX.checked)
        drpSX.disabled=false;
    else
        drpSX.disabled=true;
    
    //加载部门
    var chkBM=document.getElementById("chkBM");
    var drpBM=document.getElementById("drpBM");
    if(chkBM.checked)
        drpBM.disabled=false;
    else
        drpBM.disabled=true;
        
    //加载制单日期
    var chkMakeTime=document.getElementById("chkMakeTime");
    var MakeStartTime=document.getElementById("MakeStartTime");
    var MakeEndTime=document.getElementById("MakeEndTime");
    if(chkMakeTime.checked)
    {
        MakeStartTime.disabled=false;
        MakeEndTime.disabled=false;
    }
    else
    {
        MakeStartTime.disabled=true;
        MakeEndTime.disabled=true;
    }
    
    //加载出库时间日期
    var chkChuKuTime=document.getElementById("chkChuKuTime");
    var ChuKuStartTime=document.getElementById("ChuKuStartTime");
    var ChuKuEndTime=document.getElementById("ChuKuEndTime");
    if(chkChuKuTime.checked)
    {
        ChuKuStartTime.disabled=false;
        ChuKuEndTime.disabled=false;
    }
    else
    {
        ChuKuStartTime.disabled=true;
        ChuKuEndTime.disabled=true;
    }
    
    //加载出门时间日期
    var chkGoTime=document.getElementById("chkGoTime");
    var GoStartTime=document.getElementById("GoStartTime");
    var GoEndtime=document.getElementById("GoEndtime");
    if(chkGoTime.checked)
    {
        GoStartTime.disabled=false;
        GoEndtime.disabled=false;
    }
    else
    {
        GoStartTime.disabled=true;
        GoEndtime.disabled=true;
    }
    
     //加载入门时间日期
    var chkInTime=document.getElementById("chkInTime");
    var InStartTime=document.getElementById("InStartTime");
    var InEndTime=document.getElementById("InEndTime");
    if(chkInTime.checked)
    {
        InStartTime.disabled=false;
        InEndTime.disabled=false;
    }
    else
    {
        InStartTime.disabled=true;
        InEndTime.disabled=true;
    }
    
    //加载运输
    var chkChuanShu=document.getElementById("chkChuanShu");
    var drpChuanShu=document.getElementById("drpChuanShu");
    if(chkChuanShu.checked)
        drpChuanShu.disabled=true;
}

//获取制单人
function GetZDR()
{
    var chkZDR=document.getElementById("chkZDR");
    var drpZDR=document.getElementById("drpZDR");
    if(chkZDR.checked)
    {
         drpZDR.disabled=false;
    }
    else
    {
        drpZDR.value="请选择";
        drpZDR.disabled=true;
    }
}
//获取货运单
function GetFYD()
{
    var hidFYD=document.getElementById("hidFYD");
    var chkFYD=document.getElementById("chkFYD");
    var drpFYD=document.getElementById("drpFYD");
    if(chkFYD.checked)
    {
        //已经加载过
        if(drpFYD.options.length>0)
        {
            if(hidFYD.value!=""&&hidFYD.value.length>0)
            {
                drpFYD.value=hidFYD.value;
                drpFYD.text=hidFYD.value;
            }
            return;
        }
        if(LoadFYD())
        {
           if(hidFYD.value!=""&&hidFYD.value.length>0)
            {
                drpFYD.value=hidFYD.value;
                drpFYD.text=hidFYD.value;
            }
            return;
        }
    }
    else
    {
        hidFYD.value="";
        //drpFYD.options.length=0;
        drpFYD.value="";
        drpFYD.text="";
    }
}

//Load发运单
function LoadFYD()
{
    var request=getXmlHttpRequest();
    var url="loadFYD.aspx?TYPE=3";
    var drpFYD=document.getElementById("drpFYD");
    drpFYD.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpFYD.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/FYDH");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpFYD.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpFYD.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//获取部门
function GetBM()
{
    var chkBM=document.getElementById("chkBM");
    var drpBM=document.getElementById("drpBM");
    if(chkBM.checked)
    {
       drpBM.disabled=false;
    }
    else
    {
        drpBM.value="请选择";
        drpBM.disabled=true;
    }
}

//获取车牌号
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
        drpCPH.text="";
    }
}

//加载车牌号
function LoadCPH()
{
    var request=getXmlHttpRequest();
    var url="loadFYD.aspx?TYPE=5";
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

//获取物料号
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
        drpWLH.text="";
    }
}

//加载物料号
function LoadWLH()
{
    var request=getXmlHttpRequest();
    var url="loadFYD.aspx?TYPE=6";
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

function GetWCBZ()
{
    var chkWCBZ=document.getElementById("chkWCBZ");
    var drpWCBZ=document.getElementById("drpWCBZ");
    if(chkWCBZ.checked)
    {
        drpWCBZ.disabled=false;
    }
    else
    {
        drpWCBZ.disabled=true;
    }
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
                drpPH.text=hidPH.value;
            }
            return;
        }
        if(LoadPH())
        {
           if(hidPH.value!=""&&hidPH.value.length>0)
            {
                drpPH.value=hidPH.value;
                drpPH.text=hidPH.value;
            }
            return;
        }
    }
    else
    {
        hidPH.value="";
        drpPH.options.length = 0;
        drpPH.disabled=true;
        drpPH.text="";
        drpPH.value="";
    }
}

//加载牌号
function LoadPH()
{
    var request=getXmlHttpRequest();
    var url="loadFYD.aspx?TYPE=7";
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

//获取属性
function GetSX()
{
    var chkSX=document.getElementById("chkSX");
    var drpSX=document.getElementById("drpSX");
    if(chkSX.checked)
    {
        drpSX.disabled=false;
    }
    else
    {
        drpSX.disabled=true;
    }
}

//获取规格
function GetGG()
{
    var chkGG=document.getElementById("chkGG");
    var drpGG=document.getElementById("drpGG");
    var drpCopyGG=document.getElementById("drpCopyGG");
    if(chkGG.checked)
    {
        drpGG.disabled=false;
        drpCopyGG.disabled=false;
    }
    else
    {
       drpGG.disabled=true;
       drpCopyGG.disabled=true;
       drpGG.value="请选择";
       drpCopyGG.value="请选择";
    }  
}
//获取特殊信息
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
                drpTSXX.text=hidTSXX.value;
            }
            return;
        }
        if(LoadTSXX())
        {
           if(hidTSXX.value!=""&&hidTSXX.value.length>0)
            {
                drpTSXX.value=hidTSXX.value;
                drpTSXX.text=hidTSXX.value;
            }
            return;
        }
    }
    else
    {
        hidTSXX.value="";
        drpTSXX.options.length = 0;
        drpTSXX.disabled=true;
        drpTSXX.value="";
        drpTSXX.text="";
    }
}

//加载特殊信息
function LoadTSXX()
{
    var request=getXmlHttpRequest();
    var url="loadFYD.aspx?TYPE=11";
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

//获取客户号
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
                drpKHH.text=hidKHH.value;
            }
            return;
        }
        if(LoadKHH())
        {
           if(hidKHH.value!=""&&hidKHH.value.length>0)
            {
                drpKHH.value=hidKHH.value;
                drpKHH.text=hidKHH.value;
            }
            return;
        }
    }
    else
    {
        hidKHH.value="";
        drpKHH.options.length = 0;
        drpKHH.disabled=true;
        drpKHH.value="";
        drpKHH.text="";
    }
}

//加载客户号
function LoadKHH()
{
    var request=getXmlHttpRequest();
    var url="loadFYD.aspx?TYPE=12";
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

//获取地址
function GetADD()
{
    var hidADD=document.getElementById("hidADD");
    var chkADD=document.getElementById("chkADD");
    var drpADD=document.getElementById("drpADD");
    if(chkADD.checked)
    {
        //已经加载过
        if(drpADD.options.length>0)
        {
            if(hidADD.value!=""&&hidADD.value.length>0)
            {
                drpADD.value=hidADD.value;
                drpADD.text=hidADD.value;
            }
            return;
        }
        if(LoadADD())
        {
           if(hidADD.value!=""&&hidADD.value.length>0)
            {
                drpADD.value=hidADD.value;
                drpADD.value=hidADD.value;
            }
            return;
        }
    }
    else
    {
        hidADD.value="";
        drpADD.options.length = 0;
        drpADD.disabled=true;
        drpADD.text="";
        drpADD.value="";
    }
}

//加载地址
function LoadADD()
{
    var request=getXmlHttpRequest();
    var url="loadFYD.aspx?TYPE=13";
    var drpADD=document.getElementById("drpADD");
    drpADD.disabled=false;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpADD.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/AimAdress");
　　	var itemsLength=items1.length; 
　　	if(itemsLength>0)
　　	{
　　	    var varItem = new Option("请选择","请选择");
　　	    drpADD.options.add(varItem); 
　　	}
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpADD.options.add(newOption); 
　	　	}
　	　	return true;
    }
}

//获取批次
function GettxtPC()
{  
    var txtPC=document.getElementById("txtPC");
    var chktxtPC=document.getElementById("chktxtPC");
    if(chktxtPC.checked)
    {
            txtPC.readOnly=false;
            txtPC.focus();
    }
    else
    {
            txtPC.readOnly=true;
            txtPC.value="";
    }
}
//获取批次
function GettxtFree1()
{  
    var txtPC=document.getElementById("txtFree1");
    var chktxtPC=document.getElementById("chkFree1");
    if(chktxtPC.checked)
    {
            txtPC.readOnly=false;
            txtPC.focus();
    }
    else
    {
            txtPC.readOnly=true;
            txtPC.value="";
    }
}
//获取批次
function GettxtFree2()
{  
    var txtPC=document.getElementById("txtFree2");
    var chktxtPC=document.getElementById("chkFree2");
    if(chktxtPC.checked)
    {
            txtPC.readOnly=false;
            txtPC.focus();
    }
    else
    {
            txtPC.readOnly=true;
            txtPC.value="";
    }
}
//获取批次
function GettxtFree3()
{  
    var txtPC=document.getElementById("txtFree3");
    var chktxtPC=document.getElementById("chkFree3");
    if(chktxtPC.checked)
    {
            txtPC.readOnly=false;
            txtPC.focus();
    }
    else
    {
            txtPC.readOnly=true;
            txtPC.value="";
    }
}


//获取进门卡号
function GetJMKH()
{  
    var txtJMKH=document.getElementById("txtJMKH");
    var chkJMKH=document.getElementById("chkJMKH");
    if(chkJMKH.checked)
        {
            txtJMKH.readOnly=false;
            txtJMKH.focus();
        }
     else
       {
            txtJMKH.readOnly=true;
            txtJMKH.value="";       }
}


//获取出门卡号
function GetCMKH()
{  
    var txtCMKH=document.getElementById("txtCMKH");
    var chkCMKH=document.getElementById("chkCMKH");
    if(chkCMKH.checked)
        {
            txtCMKH.readOnly=false;
            txtCMKH.focus();
        }
     else
       {
            txtCMKH.readOnly=true;
            txtCMKH.value="";
       }
}
//获取传输
function GetChuanShu()
{
    var chkChuanShu=document.getElementById("chkChuanShu");
    var drpChuanShu=document.getElementById("drpChuanShu");
    if(chkChuanShu.checked)
    {
        drpChuanShu.disabled=true;
    }
}

//制单日期
function GetMakeTime()
{
    var chkMakeTime=document.getElementById("chkMakeTime");
    var MakeStartTime=document.getElementById("MakeStartTime");
    var MakeEndTime=document.getElementById("MakeEndTime");
    if(chkMakeTime.checked)
    {
        MakeStartTime.disabled=false;
        MakeEndTime.disabled=false;
     }
     else
     {
        MakeStartTime.disabled=true;
        MakeEndTime.disabled=true;       
     }
}
//出库时间
function GetChuKuTime()
{
    var chkChuKuTime=document.getElementById("chkChuKuTime");
    var ChuKuStartTime=document.getElementById("ChuKuStartTime");
    var ChuKuEndTime=document.getElementById("ChuKuEndTime");
    if(chkChuKuTime.checked)
    {
        ChuKuStartTime.disabled=false;
        ChuKuEndTime.disabled=false;
     }
     else
     {
        ChuKuStartTime.disabled=true;
        ChuKuEndTime.disabled=true;
      }
}
//出门时间
function GetGoTime()
{
    var chkGoTime=document.getElementById("chkGoTime");
    var GoStartTime=document.getElementById("GoStartTime");
    var GoEndtime=document.getElementById("GoEndtime");
    if(chkGoTime.checked)
    {
        GoStartTime.disabled=false;
        GoEndtime.disabled=false;
     }
     else
     {
        GoStartTime.disabled=true;
        GoEndtime.disabled=true;
     }
}
//入门时间
function GetInTime()
{
    var chkInTime=document.getElementById("chkInTime");
    var InStartTime=document.getElementById("InStartTime");
    var InEndTime=document.getElementById("InEndTime");
    if(chkInTime.checked)
    {
        InStartTime.disabled=false;
        InEndTime.disabled=false;
     }
     else
     {
        InStartTime.disabled=true;
        InEndTime.disabled=true;
     }
}
//function GetZuoFei()
//{
//    var hidFYDHitem=document.getElementById("hidFYDHitem");//发运单号
//    var hidStatus=document.getElementById("hidStatus");//状态
//    var hidyslb=document.getElementById("hidyslb");//运输类别
//    if(hidFYDHitem.value=="")
//    {
//        alert('没有可选的发运单');
//        return false;
//    }
//    if(hidStatus.value=="已进厂")
//    {   
//        alert("该发运单正在装车，不能作废");
//        return false;
//    }
//    if(hidStatus.value=="装车完毕")
//    {
//        alert("该发运单已经装车完毕，不能作废");
//        return false;
//    }
//    if(hidStatus.value=="已出厂")
//    {
//        alert("该发运单车辆已经出厂，不能作废");
//        return false;
//        
//    }
//    if(hidStatus.value=="已作废")
//    {
//        alert("该发运单已经作废，不能重复作废");
//        return false;
//    }
//    if(hidyslb.value="火车发运" && hidStatus.value=="装车完毕")
//    {
//     alert('该火车发运单已经出厂，不能作废');
//     return false;
//    }
//    if(!confirm('是否作废该发运单？'))
//    {
//    return false;
//    }
//    url="FYDItem.aspx?action=zuofei&FYDH="+hidFYDHitem.value;
//    //alert(url);
//    window.location=url;
//}

//function GetCancelwc()
//{
//   var hidFYDHitem=document.getElementById("hidFYDHitem");//发运单号
//   var hidStatus=document.getElementById("hidStatus");//状态
//   var hidyslb=document.getElementById("hidyslb");//运输类别
//   if(hidStatus.value!="装车完毕")
//   {
//    alert("不能取消完成");
//    return false;
//   }
//   url="FYDItem.aspx?action=zuofei&FYDH="+hidFYDHitem.value;

//}

//修改车厢号
function GetChehao()
{
    var hidyslb=document.getElementById("hidyslb");//运输类别
    if(hidyslb.value=="" || hidyslb.value.length==0)
    {
        alert("请选择要修改的记录！");
    }
    if(hidyslb.value=="2")
    {
        var hidFYDHitem=document.getElementById("hidFYDHitem");//发运单号
        window.open('ModiCXH.aspx?FYDH='+hidFYDHitem.value, 'KHSC', 'height=100, width=280, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
    }
    else
    {
        alert("汽车发运,不能修改车厢号!");
        return false;
    }
}
function checkfydqr(fydh) {
    var request=getXmlHttpRequest();
    var url="LogincAjax.aspx?TYPE=38&fydh="+fydh;
    var txtzcsl=document.getElementById("txtzcsl");
    txtzcsl.value="";
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if (result!="") {
       alert(result);
       return result; 
    }
    else
    {
       displayDiv('popbox');
       return "";
    }
}
//察看发运单明细
function GetFYDItem()
{
    var iFrame=document.getElementById("frmList");
    var e = event.srcElement;
    var cheStatus=e.checked;
    
    var td = e.parentNode;
    var tr=td.parentNode;
    var table=tr.parentNode;
    var inputs=table.all.tags("INPUT");
    var hidFYDHitem=document.getElementById("hidFYDHitem");//发送单号
    var hidStatus=document.getElementById("hidStatus");//状态
    var hidyslb=document.getElementById("hidyslb");//运输类别
    
    var btnQuery = document.getElementById("btnQuery");
	var tblQuery = document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
    
    
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
        var strFYDH=inputs2[1].value;
        hidFYDHitem.value=strFYDH; 
        hidyslb.value=inputs2[2].value;
        hidStatus.value=inputs2[3].value;
        
        
        
        
//        var request=getXmlHttpRequest();
//    var url="LogincAjax.aspx?TYPE=38&fydh="+hidFYDHitem.value;
//    var txtCXH=document.getElementById("txtCXH");
//    txtCXH.value="";
//    sendRequest(url,"","POST",request);
//    var result = request.responseText;
//    if (result!="") {
//       alert(result);
//        e.checked=false;
//    }
//    else
//    {
//       displayDiv('popbox');
//    }
    
        var btnItem = document.getElementById("btnItem");
 	    var tblPList= document.getElementById("tblPList");
	    var hidItem = document.getElementById("hidItem");
	    btnItem.src = "../../images/icon/collapse.gif";
	    btnItem.alt = "关闭";
	    tblPList.style.display = "block";
	    hidItem.value = "block";
	    
	    btnQuery.src = "../../images/icon/expand.gif";
	    btnQuery.alt = "展开";
	    tblQuery.style.display = "none";
	    hidQuery="none";
       //AddQuery();
        iFrame.src="FYD_qrSearchItem.aspx?FYDH="+strFYDH;
    }
    else
    {
        hidFYDHitem.value="";
        hidyslb.value="";
        hidStatus.value="";
        var btnItem = document.getElementById("btnItem");
	    var tblPList= document.getElementById("tblPList");
	    var hidItem = document.getElementById("hidItem");
	    btnItem.src = "../../images/icon/expand.gif";
	    btnItem.alt = "展开";
	    tblPList.style.display = "none";
	    hidItem.value = "none";
	    
	    btnQuery.src = "../../images/icon/collapse.gif";
	    btnQuery.alt = "关闭";
	   // tblQuery.style.display = "block";
	    hidQuery="block";
    }
}

function closeDiv( menuId)
{
	if ( (menu = document.getElementById(menuId)) != null )
	{
		menu.style.display="none";
    }
    return( true);
}

//显示DIV
function displayDiv(menuId)
{	
    var hidFYDHitem=document.getElementById("hidFYDHitem");//发送单号
    if(hidFYDHitem.value==null || hidFYDHitem.value.length==0)
    {
        alert("请选择要进行装货确认的发运单！");
        return;
    }
    var hidYSLB=document.getElementById("hidyslb");
	var e = window.event;
	var menu = document.getElementById(menuId);
    menu.style.filter="alpha(opacity=0)";
	adjustPosition(e, menu);
	displayLater(menuId);
}
//显示DIV
function displayDivP(menuId)
{
	var e = window.event;
	var menu = document.getElementById(menuId);
    menu.style.filter="alpha(opacity=0)";
	adjustPosition(e, menu);
	displayLater(menuId);
}
//显示层
function displayLater( menuId)
{
	document.getElementById(menuId).style.filter="alpha(opacity=100)";
}
//调整显示位置
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

//function check(obj)
//{
//	var e = event.srcElement;
//	var table = e.parentNode.parentNode.parentNode.parentNode;
//	var row = table.all.tags("tr");
//	var row1 = row[1];
//	var texts = row1.all.tags("INPUT")
//	if(texts.length == 0)
//		return;
//	for(var i = 0; i < texts.length;i++)
//	{
//		texts[i].checked = obj.checked;	
//	}
//}