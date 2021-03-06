﻿namespace Exprelsior.DynamicQuery.Parser
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Shared.Extensions;

    // ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local

    /// <summary>
    ///     Provides methods to parse the string representation of a query to a object representation.
    /// </summary>
    internal static class QueryParser
    {
        /// <summary>
        ///     The regular expression that matches the operators that compose queries.
        ///     Splits composite queries into single queries with their compose operators.
        /// </summary>
        /// <remarks>
        ///     - Result location on <see cref="Match"/> object: <see cref="Group"/> number 1.
        /// </remarks>
        private static readonly Regex QueryCompositionRegex = new Regex(@"(?<=[\'\]]\s*\)\s*)\+([a-zA-Z]{2,3})\+(?=\s*[A-Za-z]{2,3}\s*\(\s*\')", RegexOptions.Compiled);

        /// <summary>
        ///     The regular expression that matches the elements (operator, property and values) of a single query.
        /// </summary>
        /// <remarks>
        ///     Explanation:
        ///         - Operator part.
        ///             - <code>^[A-Za-z]{2,3}(?=(\s*\(\s*))</code>
        ///             - Matches the 2 or 3 first characters in the query string that represents the query operator.
        ///             - Result location on <see cref="Match"/> object: <see cref="Group"/> name: 'operator'.
        ///         - Property part.
        ///             - <code>(?&lt;=^[A-Za-z]{2,3}\s*\(\s*)'(?&lt;property&gt;(?!\.).[a-zA-Z][a-zA-Z0-9._]+)(?&lt;!\.)'\s*(?=(,\s*)))</code>
        ///             - Matches the name of property that the query targets.
        ///             - Result location on <see cref="Match"/> object: <see cref="Group"/> name: 'property'.
        ///         - Value part (when single value).
        ///             - <code>(?&lt;=(^[a-zA-Z]{2,3}\s*\(\s*\'[a-zA-Z]+\'\s*\,\s*))'(.+?)'\s*(?=\))</code>
        ///             - Matches the value of the query when it's a single value (non-array).
        ///             - Result location on <see cref="Match"/> object: <see cref="Group"/> name: 'value'.
        ///          - Value part (when array of values).
        ///             - <code>((?:\[\s*|\G(?!\A))('(.+?)')(?:(?:\s*,\s*(?=[^\]]*?\]))|\s*\]))</code>
        ///             - Matches the value of the query when it's a array of values.
        ///             - Result location on <see cref="Match"/> object: <see cref="Group"/> name: 'arrayValues'.
        /// </remarks>
        private static readonly Regex QueryElementsRegex =
            new Regex(
                @"((?<operator>[A-Za-z]{2,3})(?=(\s*\(\s*))|(?<=^[A-Za-z]{2,3}\s*\(\s*)'(?<property>(?!\.).[a-zA-Z0-9._]*)(?<!\.)'\s*(?=(,\s*)))|(?<=(^[a-zA-Z]{2,3}\s*\(\s*\'[a-zA-Z\.]+\'\s*\,\s*))'(?<value>.+?)'\s*(?=\))|((?:\[\s*|\G(?!\A))('(?<arrayValues>.+?)')(?:(?:\s*,\s*(?=[^\]]*?\]))|\s*\]))",
                RegexOptions.Compiled & RegexOptions.ExplicitCapture);

        /// <summary>
        ///     The query keywords.
        /// </summary>
        private static readonly Dictionary<string, object> QueryKeywords = new Dictionary<string, object>
        {
            {
                "$!NULL!$", null
            }
        };

        /// <summary>
        ///     Parses the provided <see cref="string"/> representing an query to a collection of <see cref="QueryInfo"/> objects representing the elements of the query.
        /// </summary>
        /// <param name="query">
        ///     The <see cref="string"/> with the query to be parsed.
        /// </param>
        /// <returns>
        ///     The collection of query elements.
        /// </returns>
        internal static IEnumerable<QueryInfo> ParseQuery(string query)
        {
            var operationsAndCompositions = QueryCompositionRegex.Split(query).ToArray();
            var operations = operationsAndCompositions.Where((t, i) => i % 2 == 0).ToArray();
            var compositions = operationsAndCompositions.Where((t, i) => i % 2 != 0).Select(GetExpressionCompose).ToArray();

            if (operations.Length - compositions.Length != 1)
                throw new InvalidOperationException("Malformed query: invalid number of operations and compositions.");

            for (var i = 0; i < operations.Length; i++)
            {
                var composition = i > 0 ? compositions[i - 1] : null;
                var operation = QueryElementsRegex.Matches(operations[i]).Cast<Match>().Select(t => t.Groups).ToArray();

                var queryOperator = GetExpressionOperator(operation.Select(t => t["operator"].Value).FirstOrDefault(t => !string.IsNullOrWhiteSpace(t)));
                var property = operation.Select(t => t["property"].Value).FirstOrDefault(t => !string.IsNullOrWhiteSpace(t));
                var value = (object)operation.Select(t => t["value"].Value).FirstOrDefault(t => !string.IsNullOrWhiteSpace(t))
                    ?? operation.Select(t => t["arrayValues"].Value).Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();

                ValidateQuery(composition, queryOperator, property, value, i > 0);

                yield return new QueryInfo(composition, queryOperator.GetValueOrDefault(), property, ReplaceKeywords(value));
            }

            void ValidateQuery(ExpressionCompose? composition, ExpressionOperator? @operator, string property, object value, bool compositionRequired)
            {
                if (compositionRequired && !composition.HasValue)
                    throw new InvalidOperationException("Malformed query: invalid composition operator.");

                if (!@operator.HasValue)
                    throw new InvalidOperationException("Malformed query: invalid comparison operator.");

                if (string.IsNullOrWhiteSpace(property))
                    throw new InvalidOperationException("Malformed query: invalid property name/path.");

                if (value == null || (value is string[] stringArray && stringArray.Length == 0))
                    throw new InvalidOperationException("Malformed query: invalid value.");
            }
        }

        /// <summary>
        ///     Replaces the keywords in the query values with their actual values.
        /// </summary>
        /// <param name="values">
        ///     The query values to be replaced.
        /// </param>
        /// <returns>
        ///     The object containing the values with the replaced keywords.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     Exception thrown when the provided value object is invalid.
        /// </exception>
        private static object ReplaceKeywords(object values)
        {
            switch (values)
            {
                case string[] stringArray:
                {
                    for (var i = 0; i < stringArray.Length; i++)
                    {
                        foreach (var queryKeyword in QueryKeywords.Where(queryKeyword => stringArray[i].IndexOf(queryKeyword.Key, StringComparison.OrdinalIgnoreCase) != -1))
                        {
                            stringArray.SetValue(queryKeyword.Value, i);
                        }
                    }

                    return stringArray;
                }

                case string stringValue:
                {
                    foreach (var queryKeyword in QueryKeywords.Where(queryKeyword => stringValue.IndexOf(queryKeyword.Key, StringComparison.OrdinalIgnoreCase) != -1))
                    {
                        stringValue = (string)queryKeyword.Value;
                    }

                    return stringValue;
                }

                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        ///     Gets the <see cref="ExpressionOperator" /> value identified by the provided <see cref="string" />.
        /// </summary>
        /// <remarks>
        ///     The <see cref="ExpressionOperator" /> is identified by the description set in the
        ///     <see cref="DescriptionAttribute" />.
        /// </remarks>
        /// <param name="operator">
        ///     The <see cref="string" /> representing the operator value.
        /// </param>
        /// <returns>
        ///     The <see cref="ExpressionOperator" /> identified by the provided <see cref="string" />.
        /// </returns>
        private static ExpressionOperator? GetExpressionOperator(string @operator)
        {
            return Enum.GetValues(typeof(ExpressionOperator))
                .Cast<ExpressionOperator?>()
                .FirstOrDefault(t => string.Equals(t.GetDescription(), @operator, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        ///     Gets the <see cref="ExpressionCompose" /> value identified by the provided <see cref="string" />.
        /// </summary>
        /// <remarks>
        ///     The <see cref="ExpressionCompose" /> is identified by the description set in the
        ///     <see cref="DescriptionAttribute" />.
        /// </remarks>
        /// <param name="operator">
        ///     The <see cref="string" /> representing the operator value.
        /// </param>
        /// <returns>
        ///     The <see cref="ExpressionCompose" /> identified by the provided <see cref="string" />.
        /// </returns>
        private static ExpressionCompose? GetExpressionCompose(string @operator)
        {
            return Enum.GetValues(typeof(ExpressionCompose))
                .Cast<ExpressionCompose?>()
                .FirstOrDefault(t => string.Equals(t.GetDescription(), @operator, StringComparison.OrdinalIgnoreCase));
        }
    }
}