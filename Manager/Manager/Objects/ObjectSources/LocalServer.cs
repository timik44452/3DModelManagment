using System.Collections.Generic;
using System.ComponentModel;
using Manager.Objects;
using MiddlewareAPI;
using ServiceAPI.Log;
using ServiceAPI.Timers;

namespace Manager
{
    public class LocalServer : IObjectSource, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsAvailable
        {
            get => isAvailable;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChangedInvoke(nameof(Name));
            }
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
        private bool isAvailable;

        private NetworkCommunicator networkCommunicator;
        private List<IObjectModel> objects = new List<IObjectModel>();

        public LocalServer(string name, string source, ILogger logger)
        {
            this.name = name;
            this.source = source;


            ItemIcon = DISCONNECTED_SERVER_ICON;
            networkCommunicator = new NetworkCommunicator(logger, null);

            Timer.RegisterNewAction(new TimerTask(1500, CheckConnection, loop: true));
        }

        public void AddObject(string FilePath, IObjectModel objectModel)
        {
            networkCommunicator.Send(this, $"log:{objectModel.Name}");
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
            if (networkCommunicator == null)
            {
                return;
            }

            if (!networkCommunicator.IsConnected)
            {
                networkCommunicator.Connect("127.0.0.1", 67);
            }

            if (isAvailable != networkCommunicator.IsConnected)
            {
                isAvailable = networkCommunicator.IsConnected;
                PropertyChangedInvoke(nameof(IsAvailable));
            }

            ItemIcon = IsAvailable ? CONNECTED_SERVER_ICON : DISCONNECTED_SERVER_ICON;
        }
    }
}