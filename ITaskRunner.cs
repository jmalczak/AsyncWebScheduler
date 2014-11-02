using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebScheduler
{
    public interface ITaskRunner
    {
        Task Run<T>(T task) where T: ITask;
    }
}
