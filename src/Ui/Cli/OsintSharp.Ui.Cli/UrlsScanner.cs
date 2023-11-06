using OsintSharp.Core;
using System.Collections.Concurrent;

namespace OsintSharp.Ui.Cli;

internal class UrlsScanner
{
    private readonly HttpClientHelper _httpClientHelper;
    private object _consoleLoggerLocker = new();
    private object _fileLoggerLocker = new();

    public UrlsScanner(HttpClientHelper httpClientHelper)
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
    public async Task StartAnalysisAsync(HttpMethods httpMethod, ConcurrentBag<string> urls, bool catchException = true)
    {
        var urlsCount = urls.Count();
        var urlsArray = urls.ToArray();

        if (httpMethod == HttpMethods.GET)
        {
            for (int i = 1; i < urlsCount; Interlocked.Increment(ref i))
            {
                var th = new Task(async () =>
                {
                    await PrintResult(urlsArray[i - 1]);
                });

                th.Start();
                th.Wait(300); // waits 300 ms

            }
        }


    }

    /// <summary>
    /// Writes output and log exceptions to file 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    private async Task PrintResult(string url)
    {
        try
        {
            var msg = await _httpClientHelper.GetAsync(url);

            lock (_consoleLoggerLocker)
            {
                ConsoleLogger.LogLine(url, msg);
            }
        }
        catch (TimeoutException ex)
        {
            lock (_fileLoggerLocker)
            {
                FileLogger.Log($"[{url}]    {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            lock (_fileLoggerLocker)
            {
                FileLogger.Log($"[{url}]    {ex.Message}");
            }
        }
    }
}
