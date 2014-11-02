namespace AsyncWebScheduler.TimerFactory
{
    using System;

    using global::AsyncWebScheduler._Interfaces;

    public class TimerFactory : ITimerFactory
    {
        public ITimer CreateToRunAfter(Action action, TimeSpan timeSpan)
        {
            return new Timer(new System.Threading.Timer(param => action(), null, timeSpan, System.Threading.Timeout.InfiniteTimeSpan));
        }

        public ITimer CreateToRunEvery(Action action, TimeSpan timeSpan)
        {
            return new Timer(new System.Threading.Timer(param => action(), null, timeSpan, timeSpan));
        }
    }
}