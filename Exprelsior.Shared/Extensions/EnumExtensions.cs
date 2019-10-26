namespace Exprelsior.Shared.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

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
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null)
                return null;

            var field = type.GetField(name);

            if (field == null)
                return null;

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                return attr.Description;

            return null;
        }
    }
}