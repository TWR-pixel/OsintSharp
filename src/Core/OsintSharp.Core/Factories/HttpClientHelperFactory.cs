using OsintSharp.Core.Interfaces;
using System.Net;

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
        //ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var helper = new HttpClientHelper(new HttpClientHandlerFactory().Create());

        var userAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";
        helper.Client.DefaultRequestHeaders.Add("User-Agent", userAgent);
        helper.Client.Timeout = new TimeSpan(0, 1, 0);
        return helper;
    }
}
