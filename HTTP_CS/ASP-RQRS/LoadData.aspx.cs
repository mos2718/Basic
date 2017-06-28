using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;
using System.Data.OleDb;


public partial class LoadData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


      string str;

        StreamReader reader = new StreamReader(Request.InputStream);
        string xmlData = reader.ReadToEnd();

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlData);

        XmlNode RNode, Node1;
        RNode = doc.FirstChild;
        XmlNodeList NodeList;
        NodeList = RNode.ChildNodes;
        int i, Count;

        string IDStr, NameStr, DataStr;
        IDStr = "";
        NameStr = "";
        DataStr = "";
        Count = NodeList.Count;
        for (i = 0; i < Count; i++)
        {
            Node1 = NodeList[i];
            str = Node1.Name;
            if (str == "ID")
                IDStr = Node1.InnerText;
            /*
                 if (str == "Name")
                     NameStr = Node1.InnerText;
                 if (str == "Data")
                     DataStr = Node1.InnerXml;
             */
        }

     

        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source=" + Server.MapPath("~/App_Data/Data.mdb");
        //使用 Connection 物件開啟資料連接
        OleDbConnection objConn = new OleDbConnection(connStr); 
        str = "Select * From DataTable Where ID ='";
        str += IDStr;
        str += "'";

        //建立 DataAdapter 物件
        OleDbDataAdapter objCmd = new OleDbDataAdapter(str, objConn);

        //建立 CommandBuilder 物件
        OleDbCommandBuilder objCB = new OleDbCommandBuilder(objCmd);

        //建立 DataSet 物件，並將 SelectCommand 的執行結果置入 DataSet 物件中
        DataSet DS = new DataSet();
        objCmd.Fill(DS, "DataTable");

        //建立 myTable 為 DataTable 物件，將 DataSet 物件的 DataTable 資料表指定給 myTable    
        DataTable myTable = DS.Tables["DataTable"];
        string xml = "<Root>";
        if (myTable.Rows.Count > 0)
            xml += myTable.Rows[0]["Data"].ToString();
        xml += "</Root>";
        Response.Write(xml);
    }
}
