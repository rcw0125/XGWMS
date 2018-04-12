function AddFull(flag) {
    if (flag == 1) {
        parent.document.body.cols = "*,100%";
    }
    if (flag == 0) {
        parent.document.body.cols = "120,*";
    }
}

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
function getBZBZInfo() {
    var grvstand = document.getElementById("grvstand");
    if (grvstand!=null)
    {
       //清空数据
       deleteRow("grvstand",0);
       var request = getXmlHttpRequest();
       var url = "../CheckQu/LogincAjax.aspx?TYPE=33";
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
          var items0 = oDoc.selectNodes("//NewDataSet/Table/fid"); 
          var items1 = oDoc.selectNodes("//NewDataSet/Table/BZBZ");  
          var items2 = oDoc.selectNodes("//NewDataSet/Table/ZLMIN");     
          var items3 = oDoc.selectNodes("//NewDataSet/Table/ZLMAX"); 
          var items4 = oDoc.selectNodes("//NewDataSet/Table/ZL");
          var items5 = oDoc.selectNodes("//NewDataSet/Table/BZ");
          var items6 = oDoc.selectNodes("//NewDataSet/Table/SCXName");
          var items7 = oDoc.selectNodes("//NewDataSet/Table/SCXBM");
          
          var itemsLength = items1.length;
          var oldbzbz="";
          var newbzbz = "";
          var oldscx = "";
          var newscx = "";
          var displaystyle1 = "none";
          var displaystyle="none";
          for (i=0;i<itemsLength;i++) {
              if(items6[i]!=null)
                newscx = items6[i].text;
              newbzbz = items1[i].text;
              if (newscx != oldscx) {
                  displaystyle1 = "block";
              } else displaystyle1 = "none";
              if (newbzbz != oldbzbz) {
                  displaystyle = "block";
              } else displaystyle = "none";
              
              var txt0 = items0[i].text;
              var txt1 = items1[i].text;
              var txt2 = items2[i].text;
              var txt3 = items3[i].text;
              var txt4 = items4[i].text;
              var txt5 = "";
              if (items5[i] != null)
                  txt5 = items5[i].text;
              var txt6 = items6[i].text;
              var txt7 = items7[i].text;
              insertRowzxbz(displaystyle1, displaystyle, txt0, txt1, txt2, txt3, txt4, txt5, i, txt6,txt7);
              oldscx = newscx;
              oldbzbz=newbzbz;
          }
       }
    }
    setbtnstatuszxbz("query");
}
function insertRowzxbz(displaystyle1,displaystyle,txt0,txt1,txt2,txt3,txt4,txt5,rowno,txt6,txt7)
{
  tableobj=document.getElementById("grvstandTbody"); 
  trobj=document.createElement("tr"); 
  
  td0obj=document.createElement("td");
  td0textobj=document.createTextNode(txt0);
  td0obj.style.display = "none";

  tdbm = document.createElement("td");
  bmobj = document.createElement("input");
  bmobj.type = "Text";
  bmobj.style.cssText = "width:100%;border:Solid 0px #CCCCCC;display:" + displaystyle1;
  bmobj.value = txt7;
  bmobj.disabled = true;
  tdbm.appendChild(bmobj);

  tdscObj = document.createElement("td");
  scxobj = document.createElement("input");
  scxobj.type = "Text";
  scxobj.style.cssText = "width:14%;border:Solid 0px #CCCCCC;display:" + displaystyle1;
  scxobj.value = txt6;
  scxobj.disabled = true;
  tdscObj.appendChild(scxobj);
  
  td1obj=document.createElement("td");
  //td1textobj=document.createTextNode(txt1);
  //td1obj.innerHtml="<input type=text  style=\"display:"+displaystyle+";border:border:Solid 0px #CCCCCC;width:70px\">"+txt1+"</span>";
  slhobj = document.createElement("input");
  slhobj.type="Text";
  slhobj.style.cssText="width:100%;border:Solid 0px #CCCCCC;display:"+displaystyle;
  slhobj.value=txt1;
  slhobj.disabled = true;
  td1obj.appendChild(slhobj);
  
  
  td2obj=document.createElement("td");
  td2textobj = document.createTextNode(txt2);
  
  
  
  td3obj=document.createElement("td");
  td3textobj=document.createTextNode(txt3);
  
  td4obj=document.createElement("td");
  td4textobj=document.createTextNode(txt4);
  
  td5obj=document.createElement("td");
  td5textobj=document.createTextNode(txt5);
  
  trobj.id="tr"+rowno;

  tdscObj.style.cssText = "width:14%"; //增加生产线显示
  tdbm.style.cssTest = "width:14%";
  td1obj.style.cssText = "width:14%";
  td2obj.style.cssText = "width:14%";
  td3obj.style.cssText = "width:14%";
  td4obj.style.cssText = "width:14%";
  td5obj.style.cssText = "width:16%;word-WRAP: break-word";

  td0obj.appendChild(td0textobj);
  td2obj.appendChild(td2textobj);
  td3obj.appendChild(td3textobj);
  td4obj.appendChild(td4textobj);
  td5obj.appendChild(td5textobj);

  trobj.appendChild(td0obj);
  trobj.appendChild(tdbm);
  trobj.appendChild(tdscObj);
  trobj.appendChild(td1obj); 
  trobj.appendChild(td2obj);
  trobj.appendChild(td3obj);
  trobj.appendChild(td4obj);
  trobj.appendChild(td5obj);
  trobj.onclick=function()
  {
     selecttbrowzxbz(rowno);
  } 
  tableobj.appendChild(trobj);
}

