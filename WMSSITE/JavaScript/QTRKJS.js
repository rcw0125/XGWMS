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

//得到仓库、货位、重量
function GetRKItem(rIndex)
{
    var e = event.srcElement;
    var td = e.parentNode;
         var e = event.srcElement;
    var cheStatus=e.checked;
    
    var tr=td.parentNode;
    var table=tr.parentNode;
    var inputs=table.all.tags("INPUT");
    var txtYCK=document.getElementById("txtYu");
    var txtYHW=document.getElementById("txtMu");
    var txtRKZL=document.getElementById("txtRKZL");//重量
    var hidTM=document.getElementById("hidTM");//条码
    var hidFYDH=document.getElementById("hidFYDH");//完工单号
    var hidRKHW=document.getElementById("hidRKHW");//隐藏货位
    
    var hidRowIndex=document.getElementById("hidRowIndex");
    hidRowIndex.value=rIndex;
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
      txtYCK.value=inputs2[1].value;
      txtYHW.value=inputs2[2].value;
      txtRKZL.value=inputs2[3].value;
      hidTM.value=inputs2[4].value;
      hidFYDH.value=inputs2[5].value;
      }
//    var tds=tr.all.tags("td");
//    KHBM.value=tds[1].innerText;
//    KHName.value=tds[2].innerText;
//    CPH.value=tds[3].innerText;
//    Proposer.options.value=texts[2].value;
}

//重量(增加)
function AddZL()
{
    var txtRKZL=document.getElementById("txtRKZL");
    var isNum=/^\-?[0-9]*\.?[0-9]*$/;
    if(!(isNum.test(txtRKZL.value)))
    {
        txtRKZL.value="0";
        return;
    } 
    var gh=txtRKZL.value;
    var str1="0.0001";
    var sum=0;
    if(Number(txtRKZL.value))
    {
        sum=parseFloat(gh)+parseFloat(str1);
        txtRKZL.value=Math.round(sum*10000)/10000;
    }  
    if(Number(txtRKZL.value)<=0)
    {
        txtRKZL.value="0.0001";
    }

}
//重量(减少)
function DelZL()
{
    var txtRKZL=document.getElementById("txtRKZL");
    var isNum=/^\-?[0-9]*\.?[0-9]*$/;
    if(!(isNum.test(txtRKZL.value)))
    {
        txtRKZL.value="0";
        return;
    } 
    var gh=txtRKZL.value;
    var str1="0.0001";
    var sum=0;
    if(Number(txtRKZL.value))
    {
        sum=parseFloat(gh)-parseFloat(str1);
        if(sum<0)
            sum=0;
        txtRKZL.value=Math.round(sum*10000)/10000;
    }
     
}
//加载货位
function LoadHW()
{
    var request=getXmlHttpRequest();
    
       var drpRKCK=document.getElementById("drpRKCK");//仓库
    var drpRKHW=document.getElementById("drpRKHW");//货位
    var url="loadQTRK.aspx?TYPE=1&ck="+drpRKCK.options.value;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    if(result.indexOf("ERROR")!=-1)
    {
        window.alert("数据访问失败，请重试！");
        return false;
    }
    else
    {
        drpRKHW.options.length = 0;
        var oDoc=getXmlDocument();
        oDoc.loadXML(result);
　　	var items1 = oDoc.selectNodes("//NewDataSet/Table/hwid");
　　	var itemsLength=items1.length; 
　　	for(i=0;i<itemsLength;i++) 
		{ 　　			
			var newOption = document.createElement("OPTION"); 
　　		newOption.text=items1[i].text; 
　　		newOption.value=items1[i].text;
　　		drpRKHW.options.add(newOption); 
　	　	}
　	　	return true;
    }
}
function ChangeRKHW()
{
    var drpRKHW=document.getElementById("drpRKHW");//货位
    var hidRKHW=document.getElementById("hidRKHW");
    hidRKHW.value=drpRKHW.options.value;
}

//入库
function get_QTRK()
{
    var hidTM=document.getElementById("hidTM");//条码
    var txtYUCK=document.getElementById("txtYu");//源仓库
    var txtYUHW=document.getElementById("txtMu");
    var hidFYDH=document.getElementById("hidFYDH");//完工单号
    var drpRKCK=document.getElementById("drpRKCK");
    var drpRKHW=document.getElementById("drpRKHW");//入库货位
    
    var txtRKZL=document.getElementById("txtRKZL");//重量
    var drpCKType=document.getElementById("drpCKType");//仓库类型
    var hidRIndex=document.getElementById("hidRowIndex");//行号
    if(hidFYDH.value==""||hidFYDH.value.length==0)
    {
        alert("请选择入库记录！");
        return false;    
    }
    if (hidTM.Value == "")
    {
       alert("没有选定记录！");
       return false;
    }
    var isQuantity= /^\-?[0-9]*\.?[0-9]*$/;
    if(!(isQuantity.test(txtRKZL.value))||Number(txtRKZL.value)<=0)
    {
        alert("重量非法");
        return false;
    }
    if (drpRKCK.options[drpRKCK.selectedIndex].value == "请选择")
    {
        alert("请指定仓库！");
        return false;
    }
    if (drpRKHW.options.value == "请选择")
    {
        alert("请指定货位！");
        return false;
    }
    if(!confirm("是否入库?"))
    {
        return false;
    }
    else
    {
        url="loadQTRK.aspx?type=ruku&ZKDH="+hidFYDH.value+"&tm="+hidTM.value+"&rkhw="+drpRKHW.options.value+"&drpCKType="+encodeURI(drpCKType.options.value)+"&ck="+drpRKCK.options.value+"&txtzl="+txtRKZL.value;
        var request=getXmlHttpRequest();
        sendRequest(url,"","POST",request); 
        var result = request.responseText;
        if(result=="1")
        {
            alert("该单卷已经在库中！");
            return false;
        }
        if(result=="NotRu")
        {
            alert("单据状态不符合其他入库的要求，不能入库!");
            return false;
        }
        if(result=="NotHW")
        {
            alert("当前货位不可用");
            return false;
        }
        if(result=="SUCCESS")
        {
            var dTable=document.getElementById("grvQTRK");  
            dTable.deleteRow(hidRIndex.value);
            txtYUCK.value="";
            txtYUHW.value="";
            hidRIndex.value="";
            hidTM.value="";
            hidFYDH.value="";
            alert("入库成功");
            return false;
        }
        if(result=="ERROR")
        {
            alert("数据访问错误!");
            return false;
        }
    }
}