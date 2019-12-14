using ModelImporter;

namespace Manager.Objects
{
    public static class ObjectModelFactory
    {
        //TODO: Bad factory
        public static IObjectModel GetObject(string path)
        {
            ModelImport.ImportModel(path, out ModelImporter.Model3D model3D);

            if(model3D != null)
            {
                return new Model3D
                { 
                    Name = model3D.Name,
                    Type = new ObjectType(model3D.Type)
                };

            }

            return null;
        }
    }
}