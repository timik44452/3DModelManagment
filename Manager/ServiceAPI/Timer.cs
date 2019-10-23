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
                timer = new System.Timers.Timer(task.Interval);
            }

            timer.Elapsed += (s, e) =>
              {
                  task.Run();

                  if (!task.IsLoop)
                  {
                      timer.Stop();
                  }
              };

            timer.Start();
        }

        public static void StopTimer()
        {
            timer.Stop();
            tasks.Clear();
        }
    }
}