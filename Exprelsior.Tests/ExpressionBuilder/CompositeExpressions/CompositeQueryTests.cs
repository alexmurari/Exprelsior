namespace Exprelsior.Tests.ExpressionBuilder.CompositeExpressions
{
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Shared.Extensions;
    using Exprelsior.Tests.ExpressionBuilder.CompositeExpressions.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    ///     Unit tests for the expression composition.
    /// </summary>
    public class CompositeQueryTests : ExpressionBuilderTestBase, ICompositeExpressionTests
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
        ///     Asserts that expressions composed by the <see cref="ExpressionCompose.And"/> operator gives correct result. 
        /// </summary>
        [Fact]
        public void Assert_And_Composition_Gives_Correct_Result()
        {
            // Arrange
            var randomHydra1 = Utilities.GetRandomItem(HydraArmy);
            var randomHydra2 = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.FullName), randomHydra1.FullName, ExpressionOperator.NotEqual).And(
                ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomHydra2.DateTime, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FullName != randomHydra1.FullName && t.DateTime != randomHydra2.DateTime);
            Assert.DoesNotContain(result, t => t.FullName == randomHydra1.FullName || t.DateTime == randomHydra2.DateTime);
        }

        /// <summary>
        ///     Asserts that expressions composed by the <see cref="ExpressionCompose.Or"/> operator gives correct result. 
        /// </summary>
        [Fact]
        public void Assert_Or_Composition_Gives_Correct_Result()
        {
            // Arrange
            var randomHydra1 = Utilities.GetRandomItem(HydraArmy);
            var randomHydra2 = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.FullName), randomHydra1.FullName, ExpressionOperator.Equal).Or(
                ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomHydra2.DateTime, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.FullName == randomHydra1.FullName || t.DateTime == randomHydra2.DateTime);
            Assert.DoesNotContain(result, t => t.FullName != randomHydra1.FullName && t.DateTime != randomHydra2.DateTime);
        }
    }
}
