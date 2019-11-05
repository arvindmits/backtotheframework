using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    public class InterpolatedVerbatimStringsExample
    {
        string _c7 = $@"You could do this ¯\_(ツ)_/¯ {DateTime.UtcNow}";
        string _c8 = @$"Now you can do this ¯\_(ツ)_/¯ {DateTime.UtcNow}";
    }
}
