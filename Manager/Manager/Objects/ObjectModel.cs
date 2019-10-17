using System;

namespace Manager
{
    public enum ModelState
    {
        Free,
        Busy,
        Uploading,
        Downloading
    }

    public class ObjectModel
    {
        public string Name { get; set; }
        public ModelState State { get; set; }
        public ObjectType Type { get; set; }
        public DateTime Date { get; set; }
    }
}