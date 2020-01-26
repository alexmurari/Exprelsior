namespace Exprelsior.Tests.DynamicQuery.CompositeQueries
{
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.DynamicQuery.CompositeQueries.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    ///     Unit tests for the query composition.
    /// </summary>
    public class CompositeQueryTests : DynamicQueryTestBase, ICompositeQueryTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CompositeQueryTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The test output.
        /// </param>
        public CompositeQueryTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        /// <summary>
        ///     Asserts that queries composed by the <see cref="ExpressionCompose.And"/> operator gives correct result. 
        /// </summary>
        [Fact]
        public void Assert_And_Composition_Gives_Correct_Result()
        {
            // Arrange
            var randomHydra1 = Utilities.GetRandomItem(HydraArmy);
            var randomHydra2 = Utilities.GetRandomItem(HydraArmy);
            var queryText = ComposeQuery(BuildQueryText(nameof(Hydra.FullName), randomHydra1.FullName, ExpressionOperator.NotEqual), BuildQueryText(nameof(Hydra.DateTime), randomHydra2.DateTime, ExpressionOperator.NotEqual), ExpressionCompose.And);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(queryText);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FullName != randomHydra1.FullName && t.DateTime != randomHydra2.DateTime);
            Assert.DoesNotContain(result, t => t.FullName == randomHydra1.FullName || t.DateTime == randomHydra2.DateTime);
        }

        /// <summary>
        ///     Asserts that queries composed by the <see cref="ExpressionCompose.Or"/> operator gives correct result. 
        /// </summary>
        [Fact]
        public void Assert_Or_Composition_Gives_Correct_Result()
        {
            // Arrange
            var randomHydra1 = Utilities.GetRandomItem(HydraArmy);
            var randomHydra2 = Utilities.GetRandomItem(HydraArmy);
            var queryText = ComposeQuery(BuildQueryText(nameof(Hydra.FullName), randomHydra1.FullName, ExpressionOperator.Equal), BuildQueryText(nameof(Hydra.DateTime), randomHydra2.DateTime, ExpressionOperator.Equal), ExpressionCompose.Or);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(queryText);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FullName == randomHydra1.FullName || t.DateTime == randomHydra2.DateTime);
            Assert.DoesNotContain(result, t => t.FullName != randomHydra1.FullName && t.DateTime != randomHydra2.DateTime);
        }
    }
}
