using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

public partial class sShowQueryString : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {	// 1
        // Get collection
        NameValueCollection n = Request.QueryString;
        // 2
        // See if any query string exists
        int i=0;
        while (i < n.Count)
        {          
            string k = n.GetKey(i);
            string v = n.Get(i);
            Response.Write("Parameter is: " + k);
            Response.Write(" 　 and value is:" + v);
            Response.Write("<br/>");
            i = i + 1;
        }

    }
}