namespace AsyncWebScheduler._Interfaces
{
    using System;

    public interface ITimerFactory
    {
        ITimer CreateToRunAt(Action action, DateTime date);

        ITimer CreateToRunEvery(Action action, TimeSpan timeSpan);

        ITimer CreateToRunEveryDayAt(Action action, TimeSpan timeSpanFromStartOfTheDay);
    }
}