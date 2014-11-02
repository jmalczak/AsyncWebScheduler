namespace AsyncWebScheduler._Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface ITask : IDisposable
    {
        Task Run();
    }
}
