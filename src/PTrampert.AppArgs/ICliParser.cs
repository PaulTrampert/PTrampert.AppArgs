namespace PTrampert.AppArgs
{
    public interface ICliParser<T> where T : new()
    {
        T Parse(string[] args);
        T Parse(string[] args, T obj);
    }
}