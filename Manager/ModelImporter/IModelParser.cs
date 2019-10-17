namespace ModelImporter
{
    public interface IModelParser
    {
        Property GetProperty<T>(string name);

        void SetProperty(string name, object value);

        void Save();
    }
}