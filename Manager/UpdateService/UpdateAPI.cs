using System;
using System.Diagnostics;

namespace UpdateService
{
    public static class UpdateAPI
    {
        private const string VERSION_FILE_PATH = @".version";

        public static Version GetVersion(UpdateSource source)
        {
            throw new NotImplementedException();
        }

        public static Version GetCurrentVersion()
        {
            Version currentVersion = Serializatior.Deserialization<Version>(VERSION_FILE_PATH);

            if (currentVersion == null)
            {
                currentVersion = new Version();

                Serializatior.Serialization(VERSION_FILE_PATH, currentVersion);
            }

            return currentVersion;
        }

        public static bool NeedUpdate(UpdateSource source)
        {
            Version currentVersion = GetCurrentVersion();
            Version actualVersion = GetVersion(source);

            return actualVersion > currentVersion;
        }

        public static void Update(UpdateSource source, Process programm)
        {
            throw new NotImplementedException();
        }
    }
}