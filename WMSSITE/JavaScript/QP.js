function deleteRow(tbname,saverowno)  //删除表格行
{
   var obj=document.getElementById(tbname);
   var rowIndex=obj.childNodes[0].childNodes.length;
   if(rowIndex>saverowno)
   {  
      var delnum = rowIndex-parseInt(saverowno);
      for (i=rowIndex;i>saverowno;i--)
      {
        obj.deleteRow(i-1);
      }
   }
}
function getQPInfo(wlhper) {
    if (wlhper=="") {
       return;
    }
    var grvstand = document.getElementById("grvstand");
    if (grvstand!=null)
    {
       //清空数据
       deleteRow("grvstand",1);
       
       var request = getXmlHttpRequest();
       var url = "../CheckQu/LogincAjax.aspx?TYPE=30&wlhper="+wlhper;
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
          window.alert("数据访问失败，请重试！");
          return false;
       }
       else
       {
          var hwlh=document.getElementById("hwlh");
          var hrownum=document.getElementById("hrownum");
          hwlh.value="";
          hrownum.value="";
          var oDoc = getXmlDocument();
          oDoc.loadXML(result); 
          var items1 = oDoc.selectNodes("//NewDataSet/Table/wlh");  
          var items2 = oDoc.selectNodes("//NewDataSet/Table/isqp");  
          var items3 = oDoc.selectNodes("//NewDataSet/Table/bzbzstr");    
          var itemsLength = items1.length;
          selectrow=null;
          for (i=0;i<itemsLength;i++)
          {
              var txt = items1[i].text;
              var txt1 = items3[i].text;
              insertRowzxbz(txt,txt1,i);
          }
       }
    }
}
function insertRowzxbz(txt,txt1,rowno)
{


  var x=document.getElementById('grvstand').insertRow(rowno+1);
  var y=x.insertCell(0);
  var z=x.insertCell(1);
  y.innerHTML=txt
  z.innerHTML=txt1;

//  tableobj=document.getElementById("grvstand"); 
//  trobj=document.createElement("tr"); 
//  
//  tdobj=document.createElement("td");
//  tdobj.height = "15";
//  tdobj1 = document.createElement("td"); 
//  trobj.id="tr"+rowno;
//  tdtextobj=document.createTextNode(txt); 
//  tdtextbzbzstrobj=document.createTextNode(txt1); 

//  
//  tdobj.appendChild(tdtextobj);
//  tdobj1.appendChild(tdtextbzbzstrobj);
//  trobj.appendChild(tdobj); 
//  trobj.appendChild(tdobj1);

  
  x.onclick=function()
  {
     selecttbrowzxbz(this,txt);
  } 
  //tableobj.appendChild(trobj); 

}
function setwlbzbz(obj,bzbz) {
   var hwlh=document.getElementById("hwlh");
   var hrownum=document.getElementById("hrownum");
   var mytable=document.getElementById("grvstand");
   if (hwlh.value=="") { 
   alert("请选择");
   return;
   }
   if (!confirm("是否进行设置？")) { return;
   }
   var ope="0";
   var e = event.srcElement;
   var cheStatus=e.checked;
   if (cheStatus) {ope="1";
   }
   var bzbz=e.parentNode.parentNode.cells(0).innerText;
   var request = getXmlHttpRequest();
   var url = "../CheckQu/LogincAjax.aspx?TYPE=303&wlh="+hwlh.value+"&bzbz="+bzbz+"&ope="+ope;
   sendRequest(url,"","POST",request);
   var result = request.responseText;
   if(result.indexOf("ERROR")!=-1)
   {
          window.alert("设置错误："+result);
          return false;
   }
   else
   {
        alert("设置成功！");
        //var grvstand=document.getElementById("grvstand");
     
        mytable.rows(parseInt(hrownum.value)).cells(1).innerText=result; 
   }
}
function insertRowzxbzbz(txt,txt1,rowno) {


    var x=document.getElementById('grvbzbz').insertRow(rowno+1);
  var y=x.insertCell(0);
  var z=x.insertCell(1);
  var hwlh=document.getElementById("hwlh");
  y.innerHTML=txt
  var inputstr="<input type='checkbox' onclick='javascript:setwlbzbz();'/>";
  if (txt1=="1") {
     inputstr="<input type='checkbox' checked=checked onclick='javascript:setwlbzbz();'/>";
  }
  
  z.innerHTML=inputstr;
  
//   tableobj=document.getElementById("grvbzbzTbody"); 
//  trobj=document.createElement("tr"); 
//  
//  tdobj=document.createElement("td");
//  tdobj.height = "15";
//  tdobj1 = document.createElement("td"); 
//  trobj.id="trb"+rowno;
//  tdtextobj=document.createTextNode(txt); 
//  var ckobj=document.createElement("input");
//  ckobj.type="checkbox";
//  tdobj1.appendChild(ckobj);
//  
//  tdobj.appendChild(tdtextobj);
//  trobj.appendChild(tdobj); 
//  trobj.appendChild(tdobj1);
//  if(txt1=="1") 
//  ckobj.setAttribute("checked","checked");
//  ckobj.setAttribute("value",txt);
//  ckobj.onclick=function()
//  {
//      setqp(this);
//  }
//  
//  tableobj.appendChild(trobj); 
}
var selectrow=null;
function selecttbrowzxbz(obj,wlhstr) 
{ 
     var mytable=document.getElementById("grvstand");
     //alert(mytable.rows.length);
     for(var i=0;i<mytable.rows.length;i++)
     {
         
            mytable.rows[i].style.background="#FFFFFF";
        
     }
     obj.style.background='#191970';
     var hwlh=document.getElementById("hwlh");
     hwlh.value=wlhstr;
     var hrownum=document.getElementById("hrownum");
     hrownum.value=obj.rowIndex;
     deleteRow("grvbzbz",1);
     var ckall=document.getElementById("ckall");
     ckall.checked=false;
       var request = getXmlHttpRequest();
       var url = "../CheckQu/LogincAjax.aspx?TYPE=301&wlhstr="+wlhstr;
       sendRequest(url,"","POST",request);
       var result = request.responseText;
       if(result.indexOf("ERROR")!=-1)
       {
          window.alert("数据访问失败，请重试！");
          return false;
       }
       else
       {
          var oDoc = getXmlDocument();
          oDoc.loadXML(result); 
          var items1 = oDoc.selectNodes("//NewDataSet/Table/bzbz");  
          var items2 = oDoc.selectNodes("//NewDataSet/Table/ischeck");     
          var itemsLength = items1.length;
          selectrow=null;
          for (i=0;i<itemsLength;i++)
          {
              var txt = items1[i].text;
              var txt1 = items2[i].text;
              insertRowzxbzbz(txt,txt1,i);
          }
       }
}
function searchqpinfo() {
    var value= event.keyCode 
    var key = String.fromCharCode(event.keyCode);
    var selectwlh=document.getElementById("selectwlh");
    
    if (value=="13") {
        getQPInfo(selectwlh.value);
    }
}
function setqp(obj) {
   var tr=obj.parentNode.parentNode;
   var wlh=obj.value;
   if (obj.checked) {
      if(!confirm("是否进行去皮设置？"))
      {
         obj.checked=false;
         return;
      }
   }
   if (!obj.checked) {
      if(!confirm("是否取消去皮设置？"))
      {
         obj.checked=true;
         return;
      }
   }
   var request = getXmlHttpRequest();
   var url = "../CheckQu/LogincAjax.aspx?TYPE=37&wlh="+wlh;
   sendRequest(url,"","POST",request);
   var result = request.responseText;
   if(result.indexOf("ERROR")!=-1)
   {
          window.alert("设置错误："+result);
          return false;
   }
   else
   {
        alert("设置成功！");
        //var grvstand=document.getElementById("grvstand");
        getQPInfo(document.getElementById("selectwlh").value);
   }
}

function setall() {
   var hwlh=document.getElementById("hwlh");
   var hrownum=document.getElementById("hrownum");
  
   var ckall=document.getElementById("ckall");
   var mytable=document.getElementById("grvstand");
   if(ckall.checked)
   {
       if (hwlh.value=="") {
      alert("请选择物料！");
      ckall.checked=false;
      return;
   }
       if (!confirm("是否全置包装标准？"))
       { 
       ckall.checked=false;
       return;
       }
   var request = getXmlHttpRequest();
   var url = "../CheckQu/LogincAjax.aspx?TYPE=302&wlh="+hwlh.value;
   sendRequest(url,"","POST",request);
   var result = request.responseText;
   if(result.indexOf("ERROR")!=-1)
   {
          window.alert("设置错误："+result);
          return false;
   }
   else
   {
        alert("设置成功！");
        //var grvstand=document.getElementById("grvstand");
     
        mytable.rows(parseInt(hrownum.value)).cells(1).innerText=result; 
   }
   }
}