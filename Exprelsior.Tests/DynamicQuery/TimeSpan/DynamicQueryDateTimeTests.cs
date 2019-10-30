namespace Exprelsior.Tests.DynamicQuery.TimeSpan
{
    using System;
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.DynamicQuery.TimeSpan.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="TimeSpan"/> type queries.
    /// </summary>
    public class DynamicQueryTimeSpanTests : DynamicQueryTestBase, IDynamicQueryTimeSpanTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DynamicQueryTimeSpanTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public DynamicQueryTimeSpanTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // TimeSpan

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpan), randomHydra.TimeSpan, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpan == randomHydra.TimeSpan);
            Assert.DoesNotContain(result, t => t.TimeSpan != randomHydra.TimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpan), randomHydra.TimeSpan, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpan != randomHydra.TimeSpan);
            Assert.DoesNotContain(result, t => t.TimeSpan == randomHydra.TimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/> <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Less_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpan), randomHydra.TimeSpan, ExpressionOperator.LessThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpan < randomHydra.TimeSpan);
            Assert.DoesNotContain(result, t => t.TimeSpan >= randomHydra.TimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/> <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Less_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpan), randomHydra.TimeSpan, ExpressionOperator.LessThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpan <= randomHydra.TimeSpan);
            Assert.DoesNotContain(result, t => t.TimeSpan > randomHydra.TimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/> <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Greater_Than_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpan), randomHydra.TimeSpan, ExpressionOperator.GreaterThan));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpan > randomHydra.TimeSpan);
            Assert.DoesNotContain(result, t => t.TimeSpan <= randomHydra.TimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/> <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Greater_Than_Or_Equal_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpan), randomHydra.TimeSpan, ExpressionOperator.GreaterThanOrEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpan >= randomHydra.TimeSpan);
            Assert.DoesNotContain(result, t => t.TimeSpan < randomHydra.TimeSpan);
        }

        /// <summary>
        ///     Asserts that an <see cref="TimeSpan"/> <see cref="ExpressionOperator.ContainsOnValue"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Contains_On_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomTimeSpans = Utilities.GetRandomItems(HydraArmy.Select(t => t.TimeSpan));
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpan), randomTimeSpans, ExpressionOperator.ContainsOnValue));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomTimeSpans.Contains(t.TimeSpan));
            Assert.DoesNotContain(result, t => randomTimeSpans.Contains(t.TimeSpan) == false);
        }

        // TimeSpan Array

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Array_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanArray), randomHydra.TimeSpanArray, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanArray.SequenceEqual(randomHydra.TimeSpanArray));
            Assert.DoesNotContain(result, t => t.TimeSpanArray.SequenceEqual(randomHydra.TimeSpanArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Array_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanArray), randomHydra.TimeSpanArray, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanArray.SequenceEqual(randomHydra.TimeSpanArray) == false);
            Assert.DoesNotContain(result, t => t.TimeSpanArray.SequenceEqual(randomHydra.TimeSpanArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanArray), randomHydra.TimeSpanArray.ToList(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanArray.SequenceEqual(randomHydra.TimeSpanArray));
            Assert.DoesNotContain(result, t => t.TimeSpanArray.SequenceEqual(randomHydra.TimeSpanArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanArray), randomHydra.TimeSpanArray.ToList(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanArray.SequenceEqual(randomHydra.TimeSpanArray) == false);
            Assert.DoesNotContain(result, t => t.TimeSpanArray.SequenceEqual(randomHydra.TimeSpanArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="TimeSpan"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Array_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomTimeSpan = Utilities.GetRandomItem(HydraArmy.Select(t => t.TimeSpanArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanArray), randomTimeSpan, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanArray.Contains(randomTimeSpan));
            Assert.DoesNotContain(result, t => t.TimeSpanArray.Contains(randomTimeSpan) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Collection_Equality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanCollection), randomHydra.TimeSpanCollection, ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanCollection.SequenceEqual(randomHydra.TimeSpanCollection));
            Assert.DoesNotContain(result, t => t.TimeSpanCollection.SequenceEqual(randomHydra.TimeSpanCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Collection_Inequality_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanCollection), randomHydra.TimeSpanCollection, ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanCollection.SequenceEqual(randomHydra.TimeSpanCollection) == false);
            Assert.DoesNotContain(result, t => t.TimeSpanCollection.SequenceEqual(randomHydra.TimeSpanCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanCollection), randomHydra.TimeSpanCollection.ToArray(), ExpressionOperator.Equal));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanCollection.SequenceEqual(randomHydra.TimeSpanCollection));
            Assert.DoesNotContain(result, t => t.TimeSpanCollection.SequenceEqual(randomHydra.TimeSpanCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanCollection), randomHydra.TimeSpanCollection.ToArray(), ExpressionOperator.NotEqual));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanCollection.SequenceEqual(randomHydra.TimeSpanCollection) == false);
            Assert.DoesNotContain(result, t => t.TimeSpanCollection.SequenceEqual(randomHydra.TimeSpanCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="TimeSpan"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_TimeSpan_Collection_Contains_Single_Value_Dynamic_Query_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomTimeSpan = Utilities.GetRandomItem(HydraArmy.Select(t => t.TimeSpanCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryFromQuery<Hydra>(BuildQueryText(nameof(Hydra.TimeSpanCollection), randomTimeSpan, ExpressionOperator.Contains));

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.TimeSpanCollection.Contains(randomTimeSpan));
            Assert.DoesNotContain(result, t => t.TimeSpanCollection.Contains(randomTimeSpan) == false);
        }
    }
}
