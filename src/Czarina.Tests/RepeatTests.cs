using System.Collections.Generic;
using Czarina.Generator;
using NUnit.Framework;
using System.Linq;

namespace Czarina.Tests
{
    public class RepeatTests
    {
        private readonly string[] _people = new[] { "Ronnie", "Shane", "Brittney", "Tina", "Anna", "Lukus" };

        [Test]
        public void CanRepeatMyName()
        {
            const string name = "Ronnie";
            var arr = new[] { name, name, name };
            Assert.True(name.Repeat().Take(arr.Length).SequenceEqual(arr));
        }

        [Test]
        public void CanRepeatEachItemManyTimes()
        {
            const int times = 25;
            var rp = _people.RepeatEach(times);
            var list = new List<string>(_people.Length * times);

            foreach (var p in _people)
                for (var i = 0; i < times; i++)
                    list.Add(p);

            Assert.True(rp.SequenceEqual(list));
        }

        [Test]
        public void CanRepeatEachItemVariableTimes()
        {
            // items that are 5 characters are repeated twice
            var rp = _people.RepeatEach(p => p.Length == 5 ? 2 : 1);
            var list = new List<string>(_people.Length + _people.Count(x => x.Length == 5));

            foreach (var p in _people)
            {
                list.Add(p);
                if (p.Length == 5)
                    list.Add(p);
            }

            Assert.True(rp.SequenceEqual(list));
        }

        [Test]
        public void CanEnumerateRepeatedly()
        {
            var rep = _people.EnumerateRepeatedly().Take(_people.Length * 3);
            Assert.True(rep.SequenceEqual(_people.Concat(_people).Concat(_people)));

        }

        [Test]
        public void CanSelectRepeatedly()
        {
            // not a great test.... just checking interface existence I guess.....
            var seq = Enumerable.Range(1, 1000).ToArray();
            var randoms = seq.SelectOneRepeatedly(x => x.RandomElement()).Take(10000);
            var shuffles = seq.SelectRepeatedly(x => x.Shuffle()).Take(10000);
            Assert.False(randoms.SequenceEqual(shuffles));
        }

        [Test]
        public void BiasTest()
        {
            var biasDef = _people.ToDictionary(x => x, x => RandomHelper.Instance.Next(1000));

            var vals = _people.RepeatEach(x => biasDef[x]).ToArray()
                              .SelectRepeatedly(x => x.Shuffle())
                              .Take(1000).ToArray();

            var rep = vals
                .GroupBy(x => x)
                .Select(x => new { x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count).ToArray();
        }
    }

   
}