using System;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var readOnlyMembersExample = new ReadOnlyMembersExample(DateTime.UtcNow);
            //var _ = readOnlyMembersExample.AddDaysNew(1);

            UsingDeclarationsExample.RunDemos();
            //NullCoalescingAssignmentExample.RunDemos();
            //IndicesAndRangesExample.RunDemos();
            //PatternMatchingExample.RunDemos();
            //await AsynchronousStreamsExample.RunDemos();

         
        }
    }


}
