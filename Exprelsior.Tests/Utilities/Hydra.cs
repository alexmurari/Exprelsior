namespace Exprelsior.Tests.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Cut off one property, and two more shall take it's place.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Hydra
    {
        //// Strings

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        ///     Gets or sets the string array.
        /// </summary>
        public string[] StringArray { get; set; }

        /// <summary>
        ///     Gets or sets the string collection.
        /// </summary>
        public ICollection<string> StringCollection { get; set; }

        //// Chars

        /// <summary>
        ///     Gets or sets the char.
        /// </summary>
        public char Char { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed char.
        /// </summary>
        public char? NullableChar { get; set; }

        /// <summary>
        ///     Gets or sets the char array.
        /// </summary>
        public char[] CharArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed char array.
        /// </summary>
        public char?[] NullableCharArray { get; set; }

        /// <summary>
        ///     Gets or sets the char collection.
        /// </summary>
        public ICollection<char> CharCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed char collection.
        /// </summary>
        public ICollection<char?> NullableCharCollection { get; set; }

        //// Integers

        /// <summary>
        ///     Gets or sets the integer.
        /// </summary>
        public int Integer { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed integer.
        /// </summary>
        public int? NullableInteger { get; set; }

        /// <summary>
        ///     Gets or sets the integer array.
        /// </summary>
        public int[] IntegerArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed integer array.
        /// </summary>
        public int?[] NullableIntegerArray { get; set; }

        /// <summary>
        ///     Gets or sets the integer collection.
        /// </summary>
        public ICollection<int> IntegerCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed integer collection.
        /// </summary>
        public ICollection<int?> NullableIntegerCollection { get; set; }

        //// Floats

        /// <summary>
        ///     Gets or sets the float.
        /// </summary>
        public float Float { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed float.
        /// </summary>
        public float? NullableFloat { get; set; }

        /// <summary>
        ///     Gets or sets the float array.
        /// </summary>
        public float[] FloatArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed float array.
        /// </summary>
        public float?[] NullableFloatArray { get; set; }

        /// <summary>
        ///     Gets or sets the float collection.
        /// </summary>
        public ICollection<float> FloatCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed float collection.
        /// </summary>
        public ICollection<float?> NullableFloatCollection { get; set; }

        //// Doubles

        /// <summary>
        ///     Gets or sets the double.
        /// </summary>
        public double Double { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed double.
        /// </summary>
        public double? NullableDouble { get; set; }

        /// <summary>
        ///     Gets or sets the double array.
        /// </summary>
        public double[] DoubleArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed double array.
        /// </summary>
        public double?[] NullableDoubleArray { get; set; }

        /// <summary>
        ///     Gets or sets the double collection.
        /// </summary>
        public ICollection<double> DoubleCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed double collection.
        /// </summary>
        public ICollection<double?> NullableDoubleCollection { get; set; }

        //// Decimals

        /// <summary>
        ///     Gets or sets the decimal.
        /// </summary>
        public decimal Decimal { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed decimal.
        /// </summary>
        public decimal? NullableDecimal { get; set; }

        /// <summary>
        ///     Gets or sets the decimal array.
        /// </summary>
        public decimal[] DecimalArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed decimal array.
        /// </summary>
        public decimal?[] NullableDecimalArray { get; set; }

        /// <summary>
        ///     Gets or sets the decimal collection.
        /// </summary>
        public ICollection<decimal> DecimalCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed decimal collection.
        /// </summary>
        public ICollection<decimal?> NullableDecimalCollection { get; set; }

        //// DateTimes

        /// <summary>
        ///     Gets or sets the date and time.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed date and time.
        /// </summary>
        public DateTime? NullableDateTime { get; set; }

        /// <summary>
        ///     Gets or sets the date and time array.
        /// </summary>
        public DateTime[] DateTimeArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed date and time array.
        /// </summary>
        public DateTime?[] NullableDateTimeArray { get; set; }

        /// <summary>
        ///     Gets or sets the date and time collection.
        /// </summary>
        public ICollection<DateTime> DateTimeCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed date and time collection.
        /// </summary>
        public ICollection<DateTime?> NullableDateTimeCollection { get; set; }

        //// TimeSpans

        /// <summary>
        ///     Gets or sets the date and time.
        /// </summary>
        public TimeSpan TimeSpan { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed date and time.
        /// </summary>
        public TimeSpan? NullableTimeSpan { get; set; }

        /// <summary>
        ///     Gets or sets the date and time array.
        /// </summary>
        public TimeSpan[] TimeSpanArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed date and time array.
        /// </summary>
        public TimeSpan?[] NullableTimeSpanArray { get; set; }

        /// <summary>
        ///     Gets or sets the date and time collection.
        /// </summary>
        public ICollection<TimeSpan> TimeSpanCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed date and time collection.
        /// </summary>
        public ICollection<TimeSpan?> NullableTimeSpanCollection { get; set; }

        //// Booleans

        /// <summary>
        ///     Gets or sets a value indicating whether the boolean is true or false.
        /// </summary>
        public bool Boolean { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed boolean.
        /// </summary>
        public bool? NullableBoolean { get; set; }

        /// <summary>
        ///     Gets or sets the boolean array.
        /// </summary>
        public bool[] BooleanArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed boolean array.
        /// </summary>
        public bool?[] NullableBooleanArray { get; set; }

        /// <summary>
        ///     Gets or sets the boolean collection.
        /// </summary>
        public ICollection<bool> BooleanCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed boolean collection.
        /// </summary>
        public ICollection<bool?> NullableBooleanCollection { get; set; }

        //// GUIDs

        /// <summary>
        ///     Gets or sets the <see cref="System.Guid" />.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed <see cref="System.Guid" />.
        /// </summary>
        public Guid? NullableGuid { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="System.Guid" /> array.
        /// </summary>
        public Guid[] GuidArray { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed <see cref="System.Guid" /> array.
        /// </summary>
        public Guid?[] NullableGuidArray { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="System.Guid" /> collection.
        /// </summary>
        public ICollection<Guid> GuidCollection { get; set; }

        /// <summary>
        ///     Gets or sets the null allowed <see cref="System.Guid" /> collection.
        /// </summary>
        public ICollection<Guid?> NullableGuidCollection { get; set; }

        // Objects

        /////// <summary>
        /////// Gets or sets the object.
        /////// </summary>
        ////public object Object { get; set; }

        /////// <summary>
        /////// Gets or sets the object array.
        /////// </summary>
        ////public object[] ObjectArray { get; set; }

        /////// <summary>
        /////// Gets or sets the object collection.
        /////// </summary>
        ////public ICollection<object> ObjectCollection { get; set; }

        /////// <summary>
        /////// Gets or sets the object list.
        /////// </summary>
        ////public ArrayList ObjectList { get; set; }
    }
}