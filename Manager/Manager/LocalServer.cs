using System;
using System.Collections.Generic;
using MiddlewareAPI;
using ServiceAPI;
using System.ComponentModel;

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


        private string name;
        private string source;
        private string itemIcon;

        private FileStreamer fileSender;
        private List<ObjectModel> objects = new List<ObjectModel>();


        public LocalServer(string name, string source, ILogger logger)
        {
            this.name = name;
            this.source = source;

            ItemIcon = "/Manager;component/Resources/disconnectedServer.png";
            fileSender = new FileStreamer(logger);

            Timer.RegisterNewAction(new TimerTask(1500, CheckConnection, loop:true));
        }

        public void AddObject(ObjectModel objectModel)
        {
            objects.Add(objectModel);
        }

        public List<ObjectModel> GetObjects()
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
            if(fileSender == null)
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

            if (!IsAvailable)
            {
                ItemIcon = "/Manager;component/Resources/disconnectedServer.png";
            }
            else
            {
                ItemIcon = "/Manager;component/Resources/connectedServer.png";
            }
        }
    }
}