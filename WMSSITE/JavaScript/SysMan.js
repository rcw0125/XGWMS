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

//设置需要修改的项
function SetModifyItem()
{
    if(!window.confirm("确定要修改该记录？"))
			return;
    var hidName=document.getElementById("hidCValue");
    var csValue=document.getElementById("txtValue");
    var csExp=document.getElementById("txtExp");
    var e = event.srcElement;
    var td = e.parentNode;
    var texts =td.all.tags("INPUT");
    hidName.value=texts[0].value;
    var tr=td.parentNode;
    var tds=tr.all.tags("td");
    csValue.value=tds[1].innerText;
    csExp.value=tds[2].innerText;
}

//清空值
function ClearValue()
{
    var hidName=document.getElementById("hidCValue");
    var csValue=document.getElementById("txtValue");
    var csExp=document.getElementById("txtExp");
    hidName.value="";
    csValue.value="";
    csExp.value="";
}

/*显示或隐藏编辑信息*/
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

/*页面初始化，角色定义*/
function Init()
{
	var tblNewRole = document.getElementById("tblNewRole");
	var HidNewRole = document.getElementById("HidNewRole");
/*	window.alert(HidBase.value); 调试用的*/
	if(HidNewRole.value!="")
	{
		tblNewRole.style.display = "none";
		if( HidNewRole.value== "none")
			tblNewRole.style.display = "block";
		AddNewRole();
	}
}

