using System;
using Czarina.Generator;
using NUnit.Framework;
using System.Linq;

namespace Czarina.Tests
{
    public class RangeTests
    {
        [Test]
        public void CanCreateRangeOneToFiveStepOne()
        {
            var range = 1.To(5);
            var expect = new[] {1, 2, 3, 4, 5};
            Assert.That(range.SequenceEqual(expect), Is.True);
        }

        [Test]
        public void CanCreateRangePointOneToPointF()
        {
            var range = .5.To(2.5, .5);
            var expect = new[] {.5, 1, 1.5, 2, 2.5};
            Assert.That(range.SequenceEqual(expect), Is.True);
        }

        [Test]
        public void CanCreateReverseRange5To1()
        {
            var range = 5.To(1).ToArray();
            var expect = new[] {5,4,3,2,1};
            Assert.That(range.SequenceEqual(expect), Is.True);
        }

        [Test]
        public void CanCreateFloatRange()
        {
            var range = 5f.To(1).ToArray();
            var expect = new[] {5, 4, 3, 2, 1f};
            Assert.That(range.SequenceEqual(expect), Is.True);
        }

        [Test]
        public void CanCreateShortRange()
        {
            const short a = 5;
            var range = a.To(1).ToArray();
            var expect = new short[] {5, 4, 3, 2, 1};
            Assert.That(range.SequenceEqual(expect), Is.True);
        }

        [Test]
        public void CanCreateByteRange()
        {
            const byte a = 5;
            var range = a.To(1).ToArray();
            var expect = new byte[] { 5, 4, 3, 2, 1 };
            Assert.That(range.SequenceEqual(expect), Is.True);
        }

        [Test]
        public void CanCreateDecimalRange()
        {
            const decimal a = 5;
            var range = a.To(1).ToArray();
            var expect = new decimal[] { 5, 4, 3, 2, 1 };
            Assert.That(range.SequenceEqual(expect), Is.True);
        }

        [Test]
        public void CantUseStepZero_ThrowsBeforeEnumeration()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 1.To(100, 0));
        }
    }
}