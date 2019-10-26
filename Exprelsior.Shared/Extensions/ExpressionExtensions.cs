namespace Exprelsior.Shared.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
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
        ///     Converts the property accessor lambda expression to a textual representation of it's path. <br />
        ///     The textual representation consists of the properties that the expression access flattened and separated by a dot
        ///     character (".").
        /// </summary>
        /// <param name="expression">The property selector expression.</param>
        /// <returns>The extracted textual representation of the expression's path.</returns>
        public static string AsPath(this LambdaExpression expression)
        {
            if (expression == null)
                return null;

            TryParsePath(expression.Body, out var path);

            return path;
        }

        /// <summary>
        ///     Recursively parses an expression tree representing a property accessor to extract a textual representation of it's
        ///     path. <br />
        ///     The textual representation consists of the properties accessed by the expression tree flattened and separated by a
        ///     dot character (".").
        /// </summary>
        /// <param name="expression">The expression tree to parse.</param>
        /// <param name="path">The extracted textual representation of the expression's path.</param>
        /// <returns>True if the parse operation succeeds; otherwise, false.</returns>
        private static bool TryParsePath(Expression expression, out string path)
        {
            var noConvertExp = RemoveConvertOperations(expression);
            path = null;

            switch (noConvertExp)
            {
                case MemberExpression memberExpression:
                {
                    var currentPart = memberExpression.Member.Name;

                    if (!TryParsePath(memberExpression.Expression, out var parentPart))
                        return false;

                    path = string.IsNullOrEmpty(parentPart) ? currentPart : string.Concat(parentPart, ".", currentPart);
                    break;
                }

                case MethodCallExpression callExpression:
                    switch (callExpression.Method.Name)
                    {
                        case nameof(Queryable.Select) when callExpression.Arguments.Count == 2:
                        {
                            if (!TryParsePath(callExpression.Arguments[0], out var parentPart))
                                return false;

                            if (string.IsNullOrEmpty(parentPart))
                                return false;

                            if (!(callExpression.Arguments[1] is LambdaExpression subExpression))
                                return false;

                            if (!TryParsePath(subExpression.Body, out var currentPart))
                                return false;

                            if (string.IsNullOrEmpty(parentPart))
                                return false;

                            path = string.Concat(parentPart, ".", currentPart);
                            return true;
                        }

                        case nameof(Queryable.Where):
                            throw new NotSupportedException("Filtering an Include expression is not supported");
                        case nameof(Queryable.OrderBy):
                        case nameof(Queryable.OrderByDescending):
                            throw new NotSupportedException("Ordering an Include expression is not supported");
                        default:
                            return false;
                    }
            }

            return true;
        }

        /// <summary>
        ///     Removes all casts or conversion operations from the nodes of the provided <see cref="Expression" />.
        ///     Used to prevent type boxing when manipulating expression trees.
        /// </summary>
        /// <param name="expression">The expression to remove the conversion operations.</param>
        /// <returns>The expression without conversion or cast operations.</returns>
        private static Expression RemoveConvertOperations(Expression expression)
        {
            while (expression.NodeType == ExpressionType.Convert || expression.NodeType == ExpressionType.ConvertChecked)
                expression = ((UnaryExpression)expression).Operand;

            return expression;
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