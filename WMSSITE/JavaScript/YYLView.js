// JScript 文件
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
function loadallyyl()
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
    var hidSX=document.getElementById("hidSX");
    var chkSX=document.getElementById("chkSX");
    var drpSX=document.getElementById("drpSX");
    if(hidSX.value!="" && hidSX.value!=null && hidSX.value.length>0)
    {
        chkSX.checked=true;
        GetSX();
    }
     //牌号
    var hidPH=document.getElementById("hidPH");
    var chkPH=document.getElementById("chkPH");
    var drpPH=document.getElementById("drpPH");
    if(hidPH.value!="" && hidPH.value!=null && hidPH.value.length>0)
    {
        chkPH.checked=true;
        GetPH();
    }
//        //加载模糊
//    var hidMOHU=document.getElementById("hidMOHU");
//    var chkMOHU=document.getElementById("chkMOHU");
//    if(hidMOHU.value!=null && hidMOHU.value!="" && hidMOHU.value.length>0)
//    {
//        chkMOHU.checked=true;
//     }
     
    //加载规格
    var chkGG=document.getElementById("chkGG");
    if(chkGG.checked)
    {
        GetGG();
        GetCopyGG();
    }
//    //仓库排序
//    var ImgPXCK=document.getElementById("ImgPXCK");
//    var chkPXCK=document.getElementById("chkPXCK");
//    var hidPXCK=document.getElementById("hidPXCK");
//    var hidimgPXCK=document.getElementById("hidimgPXCK");
//    if(hidPXCK.value!="")
//    {
//        chkPXCK.checked=true;
//        if(hidimgPXCK.value=="ASC")
//        {
//            ImgPXCK.src="../../images/icon/collapse.gif";
//        }
//        else
//        {
//            ImgPXCK.src="../../images/icon/expand.gif";
//        }
//    }
//    
//    //属性排序
//    var ImgPXSX=document.getElementById("ImgPXSX");
//    var chkPXSX=document.getElementById("chkPXSX");
//    var hidPXSX=document.getElementById("hidPXSX");
//    var hidimgPXSX=document.getElementById("hidimgPXSX");
//    if(hidPXSX.value!="")
//    {
//        chkPXSX.checked=true;
//        if(hidimgPXSX.value=="ASC")
//        {
//            ImgPXSX.src="../../images/icon/collapse.gif";
//        }
//        else
//        {
//            ImgPXSX.src="../../images/icon/expand.gif";
//        }
//    }
    
//     //牌号排序
//    var ImgPXPH=document.getElementById("ImgPXPH");
//    var chkPXPH=document.getElementById("chkPXPH");
//    var hidPXPH=document.getElementById("hidPXPH");
//    var hidimgPXPH=document.getElementById("hidimgPXPH");
//    if(hidPXPH.value!="")
//    {
//        chkPXPH.checked=true;
//        if(hidimgPXPH.value=="ASC")
//        {
//            ImgPXPH.src="../../images/icon/collapse.gif";
//        }
//        else
//        {
//            ImgPXPH.src="../../images/icon/expand.gif";
//        }
//    }
//         //规格排序
//    var ImgPXGG=document.getElementById("ImgPXGG");
//    var chkPXGG=document.getElementById("chkPXGG");
//    var hidPXGG=document.getElementById("hidPXGG");
//    var hidimgPXGG=document.getElementById("hidimgPXGG");
//    if(hidPXGG.value!="")
//    {
//        chkPXGG.checked=true;
//        if(hidimgPXGG.value=="ASC")
//        {
//            ImgPXGG.src="../../images/icon/collapse.gif";
//        }
//        else
//        {
//            ImgPXGG.src="../../images/icon/expand.gif";
//        }
//    }
    
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
    var url="loadYYLView.aspx?TYPE=1";
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
        ClearCK();
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

////选中SX复选框时运行的操作
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
    //LoadZDR();
    //GetZDR();
}
//加载仓库
function LoadSX()
{
    var request=getXmlHttpRequest();
    var url="loadYYLView.aspx?TYPE=2";
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
//清空仓库下拉框
function ClearSX()
{
    var drpSX=document.getElementById("drpSX");
	for(var i = 0;i<=drpSX.options.length -1;i++)
	{
　　	drpSX.remove(i);
　　}
}
//改变仓库号
function ChangeSX()
{
    var drpSX=document.getElementById("drpSX");
    var hidSX=document.getElementById("hidSX");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpSX.value!="请选择")
    {
        hidSX.value=drpSX.value;
    }
    if(drpSX.value=="请选择")
        hidSX.value="";
}

////选中PH复选框时运行的操作
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
    //LoadZDR();
    //GetZDR();
}
//加载仓库
function LoadPH()
{
    var request=getXmlHttpRequest();
    var url="loadYYLView.aspx?TYPE=3";
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
//清空仓库下拉框
function ClearPH()
{
    var drpPH=document.getElementById("drpPH");
	for(var i = 0;i<=drpPH.options.length -1;i++)
	{
　　	drpPH.remove(i);
　　}
}
//改变仓库号
function ChangePH()
{
    var drpPH=document.getElementById("drpPH");
    var hidPH=document.getElementById("hidPH");
    var chkZDR=document.getElementById("chkZDR");
 
    if(drpPH.value!="请选择")
    {
        hidPH.value=drpPH.value;
    }
    if(drpPH.value=="请选择")
        hidPH.value="";
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

    }
    
}

