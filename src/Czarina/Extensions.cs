using System;
using System.Collections.Generic;
using System.Linq;

namespace Czarina.Generator
{
    public static class Extensions
    {
        /// <summary>
        /// Repeatedly invokes the delegate for each item in the enumeration, yielding the results.
        /// </summary>
        public static IEnumerable<T> SelectRepeatedly<T, TSource>(this TSource source, Func<TSource, IEnumerable<T>> func)
            where TSource:IEnumerable<T>
        {
            while (true)
                foreach (var item in func(source))
                    yield return item;
        }

        /// <summary>
        /// Repeatedly invokes the delegate, yielding the result.
        /// </summary>
        public static IEnumerable<T> SelectOneRepeatedly<T, TSource>(this TSource source, Func<TSource, T> func)
            where TSource : IEnumerable<T>
        {
            while (true) yield return func(source);
        }

        /// <summary>
        /// Shuffles an enumeration of items.
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng = null)
        {
            return source.ToArray().Shuffle(rng);
        }

        /// <summary>
        /// Shuffles a collection of items.
        /// </summary>
        /// <thanks to="Jon Skeet">http://stackoverflow.com/a/1287572/64334</thanks>
        public static IEnumerable<T> Shuffle<T>(this IList<T> list, Random rng = null)
        {
            rng = rng ?? RandomHelper.Instance;
            var elements = new T[list.Count];
            list.CopyTo(elements, 0);
            for (var i = elements.Length - 1; i >= 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                // ... except we don't really need to swap it fully, as we can
                // return it immediately, and afterwards it's irrelevant.
                var swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }

        /// <summary>
        /// Yields an object indefinetely.
        /// </summary>
        public static IEnumerable<T> Repeat<T>(this T source)
        {
            while (true) yield return source;
        }

        /// <summary>
        /// Repeatedly invokes the delegate and yields it's result.
        /// </summary>
        public static IEnumerable<T> InvokeRepeatedly<T>(this Func<T> func)
        {
            while (true) yield return func();
        }

        /// <summary>
        /// Repeatedly invokes the delegate and flattening and yielding it's results.
        /// </summary>
        public static IEnumerable<T> InvokeRepeatedly<T>(this Func<IEnumerable<T>> source)
        {
            while (true)
                foreach (var item in source())
                    yield return item;
        }

        /// <summary>
        /// Repeatedly yields the collection's items.
        /// </summary>
        public static IEnumerable<T> EnumerateRepeatedly<T>(this IEnumerable<T> source)
        {
            return new Func<IEnumerable<T>>(() => source).InvokeRepeatedly();
        }

        /// <summary>
        /// Invokes countFunc for each element, yielding the element the resulting number of times.
        /// </summary>
        public static IEnumerable<T> RepeatEach<T>(this IEnumerable<T> source, Func<T, int> countFunc)
        {
            return source.SelectMany(x =>
                {
                    var count = countFunc(x);
                    return x.Repeat().Take(count);
                });
        }

        /// <summary>
        /// Yields each element the specified number of times
        /// </summary>
        public static IEnumerable<T> RepeatEach<T>(this IEnumerable<T> source, int count)
        {
            return source.RepeatEach(x => count);
        }

        /// <thanks to="Jon Skeet">http://stackoverflow.com/a/648240/64334</thanks>
        public static T RandomElement<T>(this IEnumerable<T> source, Random rng = null)
        {
            if (source == null) throw new ArgumentNullException("source");
            rng = rng ?? RandomHelper.Instance;

            var list = source as IList<T>;
            if (list != null) return list.RandomElement();

            var current = default(T);
            var count = 0;
            foreach (var element in source)
            {
                count++;
                if (rng.Next(count) == 0)
                    current = element;
            }

            if (count == 0)
                throw new InvalidOperationException("Sequence was empty");

            return current;
        }

        // more efficient for collections with an indexer
        public static T RandomElement<T>(this IList<T> list, Random rng = null)
        {
            if (list == null) throw new ArgumentNullException("list");
            rng = rng ?? RandomHelper.Instance;

            if (list.Count == 0)
                throw new InvalidOperationException("List was empty");

            rng = rng ?? RandomHelper.Instance;
            var i = rng.Next(list.Count);
            var element = list[i];
            return element;
        }

        public static T NextElement<T>(this Random rng, IEnumerable<T> enumerable)
        {
            return enumerable.RandomElement(rng);
        }

        public static T NextElement<T>(this Random rng, IList<T> list)
        {
            return list.RandomElement(rng);
        }

        public static bool NextBool(this Random rng)
        {
            return rng.NextDouble() < .5;
        }

        /// <summary>
        /// Returns an Int32 with a random value across the entire range of
        /// possible values.
        /// </summary>
        /// <thanks to="Jon Skeet">http://stackoverflow.com/a/609529/64334</thanks>
        public static int NextInt32(this Random rng)
        {
            unchecked
            {
                var firstBits = rng.Next(0, 1 << 4) << 28;
                var lastBits = rng.Next(0, 1 << 28);
                return firstBits | lastBits;
            }
        }

        /// <thanks to="Jon Skeet">http://stackoverflow.com/a/609529/64334</thanks>
        public static decimal NextDecimal(this Random rng)
        {
            var scale = (byte)rng.Next(29);
            var sign = rng.NextBool();
            return new decimal(rng.NextInt32(),
                               rng.NextInt32(),
                               rng.NextInt32(),
                               sign,
                               scale);
        }

        /// <summary>
        /// Returns a random long from min (inclusive) to max (exclusive)
        /// </summary>
        /// <param name="random">The given random instance</param>
        /// <param name="min">The inclusive minimum bound</param>
        /// <param name="max">The exclusive maximum bound.  Must be greater than min</param>
        /// <thanks>http://stackoverflow.com/a/13095144/64334</thanks>
        public static long NextLong(this Random random, long min, long max)
        {
            if (max <= min)
                throw new ArgumentOutOfRangeException("max", "max must be > min!");

            //Working with ulong so that modulo works correctly with values > long.MaxValue
            var uRange = (ulong)(max - min);

            //Prevent a modolo bias; see http://stackoverflow.com/a/10984975/238419
            //for more information.
            //In the worst case, the expected number of calls is 2 (though usually it's
            //much closer to 1) so this loop doesn't really hurt performance at all.
            ulong ulongRand;
            do
            {
                var buf = new byte[8];
                random.NextBytes(buf);
                ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
            } while (ulongRand > UInt64.MaxValue - ((UInt64.MaxValue % uRange) + 1) % uRange);

            return (long)(ulongRand % uRange) + min;
        }

        /// <summary>
        /// Returns a random long from 0 (inclusive) to max (exclusive)
        /// </summary>
        /// <param name="random">The given random instance</param>
        /// <param name="max">The exclusive maximum bound.  Must be greater than 0</param>
        /// <thanks>http://stackoverflow.com/a/13095144/64334</thanks>
        public static long NextLong(this Random random, long max)
        {
            return random.NextLong(0, max);
        }

        /// <summary>
        /// Returns a random long over all possible values of long (except long.MaxValue, similar to
        /// random.Next())
        /// </summary>
        /// <param name="random">The given random instance</param>
        /// <thanks>http://stackoverflow.com/a/13095144/64334</thanks>
        public static long NextLong(this Random random)
        {
            return random.NextLong(Int64.MinValue, Int64.MaxValue);
        }

        public static DateTimeOffset NextDateTimeOffset(this Random rng)
        {
            return rng.NextDateTimeOffset(DateTimeOffset.MaxValue);
        }

        public static DateTimeOffset NextDateTimeOffset(this Random rng, DateTimeOffset max)
        {
            return rng.NextDateTimeOffset(DateTimeOffset.MinValue, max);
        }

        public static DateTimeOffset NextDateTimeOffset(this Random rng, DateTimeOffset min, DateTimeOffset max)
        {
            return new DateTimeOffset(rng.NextLong(min.Ticks, max.Ticks), max.Offset);
        }

        public static DateTime NextDateTime(this Random rng)
        {
            return rng.NextDateTime(DateTime.MaxValue);
        }

        public static DateTime NextDateTime(this Random rng, DateTime max)
        {
            return rng.NextDateTime(DateTime.MinValue, max);
        }

        public static DateTime NextDateTime(this Random rng, DateTime min, DateTime max)
        {
            return new DateTime(rng.NextLong(min.Ticks, max.Ticks), max.Kind);
        }

        public static TimeSpan NextTimeSpan(this Random rng)
        {
            return rng.NextTimeSpan(TimeSpan.MaxValue);
        }

        public static TimeSpan NextTimeSpan(this Random rng, TimeSpan max)
        {
            return rng.NextTimeSpan(TimeSpan.Zero, max);
        }

        public static TimeSpan NextTimeSpan(this Random rng, TimeSpan min, TimeSpan max)
        {
            return new TimeSpan(rng.NextLong(min.Ticks, max.Ticks));
        }

        public static DateTime Truncate(this DateTime dt, DateTimePrecision precision = DateTimePrecision.Millisecond)
        {
            switch (precision)
            {
                case DateTimePrecision.Millisecond:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond,
                                        dt.Kind);
                case DateTimePrecision.Second:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0, dt.Kind);
                case DateTimePrecision.Minute:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, dt.Kind);
                case DateTimePrecision.Hour:
                    return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, 0, dt.Kind);
                case DateTimePrecision.Day:
                    return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Kind);
                case DateTimePrecision.Month:
                    return new DateTime(dt.Year, dt.Month, 1, 0, 0, 0, 0, dt.Kind);
                case DateTimePrecision.Year:
                    return new DateTime(dt.Year, 1, 1, 0, 0, 0, 0, dt.Kind);
                default:
                    throw new ArgumentOutOfRangeException("precision");
            }
        }

        public static DateTimeOffset Truncate(this DateTimeOffset dt, DateTimePrecision precision = DateTimePrecision.Millisecond)
        {
            switch (precision)
            {
                case DateTimePrecision.Millisecond:
                    return new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond,
                                              dt.Offset);
                case DateTimePrecision.Second:
                    return new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, 0, dt.Offset);
                case DateTimePrecision.Minute:
                    return new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, dt.Offset);
                case DateTimePrecision.Hour:
                    return new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0, 0, dt.Offset);
                case DateTimePrecision.Day:
                    return new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, dt.Offset);
                case DateTimePrecision.Month:
                    return new DateTimeOffset(dt.Year, dt.Month, 1, 0, 0, 0, 0, dt.Offset);
                case DateTimePrecision.Year:
                    return new DateTimeOffset(dt.Year, 1, 1, 0, 0, 0, 0, dt.Offset);
                default:
                    throw new ArgumentOutOfRangeException("precision");
            }
        }

        public static double TotalYears(this TimeSpan timeSpan)
        {
            return timeSpan.TotalDays / Constants.DaysPerYear;
        }

        public static double TotalMonths(this TimeSpan timeSpan)
        {
            return timeSpan.TotalYears() * 12;
        }

        public static void Dispose(this IEnumerable<IDisposable> disposables)
        {
            foreach (var d in disposables)
                d.Dispose();
        }
    }
}
