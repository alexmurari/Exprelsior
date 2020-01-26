namespace Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.TimeSpan
{
    using System;
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.TimeSpan.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="TimeSpan"/>? type queries.
    /// </summary>
    public class ExpressionBuilderNullableTimeSpanTests : ExpressionBuilderTestBase, IExpressionBuilderNullableTimeSpanTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionBuilderNullableTimeSpanTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public ExpressionBuilderNullableTimeSpanTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // TimeSpan

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpan), randomHydra.NullableTimeSpan, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpan == randomHydra.NullableTimeSpan);
            Assert.DoesNotContain(result, t => t.NullableTimeSpan != randomHydra.NullableTimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpan), randomHydra.NullableTimeSpan, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpan != randomHydra.NullableTimeSpan);
            Assert.DoesNotContain(result, t => t.NullableTimeSpan == randomHydra.NullableTimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/>? <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Less_Than_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableTimeSpan.HasValue));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpan), randomHydra.NullableTimeSpan, ExpressionOperator.LessThan);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpan < randomHydra.NullableTimeSpan);
            Assert.DoesNotContain(result, t => t.NullableTimeSpan >= randomHydra.NullableTimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/>? <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Less_Than_Or_Equal_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableTimeSpan.HasValue));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpan), randomHydra.NullableTimeSpan, ExpressionOperator.LessThanOrEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpan <= randomHydra.NullableTimeSpan);
            Assert.DoesNotContain(result, t => t.NullableTimeSpan > randomHydra.NullableTimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/>? <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Greater_Than_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableTimeSpan.HasValue));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpan), randomHydra.NullableTimeSpan, ExpressionOperator.GreaterThan);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpan > randomHydra.NullableTimeSpan);
            Assert.DoesNotContain(result, t => t.NullableTimeSpan <= randomHydra.NullableTimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/>? <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Greater_Than_Or_Equal_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableTimeSpan.HasValue));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpan), randomHydra.NullableTimeSpan, ExpressionOperator.GreaterThanOrEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpan >= randomHydra.NullableTimeSpan);
            Assert.DoesNotContain(result, t => t.NullableTimeSpan < randomHydra.NullableTimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/>? <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Contains_On_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomTimeSpans = Utilities.GetRandomItems(HydraArmy.Select(t => t.NullableTimeSpan));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpan), randomTimeSpans, ExpressionOperator.ContainsOnValue);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomTimeSpans.Contains(t.NullableTimeSpan));
            Assert.DoesNotContain(result, t => randomTimeSpans.Contains(t.NullableTimeSpan) == false);
        }

        // TimeSpan Array

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Array_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanArray), randomHydra.NullableTimeSpanArray, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanArray.SequenceEqual(randomHydra.NullableTimeSpanArray));
            Assert.DoesNotContain(result, t => t.NullableTimeSpanArray.SequenceEqual(randomHydra.NullableTimeSpanArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Array_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanArray), randomHydra.NullableTimeSpanArray, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanArray.SequenceEqual(randomHydra.NullableTimeSpanArray) == false);
            Assert.DoesNotContain(result, t => t.NullableTimeSpanArray.SequenceEqual(randomHydra.NullableTimeSpanArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanArray), randomHydra.NullableTimeSpanArray.ToList(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanArray.SequenceEqual(randomHydra.NullableTimeSpanArray));
            Assert.DoesNotContain(result, t => t.NullableTimeSpanArray.SequenceEqual(randomHydra.NullableTimeSpanArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanArray), randomHydra.NullableTimeSpanArray.ToList(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanArray.SequenceEqual(randomHydra.NullableTimeSpanArray) == false);
            Assert.DoesNotContain(result, t => t.NullableTimeSpanArray.SequenceEqual(randomHydra.NullableTimeSpanArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Array_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomTimeSpan = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableTimeSpanArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanArray), randomTimeSpan, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanArray.Contains(randomTimeSpan));
            Assert.DoesNotContain(result, t => t.NullableTimeSpanArray.Contains(randomTimeSpan) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Collection_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanCollection), randomHydra.NullableTimeSpanCollection, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanCollection.SequenceEqual(randomHydra.NullableTimeSpanCollection));
            Assert.DoesNotContain(result, t => t.NullableTimeSpanCollection.SequenceEqual(randomHydra.NullableTimeSpanCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Collection_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanCollection), randomHydra.NullableTimeSpanCollection, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanCollection.SequenceEqual(randomHydra.NullableTimeSpanCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableTimeSpanCollection.SequenceEqual(randomHydra.NullableTimeSpanCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanCollection), randomHydra.NullableTimeSpanCollection.ToArray(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanCollection.SequenceEqual(randomHydra.NullableTimeSpanCollection));
            Assert.DoesNotContain(result, t => t.NullableTimeSpanCollection.SequenceEqual(randomHydra.NullableTimeSpanCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanCollection), randomHydra.NullableTimeSpanCollection.ToArray(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanCollection.SequenceEqual(randomHydra.NullableTimeSpanCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableTimeSpanCollection.SequenceEqual(randomHydra.NullableTimeSpanCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_TimeSpan_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomTimeSpan = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableTimeSpanCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.NullableTimeSpanCollection), randomTimeSpan, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableTimeSpanCollection.Contains(randomTimeSpan));
            Assert.DoesNotContain(result, t => t.NullableTimeSpanCollection.Contains(randomTimeSpan) == false);
        }
    }
}
