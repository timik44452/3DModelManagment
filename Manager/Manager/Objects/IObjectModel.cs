namespace Manager.Objects
{
    public interface IObjectModel
    {
        string Name { get; set; }
        ObjectType Type { get; set; }
        ObjectState State { get; set; }
        ObjectHistory History { get; set; }
    }
}