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
function OpenDJ()
{
    window.open('DanJuSearch.aspx', 'KHSC', 'height=500, width=500, top=200, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');
}
function GetDanju()
{
    var e = event.srcElement;
    var tr = e.parentNode.parentNode;
    var tds=tr.all.tags("td");
    var txtDanJu=window.opener.document.getElementById("txtDanJu");
    var txtPiCiHao=window.opener.document.getElementById("txtPiCiHao");
    txtDanJu.value=tds[1].innerText;
    txtPiCiHao.value=tds[2].innerText;
    
    var td=e.parentNode;
    var inputs=td.all.tags("INPUT");
    txtDanJu.value=inputs[0].value;
    txtPiCiHao.value=inputs[1].value; 
    window.close();
}

function IMG1_onclick()
 {
    var txtDJH=document.getElementById("txtDJH");
    var txtPCH=document.getElementById("txtPCH");
    var drpCK=document.getElementById("drpCK");
    txtDJH.value="";
    txtPCH.value="";
    drpCK.options.value = "--全部仓库--";
}
function close_win()
{
    window.close();
}


//察看转库单明细
function GetXTZHItem()
{
    var iFrame=document.getElementById("frmList");
    var e = event.srcElement;
    var cheStatus=e.checked;
    var hidURL=document.getElementById("hidURL"); 
    
    var table=e.parentNode.parentNode.parentNode;
    var inputs=table.all.tags("INPUT");
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
        var td=e.parentNode;
        var inputs2=td.all.tags("INPUT"); 
        var strzhdh=inputs2[1].value; 
        iFrame.src="XTZHItem.aspx?action=item&zhdh="+strzhdh;
        hidURL.value="XTZHItem.aspx?action=item&zhdh="+strzhdh;
    }
    else
    {
        iFrame.src="";
        hidURL.value="";
    }
}

function Init()
{
    var hidURL=document.getElementById("hidURL"); 
    var iFrame=document.getElementById("frmList");
    if(hidURL.value!="" && hidURL.value.length>0)
        iFrame.src=hidURL.value;
}