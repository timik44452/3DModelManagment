using ModelImporter;

namespace Manager.Objects
{
    public static class ObjectModelFactory
    {
        public static IObjectModel GetObject(string path)
        {
            ModelImporter.Model3D model3D = null;
            ModelImport.ImportModel(path, out model3D, null);

            if(model3D != null)
            {
                return new Model3D
                { 
                };

            }

            return null;
        }

        public static IObjectModel GetObject(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is ModelImporter.Model3D)
            {
                var model3D = value as ModelImporter.Model3D;

                return new Model3D()
                {
                    Name = model3D.Name,
                    Type = ObjectType.FBX,
                    State = ObjectState.Uploaded,
                };
            }

            throw new System.NotImplementedException();
        }
    }
}