//加载规格
function LoadGG()
{
    var request=getXmlHttpRequest();
    var url="loadYYLView.aspx?TYPE=4";
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
    var url="loadYYLView.aspx?TYPE=4";
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
//获取模糊
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
//获取仓库排序
  function GetPXCK()
{
    var ImgPXCK=document.getElementById("ImgPXCK");
    var chkPXCK=document.getElementById("chkPXCK");
    var hidPXCK=document.getElementById("hidPXCK");
    var hidimgPXCK=document.getElementById("hidimgPXCK");
    if(chkPXCK.checked)
    {
    ImgPXCK.src="../../images/icon/collapse.gif";
    hidPXCK.value=true;
    hidimgPXCK.value="ASC";
    }
    else
    {
    ImgPXCK.src="../../images/icon/Not_ASC.gif";
    hidPXCK.value="";
    hidimgPXCK.value="";
    
    }
    
}
function PXCK()
{
    var ImgPXCK=document.getElementById("ImgPXCK");
    var chkPXCK=document.getElementById("chkPXCK");
    var hidPXCK=document.getElementById("hidPXCK");
    var hidimgPXCK=document.getElementById("hidimgPXCK");
    if(hidPXCK.value=="")
        {
            return false;
        }
      if(hidimgPXCK.value=="ASC")
        { 
            ImgPXCK.src="../../images/icon/expand.gif";
            hidimgPXCK.value="DESC";
         }
       else
         {
            ImgPXCK.src="../../images/icon/collapse.gif";
            hidimgPXCK.value="ASC";
         }
 
 }  
 
 //获取属性排序规则
   function GetPXSX()
{
    var ImgPXSX=document.getElementById("ImgPXSX");
    var chkPXSX=document.getElementById("chkPXSX");
    var hidPXSX=document.getElementById("hidPXSX");
    var hidimgPXSX=document.getElementById("hidimgPXSX");
    if(chkPXSX.checked)
    {
    ImgPXSX.src="../../images/icon/collapse.gif";
    hidPXSX.value=true;
    hidimgPXSX.value="ASC";
    }
    else
    {
    ImgPXSX.src="../../images/icon/Not_ASC.gif";
    hidPXSX.value="";
    hidimgPXSX.value="";
    
    }
    
}
function PXSX()
{
    var ImgPXSX=document.getElementById("ImgPXSX");
    var chkPXSX=document.getElementById("chkPXSX");
    var hidPXSX=document.getElementById("hidPXSX");
    var hidimgPXSX=document.getElementById("hidimgPXSX");
    if(hidPXSX.value=="")
        {
            return false;
        }
      if(hidimgPXSX.value=="ASC")
        { 
            ImgPXSX.src="../../images/icon/expand.gif";
            hidimgPXSX.value="DESC";
         }
       else
         {
            ImgPXSX.src="../../images/icon/collapse.gif";
            hidimgPXSX.value="ASC";
         }
 
 } 
 
  //获取牌号排序规则
   function GetPXPH()
{
    var ImgPXPH=document.getElementById("ImgPXPH");
    var chkPXPH=document.getElementById("chkPXPH");
    var hidPXPH=document.getElementById("hidPXPH");
    var hidimgPXPH=document.getElementById("hidimgPXPH");
    if(chkPXPH.checked)
    {
    ImgPXPH.src="../../images/icon/collapse.gif";
    hidPXPH.value=true;
    hidimgPXPH.value="ASC";
    }
    else
    {
    ImgPXPH.src="../../images/icon/Not_ASC.gif";
    hidPXPH.value="";
    hidimgPXPH.value="";
    
    }
    
}
function PXPH()
{
    var ImgPXPH=document.getElementById("ImgPXPH");
    var chkPXPH=document.getElementById("chkPXPH");
    var hidPXPH=document.getElementById("hidPXPH");
    var hidimgPXPH=document.getElementById("hidimgPXPH");
    if(hidPXPH.value=="")
        {
            return false;
        }
      if(hidimgPXPH.value=="ASC")
        { 
            ImgPXPH.src="../../images/icon/expand.gif";
            hidimgPXPH.value="DESC";
         }
       else
         {
            ImgPXPH.src="../../images/icon/collapse.gif";
            hidimgPXPH.value="ASC";
         }
 
 }  
 
  //获取规格排序规则
   function GetPXGG()
{
    var ImgPXGG=document.getElementById("ImgPXGG");
    var chkPXGG=document.getElementById("chkPXGG");
    var hidPXGG=document.getElementById("hidPXGG");
    var hidimgPXGG=document.getElementById("hidimgPXGG");
    if(chkPXGG.checked)
    {
    ImgPXGG.src="../../images/icon/collapse.gif";
    hidPXGG.value=true;
    hidimgPXGG.value="ASC";
    }
    else
    {
    ImgPXGG.src="../../images/icon/Not_ASC.gif";
    hidPXGG.value="";
    hidimgPXGG.value="";
    
    }
    
}
function PXGG()
{
    var ImgPXGG=document.getElementById("ImgPXGG");
    var chkPXGG=document.getElementById("chkPXGG");
    var hidPXGG=document.getElementById("hidPXGG");
    var hidimgPXGG=document.getElementById("hidimgPXGG");
    if(hidPXGG.value=="")
        {
            return false;
        }
      if(hidimgPXGG.value=="ASC")
        { 
            ImgPXGG.src="../../images/icon/expand.gif";
            hidimgPXGG.value="DESC";
         }
       else
         {
            ImgPXGG.src="../../images/icon/collapse.gif";
            hidimgPXGG.value="ASC";
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
		AddQuery();
	}
	if(Hidconfig.value!="")
	{
		tablecon.style.display = "none";
		if( Hidconfig.value== "none")
			tablecon.style.display = "block";
		Addconfig();
	}
	    loadallyyl();
}
