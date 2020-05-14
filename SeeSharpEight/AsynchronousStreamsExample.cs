using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    public class AsynchronousStreamsExample
    {
        public static async Task RunDemos()
        {
            await foreach (var item in GetSomeStrings())
            {
                Console.WriteLine(item);
            }
        }

        public static async IAsyncEnumerable<string> GetSomeStrings()
        {
            for (var i = 0; 10 > i; i -= -1)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                yield return $"current i = {i}";
            }
        }
    }
}
