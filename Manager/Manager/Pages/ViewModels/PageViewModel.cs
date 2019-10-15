using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System;

namespace Manager.Pages.ViewModels
{
    public class PageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnKeyDown(KeyEventArgs e)
        {
            
        }
        public virtual void OnDropDown(DragEventArgs e)
        {

        }

        public void PropertyChange(string propertyName)
        {
            PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}
