using OsintSharp.Core;
using OsintSharp.Core.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;

namespace OsintSharp.Core.Factories;

public class HttpClientHelperFactory : IFactory<HttpClientHelper>
{
    public HttpClientHelper Create()
    {
        //var proxy = new WebProxy
        //{
        //    Address = new Uri($"http://117.54.114.103:80"),
        //    BypassProxyOnLocal = false,
        //    UseDefaultCredentials = false,
        //};

        var handler = new HttpClientHandler
        {
            UseProxy = false,
        };
        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        
        var helper = new HttpClientHelper(handler);
        var userAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";
        helper.Client.DefaultRequestHeaders.Add("User-Agent", userAgent);

        return helper;
    }
}
