namespace Exprelsior.Tests.ExpressionBuilder.Char.Contracts
{
    using Exprelsior.ExpressionBuilder.Enums;
    using Xunit;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Provides methods for unit testing the expression builder with focus on <see cref="char"/>? values.
    /// </summary>
    public interface IExpressionBuilderNullableCharTests
    {
        // Char

        /// <summary>
        ///     Asserts that an <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="char"/>? <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Contains_On_Value_Expression_Is_Generated_Correctly();

        // Char Array

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Array_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Array_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Array_Contains_Single_Value_Expression_Is_Generated_Correctly();

        // Char Collection

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Collection_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Collection_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_Nullable_Char_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly();
    }
}
