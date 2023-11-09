using OsintSharp.Core.Interfaces;
using System.Net;

namespace OsintSharp.Core.Factories;

public class HttpsClientHelperFactory : IFactory<HttpClientHelper>
{
    public HttpClientHelper Create()
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var builder = new HttpClientHelperBuilder(new HttpClientHandlerFactory().Create());

        var userAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

        builder.SetUserAgent(userAgent);
        builder.SetTimeout(TimeSpan.FromSeconds(10));
        
        return builder.HttpClientHelper;
    }
}
