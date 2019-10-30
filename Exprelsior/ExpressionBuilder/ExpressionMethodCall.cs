namespace Exprelsior.ExpressionBuilder
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///     Provides static methods to build predefined method call expressions.
    /// </summary>
    internal static class ExpressionMethodCallBuilder
    {
        /// <summary>
        ///     Builds an method call expression that represents a call to the '<see cref="Enumerable.Contains{T}(IEnumerable{T}, T)" />' method.
        /// </summary>
        /// <param name="property">The expression representing the instance for the instance method call.</param>
        /// <param name="value">The expression representing the value to be passed as the method argument.</param>
        /// <returns>The expression representing the call to the method.</returns>
        internal static MethodCallExpression BuildGenericCollectionContainsMethodCall(Expression property, Expression value)
        {
            return BuildEnumerableContainsMethodCall(property, value, null);
        }

        /// <summary>
        ///     Builds an method call expression that represents a call to the '
        ///     <see cref="Enumerable.Contains{T}(IEnumerable{T}, T, IEqualityComparer{T})" />' method. <br />
        ///     An <see cref="IEqualityComparer{T}" /> that performs an case-insensitive ordinal string comparison is passed as
        ///     argument to the method.
        /// </summary>
        /// <param name="property">The expression representing the instance for the instance method call.</param>
        /// <param name="value">The expression representing the value to be passed as the method argument.</param>
        /// <returns>The call to the method.</returns>
        internal static MethodCallExpression BuildGenericStringCollectionContainsMethodCall(Expression property, Expression value)
        {
            return BuildEnumerableContainsMethodCall(property, value, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Builds an method call expression that represents a call to the '<see cref="IList.Contains" />' method.
        /// </summary>
        /// <param name="property">The expression representing the instance for the instance method call.</param>
        /// <param name="value">The expression representing the value to be passed as the method argument.</param>
        /// <returns>The expression representing the call to the method.</returns>
        internal static MethodCallExpression BuildIListContainsMethodCall(Expression property, Expression value)
        {
            var argumentTypes = new[]
            {
                typeof(object)
            };

            return Expression.Call(property, typeof(IList).GetMethod(nameof(IList.Contains), argumentTypes) ?? throw new InvalidOperationException(), value);
        }

        /// <summary>
        ///     Builds an method call expression that represents a call to the '<see cref="string.Contains(string)" />' method.
        /// </summary>
        /// <param name="property">The expression representing the instance for the instance method call.</param>
        /// <param name="value">The expression representing the value to be passed as the method argument.</param>
        /// <returns>The call to the method.</returns>
        internal static MethodCallExpression BuildStringContainsMethodCall(Expression property, Expression value)
        {
            var argumentTypes = new[]
            {
                typeof(string)
            };

            return Expression.Call(property, typeof(string).GetMethod(nameof(string.Contains), argumentTypes) ?? throw new InvalidOperationException(), value);
        }

        /// <summary>
        ///     Builds an method call expression that represents a call to the '<see cref="string.EndsWith(string)" />' method.
        /// </summary>
        /// <param name="property">The expression representing the instance for the instance method call.</param>
        /// <param name="value">The expression representing the value to be passed as the method argument.</param>
        /// <returns>The expression representing the call to the method.</returns>
        internal static MethodCallExpression BuildStringEndsWithMethodCall(Expression property, Expression value)
        {
            var argumentTypes = new[]
            {
                typeof(string)
            };

            return Expression.Call(property, typeof(string).GetMethod(nameof(string.EndsWith), argumentTypes) ?? throw new InvalidOperationException(), value);
        }

        /// <summary>
        ///     Builds an method call expression that represents a call to the '<see cref="string.StartsWith(string)" />' method.
        /// </summary>
        /// <param name="property">The expression representing the instance for the instance method call.</param>
        /// <param name="value">The expression representing the value to be passed as the method argument.</param>
        /// <returns>The expression representing the call to the method.</returns>
        internal static MethodCallExpression BuildStringStartsWithMethodCall(Expression property, Expression value)
        {
            var argumentTypes = new[]
            {
                typeof(string)
            };

            return Expression.Call(property, typeof(string).GetMethod(nameof(string.StartsWith), argumentTypes) ?? throw new InvalidOperationException(), value);
        }

        /// <summary>
        ///     Builds an method call expression that represents a call to the '<see cref="Enumerable.SequenceEqual{T}(IEnumerable{T}, IEnumerable{T})" />' method.
        /// </summary>
        /// <param name="property">
        ///     The expression representing the instance for the instance method call.
        /// </param>
        /// <param name="value">
        ///     The expression representing the value to be passed as the method argument.
        /// </param>
        /// <param name="negate">
        ///     Informs whether the comparison should be negated (not equal).
        /// </param>
        /// <returns>
        ///     The call to the method.
        /// </returns>
        internal static Expression BuildEnumerableSequenceEqualMethodCall(Expression property, Expression value, bool negate = false)
        {
            var genericType = property.Type.IsArray ? property.Type.GetElementType() : property.Type.GetGenericArguments()[0];

            var containsMethod = typeof(Enumerable).GetMethods()
                .Single(x => x.Name == nameof(Enumerable.SequenceEqual) && x.GetParameters().Length == 2)
                .MakeGenericMethod(genericType);

            var methodCall = Expression.Call(containsMethod, property, value);
            return negate ? (Expression)Expression.Not(methodCall) : methodCall;
        }

        /// <summary>
        ///     Builds an method call expression that represents a call to the '<see cref="Enumerable.Contains{T}(IEnumerable{T}, T, IEqualityComparer{T})" />' method.
        /// </summary>
        /// <param name="property">
        ///     The expression representing the instance for the instance method call.
        /// </param>
        /// <param name="value">
        ///     The expression representing the value to be passed as the method argument.
        /// </param>
        /// <param name="equalityComparer">
        ///     The equality comparer to be used by the method.
        /// </param>
        /// <returns>
        ///     The call to the method.
        /// </returns>
        private static MethodCallExpression BuildEnumerableContainsMethodCall(Expression property, Expression value, IEqualityComparer equalityComparer)
        {
            var genericType = property.Type.IsArray ? property.Type.GetElementType() : property.Type.GetGenericArguments()[0];

            var containsMethod = typeof(Enumerable).GetMethods()
                .Single(x => x.Name == nameof(Enumerable.Contains) && x.GetParameters().Length == (equalityComparer == null ? 2 : 3))
                .MakeGenericMethod(genericType);

            return equalityComparer == null
                ? Expression.Call(containsMethod, property, value)
                : Expression.Call(containsMethod, property, value, Expression.Constant(equalityComparer));
        }
    }
}