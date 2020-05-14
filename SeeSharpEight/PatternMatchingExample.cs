using System;
using Xunit;
using static System.Diagnostics.Trace;

namespace SeeSharpEight
{
    public class PatternMatchingExample
    {
        [Fact]
        public void RunDemos()
        {
            WriteLine($"{nameof(GetColorCodeWithRegularSwitch)} {GetColorCodeWithRegularSwitch("green")}");
            WriteLine($"{nameof(GetColorCodeWithSwitchExpression)} {GetColorCodeWithSwitchExpression("green")}");
            WriteLine($"{nameof(GetColorCodeWithRegularSwitchAndWhenFilter)} {GetColorCodeWithRegularSwitchAndWhenFilter("green", true)}");
            WriteLine($"{nameof(GetColorCodeWithRegularSwitchAndFilterExpressions)} {GetColorCodeWithRegularSwitchAndFilterExpressions("green", true)}");
            WriteLine($"{nameof(GetColorCodeWithSwitchExpressionAndWhenFilter)} {GetColorCodeWithSwitchExpressionAndWhenFilter("green", true)}");

            WriteLine($"{nameof(GetWordLengthWithSwitchExpressionAndProperty)}(what) {GetWordLengthWithSwitchExpressionAndProperty("what")}");
            WriteLine($"{nameof(GetWordLengthWithSwitchExpressionAndProperty)}(something) {GetWordLengthWithSwitchExpressionAndProperty("something")}");

            WriteLine($"{nameof(GetPosition)} 0,0 {GetPosition(0, 0)}");
            WriteLine($"{nameof(GetPosition)} 3,4 {GetPosition(3, 4)}");
        }

        [Theory]
        [InlineData("green")]
        public string GetColorCodeWithRegularSwitch(string color)
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

        [Theory]
        [InlineData("green")]
        public string GetColorCodeWithSwitchExpression(string color) => color switch
        {
            "red" => "#FF0000",
            "green" => "#00FF00",
            "blue" => "#0000FF",
            _ => "#000000"
        };

        [Theory]
        [InlineData("green", true)]
        public string GetColorCodeWithRegularSwitchAndWhenFilter(string color, bool light)
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

        [Theory]
        [InlineData("green", true)]
        public string GetColorCodeWithRegularSwitchAndFilterExpressions(string color, bool light)
        {
            switch (color, light)
            {
                case ("red", true):
                    return "#FF5050";
                case ("green", true):
                    return "#50FF50";
                case ("blue", true):
                    return "#5050FF";
                case ("red", _):
                    return "#FF0000";
                case ("green", _):
                    return "#00FF00";
                case ("blue", _):
                    return "#0000FF";
                case (_, true):
                    return "#FFFFFF";
                default:
                    return "#000000";
            }
        }

        [Theory]
        [InlineData("green", true)]
        public string GetColorCodeWithSwitchExpressionAndWhenFilter(string color, bool light) => color switch
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

        [Theory]
        [InlineData("what")]
        [InlineData("something")]
        public string GetWordLengthWithSwitchExpressionAndProperty(string word) => word switch
        {
            { Length: 3 } => "three",
            { Length: 4 } => "four",
            _ => "Not three or four"
        };

        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 4)]
        public string GetPosition(int x, int y) => (x, y) switch
        {
            { x: 0, y: 0 } => "center",
            (var p, var q) => $"x: {p} y: {q}"
        };
    }
}
