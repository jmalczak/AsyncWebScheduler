namespace AsyncWebScheduler._Interfaces
{
    using System.Threading.Tasks;

    public interface ITaskRunner
    {
        Task Run<T>(T task) where T: ITask;
    }
}
