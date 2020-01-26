namespace Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.Integer
{
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.Integer.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="int"/>? type queries.
    /// </summary>
    public class ExpressionBuilderNullableIntegerTests : ExpressionBuilderTestBase, IExpressionBuilderNullableIntegerTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionBuilderNullableIntegerTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public ExpressionBuilderNullableIntegerTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Integer

        /// <summary>
        ///     Asserts that an <see cref="int"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableInteger), randomHydra.NullableInteger, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableInteger == randomHydra.NullableInteger);
            Assert.DoesNotContain(result, t => t.NullableInteger != randomHydra.NullableInteger);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableInteger), randomHydra.NullableInteger, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableInteger != randomHydra.NullableInteger);
            Assert.DoesNotContain(result, t => t.NullableInteger == randomHydra.NullableInteger);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/>? <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Less_Than_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableInteger.HasValue));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableInteger), randomHydra.NullableInteger, ExpressionOperator.LessThan);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableInteger < randomHydra.NullableInteger);
            Assert.DoesNotContain(result, t => t.NullableInteger >= randomHydra.NullableInteger);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/>? <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Less_Than_Or_Equal_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableInteger.HasValue));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableInteger), randomHydra.NullableInteger, ExpressionOperator.LessThanOrEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableInteger <= randomHydra.NullableInteger);
            Assert.DoesNotContain(result, t => t.NullableInteger > randomHydra.NullableInteger);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/>? <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Greater_Than_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableInteger.HasValue));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableInteger), randomHydra.NullableInteger, ExpressionOperator.GreaterThan);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableInteger > randomHydra.NullableInteger);
            Assert.DoesNotContain(result, t => t.NullableInteger <= randomHydra.NullableInteger);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/>? <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Greater_Than_Or_Equal_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableInteger.HasValue));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableInteger), randomHydra.NullableInteger, ExpressionOperator.GreaterThanOrEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableInteger >= randomHydra.NullableInteger);
            Assert.DoesNotContain(result, t => t.NullableInteger < randomHydra.NullableInteger);
        }

        /// <summary>
        ///     Asserts that an <see cref="int"/>? <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Contains_On_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomIntegers = Utilities.GetRandomItems(HydraArmy.Select(t => t.NullableInteger));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableInteger), randomIntegers, ExpressionOperator.ContainsOnValue);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomIntegers.Contains(t.NullableInteger));
            Assert.DoesNotContain(result, t => randomIntegers.Contains(t.NullableInteger) == false);
        }

        // Integer Array

        /// <summary>
        ///     Asserts that an array of <see cref="int"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Array_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerArray), randomHydra.NullableIntegerArray, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerArray.SequenceEqual(randomHydra.NullableIntegerArray));
            Assert.DoesNotContain(result, t => t.NullableIntegerArray.SequenceEqual(randomHydra.NullableIntegerArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="int"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Array_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerArray), randomHydra.NullableIntegerArray, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerArray.SequenceEqual(randomHydra.NullableIntegerArray) == false);
            Assert.DoesNotContain(result, t => t.NullableIntegerArray.SequenceEqual(randomHydra.NullableIntegerArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="int"/>? <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerArray), randomHydra.NullableIntegerArray.ToList(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerArray.SequenceEqual(randomHydra.NullableIntegerArray));
            Assert.DoesNotContain(result, t => t.NullableIntegerArray.SequenceEqual(randomHydra.NullableIntegerArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="int"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerArray), randomHydra.NullableIntegerArray.ToList(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerArray.SequenceEqual(randomHydra.NullableIntegerArray) == false);
            Assert.DoesNotContain(result, t => t.NullableIntegerArray.SequenceEqual(randomHydra.NullableIntegerArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="int"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Array_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomInteger = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableIntegerArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerArray), randomInteger, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerArray.Contains(randomInteger));
            Assert.DoesNotContain(result, t => t.NullableIntegerArray.Contains(randomInteger) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Collection_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerCollection), randomHydra.NullableIntegerCollection, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerCollection.SequenceEqual(randomHydra.NullableIntegerCollection));
            Assert.DoesNotContain(result, t => t.NullableIntegerCollection.SequenceEqual(randomHydra.NullableIntegerCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Collection_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerCollection), randomHydra.NullableIntegerCollection, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerCollection.SequenceEqual(randomHydra.NullableIntegerCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableIntegerCollection.SequenceEqual(randomHydra.NullableIntegerCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/>? <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerCollection), randomHydra.NullableIntegerCollection.ToArray(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerCollection.SequenceEqual(randomHydra.NullableIntegerCollection));
            Assert.DoesNotContain(result, t => t.NullableIntegerCollection.SequenceEqual(randomHydra.NullableIntegerCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerCollection), randomHydra.NullableIntegerCollection.ToArray(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerCollection.SequenceEqual(randomHydra.NullableIntegerCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableIntegerCollection.SequenceEqual(randomHydra.NullableIntegerCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="int"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Integer_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomInteger = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableIntegerCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableIntegerCollection), randomInteger, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableIntegerCollection.Contains(randomInteger));
            Assert.DoesNotContain(result, t => t.NullableIntegerCollection.Contains(randomInteger) == false);
        }
    }
}