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
/*显示或者隐藏查询条件*/
function AddQuery()
{
    var btnQuery = document.getElementById("btnQuery");
	var tblQuery= document.getElementById("tblQuery");
	var hidQuery = document.getElementById("hidQuery");
	if(tblQuery.style.display == "block")
	{
		btnQuery.src = "../../images/icon/expand.gif";
		btnQuery.alt = "展开";
		tblQuery.style.display = "none";
		hidQuery.value= "no";
	}
	else
	{
		btnQuery.src = "../../images/icon/collapse.gif";
		btnQuery.alt = "关闭";
		tblQuery.style.display = "block";
		hidQuery.value = "yes";
	}	
}