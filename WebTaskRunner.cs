using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebScheduler
{
    public class WebTaskRunner : ITaskRunner
    {
        public async Task Run<T>(T task) where T: ITask
        {
            var request = new System.Net.WebRequest("http://localhost:58749/TestTask/run");
            await request.GetResponseAsync();
        }
    }
}
