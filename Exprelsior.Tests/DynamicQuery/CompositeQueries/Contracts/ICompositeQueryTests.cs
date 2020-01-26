namespace Exprelsior.Tests.DynamicQuery.CompositeQueries.Contracts
{
    using Exprelsior.ExpressionBuilder.Enums;
    using Xunit;

    /// <summary>
    ///     Provides methods for unit testing the query composition.
    /// </summary>
    public interface ICompositeQueryTests
    {
        /// <summary>
        ///     Asserts that queries composed by the <see cref="ExpressionCompose.And"/> operator gives correct result. 
        /// </summary>
        [Fact]
        void Assert_And_Composition_Gives_Correct_Result();

        /// <summary>
        ///     Asserts that queries composed by the <see cref="ExpressionCompose.Or"/> operator gives correct result. 
        /// </summary>
        [Fact]
        void Assert_Or_Composition_Gives_Correct_Result();
    }
}