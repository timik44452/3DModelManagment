using System.IO;

namespace ModelImporter
{
    public static class ModelImport
    {
        public static void ImportModel(string path, out Model3D model3D)
        {
            model3D = null;

            if (File.Exists(path) && ModelType.TryParse(path, out Type3D modelType))
            {
                var modelName = Path.GetFileNameWithoutExtension(path);

                model3D = new Model3D()
                {
                    Name = modelName,
                    Type = modelType
                };
            }
        }
    }
}