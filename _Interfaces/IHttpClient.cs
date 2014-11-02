namespace AsyncWebScheduler._Interfaces
{
    using System.Threading.Tasks;

    public interface IHttpClient
    {
        Task Get(string url);
    }
}