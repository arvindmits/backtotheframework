using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using static System.Diagnostics.Trace;

namespace SeeSharpEight
{
    public class AsynchronousStreamsExample
    {
        [Fact]
        public async Task RunDemos()
        {
            await foreach (var item in GetSomeStrings())
            {
                WriteLine(item);
            }
        }

        public async IAsyncEnumerable<string> GetSomeStrings()
        {
            for (var i = 0; 10 > i; i -= -1)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                yield return $"current i = {i}";
            }
        }
    }
}
