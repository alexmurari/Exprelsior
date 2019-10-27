namespace Exprelsior.Tests.DynamicQuery.Integer
{
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.DynamicQuery.Integer.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="int"/> type queries.
    /// </summary>
    public class DynamicQueryIntegerTests : DynamicQueryTestBase, IDynamicQueryIntegerTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicQueryIntegerTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public DynamicQueryIntegerTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Integer

        /// <summary>
        ///     Asserts that an <see cref="int"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Integer), randomHydra.Integer, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Integer == randomHydra.Integer);
            Assert.DoesNotContain(result, t => t.Integer != randomHydra.Integer);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Integer), randomHydra.Integer, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Integer != randomHydra.Integer);
            Assert.DoesNotContain(result, t => t.Integer == randomHydra.Integer);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/> <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Less_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Integer), randomHydra.Integer, ExpressionOperator.LessThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Integer < randomHydra.Integer);
            Assert.DoesNotContain(result, t => t.Integer >= randomHydra.Integer);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/> <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Less_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Integer), randomHydra.Integer, ExpressionOperator.LessThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Integer <= randomHydra.Integer);
            Assert.DoesNotContain(result, t => t.Integer > randomHydra.Integer);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/> <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Greater_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Integer), randomHydra.Integer, ExpressionOperator.GreaterThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Integer > randomHydra.Integer);
            Assert.DoesNotContain(result, t => t.Integer <= randomHydra.Integer);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/> <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Greater_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Integer), randomHydra.Integer, ExpressionOperator.GreaterThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Integer >= randomHydra.Integer);
            Assert.DoesNotContain(result, t => t.Integer < randomHydra.Integer);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/> <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Contains_On_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomIntegers = Utilities.GetRandomItems(HydraArmy.Select(t => t.Integer));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.Integer), randomIntegers, ExpressionOperator.ContainsOnValue));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomIntegers.Contains(t.Integer));
            Assert.DoesNotContain(result, t => randomIntegers.Contains(t.Integer) == false);
        }

        // Integer Array

        /// <summary>
        ///     Asserts that an array of <see cref="int"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Array_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerArray), randomHydra.IntegerArray, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerArray.SequenceEqual(randomHydra.IntegerArray));
            Assert.DoesNotContain(result, t => t.IntegerArray.SequenceEqual(randomHydra.IntegerArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="int"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Array_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerArray), randomHydra.IntegerArray, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerArray.SequenceEqual(randomHydra.IntegerArray) == false);
            Assert.DoesNotContain(result, t => t.IntegerArray.SequenceEqual(randomHydra.IntegerArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="int"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerArray), randomHydra.IntegerArray.ToList(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerArray.SequenceEqual(randomHydra.IntegerArray));
            Assert.DoesNotContain(result, t => t.IntegerArray.SequenceEqual(randomHydra.IntegerArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="int"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerArray), randomHydra.IntegerArray.ToList(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerArray.SequenceEqual(randomHydra.IntegerArray) == false);
            Assert.DoesNotContain(result, t => t.IntegerArray.SequenceEqual(randomHydra.IntegerArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="int"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Array_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomInteger = Utilities.GetRandomItem(HydraArmy.Select(t => t.IntegerArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerArray), randomInteger, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerArray.Contains(randomInteger));
            Assert.DoesNotContain(result, t => t.IntegerArray.Contains(randomInteger) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Collection_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerCollection), randomHydra.IntegerCollection, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerCollection.SequenceEqual(randomHydra.IntegerCollection));
            Assert.DoesNotContain(result, t => t.IntegerCollection.SequenceEqual(randomHydra.IntegerCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Collection_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerCollection), randomHydra.IntegerCollection, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerCollection.SequenceEqual(randomHydra.IntegerCollection) == false);
            Assert.DoesNotContain(result, t => t.IntegerCollection.SequenceEqual(randomHydra.IntegerCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerCollection), randomHydra.IntegerCollection.ToArray(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerCollection.SequenceEqual(randomHydra.IntegerCollection));
            Assert.DoesNotContain(result, t => t.IntegerCollection.SequenceEqual(randomHydra.IntegerCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerCollection), randomHydra.IntegerCollection.ToArray(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerCollection.SequenceEqual(randomHydra.IntegerCollection) == false);
            Assert.DoesNotContain(result, t => t.IntegerCollection.SequenceEqual(randomHydra.IntegerCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Integer_Collection_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomInteger = Utilities.GetRandomItem(HydraArmy.Select(t => t.IntegerCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.IntegerCollection), randomInteger, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.IntegerCollection.Contains(randomInteger));
            Assert.DoesNotContain(result, t => t.IntegerCollection.Contains(randomInteger) == false);
        }
    }
}