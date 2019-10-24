using Manager.Objects;

namespace Manager.Dialogs
{
    public class ObjectSourceItem
    {
        public string Path { get; set; }
        public IObjectSource[] Sources { get; set; }
        public IObjectSource CurrentSource { get; set; }


        public ObjectSourceItem(string path, IObjectSource[] sources)
        {
            Path = path;
            Sources = sources;
            CurrentSource = sources[0];
        }
    }
}
