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
            source = new LocalServer(NameBox.Text,SourceBox.Text, logger);

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
