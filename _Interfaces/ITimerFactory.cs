namespace AsyncWebScheduler._Interfaces
{
    using System;

    public interface ITimerFactory
    {
        ITimer CreateToRunAfter(Action action, TimeSpan timeSpan);

        ITimer CreateToRunEvery(Action action, TimeSpan timeSpan); 
    }
}