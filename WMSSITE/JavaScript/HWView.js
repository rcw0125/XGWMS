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
//增加最小行
function AddMinRow()
{
    var txtMinRow=document.getElementById("txtMinRow");
    var regInt=/^[0-9]*[1-9][0-9]*$/;//匹配正整数
    if(!regInt.test(txtMinRow.value))
    {
        txtMinRow.value="1";
    }
    var result=Number(txtMinRow.value)+1;
    if(result>99)
    {
        txtMinRow.value="99";
        return;
    }
    txtMinRow.value=result;
}

//增加最大行
function AddMaxRow()
{
    var txtMaxRow=document.getElementById("txtMaxRow");
    var regInt=/^[0-9]*[1-9][0-9]*$/;//匹配正整数
    if(!regInt.test(txtMaxRow.value))
    {
        txtMaxRow.value="1";
    }
    var result=Number(txtMaxRow.value)+1;
    if(result>99)
    {
        txtMaxRow.value="99";
        return;
    }
    txtMaxRow.value=result;
}
//增加最小列
function AddMinCol()
{
    var txtMinCol=document.getElementById("txtMinCol");
    var regInt=/^[0-9]*[1-9][0-9]*$/;//匹配正整数
    if(!regInt.test(txtMinCol.value))
    {
        txtMinCol.value="1";
    }
    var result=Number(txtMinCol.value)+1;
    if(result>99)
    {
        txtMinCol.value="99";
        return;
    }
    txtMinCol.value=result;
}
//增加最大列
function AddMaxCol()
{
    var txtMaxCol=document.getElementById("txtMaxCol");
    var regInt=/^[0-9]*[1-9][0-9]*$/;//匹配正整数
    if(!regInt.test(txtMaxCol.value))
    {
        txtMaxCol.value="1";
    }
    var result=Number(txtMaxCol.value)+1;
    if(result>99)
    {
        txtMaxCol.value="99";
        return;
    }
    txtMaxCol.value=result;
}

//减少最小行
function SubtractMinRow()
{
    var txtMinRow=document.getElementById("txtMinRow");
    var regInt=/^[0-9]*[1-9][0-9]*$/;//匹配正整数
    if(!regInt.test(txtMinRow.value))
    {
        txtMinRow.value="99";
    }
    var result=Number(txtMinRow.value)-1;
    if(result<1)
    {
        txtMinRow.value="1";
        return;
    }
    txtMinRow.value=result;
}

//减少最大行
function SubtractMaxRow()
{
    var txtMaxRow=document.getElementById("txtMaxRow");
    var regInt=/^[0-9]*[1-9][0-9]*$/;//匹配正整数
    if(!regInt.test(txtMaxRow.value))
    {
        txtMaxRow.value="99";
    }
    var result=Number(txtMaxRow.value)-1;
    if(result<1)
    {
        txtMaxRow.value="1";
        return;
    }
    txtMaxRow.value=result;
}
//减少最小列
function SubtractMinCol()
{
    var txtMinCol=document.getElementById("txtMinCol");
    var regInt=/^[0-9]*[1-9][0-9]*$/;//匹配正整数
    if(!regInt.test(txtMinCol.value))
    {
        txtMinCol.value="99";
    }
    var result=Number(txtMinCol.value)-1;
    if(result<1)
    {
        txtMinCol.value="1";
    }
    txtMinCol.value=result;
}
//减少最大列
function SubtractMaxCol()
{
    var txtMaxCol=document.getElementById("txtMaxCol");
    var regInt=/^[0-9]*[1-9][0-9]*$/;//匹配正整数
    if(!regInt.test(txtMaxCol.value))
    {
        txtMaxCol.value="99";
    }
    var result=Number(txtMaxCol.value)-1;
    if(result<1)
    {
        txtMaxCol.value="1";
    }
    txtMaxCol.value=result;
}

