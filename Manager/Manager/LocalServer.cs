using System;
using System.Collections.Generic;
using MiddlewareAPI;
using Manager.Service;

namespace Manager
{
    public class LocalServer : IObjectSource
    {
        public event Action<string> OnPropertyChange;


        public string Name
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get => fileSender != null && fileSender.IsConnected;
        }

        public bool IsSelected 
        { 
            get; 
            set; 
        }

        private FileStreamer fileSender;
        private List<ObjectModel> objects = new List<ObjectModel>();


        public LocalServer(string Name)
        {
            this.Name = Name;
        }

        public void AddObject(ObjectModel objectModel)
        {
            objects.Add(objectModel);
        }

        public List<ObjectModel> GetObjects()
        {
            return objects;
        }
    }
}