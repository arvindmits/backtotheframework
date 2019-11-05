using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    public class IndicesAndRangesExample
    {
        static char[] abc = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        public static void RunDemos()
        {
            Console.WriteLine("Running demo 1");
            RunDemo1();
            Console.WriteLine("Running demo 2");
            RunDemo2();
        }
        public static void RunDemo1()
        {
            Console.WriteLine("Running demos IndicesAndRangesExample");

            var indice1 = abc[^2];
            Console.WriteLine($"abc[^2] = {indice1}");

            var range1 = abc[1..2];
            Console.WriteLine($"abc[1..2] = {string.Join(',', range1)}");

            var comb1 = abc[^3..^1];
            Console.WriteLine($"abc[^3..^1] = {string.Join(',', comb1)}");

            var comb2 = abc[^3..];
            Console.WriteLine($"abc[^3..] = {string.Join(',', comb2)}");

            Range phrase = 1..4;
            var result = abc[phrase];
            Console.WriteLine($"abc[{phrase}] = {string.Join(',', result)}");
        }

        public static void RunDemo2()
        {
            //Strings
            var anything = "anything";
            string last4charsOld = anything.Substring(anything.Length - 4, 4);
            string last4charsNew = anything[^4..];
            Console.WriteLine($"the last 4 chars of '{anything}' are {last4charsOld} - {last4charsNew}");

            //Batching
            var batchSize = 3;
            for (var i = 0; i < abc.Length; i += batchSize)
            {
                var rangePhrase = new Range(i, Math.Min(abc.Length, i + 3));
                Console.WriteLine($"Batch for {rangePhrase} = {string.Join(',', abc[rangePhrase])}");
            }
        }
    }
}
