using System.Windows;

namespace Notification
{
    public class NotificationManager
    {
        private NotificationWindowViewModel viewModel;

        public void Show(NotificationItem notification)
        {
            if (viewModel == null)
            {
                var workArea = SystemParameters.WorkArea;
                var viewModel = new NotificationWindowViewModel();

                NotificationWindow window = new NotificationWindow();

                window.DataContext = viewModel;
                window.Left = workArea.Left;
                window.Top = workArea.Top;
                window.Width = workArea.Width;
                window.Height = workArea.Height;

                window.Show();

                this.viewModel = viewModel;
            }

            this.viewModel.AddNotification(notification);
        }
    }
}
