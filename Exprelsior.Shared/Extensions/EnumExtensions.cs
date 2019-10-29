namespace Exprelsior.Shared.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    ///     Provides extension methods to the <see cref="Enum" /> type.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class EnumExtensions
    {
        /// <summary>
        ///     Gets the description of the enumeration defined in the <see cref="DescriptionAttribute" />.
        /// </summary>
        /// <param name="value">
        ///     The value representing the enumeration to get the description from.
        /// </param>
        /// <returns>
        ///     The enumeration description.
        /// </returns>
        public static string GetDescription(this Enum value)
        {
            return !(value.GetType().GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() is DescriptionAttribute attribute) ? string.Empty : attribute.Description;
        }
    }
}