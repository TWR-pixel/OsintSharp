using System.Net;

namespace OsintSharp.Core;

internal class HttpClientHelperBuilder
{
    public HttpClientHelper HttpClientHelper { get; set; }

    public HttpClientHelperBuilder(HttpClientHandler handler)
    {
        HttpClientHelper = new HttpClientHelper(handler);
    }

    public HttpClientHelperBuilder SetUserAgent(string userAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4")
    {
        ThrowHelper.ThrowIfArgumentNull(userAgent);

        var agent = userAgent;
        HttpClientHelper.Client.DefaultRequestHeaders.Add("User-Agent", agent);

        return this;
    }

    public HttpClientHelperBuilder SetTimeout(TimeSpan timeout)
    {
        HttpClientHelper.Client.Timeout = timeout;

        return this;
    }

}

