using System;

namespace EventMaster
{
    public abstract class Schedule
    {
        public DateTimeOffset GetNextEvent() => GetNextEvent(DateTimeOffset.Now);

        public abstract DateTimeOffset GetNextEvent(DateTimeOffset currentDate);
    }
}