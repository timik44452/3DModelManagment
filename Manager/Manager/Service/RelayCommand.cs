using System;
using System.Windows.Input;

namespace Manager.Service
{
    public class RelayCommand<T> : ICommand
    {
        private Action<T> execute;
        private Func<bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Func<bool> canExecute = null)
        {
            RegisterCallback(execute);
            this.canExecute = canExecute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            RegisterCallback(execute);
            this.canExecute = canExecute;
        }

        public void RegisterCallback(Action callback)
        {
            execute += x => callback?.Invoke();
        }

        public void RegisterCallback(Action<T> callback)
        {
            execute += callback;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(T parameter)
        {
            execute?.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            execute?.Invoke((T)parameter);
        }
    }
}