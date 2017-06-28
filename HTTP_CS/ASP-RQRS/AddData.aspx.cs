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
using System.Data;
using System.Data.OleDb;

public partial class AddData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["DataConnectionString"];
        string ConnString;
        //"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("Admin/news.mdb")
        ConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data/Data.mdb");
        //使用 Connection 物件開啟資料連接 
        OleDbConnection objConn = new OleDbConnection(ConnString);

        //建立 DataAdapter 物件
        OleDbDataAdapter objCmd = new OleDbDataAdapter("Select * From DataTable", objConn);

        //建立 CommandBuilder 物件
        OleDbCommandBuilder objCB = new OleDbCommandBuilder(objCmd);

        //建立 DataSet 物件，並將 SelectCommand 的執行結果置入 DataSet 物件中
        DataSet DS = new DataSet();
        objCmd.Fill(DS, "DataTable");

        //建立 myTable 為 DataTable 物件，將 DataSet 物件的 DataTable 資料表指定給 myTable    
        DataTable myTable = DS.Tables["DataTable"];
      

        //新增資料列
        DataRow myRow = myTable.NewRow();
        string aaa;
        aaa = Request.Form["ID"];
        myRow["ID"] = Request.Form["ID"];
        myRow["Name"] = Request.Form["Name"];
        myRow["Data"] = Request.Form["Data"]; 
        myTable.Rows.Add(myRow);

        objCmd.Update(myTable.Select(null, null, DataViewRowState.Added));
        Response.Write("Input data  done");
    }
}
