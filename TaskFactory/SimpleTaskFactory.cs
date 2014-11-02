namespace AsyncWebScheduler.TaskFactory
{
    using System;
    using System.Linq;

    using global::AsyncWebScheduler._Interfaces;

    public class SimpleTaskFactory : ITaskFactory
    {
        public T Get<T>() where T : ITask
        {
            return Activator.CreateInstance<T>();
        }

        public ITask Get(string typeName)
        {
            var assembliesFromAppDomain = AppDomain.CurrentDomain
                                                   .GetAssemblies()
                                                   .Where(a => a.GlobalAssemblyCache == false &&
                                                         !a.IsDynamic &&
                                                          a.ExportedTypes.Any(t => t.FullName == typeName))
                                                   .ToList();

            if (assembliesFromAppDomain.Any())
            {
                var type = assembliesFromAppDomain.First().GetType(typeName);
                return (ITask)Activator.CreateInstance(type);
            }
            
            throw new ArgumentException("Incorrect task name.");
        }
    }
}
