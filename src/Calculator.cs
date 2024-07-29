using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkDaysCalculator
{
    public class Calculator
    {
        public DayOfWeek[] DefaultWeekEnd
        {
            get
            {
                return _defaultWeekEnd;
            }
            set
            {
                _defaultWeekEnd = value;
            }
        }

        public int GetWorkingDays(DateTime startDate, DateTime endDate)
        {
            return GetWorkingDays(startDate, endDate, _defaultWeekEnd);
        }
        public int GetWorkingDays(
            DateTime startDate,
            DateTime endDate,
            IEnumerable<DayOfWeek> weekEndList)
        {
            int daySpan = endDate.Subtract(startDate).Days;
            int numberOfWeeks = (daySpan + 1) / 7;
            int fullWeekWorkDays = numberOfWeeks * (7 - _defaultWeekEnd.Length);
            int remainderDays = daySpan - (numberOfWeeks * 7);
            int remainderWorkDays = Enumerable
                .Range(0, remainderDays + 1)
                .Select(x => startDate.AddDays(x))
                .Count(x => !weekEndList.Contains(x.DayOfWeek));

            return fullWeekWorkDays + remainderWorkDays;
        }
        public int GetWorkingDays(
            DateTime startDate,
            DateTime endDate,
            IEnumerable<DateTime> holidayList = null)
        {
            return GetWorkingDays(startDate, endDate) -
                CountHolidays(startDate, endDate, _defaultWeekEnd, holidayList);
        }

        private int CountHolidays(
            DateTime startDate,
            DateTime endDate,
            IEnumerable<DayOfWeek> weekEndList,
            IEnumerable<DateTime> holidayList)
        {
            if (holidayList == null || holidayList.Count() == 0)
            {
                return 0;
            }

            return holidayList.Count(x =>
                x.Date >= startDate &&
                x.Date <= endDate &&
                !weekEndList.Contains(x.DayOfWeek));
        }

        private DayOfWeek[] _defaultWeekEnd = { DayOfWeek.Saturday, DayOfWeek.Sunday };
    }
}
