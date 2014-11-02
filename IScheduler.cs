using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebScheduler
{
    public interface IScheduler
    {
        Task Run(string taskName);
        Task Run<T>() where T : ITask;
        void RunEvery<T>(TimeSpan timeSpan) where T : ITask;
        void RunAt<T>(DateTime time) where T : ITask;
    }
}
