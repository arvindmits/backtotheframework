using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    public class UsingDeclarationsExample
    {
        public async static Task RunDemos()
        {
            Console.WriteLine("Running demo 1");
            Demo1();
            Console.WriteLine("Running demo 2");
            Demo2();
            Console.WriteLine("Running demo 3");
            await Demo3();
            Console.WriteLine("Running demo 4");
            await Demo4();
        }

        public static void Demo1()
        {
            using (var sd1 = new SomethingDisposable())
            {
                Console.WriteLine("Something1");
                using (var sd2 = new SomethingDisposable())
                {
                    Console.WriteLine("Something2");
                };

                using (var sd3 = new SomethingDisposable())
                {
                    Console.WriteLine("Something3");
                }
            }

            Console.WriteLine("Something4");
        }

        public static void Demo2()
        {
            using var sd1 = new SomethingDisposable();
            Console.WriteLine("Something 1");
            Console.WriteLine("Something 2");
            using var sd2 = new SomethingDisposable();
            Console.WriteLine("Something 3");
            if (true)
            {
                using var sd3 = new SomethingDisposable();
            }
            Console.WriteLine("Something 4");
        }

        public async static Task Demo3()
        {
            using var sd1 = new SomethingDisposable();
            Console.WriteLine("Something 1");
            await Task.Delay(1000);
            Console.WriteLine("Something 2");
            using var sd2 = new SomethingDisposable();
            Console.WriteLine("Something 3");
            if (true)
            {
                using var sd3 = new SomethingDisposable();
            }
            await Task.Delay(1000);
            Console.WriteLine("Something 4");
        }

        public async static Task Demo4()
        {
            await using var sd1 = new SomethingAsyncDisposable();
            Console.WriteLine("Something 1");
            Console.WriteLine("Something 2");
            await using var sd2 = new SomethingAsyncDisposable();
            Console.WriteLine("Something 3");
            if (true)
            {
                await using var sd3 = new SomethingAsyncDisposable();
            }
            Console.WriteLine("Something 4");
        }
    }


    public class SomethingDisposable : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("=> SomethingDisposable is being Disposed");
        }
    }

    public class SomethingAsyncDisposable : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("=> SomethingAsyncDisposable will be Disposed");
            await Task.Delay(1000);
            Console.WriteLine("=> SomethingAsyncDisposable is being Disposed");
        }
    }
}
