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

            for (int day = 1; day <= 7; day++)
            {
                DateTime start = new DateTime(year, month, day);
                DateTime end = start.AddDays(6);
                Assert.Equal(5, calculator.GetWorkingDays(start, end));
            }
        }

        [Fact]
        public void GetWorkingDays_DateSpanIsThreeWeeks_Return_15()
        {
            Calculator calculator = new Calculator();
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            for (int day = 1; day <= 7; day++)
            {
                DateTime start = new DateTime(year, month, day);
                DateTime end = start.AddDays(20);
                Assert.Equal(15, calculator.GetWorkingDays(start, end));
            }
        }

        [Fact]
        public void GetWorkingDays_SameDaysWorkdays_Return_1()
        {
            Calculator calculator = new Calculator();
            DateTime mon = new DateTime(2020, 10, 5);
            DateTime tue = new DateTime(2020, 10, 6);
            DateTime wed = new DateTime(2020, 10, 7);
            DateTime thu = new DateTime(2020, 10, 8);
            DateTime fri = new DateTime(2020, 10, 9);

            Assert.Equal(1, calculator.GetWorkingDays(mon, mon));
            Assert.Equal(1, calculator.GetWorkingDays(tue, tue));
            Assert.Equal(1, calculator.GetWorkingDays(wed, wed));
            Assert.Equal(1, calculator.GetWorkingDays(thu, thu));
            Assert.Equal(1, calculator.GetWorkingDays(fri, fri));
        }

        [Fact]
        public void GetWorkingDays_SameDaysWeekend_Return_0()
        {
            Calculator calculator = new Calculator();
            DateTime sat = new DateTime(2020, 10, 3);
            DateTime sun = new DateTime(2020, 10, 4);

            Assert.Equal(0, calculator.GetWorkingDays(sat, sat));
            Assert.Equal(0, calculator.GetWorkingDays(sun, sun));
        }

        [Fact]
        public void GetWorkingDays_SatToSun_Return_0()
        {
            Calculator calculator = new Calculator();
            DateTime sat = new DateTime(2020, 10, 3);
            DateTime sun = new DateTime(2020, 10, 4);

            Assert.Equal(0, calculator.GetWorkingDays(sat, sun));
        }

        [Fact]
        public void GetWorkingDays_SatToMon_Return_1()
        {
            Calculator calculator = new Calculator();
            DateTime sat = new DateTime(2020, 10, 3);
            DateTime mon = new DateTime(2020, 10, 5);

            Assert.Equal(1, calculator.GetWorkingDays(sat, mon));
        }

        [Fact]
        public void GetWorkingDays_WeekendToNextWeekend_Return_5()
        {
            Calculator calculator = new Calculator();
            DateTime sat = new DateTime(2020, 10, 3);
            DateTime sun = new DateTime(2020, 10, 4);
            DateTime nextSat = new DateTime(2020, 10, 10);
            DateTime nextSun = new DateTime(2020, 10, 11);

            Assert.Equal(5, calculator.GetWorkingDays(sat, nextSat));
            Assert.Equal(5, calculator.GetWorkingDays(sat, nextSun));
            Assert.Equal(5, calculator.GetWorkingDays(sun, nextSat));
            Assert.Equal(5, calculator.GetWorkingDays(sun, nextSun));
        }

        [Fact]
        public void GetWorkingDays_WorkdaysToNextWorkdays_Return_6()
        {
            Calculator calculator = new Calculator();
            DateTime start = new DateTime(2020, 10, 5);
            DateTime end = new DateTime(2020, 10, 9);

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                Assert.Equal(6, calculator.GetWorkingDays(date, date.AddDays(7)));
            }
        }
    }
}
