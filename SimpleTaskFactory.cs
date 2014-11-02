using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebScheduler
{
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

            if (assembliesFromAppDomain != null && assembliesFromAppDomain.Any())
            {
                var type = assembliesFromAppDomain.First().GetType(typeName);
                return (ITask)Activator.CreateInstance(type);
            }
            else
            {
                throw new ArgumentException("Incorrect task name.");
            }
        }
    }
}
