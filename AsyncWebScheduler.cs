namespace AsyncWebScheduler
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::AsyncWebScheduler._Interfaces;

    using global::AsyncWebScheduler.DateTime;

    using global::AsyncWebScheduler.Runner;

    using global::AsyncWebScheduler.TaskFactory;

    public class AsyncWebScheduler : IScheduler
    {
        private readonly List<ITimer> timers;

        private readonly ITaskFactory taskFactory;

        private readonly ITaskRunner taskRunner;

        private readonly IDateTime dateTime;

        private readonly ITimerFactory timerFactory;

        public AsyncWebScheduler(
            ITaskFactory taskFactory, 
            ITaskRunner taskRunner, 
            IDateTime dateTime,
            ITimerFactory timerFactory) : this()
        {
            this.taskFactory = taskFactory;
            this.taskRunner = taskRunner;
            this.dateTime = dateTime;
            this.timerFactory = timerFactory;
        }

        public AsyncWebScheduler(string baseUrl)
            : this()
        {
            this.taskFactory = new SimpleTaskFactory();
            this.taskRunner = new WebTaskRunner(baseUrl, WebTaskRunnerController.ActionFormat);
            this.dateTime = new DateTimeHelper();
            this.timerFactory = new TimerFactory.TimerFactory();

            WebTaskRunnerController.SetTaskFactory(this.taskFactory);
        }

        private AsyncWebScheduler()
        {
            this.timers = new List<ITimer>();
        }

        public void RunEvery<T>(TimeSpan timeSpan) where T : ITask
        {
            this.timers.Add(this.timerFactory.CreateToRunEvery(async () => { await this.Run<T>(); }, timeSpan));
        }

        public void RunAt<T>(System.DateTime time) where T : ITask
        {
            this.timers.Add(this.timerFactory.CreateToRunAfter(async () => { await this.Run<T>(); }, time - this.dateTime.Now));
        }

        private async Task Run<T>() where T : ITask
        {
            await this.taskRunner.Run(this.taskFactory.Get<T>());
        }
    }
}
