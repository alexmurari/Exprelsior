namespace Exprelsior.ExpressionBuilder.Enums
{
    using System.ComponentModel;

    /// <summary>
    ///     Expression comparison operators.
    /// </summary>
    public enum ExpressionOperator
    {
        /// <summary>
        ///     The equality comparison.
        /// </summary>
        [Description("EQ")]
        Equal,

        /// <summary>
        ///     The inequality comparison.
        /// </summary>
        [Description("NE")]
        NotEqual,

        /// <summary>
        ///     The "less than" numeric comparison.
        /// </summary>
        [Description("LT")]
        LessThan,

        /// <summary>
        ///     The "less than or equal" numeric comparison.
        /// </summary>
        [Description("LTE")]
        LessThanOrEqual,

        /// <summary>
        ///     The "greater than" numeric comparison.
        /// </summary>
        [Description("GT")]
        GreaterThan,

        /// <summary>
        ///     The "greater than or equal" numeric comparison.
        /// </summary>
        [Description("GTE")]
        GreaterThanOrEqual,

        /// <summary>
        ///     The "contains" comparison.
        /// </summary>
        [Description("CT")]
        Contains,

        /// <summary>
        ///     The "contains" comparison applied on the value of an expression.
        /// </summary>
        [Description("COV")]
        ContainsOnValue,

        /// <summary>
        ///     The "starts with" comparison.
        /// </summary>
        [Description("SW")]
        StartsWith,

        /// <summary>
        ///     The "ends with" comparison.
        /// </summary>
        [Description("EW")]
        EndsWith
    }

    /// <summary>
    ///     Expression aggregate operators.
    /// </summary>
    public enum ExpressionAggregate
    {
        /// <summary>
        ///     The "and" aggregate.
        /// </summary>
        [Description("AND")]
        And,

        /// <summary>
        ///     The "or" aggregate.
        /// </summary>
        [Description("OR")]
        Or
    }
}