// JScript 文件
$(document).ready(function() {
    var timer;
    $("#txt_wlh").keypress(function() {
        if (timer != null) clearTimeout(timer);
        timer = setTimeout(function() {
            var txt_wlh = document.getElementById("txt_wlh");
            if (txt_wlh.value.length > 7) {
                var ajaxUrl = "../CheckQu/LogincAjax.aspx?TYPE=404&wlh=" + txt_wlh.value;
                $.get(ajaxUrl, function(msg) {
                    var txt_ph = document.getElementById("txt_ph");
                    var txt_gg = document.getElementById("txt_gg");
                    var msgs = msg.split(",");
                    if (msgs.length > 1) {
                        txt_ph.value = msgs[0];
                        txt_gg.value = msgs[1];
                    }
                    else {
                        txt_ph.value = "";
                        txt_gg.value = "";
                    }
                });
            }
        }, 1000);
    });

    $("#allcheck").click(function() {
    if (!confirm("是否全部启用？"))
        return false;
        
    $.get("../CheckQu/LogincAjax.aspx?TYPE=406&inuse=1", function() {
    getBZBZInfo();
        });
    });
    $("#alluncheck").click(function() {
    if (!confirm("是否全部禁用？"))
        return false;
        $.get("../CheckQu/LogincAjax.aspx?TYPE=406&inuse=0", function() {
            getBZBZInfo();
        });
    });
});

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
        deleteRow("grvstand", 0);

        var request = getXmlHttpRequest();
        
        var obj = document.getElementById("query_wlh");
        var wlhtxt = obj.value;
        if (wlhtxt == "") {
            wlhtxt = "A";
           
        }

      
       
       var url = "../CheckQu/LogincAjax.aspx?TYPE=401&wlh="+wlhtxt;
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
          var items0 = oDoc.selectNodes("//NewDataSet/Table/WLH"); 
          var items1 = oDoc.selectNodes("//NewDataSet/Table/PH");  
          var items2 = oDoc.selectNodes("//NewDataSet/Table/GG");     
          var items3 = oDoc.selectNodes("//NewDataSet/Table/PPRICE"); 
          var items4 = oDoc.selectNodes("//NewDataSet/Table/FPRICE");
          var items5 = oDoc.selectNodes("//NewDataSet/Table/TWZL");
          var items6 = oDoc.selectNodes("//NewDataSet/Table/KCZL");
          var items7 = oDoc.selectNodes("//NewDataSet/Table/INUSE");
          
          
          var itemsLength = items0.length;

          for (i=0;i<itemsLength;i++) {
              var txt0 = items0[i].text;
              var txt1 = items1[i].text;
              var txt2 = items2[i].text;
              var txt3 = items3[i].text;
              var txt4 = items4[i].text;
              var txt5 = items5[i].text;
              var txt6 = items6[i].text;
              var txt7 = items7[i].text;
              insertRowzxbz(i, txt0, txt1, txt2, txt3, txt4, txt5,txt6,txt7);
          }
       }
    }
    setbtnstatuszxbz("query");
}
function insertRowzxbz(rowno,txt0,txt1,txt2,txt3,txt4,txt5,txt6,txt7)
{
  tableobj=document.getElementById("grvstandTbody"); 
  trobj=document.createElement("tr");

  td0obj = document.createElement("td");
  td0textobj = document.createTextNode(txt0);
  td0obj.style.cssText = "width:16%";
  td0obj.appendChild(td0textobj);
  
  td1obj = document.createElement("td");
  td1textobj = document.createTextNode(txt1);
  td1obj.style.cssText = "width:12%";
  td1obj.appendChild(td1textobj);
    
  td2obj=document.createElement("td");
  td2textobj = document.createTextNode(txt2);
  td2obj.style.cssText = "width:12%";
  td2obj.appendChild(td2textobj);
  
  td3obj=document.createElement("td");
  td3textobj=document.createTextNode(txt3);
  td3obj.style.cssText = "width:12%";
  td3obj.appendChild(td3textobj);
  
  td4obj=document.createElement("td");
  td4textobj=document.createTextNode(txt4);
  td4obj.style.cssText = "width:12%";
  td4obj.appendChild(td4textobj);
  
  td5obj=document.createElement("td");
  td5textobj=document.createTextNode(txt5);
  td5obj.style.cssText = "width:12%";
  td5obj.appendChild(td5textobj);

  td6obj = document.createElement("td");
  td6textobj = document.createTextNode(txt6);
  td6obj.style.cssText = "width:12%";
  td6obj.appendChild(td6textobj);

  td7obj = document.createElement("td");
  //td7textobj = document.createTextNode(txt7);
  
  btnobj = document.createElement("input");
  btnobj.type = "Checkbox";
  //scxobj.style.cssText = "width:14%;border:Solid 0px #CCCCCC;display:" + displaystyle1;
  //scxobj.disabled = true;
  
  td7obj.style.cssText = "width:12%";
  td7obj.appendChild(btnobj);
 
  
  
  trobj.id="tr"+rowno;

  trobj.appendChild(td0obj); 
  trobj.appendChild(td1obj); 
  trobj.appendChild(td2obj);
  trobj.appendChild(td3obj);
  trobj.appendChild(td4obj);
  trobj.appendChild(td5obj);
  trobj.appendChild(td6obj);
  trobj.appendChild(td7obj);

  trobj.onclick=function() {
  
     selecttbrowzxbz(rowno);
  }
  tableobj.appendChild(trobj);

  if (txt7 == "1") {
      trobj.style.backgroundColor = "#FFFFFF";
      btnobj.checked = true;
  }
  else { 
      trobj.style.backgroundColor = "#F7F7F7";
      btnobj.checked = false;
  }
  btnobj.onclick = function() {
      var wlh = this.parentNode.parentNode.cells[0].innerText;
      var inuse = "1";
      var msg = "确定要启用(" + wlh + ")吗？";
      if (this.checked)
          inuse = "1";
      else {
          inuse = "0";
          msg = "确定要禁用(" + wlh + ")吗？";
      }

      if (!confirm(msg))
          return false;

      var result = "ok";
      $.ajax({
          type: "get",
          url: "../CheckQu/LogincAjax.aspx?TYPE=405&wlh=" + wlh + "&inuse=" + inuse,
          async: false,
          success: function(data) {
              if (data != "0") {
                  result = data;
              }
          },
          error: function() {
              result = "更新数据失败，无法访问服务器";
          }
      });
      if (result != "ok") {
          alert(result);
          return false;
      }

      //var ajaxUrl = "../CheckQu/LogincAjax.aspx?TYPE=405&wlh=" + wlh + "&inuse=" + inuse;
     // $.get(ajaxUrl);
  }
}

