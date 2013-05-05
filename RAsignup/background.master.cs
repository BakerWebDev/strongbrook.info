using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RAsignup_background : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string alias = null;
            string firstName = "";
            string lastName = "";
            string phone = "";

            object id = String.Empty;
            // Attempt to get WebAlias from routing data
            if (Request.QueryString["ID"] != null)
            {
                ExigoApiServices api = new ExigoApiServices();
                #region Get the data
                var auth = new ExigoApiServices();
                string webAlias = Request.QueryString["ID"];
                var query = (from c in auth.OData.Customers
                             where c.LoginName == webAlias
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
                        firstName = i.FirstName;
                        lastName = i.LastName;
                        phone = i.Phone;

                        webAlias = i.LoginName;
                    }
                }
                #endregion
                alias = webAlias;
            }
            if (alias != null)
            {
                lblFirstName.Text = firstName;
                lblLastName.Text = lastName;
                lblPhone.Text = phone;
            }
            else
            {
                // The requested city was not found
                lblFirstName.Text = "The person specified is not available!";
            }
        }


    }
}
