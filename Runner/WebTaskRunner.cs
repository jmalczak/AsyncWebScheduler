namespace AsyncWebScheduler.Runner
{
    using System.Threading.Tasks;

    using global::AsyncWebScheduler._Interfaces;
    using global::AsyncWebScheduler.HttpClient;

    public class WebTaskRunner : ITaskRunner
    {
        private readonly string baseUrl;

        private readonly string actionFormat;

        private readonly IHttpClient httpClient;

        public WebTaskRunner(string baseUrl, string actionFormat, IHttpClient httpClient)
        {
            this.baseUrl = baseUrl;
            this.actionFormat = actionFormat;
            this.httpClient = httpClient;
        }

        public WebTaskRunner(string baseUrl, string actionFormat)
            : this(baseUrl, actionFormat, new SimpleHttpClient())
        {
        }

        public async Task Run<T>(T task) where T : ITask
        {
            try
            {
                string requestUrl = string.Format(
                    this.actionFormat,
                    this.baseUrl,
                    task.GetType().FullName);
                await this.httpClient.Get(requestUrl);
            }
            finally
            {
                task.Dispose();
            }
        }
    }
}
