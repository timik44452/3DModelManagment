using System.Windows.Controls;
using ServiceAPI;

namespace Manager.Service
{
    public class ManagerLogger : ILogger
    {
        private UserControl logControl;

        public ManagerLogger(UserControl logControl)
        {
            this.logControl = logControl;
        }

        public void ErrorMessage(object msg)
        {
            logControl.Foreground = System.Windows.Media.Brushes.Red;
            logControl.Content = msg.ToString();
            logControl.Foreground = System.Windows.Media.Brushes.Black;
        }

        public void LogMessage(object msg)
        {
            logControl.Foreground = System.Windows.Media.Brushes.Black;
            logControl.Content = msg.ToString();
        }

        public void WarningMessage(object msg)
        {
            logControl.Foreground = System.Windows.Media.Brushes.Orange;
            logControl.Content = msg.ToString();
            logControl.Foreground = System.Windows.Media.Brushes.Black;
        }
    }
}