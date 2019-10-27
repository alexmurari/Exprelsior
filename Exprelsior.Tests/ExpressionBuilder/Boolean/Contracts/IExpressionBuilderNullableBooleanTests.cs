namespace Exprelsior.ExpressionBuilder.Boolean.Contracts
{
    using Xunit;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Provides methods for unit testing the expression builder with focus on <see cref="bool"/>? values.
    /// </summary>
    public interface IExpressionBuilderNullableBooleanTests
    {
        // Boolean

        /// <summary>
        ///     Asserts that an <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="bool"/>? <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Contains_On_Value_Expression_Is_Generated_Correctly();

        // Boolean Array

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Array_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Array_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Array_Contains_Single_Value_Expression_Is_Generated_Correctly();

        // Boolean Collection

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Collection_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Collection_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Boolean_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly();
    }
}
