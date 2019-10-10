using System;
using Manager.Service;
using Manager.Security;
using System.Windows.Input;

namespace Manager.Pages.ViewModels
{
    public class UserEnterPageViewModel : PageViewModel
    {
        public event Action OnAccept;

        public string Login { get; set; }

        public ICommand AuthorizationCommand
        {
            get
            {
                if(authorizationCommand == null)
                {
                    authorizationCommand = new RelayCommand(CheckAuthorization);
                    CheckAuthorization();
                }

                return authorizationCommand;
            }
        }

        private ICommand authorizationCommand;

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
