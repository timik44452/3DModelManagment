using System.IO;
using System.Xml.Serialization;

namespace UpdateService
{
    public static class Serializatior
    {
        public static void Serialization(string path, object target)
        {
            var serializer = new XmlSerializerFactory().CreateSerializer(target.GetType());
            using(Stream stream = new StreamWriter(path).BaseStream)
            {
                serializer.Serialize(stream, target);
            }
        }

        public static T Deserialization<T>(string path)
        {
            if (File.Exists(path))
            {
                var serializer = new XmlSerializerFactory().CreateSerializer(typeof(T));

                using (Stream stream = new StreamReader(path).BaseStream)
                {
                    object value = serializer.Deserialize(stream);

                    if (value != null)
                        return (T)value;
                }
            }

            return default;
        }
    }
}
