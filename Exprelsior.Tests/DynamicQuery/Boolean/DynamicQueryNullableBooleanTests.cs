namespace Exprelsior.Tests.DynamicQuery.Boolean
{
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.DynamicQuery.Boolean.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="bool"/>? type queries.
    /// </summary>
    public class DynamicQueryNullableBooleanTests : DynamicQueryTestBase, IDynamicQueryNullableBooleanTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicQueryNullableBooleanTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public DynamicQueryNullableBooleanTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Boolean

        /// <summary>
        ///     Asserts that an <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBoolean), randomHydra.NullableBoolean, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBoolean == randomHydra.NullableBoolean);
            Assert.DoesNotContain(result, t => t.NullableBoolean != randomHydra.NullableBoolean);
        }

        /// <summary>
        ///     Asserts that an <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBoolean), randomHydra.NullableBoolean, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBoolean != randomHydra.NullableBoolean);
            Assert.DoesNotContain(result, t => t.NullableBoolean == randomHydra.NullableBoolean);
        }

        /// <summary>
        ///     Asserts that an <see cref="bool"/>? <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Contains_On_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomBooleans = Utilities.GetRandomItems(HydraArmy.Select(t => t.NullableBoolean));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBoolean), randomBooleans, ExpressionOperator.ContainsOnValue));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomBooleans.Contains(t.NullableBoolean));
            Assert.DoesNotContain(result, t => randomBooleans.Contains(t.NullableBoolean) == false);
        }

        // Boolean Array

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Array_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanArray), randomHydra.NullableBooleanArray, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanArray.SequenceEqual(randomHydra.NullableBooleanArray));
            Assert.DoesNotContain(result, t => t.NullableBooleanArray.SequenceEqual(randomHydra.NullableBooleanArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Array_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanArray), randomHydra.NullableBooleanArray, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanArray.SequenceEqual(randomHydra.NullableBooleanArray) == false);
            Assert.DoesNotContain(result, t => t.NullableBooleanArray.SequenceEqual(randomHydra.NullableBooleanArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanArray), randomHydra.NullableBooleanArray.ToList(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanArray.SequenceEqual(randomHydra.NullableBooleanArray));
            Assert.DoesNotContain(result, t => t.NullableBooleanArray.SequenceEqual(randomHydra.NullableBooleanArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanArray), randomHydra.NullableBooleanArray.ToList(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanArray.SequenceEqual(randomHydra.NullableBooleanArray) == false);
            Assert.DoesNotContain(result, t => t.NullableBooleanArray.SequenceEqual(randomHydra.NullableBooleanArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Array_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomBoolean = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableBooleanArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanArray), randomBoolean, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanArray.Contains(randomBoolean));
            Assert.DoesNotContain(result, t => t.NullableBooleanArray.Contains(randomBoolean) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Collection_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanCollection), randomHydra.NullableBooleanCollection, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanCollection.SequenceEqual(randomHydra.NullableBooleanCollection));
            Assert.DoesNotContain(result, t => t.NullableBooleanCollection.SequenceEqual(randomHydra.NullableBooleanCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Collection_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanCollection), randomHydra.NullableBooleanCollection, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanCollection.SequenceEqual(randomHydra.NullableBooleanCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableBooleanCollection.SequenceEqual(randomHydra.NullableBooleanCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanCollection), randomHydra.NullableBooleanCollection.ToArray(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanCollection.SequenceEqual(randomHydra.NullableBooleanCollection));
            Assert.DoesNotContain(result, t => t.NullableBooleanCollection.SequenceEqual(randomHydra.NullableBooleanCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanCollection), randomHydra.NullableBooleanCollection.ToArray(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanCollection.SequenceEqual(randomHydra.NullableBooleanCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableBooleanCollection.SequenceEqual(randomHydra.NullableBooleanCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Boolean_Collection_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomBoolean = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableBooleanCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableBooleanCollection), randomBoolean, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableBooleanCollection.Contains(randomBoolean));
            Assert.DoesNotContain(result, t => t.NullableBooleanCollection.Contains(randomBoolean) == false);
        }
    }
}
