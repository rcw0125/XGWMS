// JScript 文件
//获取XMLHttp对象
function getXmlHttpRequest()
{
    var xRequest=null;
    if(window.XMLHttpRequest)
    {
        xRequest=new XMLHttpRequest();
    }
    else if(typeof ActiveXObject!="undefined")
    {
        xRequest=new ActiveXObject("Microsoft.XMLHTTP");
    }
    return xRequest;
}
//发送异步请求
function sendRequest(url,params,HttpMethod,req)
{
    if(!HttpMethod)
        HttpMethod="POST";
    //req.onreadystatechange=onReadyStateChange;//回调函数
    if(req)
    {
        req.open(HttpMethod,url,true);//是否异步
        req.setRequestHeader("Content-type","application/x-www-form-urlencoded");
        req.send(params);
    }
}
//退出系统
function LoginOut()
{
    if(event!=null)
    {
        if(event.clientX>document.body.clientWidth&&event.clientY<0||event.altKey)   
        {  
            var req=getXmlHttpRequest();
            var url="LoginLogicDeal.aspx?TYPE=LOGINOUT";
            sendRequest(url,"",null,req); 
        } 
    }
}
function fun(x,name)
	{
	 var e = eval("document.all.Header_"+ x);
	 e.src="image/header/"+name+".gif";
	}
	
	function out(x,name)
	{
	 var e = eval("document.all.Header_"+ x);
	 e.src="image/header/"+name+".gif";
	}
	
function showdialog()
{
	var width=500;
	var height=300;
	var str = "height=" +300; 
	str += ",width=" + 420; 
	if (window.screen) { 
		var ah = screen.availHeight - 30; 
		var aw = screen.availWidth - 10; 
		var xc = (aw - width) / 2; 
		var yc = (ah - height) / 2; 
		str += ",left=" + xc + ",screenX=" + xc; 
		str += ",top=" + yc + ",screenY=" + yc;
		str+=",scrollbars=yes";
	} 
    window.open('changepasswd.aspx','修改密码',str)
}

function up()
	{
		var tablex = document.getElementById("tablex");
		tablex.style.display = "none";
	}
	
function down()
	{
		var tablex = document.getElementById("tablex");
		tablex.style.display = "block";
	}
//登录历史库
function OpenHistory()
		{
		    window.open('http://192.168.2.10/wmssitehistory');
		}
