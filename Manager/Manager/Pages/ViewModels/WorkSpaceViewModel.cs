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

                if (value != null)
                {
                    models = new ObservableCollection<ObjectModel>(value.GetObjects());
                }

                PropertyChange(nameof(CurrentObjectSource));
                PropertyChange(nameof(Models));
            }
        }

        public ICommand SelectObjectSourceCommand
        {
            get;
            set;
        }

        public ICommand AddDataSourceCommand
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

            RelayCommand<object> addDataSourceCommand = new RelayCommand<object>();
            RelayCommand<IObjectSource> selectObjectSourceCommand = new RelayCommand<IObjectSource>();

            addDataSourceCommand.RegisterCallback(AddDataSource);
            selectObjectSourceCommand.RegisterCallback(OnSelectObjectSource);

            AddDataSourceCommand = addDataSourceCommand;
            SelectObjectSourceCommand = selectObjectSourceCommand;

            IObjectSource testServer0 = new LocalServer("Fictive server 0");

            ObjectSources.Add(testServer0);

            SelectObjectSourceCommand.Execute(testServer0);
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

        private void AddDataSource()
        {

        }

        private void OnSelectObjectSource(IObjectSource source)
        {
            if(currentObjectSource != null)
            {
                currentObjectSource.IsSelected = false;
            }
            if (source != null)
            {
                source.IsSelected = true;

                CurrentObjectSource = source;

                PropertyChange(nameof(ObjectSources));
            }
        }
    }
}