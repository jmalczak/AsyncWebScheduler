using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebScheduler
{
    public interface ITaskFactory
    {
        T Get<T>() where T : ITask;
        ITask Get(string typeName);
    }
}
