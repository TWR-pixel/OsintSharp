using System.Runtime.CompilerServices;

namespace OsintSharp.Core;

public class HttpClientHelper
{
    public  HttpClient Client { get; set; }

    public HttpClientHelper(HttpClientHandler handler)
    {
        ThrowHelper.ThrowIfArgumentNull(handler);

        Client = new HttpClient(handler, true);
    }

    public HttpClientHelper()
    {
        Client = new HttpClient();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public async Task<HttpResponseMessage> GetAsync(string url, bool catchException = true)
    {
        ThrowHelper.ThrowIfArgumentNull(url);

        var msg = await Client.GetAsync(url);
        return msg;
    }

}
