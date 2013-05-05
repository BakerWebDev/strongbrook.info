using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using StrongbrookInfo.ExigoWebService;
using StrongbrookInfo.ExigoOData;

public partial class RAsignup_page2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    #region Get the WebAlias for the querystring
    public void AliasForGamePlanReport()
    {
        HtmlTextWriter writer = new HtmlTextWriter(Response.Output);
        writer.Write(EnrollerWebAlias);
    }

    public string MyProperty { get; set; }
    protected string EnrollerWebAlias
    {
        get
        {

                object id = String.Empty;
                string CustomerWebAlias = "";
                if (Request.QueryString["ID"] != null)
                {
                    CustomerWebAlias = Request.QueryString["ID"];
                }
                if (CustomerWebAlias == "")
                {
                    Response.Redirect("orphan");
                }
                return CustomerWebAlias;
            
        }
        set { MyProperty = value; }
    }
    #endregion

    #region Get the CustomerID for the querystring

    public int CustomerID 
    { 
        get
        {
            ExigoApiServices context = new ExigoApiServices();

            var custID = 0;
            var data = context.OData.Customers
                .Where(c => c.LoginName == Request.QueryString["ID"])
                .Select(c => new { c.CustomerID })
                .FirstOrDefault();
            if (data != null) custID = data.CustomerID;

            return custID;
        } 
        set
        {
            CustomerID = value;
        }
    }

    //public string EnrollerID { get; set; }
    //protected string EnrollerCustomerID
    //{
    //    get
    //    {
    //        object id = String.Empty;
    //        string EnrollerID = "";
    //        if (Request.QueryString["ID"] != null)
    //        {
    //            EnrollerID = Request.QueryString["ID"];
    //        }
    //        if (EnrollerID == "")
    //        {
    //            Response.Redirect("10005");
    //        }
    //        return EnrollerID;

    //    }
    //    set { EnrollerID = value; }
    //}

    public void CustomerIDForGamePlanReport()
    {
        HtmlTextWriter writer = new HtmlTextWriter(Response.Output);
        writer.Write(CustomerID);
    }
    #endregion

}




