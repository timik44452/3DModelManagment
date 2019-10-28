using ServiceAPI;
using System.Windows;
using Manager.Objects;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для AddDatasourceDialog.xaml
    /// </summary>
    public partial class AddDatasourceDialog : Window
    {
        public IObjectSource Source
        {
            get => source;
        }

        private ILogger logger;
        private IObjectSource source;


        public AddDatasourceDialog(ILogger logger)
        {
            this.logger = logger;

            InitializeComponent();
        }

        private void Accept(object sender, RoutedEventArgs e)
        {
            if (System.IO.Directory.Exists(SourceBox.Text))
                source = new Folder(NameBox.Text, SourceBox.Text, logger);
            else
                source = new LocalServer(NameBox.Text, SourceBox.Text, logger);

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
