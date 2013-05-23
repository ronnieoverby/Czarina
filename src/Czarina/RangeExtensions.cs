using System;
using System.Collections.Generic;
using System.Linq;

namespace Czarina.Generator
{
    public static class RangeExtensions
    {
        public static IEnumerable<long> To(this long from, long to, long step = 1)
        {
            ValidateStep(step);
            return ToInternal(from, to, step).Select(d => (long)d);
        }

        public static IEnumerable<int> To(this int from, int to, int step = 1)
        {
            ValidateStep(step);
            return ToInternal(from, to, step).Select(d => (int)d);
        }

        public static IEnumerable<short> To(this short from, short to, short step = 1)
        {
            ValidateStep(step);
            return ToInternal(from, to, step).Select(d => (short)d);
        }

        public static IEnumerable<byte> To(this byte from, byte to, byte step = 1)
        {
            ValidateStep(step);
            return ToInternal(from, to, step).Select(d => (byte)d);
        }

        public static IEnumerable<decimal> To(this decimal from, decimal to, decimal step = 1)
        {
            ValidateStep((double) step);
            return ToInternal((double)from, (double)to, (double)step).Select(d => (decimal)d);
        }

        public static IEnumerable<float> To(this float from, float to, float step = 1)
        {
            ValidateStep(step);
            return ToInternal(from, to, step).Select(d => (float)d);
        }

        public static IEnumerable<double> To(this double from, double to, double step = 1)
        {
            ValidateStep(step);
            return from.ToInternal(to, step);
        }

        private static IEnumerable<double> ToInternal(this double from, double to, double step = 1)
        {

            double a = from, z = to;

            if (from > to && step > 0)
                step = -step;

            for (var i = a; step > 0 ? i <= z : i >= z; i += step)
                yield return i;
        }

        private static void ValidateStep(double step)
        {
            if (step == 0)
                throw new ArgumentOutOfRangeException("step", "step must be non zero");
        }
    }
}