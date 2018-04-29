using System.Collections.Generic;

namespace PTrampert.AppArgs
{
    /// <summary>
    /// A cli parser that allows the usage of multiple parsers.
    /// </summary>
    public class MixedParser<T> : ICliParser<T> where T : new()
    {
        private IEnumerable<ICliParser<T>> _subParsers;

        /// <summary>
        /// Default constructor that initializes the MixedParser with an <c>ArgumentParser&lt;T&gt;</c> and an <c>OptionParser&lt;T&gt;</c>
        /// </summary>
        public MixedParser()
        {
            _subParsers = new ICliParser<T>[]
            {
                new ArgumentParser<T>(),
                new OptionParser<T>()
            };
        }

        /// <summary>
        /// Constructor that allows the passing in of a custom collection of sub parsers.
        /// </summary>
        /// <param name="subParsers">Consumer specified collection of sub parsers.</param>
        public MixedParser(IEnumerable<ICliParser<T>> subParsers)
        {
            _subParsers = subParsers;
        }

        /// <summary>
        /// Parses command line args array into a new instance of the generic type <c>T</c>
        /// </summary>
        /// <param name="args">Command line args array passed into Main</param>
        /// <returns>Populated instance of <c>T</c></returns>
        public T Parse(string[] args)
        {
            return Parse(args, new T());
        }

        /// <summary>
        /// Parses command line args array into an existing instance of the generic type <c>T</c>
        /// </summary>
        /// <param name="args">Command line args array passed into Main</param>
        /// <param name="obj">Instance to store parsed results into</param>
        /// <returns>Populated instance of <c>T</c></returns>
        public T Parse(string[] args, T obj)
        {
            var result = obj;
            foreach(var parser in _subParsers)
            {
                result = parser.Parse(args, result);
            }
            return result;
        }
    }
}