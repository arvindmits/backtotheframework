using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace SeeSharpEight
{

    public class NullableReferenceTypesExampleDemo
    {
        public static void Run()
        {
            var nrte = new NullableReferenceTypesExample();
            nrte.DoSomething();
            nrte.SetData(null, null, 12);
        }
    }

    public class NullableReferenceTypesExample
    {
        string _emailaddress;
        SomeClass _someObject;
        int _luckyNumber;

        public NullableReferenceTypesExample()
        {

        }

        public void SetData(string emailAddress, SomeClass someObject, int luckyNumber)
        {
            _emailaddress = emailAddress;
            _someObject = someObject;
            _luckyNumber = luckyNumber;
        }

        public void ResetData()
        {
            _emailaddress = default;
            _someObject = default;
            _luckyNumber = default;
        }

        public void DoSomething()
        {
            Console.WriteLine(_someObject.Message);
            Console.WriteLine(_emailaddress.Length);
            Console.WriteLine(_luckyNumber);
        }
    }

    public class SomeClass
    {
        public string Message { get; set; } = "Hello world";
    }

}
#nullable restore