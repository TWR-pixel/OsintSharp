using OsintSharp.Core;

namespace OsintSharp.Ui.Cli;

internal class SocialNetwork
{
    private readonly HttpClientHelper _httpClientHelper;

    public SocialNetwork(HttpClientHelper httpClientHelper)
    {
        if (httpClientHelper is null) throw new ArgumentNullException(nameof(httpClientHelper));

        _httpClientHelper = httpClientHelper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpMethod"></param>
    /// <param name="urls">urls list social networks</param>
    /// <returns>http response message list with codes</returns>
    /// <exception cref="HttpMethodNotSupportedException"></exception>
    public async Task StartAnalysisAsync(HttpMethods httpMethod, IEnumerable<string> urls, bool catchException = true)
    {
        var urlsCount = urls.Count();
        var urlsArray = urls.ToArray();

        if (httpMethod == HttpMethods.GET)
        {
            for (int i = urlsCount; i > 0; i--)
            {
                var th = new Thread(async () =>
                {
                    await PrintResultAsync(urlsArray[i]);
                });
                th.Start();

            }
        }


    }

    private async Task PrintResultAsync(string url)
    {
        try
        {
            var r = await _httpClientHelper.GetAsync(url);
            await Console.Out.WriteLineAsync($"[{url}] {r.StatusCode}");
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
    }
}
