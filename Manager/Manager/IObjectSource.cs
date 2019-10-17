using Manager.Service;
using System.Collections.Generic;

namespace Manager
{
    public interface IObjectSource
    {
        string Name { get; set; }

        bool IsAvailable { get; }

        //TODO:Replace
        RelayCommand<IObjectSource> OnClick { get; set; }

        List<ObjectModel> GetObjects();

        void AddObject(ObjectModel objectModel);
    }
}