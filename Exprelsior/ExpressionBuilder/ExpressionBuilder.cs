namespace Exprelsior.ExpressionBuilder
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.ExpressionBuilder.Parser;
    using Exprelsior.Shared.Extensions;

    /// <summary>
    ///     Provides static methods to create <see cref="Expression" /> instances.
    /// </summary>
    public static class ExpressionBuilder
    {
        /// <summary>
        ///     Creates a lambda expression that represents an accessor to a property from an object of type
        ///     <typeparamref name="T" />.
        /// </summary>
        /// <param name="propertyNameOrPath">
        ///     The name or the path to the property to be accessed composed of simple dot-separated property access expressions.
        /// </param>
        /// <typeparam name="T">
        ///     The type that contains the property to be accessed.
        /// </typeparam>
        /// <typeparam name="TResult">
        ///     The type of the accessed property used as the delegate return type.
        /// </typeparam>
        /// <returns>
        ///     The built <see cref="Expression{TDelegate}" /> instance representing the property accessor.
        /// </returns>
        public static Expression<Func<T, TResult>> CreateAccessorExpression<T, TResult>(string propertyNameOrPath)
        {
            propertyNameOrPath.ThrowIfNullOrWhitespace(nameof(propertyNameOrPath));

            var (parameter, accessor) = BuildAccessor<T>(propertyNameOrPath);
            var conversion = Expression.Convert(accessor, typeof(TResult));

            return Expression.Lambda<Func<T, TResult>>(conversion, parameter);
        }

        /// <summary>
        ///     Creates a binary lambda expression that compares the value of an property from an object of
        ///     type <typeparamref name="T" /> with the provided value using the specified comparison operator.
        /// </summary>
        /// <typeparam name="T">
        ///     The type that contains the property to be compared.
        /// </typeparam>
        /// <param name="propertyNameOrPath">
        ///     The name or the path to access the property to be compared composed of simple dot-separated property access
        ///     expressions.
        /// </param>
        /// <param name="value">
        ///     The value to compare the property.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <returns>The built <see cref="Expression{TDelegate}" /> instance representing the binary operation.</returns>
        public static Expression<Func<T, bool>> CreateBinaryExpression<T>(string propertyNameOrPath, object value, ExpressionOperator @operator)
        {
            return BuildBinaryExpression<T>(propertyNameOrPath, value, @operator);
        }

        /// <summary>
        ///     Creates a binary lambda expression that compares the value of an property from an object of
        ///     type <typeparamref name="T" /> with the provided value using the specified comparison operator.
        /// </summary>
        /// <typeparam name="T">
        ///     The type that contains the property to be compared.
        /// </typeparam>
        /// <param name="propertyInfo">
        ///     The metadata of the property to be compared.
        /// </param>
        /// <param name="value">
        ///     The value to compare the property.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <returns>The built <see cref="Expression{TDelegate}" /> instance representing the binary operation.</returns>
        public static Expression<Func<T, bool>> CreateBinaryExpression<T>(PropertyInfo propertyInfo, object value, ExpressionOperator @operator)
        {
            return BuildBinaryExpression<T>(propertyInfo.Name, value, @operator);
        }

        /// <summary>
        ///     Creates a <see cref="MemberExpression" /> that represents accessing a property from an object of type
        ///     <typeparamref name="T" />.
        /// </summary>
        /// <param name="propertyNameOrPath">
        ///     The name or the path to the property to be accessed composed of simple dot-separated property access expressions.
        /// </param>
        /// <typeparam name="T">
        ///     The type that contains the property to be accessed.
        /// </typeparam>
        /// <returns>
        ///     The <see cref="ParameterExpression" /> representing a parameter of the type that contains
        ///     the accessed property and the <see cref="MemberExpression" /> representing the accessor to the property.
        /// </returns>
        private static (ParameterExpression Parameter, MemberExpression Accessor) BuildAccessor<T>(string propertyNameOrPath)
        {
            propertyNameOrPath.ThrowIfNullOrWhitespace(nameof(propertyNameOrPath));

            var param = Expression.Parameter(typeof(T));
            var accessor = propertyNameOrPath.Split('.').Aggregate<string, MemberExpression>(
                null,
                (current, property) => Expression.Property((Expression)current ?? param, property.Trim()));

            return (param, accessor);
        }

        /// <summary>
        ///     Creates a binary lambda expression that compares the value of an property from an object of
        ///     type <typeparamref name="T" /> with the provided value using the specified comparison operator.
        /// </summary>
        /// <typeparam name="T">
        ///     The type with the property to be compared.
        /// </typeparam>
        /// <param name="propertyNameOrPath">
        ///     The name or the path to access the property to be compared composed of simple dot-separated property access
        ///     expressions.
        /// </param>
        /// <param name="value">
        ///     The value to compare the property.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <returns>The built <see cref="Expression{TDelegate}" /> instance representing the binary operation.</returns>
        private static Expression<Func<T, bool>> BuildBinaryExpression<T>(string propertyNameOrPath, object value, ExpressionOperator @operator)
        {
            propertyNameOrPath.ThrowIfNullOrWhitespace(nameof(propertyNameOrPath));

            var (parameter, property) = BuildAccessor<T>(propertyNameOrPath);
            var (leftExpression, rightExpression) = BuildBinaryExpressionParameters(property, value, @operator);

            Expression body;

            switch (@operator)
            {
                case ExpressionOperator.LessThan:
                    body = Expression.LessThan(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.GreaterThan:
                    body = Expression.GreaterThan(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.LessThanOrEqual:
                    body = Expression.LessThanOrEqual(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.GreaterThanOrEqual:
                    body = Expression.GreaterThanOrEqual(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.Equal when property.Type.IsGenericCollection():
                    body = ExpressionMethodCallBuilder.BuildEnumerableSequenceEqualMethodCall(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.NotEqual when property.Type.IsGenericCollection():
                    body = ExpressionMethodCallBuilder.BuildEnumerableSequenceEqualMethodCall(leftExpression, rightExpression, true);
                    break;
                case ExpressionOperator.Equal:
                    body = Expression.Equal(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.NotEqual:
                    body = Expression.NotEqual(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.Contains when property.Type.IsString():
                    body = ExpressionMethodCallBuilder.BuildStringContainsMethodCall(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.Contains when property.Type.IsGenericCollection(typeof(string)):
                case ExpressionOperator.ContainsOnValue when leftExpression.Type.IsGenericCollection(typeof(string)):
                    body = ExpressionMethodCallBuilder.BuildGenericStringCollectionContainsMethodCall(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.Contains when property.Type.IsGenericCollection():
                case ExpressionOperator.ContainsOnValue when leftExpression.Type.IsGenericCollection():
                    body = ExpressionMethodCallBuilder.BuildGenericCollectionContainsMethodCall(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.Contains when property.Type.IsNonGenericIList():
                case ExpressionOperator.ContainsOnValue when leftExpression.Type.IsNonGenericIList():
                    body = ExpressionMethodCallBuilder.BuildIListContainsMethodCall(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.StartsWith:
                    body = ExpressionMethodCallBuilder.BuildStringStartsWithMethodCall(leftExpression, rightExpression);
                    break;
                case ExpressionOperator.EndsWith:
                    body = ExpressionMethodCallBuilder.BuildStringEndsWithMethodCall(leftExpression, rightExpression);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        /// <summary>
        ///     Creates the <see cref="Expression" /> parameters that can be used to build <see cref="BinaryExpression" /> objects.
        /// </summary>
        /// <param name="property">
        ///     The expression representing the property accessor.
        /// </param>
        /// <param name="value">
        ///     The value to compare the property.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <returns>
        ///     The expression parameters to build <see cref="BinaryExpression" /> objects.
        /// </returns>
        private static (Expression leftExpression, Expression rightExpression) BuildBinaryExpressionParameters(Expression property, object value, ExpressionOperator @operator)
        {
            var propertyType = @operator != ExpressionOperator.ContainsOnValue ? property.Type : value.GetType();

            ValidateBinaryExpressionParameters(propertyType, @operator);

            var (leftExpression, rightExpression) = ExpressionTypeParser.BuildAccessorAndValue(property, value, @operator);

            return @operator == ExpressionOperator.ContainsOnValue ? (rightExpression, leftExpression) : (leftExpression, rightExpression);
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type accessed by the expression.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        private static void ValidateBinaryExpressionParameters(Type propertyType, ExpressionOperator @operator)
        {
            var isCollection = propertyType.IsCollection();

            if (isCollection)
                ValidateBinaryExpressionParametersForCollection(propertyType, @operator);
            else if (propertyType.IsString())
                ValidateBinaryExpressionParametersForString(propertyType, @operator);
            else if (propertyType.IsChar())
                ValidateBinaryExpressionParametersForChar(propertyType, @operator);
            else if (propertyType.IsNumeric())
                ValidateBinaryExpressionParametersForNumeric(propertyType, @operator);
            else if (propertyType.IsBoolean())
                ValidateBinaryExpressionParametersForBoolean(propertyType, @operator);
            else if (propertyType.IsDateTime())
                ValidateBinaryExpressionParametersForDateTime(propertyType, @operator);
            else if (propertyType.IsGuid())
                ValidateBinaryExpressionParametersForGuid(propertyType, @operator);
            else
                ValidateBinaryExpressionParametersForObject(propertyType, @operator);
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions for collection type comparisons.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Exception thrown when the comparison operator value is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the comparison operator value is out of range.
        /// </exception>
        private static void ValidateBinaryExpressionParametersForCollection(Type propertyType, ExpressionOperator @operator)
        {
            switch (@operator)
            {
                case ExpressionOperator.Contains:
                case ExpressionOperator.ContainsOnValue when propertyType.IsCollection():
                case ExpressionOperator.Equal when propertyType.IsCollection():
                case ExpressionOperator.NotEqual when propertyType.IsCollection():
                    break;
                case ExpressionOperator.LessThan:
                case ExpressionOperator.LessThanOrEqual:
                case ExpressionOperator.GreaterThan:
                case ExpressionOperator.GreaterThanOrEqual:
                case ExpressionOperator.StartsWith:
                case ExpressionOperator.EndsWith:
                    throw new ArgumentException($"Operator {@operator} isn't valid for the type {propertyType.Name}.", nameof(@operator));
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions for <see cref="DateTime" /> type comparisons.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Exception thrown when the comparison operator value is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the comparison operator value is out of range.
        /// </exception>
        private static void ValidateBinaryExpressionParametersForDateTime(MemberInfo propertyType, ExpressionOperator @operator)
        {
            switch (@operator)
            {
                case ExpressionOperator.Equal:
                case ExpressionOperator.NotEqual:
                case ExpressionOperator.LessThan:
                case ExpressionOperator.LessThanOrEqual:
                case ExpressionOperator.GreaterThan:
                case ExpressionOperator.GreaterThanOrEqual:
                    break;
                case ExpressionOperator.Contains:
                case ExpressionOperator.ContainsOnValue:
                case ExpressionOperator.StartsWith:
                case ExpressionOperator.EndsWith:
                    throw new ArgumentException($"Operator {@operator} isn't valid for the type {propertyType.Name}.", nameof(@operator));
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions for <see cref="char" /> type comparisons.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Exception thrown when the comparison operator value is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the comparison operator value is out of range.
        /// </exception>
        private static void ValidateBinaryExpressionParametersForChar(MemberInfo propertyType, ExpressionOperator @operator)
        {
            switch (@operator)
            {
                case ExpressionOperator.Equal:
                case ExpressionOperator.NotEqual:
                    break;
                case ExpressionOperator.LessThan:
                case ExpressionOperator.LessThanOrEqual:
                case ExpressionOperator.GreaterThan:
                case ExpressionOperator.GreaterThanOrEqual:
                case ExpressionOperator.Contains:
                case ExpressionOperator.ContainsOnValue:
                case ExpressionOperator.StartsWith:
                case ExpressionOperator.EndsWith:
                    throw new ArgumentException($"Operator {@operator} isn't valid for the type {propertyType.Name}.", nameof(@operator));
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions for <see cref="bool" /> type comparisons.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Exception thrown when the comparison operator value is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the comparison operator value is out of range.
        /// </exception>
        private static void ValidateBinaryExpressionParametersForBoolean(MemberInfo propertyType, ExpressionOperator @operator)
        {
            switch (@operator)
            {
                case ExpressionOperator.Equal:
                case ExpressionOperator.NotEqual:
                    break;
                case ExpressionOperator.LessThan:
                case ExpressionOperator.LessThanOrEqual:
                case ExpressionOperator.GreaterThan:
                case ExpressionOperator.GreaterThanOrEqual:
                case ExpressionOperator.Contains:
                case ExpressionOperator.ContainsOnValue:
                case ExpressionOperator.StartsWith:
                case ExpressionOperator.EndsWith:
                    throw new ArgumentException($"Operator {@operator} isn't valid for the type {propertyType.Name}.", nameof(@operator));
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions for <see cref="Guid" /> type comparisons.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Exception thrown when the comparison operator value is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the comparison operator value is out of range.
        /// </exception>
        private static void ValidateBinaryExpressionParametersForGuid(MemberInfo propertyType, ExpressionOperator @operator)
        {
            switch (@operator)
            {
                case ExpressionOperator.Equal:
                case ExpressionOperator.NotEqual:
                    break;
                case ExpressionOperator.LessThan:
                case ExpressionOperator.LessThanOrEqual:
                case ExpressionOperator.GreaterThan:
                case ExpressionOperator.GreaterThanOrEqual:
                case ExpressionOperator.Contains:
                case ExpressionOperator.ContainsOnValue:
                case ExpressionOperator.StartsWith:
                case ExpressionOperator.EndsWith:
                    throw new ArgumentException($"Operator {@operator} isn't valid for the type {propertyType.Name}.", nameof(@operator));
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions for numeric type comparisons.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Exception thrown when the comparison operator value is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the comparison operator value is out of range.
        /// </exception>
        private static void ValidateBinaryExpressionParametersForNumeric(MemberInfo propertyType, ExpressionOperator @operator)
        {
            switch (@operator)
            {
                case ExpressionOperator.Equal:
                case ExpressionOperator.NotEqual:
                case ExpressionOperator.LessThan:
                case ExpressionOperator.LessThanOrEqual:
                case ExpressionOperator.GreaterThan:
                case ExpressionOperator.GreaterThanOrEqual:
                    break;
                case ExpressionOperator.Contains:
                case ExpressionOperator.ContainsOnValue:
                case ExpressionOperator.StartsWith:
                case ExpressionOperator.EndsWith:
                    throw new ArgumentException($"Operator {@operator} isn't valid for the type {propertyType.Name}.", nameof(@operator));
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions for <see cref="object" /> type comparisons.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Exception thrown when the comparison operator value is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the comparison operator value is out of range.
        /// </exception>
        private static void ValidateBinaryExpressionParametersForObject(MemberInfo propertyType, ExpressionOperator @operator)
        {
            switch (@operator)
            {
                case ExpressionOperator.Equal:
                case ExpressionOperator.NotEqual:
                    break;
                case ExpressionOperator.LessThan:
                case ExpressionOperator.LessThanOrEqual:
                case ExpressionOperator.GreaterThan:
                case ExpressionOperator.GreaterThanOrEqual:
                case ExpressionOperator.Contains:
                case ExpressionOperator.ContainsOnValue:
                case ExpressionOperator.StartsWith:
                case ExpressionOperator.EndsWith:
                    throw new ArgumentException($"Operator {@operator} isn't valid for the type {propertyType.Name}.", nameof(@operator));
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }

        /// <summary>
        ///     Validates the provided parameters for building binary expressions for <see cref="string" /> type comparisons.
        /// </summary>
        /// <param name="propertyType">
        ///     The property type.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     Exception thrown when the comparison operator value is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the comparison operator value is out of range.
        /// </exception>
        private static void ValidateBinaryExpressionParametersForString(MemberInfo propertyType, ExpressionOperator @operator)
        {
            switch (@operator)
            {
                case ExpressionOperator.Equal:
                case ExpressionOperator.NotEqual:
                case ExpressionOperator.Contains:
                case ExpressionOperator.StartsWith:
                case ExpressionOperator.EndsWith:
                    break;
                case ExpressionOperator.LessThan:
                case ExpressionOperator.LessThanOrEqual:
                case ExpressionOperator.GreaterThan:
                case ExpressionOperator.GreaterThanOrEqual:
                case ExpressionOperator.ContainsOnValue:
                    throw new ArgumentException($"Operator {@operator} isn't valid for the type {propertyType.Name}.", nameof(@operator));
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }
    }
}