using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(obj is UserHash)
            {
                return ((UserHash)obj).hash == hash;
            }

            return false;
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
