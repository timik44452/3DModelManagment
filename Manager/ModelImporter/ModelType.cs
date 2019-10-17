namespace ModelImporter
{
    public enum Type3D
    {
        FBX,
        OBJ
    }

    public class ModelType
    {
        public static ModelType Fbx { get => new ModelType(Type3D.FBX); }
        public static ModelType Obj { get => new ModelType(Type3D.OBJ); }

        private Type3D type;

        public ModelType(Type3D type)
        {
            this.type = type;
        }

        public static ModelType Parse(string path)
        {
            if (TryParse(path, out ModelType type))
                return type;

            return null;
        }

        public static bool TryParse(string modelName, out ModelType target)
        {
            target = null;

            if (modelName.ToLower().Contains(".fbx"))
            {
                target = Fbx;

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return type.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is ModelType type &&
                   this.type == type.type;
        }

        public override int GetHashCode()
        {
            return 34944597 + type.GetHashCode();
        }
    }
}