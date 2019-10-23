using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Manager.Service;
using ModelImporter;
using System.Linq;

namespace Manager.Pages.ViewModels
{
    public class WorkSpaceViewModel : PageViewModel
    {
        public ObservableCollection<ObjectModel> Models
        {
            get
            {
                ObservableCollection<ObjectModel> models = new ObservableCollection<ObjectModel>();

                foreach(IObjectSource objectSource in ObjectSources)
                    foreach(ObjectModel model in objectSource.GetObjects())
                    {
                        models.Add(model);
                    }

                return models;
            }
        }

        public ObservableCollection<IObjectSource> ObjectSources
        {
            get;
            set;
        }

        public ICommand AddDataSourceCommand
        {
            get;
            set;
        }


        public WorkSpaceViewModel()
        {
            ObjectSources = new ObservableCollection<IObjectSource>();
            ObjectSources.CollectionChanged += (send, e) =>
            {
                PropertyChange(nameof(ObjectSources));
                PropertyChange(nameof(Models));
            };

            RelayCommand<object> addDataSourceCommand = new RelayCommand<object>();
            RelayCommand<IObjectSource> selectObjectSourceCommand = new RelayCommand<IObjectSource>();

            addDataSourceCommand.RegisterCallback(AddDataSource);

            AddDataSourceCommand = addDataSourceCommand;

            IObjectSource testServer0 = new LocalServer("Fictive server 0", "127.0.0.1:67", null);
            ObjectSources.Add(testServer0);
        }

        public override void OnDropDown(DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


            AddModelDialog modelDialog = new AddModelDialog(ObjectSources, files);
            modelDialog.ShowDialog();

            PropertyChange(nameof(Models));
        }

        private void AddDataSource()
        {
            AddDatasourceDialog datasourceDialog = new AddDatasourceDialog(null);
            
            if(datasourceDialog.ShowDialog() == true)
            {
                ObjectSources.Add(datasourceDialog.Source);
            }
        }
    }
}