using System.Collections.Generic;
using System.ComponentModel;
using Manager.Objects;
using MiddlewareAPI;
using ServiceAPI;

namespace Manager
{
    public class LocalServer : IObjectSource, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChangedInvoke(nameof(Name));
            }
        }

        public bool IsAvailable
        {
            get => fileSender != null && fileSender.IsConnected;
        }

        public string Source
        {
            get => source;
            set
            {
                source = value;
                PropertyChangedInvoke(nameof(Name));
            }
        }

        public string ItemIcon
        {
            get => itemIcon;
            set
            {
                if (itemIcon != value)
                {
                    itemIcon = value;
                    PropertyChangedInvoke(nameof(ItemIcon));
                }
            }
        }

        private const string DISCONNECTED_SERVER_ICON = "/Manager;component/Resources/disconnectedServer.png";
        private const string CONNECTED_SERVER_ICON = "/Manager;component/Resources/connectedServer.png";

        private string name;
        private string source;
        private string itemIcon;

        private FileStreamer fileSender;
        private List<IObjectModel> objects = new List<IObjectModel>();

        public LocalServer(string name, string source, ILogger logger)
        {
            this.name = name;
            this.source = source;

            ItemIcon = DISCONNECTED_SERVER_ICON;
            fileSender = new FileStreamer(logger);

            Timer.RegisterNewAction(new TimerTask(1500, CheckConnection, loop: true));
        }

        public void AddObject(IObjectModel objectModel)
        {
            objects.Add(objectModel);
        }

        public List<IObjectModel> GetObjects()
        {
            return objects;
        }

        private void PropertyChangedInvoke(string propertyName)
        {
            PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }

        private void CheckConnection()
        {
            if (fileSender == null)
            {
                return;
            }

            if (!fileSender.IsConnected)
            {
                fileSender.Connect("127.0.0.1", 67);

                if (fileSender.IsConnected)
                {
                    PropertyChangedInvoke(nameof(IsAvailable));
                }
            }

            ItemIcon = IsAvailable ? CONNECTED_SERVER_ICON : DISCONNECTED_SERVER_ICON;
        }
    }
}