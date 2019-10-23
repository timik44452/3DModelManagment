using System.Collections.Generic;

namespace Manager.Objects
{
    public interface IObjectSource
    {
        string Name { get; set; }

        string Source { get; set; }

        bool IsAvailable { get; }

        List<IObjectModel> GetObjects();

        void AddObject(IObjectModel objectModel);
    }
}