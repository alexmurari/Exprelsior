namespace Exprelsior.Tests.ExpressionBuilder.CompositeExpressions.Contracts
{
    using Exprelsior.ExpressionBuilder.Enums;
    using Xunit;

    /// <summary>
    ///     Provides methods for unit testing the expression composition.
    /// </summary>
    public interface ICompositeExpressionTests
    {
        /// <summary>
        ///     Asserts that expressions composed by the <see cref="ExpressionCompose.And"/> operator gives correct result. 
        /// </summary>
        [Fact]
        void Assert_And_Composition_Gives_Correct_Result();

        /// <summary>
        ///     Asserts that expressions composed by the <see cref="ExpressionCompose.Or"/> operator gives correct result. 
        /// </summary>
        [Fact]
        void Assert_Or_Composition_Gives_Correct_Result();
    }
}