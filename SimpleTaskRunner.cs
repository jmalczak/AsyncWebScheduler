using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebScheduler
{
    public class SimpleTaskRunner : ITaskRunner
    {
        public async Task Run<T>(T task) where T: ITask
        {
            await task.Run();
        }
    }
}
