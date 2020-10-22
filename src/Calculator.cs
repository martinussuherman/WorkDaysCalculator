using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkDaysCalculator
{
    public class Calculator
    {
        // https://stackoverflow.com/questions/1617049/calculate-the-number-of-business-days-between-two-dates
        public int GetWorkingDays(DateTime startDate, DateTime endDate)
        {
            int daySpan = endDate.Subtract(startDate).Days;
            int numberOfWeeks = (daySpan + 1) / 7;
            int fullWeekWorkDays = numberOfWeeks * 5;
            int remainderDays = daySpan - (numberOfWeeks * 7);
            int remainderWorkDays = Enumerable
                .Range(0, remainderDays + 1)
                .Select(x => startDate.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);

            return fullWeekWorkDays + remainderWorkDays;
        }

        public int GetWorkingDays(
            DateTime startDate,
            DateTime endDate,
            IEnumerable<DateTime> holidayList = null)
        {
            if (holidayList == null || holidayList.Count() == 0)
            {
                return GetWorkingDays(startDate, endDate);
            }

            // TODO : get holiday count and substract from working days
            return GetWorkingDays(startDate, endDate);
        }
    }
}
