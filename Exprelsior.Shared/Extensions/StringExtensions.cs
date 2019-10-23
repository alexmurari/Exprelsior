namespace Exprelsior.Shared.Extensions
{
    using System;

    /// <summary>
    ///     Extensions for <see cref="string" /> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Throws an exception if the provided <see cref="string" /> is null or empty, otherwise returns the value.
        /// </summary>
        /// <param name="value">
        ///     The value to be checked.
        /// </param>
        /// <param name="argName">
        ///     The name of the argument to be checked.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The exception if the string is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     The exception if the string is empty.
        /// </exception>
        /// <returns>
        ///     The value of the argument.
        /// </returns>
        public static string ThrowIfNullOrEmpty(this string value, string argName)
        {
            if (value == null)
                throw new ArgumentNullException(argName);

            if (value.Length == 0)
                throw new ArgumentException("Argument must not be empty.", argName);

            return value;
        }

        /// <summary>
        ///     Throws an exception if the provided <see cref="string" /> is null, empty or only consists of whitespaces, otherwise
        ///     returns the value.
        /// </summary>
        /// <param name="value">
        ///     The value to be checked.
        /// </param>
        /// <param name="argName">
        ///     The name of the argument to be checked.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     The exception if the string is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     The exception if the string is empty or only consists of whitespaces.
        /// </exception>
        /// <returns>
        ///     The value of the argument.
        /// </returns>
        public static string ThrowIfNullOrWhitespace(this string value, string argName)
        {
            if (value == null)
                throw new ArgumentNullException(argName);

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Argument must not be empty or only contain whitespaces.", argName);

            return value;
        }
    }
}