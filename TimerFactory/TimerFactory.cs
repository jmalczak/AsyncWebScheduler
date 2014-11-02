namespace AsyncWebScheduler.TimerFactory
{
    using System;

    using global::AsyncWebScheduler._Interfaces;

    public class TimerFactory : ITimerFactory
    {
        private readonly IDateTime dateTime;

        public TimerFactory(IDateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public ITimer CreateToRunAt(Action action, DateTime date)
        {
            return new Timer(new System.Threading.Timer(param => action(), null, date - this.dateTime.Now, System.Threading.Timeout.InfiniteTimeSpan));
        }

        public ITimer CreateToRunEvery(Action action, TimeSpan timeSpan)
        {
            return new Timer(new System.Threading.Timer(param => action(), null, timeSpan, timeSpan));
        }

        public ITimer CreateToRunEveryDayAt(Action action, TimeSpan timeSpanFromStartOfTheDay)
        {
            var now = this.dateTime.Now;
            var startOfTheDay = now.Date;

            if (now < startOfTheDay.Add(timeSpanFromStartOfTheDay))
            {
                return new Timer(new System.Threading.Timer(param => action(), null, startOfTheDay.Add(timeSpanFromStartOfTheDay) - now, TimeSpan.FromHours(24)));
            }
            
            return new Timer(new System.Threading.Timer(param => action(), null, startOfTheDay.AddDays(1).Add(timeSpanFromStartOfTheDay) - now, TimeSpan.FromHours(24)));
        }
    }
}