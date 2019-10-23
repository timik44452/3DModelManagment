using System.Collections.Generic;

namespace Manager.Objects
{
    public class ObjectType
    {
        public static ObjectType FBX { get => new ObjectType("FBX"); }

        private string type;

        public ObjectType(string type)
        {
            this.type = type;
        }

        public override bool Equals(object obj)
        {
            return obj is ObjectType type &&
                   this.type == type.type;
        }

        public override int GetHashCode()
        {
            return 34944597 + EqualityComparer<string>.Default.GetHashCode(type);
        }

        public override string ToString()
        {
            return type;
        }
    }
}