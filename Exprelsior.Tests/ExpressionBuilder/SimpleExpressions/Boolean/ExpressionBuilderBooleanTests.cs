namespace Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.Boolean
{
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.Boolean.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="bool"/> type queries.
    /// </summary>
    public class ExpressionBuilderBooleanTests : ExpressionBuilderTestBase, IExpressionBuilderBooleanTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionBuilderBooleanTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public ExpressionBuilderBooleanTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Boolean

        /// <summary>
        ///     Asserts that an <see cref="bool"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.Boolean), randomHydra.Boolean, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Boolean == randomHydra.Boolean);
            Assert.DoesNotContain(result, t => t.Boolean != randomHydra.Boolean);
        }

        /// <summary>
        ///     Asserts that an <see cref="bool"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.Boolean), randomHydra.Boolean, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Boolean != randomHydra.Boolean);
            Assert.DoesNotContain(result, t => t.Boolean == randomHydra.Boolean);
        }

        /// <summary>
        ///     Asserts that an <see cref="bool"/> <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Contains_On_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomBooleans = Utilities.GetRandomItems(HydraArmy.Select(t => t.Boolean));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.Boolean), randomBooleans, ExpressionOperator.ContainsOnValue);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomBooleans.Contains(t.Boolean));
            Assert.DoesNotContain(result, t => randomBooleans.Contains(t.Boolean) == false);
        }

        // Boolean Array

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Array_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanArray), randomHydra.BooleanArray, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanArray.SequenceEqual(randomHydra.BooleanArray));
            Assert.DoesNotContain(result, t => t.BooleanArray.SequenceEqual(randomHydra.BooleanArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Array_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanArray), randomHydra.BooleanArray, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanArray.SequenceEqual(randomHydra.BooleanArray) == false);
            Assert.DoesNotContain(result, t => t.BooleanArray.SequenceEqual(randomHydra.BooleanArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanArray), randomHydra.BooleanArray.ToList(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanArray.SequenceEqual(randomHydra.BooleanArray));
            Assert.DoesNotContain(result, t => t.BooleanArray.SequenceEqual(randomHydra.BooleanArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanArray), randomHydra.BooleanArray.ToList(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanArray.SequenceEqual(randomHydra.BooleanArray) == false);
            Assert.DoesNotContain(result, t => t.BooleanArray.SequenceEqual(randomHydra.BooleanArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="bool"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Array_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomBoolean = Utilities.GetRandomItem(HydraArmy.Select(t => t.BooleanArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanArray), randomBoolean, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanArray.Contains(randomBoolean));
            Assert.DoesNotContain(result, t => t.BooleanArray.Contains(randomBoolean) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Collection_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanCollection), randomHydra.BooleanCollection, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanCollection.SequenceEqual(randomHydra.BooleanCollection));
            Assert.DoesNotContain(result, t => t.BooleanCollection.SequenceEqual(randomHydra.BooleanCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Collection_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanCollection), randomHydra.BooleanCollection, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanCollection.SequenceEqual(randomHydra.BooleanCollection) == false);
            Assert.DoesNotContain(result, t => t.BooleanCollection.SequenceEqual(randomHydra.BooleanCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanCollection), randomHydra.BooleanCollection.ToArray(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanCollection.SequenceEqual(randomHydra.BooleanCollection));
            Assert.DoesNotContain(result, t => t.BooleanCollection.SequenceEqual(randomHydra.BooleanCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanCollection), randomHydra.BooleanCollection.ToArray(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanCollection.SequenceEqual(randomHydra.BooleanCollection) == false);
            Assert.DoesNotContain(result, t => t.BooleanCollection.SequenceEqual(randomHydra.BooleanCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="bool"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Boolean_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomBoolean = Utilities.GetRandomItem(HydraArmy.Select(t => t.BooleanCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.BooleanCollection), randomBoolean, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.BooleanCollection.Contains(randomBoolean));
            Assert.DoesNotContain(result, t => t.BooleanCollection.Contains(randomBoolean) == false);
        }
    }
}
