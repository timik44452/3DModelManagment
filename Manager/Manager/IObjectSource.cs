using System;
using Manager.Service;
using System.Collections.Generic;

namespace Manager
{
    public interface IObjectSource
    {
        string Name { get; set; }

        string Source { get; set; }

        bool IsAvailable { get; }

        List<ObjectModel> GetObjects();

        void AddObject(ObjectModel objectModel);
    }
}