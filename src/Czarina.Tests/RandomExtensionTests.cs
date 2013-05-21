using System;
using Czarina.Generator;
using NUnit.Framework;

namespace Czarina.Tests
{
    public class RandomExtensionTests
    {
        [Test, Repeat(100000)]
        public void CanGenDateTime()
        {
            var dt = RandomHelper.Instance.NextDateTime();
            Assert.NotNull(dt);
        }

        [Test, Repeat(100000)]
        public void CanGenDateTimeWithMax()
        {
            var now = DateTime.Now;
            var dt = RandomHelper.Instance.NextDateTime(now);
            Assert.Less(dt, now);
        }

        [Test, Repeat(100000)]
        public void CanGenDateTimeWithMaxAndMin()
        {
            var bday = new DateTime(1984, 5, 10);
            var now = DateTime.Now;
            var dt = RandomHelper.Instance.NextDateTime(bday, now);
            Assert.GreaterOrEqual(dt, bday);
            Assert.Less(dt, now);
        }
    }
}
