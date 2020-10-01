namespace Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.DateTime
{
    using System;
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.DateTime.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="DateTime"/> type queries.
    /// </summary>
    public class ExpressionBuilderDateTimeTests : ExpressionBuilderTestBase, IExpressionBuilderDateTimeTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionBuilderDateTimeTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public ExpressionBuilderDateTimeTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // DateTime

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomHydra.DateTime, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTime == randomHydra.DateTime);
            Assert.DoesNotContain(result, t => t.DateTime != randomHydra.DateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomHydra.DateTime, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTime != randomHydra.DateTime);
            Assert.DoesNotContain(result, t => t.DateTime == randomHydra.DateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/> <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Less_Than_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomHydra.DateTime, ExpressionOperator.LessThan);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTime < randomHydra.DateTime);
            Assert.DoesNotContain(result, t => t.DateTime >= randomHydra.DateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/> <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Less_Than_Or_Equal_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomHydra.DateTime, ExpressionOperator.LessThanOrEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTime <= randomHydra.DateTime);
            Assert.DoesNotContain(result, t => t.DateTime > randomHydra.DateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/> <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Greater_Than_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomHydra.DateTime, ExpressionOperator.GreaterThan);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTime > randomHydra.DateTime);
            Assert.DoesNotContain(result, t => t.DateTime <= randomHydra.DateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/> <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Greater_Than_Or_Equal_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomHydra.DateTime, ExpressionOperator.GreaterThanOrEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTime >= randomHydra.DateTime);
            Assert.DoesNotContain(result, t => t.DateTime < randomHydra.DateTime);
        }

        /// <summary>
        ///     Asserts that an <see cref="DateTime"/> <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Contains_On_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDateTimes = Utilities.GetRandomItems(HydraArmy.Select(t => t.DateTime));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTime), randomDateTimes, ExpressionOperator.ContainsOnValue);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomDateTimes.Contains(t.DateTime));
            Assert.DoesNotContain(result, t => !randomDateTimes.Contains(t.DateTime));
        }

        // DateTime Array

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Array_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeArray), randomHydra.DateTimeArray, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTimeArray.SequenceEqual(randomHydra.DateTimeArray));
            Assert.DoesNotContain(result, t => !t.DateTimeArray.SequenceEqual(randomHydra.DateTimeArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Array_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeArray), randomHydra.DateTimeArray, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.DateTimeArray.SequenceEqual(randomHydra.DateTimeArray));
            Assert.DoesNotContain(result, t => t.DateTimeArray.SequenceEqual(randomHydra.DateTimeArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeArray), randomHydra.DateTimeArray.ToList(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTimeArray.SequenceEqual(randomHydra.DateTimeArray));
            Assert.DoesNotContain(result, t => !t.DateTimeArray.SequenceEqual(randomHydra.DateTimeArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeArray), randomHydra.DateTimeArray.ToList(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.DateTimeArray.SequenceEqual(randomHydra.DateTimeArray));
            Assert.DoesNotContain(result, t => t.DateTimeArray.SequenceEqual(randomHydra.DateTimeArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="DateTime"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Array_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDateTime = Utilities.GetRandomItem(HydraArmy.Select(t => t.DateTimeArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeArray), randomDateTime, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTimeArray.Contains(randomDateTime));
            Assert.DoesNotContain(result, t => !t.DateTimeArray.Contains(randomDateTime));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Collection_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeCollection), randomHydra.DateTimeCollection, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTimeCollection.SequenceEqual(randomHydra.DateTimeCollection));
            Assert.DoesNotContain(result, t => !t.DateTimeCollection.SequenceEqual(randomHydra.DateTimeCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Collection_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeCollection), randomHydra.DateTimeCollection, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.DateTimeCollection.SequenceEqual(randomHydra.DateTimeCollection));
            Assert.DoesNotContain(result, t => t.DateTimeCollection.SequenceEqual(randomHydra.DateTimeCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeCollection), randomHydra.DateTimeCollection.ToArray(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTimeCollection.SequenceEqual(randomHydra.DateTimeCollection));
            Assert.DoesNotContain(result, t => !t.DateTimeCollection.SequenceEqual(randomHydra.DateTimeCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeCollection), randomHydra.DateTimeCollection.ToArray(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.DateTimeCollection.SequenceEqual(randomHydra.DateTimeCollection));
            Assert.DoesNotContain(result, t => t.DateTimeCollection.SequenceEqual(randomHydra.DateTimeCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="DateTime"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_DateTime_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomDateTime = Utilities.GetRandomItem(HydraArmy.Select(t => t.DateTimeCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.DateTimeCollection), randomDateTime, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.DateTimeCollection.Contains(randomDateTime));
            Assert.DoesNotContain(result, t => !t.DateTimeCollection.Contains(randomDateTime));
        }
    }
}