function selecttbrowzxbz(rowIndex) 
{ 
     var mytable=document.getElementById("grvstand");
     var txtbzbz = document.getElementById("txtbzbz");
     var bzxx=document.getElementById("bzxx"); 
     var bzsx=document.getElementById("bzsx");
     var clkz=document.getElementById("clkz");
     var bz = document.getElementById("bz");
     var drpSCX = document.getElementById("drpProductLine");
         
     var tds = null;    
     if (txtbzbz!=null) {

         var strSCX = mytable.rows[rowIndex].cells[1].childNodes[0].value;
         for (var i = 0; i < drpSCX.options.length; i++) {
             if (drpSCX.options[i].value == strSCX) {
                 drpSCX.options[i].selected = true;
             }
         }                                      
        txtbzbz.value=mytable.rows[rowIndex].cells[3].childNodes[0].value;  
        bzxx.value=mytable.rows[rowIndex].cells[4].innerText;  
        bzsx.value=mytable.rows[rowIndex].cells[5].innerText;  
        clkz.value=mytable.rows[rowIndex].cells[6].innerText; 
        bz.value=mytable.rows[rowIndex].cells[7].innerText;   
     }
     mytable.rows[rowIndex].style.backgroundColor='#C8F7FF';
     for(var i=0;i<mytable.rows.length;i++)
     {
         if(i!=rowIndex)
         {
            mytable.rows[i].style.backgroundColor="#FFFFFF";
         }
     }
     document.getElementById("hfid").value = mytable.rows[rowIndex].cells[0].innerText;
     document.getElementById("htxtbzbz").value = mytable.rows[rowIndex].cells[3].childNodes[0].value;
     document.getElementById("hbzxx").value = mytable.rows[rowIndex].cells[4].innerText;
     document.getElementById("hbzsx").value = mytable.rows[rowIndex].cells[5].innerText;
     document.getElementById("hclkz").value = mytable.rows[rowIndex].cells[6].innerText;
     document.getElementById("hbz").value = mytable.rows[rowIndex].cells[7].innerText;
     document.getElementById("hscx").value = mytable.rows[rowIndex].cells[1].childNodes[0].value;
     
} 
function f_check_number(obj)
{
    return !isNaN(obj)
}
function isfloat(str)
{
   return f_check_number(str);
}
function setbtnstatuszxbz(opetype)
{
   var tb = document.getElementById("grvstand");
   var btnnew = document.getElementById("btnnew");
   var btnedit = document.getElementById("btnedit");
   var btncancel = document.getElementById("btncancel");
   var btnsave = document.getElementById("btnsave");
   var btndel = document.getElementById("btndel");
   
   var txtbzbz = document.getElementById("txtbzbz");
   var bzxx=document.getElementById("bzxx"); 
   var bzsx=document.getElementById("bzsx");
   var clkz=document.getElementById("clkz");
   var bz = document.getElementById("bz");
   var drpSCX = document.getElementById("drpProductLine");//获取生产线信息
   var hopetype = document.getElementById("hopetype");
   
   var hfid=document.getElementById("hfid");
   var htxtbzbz = document.getElementById("htxtbzbz");
   var hbzxx=document.getElementById("hbzxx"); 
   var hbzsx=document.getElementById("hbzsx");
   var hclkz=document.getElementById("hclkz");
   var hbz = document.getElementById("hbz");
   var hscx = document.getElementById("hscx");
   
   
   
   var rowscount = 0;
   var reasontype = "0";

   if (opetype=="query")
   {
      settbedablezxbz(true);//设置是否可选择
      rowscount = tb.childNodes[0].childNodes.length;
      hopetype.value = "query";
      txtbzbz.disabled = true;
      bzxx.disabled = true;
      bzsx.disabled= true;
      clkz.disabled= true;
      bz.disabled = true;
      drpSCX.disabled = true;
      
      btnnew.disabled = false;
      if (rowscount>=1)
        btnedit.disabled = false;
      else
        btnedit.disabled = true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>=1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      
      return false;
   }
   if (opetype=="new")
   {
      settbedablezxbz(false);
      hopetype.value = "new";
      
      txtbzbz.disabled = false;
      bzxx.disabled = false;
      bzsx.disabled= false;
      clkz.disabled= false;
      bz.disabled = false;
      drpSCX.disabled = false;
      
      txtbzbz.value = "";
      bzxx.value = "";
      bzsx.value = "";
      clkz.value = "";
      bz.value = "";
      drpSCX.options[0].selected = true;
      
      
      btnnew.disabled = true;
      btnedit.disabled = true;
      btncancel.disabled = false;
      btnsave.disabled = false;
      btndel.disabled = true;
      return false;
   }
   if(opetype=="edit")
   {
      if(document.getElementById("hfid").value=="")
      {
         alert("请选择需要修改的包装！");
         return false;
      }
      settbedablezxbz(false);
      hopetype.value = "edit";
      
      txtbzbz.disabled = false;
      bzxx.disabled = false;
      bzsx.disabled= false;
      clkz.disabled= false;
      bz.disabled= false;
      
      btnnew.disabled = true;
      btnedit.disabled = true;
      btncancel.disabled = false;
      btnsave.disabled = false;
      btndel.disabled = true;
      return false;
   }
   if(opetype=="cancel")
   {
      settbedablezxbz(true);
      hopetype.value = "cancel";
      rowscount = tb.childNodes[0].childNodes.length;
      
      txtbzbz.disabled = true;
      bzxx.disabled = true;
      bzsx.disabled= true;
      clkz.disabled= true;
      bz.disabled = true;
      drpSCX.disabled = true;
      
      txtbzbz.value = document.getElementById("htxtbzbz").value;
      bzxx.value = document.getElementById("hbzxx").value;
      bzsx.value = document.getElementById("hbzsx").value;
      clkz.value = document.getElementById("hclkz").value;
      bz.value = document.getElementById("hbz").value;
      var strScx = document.getElementById("hscx").value;
      if (strScx == "") {
          drpSCX.options[0].selected = true;
      } else {
      for (var i = 0; i < drpSCX.options.length; i++) {
          if (drpSCX.options[i].value == strScx) {
              drpSCX.options[i].selected = true;
          }
      }  
      }
      
      btnnew.disabled = false;
      if (rowscount>=1)
        btnedit.disabled = false;
      else
        btnedit.disabled = true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>=1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      return false;
   }
   if(opetype=="save")
   {  
      //检测
       if (drpSCX.value == "0") {
           alert("请选择生产线信息！");
           drpSCX.focus();
           return false;
       }
      if (txtbzbz.value=="")
      {
         alert("填写包装标准！");
         txtbzbz.focus();
         return false;
      }
      if (bzxx.value=="")
      {
         alert("填写包重下限！");
         bzxx.focus();
         return false;
      }
      if (bzsx.value=="")
      {
         alert("填写包重上限！");
         bzsx.focus();
         return false;
      }
      if (clkz.value=="")
      {
         alert("填写材料扣重！");
         clkz.focus();
         return false;
      }
      if(!isfloat(bzxx.value))
      {
         alert("数据格式错误！");
         bzxx.focus();
         return false;
      }
      if(!isfloat(bzsx.value))
      {
         alert("数据格式错误！");
         bzsx.focus();
         return false;
      }
      if(!isfloat(clkz.value))
      {
         alert("数据格式错误！");
         clkz.focus();
         return false;
      }
      //保存
      if(!confirm("是否保存？"))
         return false;
      
      if (hopetype.value == "new")
      {
          var request = getXmlHttpRequest();
          //Response["zxbz"],Response["ph"],Response["opetype"],Response["oldph"],Response["oldzxbz"]);
          var url = "../CheckQu/LogincAjax.aspx?TYPE=34&txtbzbz=" + encodeURI(txtbzbz.value) +
                 "&opetype=0&bzxx="+bzxx.value+"&bzsx="+bzsx.value+"&clkz="+clkz.value+"&bz="+bz.value+"&scx="+drpSCX.value+"&fid=''";
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="0")
             {
                 alert("保存成功！");
             }
             else
             {
                if(result=="1")
                  alert("数据重复！");
                else
                  alert("保存失败："+result);
                return false;
             }
          }
      }
      else
      {
        if(hopetype.value == "edit")
        {
          var request = getXmlHttpRequest();
          var url = "../CheckQu/LogincAjax.aspx?TYPE=34&txtbzbz=" + encodeURI(txtbzbz.value) +
                 "&opetype=1&bzxx="+bzxx.value+"&bzsx="+bzsx.value+"&clkz="+clkz.value+"&bz="+encodeURI(bz.value)+"&scx="+drpSCX.value+"&fid="+hfid.value;
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="0")
             {
                 alert("保存成功！");
             }
             else
             {
                if(result=="1")
                  alert("数据重复！");
                else
                  alert("保存失败："+result);
                return false;
             }
          }
        }
        else
        {
           alert("不在编辑状态！");
           return false;
        }
      }
      settbedablezxbz(true);
      txtbzbz.disabled = true;
      bzxx.disabled = true;
      bzsx.disabled= true;
      clkz.disabled= true;
      bz.disabled= true;
      btnnew.disabled = false;
      btnedit.disabled = false;
      btncancel.disabled = true;
      btnsave.disabled = true;
      btndel.disabled = false;
      txtbzbz.value = "";
      bzxx.value = "";
      bzsx.value = "";
      clkz.value = "";
      bz.value = "";
      getBZBZInfo();
      hopetype.value = "query";
      document.getElementById("htxtbzbz").value="";
      document.getElementById("hbzxx").value="";
      document.getElementById("hbzsx").value="";
      document.getElementById("hclkz").value="";
      document.getElementById("hbz").value="";
      document.getElementById("hfid").value="";
      return false;
   }
   if(opetype=="del")
   {
           
      if(document.getElementById("hfid").value=="")
      {
         alert("请选择需要删除的包装标准！");
         return false;
      }
      //操作
      if(!confirm("是否删除？"))
        return false;
      var request = getXmlHttpRequest();
    
          var url = "../CheckQu/LogincAjax.aspx?TYPE=35&fid="+document.getElementById("hfid").value;
                         
          sendRequest(url,"","POST",request);
          var result = request.responseText;
          if (result.indexOf("ERROR")!=-1)
          {
              window.alert("数据访问失败，请重试！");
              return false;
           }
          else
          {
             if (result=="")
             {
                 alert("删除成功！");
             }
             else
             {
                
                  alert("删除失败："+result);
                return false;
             }
          }
          
      document.getElementById("htxtbzbz").value="";
      document.getElementById("hbzxx").value="";
      document.getElementById("hbzsx").value="";
      document.getElementById("hclkz").value="";
      document.getElementById("hbz").value="";
      document.getElementById("hfid").value="";
      txtbzbz.value = "";
      bzxx.value = "";
      bzsx.value = "";
      clkz.value = "";
      bz.value = "";
      getBZBZInfo();
      rowscount = tb.childNodes[0].childNodes.length;
      settbedablezxbz(true);
      txtbzbz.disabled = true;
      bzxx.disabled = true;
      bzsx.disabled= true;
      clkz.disabled= true;
      bz.disabled= true;
      btnnew.disabled = false;
      if(rowscount>1)
        btnedit.disabled = false;
      else
        btnedit.disabled=true;
      btncancel.disabled = true;
      btnsave.disabled = true;
      if (rowscount>1)
        btndel.disabled = false;
      else
        btndel.disabled = true;
      hopetype.value = "query";
      return false;
   }
   
   return false;
}
function settbedablezxbz(boo)
{
   var tb = document.getElementById("grvstand");
   var trr = null;
   var rowscount = 0;
   rowscount = tb.childNodes[0].childNodes.length;
   if(boo)
   {
      for (i=0;i<rowscount;i++)
      {
         trr=document.getElementById("tr"+i);
         trr.disabled = false;
      }
   }
   else
   {
      for (i=0;i<rowscount;i++)
      {
         trr=document.getElementById("tr"+i);
         trr.disabled = true;
      }
   }
   
}