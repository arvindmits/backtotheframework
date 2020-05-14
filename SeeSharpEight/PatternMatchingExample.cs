using System;

namespace SeeSharpEight
{
    public class PatternMatchingExample
    {
        public static void RunDemos()
        {
            Console.WriteLine($"{nameof(GetColorCodeWithRegularSwitch)} {GetColorCodeWithRegularSwitch("green")}");
            Console.WriteLine($"{nameof(GetColorCodeWithSwitchExpression)} {GetColorCodeWithSwitchExpression("green")}");
            Console.WriteLine($"{nameof(GetColorCodeWithRegularSwitchAndWhenFilter)} {GetColorCodeWithRegularSwitchAndWhenFilter("green", true)}");
            Console.WriteLine($"{nameof(GetColorCodeWithRegularSwitchAndFilterExpressions)} {GetColorCodeWithRegularSwitchAndFilterExpressions("green", true)}");
            Console.WriteLine($"{nameof(GetColorCodeWithSwitchExpressionAndWhenFilter)} {GetColorCodeWithSwitchExpressionAndWhenFilter("green", true)}");

            Console.WriteLine($"{nameof(GetWordLengthWithSwitchExpressionAndProperty)}(what) {GetWordLengthWithSwitchExpressionAndProperty("what")}");
            Console.WriteLine($"{nameof(GetWordLengthWithSwitchExpressionAndProperty)}(something) {GetWordLengthWithSwitchExpressionAndProperty("something")}");

            Console.WriteLine($"{nameof(GetPosition)} 0,0 {GetPosition((0, 0))}");
            Console.WriteLine($"{nameof(GetPosition)} 3,4 {GetPosition((3, 4))}");
        }

        static string GetColorCodeWithRegularSwitch(string color)
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

        static string GetColorCodeWithSwitchExpression(string color) => color switch
        {
            "red" => "#FF0000",
            "green" => "#00FF00",
            "blue" => "#0000FF",
            _ => "#000000"
        };

        static string GetColorCodeWithRegularSwitchAndWhenFilter(string color, bool light)
        {
            switch (color)
            {
                case "red" when light:
                    return "#FF5050";
                case "green" when light:
                    return "#50FF50";
                case "blue" when light: 
                    return "#5050FF";
                case "red": 
                    return "#FF0000";
                case "green": 
                    return "#00FF00";
                case "blue": 
                    return "#0000FF";
                default: 
                    return light ? "#FFFFFF" : "#000000";
            }
        }

        static string GetColorCodeWithRegularSwitchAndFilterExpressions(string color, bool light)
        {
            switch (color, light)
            {
                case ("red",true):
                    return "#FF5050";
                case ("green", true):
                    return "#50FF50";
                case ("blue", true): 
                    return "#5050FF";
                case ("red", _): 
                    return "#FF0000";
                case ("green",_): 
                    return "#00FF00";
                case ("blue",_): 
                    return "#0000FF";
                case (_, true):
                    return "#FFFFFF";
                default: 
                    return "#000000";
            }
        }

        static string GetColorCodeWithSwitchExpressionAndWhenFilter(string color, bool light) => color switch
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

        static string GetWordLengthWithSwitchExpressionAndProperty(string word) => word switch
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
