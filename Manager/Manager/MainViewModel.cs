using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Manager.Pages.ViewModels;
using Manager.Service;
using UpdateService;

namespace Manager
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand KeyDownCommand
        {
            get;
            set;
        }

        public ICommand DropDownCommand
        {
            get;
            set;
        }

        public PageViewModel CurrentPage
        {
            get;
            set;
        }

        private List<PageViewModel> pages;

        public MainViewModel()
        {
            InitPages();
            InitCommands();
        }

        public void PropertyChange(string propertyName)
        {
            PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }

        public void SetPage<T>()
        {
            var currentPage = pages.Find(x => x.GetType() == typeof(T));

            if (currentPage != null)
            {
                CurrentPage = currentPage;
            }
            else
            {
                throw new NotImplementedException();
            }

            PropertyChange(nameof(CurrentPage));
        }

        private void InitPages()
        {
            pages = new List<PageViewModel>();

            var authorizationPage = new UserEnterPageViewModel();
            var workspacePage = new WorkSpaceViewModel();

            authorizationPage.OnAccept += () => SetPage<WorkSpaceViewModel>();

            pages.Add(authorizationPage);
            pages.Add(workspacePage);

            SetPage<UserEnterPageViewModel>();
        }

        private void InitCommands()
        {
            RelayCommand<KeyEventArgs> keyDownCommand = new RelayCommand<KeyEventArgs>();
            RelayCommand<DragEventArgs> dropDownCommand = new RelayCommand<DragEventArgs>();

            foreach (PageViewModel page in pages)
            {
                keyDownCommand.RegisterCallback(x => page.OnKeyDown(x as KeyEventArgs));
                dropDownCommand.RegisterCallback(x => page.OnDropDown(x as DragEventArgs));
            }

            KeyDownCommand = keyDownCommand;
            DropDownCommand = dropDownCommand;
        }
    }
}