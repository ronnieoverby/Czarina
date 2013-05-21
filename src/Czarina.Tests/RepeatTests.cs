using System;
using System.Collections.Generic;
using Czarina.Generator;
using NUnit.Framework;
using System.Linq;

namespace Czarina.Tests
{
    public class RepeatTests
    {
        private Random r = RandomHelper.Instance;

        [Test]
        public void test()
        {
            var seq = new[] { "Ronnie", "Shane", "Brittney", "Anna", "Tina", "Lukus" };

            var repSeq = seq.RepeatEach(x => 5).ToArray();
        }

        [Test]
        public void test2()
        {
            var seq = new[] { "Ronnie", "Shane", "Brittney", "Anna", "Tina", "Lukus" };

            var r = RandomHelper.Instance;
            var repSeq = seq.RepeatEach(x => r.Next(2)).ToArray();
        }

        [Test]
        public void BiasTest1()
        {
            var seq = new Dictionary<string, int>
                {
                    {"Ronnie", 200},
                    {"Shane", 2},
                    {"Brittney", 1}
                };

            var vals = seq.Keys.RepeatEach(x => seq[x]).SelectRepeatedly(x => x.RandomElement()).Take(seq.Values.Sum() * 1000).ToArray();
            var rep = vals
                         .GroupBy(x => x)
                         .Select(x => new
                             {
                                 x.Key,
                                 Count = x.Count()
                             }).ToArray();

        }

        [Test]
        public void BiasTest2()
        {
            var seq = new Biaser<string>
                {
                    {"Ronnie", 200},
                    {"Shane", 2},
                    {"Brittney", 1} // normally not needed. default bias factor is 1. but using keys as source enumerable
                };

            var vals = seq.Keys.RepeatEach(x => seq[x]).SelectRepeatedly(x => x.RandomElement()).Take(seq.Values.Sum() * 1000).ToArray();
            var rep = vals
                         .GroupBy(x => x)
                         .Select(x => new
                             {
                                 x.Key,
                                 Count = x.Count()
                             }).ToArray();

        }
    }
}

public class Biaser<T> : Dictionary<T, int>
{
    // need function that takes in enumerable
    // returns a random element determined by
    // bias factors

    public T RandomElement(IEnumerable<T> enumerable = null)
    {
        enumerable = enumerable ?? Keys;

        // select one of the this.Keys (or something representing a default) according to its bias
        // if key was selected, return it
        // if default was selected return any other item in the enumerable

        // IDK about all this

        // ORRRR

        // treat bias factors as markings on a spectrum like: (may need to subtract 1 from all bias factors to reconcile with unbiased elements)
        // ----------10------------20----------------------------------------------100---------------------

        // and multiply the sum of the bias factors by random double between 0 and 1

        // if zero then default (random element)
        // else if <= 10 then take that one
        // etc
    }
}