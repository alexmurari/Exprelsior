namespace Exprelsior.Tests.DynamicQuery.DateTime
{
    using System;
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.DynamicQuery.DateTime.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="DateTime"/>? type queries.
    /// </summary>
    public class DynamicQueryNullableDateTimeTests : DynamicQueryTestBase, IDynamicQueryNullableDateTimeTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicQueryNullableDateTimeTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public DynamicQueryNullableDateTimeTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // DateTime

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTime), randomHydra.NullableDateTime, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTime == randomHydra.NullableDateTime);
            Assert.DoesNotContain(result, t => t.NullableDateTime != randomHydra.NullableDateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTime), randomHydra.NullableDateTime, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTime != randomHydra.NullableDateTime);
            Assert.DoesNotContain(result, t => t.NullableDateTime == randomHydra.NullableDateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/>? <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Less_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableDateTime.HasValue));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTime), randomHydra.NullableDateTime, ExpressionOperator.LessThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTime < randomHydra.NullableDateTime);
            Assert.DoesNotContain(result, t => t.NullableDateTime >= randomHydra.NullableDateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/>? <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Less_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableDateTime.HasValue));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTime), randomHydra.NullableDateTime, ExpressionOperator.LessThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTime <= randomHydra.NullableDateTime);
            Assert.DoesNotContain(result, t => t.NullableDateTime > randomHydra.NullableDateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/>? <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Greater_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableDateTime.HasValue));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTime), randomHydra.NullableDateTime, ExpressionOperator.GreaterThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTime > randomHydra.NullableDateTime);
            Assert.DoesNotContain(result, t => t.NullableDateTime <= randomHydra.NullableDateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/>? <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Greater_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableDateTime.HasValue));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTime), randomHydra.NullableDateTime, ExpressionOperator.GreaterThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTime >= randomHydra.NullableDateTime);
            Assert.DoesNotContain(result, t => t.NullableDateTime < randomHydra.NullableDateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/>? <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Contains_On_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDateTimes = Utilities.GetRandomItems(HydraArmy.Select(t => t.NullableDateTime));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTime), randomDateTimes, ExpressionOperator.ContainsOnValue));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomDateTimes.Contains(t.NullableDateTime));
            Assert.DoesNotContain(result, t => randomDateTimes.Contains(t.NullableDateTime) == false);
        }

        // DateTime Array

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Array_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeArray), randomHydra.NullableDateTimeArray, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeArray.SequenceEqual(randomHydra.NullableDateTimeArray));
            Assert.DoesNotContain(result, t => t.NullableDateTimeArray.SequenceEqual(randomHydra.NullableDateTimeArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Array_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeArray), randomHydra.NullableDateTimeArray, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeArray.SequenceEqual(randomHydra.NullableDateTimeArray) == false);
            Assert.DoesNotContain(result, t => t.NullableDateTimeArray.SequenceEqual(randomHydra.NullableDateTimeArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/>? <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeArray), randomHydra.NullableDateTimeArray.ToList(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeArray.SequenceEqual(randomHydra.NullableDateTimeArray));
            Assert.DoesNotContain(result, t => t.NullableDateTimeArray.SequenceEqual(randomHydra.NullableDateTimeArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeArray), randomHydra.NullableDateTimeArray.ToList(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeArray.SequenceEqual(randomHydra.NullableDateTimeArray) == false);
            Assert.DoesNotContain(result, t => t.NullableDateTimeArray.SequenceEqual(randomHydra.NullableDateTimeArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Array_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDateTime = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableDateTimeArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeArray), randomDateTime, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeArray.Contains(randomDateTime));
            Assert.DoesNotContain(result, t => t.NullableDateTimeArray.Contains(randomDateTime) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Collection_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeCollection), randomHydra.NullableDateTimeCollection, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeCollection.SequenceEqual(randomHydra.NullableDateTimeCollection));
            Assert.DoesNotContain(result, t => t.NullableDateTimeCollection.SequenceEqual(randomHydra.NullableDateTimeCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Collection_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeCollection), randomHydra.NullableDateTimeCollection, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeCollection.SequenceEqual(randomHydra.NullableDateTimeCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableDateTimeCollection.SequenceEqual(randomHydra.NullableDateTimeCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/>? <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeCollection), randomHydra.NullableDateTimeCollection.ToArray(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeCollection.SequenceEqual(randomHydra.NullableDateTimeCollection));
            Assert.DoesNotContain(result, t => t.NullableDateTimeCollection.SequenceEqual(randomHydra.NullableDateTimeCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeCollection), randomHydra.NullableDateTimeCollection.ToArray(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeCollection.SequenceEqual(randomHydra.NullableDateTimeCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableDateTimeCollection.SequenceEqual(randomHydra.NullableDateTimeCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_DateTime_Collection_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDateTime = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableDateTimeCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.NullableDateTimeCollection), randomDateTime, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableDateTimeCollection.Contains(randomDateTime));
            Assert.DoesNotContain(result, t => t.NullableDateTimeCollection.Contains(randomDateTime) == false);
        }
    }
}
