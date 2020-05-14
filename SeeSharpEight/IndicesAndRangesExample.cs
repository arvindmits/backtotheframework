using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using static System.Diagnostics.Trace;

namespace SeeSharpEight
{
    public class IndicesAndRangesExample
    {
        readonly char[] abc = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        public void RunDemos()
        {
            WriteLine($"Running demo {nameof(RunStringDemo)}");
            RunStringDemo();
            WriteLine($"Running demo {nameof(RunArrayDemo1)}");
            RunArrayDemo1();
            WriteLine($"Running demo {nameof(RunArrayDemo2)}");
            RunArrayDemo2();
            WriteLine($"Running demo {nameof(RunIListDemo)}");
            RunIListDemo();
        }

        [Fact]
        public void RunStringDemo()
        {
            const string anything = "anything";

            // Hat-operator indexes are one based.
            char lastCharOld = anything[anything.Length - 1];
            char lastCharNew = anything[^1];
            WriteLine($"the last chars of '{anything}' is {lastCharOld} = {lastCharNew}");

            string last4charsOld = anything.Substring(anything.Length - 4, 4);
            string last4charsNew = anything[^4..];
            WriteLine($"the last 4 chars of '{anything}' are {last4charsOld} - {last4charsNew}");
        }

        [Fact]
        public void RunArrayDemo1()
        {
            WriteLine("Running demos IndicesAndRangesExample");

            var indice1 = abc[^2];
            WriteLine($"abc[^2] = {indice1}");
            
            Index index = ^2;
            var indice2 = abc[index];
            WriteLine($"abc[{index}] = {indice1}");

            var range1 = abc[1..2];
            WriteLine($"abc[1..2] = {string.Join(',', range1)}");

            var comb1 = abc[^3..^1];
            WriteLine($"abc[^3..^1] = {string.Join(',', comb1)}");

            var comb2 = abc[^3..];
            WriteLine($"abc[^3..] = {string.Join(',', comb2)}");

            Range phrase = 1..4;
            var result = abc[phrase];
            WriteLine($"abc[{phrase}] = {string.Join(',', result)}");
        }

        [Fact]
        public void RunArrayDemo2()
        {
            //Batching
            const int batchSize = 3;

            for (var i = 0; i < abc.Length; i += batchSize)
            {
                var rangePhrase = new Range(i, Math.Min(abc.Length, i + 3));
                WriteLine($"Batch for {rangePhrase} = {string.Join(',', abc[rangePhrase])}");
            }
        }

        [Fact]
        public void RunIListDemo()
        {
            IList abcList = new List<char>(abc);

            // the compiler replaces the latter by the first
            var indiceOld = abcList[abcList.Count - 2];
            var indiceNew = abcList[^2];
            WriteLine($"abcList[^2] = {indiceOld} - {indiceNew}");

            // this won't work. Ranges only work with arrays and strings
            //Range phrase = 1..4;
            //var result = abcList[phrase];
            //WriteLine($"abcList[{phrase}] = {string.Join(',', result)}");
        }
    }
}
