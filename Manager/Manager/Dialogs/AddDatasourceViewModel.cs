using System.Linq;
using Manager.Objects;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Manager.Dialogs
{
    public class AddDatasourceViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ObjectSourceItem> SourceItems
        {
            get;
            set;
        }
        public ObservableCollection<IObjectSource> ObjectSources
        {
            get;
            set;
        }


        public AddDatasourceViewModel(ObservableCollection<IObjectSource> objectSources, string[] files)
        {
            if (objectSources == null || objectSources.Count == 0)
            {
                return;
            }

            SourceItems = new ObservableCollection<ObjectSourceItem>();

            foreach (string file in files)
            {
                SourceItems.Add(new ObjectSourceItem(file, objectSources.ToArray()));
            }
        }

        private void PropertyChangdInvoke(string propertyName)
        {
            PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
