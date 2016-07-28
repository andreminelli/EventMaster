using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaster.Schedules
{
    public class WeeklySchedule : Schedule
    {
        private readonly TimeSpan Offset;
        private readonly TimeSpan Duration;
        private readonly DayOfWeek DayOfWeek;
        private readonly TimeSpan StartHour;

        public WeeklySchedule(DayOfWeek dayOfWeek, TimeSpan startHour, TimeSpan offset, TimeSpan duration)
        {
            StartHour = startHour;
            DayOfWeek = dayOfWeek;
            Duration = duration;
            Offset = offset;
        }

        public override DateTimeOffset GetNextEvent(DateTimeOffset currentDate)
        {
            currentDate = currentDate.ToOffset(Offset);
            var nextEvent = currentDate.UtcDateTime;

            if (nextEvent.DayOfWeek != DayOfWeek)
            {
                var adjustedDayOfWeek = (int)DayOfWeek;
                if (nextEvent.DayOfWeek > DayOfWeek)
                {
                    adjustedDayOfWeek = (int)DayOfWeek + 7;
                }
                nextEvent = nextEvent.AddDays(adjustedDayOfWeek - (int)nextEvent.DayOfWeek);
            }
            else if (nextEvent.TimeOfDay > StartHour)
            {
                nextEvent = nextEvent.AddDays(7);
            }

            nextEvent = nextEvent.Subtract(nextEvent.TimeOfDay).AddHours(StartHour.TotalHours);
            return nextEvent;
        }
    }
}
