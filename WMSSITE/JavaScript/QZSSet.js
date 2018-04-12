function getId(objId){
    return document.getElementById(objId);
}
function adddoor() {
   var txtdoorno=getId("txtdoorno");
   var txtdoorname=getId("txtdoorname");
   var hdcno=getId("hdcno");
   var txtip=getId("txtip");
   var txtport=getId("txtport");
   hdcno.value="";
   txtdoorno.value="";
   txtdoorname.value="";
   txtip.value="";
   txtport.value="";
}
function savedoor() {
   if (txtdoorno.value=="") {
      alert("输入签证室编号");
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
    txtip.value=tds[2].innerText;
    txtport.value=tds[3].innerText;
    hdcno.value=tds[0].innerText;  
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