//设置显示货位
function GetHWView()
{
    var drpStore=document.getElementById("drpStore");
    var txtMinRow=document.getElementById("txtMinRow");
    var txtMaxRow=document.getElementById("txtMaxRow");
    var txtMinCol=document.getElementById("txtMinCol");
    var txtMaxCol=document.getElementById("txtMaxCol");
    var txtHeigth=document.getElementById("txtHeight");
    var txtWidth=document.getElementById("txtWidth");
    if(drpStore.value=="0")
    {
        alert("请选择仓库！");
        drpStore.focus();
        return;
    }
    var regInt=/^[0-9]*[1-9][0-9]*$/;
    if(!regInt.test(txtMinRow.value))
    {
        alert("最小行格式错误！");
        txtMinRow.focus();
        return;
    }
    if(!regInt.test(txtMaxRow.value))
    {
        alert("最大行格式错误！");
        txtMaxRow.focus();
        return;
    }
    if(!regInt.test(txtMinCol.value))
    {
        alert("最小列格式错误！");
        txtMinCol.focus();
        return;
    }
    if(!regInt.test(txtMaxCol.value))
    {
        alert("最大列格式错误！");
        txtMaxCol.focus();
        return;
    }
    if(!regInt.test(txtHeigth.value))
    {
        alert("货位区域高设置格式错误！");
        txtHeigth.focus();
        return;
    }
    if(!regInt.test(txtWidth.value))
    {
        alert("货位区域宽设置格式错误！");
        txtWidth.focus();
        return;
    }
    //不能超过范围
    if(Number(txtMinRow.value)>99)
    {
        txtMinRow.value=99;
    }
    if(Number(txtMinRow.value)<1)
    {
        txtMinRow.value=1;
    }
    if(Number(txtMaxRow.value)>99)
        txtMaxRow.value=99;
    if(Number(txtMaxRow.value)<1)
        txtMaxRow.value=1;
    if(Number(txtMinCol.value)>99)
        txtMinCol.value=99;
    if(Number(txtMaxCol.value)<1)
        txtMaxCol.value=1;
    if(Number(txtWidth.value)>600)
        txtWidth.value=600;
    if(Number(txtWidth.value)<100)
        txtWidth.value=100;
    if(Number(txtHeigth.value)>600)
        txtHeigth.value=600;
    if(Number(txtHeigth.value)<100)
        txtHeigth.value=100;
    if(Number(txtMinRow.value)>Number(txtMaxRow.value))
    {
        alert("最小行必须小于等于最大行！");
        return;
    }
    if(Number(txtMinCol.value)>Number(txtMaxCol.value))
    {
        alert("最小列必须小于等于最大列！");
        return;
    }
    var iFram=document.getElementById("iframeHW");
    var url="HWDetail.aspx?STORE="+drpStore.value+"&MINROW="+txtMinRow.value+"&MAXROW="+txtMaxRow.value+"&MINCOL="+txtMinCol.value+"&MAXCOL="+txtMaxCol.value+"&HEIGTH="+txtHeigth.value+"&WEIGHT="+txtWidth.value;
    iFram.src=url;
}

/*显示或者隐藏查询条件*/
function AddQuery()
{
    var btnQuery = document.getElementById("btnQuery");
	var tblQuery= document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
	var iframeHW=document.getElementById("iframeHW");
	if(tblQuery.style.display == "block")
	{
		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		tblQuery.style.display = "none";
		hidQuery.value= "none";
		iframeHW.style.height="500px";
	}
	else
	{
		btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
		tblQuery.style.display = "block";
		hidQuery.value = "block";
		iframeHW.style.height="400px";
	}	
}

/*页面初始化，完工单查询*/
function Init()
{
	var tblQuery = document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
	
	if(hidQuery.value!="")
	{
		tblQuery.style.display = "none";
		if( hidQuery.value== "none")
			tblQuery.style.display = "block";
		AddQuery();
	}
}