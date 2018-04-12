// JScript 文件

/*数据编辑*/
function AddQuery()
{
    var dataedit=document.getElementById("dataedit");
	var imgData = document.getElementById("imgData");
	var hidData = document.getElementById("hidData");
	var Print1 = document.getElementById("Print1");
	var hidPrint = document.getElementById("hidPrint");
	if(dataedit.style.display == "block")
	{
		imgData.src = "../../images/icon/expand.gif";
		imgData.alt = "展开";
		dataedit.style.display = "none";
		hidData.value= "none";
	}
	else
	{
		imgData.src = "../../images/icon/collapse.gif";
		imgData.alt = "关闭";
		dataedit.style.display = "block";
		hidData.value = "block";
	}
	
}



/*显示或者隐藏打印配置*/
function Addconfig() 
{
	var imgPrint = document.getElementById("imgPrint");
	var Print1 = document.getElementById("Print1");
	var hidPrint = document.getElementById("hidPrint");
	if(Print1.style.display ==  "block")
	{
		imgPrint.src = "../../images/icon/expand.gif";
		imgPrint.alt = "展开";
		Print1.style.display = "none";
		hidPrint.value= "none";
	}
	else
	{
		imgPrint.src = "../../images/icon/collapse.gif";
		imgPrint.alt = "关闭";
		Print1.style.display = "block";
		hidPrint.value= "block";
	}
}
/*页面初始化，完工单查询*/
function Init()
{
    var dataedit=document.getElementById("dataedit");
    var hidData = document.getElementById("hidData");
	
	
	var Print1 = document.getElementById("Print1")
    var hidPrint = document.getElementById("hidPrint");
 
/*	window.alert(HidBase.value); 调试用的*/
	if(hidData.value!="")
	{
		dataedit.style.display = "none";
		if( hidData.value== "none")
			dataedit.style.display = "block";
		AddQuery();
	}
	if(hidPrint.value!="")
	{
		Print1.style.display = "none";
		if( hidPrint.value== "none")
			Print1.style.display = "block";
		Addconfig();
	}
	

}
function checkprint()
{
var chkPrintDrp=document.getElementById("chkPrintDrp");
var Drpprint=document.getElementById("Drpprint");
var txtROW1=document.getElementById("txtROW1");
var txtCOLUMN1=document.getElementById("txtCOLUMN1");
var txtminROW=document.getElementById("txtminROW");
var txtmaxROW=document.getElementById("txtmaxROW");
var txtminColumn=document.getElementById("txtminColumn");
var txtmaxColumn=document.getElementById("txtmaxColumn");
if(chkPrintDrp.options.value==""||chkPrintDrp.options.value==null)
{
alert('仓库不能为空');
return false;
}
if(Drpprint.options.value=='单个打印')
    {

        if (txtROW1.value==""||txtROW1.value==null||txtROW1.value.length>2)
        {        
            alert('行号错误，请重新输入！(1-99)');
            return false;
        }
        if(isNaN(txtROW1.value))
        {
          alert('行号错误，请重新输入！(1-99)');
           return false;
        }
        if(txtCOLUMN1.value==""||txtCOLUMN1.value==null||txtCOLUMN1.value.length>2)
        {
            alert('列号错误，请重新输入！(1-99)');
            return false;
        }
         if(isNaN(txtCOLUMN1.value))
        {
          alert('列号错误，请重新输入！(1-99)');
           return false;
        }
   url = "../../PrintCode.aspx?STORE=" + chkPrintDrp.options.value + "&SROW=" + txtROW1.value+ "&TROW=0&SCOL=" + txtCOLUMN1.value + "&TCOL=0";
         
     window.open(url);

    }
  if(Drpprint.options.value=='批量打印')
  {
    if(txtminROW.value==""||txtminROW.value==null)
    {
           alert('起始行号错误，不能为空！(1-99)');
           return false;
    }
    if(txtminROW.value.length>2)
    {
        alert('起始行号错误，请重新输入！(1-99)');
        return false;
        
    }
    if(isNaN(txtminROW.value))
    {
     alert('起始行号错误，请重新输入！(1-99)');
           return false;
    }
    
    if(txtmaxROW.value==""||txtmaxROW.value==null)
    {
           alert('终止行号错误，不能为空！(1-99)');
           return false;
    }
    if(txtmaxROW.value.length>2)
    {
        alert('终止行号错误，请重新输入!(1-99)');
        return false;
    }
    if(isNaN(txtmaxROW.value))
    {
          alert('终止行号错误，请重新输入！(1-99)');
           return false;
    }
 
    if(txtminColumn.value==""||txtminColumn.value==null)
    
    {
          alert('起始列号错误，请重新输入！(1-99)');
           return false;
    }
    if(txtminColumn.value.length>2)
    {
     alert('起始列号错误，请重新输入！(1-99)');
           return false;
    }
    if(isNaN(txtminColumn.value))
    {
        alert('起始列号错误，请重新输入！(1-99)');
           return false;
    }
    if(txtmaxColumn.value==""||txtmaxColumn.value==null)
    {
        alert('终止列号错误，请重新输入！(1-99)');
        return false;
    }
    if(txtmaxColumn.value.length>2)
    {
            alert('终止列号错误，请重新输入！(1-99)');
        return false;
    }
    
    if(isNaN(txtmaxColumn.value))
    {
            alert('终止列号错误，请重新输入！(1-99)');
        return false;
    
    }
if(txtmaxROW.value<txtminROW.value)
{
    alert('终止行号不能小于起始行号，请重新输入！(1-99)');
    return false;
}
if(txtmaxColumn.value<txtminColumn.value)
{
    alert('终止列号不能小于起始列号，请重新输入！(1-99)');
    return false;
}
    
     url = "../../PrintCode.aspx?STORE=" + chkPrintDrp.options.value + "&SROW=" + txtminROW.value+ "&TROW="+txtmaxROW.value+"&SCOL=" + txtminColumn.value + "&TCOL="+txtmaxColumn.value;
window.open(url);
  }

}