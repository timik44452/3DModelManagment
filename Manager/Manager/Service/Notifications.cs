using Notification;

namespace Manager.Service
{
    public class Notifications
    {
        private static NotificationManager notificationManager = new NotificationManager();

        public static void Show(string Title, string Content)
        {
            NotificationItem notification = new NotificationItem();

            notification.Title = Title;
            notification.Content = Content;

            notificationManager.Show(notification);
        }
    }
}
