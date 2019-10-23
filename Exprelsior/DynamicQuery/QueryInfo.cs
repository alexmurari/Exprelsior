namespace Exprelsior.DynamicQuery
{
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Shared.Extensions;

    /// <summary>
    ///     Represents an query.
    /// </summary>
    public class QueryInfo
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryInfo"/> class.
        /// </summary>
        /// <param name="aggregate">
        ///     The aggregate operator.
        /// </param>
        /// <param name="operator">
        ///     The comparison operator.
        /// </param>
        /// <param name="propertyName">
        ///     The property name.
        /// </param>
        /// <param name="value">
        ///     The value to be compared.
        /// </param>
        public QueryInfo(ExpressionAggregate? aggregate, ExpressionOperator @operator, string propertyName, object value)
        {
            Aggregate = aggregate;
            Operator = @operator;
            PropertyName = propertyName.ThrowIfNullOrWhitespace(nameof(propertyName));
            Value = value;
        }

        /// <summary>
        ///     Gets the aggregate operator.
        /// </summary>
        public ExpressionAggregate? Aggregate { get; }

        /// <summary>
        ///     Gets the comparison operator.
        /// </summary>
        public ExpressionOperator Operator { get; }

        /// <summary>
        ///     Gets the property name.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        public object Value { get; }
    }
}