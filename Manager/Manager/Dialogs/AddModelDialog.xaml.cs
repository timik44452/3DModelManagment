using System.Windows;
using Manager.Objects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Manager.Dialogs;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для AddModelDialog.xaml
    /// </summary>
    public partial class AddModelDialog : Window
    {
        private AddDatasourceViewModel viewModel;

        public AddModelDialog(ObservableCollection<IObjectSource> objectSources, string[] files)
        {
            InitializeComponent();

            viewModel = new AddDatasourceViewModel(objectSources, files);
            DataContext = viewModel;
        }

        private void Accept(object sender, RoutedEventArgs e)
        {
            foreach(var item in viewModel.SourceItems)
            {
                item.CurrentSource.AddObject(ObjectModelFactory.GetObject(item.Path));
            }

            DialogResult = true;
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}