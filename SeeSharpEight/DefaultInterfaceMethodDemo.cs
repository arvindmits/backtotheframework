using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    public static class DefaultInterfaceMethodDemo
    {
        public static void RunDemos()
        {
            // static local functions are also new
            static double GetAbsoluteValue(INumber nr)
                => Math.Sqrt(nr.RealPart * nr.RealPart + nr.ImaginaryPart * nr.ImaginaryPart);

            RealNumber number1 = new RealNumber(-3.14);
            Console.WriteLine($"The RealPart of number1 equals {number1.RealPart}");
            // RealNumber only has an imaginary part when cast to INumber
            // Console.WriteLine($"The ImaginaryPart of number1 equals {number1.ImaginaryPart}");
            Console.WriteLine($"The absolute value of real number -3.14 equals {GetAbsoluteValue(number1)}");

            INumber number2 = new ComplexNumber(-1.5, 2);
            Console.WriteLine($"The RealPart of number2 equals {number2.RealPart}");
            Console.WriteLine($"The ImaginaryPart of number1 equals {number2.ImaginaryPart}");
            Console.WriteLine($"The absolute value of complex number -1.5+2i equals {GetAbsoluteValue(number2)}");
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
        private double _r;
        public RealNumber(double r) => _r = r;
        public double RealPart => _r;

        public override string ToString() => _r.ToString();
    }

    public class ComplexNumber : INumber
    {
        private double _r;
        private double _i;
        
        // This uses a positional pattern: no tuple is created here.
        public ComplexNumber(double r, double i) => (_r, _i) = (r, i); 
        public double RealPart => _r;
        public double ImaginaryPart => _i;
    }
}