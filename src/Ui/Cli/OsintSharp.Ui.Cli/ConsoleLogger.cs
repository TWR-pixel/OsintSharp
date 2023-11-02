using System.Net;
using System.Runtime.CompilerServices;

namespace OsintSharp.Ui.Cli;

internal static class ConsoleLogger
{
    public static void LogLine(string url,HttpResponseMessage msg)
    {
        switch (msg.StatusCode)
        {
            case HttpStatusCode.OK:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Out.WriteLine($"[{url}]    {msg.StatusCode}");
                Console.ResetColor();
                break;
            case HttpStatusCode.NotFound:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Out.WriteLine($"[{url}]    {msg.StatusCode}");
                Console.ResetColor();
                break;
            case HttpStatusCode.BadRequest:
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Out.WriteLine($"[{url}]    {msg.StatusCode}");
                Console.ResetColor();
                break;
            case HttpStatusCode.Forbidden:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Out.WriteLine($"[{url}]    {msg.StatusCode}");
                Console.ResetColor();
                break;
            default:
                break;
        }

    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void LogError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Out.WriteLine(msg);
        Console.ResetColor();
    }
}
