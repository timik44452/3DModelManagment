using System;
using System.Windows.Input;
using Manager.Security;
using Manager.Service;

namespace Manager.Pages.ViewModels
{
    public class UserEnterPageViewModel : PageViewModel
    {
        public event Action OnAccept;

        public string Login { get; set; }

        public ICommand AuthorizationCommand
        {
            get;
            set;
        }

        public UserEnterPageViewModel()
        {
            AuthorizationCommand = new RelayCommand<object>(CheckAuthorization);
            AuthorizationCommand.Execute(null);
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CheckAuthorization();
            }
        }

        private void CheckAuthorization()
        {
            var userHash = UserHash.FromUserData(Login);

            if (Authorization.CheckAuthorization(userHash))
            {
                OnAccept?.Invoke();
            }
        }
    }
}