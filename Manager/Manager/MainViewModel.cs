using System.ComponentModel;
using System.Windows.Controls;
using Manager.Pages.ViewModels;
using System.Collections.Generic;

namespace Manager
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Page
        {
            get => currentPageNumber;
            set
            {
                if (value > -1 && value < pages.Count)
                {
                    currentPageNumber = value;
                    PropertyChange(nameof(Page));
                    PropertyChange(nameof(CurrentPage));
                }
            }
        }

        public PageViewModel CurrentPage
        {
            get => pages[currentPageNumber];
        }

        private int currentPageNumber = 0;
        private List<PageViewModel> pages;


        public MainViewModel()
        {
            InitPages();
        }

        public void PropertyChange(string propertyName)
        {
            PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }

        private void InitPages()
        {
            pages = new List<PageViewModel>();

            pages.Add(new UserEnterPageViewModel());
        }
    }
}
