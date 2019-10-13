using System;
using System.IO;

namespace ModelImporter
{
    public static class ModelImporter
    {
        public static Model3D ImportModel(string path, IModelParser parser)
        {
            if (IsModel(path))
            {
                var modelName = Path.GetFileNameWithoutExtension(path);
                var modelType = ModelType.Parse(path);

                return new Model3D()
                {
                    Name = modelName,
                    Type = modelType
                };
            }

            return null;

        }

        public static bool IsModel(string path)
        {
            return File.Exists(path) && ModelType.TryParse(path, out _);
        }
    }
}
