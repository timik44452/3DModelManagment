using System;
using Manager.Service;
using System.Windows.Input;

namespace Manager.Pages.ViewModels
{
    public class UserEnterPageViewModel : PageViewModel
    {
        public event Action OnAccept;

        public string Login
        {
            get => login;
            set
            {
                login = value;
                CheckAuthorization();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                CheckAuthorization();
            }
        }

        public ICommand Authorization
        {
            get
            {
                if(authorization == null)
                {
                    authorization = new RelayCommand(
                        CheckAuthorization);
                        
                }

                return authorization;
            }
        }


        private string login;
        private string password;
        private ICommand authorization;

        private void CheckAuthorization()
        {
            
            if (login == "admin" && password == "admin")
                OnAccept?.Invoke();
        }
    }
}
