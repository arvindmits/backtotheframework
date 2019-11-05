using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpEight
{
    public struct ReadOnlyMembersExample
    {
        private DateTime _currentDate;

        public ReadOnlyMembersExample(DateTime dateTime)
        {
            _currentDate = dateTime;
        }

        public /*readonly*/ DateTime AddDaysNew(int days)
        {
            _currentDate = _currentDate.AddDays(days);
            return _currentDate;

            //return _currentDate.AddDays(days);
        }

    }
}
