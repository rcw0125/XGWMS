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

//选中改变颜色
function SelectDataGridRow(DataGridName,rowIndex) 
{ 
     var mytable=document.getElementById(DataGridName);
     mytable.rows[rowIndex+1].oldcolor=mytable.rows[rowIndex+1].style.backgroundColor;
     mytable.rows[rowIndex+1].style.backgroundColor='#C8F7FF';
     for(var i=0;i<mytable.rows.length;i++)
     {
         if(i!=rowIndex+1)
         {
            mytable.rows[i].style.backgroundColor=mytable.rows[i].oldcolor;
         }
     }
     var iframe=document.getElementById("ifPCHDetail");
     iframe.src="PCHDetail.aspx?PCH="+mytable.rows[rowIndex+1].cells[1].innerText;
}

//选中改变颜色
function SelectLogRow(tableName,rowIndex)
{
     //服务器端不包括表头，而客户端包括了表头
     rowIndex=rowIndex+1;
     var mytable=document.getElementById(tableName);
     mytable.rows[rowIndex].oldcolor=mytable.rows[rowIndex].style.backgroundColor;
     mytable.rows[rowIndex].style.backgroundColor='#C8F7FF';
     for(var i=0;i<mytable.rows.length;i++)
     {
         if(i!=rowIndex)
         {
            mytable.rows[i].style.backgroundColor=mytable.rows[i].oldcolor;
         }
     }
     var hidIndex=document.getElementById("hidRowIndex");
     hidIndex.value=rowIndex-1;
     var txtResult=document.getElementById("txtResult");
     txtResult.value=mytable.rows[rowIndex].cells[4].innerText;
}

//全选
function checkAllInput()
{
    var table=document.getElementById("grdLog");
    var checkall=document.getElementById("checkAll");
    var inputs=table.all.tags("INPUT");
    for(var i=0;i<inputs.length;i++)
    {
        if(inputs[i].type=="checkbox")
        {
            inputs[i].checked=checkall.checked;
        }
    }
}

function SelectSinger()
{
    var e = event.srcElement;
    var checkall=document.getElementById("checkAll");
    if(e.checked==false)
    {
        checkall.checked=false;
        return;
    }
    
	var table = document.getElementById("grdLog");
    
    checkall.checked=true;
    var inputs=table.all.tags("INPUT");
    for(var i=0;i<inputs.length;i++)
    {
        if(inputs[i].type=="checkbox")
        {
            if(inputs[i].checked==false)
            {
                checkall.checked=false;
                break;
            }
        }
    }
}
