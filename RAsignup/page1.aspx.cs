using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StrongbrookInfo.ExigoOData;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using StrongbrookInfo.ExigoWebService;
using System.Web.Services;


public partial class RAsignup_page1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Public Properties


    public int enrolleridy { get; set; }
    protected int EnrollerID
    {
        get
        {
            int customerID = 0;
            //object id = String.Empty;
            if (enrolleridy == 0)
            {
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
                                     c.CustomerID
                                 });
                    #endregion
                    #region Return the data
                    if (query.Count() > 0)
                    {
                        foreach (var i in query)
                        {
                            customerID = i.CustomerID;
                        }
                    }
                    #endregion
                }
            }

            if (enrolleridy == 0)
            {
                enrolleridy = customerID;
            }
            customerID = enrolleridy;
            //custidy = customerID;
            //return customerID;
            return customerID;
        }
        set { txtEnrollerID.Text = value.ToString(); }
        //set { custidy = value; }
    }















    public int custidy { get; set; }
    protected int CustomerID
    {
        get
        {
            int customerID = 0;
            //object id = String.Empty;
            if (custidy == 0)
            {
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
                                     c.CustomerID
                                 });
                    #endregion
                    #region Return the data
                    if (query.Count() > 0)
                    {
                        foreach (var i in query)
                        {
                            customerID = i.CustomerID;
                        }
                    }
                    #endregion
                }
            }

            if (custidy == 0)
            {
                custidy = customerID;
            }
            customerID = custidy;
            //custidy = customerID;
            //return customerID;
            return customerID;
        }
        set { txtEnrollerID.Text = value.ToString(); }
        //set { custidy = value; }
    }























    public int _RAsEnrollerID { get; set; }
    protected int RAsEnrollerID
    {
        get
        {
            int enrollerID = 0;
            if (_RAsEnrollerID == 0)
            {
                if (EnrollerID != 0)
                {
                    ExigoApiServices api = new ExigoApiServices();
                    #region Get the data
                    var auth = new ExigoApiServices();

                    var query = (from c in auth.OData.EnrollerTree
                                 where c.CustomerID == EnrollerID
                                 select new
                                 {
                                     c.EnrollerID
                                 });
                    #endregion
                    #region Return the data
                    if (query.Count() > 0)
                    {
                        if (enrollerID == 0)
                        {
                            foreach (var i in query)
                            {
                                enrollerID = i.EnrollerID;
                            }
                        }

                    }
                    #endregion
                }
            }
            //return enrollerID;
            if (_RAsEnrollerID == 0)
            {
                _RAsEnrollerID = enrollerID;
            }
            enrollerID = _RAsEnrollerID;

            return enrollerID;
        }

        set { _RAsEnrollerID = value; }
    }

    public int _RAsEnrollerType { get; set; }
    protected int RAsEnrollerType
    {
        get
        {
            int enrollerID = 0;
            if (_RAsEnrollerType == 0)
            { 
                if (RAsEnrollerID != 0)
                {
                    ExigoApiServices api = new ExigoApiServices();
                    #region Get the data
                    var auth = new ExigoApiServices();

                    var query = (from c in auth.OData.Customers
                                 where c.CustomerID == RAsEnrollerID
                                 select new
                                 {
                                     c.CustomerTypeID
                                 });
                    #endregion
                    #region Return the data
                    foreach (var i in query)
                    {
                        enrollerID = i.CustomerTypeID;
                    }
                    #endregion
                }
                        
            }
            return enrollerID;
        }

        set { _RAsEnrollerID = value; }
    }





    public int _CustomerTypeOfAliasInURL { get; set; }
    protected int CustomerTypeOfAliasInURL
    {
        get
        {
            int custType = 0;
            if (_CustomerTypeOfAliasInURL == 0)
            {
                //if (EnrollerID != 0) // This needs to be changed to say CustomerID
                if (CustomerID != 0)
                {
                    ExigoApiServices api = new ExigoApiServices();
                    #region Get the data
                    var auth = new ExigoApiServices();

                    var query = (from c in auth.OData.Customers
                                 where c.CustomerID == EnrollerID
                                 select new
                                 {
                                     c.CustomerTypeID
                                 });
                    #endregion
                    #region Return the data
                    foreach (var i in query)
                    {
                        custType = i.CustomerTypeID;
                    }
                    #endregion
                }
                        
            }
            return custType;
        }

        set { _CustomerTypeOfAliasInURL = value; }
    }





    protected string EnrollerWebAlias
    {
        get
        {
            if (CookieEnrollerID != null)
            {
                return CookieEnrollerWebAlias;
            }
            else
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
        }
        set { txtEnrollerID.Text = value.ToString(); }
    }

    public int NewCustomerID { get; set; }
    //protected int NewCustomerID
    //{
    //    get
    //    {
    //        if (CookieNewCustomerID != null)
    //        {
    //            return Convert.ToInt32(CookieNewCustomerID);
    //        }
    //        else
    //        {
    //            return Convert.ToInt32(txtNewCustomerID.Text);
    //        }
    //    }
    //    set { txtNewCustomerID.Text = value.ToString(); }
    //}
    protected string FirstName
    {
        get
        {
            if (CookieFirstName != null)
            {
                return CookieFirstName;
            }
            else
            {
                return txtFirstName.Text;
            }
        }
        set { txtFirstName.Text = value; }
    }
    protected string LastName
    {
        get
        {
            if (CookieLastName != null)
            {
                return CookieLastName;
            }
            else
            {
                return txtLastName.Text;
            }
        }
        set { txtLastName.Text = value; }
    }
    protected string Email
    {
        get
        {
            if (CookieEmail != null)
            {
                return CookieEmail;
            }
            else
            {
                return txtEmail.Text;
            }
        }
        set { txtEmail.Text = value; }
    }
    protected string ConfirmEmail
    {
        get
        {
            if (CookieConfirmEmail != null)
            {
                return CookieConfirmEmail;
            }
            else
            {
                return txtConfemail.Text;
            }
        }
        set { txtConfemail.Text = value; }
    }
    protected string DaytimePhone
    {
        get
        {
            if (CookieDaytimePhone != null)
            {
                return CookieDaytimePhone;
            }
            else
            {
                return txtPhone.Text;
            }
        }
        set { txtPhone.Text = value; }
    }
    protected string WebAlias
    {
        get
        {
            if (CookieWebAlias != null)
            {
                return CookieWebAlias;
            }
            else
            {
                return txtUsername.Text;
            }
        }
        set { txtUsername.Text = value; }
    }

    #region Cookie Properties
    public string _EnrollerID { get; set; }
    protected string CookieEnrollerID
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _EnrollerID = Request.Cookies["userCookie"].Values["txtEnrollerID"];
                return _EnrollerID;
            }
            else
            {
                return _EnrollerID;
            }

        }
        set { _EnrollerID = value; }
    }



    public string _EnrollerWebAlias { get; set; }
    protected string CookieEnrollerWebAlias
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _EnrollerWebAlias = Request.Cookies["userCookie"].Values["txtEnrollerWebAlias"];
                return _EnrollerWebAlias;
            }
            else
            {
                return _EnrollerWebAlias;
            }

        }
        set { _EnrollerWebAlias = value; }
    }


    public int _NewCustomerID { get; set; }
    protected string CookieNewCustomerID
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _NewCustomerID = Convert.ToInt32(Request.Cookies["userCookie"].Values["txtNewCustomerID"]);
                return _NewCustomerID.ToString();
            }
            else
            {
                return _NewCustomerID.ToString();
            }

        }
        set { _NewCustomerID = Convert.ToInt32(value); }
    }

    public string _FirstName { get; set; }
    protected string CookieFirstName
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _FirstName = Request.Cookies["userCookie"].Values["txtFirstName"];
                return _FirstName;
            }
            else
            {
                return _FirstName;
            }

        }
        set { _FirstName = value; }
    }

    public string _LastName { get; set; }
    protected string CookieLastName
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _LastName = Request.Cookies["userCookie"].Values["txtLastName"];
                return _LastName;
            }
            else
            {
                return _LastName;
            }
        }
        set { _LastName = value; }
    }

    public string _Email { get; set; }
    protected string CookieEmail
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _Email = Request.Cookies["userCookie"].Values["txtEmail"];
                return _Email;
            }
            else
            {
                return _Email;
            }
        }
        set { _Email = value; }
    }

    public string _ConfirmEmail { get; set; }
    protected string CookieConfirmEmail
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _ConfirmEmail = Request.Cookies["userCookie"].Values["txtEmailConf"];
                return _ConfirmEmail;
            }
            else
            {
                return _ConfirmEmail;
            }
        }
        set { _ConfirmEmail = value; }
    }

    public string _DaytimePhone { get; set; }
    protected string CookieDaytimePhone
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _DaytimePhone = Request.Cookies["userCookie"].Values["txtPhone"];
                return _DaytimePhone;
            }
            else
            {
                return _DaytimePhone;
            }
        }
        set { _DaytimePhone = value; }
    }

    public string _WebAlias { get; set; }
    protected string CookieWebAlias
    {
        get
        {
            if (Request.Cookies["userCookie"] != null)
            {
                _WebAlias = Request.Cookies["userCookie"].Values["txtUsername"];
                return _WebAlias;
            }
            else
            {
                return _WebAlias;
            }
        }
        set { _WebAlias = value; }
    }
    #endregion

    public string DefaultCountry = "US";
    public string CurrencyCode = "usd";
    public int WarehouseID = 1;
    public int PriceType = 1;
    public string ShipMethods = "2";
    public int DefaultShipMethodID = 2;
    public int ShipMethodID = 2;

    public string ToTheNextPage = "~/RAsignup/page2.aspx";

    #endregion

    public void Click_NextPage(object sender, EventArgs e)    
    {
        if (textFieldsAreNotEmpty())
        {
            GoForward();
        }
        else
        {
            Response.Redirect(Request.RawUrl);
        }
    }

    public void GoForward()
    {
        string var = "?" + "confirm=" + Server.UrlEncode(Encrypt(string.Format("{0}|{1}|{2}|{3}|{4}"
                , EnrollerWebAlias // 0
                , FirstName // 1
                , LastName // 2
                , Email // 3
                , WebAlias // 4
                ), "justdoit"));

        SubmitOrder();

        string variables = EnrollerWebAlias.ToString();
        //SaveUserCookie();
        Response.Redirect(ToTheNextPage + var + "&ID=" + variables);    
    }


    public bool textFieldsAreNotEmpty()
    {
        bool check1 = false;
        if (txtFirstName.Text != "" && txtLastName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "" && txtEmail.Text == txtConfemail.Text)
        {
            check1 = true;
        }
        return check1;
    }



    #region Exigo API Requests
    public void SubmitOrder()
    {
        ExigoApiServices Exigo = new ExigoApiServices();
        var response = Exigo.WebService.ProcessTransaction(TransactionRequest_Initial());

        if (response.Result.Status == ResultStatus.Success)
        {
            foreach (ApiResponse resp in response.TransactionResponses)
            {
                if (resp is CreateCustomerLeadResponse) NewCustomerID = ((CreateCustomerLeadResponse)resp).CustomerLeadID;
            }
        }
    }

    TransactionalRequest TransactionRequest_Initial()
    {
        TransactionalRequest req = new TransactionalRequest();
        List<ApiRequest> details = new List<ApiRequest>();

        details.Add(Request_CreateCustomerLead());

        req.TransactionRequests = details.ToArray();
        return req;
    }


    public CreateCustomerLeadRequest Request_CreateCustomerLead()
    {
        CreateCustomerLeadRequest req = new CreateCustomerLeadRequest();

        //req.CustomerID = EnrollerID;

        if (CustomerTypeOfAliasInURL == 3 || CustomerTypeOfAliasInURL == 4)
        {
            req.CustomerID = EnrollerID;   
        }
        else if (CustomerTypeOfAliasInURL == 8)
        {
            req.CustomerID = RAsEnrollerID;
        }

        req.FirstName = FirstName;
        req.LastName = LastName;
        req.Email = Email;
        req.Phone = DaytimePhone;
        req.Notes = "Customer created by the RA Leads Referral Signup at " + Request.Url.AbsoluteUri.ToString() + " on " + DateTime.Now + " CST at IP " + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] + " using " + Request.Browser.Browser + " " + Request.Browser.Version + " (" + Request.Browser.Platform + ").   ";

        return req;
    }
    #endregion

    #region Create and save the Cookie
    public void CreateNewUserCookie()
    {
        string CustomerID = EnrollerWebAlias.ToString();
        string FirstName = txtFirstName.Text;
        string LastName = txtLastName.Text;
        string DaytimePhone = txtPhone.Text;
        string Email = txtEmail.Text;
        string ConfirmEmail = txtConfemail.Text;

        HttpCookie userCookie = new HttpCookie("userCookie");
        userCookie.Expires = DateTime.Now.AddDays(1);

        userCookie.Values.Add("CustomerID", CustomerID);
        userCookie.Values.Add("txtFirstName", FirstName);
        userCookie.Values.Add("txtLastName", LastName);
        userCookie.Values.Add("txtPhone", DaytimePhone);
        userCookie.Values.Add("txtEmail", Email);
        userCookie.Values.Add("txtEmailConf", ConfirmEmail);
        Response.Cookies.Add(userCookie);
    }
    public void SaveUserCookie()
    {
        if (Request.Cookies["userCookie"] == null) //if there isn't a cookie, create one
        {
            //set user permissions through encryption into UserCookie
            CreateNewUserCookie();
        }

        if (Request.Cookies["userCookie"] != null) //if the cookie Customer ID is different than the one loggin in, delete it and create a new one
        {
            Request.Cookies["userCookie"].Expires = DateTime.Now.AddDays(-1);

            CreateNewUserCookie();
        }

    }
    #endregion

    #region Encryption Methods
    // Used for submission process URL variables
    string Encrypt(string uncoded, string key)
    {
        RijndaelManaged cryptProvider = new RijndaelManaged();
        cryptProvider.KeySize = 256;
        cryptProvider.BlockSize = 256;
        cryptProvider.Mode = CipherMode.CBC;
        SHA256Managed hashSHA256 = new SHA256Managed();
        cryptProvider.Key = hashSHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
        string iv = "signup";
        cryptProvider.IV = hashSHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(iv));
        byte[] plainTextByteArray = ASCIIEncoding.ASCII.GetBytes(uncoded);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, cryptProvider.CreateEncryptor(), CryptoStreamMode.Write);
        cs.Write(plainTextByteArray, 0, plainTextByteArray.Length);
        cs.FlushFinalBlock();
        cs.Close();
        byte[] byt = ms.ToArray();
        return Convert.ToBase64String(byt);
    }
    string Decrypt(string coded, string key)
    {
        RijndaelManaged cryptProvider = new RijndaelManaged();
        cryptProvider.KeySize = 256;
        cryptProvider.BlockSize = 256;
        cryptProvider.Mode = CipherMode.CBC;
        SHA256Managed hashSHA256 = new SHA256Managed();
        cryptProvider.Key = hashSHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
        string iv = "signup";
        cryptProvider.IV = hashSHA256.ComputeHash(ASCIIEncoding.ASCII.GetBytes(iv));
        byte[] cipherTextByteArray = Convert.FromBase64String(coded);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, cryptProvider.CreateDecryptor(), CryptoStreamMode.Write);
        cs.Write(cipherTextByteArray, 0, cipherTextByteArray.Length);
        cs.FlushFinalBlock();
        cs.Close();
        byte[] byt = ms.ToArray();
        return Encoding.ASCII.GetString(byt);
    }
    #endregion



}




