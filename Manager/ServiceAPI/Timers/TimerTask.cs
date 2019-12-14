using System;

namespace ServiceAPI.Timers
{
    public struct TimerTask : ITimerTask
    {
        public readonly string Name;

        public int Interval
        {
            get;
            set;
        }
        public bool Looped
        {
            get;
            set;
        }

        public DateTime InvokedTime
        {
            get => lastInvokedTime.AddMilliseconds(Interval);
        }

        private DateTime lastInvokedTime;
        private Action task;

        /// <param name="interval">Интервал выполнения задачи в ms</param>
        public TimerTask(int interval, Action task, string name = "none", bool loop = false)
        {
            Name = name;
            Looped = loop;
            Interval = interval;

            lastInvokedTime = DateTime.Now;

            this.task = task;
        }

        public bool CanRun()
        {
            return (DateTime.Now - lastInvokedTime).TotalMilliseconds >= Interval;
        }

        public void Run()
        {
            task?.Invoke();
            lastInvokedTime = DateTime.Now;
        }
    }
}