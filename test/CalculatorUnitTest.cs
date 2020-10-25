using FluentAssertions;
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
                calculator.GetWorkingDays(start, end).Should().Be(5);
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
                calculator.GetWorkingDays(start, end).Should().Be(15);
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

            calculator.GetWorkingDays(mon, mon).Should().Be(1);
            calculator.GetWorkingDays(tue, tue).Should().Be(1);
            calculator.GetWorkingDays(wed, wed).Should().Be(1);
            calculator.GetWorkingDays(thu, thu).Should().Be(1);
            calculator.GetWorkingDays(fri, fri).Should().Be(1);
        }

        [Fact]
        public void GetWorkingDays_SameDaysWeekend_Return_0()
        {
            Calculator calculator = new Calculator();
            DateTime sat = new DateTime(2020, 10, 3);
            DateTime sun = new DateTime(2020, 10, 4);

            calculator.GetWorkingDays(sat, sat).Should().Be(0);
            calculator.GetWorkingDays(sun, sun).Should().Be(0);
        }

        [Fact]
        public void GetWorkingDays_SatToSun_Return_0()
        {
            Calculator calculator = new Calculator();
            DateTime sat = new DateTime(2020, 10, 3);
            DateTime sun = new DateTime(2020, 10, 4);

            calculator.GetWorkingDays(sat, sun).Should().Be(0);
        }

        [Fact]
        public void GetWorkingDays_SatToMon_Return_1()
        {
            Calculator calculator = new Calculator();
            DateTime sat = new DateTime(2020, 10, 3);
            DateTime mon = new DateTime(2020, 10, 5);

            calculator.GetWorkingDays(sat, mon).Should().Be(1);
        }

        [Fact]
        public void GetWorkingDays_WeekendToNextWeekend_Return_5()
        {
            Calculator calculator = new Calculator();
            DateTime sat = new DateTime(2020, 10, 3);
            DateTime sun = new DateTime(2020, 10, 4);
            DateTime nextSat = new DateTime(2020, 10, 10);
            DateTime nextSun = new DateTime(2020, 10, 11);

            calculator.GetWorkingDays(sat, nextSat).Should().Be(5);
            calculator.GetWorkingDays(sat, nextSun).Should().Be(5);
            calculator.GetWorkingDays(sun, nextSat).Should().Be(5);
            calculator.GetWorkingDays(sun, nextSun).Should().Be(5);
        }

        [Fact]
        public void GetWorkingDays_WorkdaysToNextWorkdays_Return_6()
        {
            Calculator calculator = new Calculator();
            DateTime start = new DateTime(2020, 10, 5);
            DateTime end = new DateTime(2020, 10, 9);

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                calculator.GetWorkingDays(date, date.AddDays(7)).Should().Be(6);
            }
        }
    }
}
