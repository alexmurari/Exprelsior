namespace Exprelsior.Tests.DynamicQuery.Char
{
    using System.Linq;
    using Exprelsior.DynamicQuery;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.DynamicQuery.Char.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="char"/> type queries.
    /// </summary>
    public class DynamicQueryCharTests : DynamicQueryTestBase, IDynamicQueryCharTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicQueryCharTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public DynamicQueryCharTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Char

        /// <summary>
        ///     Asserts that an <see cref="char"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Char), randomHydra.Char, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Char == randomHydra.Char);
            Assert.DoesNotContain(result, t => t.Char != randomHydra.Char);
        }

        /// <summary>
        ///     Asserts that an <see cref="char"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Char), randomHydra.Char, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Char != randomHydra.Char);
            Assert.DoesNotContain(result, t => t.Char == randomHydra.Char);
        }

        /// <summary>
        ///     Asserts that an <see cref="char"/> <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Contains_On_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomChars = Utilities.GetRandomItems(HydraArmy.Select(t => t.Char));
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.Char), randomChars, ExpressionOperator.ContainsOnValue));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomChars.Contains(t.Char));
            Assert.DoesNotContain(result, t => randomChars.Contains(t.Char) == false);
        }

        // Char Array

        /// <summary>
        ///     Asserts that an array of <see cref="char"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Array_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharArray), randomHydra.CharArray, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharArray.SequenceEqual(randomHydra.CharArray));
            Assert.DoesNotContain(result, t => t.CharArray.SequenceEqual(randomHydra.CharArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="char"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Array_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharArray), randomHydra.CharArray, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharArray.SequenceEqual(randomHydra.CharArray) == false);
            Assert.DoesNotContain(result, t => t.CharArray.SequenceEqual(randomHydra.CharArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="char"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharArray), randomHydra.CharArray.ToList(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharArray.SequenceEqual(randomHydra.CharArray));
            Assert.DoesNotContain(result, t => t.CharArray.SequenceEqual(randomHydra.CharArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="char"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharArray), randomHydra.CharArray.ToList(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharArray.SequenceEqual(randomHydra.CharArray) == false);
            Assert.DoesNotContain(result, t => t.CharArray.SequenceEqual(randomHydra.CharArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="char"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Array_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomChar = Utilities.GetRandomItem(HydraArmy.Select(t => t.CharArray)).FirstOrDefault();
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharArray), randomChar, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharArray.Contains(randomChar));
            Assert.DoesNotContain(result, t => t.CharArray.Contains(randomChar) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Collection_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharCollection), randomHydra.CharCollection, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharCollection.SequenceEqual(randomHydra.CharCollection));
            Assert.DoesNotContain(result, t => t.CharCollection.SequenceEqual(randomHydra.CharCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Collection_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharCollection), randomHydra.CharCollection, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharCollection.SequenceEqual(randomHydra.CharCollection) == false);
            Assert.DoesNotContain(result, t => t.CharCollection.SequenceEqual(randomHydra.CharCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharCollection), randomHydra.CharCollection.ToArray(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharCollection.SequenceEqual(randomHydra.CharCollection));
            Assert.DoesNotContain(result, t => t.CharCollection.SequenceEqual(randomHydra.CharCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharCollection), randomHydra.CharCollection.ToArray(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharCollection.SequenceEqual(randomHydra.CharCollection) == false);
            Assert.DoesNotContain(result, t => t.CharCollection.SequenceEqual(randomHydra.CharCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="char"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Char_Collection_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomChar = Utilities.GetRandomItem(HydraArmy.Select(t => t.CharCollection)).FirstOrDefault();
            var expression = DynamicQueryBuilder.Build<Hydra>(BuildQueryText(nameof(Hydra.CharCollection), randomChar, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.CharCollection.Contains(randomChar));
            Assert.DoesNotContain(result, t => t.CharCollection.Contains(randomChar) == false);
        }
    }
}
