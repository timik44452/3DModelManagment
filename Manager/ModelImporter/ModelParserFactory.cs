using ModelImporter.Parsers;

namespace ModelImporter
{
    public static class ModelParserFactory
    {
        public static IModelParser CreateParser(string path)
        {
            if (ModelType.TryParse(path, out ModelType model))
            {
                return CreateParser(model);
            }
            else
            {
                return null;
            }
        }

        public static IModelParser CreateParser(ModelType type)
        {
            if (type.Equals(ModelType.Fbx))
            {
                return new FBXParser();
            }

            return null;
        }
    }
}
