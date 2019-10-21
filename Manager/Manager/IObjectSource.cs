using System;
using Manager.Service;
using System.Collections.Generic;

namespace Manager
{
    public interface IObjectSource
    {
        event Action<string> OnPropertyChange;

        string Name { get; set; }

        bool IsAvailable { get; }

        bool IsSelected { get; set; }

        List<ObjectModel> GetObjects();

        void AddObject(ObjectModel objectModel);
    }
}