using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    public class NullCoalescingAssignmentExample
    {
        public static void RunDemos()
        {
            Console.WriteLine("Running demo 1");
            Demo1();
            Console.WriteLine("Running demo 2");
            Demo2();
            Console.WriteLine("Running demo 3");
            Demo3();
        }

        public static void Demo1()
        {
            int? value = null;
            value = 1;
            value = 2;
            Console.WriteLine(value);
        }

        public static void Demo2()
        {
            int? value = null;
            value ??= 1;
            value ??= 2;
            Console.WriteLine(value);
        }

        public static void Demo3()
        {
            int? value1 = FirstOrDefault();
            int? value2 = 1;

            value2 ??= value1 ??= CreateNewItem();
            value1 ??= 99;

            Console.WriteLine($"{value1} | {value2}");
        }

        public static int? FirstOrDefault() => null;

        public static int? CreateNewItem() => 50;
    }


}
