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
function Init() {
   var tblQuery = document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
	var btnQuery = document.getElementById("btnQuery");
	
	
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
	    //tblPList.style.display="none";
	    btnItem.src = "../../images/icon/expand.gif";
		btnItem.alt = "展开";
	}
	
	LoadAllFYD();
}
function LoadAllFYD() {
    //加载仓库
    var chkCKH=document.getElementById("chkCKH");
    var drpCKH=document.getElementById("drpCKH");
    if(chkCKH.checked)
    {
        drpCKH.disabled=false;
    }
    else
        drpCKH.disabled=true;
    
    var chkZDR=document.getElementById("chkZDR");
    var drpZDR=document.getElementById("drpZDR");
    if(chkZDR.checked)
        drpZDR.disabled=false;
    else
        drpZDR.disabled=true;
        
    //加载状态
    var chkWCBZ=document.getElementById("chkWCBZ");
    var drpWCBZ=document.getElementById("drpWCBZ");
    if(chkWCBZ.checked)
        drpWCBZ.disabled=false;
    else
        drpWCBZ.disabled=true;
        
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
        iFrame.src="ZYPDItem.aspx?action=item&PDDH="+strFYDH;
    }
    else
    {
        hidFYDHitem.value="";
        var btnItem = document.getElementById("btnItem");
	    var tblPList= document.getElementById("tblPList");
	    var hidItem = document.getElementById("hidItem");
	    btnItem.src = "../../images/icon/expand.gif";
	    btnItem.alt = "展开";
	    tblPList.style.display = "none";
	    hidItem.value = "none";
	    
	    btnQuery.src = "../../images/icon/collapse.gif";
	    btnQuery.alt = "关闭";
	    tblQuery.style.display = "block";
	    hidQuery="block";
    }
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