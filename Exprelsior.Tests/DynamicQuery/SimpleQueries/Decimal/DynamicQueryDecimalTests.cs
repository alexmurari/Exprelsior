namespace Exprelsior.Tests.DynamicQuery.SimpleQueries.Decimal
{
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.DynamicQuery.SimpleQueries.Decimal.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="decimal"/> type queries.
    /// </summary>
    public class DynamicQueryDecimalTests : DynamicQueryTestBase, IDynamicQueryDecimalTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicQueryDecimalTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public DynamicQueryDecimalTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Decimal

        /// <summary>
        ///     Asserts that an <see cref="decimal"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Decimal), randomHydra.Decimal, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Decimal == randomHydra.Decimal);
            Assert.DoesNotContain(result, t => t.Decimal != randomHydra.Decimal);
        }

        /// <summary>
        ///     Asserts that an <see cref="decimal"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Decimal), randomHydra.Decimal, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Decimal != randomHydra.Decimal);
            Assert.DoesNotContain(result, t => t.Decimal == randomHydra.Decimal);
        }

        /// <summary>
        ///     Asserts that an <see cref="decimal"/> <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Less_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Decimal), randomHydra.Decimal, ExpressionOperator.LessThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Decimal < randomHydra.Decimal);
            Assert.DoesNotContain(result, t => t.Decimal >= randomHydra.Decimal);
        }

        /// <summary>
        ///     Asserts that an <see cref="decimal"/> <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Less_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Decimal), randomHydra.Decimal, ExpressionOperator.LessThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Decimal <= randomHydra.Decimal);
            Assert.DoesNotContain(result, t => t.Decimal > randomHydra.Decimal);
        }

        /// <summary>
        ///     Asserts that an <see cref="decimal"/> <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Greater_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Decimal), randomHydra.Decimal, ExpressionOperator.GreaterThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Decimal > randomHydra.Decimal);
            Assert.DoesNotContain(result, t => t.Decimal <= randomHydra.Decimal);
        }

        /// <summary>
        ///     Asserts that an <see cref="decimal"/> <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Greater_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Decimal), randomHydra.Decimal, ExpressionOperator.GreaterThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Decimal >= randomHydra.Decimal);
            Assert.DoesNotContain(result, t => t.Decimal < randomHydra.Decimal);
        }

        /// <summary>
        ///     Asserts that an <see cref="decimal"/> <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Contains_On_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDecimals = Utilities.GetRandomItems(HydraArmy.Select(t => t.Decimal));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Decimal), randomDecimals, ExpressionOperator.ContainsOnValue));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomDecimals.Contains(t.Decimal));
            Assert.DoesNotContain(result, t => randomDecimals.Contains(t.Decimal) == false);
        }

        // Decimal Array

        /// <summary>
        ///     Asserts that an array of <see cref="decimal"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Array_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalArray), randomHydra.DecimalArray, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalArray.SequenceEqual(randomHydra.DecimalArray));
            Assert.DoesNotContain(result, t => t.DecimalArray.SequenceEqual(randomHydra.DecimalArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="decimal"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Array_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalArray), randomHydra.DecimalArray, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalArray.SequenceEqual(randomHydra.DecimalArray) == false);
            Assert.DoesNotContain(result, t => t.DecimalArray.SequenceEqual(randomHydra.DecimalArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="decimal"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalArray), randomHydra.DecimalArray.ToList(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalArray.SequenceEqual(randomHydra.DecimalArray));
            Assert.DoesNotContain(result, t => t.DecimalArray.SequenceEqual(randomHydra.DecimalArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="decimal"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalArray), randomHydra.DecimalArray.ToList(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalArray.SequenceEqual(randomHydra.DecimalArray) == false);
            Assert.DoesNotContain(result, t => t.DecimalArray.SequenceEqual(randomHydra.DecimalArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="decimal"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Array_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDecimal = Utilities.GetRandomItem(HydraArmy.Select(t => t.DecimalArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalArray), randomDecimal, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalArray.Contains(randomDecimal));
            Assert.DoesNotContain(result, t => t.DecimalArray.Contains(randomDecimal) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="decimal"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Collection_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalCollection), randomHydra.DecimalCollection, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalCollection.SequenceEqual(randomHydra.DecimalCollection));
            Assert.DoesNotContain(result, t => t.DecimalCollection.SequenceEqual(randomHydra.DecimalCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="decimal"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Collection_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalCollection), randomHydra.DecimalCollection, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalCollection.SequenceEqual(randomHydra.DecimalCollection) == false);
            Assert.DoesNotContain(result, t => t.DecimalCollection.SequenceEqual(randomHydra.DecimalCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="decimal"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalCollection), randomHydra.DecimalCollection.ToArray(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalCollection.SequenceEqual(randomHydra.DecimalCollection));
            Assert.DoesNotContain(result, t => t.DecimalCollection.SequenceEqual(randomHydra.DecimalCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="decimal"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalCollection), randomHydra.DecimalCollection.ToArray(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalCollection.SequenceEqual(randomHydra.DecimalCollection) == false);
            Assert.DoesNotContain(result, t => t.DecimalCollection.SequenceEqual(randomHydra.DecimalCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="decimal"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Decimal_Collection_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDecimal = Utilities.GetRandomItem(HydraArmy.Select(t => t.DecimalCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.DecimalCollection), randomDecimal, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DecimalCollection.Contains(randomDecimal));
            Assert.DoesNotContain(result, t => t.DecimalCollection.Contains(randomDecimal) == false);
        }
    }
}