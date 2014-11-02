namespace AsyncWebScheduler.TimerFactory
{
    using global::AsyncWebScheduler._Interfaces;

    public class Timer : ITimer
    {
        private readonly System.Threading.Timer timer;

        public Timer(System.Threading.Timer timer)
        {
            this.timer = timer;
        }

        public void Dispose()
        {
            this.timer.Dispose();
        }
    }
}