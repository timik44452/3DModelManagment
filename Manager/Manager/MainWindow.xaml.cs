using System.Windows;

namespace Manager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            MainViewModel mainView = new MainViewModel();

            KeyDown += (sen, args) => mainView.KeyDownCommand.Execute(args);
            Drop += (sen, args) => mainView.DropDownCommand.Execute(args);

            DataContext = mainView;
        }
    }
}