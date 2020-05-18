using System;
using System.Threading.Tasks;
using Xunit;
using static System.Diagnostics.Trace;

namespace SeeSharpEight
{
    public class UsingDeclarationsExample
    {
        public async Task RunDemos()
        {
            WriteLine("Running demo 1");
            Demo1();
            WriteLine("Running demo 2");
            Demo2();
            WriteLine("Running demo 3");
            await Demo3();
            WriteLine("Running demo 4");
            await Demo4();
        }

        [Fact]
        public void Demo1()
        {
            using (var sd1 = new SomethingDisposable())
            {
                WriteLine("Something1");
                using (var sd2 = new SomethingDisposable())
                {
                    WriteLine("Something2");
                };

                using (var sd3 = new SomethingDisposable())
                {
                    WriteLine("Something3");
                }
            }

            WriteLine("Something4");
        }

        [Fact]
        public void Demo2()
        {
            using var sd1 = new SomethingDisposable();
            WriteLine("Something 1");
            WriteLine("Something 2");
            using var sd2 = new SomethingDisposable();
            WriteLine("Something 3");
            if (true)
            {
                using var sd3 = new SomethingDisposable();
            }
            WriteLine("Something 4");
        }

        [Fact]
        public async Task Demo3()
        {
            using var sd1 = new SomethingDisposable();
            WriteLine("Something 1");
            await Task.Delay(1000);
            WriteLine("Something 2");
            using var sd2 = new SomethingDisposable();
            WriteLine("Something 3");
            if (true)
            {
                using var sd3 = new SomethingDisposable();
            }
            await Task.Delay(1000);
            WriteLine("Something 4");
        }

        [Fact]
        public async Task Demo4()
        {
            await using var sd1 = new SomethingAsyncDisposable();
            WriteLine("Something 1");
            WriteLine("Something 2");
            await using var sd2 = new SomethingAsyncDisposable();
            WriteLine("Something 3");
            if (true)
            {
                await using var sd3 = new SomethingAsyncDisposable();
            }
            WriteLine("Something 4");
        }
    }

    public class SomethingDisposable : IDisposable
    {
        public void Dispose()
        {
            WriteLine("=> SomethingDisposable is being Disposed");
        }
    }

    public class SomethingAsyncDisposable : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            WriteLine("=> SomethingAsyncDisposable will be Disposed");
            await Task.Delay(1000);
            WriteLine("=> SomethingAsyncDisposable is being Disposed");
        }
    }
}
