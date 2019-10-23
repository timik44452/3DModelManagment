namespace Manager
{
    public static class ObjectModelFactory
    {
        public static ObjectModel GetObject(object value)
        {
            if (value == null)
            {
                return null;
            }

            if (value is ModelImporter.Model3D)
            {
                var model3D = value as ModelImporter.Model3D;

                return new Model3D()
                {
                    Date = System.DateTime.Now,
                    Name = model3D.Name,
                    State = ModelState.Uploading,
                    Type = new Model3DFBX()
                };
            }

            throw new System.NotImplementedException();
        }
    }
}