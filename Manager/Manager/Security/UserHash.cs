namespace Manager.Security
{
    public struct UserHash
    {
        private string hash;

        public static UserHash FromUserData(string login)
        {
            return new UserHash()
            {
                hash = login
            };
        }

        public static string GetLogin(UserHash hash)
        {
            return hash.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is UserHash &&
                ((UserHash)obj).hash == hash;
        }

        public override int GetHashCode()
        {
            return hash.GetHashCode();
        }

        public override string ToString()
        {
            return hash;
        }
    }
}