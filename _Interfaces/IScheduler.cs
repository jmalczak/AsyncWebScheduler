namespace AsyncWebScheduler._Interfaces
{
    using System;

    public interface IScheduler
    {
        void RunEvery<T>(TimeSpan timeSpan) where T : ITask;

        void RunAt<T>(DateTime time) where T : ITask;
    }
}
