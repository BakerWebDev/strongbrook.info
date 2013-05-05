using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Route Data
        if (!IsPostBack)
        {
            string alias = null;

            object id = String.Empty;
            // Attempt to get WebAlias from routing data
            if (RouteData.Values.TryGetValue("id", out id))
            {
                ExigoApiServices api = new ExigoApiServices();
                #region Get the data
                var auth = new ExigoApiServices();
                string webAlias = id.ToString();
                var query = (from c in auth.OData.Customers
                             where c.LoginName == id.ToString()
                             select new
                             {
                                 c.FirstName,
                                 c.LastName,
                                 c.Phone,
                                 c.LoginName
                             });
                #endregion
                #region Return the data
                if (query.Count() > 0)
                {
                    foreach (var i in query)
                    {
                        webAlias = i.LoginName;
                    }
                }
                #endregion
                alias = webAlias;
            }
            if (alias != null)
            {
                Response.Redirect("RAsignup/page1.aspx?ID=" + alias);
            }
            else
            {
                // The requested person was not found
                Response.Redirect("RAsignup/page1.aspx?ID=" + "orphan");
            }
        }
        #endregion









        
    }
}