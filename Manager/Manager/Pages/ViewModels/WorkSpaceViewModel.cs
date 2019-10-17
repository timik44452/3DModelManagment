using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Manager.Service;
using ModelImporter;

namespace Manager.Pages.ViewModels
{
    public class WorkSpaceViewModel : PageViewModel
    {
        public ObservableCollection<ObjectModel> Models
        {
            get => models;
        }

        public ObservableCollection<IObjectSource> ObjectSources
        {
            get;
            set;
        }

        public IObjectSource CurrentObjectSource
        {
            get => currentObjectSource;
            set
            {
                currentObjectSource = value;

                PropertyChange(nameof(CurrentObjectSource));
                PropertyChange(nameof(Models));
            }
        }

        public ICommand SelectObjectSourceCommand
        {
            get;
            set;
        }

        private IObjectSource currentObjectSource;
        private ObservableCollection<ObjectModel> models;

        public WorkSpaceViewModel()
        {
            ObjectSources = new ObservableCollection<IObjectSource>();
            ObjectSources.CollectionChanged += (send, e) =>
            {
                PropertyChange(nameof(CurrentObjectSource));
                PropertyChange(nameof(ObjectSources));
            };

            IObjectSource testServer0 = new LocalServer("Fictive server 0");
            testServer0.OnClick.RegisterCallback(OnSelectObjectSource);

            IObjectSource testServer1 = new LocalServer("Fictive server 1");
            testServer1.OnClick.RegisterCallback(OnSelectObjectSource);

            ObjectSources.Add(testServer0);
            ObjectSources.Add(testServer1);

            RelayCommand<IObjectSource> selectObjectSourceCommand = new RelayCommand<IObjectSource>();

            selectObjectSourceCommand.RegisterCallback(OnSelectObjectSource);
            SelectObjectSourceCommand = selectObjectSourceCommand;
        }

        public override void OnDropDown(DragEventArgs e)
        {
            if (CurrentObjectSource == null)
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                if (ModelImporter.ModelImporter.IsModel(file))
                {
                    ObjectModel model3D = ObjectModelFactory.GetObject(ModelImporter.ModelImporter.ImportModel(file,
                        ModelParserFactory.CreateParser(file))) as Model3D;

                    CurrentObjectSource.AddObject(model3D);
                }
            }

            models = new ObservableCollection<ObjectModel>(CurrentObjectSource.GetObjects());
            PropertyChange(nameof(Models));
        }

        private void OnSelectObjectSource(IObjectSource source)
        {
            if (source != null)
            {
                models = new ObservableCollection<ObjectModel>(source.GetObjects());
                CurrentObjectSource = source;
            }
        }
    }
}