using System.Collections.Generic;

namespace Manager.Objects
{
    public class ObjectState
    {
        public static ObjectState Free { get => new ObjectState("Free"); }
        public static ObjectState Busy { get => new ObjectState("Busy"); }
        public static ObjectState Uploaded { get => new ObjectState("Uploaded"); }
        public static ObjectState Downloaded { get => new ObjectState("Downloaded"); }

        private string state;

        public ObjectState(string state)
        {
            this.state = state;
        }

        public override string ToString()
        {
            return state;
        }

        public override bool Equals(object obj)
        {
            return obj is ObjectState state &&
                   this.state == state.state;
        }

        public override int GetHashCode()
        {
            return 259708774 + EqualityComparer<string>.Default.GetHashCode(state);
        }
    }
}