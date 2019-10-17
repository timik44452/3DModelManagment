using System;
using System.Collections.Generic;
using System.Windows.Input;
using MiddlewareAPI;
using Manager.Service;

namespace Manager
{
    public class LocalServer : IObjectSource
    {
        public string Name
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get => fileSender != null && fileSender.IsConnected;
        }

        public RelayCommand<IObjectSource> OnClick 
        { 
            get; 
            set; 
        }

        private FileSender fileSender;
        private List<ObjectModel> objects = new List<ObjectModel>();

        public LocalServer(string Name)
        {
            this.Name = Name;

            OnClick = new RelayCommand<IObjectSource>();
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