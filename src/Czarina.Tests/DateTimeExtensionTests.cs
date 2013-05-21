using System;
using Czarina.Generator;
using NUnit.Framework;

namespace Czarina.Tests
{
    public class DateTimeExtensionTests
    {
        [Test,Repeat(100)]
        public void CanTruncateTicksPart()
        {
            var dt = RandomHelper.Instance.NextDateTime();
            var tdt = dt.Truncate(DateTimePrecision.Millisecond);
            Assert.AreEqual(0, tdt.Ticks%TimeSpan.TicksPerMillisecond);
        }

        [Test,Repeat(100)]
        public void CanTruncateMsPart()
        {
            var dt = RandomHelper.Instance.NextDateTime();
            var tdt = dt.Truncate(DateTimePrecision.Second);
            Assert.AreEqual(0, tdt.Ticks%TimeSpan.TicksPerSecond);
            Assert.AreEqual(0, tdt.Millisecond);
        }

        [Test,Repeat(100)]
        public void CanTruncateSecsPart()
        {
            var dt = RandomHelper.Instance.NextDateTime();
            var tdt = dt.Truncate(DateTimePrecision.Minute);
            Assert.AreEqual(0, tdt.Ticks%TimeSpan.TicksPerMinute);
            Assert.AreEqual(0, tdt.Second);
        }

        [Test, Repeat(100)]
        public void CanTruncateMinPart()
        {
            var dt = RandomHelper.Instance.NextDateTime();
            var tdt = dt.Truncate(DateTimePrecision.Hour);
            Assert.AreEqual(0, tdt.Ticks % TimeSpan.TicksPerHour);
            Assert.AreEqual(0, tdt.Minute);
        }

        [Test, Repeat(100)]
        public void CanTruncateHourPart()
        {
            var dt = RandomHelper.Instance.NextDateTime();
            var tdt = dt.Truncate(DateTimePrecision.Day);
            Assert.AreEqual(0, tdt.Ticks % TimeSpan.TicksPerDay);
            Assert.AreEqual(0, tdt.Hour);
        }

        [Test, Repeat(100)]
        public void CanTruncateDayPart()
        {
            var dt = RandomHelper.Instance.NextDateTime();
            var tdt = dt.Truncate(DateTimePrecision.Month);
            Assert.AreEqual(0, tdt.Ticks % TimeSpan.TicksPerDay);
            Assert.AreEqual(1, tdt.Day);
        }

        [Test, Repeat(100)]
        public void CanTruncateMonthPart()
        {
            var dt = RandomHelper.Instance.NextDateTime();
            var tdt = dt.Truncate(DateTimePrecision.Year);
            Assert.AreEqual(0, tdt.Ticks % TimeSpan.TicksPerDay);
            Assert.AreEqual(1, tdt.Day);
            Assert.AreEqual(1, tdt.Month);
        }  
        
        [Test,Repeat(100)]
        public void DtoCanTruncateTicksPart()
        {
            var dt = RandomHelper.Instance.NextDateTimeOffset();
            var tdt = dt.Truncate(DateTimePrecision.Millisecond);
            Assert.AreEqual(0, tdt.Ticks%TimeSpan.TicksPerMillisecond);
        }

        [Test,Repeat(100)]
        public void DtoCanTruncateMsPart()
        {
            var dt = RandomHelper.Instance.NextDateTimeOffset();
            var tdt = dt.Truncate(DateTimePrecision.Second);
            Assert.AreEqual(0, tdt.Ticks%TimeSpan.TicksPerSecond);
            Assert.AreEqual(0, tdt.Millisecond);
        }

        [Test,Repeat(100)]
        public void DtoCanTruncateSecsPart()
        {
            var dt = RandomHelper.Instance.NextDateTimeOffset();
            var tdt = dt.Truncate(DateTimePrecision.Minute);
            Assert.AreEqual(0, tdt.Ticks%TimeSpan.TicksPerMinute);
            Assert.AreEqual(0, tdt.Second);
        }

        [Test, Repeat(100)]
        public void DtoCanTruncateMinPart()
        {
            var dt = RandomHelper.Instance.NextDateTimeOffset();
            var tdt = dt.Truncate(DateTimePrecision.Hour);
            Assert.AreEqual(0, tdt.Ticks % TimeSpan.TicksPerHour);
            Assert.AreEqual(0, tdt.Minute);
        }

        [Test, Repeat(100)]
        public void DtoCanTruncateHourPart()
        {
            var dt = RandomHelper.Instance.NextDateTimeOffset();
            var tdt = dt.Truncate(DateTimePrecision.Day);
            Assert.AreEqual(0, tdt.Ticks % TimeSpan.TicksPerDay);
            Assert.AreEqual(0, tdt.Hour);
        }

        [Test, Repeat(100)]
        public void DtoCanTruncateDayPart()
        {
            var dt = RandomHelper.Instance.NextDateTimeOffset();
            var tdt = dt.Truncate(DateTimePrecision.Month);
            Assert.AreEqual(0, tdt.Ticks % TimeSpan.TicksPerDay);
            Assert.AreEqual(1, tdt.Day);
        }

        [Test, Repeat(100)]
        public void DtoCanTruncateMonthPart()
        {
            var dt = RandomHelper.Instance.NextDateTimeOffset();
            var tdt = dt.Truncate(DateTimePrecision.Year);
            Assert.AreEqual(0, tdt.Ticks % TimeSpan.TicksPerDay);
            Assert.AreEqual(1, tdt.Day);
            Assert.AreEqual(1, tdt.Month);
        }
    }
}