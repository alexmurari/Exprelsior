namespace Exprelsior.Tests.ExpressionBuilder
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Exprelsior.Tests.Utilities;
    using Xunit.Abstractions;

    /// <summary>
    ///     Base class for expression builder unit tests.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class ExpressionBuilderTestBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ExpressionBuilderTestBase"/> class.
        /// </summary>
        /// <param name="testOutput">
        ///     The class responsible for providing test output.
        /// </param>
        protected ExpressionBuilderTestBase(ITestOutputHelper testOutput)
        {
            TestOutput = testOutput;
            HydraArmy = Utilities.GetFakeHydraCollection();
        }

        /// <summary>
        ///     Gets the test output helper.
        /// </summary>
        protected ITestOutputHelper TestOutput { get; }

        /// <summary>
        ///     Gets the hydra army.
        /// </summary>
        protected List<Hydra> HydraArmy { get; }
    }
}
