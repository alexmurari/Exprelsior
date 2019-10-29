namespace Exprelsior.Shared.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    /// <summary>
    ///     Provides extension methods to the <see cref="Expression" /> class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ExpressionExtensions
    {
        /// <summary>
        ///     Joins two binary lambda expressions using the 'And' conditional operator.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the predicate.
        /// </typeparam>
        /// <param name="left">
        ///     The left <see cref="Expression{TDelegate}" />.
        /// </param>
        /// <param name="right">
        ///     The right <see cref="Expression{TDelegate}" />.
        /// </param>
        /// <returns>
        ///     The resulting <see cref="Expression{TDelegate}" /> object that contains the joined
        ///     <see cref="Expression{TDelegate}" /> objects.
        /// </returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var leftExprBody = new RebindParameterVisitor(right.Parameters[0], left.Parameters[0]).Visit(right.Body);
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left.Body, leftExprBody ?? throw new InvalidOperationException()), left.Parameters);
        }

        /// <summary>
        ///     Joins two binary lambda expressions using the 'Or' conditional operator.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the predicate.
        /// </typeparam>
        /// <param name="left">
        ///     The first <see cref="Expression{TDelegate}" />.
        /// </param>
        /// <param name="right">
        ///     The second <see cref="Expression{TDelegate}" />.
        /// </param>
        /// <returns>
        ///     The resulting <see cref="Expression{TDelegate}" /> object that contains the joined
        ///     <see cref="Expression{TDelegate}" /> objects.
        /// </returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var leftExprBody = new RebindParameterVisitor(right.Parameters[0], left.Parameters[0]).Visit(right.Body);
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, leftExprBody ?? throw new InvalidOperationException()), left.Parameters);
        }

        /// <summary>
        ///     Visitor that rebinds the parameters of the visited <see cref="Expression" />.
        /// </summary>
        private class RebindParameterVisitor : ExpressionVisitor
        {
            /// <summary>
            ///     The new <see cref="ParameterExpression" />.
            /// </summary>
            private readonly ParameterExpression _newParameter;

            /// <summary>
            ///     The old <see cref="ParameterExpression" />.
            /// </summary>
            private readonly ParameterExpression _oldParameter;

            /// <summary>
            ///     Initializes a new instance of the <see cref="RebindParameterVisitor" /> class.
            /// </summary>
            /// <param name="oldParameter">
            ///     The old expression parameter.
            /// </param>
            /// <param name="newParameter">
            ///     The new expression parameter.
            /// </param>
            public RebindParameterVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
            {
                _oldParameter = oldParameter;
                _newParameter = newParameter;
            }

            /// <summary>
            ///     Visits the <see cref="ParameterExpression" />.
            /// </summary>
            /// <param name="node">The expression to visit.</param>
            /// <returns>The modified expression, if it or any sub-expression was modified; otherwise, returns the original expression.</returns>
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == _oldParameter ? _newParameter : base.VisitParameter(node);
            }
        }
    }
}