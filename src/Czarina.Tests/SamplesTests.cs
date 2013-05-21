//using System;
//using System.Collections.Generic;
//using System.IO;
//using NUnit.Framework;
//using System.Linq;

//namespace Czarina.Tests
//{
//    public class SamplesTests
//    {
//        private const string XmlPath = @"..\Czarina\Samples\usa.xml";

//        [Test]
//        public void CanLoadSamples()
//        {
//            var samples = new Sampler();
//            samples.Load("states", "countries", "names");
//        }
//        [Test]
//        public void CanLoadSamplesDynamically()
//        {
//            var samples = new Sampler();
//            samples.Load(x => x.States.Countries.Names);
//        }

//        [Test]
//        public void CanGetSamples()
//        {
//            var samples = new Sampler();
//            samples.Load(x => x.States.Countries.Names.names.goats);
//        }


//        [Test]
//        public void CanAddToHashsetTwice()
//        {
//            var hs = new HashSet<string> { "ronnie", "ronnie", "goat", "goat" };
//            Assert.AreEqual(2, hs.Count);
//        }

//        [Test]
//        public void Test1()
//        {
//            var sampler = new Sampler();
//            sampler.Load(x => x.states);
//            var states = sampler.State;
//            foreach (var state in states.Select(s => new{s.name, s.abbr}))
//            {
//             state.   
//            }
//        }
//    }

//    public class Sampler
//    {
//        private readonly Dictionary<string, ISamples> _samples = new Dictionary<string, ISamples>();

//        public void Load(params string[] keys)
//        {
//            foreach (var key in keys)
//                LoadSamples(key);
//        }

//        public void Load(Func<dynamic, dynamic> keyCollector)
//        {
//            var c = new MemberNameCollector();
//            keyCollector(c);
//            Load(c.GetDynamicMemberNames().ToArray());
//        }

//        private void LoadSamples(string key)
//        {
//            if (_samples.ContainsKey(key))
//                return;

//            var file = ResolveFile(key);
//            if (!file.Exists)
//                throw new FileNotFoundException("File not found", file.FullName);

//            ISamples samples = ProduceSamples(file);
            

//        }

//        private FileInfo ResolveFile(string key)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    internal interface ISamples
//    {
//    }
//}