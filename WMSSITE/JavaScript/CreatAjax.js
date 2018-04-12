// JScript 文件
//获取XmlDocument对象
function getXmlDocument()
{
    var xDoc=null;
    if(document.implementation && document.implementation.createDocument)
    {
        xDoc=document.implementation.createDocument("","",null);
    }
    else if(typeof ActiveXObject!="undefined")
    {
        var msXmlAx=null;
        try
        {
            msXmlAx=new ActiveXObject("Msxml2.0DOMDocument");//较新版本IE浏览器
        }
        catch(e)
        {
            msXmlAx=new ActiveXObject("Msxml.DOMDocument");//较老版本IE浏览器
        }
        xDoc=msXmlAx;
    }
    if(xDoc==null ||typeof xDoc.load=="undefined")
        xDoc=null;
    return xDoc;
}
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
        req.open(HttpMethod,url,false);//是否异步
        //req.setRequestHeader("Content-type","application/x-www-form-urlencoded");
        req.send(params);
    }
}

//使用回调函数
var READY_STATE_UNNITIALIZED=0;
var READY_STATE_LOADING=1;
var READY_STATE_LOADED=2;
var READY_STATE_INTERRACTIVE=3;
var READY_STATE_COMPLETE=4;

function onReadyStateChange()
{
    var ready=req.readyState;
    var data=null;
    if(ready==READY_STATE_COMPLETE)
    {
        data=req.responseText;
    }
    else
    {
        data="loading...["+ready+"]";
    }
}