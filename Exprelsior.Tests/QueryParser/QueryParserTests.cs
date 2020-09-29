namespace Exprelsior.Tests.QueryParser
{
    using System.Linq;
    using Xunit;

    /// <summary>
    ///     Unit tests for the query parser.
    /// </summary>
    public class QueryParserTests
    {
        /// <summary>
        ///     Asserts that short name properties are correctly parsed by the query parser.
        /// </summary>
        /// <param name="propertyName">The property name to test.</param>
        [Theory]
        [InlineData("F")]
        [InlineData("Fo")]
        [InlineData("Foo")]
        public void Assert_Short_Name_Properties_Are_Parsed_Correctly(string propertyName)
        {
            // Arrange
            var query = $"eq('{propertyName}', '1')";

            // Act
            var queryElements = Exprelsior.DynamicQuery.Parser.QueryParser.ParseQuery(query).ToList();

            // Assert
            Assert.NotEmpty(queryElements);
            Assert.Contains(queryElements, t => t.PropertyName == propertyName);
        }
    }
}
