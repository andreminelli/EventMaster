using EventMaster.Schedules;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaster.Tests.Schedules
{
    public class WeeklyScheduleTests
    {
        private readonly WeeklySchedule Schedule;
        private readonly TimeSpan StartHour;

        public WeeklyScheduleTests()
        {
            StartHour = TimeSpan.FromHours(8.5);
            Schedule = new WeeklySchedule(DayOfWeek.Tuesday, StartHour, TimeSpan.Zero, TimeSpan.FromMinutes(90));
        }

        public void GetNextSchedule_OnSameDayOfWeekBeforeStartTime()
        {
            var someTuesday = new DateTimeOffset(2016, 8, 2, 0, 0, 0, TimeSpan.Zero);

            var nextSchedule = Schedule.GetNextEvent(someTuesday);

            var sameTuesday = new DateTimeOffset(2016, 8, 2, 8, 30, 0, TimeSpan.Zero);
            nextSchedule.ShouldBe(sameTuesday);
        }

        public void GetNextSchedule_OnSameDayOfWeekAfterStartTime()
        {
            var someTuesday = new DateTimeOffset(2016, 8, 2, 9, 0, 0, TimeSpan.Zero);

            var nextSchedule = Schedule.GetNextEvent(someTuesday);

            var nextTuesday = new DateTimeOffset(2016, 8, 9, 8, 30, 0, TimeSpan.Zero);
            nextSchedule.ShouldBe(nextTuesday);
        }

        public void GetNextSchedule_OnDayOfWeekAfterScheduleDayOfWeek()
        {
            var someSaturday = new DateTimeOffset(2016, 7, 30, 20, 0, 0, TimeSpan.Zero);

            var nextSchedule = Schedule.GetNextEvent(someSaturday);

            var nextTuesday = new DateTimeOffset(2016, 8, 2, 8, 30, 0, TimeSpan.Zero);
            nextSchedule.ShouldBe(nextTuesday);
        }

        public void GetNextSchedule_OnDayOfWeekBeforeScheduleDayOfWeek()
        {
            var someMonday = new DateTimeOffset(2016, 8, 1, 20, 0, 0, TimeSpan.Zero);

            var nextSchedule = Schedule.GetNextEvent(someMonday);

            var nextTuesday = new DateTimeOffset(2016, 8, 2, 8, 30, 0, TimeSpan.Zero);
            nextSchedule.ShouldBe(nextTuesday);
        }

    }
}
