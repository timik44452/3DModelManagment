using System.Linq;
using System.Collections.Generic;

namespace ServiceAPI
{
    public static class Timer
    {
        private static System.Timers.Timer timer;
        private static List<TimerTask> tasks;

        public static void RegisterNewAction(TimerTask task)
        {
            if (timer == null)
            {
                timer = new System.Timers.Timer();
                timer.Elapsed += (s, e) => Tick();
            }

            if (tasks == null)
            {
                tasks = new List<TimerTask>();
            }

            tasks.Add(task);
            ReconfigurateTimer();
        }

        public static void StopTimer()
        {
            timer.Stop();
            tasks.Clear();
        }

        private static void ReconfigurateTimer()
        {
            timer.Stop();
            timer.Interval = tasks.Min(x => x.Interval);
            timer.Start();
        }

        private static void Tick()
        {
            foreach(TimerTask task in tasks)
            {
                task.Run();
            }
        }
    }
}
