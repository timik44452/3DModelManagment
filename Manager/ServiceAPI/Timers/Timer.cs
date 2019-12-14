using System.Linq;
using System.Windows.Threading;
using System.Collections.Generic;

namespace ServiceAPI.Timers
{
    public static class Timer
    {
        private static DispatcherTimer timer;
        private static List<ITimerTask> tasks;

        public static void RegisterNewAction(int Interval, System.Action action)
        {
            TimerTask task = new TimerTask(Interval, action);
            RegisterNewAction(task);
        }
        public static void RegisterNewAction(ITimerTask task)
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Tick += (s, e) => Tick();
            }

            if (tasks == null)
            {
                tasks = new List<ITimerTask>();
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

            if (tasks.Count > 0)
            {
                timer.Interval = System.TimeSpan.FromMilliseconds(tasks.Min(x => x.Interval));
                timer.Start();
            }   
        }

        private static void Tick()
        {
            foreach (ITimerTask task in tasks)
            {
                if (task.CanRun())
                {
                    task.Run();

                    if (!task.Looped)
                    {
                        tasks.Remove(task);
                        ReconfigurateTimer();
                        break;
                    }
                }
            }
        }
    }
}
