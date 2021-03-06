﻿namespace Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.Guid
{
    using System;
    using System.Linq;
    using Exprelsior.ExpressionBuilder;
    using Exprelsior.ExpressionBuilder.Enums;
    using Exprelsior.Tests.ExpressionBuilder.SimpleExpressions.Guid.Contracts;
    using Exprelsior.Tests.Utilities;
    using Xunit;
    using Xunit.Abstractions;

    // ReSharper disable InconsistentNaming

    /// <summary>
    ///     Unit tests for the dynamic query builder with tests focused on <see cref="Guid"/> type queries.
    /// </summary>
    public class ExpressionBuilderGuidTests : ExpressionBuilderTestBase, IExpressionBuilderGuidTests
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionBuilderGuidTests"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        public ExpressionBuilderGuidTests(ITestOutputHelper testOutput) : base(testOutput)
        {
        }

        // Guid

        /// <summary>
        ///     Asserts that an <see cref="Guid"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.Guid), randomHydra.Guid, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Guid == randomHydra.Guid);
            Assert.DoesNotContain(result, t => t.Guid != randomHydra.Guid);
        }

        /// <summary>
        ///     Asserts that an <see cref="Guid"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.Guid), randomHydra.Guid, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.Guid != randomHydra.Guid);
            Assert.DoesNotContain(result, t => t.Guid == randomHydra.Guid);
        }

        /// <summary>
        ///     Asserts that an <see cref="Guid"/> <see cref="ExpressionOperator.Contains"/> on value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Contains_On_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomGuids = Utilities.GetRandomItems(HydraArmy.Select(t => t.Guid));
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.Guid), randomGuids, ExpressionOperator.ContainsOnValue);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => randomGuids.Contains(t.Guid));
            Assert.DoesNotContain(result, t => !randomGuids.Contains(t.Guid));
        }

        // Guid Array

        /// <summary>
        ///     Asserts that an array of <see cref="Guid"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Array_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidArray), randomHydra.GuidArray, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.GuidArray.SequenceEqual(randomHydra.GuidArray));
            Assert.DoesNotContain(result, t => !t.GuidArray.SequenceEqual(randomHydra.GuidArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="Guid"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Array_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidArray), randomHydra.GuidArray, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.GuidArray.SequenceEqual(randomHydra.GuidArray));
            Assert.DoesNotContain(result, t => t.GuidArray.SequenceEqual(randomHydra.GuidArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="Guid"/> <see cref="ExpressionOperator.Equal"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Array_Equality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidArray), randomHydra.GuidArray.ToList(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.GuidArray.SequenceEqual(randomHydra.GuidArray));
            Assert.DoesNotContain(result, t => !t.GuidArray.SequenceEqual(randomHydra.GuidArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="Guid"/> <see cref="ExpressionOperator.NotEqual"/> expression with an list of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Array_Inequality_Expression_With_List_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidArray), randomHydra.GuidArray.ToList(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.GuidArray.SequenceEqual(randomHydra.GuidArray));
            Assert.DoesNotContain(result, t => t.GuidArray.SequenceEqual(randomHydra.GuidArray));
        }

        /// <summary>
        ///     Asserts that an array of <see cref="Guid"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Array_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomGuid = Utilities.GetRandomItem(HydraArmy.Select(t => t.GuidArray)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidArray), randomGuid, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.GuidArray.Contains(randomGuid));
            Assert.DoesNotContain(result, t => !t.GuidArray.Contains(randomGuid));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="Guid"/> <see cref="ExpressionOperator.Equal"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Collection_Equality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidCollection), randomHydra.GuidCollection, ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.GuidCollection.SequenceEqual(randomHydra.GuidCollection));
            Assert.DoesNotContain(result, t => !t.GuidCollection.SequenceEqual(randomHydra.GuidCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="Guid"/> <see cref="ExpressionOperator.NotEqual"/> expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Collection_Inequality_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidCollection), randomHydra.GuidCollection, ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.GuidCollection.SequenceEqual(randomHydra.GuidCollection));
            Assert.DoesNotContain(result, t => t.GuidCollection.SequenceEqual(randomHydra.GuidCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="Guid"/> <see cref="ExpressionOperator.Equal"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Collection_Equality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidCollection), randomHydra.GuidCollection.ToArray(), ExpressionOperator.Equal);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.GuidCollection.SequenceEqual(randomHydra.GuidCollection));
            Assert.DoesNotContain(result, t => !t.GuidCollection.SequenceEqual(randomHydra.GuidCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="Guid"/> <see cref="ExpressionOperator.NotEqual"/> expression with an array of values is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Collection_Inequality_Expression_With_Array_Value_Is_Generated_Correctly()
        {
            // Arrange
            var randomHydra = Utilities.GetRandomItem(HydraArmy);
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidCollection), randomHydra.GuidCollection.ToArray(), ExpressionOperator.NotEqual);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => !t.GuidCollection.SequenceEqual(randomHydra.GuidCollection));
            Assert.DoesNotContain(result, t => t.GuidCollection.SequenceEqual(randomHydra.GuidCollection));
        }

        /// <summary>
        ///     Asserts that an collection of <see cref="Guid"/> <see cref="ExpressionOperator.Contains"/> single value expression is generated correctly.
        /// </summary>
        [Fact]
        public void Assert_Guid_Collection_Contains_Single_Value_Expression_Is_Generated_Correctly()
        {
            // Arrange
            var randomGuid = Utilities.GetRandomItem(HydraArmy.Select(t => t.GuidCollection)).FirstOrDefault();
            var expression = ExpressionBuilder.CreateBinary<Hydra>(nameof(Hydra.GuidCollection), randomGuid, ExpressionOperator.Contains);

            // Act
            var result = HydraArmy.Where(expression.Compile()).ToList();

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains(result, t => t.GuidCollection.Contains(randomGuid));
            Assert.DoesNotContain(result, t => !t.GuidCollection.Contains(randomGuid));
        }
    }
}
