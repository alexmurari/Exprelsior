namespace Exprelsior.Tests.ExpressionBuilder.Float
{
    using System;
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.ExpressionBuilder.Float.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="float"/>? type queries.
    /// </summary>
    public class ExpressionBuilderNullableFloatTests : ExpressionBuilderTestBase, IExpressionBuilderNullableFloatTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionBuilderNullableFloatTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public ExpressionBuilderNullableFloatTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Float

        /// <summary>
        ///     Asserts that an <see cref="float"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloat), randomHydra.NullableFloat, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => Math.Abs(t.NullableFloat.GetValueOrDefault() - randomHydra.NullableFloat.GetValueOrDefault()) < 0.01);
            Assert.DoesNotContain(result, t => Math.Abs(t.NullableFloat.GetValueOrDefault() - randomHydra.NullableFloat.GetValueOrDefault()) > 0.01);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloat), randomHydra.NullableFloat, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => Math.Abs(t.NullableFloat.GetValueOrDefault() - randomHydra.NullableFloat.GetValueOrDefault()) > 0.01);
            Assert.DoesNotContain(result, t => Math.Abs(t.NullableFloat.GetValueOrDefault() - randomHydra.NullableFloat.GetValueOrDefault()) < 0.01);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/>? <see cref="ExpressionOperator.LessThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Less_Than_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableFloat.HasValue));
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloat), randomHydra.NullableFloat, ExpressionOperator.LessThan);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloat < randomHydra.NullableFloat);
            Assert.DoesNotContain(result, t => t.NullableFloat >= randomHydra.NullableFloat);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/>? <see cref="ExpressionOperator.LessThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Less_Than_Or_Equal_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableFloat.HasValue));
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloat), randomHydra.NullableFloat, ExpressionOperator.LessThanOrEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloat <= randomHydra.NullableFloat);
            Assert.DoesNotContain(result, t => t.NullableFloat > randomHydra.NullableFloat);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/>? <see cref="ExpressionOperator.GreaterThan"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Greater_Than_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableFloat.HasValue));
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloat), randomHydra.NullableFloat, ExpressionOperator.GreaterThan);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloat > randomHydra.NullableFloat);
            Assert.DoesNotContain(result, t => t.NullableFloat <= randomHydra.NullableFloat);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/>? <see cref="ExpressionOperator.GreaterThanOrEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Greater_Than_Or_Equal_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy.Where(t => t.NullableFloat.HasValue));
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloat), randomHydra.NullableFloat, ExpressionOperator.GreaterThanOrEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloat >= randomHydra.NullableFloat);
            Assert.DoesNotContain(result, t => t.NullableFloat < randomHydra.NullableFloat);
        }

        /// <summary>
        ///     Asserts that an <see cref="float"/>? <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Contains_On_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomFloats = Utilities.GetRandomItems(HydraArmy.Select(t => t.NullableFloat));
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloat), randomFloats, ExpressionOperator.ContainsOnValue);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomFloats.Contains(t.NullableFloat));
            Assert.DoesNotContain(result, t => randomFloats.Contains(t.NullableFloat) == false);
        }

        // Float Array

        /// <summary>
        ///     Asserts that an array of <see cref="float"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Array_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatArray), randomHydra.NullableFloatArray, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatArray.SequenceEqual(randomHydra.NullableFloatArray));
            Assert.DoesNotContain(result, t => t.NullableFloatArray.SequenceEqual(randomHydra.NullableFloatArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="float"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Array_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatArray), randomHydra.NullableFloatArray, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatArray.SequenceEqual(randomHydra.NullableFloatArray) == false);
            Assert.DoesNotContain(result, t => t.NullableFloatArray.SequenceEqual(randomHydra.NullableFloatArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="float"/>? <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatArray), randomHydra.NullableFloatArray.ToList(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatArray.SequenceEqual(randomHydra.NullableFloatArray));
            Assert.DoesNotContain(result, t => t.NullableFloatArray.SequenceEqual(randomHydra.NullableFloatArray) == false);
        }

        /// <summary>
        ///     Asserts that an array of <see cref="float"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatArray), randomHydra.NullableFloatArray.ToList(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatArray.SequenceEqual(randomHydra.NullableFloatArray) == false);
            Assert.DoesNotContain(result, t => t.NullableFloatArray.SequenceEqual(randomHydra.NullableFloatArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="float"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Array_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomFloat = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableFloatArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatArray), randomFloat, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatArray.Contains(randomFloat));
            Assert.DoesNotContain(result, t => t.NullableFloatArray.Contains(randomFloat) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/>? <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Collection_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatCollection), randomHydra.NullableFloatCollection, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatCollection.SequenceEqual(randomHydra.NullableFloatCollection));
            Assert.DoesNotContain(result, t => t.NullableFloatCollection.SequenceEqual(randomHydra.NullableFloatCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/>? <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Collection_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatCollection), randomHydra.NullableFloatCollection, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatCollection.SequenceEqual(randomHydra.NullableFloatCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableFloatCollection.SequenceEqual(randomHydra.NullableFloatCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/>? <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatCollection), randomHydra.NullableFloatCollection.ToArray(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatCollection.SequenceEqual(randomHydra.NullableFloatCollection));
            Assert.DoesNotContain(result, t => t.NullableFloatCollection.SequenceEqual(randomHydra.NullableFloatCollection) == false);
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/>? <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatCollection), randomHydra.NullableFloatCollection.ToArray(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatCollection.SequenceEqual(randomHydra.NullableFloatCollection) == false);
            Assert.DoesNotContain(result, t => t.NullableFloatCollection.SequenceEqual(randomHydra.NullableFloatCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="float"/>? <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Nullable_Float_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomFloat = Utilities.GetRandomItem(HydraArmy.Select(t => t.NullableFloatCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinaryExpression<Hydra>(nameof(Hydra.NullableFloatCollection), randomFloat, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.NullableFloatCollection.Contains(randomFloat));
            Assert.DoesNotContain(result, t => t.NullableFloatCollection.Contains(randomFloat) == false);
        }
    }
}