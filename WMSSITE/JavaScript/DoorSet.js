function getId(objId){
    return document.getElementById(objId);
}
function adddoor() {
   var txtdoorno=getId("txtdoorno");
   var txtdoorname=getId("txtdoorname");
   var txtip=getId("txtip");
   var txtport=getId("txtport");
   txtdoorno.value="";
   txtdoorno.disabled="";
   txtdoorname.value="";
   txtip.value="";
   txtport.value="";
}
function savedoor() {
   if (txtdoorno.value=="") {
      alert("输入门岗编号");
      return;
   }
}
function adddoorcamer() {
    var txtdcname=getId("txtdcname");
    var txtdcip=getId("txtdcip");
    var txtdcport=getId("txtdcport");
    var hdcno=getId("hdcno");
    txtdcname.value="";
    txtdcip.value="";
    txtdcport.value="";
    hdcno.value="";
}
function vvv() {
   alert("11");
}
function sethidvalue() {
   var ddlmg=getId("ddlmg");
   var htxtmgno=getId("htxtmgno");
   var selValue = getId("ddlmg").options[getId("ddlmg").selectedIndex].value;
   htxtmgno.value=selValue;
}
function savedoorcamer() {
    var txtdcname=getId("txtdcname");
    var txtdcip=getId("txtdcip");
    var txtdcport=getId("txtdcport");
    var selValue = getId("ddlmg").options[getId("ddlmg").selectedIndex].value;
    var url = "../qucheck/LogincAjax.aspx?TYPE=38&mgno="+selValue+"&dcname="+txtdcname.value+"&dcip="+txtdcip.value+"&dcport="+txtdcport.value;
    sendRequest(url,"","POST",request);
    var result = request.responseText;
    
}
function SelectDataGridRow(dgvname,rowindex) {
    var mytable=getId(dgvname);
    var txtdoorno=getId("txtdoorno");
    var txtdoorname=getId("txtdoorname");
    var ddlmg=getId("ddlmg");
    var txtdcname=getId("txtdcname");
    var txtdcip=getId("txtdcip");
    var txtdcport=getId("txtdcport");
    var hdcno=getId("hdcno");
    var txtip=getId("txtip");
    var txtport=getId("txtport");
    var e = event.srcElement;
    var tds = null;
    if(e.tagName=="TD")
      tds= e.parentNode.all.tags("td");
    else
      tds=e.all.tags("td");
       
    txtdoorno.value=tds[0].innerText;
    txtdoorname.value=tds[1].innerText;
    //ddlmg.value=tds[6].innerText;
    //txtdcname.value=tds[2].innerText;
    //txtdcip.value=tds[3].innerText;
    //txtdcport.value=tds[4].innerText;
    hdcno.value=tds[0].innerText;  
    txtip.value=tds[2].innerText;
    txtport.value=tds[3].innerText;
    for(var i=1;i<mytable.rows.length;i++)
     {
         if(i!=rowindex)
         {
            mytable.rows[i].style.backgroundColor="#FFFFFF";
         }
     }
     if(rowindex!=0)
     {
       mytable.rows[rowindex].oldcolor=mytable.rows[rowindex].style.backgroundColor;
       mytable.rows[rowindex].style.backgroundColor='#C8F7FF';
       
     }
}
function refuseData() {
   var grvstand = document.getElementById("grvstand");
    if (grvstand!=null)
    {
       //清空数据
       deleteRow("grvstand",0);
       var request = getXmlHttpRequest();
       var url = "../SysMan/LogincAjax.aspx?TYPE=33";
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
          
          var itemsLength = items1.length;
          var oldbzbz="";
          var newbzbz="";
          var displaystyle="none";
          for (i=0;i<itemsLength;i++)
          {
              newbzbz=items1[i].text;
              if (newbzbz!=oldbzbz) {
                 displaystyle="block";
              }else displaystyle="none";
              
              var txt0 = items0[i].text;
              var txt1 = items1[i].text;
              var txt2 = items2[i].text;
              var txt3 = items3[i].text;
              var txt4 = items4[i].text;
              var txt5 = items5[i].text;
              insertRowzxbz(displaystyle,txt0,txt1,txt2,txt3,txt4,txt5,i);
              oldbzbz=newbzbz;
          }
       }
    }
}

