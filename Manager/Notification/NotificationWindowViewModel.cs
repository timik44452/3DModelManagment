using ServiceAPI.Timers;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Notification
{
    public class NotificationWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NotificationVisualContainer> VisualContainers
        {
            get;
            set;
        }

        public NotificationWindowViewModel()
        {
            VisualContainers = new ObservableCollection<NotificationVisualContainer>();
            VisualContainers.CollectionChanged += (s, e) => PropertyChangeInvoke(nameof(VisualContainers));
        }

        public void AddNotification(NotificationItem notification)
        {
            NotificationVisualContainer visualContainer = new NotificationVisualContainer();

            visualContainer.Background = Brushes.Gray;
            visualContainer.Notification = notification;
            visualContainer.Width = 350;
            visualContainer.Height = 100;

            VisualContainers.Add(visualContainer);
            //VisualContainers.Remove(visualContainer);
            Timer.RegisterNewAction(1500, () => VisualContainers.Remove(visualContainer));
        }

        public void PropertyChangeInvoke(string propertyName)
        {
            PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
