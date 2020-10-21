using System;
using Xunit;
using WorkDaysCalculator;

namespace WorkDaysCalculatorTest
{
    public class CalculatorUnitTest
    {
        [Fact]
        public void GetWorkingDays_DateSpanIsOneWeek_Return_5()
        {
            Calculator calculator = new Calculator();
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            for (int day = 1; day <= 20; day++)
            {
                DateTime start = new DateTime(year, month, day);
                DateTime end = start.AddDays(6);
                Assert.Equal(5, calculator.GetWorkingDays(start, end));
            }
        }

        [Fact]
        public void GetWorkingDays_DateSpanIsTwoWeeks_Return_10()
        {
            Calculator calculator = new Calculator();
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            for (int day = 1; day <= 20; day++)
            {
                DateTime start = new DateTime(year, month, day);
                DateTime end = start.AddDays(13);
                Assert.Equal(10, calculator.GetWorkingDays(start, end));
            }
        }
    }
}
