namespace ModelImporter
{
    public enum Type3D
    {
        Undefined,
        FBX,
        OBJ
    }

    public static class ModelType
    {
        public static bool TryParse(string modelName, out Type3D target)
        {
            target = Type3D.Undefined;

            modelName = modelName.ToLower();

            // TODO: Add more model types
            if (modelName.Contains(".fbx"))
            {
                target = Type3D.FBX;
            }

            if (modelName.Contains(".obj"))
            {
                target = Type3D.OBJ;
            }

            return target != Type3D.Undefined;
        }
    }
}
