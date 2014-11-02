namespace AsyncWebScheduler.Runner
{
    using System.Threading.Tasks;

    using global::AsyncWebScheduler._Interfaces;

    public class SimpleTaskRunner : ITaskRunner
    {
        public async Task Run<T>(T task) where T : ITask
        {
            try
            {
                await task.Run();
            }
            finally
            {
                task.Dispose();
            }
        }
    }
}
