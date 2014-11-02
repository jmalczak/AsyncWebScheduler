namespace WebScheduler.Tasks
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using AsyncWebScheduler._Interfaces;

    public class CreateFileTask : ITask
    {
        private FileStream file;

        public CreateFileTask()
        {
            this.file = null;
        }

        public async Task Run()
        {
            this.file = File.Create(@"C:\\BeginRequest" + DateTime.Now.Ticks);
            Thread.Sleep(240000);
            byte[] data = Encoding.ASCII.GetBytes("Test");
            await this.file.WriteAsync(data, 0, data.Length);
        }

        public void Dispose()
        {
            if (this.file != null)
            {
                this.file.Dispose();
            }
        }
    }
}