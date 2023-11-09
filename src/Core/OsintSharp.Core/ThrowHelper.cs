namespace OsintSharp.Core;

public static class ThrowHelper
{
    public static void ThrowIfArgumentNull<T>(T obj) where T : class
    {
        if (obj is null) throw new ArgumentNullException(nameof(obj));
    }
}
