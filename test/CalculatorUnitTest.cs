using FluentAssertions;
using System;
using Xunit;
using WorkDaysCalculator;
using System.Collections.Generic;

namespace WorkDaysCalculatorTest
{
    public class CalculatorUnitTest
    {
        [Fact]
        public void GetWorkingDays_DateSpanIsOneWeek_Return_5()
        {
            Calculator calculator = new Calculator();

            foreach (DateTime date in GetTestDate())
            {
                calculator.GetWorkingDays(date, date.AddDays(6)).Should().Be(5);
            }
        }

        [Fact]
        public void GetWorkingDays_DateSpanIsThreeWeeks_Return_15()
        {
            Calculator calculator = new Calculator();

            foreach (DateTime date in GetTestDate())
            {
                calculator.GetWorkingDays(date, date.AddDays(20)).Should().Be(15);
            }
        }

        [Fact]
        public void GetWorkingDays_SameDaysWorkdays_Return_1()
        {
            Calculator calculator = new Calculator();

            foreach (DateTime date in GetTestDate())
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                calculator.GetWorkingDays(date, date).Should().Be(1);
            }
        }

        [Fact]
        public void GetWorkingDays_SameDaysWeekend_Return_0()
        {
            Calculator calculator = new Calculator();

            foreach (DateTime date in GetTestDate())
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    continue;
                }

                calculator.GetWorkingDays(date, date).Should().Be(0);
            }
        }

        [Fact]
        public void GetWorkingDays_WorkdaysToNextWorkdays_Return_6()
        {
            Calculator calculator = new Calculator();

            foreach (DateTime date in GetTestDate())
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                calculator.GetWorkingDays(date, date.AddDays(7)).Should().Be(6);
            }
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

        private IEnumerable<DateTime> GetTestDate()
        {
            for (DateTime date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                date.Day <= 7;
                date = date.AddDays(1))
            {
                yield return date;
            }
        }
    }
}
