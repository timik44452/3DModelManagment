using System;

namespace ServiceAPI
{
    public struct TimerTask
    {
        public readonly string Name;

        public int Interval;
        public bool IsLoop;

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
            IsLoop = loop;
            Interval = interval;

            lastInvokedTime = DateTime.Now;

            this.task = task;
        }

        public void Run()
        {
            if ((DateTime.Now - lastInvokedTime).Milliseconds >= Interval)
                return;

            task?.Invoke();
            lastInvokedTime = DateTime.Now;
        }
    }
}