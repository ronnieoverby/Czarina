using System;
using Czarina.Generator;
using NUnit.Framework;

namespace Czarina.Tests
{
    public class TimeSpanExtensionTests
    {
        [Test, Repeat(10000)]
        public void CanGenTimeSpan()
        {
            var ts = RandomHelper.Instance.NextTimeSpan();
            Assert.GreaterOrEqual(ts,TimeSpan.Zero);
        }

        [Test, Repeat(10000)]
        public void CanGenTimeSpanWithMax()
        {
            var max = TimeSpan.FromDays(1);
            var ts = RandomHelper.Instance.NextTimeSpan(max);
            Assert.Less(ts,max);
        }

        [Test, Repeat(10000)]
        public void CanGenTimeSpanWithMaxAndMin()
        {
            var min = TimeSpan.FromDays(5);
            var max = TimeSpan.FromDays(10);
            var ts = RandomHelper.Instance.NextTimeSpan(min, max);
            Assert.Less(ts,max);
            Assert.GreaterOrEqual(ts,min);
        }

        [Test, Repeat(10000)]
        public void CanGenTimeSpanWithMaxAndMinInNegativeRange()
        {
            var max = TimeSpan.FromDays(5).Negate();
            var min = TimeSpan.FromDays(10).Negate();
            var ts = RandomHelper.Instance.NextTimeSpan(min, max);
            Assert.Less(ts,max);
            Assert.GreaterOrEqual(ts,min);
        }

        [Test, Repeat(10000)]
        public void CanGenTimeSpanWithMaxAndMinInNegativeAndPositiveRange()
        {
            var min = TimeSpan.FromDays(5).Negate();
            var max = TimeSpan.FromDays(10);
            var ts = RandomHelper.Instance.NextTimeSpan(min, max);
            Assert.Less(ts,max);
            Assert.GreaterOrEqual(ts,min);
        }
    }
}