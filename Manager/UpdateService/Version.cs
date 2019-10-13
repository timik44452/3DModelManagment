using System;


namespace UpdateService
{
    [Serializable]
    public class Version
    {
        private int m0, m1, m2, m3;

        public Version()
        {
            m0 = 1;
            m1 = 0;
            m2 = 0;
            m3 = 0;
        }

        public Version(byte m0, byte m1, byte m2, byte m3)
        {
            this.m0 = m0;
            this.m1 = m1;
            this.m2 = m2;
            this.m3 = m3;
        }

        public override string ToString()
        {
            return $"{m0}.{m1}.{m2}.{m3}";
        }

        public override bool Equals(object obj)
        {
            return obj is Version version &&
                   m0 == version.m0 &&
                   m1 == version.m1 &&
                   m2 == version.m2 &&
                   m3 == version.m3;
        }

        public static bool operator >(Version a, Version b)
        {
            if (a.m0 > b.m0)
            {
                return true;
            }

            if (a.m0 == b.m0)
            {
                if (a.m1 > b.m1)
                {
                    return true;
                }

                if (a.m1 == b.m1)
                {
                    if (a.m2 > b.m2)
                    {
                        return true;
                    }

                    if (a.m2 == b.m2)
                    {
                        return a.m3 > b.m3;
                    }
                }
            }

            return false;
        }

        public static bool operator <(Version a, Version b)
        {
            return (a != b) && !(a > b);
        }

        public static bool operator ==(Version a, Version b)
        {
            if (a is null || b is null)
                return a is null && b is null;

            return a.Equals(b);
        }


        public static bool operator != (Version a, Version b)
        {
            return !(a == b);
        }
    }
}