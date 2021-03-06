﻿namespace Exprelsior.Tests.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Bogus;
    using Bogus.Extensions;

    /// <summary>
    ///     Utilities for unit testing.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class Utilities
    {
        /// <summary>
        ///     The faker used to create dummy objects with fake data.
        /// </summary>
        private static readonly Faker Faker = new Faker();

        /// <summary>
        /// The hydra collection of objects filled with fake data.
        /// </summary>
        private static readonly List<Hydra> HydraCollection = GetFakeCollection(2000);

        /// <summary>
        ///     Gets an collection of <see cref="Hydra" /> objects filled with fake data.
        /// </summary>
        /// <returns>
        ///     The collection <see cref="Hydra" /> objects.
        /// </returns>
        internal static List<Hydra> GetFakeHydraCollection()
        {
            return HydraCollection;
        }

        /// <summary>
        ///     Gets an random item from the provided collection of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="collection">
        ///     The collection of <typeparamref name="T" />.
        /// </param>
        /// <typeparam name="T">
        ///     The type of the generic collection.
        /// </typeparam>
        /// <returns>
        ///     The random <typeparamref name="T" /> object.
        /// </returns>
        internal static T GetRandomItem<T>(IEnumerable<T> collection)
        {
            return Faker.Random.CollectionItem(collection.ToList());
        }

        /// <summary>
        ///     Gets an random collection of items from the provided collection of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="collection">
        ///     The collection of <typeparamref name="T" />.
        /// </param>
        /// <param name="count">
        ///     The number of elements to be returned.
        /// </param>
        /// <typeparam name="T">
        ///     The type of the generic collection.
        /// </typeparam>
        /// <returns>
        ///     The random collection of <typeparamref name="T" />.
        /// </returns>
        internal static T[] GetRandomItems<T>(IEnumerable<T> collection, int count = 5)
        {
            return Faker.Random.ArrayElements(collection.ToArray(), count);
        }

        /// <summary>
        ///     Generates a sequence of <see cref="DateTime"/> objects within a specified range.
        /// </summary>
        /// <param name="startDate">
        ///     The value of the first <see cref="DateTime"/> in the sequence.
        /// </param>
        /// <param name="endDate">
        ///     The value of the last <see cref="DateTime"/> in the sequence.
        /// </param>
        /// <returns>
        ///     The collection containing the range of <see cref="DateTime"/> objects.
        /// </returns>
        internal static IEnumerable<DateTime> Range(this DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d));
        }

        /// <summary>
        ///     Generates a sequence of <see cref="TimeSpan"/> objects within a specified range.
        /// </summary>
        /// <param name="startTime">
        ///     The value of the first <see cref="TimeSpan"/> in the sequence.
        /// </param>
        /// <param name="endTime">
        ///     The value of the last <see cref="TimeSpan"/> in the sequence.
        /// </param>
        /// <returns>
        ///     The collection containing the range of <see cref="TimeSpan"/> objects.
        /// </returns>
        internal static IEnumerable<TimeSpan> Range(this TimeSpan startTime, TimeSpan endTime)
        {
            return Enumerable.Range(0, (endTime - startTime).Hours + 1).Select(d => startTime.Add(new TimeSpan(0, d, 0, 0)));
        }

        /// <summary>
        ///     Gets a collection of fake objects.
        /// </summary>
        /// <param name="count">
        ///     The number of objects to be returned.
        /// </param>
        /// <returns>
        ///     The collection of fake objects.
        /// </returns>
        private static List<Hydra> GetFakeCollection(int count)
        {
            var hydraFaker = new Faker<Hydra>().StrictMode(true)

                //// Strings
                .RuleFor(t => t.FirstName, f => string.Concat(f.Name.Prefix(), " ", f.Name.FirstName() + f.Random.Number(10000)))
                .RuleFor(t => t.LastName, f => string.Concat(f.Name.LastName() + f.Random.Number(10000), " ", f.Name.Suffix()))
                .RuleFor(t => t.FullName, (f, p) => string.Concat(p.FirstName, " ", p.LastName))
                .RuleFor(t => t.StringArray, f => f.Random.WordsArray(25).Select(t => $"{t + f.Random.Number(10000)}").ToArray())
                .RuleFor(t => t.StringCollection, f => f.Random.WordsArray(25).Select(t => $"{t + f.Random.Number(10000)}").ToList())

                //// Chars
                .RuleFor(t => t.Char, f => f.Random.Char())
                .RuleFor(t => t.NullableChar, f => f.Random.Char().OrNull(f))
                .RuleFor(t => t.CharArray, f => f.Random.Chars(count: 5).Distinct().ToArray())
                .RuleFor(t => t.NullableCharArray, f => f.Random.Chars(count: 5).Distinct().Select(t => t.OrNull(f)).ToArray())
                .RuleFor(t => t.CharCollection, f => f.Random.Chars(count: 5).Distinct().ToList())
                .RuleFor(t => t.NullableCharCollection, f => f.Random.Chars(count: 5).Distinct().Select(t => t.OrNull(f)).ToList())

                //// Integers
                .RuleFor(t => t.Integer, f => f.Random.Int())
                .RuleFor(t => t.NullableInteger, f => f.Random.Int().OrNull(f))
                .RuleFor(t => t.IntegerArray, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).ToArray())
                .RuleFor(t => t.NullableIntegerArray, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => t.OrNull(f)).ToArray())
                .RuleFor(t => t.IntegerCollection, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).ToList())
                .RuleFor(t => t.NullableIntegerCollection, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => t.OrNull(f)).ToList())

                //// Floats
                .RuleFor(t => t.Float, f => (float)f.Random.Int() / 3)
                .RuleFor(t => t.NullableFloat, f => ((float)f.Random.Int() / 3).OrNull(f))
                .RuleFor(t => t.FloatArray, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => t / 3f).ToArray())
                .RuleFor(t => t.NullableFloatArray, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => (t / 3f).OrNull(f)).ToArray())
                .RuleFor(t => t.FloatCollection, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => t / 3f).ToList())
                .RuleFor(t => t.NullableFloatCollection, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => (t / 3f).OrNull(f)).ToList())

                //// Doubles
                .RuleFor(t => t.Double, f => (double)f.Random.Int() / 3)
                .RuleFor(t => t.NullableDouble, f => ((double)f.Random.Int() / 3).OrNull(f))
                .RuleFor(t => t.DoubleArray, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => t / 3d).ToArray())
                .RuleFor(t => t.NullableDoubleArray, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => (t / 3d).OrNull(f)).ToArray())
                .RuleFor(t => t.DoubleCollection, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => t / 3d).ToList())
                .RuleFor(t => t.NullableDoubleCollection, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => (t / 3d).OrNull(f)).ToList())

                //// Decimals
                .RuleFor(t => t.Decimal, f => (decimal)f.Random.Int() / 3)
                .RuleFor(t => t.NullableDecimal, f => ((decimal)f.Random.Int() / 3).OrNull(f))
                .RuleFor(t => t.DecimalArray, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => t / 3m).ToArray())
                .RuleFor(t => t.NullableDecimalArray, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => (t / 3m).OrNull(f)).ToArray())
                .RuleFor(t => t.DecimalCollection, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => t / 3m).ToList())
                .RuleFor(t => t.NullableDecimalCollection, f => GetRandomItems(Enumerable.Range(-2500, 5000), 50).Select(t => (t / 3m).OrNull(f)).ToList())

                //// DateTimes
                .RuleFor(t => t.DateTime, f => f.Date.Past())
                .RuleFor(t => t.NullableDateTime, f => f.Date.Future().OrNull(f))
                .RuleFor(t => t.DateTimeArray, f => GetRandomItems(f.Date.Soon().Range(f.Date.Soon().AddMonths(2))).ToArray())
                .RuleFor(t => t.NullableDateTimeArray, f => GetRandomItems(f.Date.Soon().Range(f.Date.Soon().AddMonths(2))).Select(t => t.OrNull(f)).ToArray())
                .RuleFor(t => t.DateTimeCollection, f => GetRandomItems(f.Date.Soon().Range(f.Date.Soon().AddMonths(2))).ToList())
                .RuleFor(t => t.NullableDateTimeCollection, f => GetRandomItems(f.Date.Soon().Range(f.Date.Soon().AddMonths(2))).Select(t => t.OrNull(f)).ToList())

                //// TimeSpans
                .RuleFor(t => t.TimeSpan, f => f.Date.Timespan())
                .RuleFor(t => t.NullableTimeSpan, f => f.Date.Timespan().OrNull(f))
                .RuleFor(t => t.TimeSpanArray, f => GetRandomItems(new TimeSpan(0, 2, 0, 9).Range(new TimeSpan(1, 6, 30, 5))).ToArray())
                .RuleFor(t => t.NullableTimeSpanArray, f => GetRandomItems(new TimeSpan(0, 2, 0, 9).Range(new TimeSpan(1, 6, 30, 5))).Select(t => t.OrNull(f)).ToArray())
                .RuleFor(t => t.TimeSpanCollection, f => GetRandomItems(new TimeSpan(0, 2, 0, 9).Range(new TimeSpan(1, 6, 30, 5))).ToList())
                .RuleFor(t => t.NullableTimeSpanCollection, f => GetRandomItems(new TimeSpan(0, 2, 0, 9).Range(new TimeSpan(1, 6, 30, 5))).Select(t => t.OrNull(f)).ToList())

                //// GUIDs
                .RuleFor(t => t.Guid, f => f.Random.Guid())
                .RuleFor(t => t.NullableGuid, f => f.Random.Guid().OrNull(f))
                .RuleFor(t => t.GuidArray, f => GetRandomItems(Enumerable.Range(1, 50).Select(t => f.Random.Guid())).ToArray())
                .RuleFor(t => t.NullableGuidArray, f => GetRandomItems(Enumerable.Range(1, 50).Select(t => f.Random.Guid().OrNull(f))).ToArray())
                .RuleFor(t => t.GuidCollection, f => GetRandomItems(Enumerable.Range(1, 50).Select(t => f.Random.Guid())).ToList())
                .RuleFor(t => t.NullableGuidCollection, f => GetRandomItems(Enumerable.Range(1, 50).Select(t => f.Random.Guid().OrNull(f))).ToList())

                //// Booleans
                .RuleFor(t => t.Boolean, f => f.Random.Bool())
                .RuleFor(t => t.NullableBoolean, f => f.Random.Bool().OrNull(f))
                .RuleFor(t => t.BooleanArray, f => GetRandomItems(Enumerable.Range(1, 100)).Select(t => t % 2 == 0).ToArray())
                .RuleFor(t => t.NullableBooleanArray, f => GetRandomItems(Enumerable.Range(1, 100)).Select(t => (t % 2 != 0).OrNull(f)).ToArray())
                .RuleFor(t => t.BooleanCollection, f => GetRandomItems(Enumerable.Range(1, 100)).Select(t => t % 2 == 0).ToList())
                .RuleFor(t => t.NullableBooleanCollection, f => GetRandomItems(Enumerable.Range(1, 100)).Select(t => (t % 2 != 0).OrNull(f)).ToList());

            return hydraFaker.Generate(count);
        }
    }
}