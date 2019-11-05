using System;

namespace SeeSharpEight
{
    public class PatternMatchingExample
    {
        public static void RunDemos()
        {
            Console.WriteLine($"{nameof(GetColorCode7)} {GetColorCode7("green")}");
            Console.WriteLine($"{nameof(GetColorCode8)} {GetColorCode8("green")}");
            Console.WriteLine($"{nameof(GetColorCode8Advanced)} {GetColorCode8Advanced("green", true)}");
            
            Console.WriteLine($"{nameof(GetWordLength)}(what) {GetWordLength("what")}");
            Console.WriteLine($"{nameof(GetWordLength)}(something) {GetWordLength("something")}");

            Console.WriteLine($"{nameof(GetPosition)} 0,0 {GetPosition((0, 0))}");
            Console.WriteLine($"{nameof(GetPosition)} 3,4 {GetPosition((3, 4))}");
        }

        static string GetColorCode7(string color)
        {
            switch (color)
            {
                case "red":
                    return "#FF0000";
                case "green":
                    return "#00FF00";
                case "blue":
                    return "#0000FF";
                default:
                    return "#000000";
            }
        }

        static string GetColorCode8(string color) => color switch
        {
            "red" => "#FF0000",
            "green" => "#00FF00",
            "blue" => "#0000FF",
            _ => "#000000"
        };

        static string GetColorCode8Advanced(string color, bool light) => color switch
        {
            "red" when light => "#FF5050",
            "green" when light => "#50FF50",
            "blue" when light => "#5050FF",
            "red" => "#FF0000",
            "green" => "#00FF00",
            "blue" => "#0000FF",
            _ when light => "#FFFFFF",
            _ => "#000000"
        };

        static string GetWordLength(string word) => word switch
        {
            { Length: 3 } => "three",
            { Length: 4 } => "four",
            _ => "Not three or four"
        };


        static string GetPosition((int x, int y) position) => position switch
        {
            { x: 0, y: 0 } => "center",
            (var x, var y) => $"x: {x} y: {y}"
        };
    }
}
