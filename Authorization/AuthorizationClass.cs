using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;

namespace Authorization
{
    internal class AuthorizationClass
    {
        public static Exception LogIn(string login, string password)
        {
            Exception exceptions = null;
            string errors = null;
            Exception loginEx = Check.CheckLogInLogin(login);
            Exception passwordEx = Check.CheckPassword(password);
            string[] users = File.ReadAllLines(@"..\..\Users.txt");
            if (loginEx == null && passwordEx == null)
            {
                foreach (string item in users)
                {
                    if (item.Length > 0 && login == item.Substring(0, item.IndexOf(':')))
                    {
                        if (password == item.Substring(item.IndexOf(':') + 1)) return exceptions;
                    }
                }
                errors += "Пароль неверный!";
            }
            else
            {
                if (loginEx != null) errors += loginEx.Message + "\n";
                if (passwordEx != null) errors += passwordEx.Message;
                
            }
            exceptions = new Exception(errors);
            return exceptions;
        }
        public static Exception Registration(string login, string password, string confirmpassword)
        {
            Exception exceptions = null;
            string errors = null;
            Exception loginEx = Check.CheckRegistrationLogin(login);
            Exception passwordsEx = Check.CheckAndComparePasswords(password, confirmpassword);
            if (loginEx == null && passwordsEx == null)
            {
                File.AppendAllLines(@"..\..\Users.txt", new string[] { login + ':' + password });
            }
            else
            {
                if (loginEx != null) errors += loginEx.Message + "\n";
                if (passwordsEx != null) errors += passwordsEx.Message;

                exceptions = new Exception(errors);
            }
            return exceptions;
        }
    }
}
