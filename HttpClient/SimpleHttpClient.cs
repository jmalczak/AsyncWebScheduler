namespace AsyncWebScheduler.HttpClient
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using global::AsyncWebScheduler._Interfaces;

    public class SimpleHttpClient : IHttpClient
    {
        public async Task Get(string url)
        {
            await new HttpClient().GetAsync(url);
        }
    }
}