function selecttbrowzxbz(rowIndex) 
{ 
     var mytable=document.getElementById("grvstand");
     var txt_wlh = document.getElementById("txt_wlh");
     var txt_ph = document.getElementById("txt_ph");
     var txt_gg = document.getElementById("txt_gg");
     var txt_pprice = document.getElementById("txt_pprice");
     var txt_fprice = document.getElementById("txt_fprice");
     var txt_twzl = document.getElementById("txt_twzl"); 

     var hopetype = document.getElementById("hopetype");
     var hwlh = document.getElementById("hwlh");
     var hph = document.getElementById("hph");
     var hgg = document.getElementById("hgg");
     var hpprice = document.getElementById("hpprice");
     var hfprice = document.getElementById("hfprice");
     var htwzl = document.getElementById("htwzl");
     var hkczl = document.getElementById("hkczl");

     txt_wlh.value = mytable.rows[rowIndex].cells[0].innerText;
     txt_ph.value = mytable.rows[rowIndex].cells[1].innerText;
     txt_gg.value = mytable.rows[rowIndex].cells[2].innerText;
     txt_pprice.value = mytable.rows[rowIndex].cells[3].innerText;
     txt_fprice.value = mytable.rows[rowIndex].cells[4].innerText;
     txt_twzl.value = mytable.rows[rowIndex].cells[5].innerText;

     hwlh.value = mytable.rows[rowIndex].cells[0].innerText;
     hph.value = mytable.rows[rowIndex].cells[1].innerText;
     hgg.value = mytable.rows[rowIndex].cells[2].innerText;
     hpprice.value = mytable.rows[rowIndex].cells[3].innerText;
     hfprice.value = mytable.rows[rowIndex].cells[4].innerText;
     htwzl.value = mytable.rows[rowIndex].cells[5].innerText;
     //hkczl.value = mytable.rows[rowIndex].cells[6].innerText;

     var chk =mytable.rows[rowIndex].cells[7].childNodes[0];
     if(chk.checked)
         mytable.rows[rowIndex].style.backgroundColor = '#C8F7FF';
     else
         mytable.rows[rowIndex].style.backgroundColor = '#C0F0F7'
         ;
     for(var i=0;i<mytable.rows.length;i++)
     {
         if (i != rowIndex) {
             chk = mytable.rows[i].cells[7].childNodes[0];
             if (chk.checked)
                 mytable.rows[i].style.backgroundColor = "#FFFFFF";
             else
                 mytable.rows[i].style.backgroundColor = "#F7F7F7";
         }
     }
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

   var txt_wlh = document.getElementById("txt_wlh");
   var txt_ph = document.getElementById("txt_ph");
   var txt_gg = document.getElementById("txt_gg");
   var txt_pprice = document.getElementById("txt_pprice");
   var txt_fprice = document.getElementById("txt_fprice");
   var txt_twzl = document.getElementById("txt_twzl"); //获取生产线信息
   
   var hopetype = document.getElementById("hopetype");
   var hwlh = document.getElementById("hwlh");
   var hph = document.getElementById("hph");
   var hgg = document.getElementById("hgg");
   var hpprice = document.getElementById("hpprice");
   var hfprice = document.getElementById("hfprice");
   var htwzl = document.getElementById("htwzl");
   var hkczl = document.getElementById("hkczl");
   
   
   
   var rowscount = 0;
   var reasontype = "0";

   if (opetype=="query")
   {
      settbedablezxbz(true);//设置是否可选择
      rowscount = tb.childNodes[0].childNodes.length;
      hopetype.value = "query";
      txt_wlh.disabled = true;
      txt_ph.disabled = true;
      txt_gg.disabled = true;
      txt_pprice.disabled = true;
      txt_fprice.disabled = true;
      txt_twzl.disabled = true;
      
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

      txt_wlh.disabled = false;
      txt_ph.disabled = false;
      txt_gg.disabled = false;
      txt_pprice.disabled = false;
      txt_fprice.disabled = false;
      txt_twzl.disabled = false;

      txt_wlh.value = "";
      txt_ph.value = "";
      txt_gg.value = "";
      txt_pprice.value = "";
      txt_fprice.value = "";
      txt_twzl.value = "";
        
      btnnew.disabled = true;
      btnedit.disabled = true;
      btncancel.disabled = false;
      btnsave.disabled = false;
      btndel.disabled = true;
      return false;
   }
   if(opetype=="edit") {
      if(hwlh.value=="")
      {
         alert("请选择需要修改的行！");
         return false;
      }
      settbedablezxbz(false);
      hopetype.value = "edit";

      txt_wlh.disabled = true;
      txt_ph.disabled = false;
      txt_gg.disabled = false;
      txt_pprice.disabled = false;
      txt_fprice.disabled = false;
      txt_twzl.disabled = false;
      
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

      txt_wlh.disabled = true;
      txt_ph.disabled = true;
      txt_gg.disabled = true;
      txt_pprice.disabled = true;
      txt_fprice.disabled = true;
      txt_twzl.disabled = true;

      txt_wlh.value = hwlh.value;
      txt_ph.value = hph.value;
      txt_gg.value = hgg.value;
      txt_pprice.value = hpprice.value;
      txt_fprice.value = hfprice.value;
      txt_twzl.value = htwzl.value;
      
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
       if (txt_wlh.value == "") {
           alert("填写物料编码！");
           txt_wlh.focus();
           return false;
       }
       if (txt_ph.value == "")
      {
         alert("填写品种！");
         txt_ph.focus();
         return false;
      }
      if (txt_gg.value == "")
      {
         alert("填写规格！");
         txt_gg.focus();
         return false;
      }
      if (txt_pprice.value == "")
      {
         alert("填写产品价格！");
         txt_pprice.focus();
         return false;
     }
      if (txt_fprice.value=="")
      {
         alert("填写废品价格！");
         txt_fprice.focus();
         return false;
     }
     
     if (txt_twzl.value == "") {
         alert("填写头尾材重量！");
         txt_twzl.focus();
         return false;
     }
     
     
      if (!isfloat(txt_pprice.value))
      {
          alert("产品价格--数据格式错误！");
          txt_pprice.focus();
         return false;
      }
      
      if (!isfloat(txt_fprice.value)) {
          alert("废品价格--数据格式错误！");
          txt_fprice.focus();
          return false;
      }
      
      if (!isfloat(txt_twzl.value)) {
          alert("头尾材重量--数据格式错误！");
          txt_twzl.focus();
          return false;
      }
      
      //保存
      if(!confirm("是否保存？"))
         return false;
      
      if (hopetype.value == "new")
      {
          var request = getXmlHttpRequest();

          var url = "../CheckQu/LogincAjax.aspx?TYPE=402" +
                 "&opetype=0&wlh=" + encodeURI(txt_wlh.value) + "&ph=" + encodeURI(txt_ph.value) + "&gg=" + encodeURI(txt_gg.value) + "&pprice=" + encodeURI(txt_pprice.value) + "&fprice=" + encodeURI(txt_fprice.value) + "&twzl=" + encodeURI(txt_twzl.value);
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
          var url = "../CheckQu/LogincAjax.aspx?TYPE=402" +
                 "&opetype=1&wlh=" + encodeURI(txt_wlh.value) + "&ph=" + encodeURI(txt_ph.value) + "&gg=" + encodeURI(txt_gg.value) + "&pprice=" + encodeURI(txt_pprice.value) + "&fprice=" + encodeURI(txt_fprice.value) + "&twzl=" + encodeURI(txt_twzl.value);
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

      txt_wlh.disabled = true;
      txt_ph.disabled = true;
      txt_gg.disabled = true;
      txt_pprice.disabled = true;
      txt_fprice.disabled = true;
      txt_twzl.disabled = true;

      txt_wlh.value = "";
      txt_ph.value = "";
      txt_gg.value = "";
      txt_pprice.value = "";
      txt_fprice.value = "";
      txt_twzl.value = "";
      
      btnnew.disabled = false;
      btnedit.disabled = false;
      btncancel.disabled = true;
      btnsave.disabled = true;
      btndel.disabled = false;

      getBZBZInfo();
      
      hopetype.value = "query";
      hwlh.value = "";
      hph.value = "";
      hgg.value = "";
      hpprice.value = "";
      hfprice.value = "";
      htwzl.value="";
      return false;
   }
   if(opetype=="del")
   {
      if (hwlh.value == "")
      {
         alert("请选择需要删除的行！");
         return false;
      }
      //操作
      if(!confirm("是否删除？"))
        return false;
      var request = getXmlHttpRequest();
    
       var url = "../CheckQu/LogincAjax.aspx?TYPE=403&wlh="+hwlh.value;
                         
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
                 alert("删除成功！");
             }
             else
             {
                
                  alert("删除失败："+result);
                return false;
             }
          }

          txt_wlh.disabled = true;
          txt_ph.disabled = true;
          txt_gg.disabled = true;
          txt_pprice.disabled = true;
          txt_fprice.disabled = true;
          txt_twzl.disabled = true;

          txt_wlh.value = "";
          txt_ph.value = "";
          txt_gg.value = "";
          txt_pprice.value = "";
          txt_fprice.value = "";
          txt_twzl.value = "";

          hwlh.value = "";
          hph.value = "";
          hgg.value = "";
          hpprice.value = "";
          hfprice.value = "";
          htwzl.value = "";
          
      getBZBZInfo();
      rowscount = tb.childNodes[0].childNodes.length;
      settbedablezxbz(true);
     
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