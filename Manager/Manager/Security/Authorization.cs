using System.Windows;

namespace Manager.Security
{
    public static class Authorization
    {
        public static string GetLogin()
        {
            object login = Application.Current.TryFindResource("Login");

            if (login == null)
            {
                return string.Empty;
            }

            return login.ToString();
        }

        public static bool CheckAuthorization(UserHash userHash)
        {
            if (userHash.Equals(UserHash.FromUserData("admin")))
            {
                if (!Application.Current.Resources.Contains("Login"))
                    Application.Current.Resources.Add("Login", UserHash.GetLogin(userHash));
                else
                    Application.Current.Resources["Login"] = UserHash.GetLogin(userHash);

                return true;
            }

            return false;
        }
    }
}