namespace OsintSharp.Core;

public class HttpClientHelper
{
    public  HttpClient Client { get; set; }

    public HttpClientHelper(HttpClientHandler handler)
    {
        if (handler == null) throw new ArgumentNullException(nameof(handler));

        Client = new HttpClient(handler, true);
    }

    public HttpClientHelper()
    {
        Client = new HttpClient();
    }

    public async Task<HttpResponseMessage> GetAsync(string url, bool catchException = true)
    {
        if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

        var msg = await Client.GetAsync(url);
        return msg;
    }



}
