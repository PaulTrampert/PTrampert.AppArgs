namespace PTrampert.AppArgs
{
    /// <summary>
    /// Interface for a command line interface parser.
    /// </summary>
    public interface ICliParser<T> where T : new()
    {
        /// <summary>
        /// Parses command line args array into a new instance of the generic type <c>T</c>
        /// </summary>
        /// <param name="args">Command line args array passed into Main</param>
        /// <returns>Populated instance of <c>T</c></returns>
        T Parse(string[] args);

        /// <summary>
        /// Parses command line args array into an existing instance of the generic type <c>T</c>
        /// </summary>
        /// <param name="args">Command line args array passed into Main</param>
        /// <param name="obj">Instance to store parsed results into</param>
        /// <returns>Populated instance of <c>T</c></returns>
        T Parse(string[] args, T obj);
    }
}