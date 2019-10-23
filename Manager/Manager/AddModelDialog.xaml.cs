using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для AddModelDialog.xaml
    /// </summary>
    public partial class AddModelDialog : Window
    {
        private List<string> Files;
        private List<IObjectSource> ObjectSources;

        public AddModelDialog(ObservableCollection<IObjectSource> objectSources, string[] files)
        {
            InitializeComponent();

            Files = new List<string>(files);
            ObjectSources = new List<IObjectSource>(objectSources);
        }

        public void Accept()
        {
            foreach (string file in Files)
            {
                //if (ModelImporter.ModelImporter.IsModel(file))
                //{
                //    ObjectModel model3D = ObjectModelFactory.GetObject(ModelImporter.ModelImporter.ImportModel(file,
                //        ModelParserFactory.CreateParser(file))) as Model3D;
                //}
            }
        }
    }
}