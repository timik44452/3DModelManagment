using System.Windows.Media;

namespace Notification
{
    public class NotificationVisualContainer
    {
        public NotificationItem Notification { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Brush Background { get; set; }
    }
}
