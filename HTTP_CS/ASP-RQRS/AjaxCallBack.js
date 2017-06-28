

var xmlHttp;
var xmlDoc; 
var RSRet;

function CallbackRequest(RQStr, Des)
	{
     if (window.XMLHttpRequest) { // 如果可以取得XMLHttpRequest
        	xmlHttp = new XMLHttpRequest();  // Mozilla、Firefox、Safari 
          	//startRequest(DataName); 
    		}
     else if (window.ActiveXObject) { // 如果可以取得ActiveXObject
        	xmlHttp = new ActiveXObject("Microsoft.XMLHTTP"); // Internet Explorer
	       // startRequest(DataName); 
 
   		}
	 else {alert("xmlHttp object initial error");	}
	 if(xmlHttp)
	     {xmlHttp.onreadystatechange =  GetRSRet   // 設定callback函式
		  xmlHttp.open("POST", Des, false); //true for asyn. // 開啟連結
   		  xmlHttp.send(RQStr); // 送出xmlDom	
   		  }
	}


function GetRSRet(){
    // alert(xmlHttp.readyState);
    //4 call back 完成,請參考 Ajax 訊息說明 
    if ( xmlHttp.readyState == 4 ) {
      	     RSRet = xmlHttp.responseText;
	    }
  }
 

