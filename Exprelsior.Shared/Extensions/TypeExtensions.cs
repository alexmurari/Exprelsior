namespace Exprelsior.Shared.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    ///     Provides extensions for the <see cref="Type" /> type.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class TypeExtensions
    {
        /// <summary>
        ///     The numeric types.
        /// </summary>
        public static readonly Type[] NumericTypes = 
        {
            typeof(byte), typeof(sbyte), typeof(ushort), typeof(uint), typeof(ulong), typeof(short), typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal)
        };

        /// <summary>
        ///     Returns a value indicating whether the provided type is a collection type.
        /// </summary>
        /// <remarks>
        ///     Although <see cref="string" /> implements <see cref="IEnumerable{T}" />, it is not considered a collection type by this method.
        /// </remarks>
        /// <param name="type">The type to be checked.</param>
        /// <returns><c>True</c> if it is a collection type; otherwise, <c>false</c>.</returns>
        public static bool IsCollection(this Type type)
        {
            if (type.IsString())
                return false;

            return type == typeof(IEnumerable) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>)) ||
                type.GetInterfaces().Any(t => t == typeof(IEnumerable) || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)));
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a <see cref="DateTime" /> type.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a <see cref="DateTime" /> type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDateTime(this Type type)
        {
            var (isNullable, underlyingType) = type.IsNullableType();

            if (isNullable)
                type = underlyingType;

            return type == typeof(DateTime);
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a <see cref="TimeSpan" /> type.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a <see cref="TimeSpan" /> type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTimeSpan(this Type type)
        {
            var (isNullable, underlyingType) = type.IsNullableType();

            if (isNullable)
                type = underlyingType;

            return type == typeof(TimeSpan);
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a generic collection type.
        /// </summary>
        /// <remarks>
        ///     Although <see cref="string" /> implements <see cref="IEnumerable{T}" />, it is not considered a generic collection type by this method.
        /// </remarks>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <param name="includeArrays">
        ///     The value that indicates whether <see cref="Array"/> objects should be considered generic collection types by this method.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a generic collection; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGenericCollection(this Type type, bool includeArrays = true)
        {
            if (type.IsString() || (!includeArrays && type.IsArray))
                return false;

            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                || type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a generic collection and the generic type parameter is the same as the provided type.
        /// </summary>
        /// <remarks>
        ///     Although <see cref="string" /> implements <see cref="IEnumerable{T}" />, it is not considered a collection type by this method.
        /// </remarks>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <param name="genericTypeArgument">
        ///     The generic type argument of the collection.
        /// </param>
        /// <param name="includeArrays">
        ///     The value that indicates whether <see cref="Array"/> objects should be considered generic collection types by this method.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a generic collection of the provided generic type argument; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGenericCollection(this Type type, Type genericTypeArgument, bool includeArrays = true)
        {
            if (type.IsString() || (!includeArrays && type.IsArray))
                return false;

            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>) && (type.GetGenericArguments()[0] == genericTypeArgument || Nullable.GetUnderlyingType(type.GetGenericArguments()[0]) == genericTypeArgument))
                || type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>) && (t.GetGenericArguments()[0] == genericTypeArgument || Nullable.GetUnderlyingType(t.GetGenericArguments()[0]) == genericTypeArgument));
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a generic collection and the generic type parameter is included in he specified type list.
        /// </summary>
        /// <remarks>
        ///     Although <see cref="string" /> implements <see cref="IEnumerable{T}" />, it is not considered a collection type by this method.
        /// </remarks>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <param name="genericTypeArguments">
        ///     The collection of generic type arguments of the collection.
        /// </param>
        /// <param name="includeArrays">
        ///     The value that indicates whether <see cref="Array"/> objects should be considered generic collection types by this method.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a generic collection of the provided generic type argument; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGenericCollection(this Type type, Type[] genericTypeArguments, bool includeArrays = true)
        {
            if (type.IsString() || (!includeArrays && type.IsArray))
                return false;

            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>) && genericTypeArguments.Contains(type.GetGenericArguments()[0]))
                || type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>) && genericTypeArguments.Contains(t.GetGenericArguments()[0]));
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a non-generic <see cref="IList" /> implementation.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a non-generic <see cref="IList" />; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNonGenericIList(this Type type)
        {
            return type == typeof(IList) || type.GetInterfaces().Any(t => t == typeof(IList));
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a numeric type.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a numeric type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumeric(this Type type)
        {
            var (isNullable, underlyingType) = type.IsNullableType();

            if (isNullable)
                type = underlyingType;

            return NumericTypes.Contains(type);
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a <see cref="string" /> type.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a <see cref="string"/> type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsString(this Type type)
        {
            return type == typeof(string);
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a <see cref="char" /> type.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a <see cref="char" /> type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsChar(this Type type)
        {
            var (isNullable, underlyingType) = type.IsNullableType();

            if (isNullable)
                type = underlyingType;

            return type == typeof(char);
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a <see cref="bool" /> type.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a <see cref="bool" /> type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBoolean(this Type type)
        {
            var (isNullable, underlyingType) = type.IsNullableType();

            if (isNullable)
                type = underlyingType;

            return type == typeof(bool);
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a <see cref="Guid" /> type.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     <c>True</c> if the type is a <see cref="Guid" /> type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGuid(this Type type)
        {
            var (isNullable, underlyingType) = type.IsNullableType();

            if (isNullable)
                type = underlyingType;

            return type == typeof(Guid);
        }

        /// <summary>
        ///     Returns a value indicating whether the provided type is a <see cref="Nullable{T}" /> type.
        /// </summary>
        /// <param name="type">
        ///     The type to be checked.
        /// </param>
        /// <returns>
        ///     A tuple consisting of a value indicating whether the provided type is a <see cref="Nullable{T}" /> type
        ///     and the type argument of the <see cref="Nullable{T}" /> representing the underlying type.
        /// </returns>
        public static (bool IsNullable, Type UnderlyingType) IsNullableType(this Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);

            return (underlyingType != null, underlyingType);
        }
    }
}