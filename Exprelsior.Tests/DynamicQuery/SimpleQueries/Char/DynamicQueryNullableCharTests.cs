namespace Exprelsior.Tests.DynamicQuery.SimpleQueries.Char
{
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.DynamicQuery.SimpleQueries.Char.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="char"/>? type queries.
    /// </summary>
    public class DynamicQueryNullableCharTests : DynamicQueryTestBase, IDynamicQueryNullableCharTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicQueryNullableCharTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public DynamicQueryNullableCharTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Char

        /// <summary>
        ///     Asserts that an <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableChar), randomHydra.NullableChar, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableChar == randomHydra.NullableChar);
            Assert.DoesNotContain(result, t => t.NullableChar != randomHydra.NullableChar);
        }

        /// <summary>
        ///     Asserts that an <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableChar), randomHydra.NullableChar, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableChar != randomHydra.NullableChar);
            Assert.DoesNotContain(result, t => t.NullableChar == randomHydra.NullableChar);
        }

        /// <summary>
        ///     Asserts that an <see cref="char"/>? <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Contains_On_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomChars = Utilities.GetRandomItems(HydraArmy.Select(t => t.NullableChar));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableChar), randomChars, ExpressionOperator.ContainsOnValue));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomChars.Contains(t.NullableChar));
            Assert.DoesNotContain(result, t => !randomChars.Contains(t.NullableChar));
        }

        // Char Array

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Array_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharArray), randomHydra.NullableCharArray, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableCharArray.SequenceEqual(randomHydra.NullableCharArray));
            Assert.DoesNotContain(result, t => !t.NullableCharArray.SequenceEqual(randomHydra.NullableCharArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Array_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharArray), randomHydra.NullableCharArray, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.NullableCharArray.SequenceEqual(randomHydra.NullableCharArray));
            Assert.DoesNotContain(result, t => t.NullableCharArray.SequenceEqual(randomHydra.NullableCharArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharArray), randomHydra.NullableCharArray.ToList(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableCharArray.SequenceEqual(randomHydra.NullableCharArray));
            Assert.DoesNotContain(result, t => !t.NullableCharArray.SequenceEqual(randomHydra.NullableCharArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharArray), randomHydra.NullableCharArray.ToList(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.NullableCharArray.SequenceEqual(randomHydra.NullableCharArray));
            Assert.DoesNotContain(result, t => t.NullableCharArray.SequenceEqual(randomHydra.NullableCharArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="char"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Array_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomChar = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableCharArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharArray), randomChar, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableCharArray.Contains(randomChar));
            Assert.DoesNotContain(result, t => !t.NullableCharArray.Contains(randomChar));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Collection_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharCollection), randomHydra.NullableCharCollection, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableCharCollection.SequenceEqual(randomHydra.NullableCharCollection));
            Assert.DoesNotContain(result, t => !t.NullableCharCollection.SequenceEqual(randomHydra.NullableCharCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Collection_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharCollection), randomHydra.NullableCharCollection, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.NullableCharCollection.SequenceEqual(randomHydra.NullableCharCollection));
            Assert.DoesNotContain(result, t => t.NullableCharCollection.SequenceEqual(randomHydra.NullableCharCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharCollection), randomHydra.NullableCharCollection.ToArray(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableCharCollection.SequenceEqual(randomHydra.NullableCharCollection));
            Assert.DoesNotContain(result, t => !t.NullableCharCollection.SequenceEqual(randomHydra.NullableCharCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharCollection), randomHydra.NullableCharCollection.ToArray(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.NullableCharCollection.SequenceEqual(randomHydra.NullableCharCollection));
            Assert.DoesNotContain(result, t => t.NullableCharCollection.SequenceEqual(randomHydra.NullableCharCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Char_Collection_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomChar = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableCharCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableCharCollection), randomChar, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableCharCollection.Contains(randomChar));
            Assert.DoesNotContain(result, t => !t.NullableCharCollection.Contains(randomChar));
        }
    }
}
