using System;
using System.Linq;

namespace WorkDaysCalculator
{
    public class Calculator
    {
        // https://stackoverflow.com/questions/1617049/calculate-the-number-of-business-days-between-two-dates
        public int GetWorkingDays(DateTime startDate, DateTime endDate)
        {
            int numberOfWeeks = (endDate.Subtract(startDate).Days + 1) / 7;
            int fullWeekWorkDays = numberOfWeeks * 5;
            int remainderDays = endDate.Subtract(startDate).Days - (numberOfWeeks * 7);
            int remainderWorkDays = Enumerable
                .Range(0, remainderDays + 1)
                .Select(x => startDate.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);

            return fullWeekWorkDays + remainderWorkDays;
        }
    }
}
