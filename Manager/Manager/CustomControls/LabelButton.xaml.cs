using System;
using System.Windows.Controls;

namespace Manager.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для LabelButton.xaml
    /// </summary>
    public partial class LabelButton : UserControl
    {
        public event EventHandler OnClick;

        public string Text { get; set; }

        public LabelButton()
        {
            InitializeComponent();
        }
    }
}