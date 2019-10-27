namespace Exprelsior.ExpressionBuilder.String.Contracts
{
    using Xunit;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Provides methods for unit testing the expression builder with focus on <see cref="string"/> values.
    /// </summary>
    public interface IExpressionBuilderStringTests
    {
        // String

        /// <summary>
        ///     Asserts that an <see cref="string"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="string"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="string"/> <see cref="ExpressionOperator.StartsWith"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Starts_With_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="string"/> <see cref="ExpressionOperator.EndsWith"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Ends_With_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="string"/> <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Contains_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an <see cref="string"/> <see cref="ExpressionOperator.ContainsOnValue"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Contains_On_Value_Expression_Is_Generated_Correctly();

        // String Array

        /// <summary>
        ///     Asserts that an array of <see cref="string"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Array_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="string"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Array_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="string"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="string"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an array of <see cref="string"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Array_Contains_Single_Value_Expression_Is_Generated_Correctly();

        // String Collection

        /// <summary>
        ///     Asserts that an collection of <see cref="string"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Collection_Equality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="string"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Collection_Inequality_Expression_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="string"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="string"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly();

        /// <summary>
        ///     Asserts that an collection of <see cref="string"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        void Assert_String_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly();
    }
}
