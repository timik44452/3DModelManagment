using ModelImporter.Parsers;

namespace ModelImporter
{
    public static class ModelParserFactory
    {
        public static IModelParser CreateParser(Type3D type)
        {
            if (type == Type3D.FBX)
            {
                return new FBXParser();
            }

            return null;
        }
    }
}