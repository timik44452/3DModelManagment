using System.Collections.Generic;

namespace Manager.Objects
{
    public class ObjectType
    {
        private string type;

        public ObjectType(string type)
        {
            this.type = type;
        }

        public ObjectType(object value)
        {
            type = value.ToString();
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