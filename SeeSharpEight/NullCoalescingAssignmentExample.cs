using Xunit;
using static System.Diagnostics.Trace;

namespace SeeSharpEight
{
    public class NullCoalescingAssignmentExample
    {
        public void RunDemos()
        {
            WriteLine("Running demo 1");
            Demo1();
            WriteLine("Running demo 2");
            Demo2();
            WriteLine("Running demo 3");
            Demo3();
        }

        [Fact]
        public void Demo1()
        {
            int? value = null;
            value = 1;
            value = 2;
            WriteLine(value);
        }

        [Fact]
        public void Demo2()
        {
            int? value = null;
            value ??= 1;
            value ??= 2;
            WriteLine(value);
        }

        [Fact]
        public void Demo3()
        {
            int? value1 = FirstOrDefault();
            int? value2 = 1;

            value2 ??= value1 ??= CreateNewItem();
            value1 ??= 99;

            WriteLine($"{value1} | {value2}");
        }

        public int? FirstOrDefault() => null;

        public int? CreateNewItem() => 50;
    }


}
