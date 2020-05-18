using System;
using Xunit;
using static System.Diagnostics.Trace;

namespace SeeSharpEight
{
    public class DefaultInterfaceMethodExample
    {
        [Fact]
        public void RunDemos()
        {
            // local functions are also new
            double GetAbsoluteValue(INumber nr)
                => Math.Sqrt(nr.RealPart * nr.RealPart + nr.ImaginaryPart * nr.ImaginaryPart);

            RealNumber number1 = new RealNumber(-3.14);
            WriteLine($"The RealPart of number1 equals {number1.RealPart}");
            // RealNumber only has an imaginary part when cast to INumber
            // WriteLine($"The ImaginaryPart of number1 equals {number1.ImaginaryPart}");
            WriteLine($"The absolute value of real number -3.14 equals {GetAbsoluteValue(number1)}");

            INumber number2 = new ComplexNumber(-3, 4);
            WriteLine($"The RealPart of number2 equals {number2.RealPart}");
            WriteLine($"The ImaginaryPart of number1 equals {number2.ImaginaryPart}");
            WriteLine($"The absolute value of complex number -3+4i equals {GetAbsoluteValue(number2)}");
        }
    }

    public interface INumber
    {
        double RealPart { get; }

        // added later
        double ImaginaryPart { get => 0; }
    }

    public class RealNumber : INumber
    {
        public RealNumber(double r) => RealPart = r;
        public double RealPart { get; }

        public override string ToString() => RealPart.ToString();
    }

    public class ComplexNumber : INumber
    {

        // This uses a positional pattern: no tuple is created here.
        public ComplexNumber(double r, double i) => (RealPart, ImaginaryPart) = (r, i);
        public double RealPart { get; }
        public double ImaginaryPart { get; }
    }
}