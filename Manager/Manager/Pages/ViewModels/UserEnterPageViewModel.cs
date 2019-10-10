using System;
using System.ComponentModel;

namespace Manager.Pages.ViewModels
{
    public class UserEnterPageViewModel : PageViewModel
    {
        public string Login
        {
            get => login;
            set => login = value;
        }
        public string Password
        {
            get => password;
            set => password = value;
        }


        private string login;
        private string password;
    }
}
