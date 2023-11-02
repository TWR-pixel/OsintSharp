namespace OsintSharp.Core.Interfaces;

public interface IFactory<T> where T : class
{
    public T Create();
}
