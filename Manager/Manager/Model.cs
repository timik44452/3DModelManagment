using System;
using ModelImporter;

namespace Manager
{
    public class Model : Model3D
    {
        public enum ModelState
        {
            Free,
            Busy,
            Uploading,
            Downloading
        }

        public DateTime Date { get; set; }

        public ModelState State { get; set; }


        public Model(string Name)
        {
            Date = DateTime.Now;
            Type = ModelType.Fbx;

            this.Name = Name;
        }

        public Model(Model3D prototype)
        {
            Name = prototype.Name;
            Type = prototype.Type;
        }
    }
}
