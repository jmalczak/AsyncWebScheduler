namespace AsyncWebScheduler.Runner
{
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using global::AsyncWebScheduler._Interfaces;

    public class WebTaskRunnerController : Controller
    {
        public const string ActionFormat = "{0}/webtaskrunner/run/?id={1}";

        private static ITaskFactory taskFacotry;

        public static void SetTaskFactory(ITaskFactory taskFactory)
        {
            taskFacotry = taskFactory;
        }

        public async Task Run(string id)
        {
            var task = taskFacotry.Get(id);
                
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