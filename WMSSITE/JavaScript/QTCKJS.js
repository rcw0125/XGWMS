// JScript 文件

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
//查询
function SelectCKD()
{
    var hidZT=document.getElementById("hidZT");
    if(hidZT.value=="Add")
    {
        return;
    }
    if(hidZT.value == "Modify")
    {
        return;
    }
    window.open('Query_QTCK.aspx', '选择其它出库单', 'height=400, width=480, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
}

function PrintCKD()
{
    var hidZT=document.getElementById("hidZT");
    var txtCKDH = document.getElementById("txtCKDH");
    if(hidZT.value=="Add")
    {
        return;
    }
    if(hidZT.value == "Modify")
    {
        return;
    }
    window.open('Query_print.aspx?CKDH='+txtCKDH.value, '打印其它出库单', 'height=600, width=800, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
}



function AllQTCK()
{
    var chkZDRQ=document.getElementById("chkZDRQ");
    var hidZDRQ=document.getElementById("hidZDRQ");
    var txtZDRQ1=document.getElementById("txtZDRQ1");
    var txtZDRQ2=document.getElementById("txtZDRQ2");
    if(hidZDRQ.value!=""&&hidZDRQ.value!=null&&hidZDRQ.value.length>0)
    {
    chkZDRQ.checked=true;
    txtZDRQ1.disabled=false;
    txtZDRQ2.disabled=false;
    }
}
function GetZDRQ()
{
    var chkZDRQ=document.getElementById("chkZDRQ");
    var hidZDRQ=document.getElementById("hidZDRQ");
    var txtZDRQ1=document.getElementById("txtZDRQ1");
    var txtZDRQ2=document.getElementById("txtZDRQ2");
    if(chkZDRQ.checked)
    {
        txtZDRQ1.disabled=false;
        txtZDRQ2.disabled=false;
        hidZDRQ.value=true;
    }
    else
    {
        txtZDRQ1.disabled=true;
        txtZDRQ2.disabled=true;
        hidZDRQ.value="";
    }
}
function GetChuCk()
{
    //var iFrame=window.opener.document.getElementById("frmList");
    var CKDH = "";
    var e = event.srcElement;
    var tr = e.parentNode.parentNode;
    var tds=tr.all.tags("td");
    CKDH = tds[1].innerText;;
    window.opener.document.location="QTCKDan.aspx?CKDH="+CKDH;
    //iFrame.src="QTCKD_item.aspx?CKDH="+CKDH;
    window.close();
}



//取消
function cancel()
{
    if(!confirm('确实要取消对该单据的操作吗?')) 
    {
       return false;
    }
}

function cancelMX()
{
    var tableMX = document.getElementById("tableMX");
    var ListDiv = document.getElementById("ListDiv");
    tableMX.style.display = "none";
    ListDiv.style.display = "block";
    
    var txtPCH = document.getElementById("txtPCH");
    var drpSX = document.getElementById("drpSX");
    var drpFree1=document.getElementById("drpFree1");
    var drpFree2=document.getElementById("drpFree2");
    var drpFree3=document.getElementById("drpFree3");
    var txtWLH = document.getElementById("txtWLH");
    var txtWLMC = document.getElementById("txtWLMC");
    var txtPH = document.getElementById("txtPH");
    var txtGG = document.getElementById("txtGG");
    var txtJHSL = document.getElementById("txtJHSL");
    var txtJHZL = document.getElementById("txtJHZL");
    
    txtPCH.value = "";
    drpSX.options.length = 0;
    drpFree1.options.length=0;
    drpFree2.options.length=0;
    drpFree3.options.length=0;
    txtWLH.value = "";
    txtWLMC.value = "";
    txtPH.value = "";
    txtGG.value = "";
    txtJHSL.value = "";
    txtJHZL.value = "";
}




//添加
function AddItem()
{
    var drpFHCK = window.parent.document.getElementById("drpFHCK");
    var hidZT=window.parent.document.getElementById("hidZT");
    var txtCKDH = window.parent.document.getElementById("txtCKDH"); //父窗体中出库单号框
    var hidCKDH = document.getElementById("hidCKDH");
    var tableMX = document.getElementById("tableMX");
    var ListDiv = document.getElementById("ListDiv");
    var hidMXZT = document.getElementById("hidMXZT");
    if(hidZT.value==""||hidZT.value==null)
    {
        return;
    }
    if(hidZT.value=="Add")
    {
        if(txtCKDH.value=="")
        {
            alert("没有出库单号，请取消后重新新建单据");
            return;
        }
        if(drpFHCK.options.value==""||drpFHCK.options.value=="请选择")
        {
             alert("请选择发货仓库");
             return;
        }
        hidCKDH.value = txtCKDH.value;
        tableMX.style.display = "block";
        ListDiv.style.display = "none";
        hidMXZT.value = "Add";
    }
    if(hidZT.value=="Modify")
    {
        if(txtCKDH.value=="")
        {
            alert("没有出库单号，请取消后重新新建单据");
            return;
        }
        if(drpFHCK.options.value==""||drpFHCK.options.value=="请选择")
        {
             alert("请选择发货仓库");
             return;
        }
        hidCKDH.value = txtCKDH.value;
        tableMX.style.display = "block";
        ListDiv.style.display = "none";
        hidMXZT.value = "Add";
    }
}
function loadAll()
{
    var tableMX = document.getElementById("tableMX");
    var ListDiv = document.getElementById("ListDiv");    
    var hidMXZT = document.getElementById("hidMXZT");
    if(hidMXZT.value == "Add")
    {
        tableMX.style.display = "block";
        ListDiv.style.display = "none";
    }
    if(hidMXZT.value == "Modify")
    {
        tableMX.style.display = "block";
        ListDiv.style.display = "none";
    }
}

function DeleteMX()
{
   if(!confirm('确实要删除该记录吗?'))
    {
        return false;
    }
}

function GetItem()
{
    var hidCKDH = document.getElementById("hidCKDH");
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
    hidCKDH.value=tds[1].innerText;
    var frameItem = document.getElementById("frameItem");
    frameItem.src = "PrintQTCKItem.aspx?CKDH="+hidCKDH.value;
}

























//function PrintOK()
//{
//    var drpPrintType = document.getElementById("drpPrintType");
//    if(drpPrintType.value == "请选择" || drpPrintType.value == "")
//    {
//        alert("请先选择打印类型");
//        return;
//    }    
//}



////修改单据
//function Modidj()
//{
//    var iFrame1=document.getElementById("frmList1");
//    var txtCKDH=document.getElementById("txtCKDH");
//      var Current=document.getElementById("Current");
//    if(Current.value=="NewDJ")
//    {
//         alert("当前是新建单据状态");
//         return false;
//    }
//    if(txtCKDH.value=="")
//    {
//    alert("请先选择要修改单据");
//    return false;
//    }
//    iFrame1.src="QTCKD_item.aspx?action=modidj&ckdh="+txtCKDH.value;
//}
////删除单据
//function DelDJ()
//{
//    var txtCKDH=document.getElementById("txtCKDH");
//    var Current=document.getElementById("Current");
//    if(Current.value=="NewDJ")
//    {
//         alert("当前是新建单据状态");
//         return false;
//    }
//    if(txtCKDH.value=="")
//    {
//        alert("请选择要删除的出库单");
//        return false;
//    }
//    var request=getXmlHttpRequest();
//    var url="BrowseQTCK.aspx?action=deldj&ckdh="+txtCKDH.value;
//    sendRequest(url,"","POST",request);
//    var result = request.responseText;
//   if(result=="NotDel")
//   {
//   alert("该单据已经执行，不能删除");
//   return false;
//   }
//   if(result=="false")
//   {
//       if(!confirm('确实要删除此出库单吗?'))
//        {
//            return false;
//        }
//        else
//        {
//        delckd();
//        }
//   }

//}
//function delckd()
//{
//     var txtCKDH=document.getElementById("txtCKDH");
//    var request=getXmlHttpRequest();
//    var url="BrowseQTCK.aspx?action=zaideldj&ckdh="+txtCKDH.value;
//    sendRequest(url,"","POST",request);
//    var result = request.responseText;
//     
//}
////重置单据
//function ChongZhiDJ()
//{
//    var txtCKDH=document.getElementById("txtCKDH");
//    var Current=document.getElementById("Current");
//    if(Current.value=="NewDJ")
//    {
//         alert("当前是新建单据状态");
//         return false;
//    }
//    if(txtCKDH.value=="")
//    {
//        alert("请选择要重置的单据");
//        return false;
//    }
//     var request=getXmlHttpRequest();
//        var url="BrowseQTCK.aspx?action=ChongZhi&ckdh="+txtCKDH.value;
//        sendRequest(url,"","POST",request);
//        var result = request.responseText;
//        if(result=="NotChongZhi")
//        {
//            alert("该单据已经执行完成，不能重置");
//            return false;
//        }
//        if(result=="NoYong")
//        {
//            alert("不用重置");
//            return false;
//        }
//        if(result == "false")
//        {
//            if(!confirm('重置单据将删除正在装车的装车信息，确实要重置该单据吗？')) 
//            {
//              return false;
//             }
//             else
//             {
//                zaicz();
//             }
//        }
//   
//}
//function zaicz()
//{
//    var txtStatus=document.getElementById("txtStatus");
//    var txtCKDH=document.getElementById("txtCKDH");
//    var url="BrowseQTCK.aspx?action=ZaiChongZhi&ckdh="+txtCKDH.value;
//    var request=getXmlHttpRequest();
//    sendRequest(url,"","POST",request); 
//    var result = request.responseText;
//    if(result=="new")
//     {
//     txtStatus.value="新建";
//      }
//}

////取消完成
//function CancelDJ()
//{
//    var txtStatus=document.getElementById("txtStatus");
//    var txtCKDH=document.getElementById("txtCKDH");
//     if(txtCKDH.value=="")
//    {
//        alert("请选择要重置的单据");
//        return false;
//    }
//     var url="BrowseQTCK.aspx?action=CancelDJ&ckdh="+txtCKDH.value;
//    var request=getXmlHttpRequest();
//    sendRequest(url,"","POST",request); 
//    var result = request.responseText;
//     if(result=="NoCancel")
//     {
//     alert("不用取消");
//     return false;
//     }
//     if(result=="false")
//     {
//      if(!confirm('该单据已经关闭，此操作将打开单据，确实要执行该操作吗？')) 
//            {
//              return false;
//             }
//             else
//             {
//                zaiWC();
//             }
//     
//     }

//}
//function zaiWC()
//{
// var txtCKDH=document.getElementById("txtCKDH");
// var txtFHCK=document.getElementById("txtFHCK");
// var txtStatus=document.getElementById("txtStatus");
//     var url="BrowseQTCK.aspx?action=zaiCancelDJ&ckdh="+txtCKDH.value+"&fhck="+txtFHCK.options.value;
//    var request=getXmlHttpRequest();
//    sendRequest(url,"","POST",request); 
//    var result = request.responseText;
//    if(result=="zhixing")
//    {
//    txtStatus.value="正在执行";
//    }
//    if(result=="wrong")
//    {
//    alert("取消完成失败！");
//    return false;
//    }
//}
//保存
//function SaveDJ()
//{
// var txtStatus=document.getElementById("txtStatus");
//    var txtCKDH=document.getElementById("txtCKDH");
//    var drpFHCK=document.getElementById("drpFHCK");
//    var drpCKLX=document.getElementById("drpCKLX");
//    var txtNCDJ=document.getElementById("txtNCDJ");
//    var txtCPH=document.getElementById("txtCPH");
//    var txtNCDJ=document.getElementById("txtNCDJ");
//    var txtTARGET=document.getElementById("txtTARGET");
//    var drpCYS=document.getElementById("drpCYS");
//    var drpSHDW=document.getElementById("drpSHDW");
//    var txtZDR=document.getElementById("txtZDR");
//    var txtZDRQ=document.getElementById("txtZDRQ");
//    var Current=document.getElementById("Current");
//    if(drpFHCK.options.value=="请选择")
//    {
//        alert("请正确选择仓库信息");
//        return false;
//    }
//    if(drpCKLX.options.value=="请选择")
//    {
//        alert("请输入出库类型")
//        return false;
//    }
//    if(txtNCDJ.value=="")
//    {   
//        alert("请输入NC单据号");
//        return false;
//    }
//     var url="BrowseQTCK.aspx?action=SaveDJ&ckdh="+txtCKDH.value+"&status="+txtStatus.value+"&ckdh="+txtCKDH.value+"&ck="+drpFHCK.options.value+"&ncdj="+txtNCDJ.value+"&cph="+txtCPH.value+"&txtTARGET="+txtTARGET.value+"&CYS="+drpCYS.options.value+"&SHDW="+drpSHDW.options.value+"&ZDR="+txtZDR.value+"&ZDRQ="+txtZDRQ.value+"&Current="+Current.value;
//    //alert(url);
//    var request=getXmlHttpRequest();
//    sendRequest(url,"","POST",request); 
//    var result = request.responseText;
//    if(result=="NoMODI")
//    {
//        alert("该单据已经执行，不能修改");
//        return false;
//    }
//    if(result=="tongyi")
//    {
//    alert("同一单据中不能出现同一批次属性的物料信息");
//    return false;
//    }

//}

////统计打印
//function TJprint()
//{
//    var txtCKDH=document.getElementById("txtCKDH");
//    window.open('Query_print.aspx?ckdh='+txtCKDH.value, '选择其它出库单', 'height=550, width=800, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');

//}