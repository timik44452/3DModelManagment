using System.IO;

namespace ModelImporter
{
    public static class ModelImport
    {
        public static void ImportModel(string path, out Model3D model3D, IModelParser parser)
        {
            model3D = null;

            if (IsModel(path))
            {
                var modelName = Path.GetFileNameWithoutExtension(path);
                var modelType = ModelType.Parse(path);

                model3D = new Model3D()
                {
                    Name = modelName,
                    Type = ModelType.Fbx
                };
            }
        }

        public static bool IsModel(string path)
        {
            return File.Exists(path) && ModelType.TryParse(path, out _);
        }
    }
}