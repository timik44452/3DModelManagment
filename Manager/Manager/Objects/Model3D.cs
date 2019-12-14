namespace Manager.Objects
{
    public class Model3D : IObjectModel
    {
        public string Name
        {
            get;
            set;
        }
        public ObjectType Type
        {
            get;
            set;
        }
        public ObjectState State
        {
            get;
            set;
        }
        public ObjectHistory History
        {
            get;
            set;
        }
    }

}