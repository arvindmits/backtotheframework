using Xunit;
using static System.Diagnostics.Trace;

#nullable disable

namespace SeeSharpEight
{

    public class NullableReferenceTypesExampleDemo
    {
        [Fact]
        public void Run()
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
            WriteLine(_someObject.Message);
            WriteLine(_emailaddress.Length);
            WriteLine(_luckyNumber);
        }
    }

    public class SomeClass
    {
        public string Message { get; set; } = "Hello world";
    }

}
#nullable restore