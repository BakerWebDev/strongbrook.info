using StrongbrookInfo.ExigoOData;
using StrongbrookInfo.ExigoWebService;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;

public class ExigoApiServices
{


    public ExigoApiServices()
    {
    }

    private string LoginName = "API_Strongbrook";
    private string Password = "strongbrookapi";
    private string Company = "strongbrook";

    public ExigoContext OData
    {
        get
        {
            var context = new ExigoContext(new Uri("http://api.exigo.com/4.0/" + Company + "/model"));
            context.IgnoreMissingProperties = true;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(LoginName + ":" + Password));
            context.SendingRequest +=
                (object s, SendingRequestEventArgs e) =>
                    e.RequestHeaders.Add("Authorization", "Basic " + credentials);
            _odata = context;

            return _odata;
        }
    }
    private ExigoContext _odata;

    public ExigoContext ODataReports
    {
        get
        {
            if (_odatareports == null)
            {
                var context = new ExigoContext(new Uri("http://api.exigo.com/4.0/" + Company + "/reports"));
                context.IgnoreMissingProperties = true;
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(LoginName + ":" + Password));
                context.SendingRequest +=
                    (object s, SendingRequestEventArgs e) =>
                        e.RequestHeaders.Add("Authorization", "Basic " + credentials);
                _odatareports = context;
            }
            return _odatareports;
        }
    }
    public ExigoContext _odatareports;



    public ExigoApi WebService
    {
        get
        {
            if (_webservice == null)
            {
                _webservice = new ExigoApi
                {
                    ApiAuthenticationValue = new ApiAuthentication
                    {
                        LoginName = LoginName,
                        Password = Password,
                        Company = Company
                    }
                };
            }
            return _webservice;
        }
    }
    private ExigoApi _webservice;


}
