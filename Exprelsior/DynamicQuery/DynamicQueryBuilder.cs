namespace Exprelsior.DynamicQuery
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Exprelsior.DynamicQuery.Parser;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Shared.Extensions;

    /// <summary>
    ///     Provides static methods to dynamically build <see cref="Expression{TDelegate}" /> objects for data querying.
    /// </summary>
    internal static class DynamicQueryBuilder
    {
        /// <summary>
        ///     Parses the provided query as <see cref="string" /> to it's <see cref="Expression{TDelegate}" /> equivalent.
        /// </summary>
        /// <param name="query">
        ///     The query.
        /// </param>
        /// <typeparam name="T">
        ///     The type being queried.
        /// </typeparam>
        /// <returns>
        ///     The <see cref="Expression{T}" /> object representing the query.
        /// </returns>
        internal static Expression<Func<T, bool>> BuildQuery<T>(string query)
        {
            var queries = QueryParser.ParseQuery(query).ToArray();
            Expression<Func<T, bool>> expression = null;

            foreach (var queryInfo in queries)
            {
                if (queryInfo.Aggregate.HasValue)
                {
                    switch (queryInfo.Aggregate.Value)
                    {
                        case ExpressionAggregate.And:
                            expression = ExpressionBuilder.CreateBinary<T>(queryInfo.PropertyName, queryInfo.Value, queryInfo.Operator).And(expression);
                            break;
                        case ExpressionAggregate.Or:
                            expression = ExpressionBuilder.CreateBinary<T>(queryInfo.PropertyName, queryInfo.Value, queryInfo.Operator).Or(expression);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    expression = ExpressionBuilder.CreateBinary<T>(queryInfo.PropertyName, queryInfo.Value, queryInfo.Operator);
                }
            }

            return expression;
        }
    }
}