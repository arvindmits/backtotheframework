using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            var readOnlyMembersExample = new ReadOnlyMembersExample(DateTime.UtcNow);
            var _ = readOnlyMembersExample.AddDaysNew(1);

            await new AsynchronousStreamsExample().RunDemos();
            await new UsingDeclarationsExample().RunDemos();
            new NullCoalescingAssignmentExample().RunDemos();
            new IndicesAndRangesExample().RunDemos();
            new PatternMatchingExample().RunDemos();
            new DefaultInterfaceMethodExample().RunDemos();
        }
    }
}
