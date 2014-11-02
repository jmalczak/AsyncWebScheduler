using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebScheduler
{
    public class AsyncScheduler : IScheduler
    {
        private readonly List<System.Threading.Timer> timers;

        private readonly ITaskFactory taskFactory;

        private readonly ITaskRunner taskRunner;

        public AsyncScheduler(ITaskFactory taskFactory, ITaskRunner taskRunner)
        {
            this.taskFactory = taskFactory;
            this.taskRunner = taskRunner;
        }

        public AsyncScheduler()
        {
            this.timers = new List<System.Threading.Timer>();
            this.taskFactory = new SimpleTaskFactory();
            this.taskRunner = new SimpleTaskRunner();
        }

        public async Task Run(string taskName)
        {
            await this.taskRunner.Run(this.taskFactory.Get(taskName));
        }

        public async Task Run<T>() where T : ITask
        {
            await this.taskRunner.Run(this.taskFactory.Get<T>());
        }

        public void RunEvery<T>(TimeSpan timeSpan) where T : ITask
        {
            this.timers.Add(new System.Threading.Timer((object param) =>
            {
                this.Run<T>();
            }, 
            null, 
            timeSpan, 
            timeSpan));
        }

        public void RunAt<T>(DateTime time) where T : ITask
        {
            this.timers.Add(new System.Threading.Timer((object param) =>
            {
                this.Run<T>();
            },
            null,
            time - DateTime.Now, 
            System.Threading.Timeout.InfiniteTimeSpan));
        }
    }
}
