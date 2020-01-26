namespace Exprelsior.Tests.DynamicQuery
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Shared.Extensions;
    using Exprelsior.Tests.Utilities;
    using Xunit.Abstractions;

    /// <summary>
    ///     Base class for dynamic query unit tests.
    /// </summary>
    public abstract class DynamicQueryTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicQueryTestBase"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        protected DynamicQueryTestBase(ITestOutputHelper testOutput)
        {
            TestOutput = testOutput;
            HydraArmy = Utilities.GetFakeHydraCollection();
        }

        /// <summary>
        ///     Gets the test output helper.
        /// </summary>
        protected ITestOutputHelper TestOutput { get; }

        /// <summary>
        ///     Gets the hydra army.
        /// </summary>
        protected List<Hydra> HydraArmy { get; }

        /// <summary>
        ///     Builds the <see cref="string" /> representing the query from the provided parameters.
        /// </summary>
        /// <param name="propertyName">
        ///     The name property of the property to be compared by the query.
        /// </param>
        /// <param name="value">
        ///     The value to compare.
        /// </param>
        /// <param name="operator">
        ///     The operator of query.
        /// </param>
        /// <returns>
        ///     The <see cref="string" /> representing the query.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Exception thrown when the operator value is out of the valid range of values.
        /// </exception>
        protected static string BuildQueryText(string propertyName, object value, ExpressionOperator @operator)
        {
            if (!(value is string) && value is IEnumerable valueCollection)
            {
                var valueList = valueCollection.Cast<object>().ToList();

                IEnumerable<string> strCollection;

                if (valueList.OfType<DateTime?>().Any())
                {
                    strCollection = valueList.Cast<DateTime?>().Select(t => string.Concat("'", t?.ToString("O") ?? "$!NULL!$", "'"));
                }
                else if (valueList.OfType<float?>().Any())
                {
                    strCollection = valueList.Cast<float?>().Select(t => string.Concat("'", t?.ToString("R") ?? "$!NULL!$", "'"));
                }
                else
                {
                    strCollection = valueList.Select(t => string.Concat("'", t?.ToString() ?? "$!NULL!$", "'"));
                }

                value = string.Concat("[", string.Join(',', strCollection), "]");
            }
            else
            {
                if (value is DateTime dtValue)
                {
                    value = string.Concat("'", dtValue.ToString("O"), "'");
                }
                else if (value is float floatValue)
                {
                    value = string.Concat("'", floatValue.ToString("R"), "'");
                }
                else
                    value = string.Concat("'", value?.ToString() ?? "$!NULL!$", "'");
            }

            switch (@operator)
            {
                case ExpressionOperator.Equal:
                    return $"{ExpressionOperator.Equal.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.NotEqual:
                    return $"{ExpressionOperator.NotEqual.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.LessThan:
                    return $"{ExpressionOperator.LessThan.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.LessThanOrEqual:
                    return $"{ExpressionOperator.LessThanOrEqual.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.GreaterThan:
                    return $"{ExpressionOperator.GreaterThan.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.GreaterThanOrEqual:
                    return $"{ExpressionOperator.GreaterThanOrEqual.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.Contains:
                    return $"{ExpressionOperator.Contains.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.ContainsOnValue:
                    return $"{ExpressionOperator.ContainsOnValue.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.StartsWith:
                    return $"{ExpressionOperator.StartsWith.GetDescription()}('{propertyName}', {value})";
                case ExpressionOperator.EndsWith:
                    return $"{ExpressionOperator.EndsWith.GetDescription()}('{propertyName}', {value})";
                default:
                    throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null);
            }
        }

        /// <summary>
        ///     Composes two queries using the specified operator.
        /// </summary>
        /// <param name="leftQuery">
        ///     The left query.
        /// </param>
        /// <param name="rightQuery">
        ///     The right query.
        /// </param>
        /// <param name="composeOperator">
        ///     The compose operator.
        /// </param>
        /// <returns>
        ///     The <see cref="string"/> representing the composed query.
        /// </returns>
        protected string ComposeQuery(string leftQuery, string rightQuery, ExpressionCompose composeOperator)
        {
            return string.Concat(leftQuery, $"+{composeOperator.GetDescription()}+", rightQuery);
        }

        /// <summary>
        ///     Writes to the console an error message describing the operation that caused an assert operation to fail.
        /// </summary>
        /// <param name="expression">
        ///     The generated expression.
        /// </param>
        /// <param name="property">
        ///     The property accessed by the expression.
        /// </param>
        /// <param name="value">
        ///     The value used by the expression to compare.
        /// </param>
        protected void WriteErrorMessage(LambdaExpression expression, string property, object value)
        {
            if (!(value is string) && value is IEnumerable valueCollection)
            {
                var valueList = valueCollection.Cast<object>().ToList();
                value = valueList.Select(t => string.Concat("'", t?.ToString() ?? "$!NULL!$", "'"));
            }

            TestOutput.WriteLine($"Expression: {expression}");
            TestOutput.WriteLine($"Property: {property}");
            TestOutput.WriteLine($"Value: {value}");
        }
    }
}
