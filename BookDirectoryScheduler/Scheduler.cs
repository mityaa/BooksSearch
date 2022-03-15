using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookDirectoryScheduler
{
    static class Scheduler
    {

        public static void IntervalInSeconds(double seconds, Action task)
        {
            var millSeconds = TimeSpan.FromSeconds(seconds);
            TriggerScheduler(millSeconds, task);
        }

        public static void IntervalInMinutes(double minutes, Action task)
        {
            var millSeconds = TimeSpan.FromMinutes(minutes);
            TriggerScheduler(millSeconds, task);
        }

        public static void IntervalInHours(double hours, Action task)
        {
            var millSeconds = TimeSpan.FromHours(hours);
            TriggerScheduler(millSeconds, task);
        }

        public static void IntervalInDays(double days, Action task)
        {
            var millSeconds = TimeSpan.FromDays(days);
            TriggerScheduler(millSeconds, task);
        }

        private static void TriggerScheduler(TimeSpan timeInMillSec, Action task)
        {
            while (true)
            {
                Thread.Sleep(timeInMillSec);
                var activity = Task.Factory.StartNew(task, TaskCreationOptions.AttachedToParent);
                activity.Wait();
            }
        }
    }
}
