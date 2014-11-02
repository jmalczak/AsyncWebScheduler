namespace AsyncWebScheduler._Interfaces
{
    public interface ITaskFactory
    {
        T Get<T>() where T : ITask;

        ITask Get(string typeName);
    }
}
