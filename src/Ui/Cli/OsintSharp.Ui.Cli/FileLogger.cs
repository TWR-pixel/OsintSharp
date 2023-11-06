using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OsintSharp.Ui.Cli;

internal static class FileLogger
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Log(string msg)
    {
        using(var writer = new StreamWriter(new  FileStream("errorLog.log", FileMode.Create)))
        {
            writer.WriteLine(msg);
        }
    }
}
