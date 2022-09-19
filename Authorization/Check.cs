using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Authorization
{
    internal class Check
    {
        static Regex regex = new Regex(@"[a-z0-9]|_", RegexOptions.IgnoreCase);
        public static Exception CheckPassword(string password)
        {
            MatchCollection matches = regex.Matches(password);
            Exception exceptions = null;
            string errors = null;
            if (matches.Count != password.Length)
            {
                errors += "Вводить можно только латиницу, цифры и нижнее подчёркивание!";
            }
            if (password.Length > 20)
            {
                if (errors != null) errors += "\n";
                errors += "Пароль не должен быть длиннее 20 символов!";
            }
            if (password.Length < 3)
            {
                if (errors != null) errors += "\n";
                errors += "Пароль не должен быть короче 3 символов!";
            }
            if (errors != null) exceptions = new Exception(errors);
            return exceptions;
        }
        public static Exception CheckRegistrationLogin(string login)
        {
            string[] logins = File.ReadAllLines(@"..\..\Users.txt").Select(pair => pair.Substring(0, pair.IndexOf(':'))).ToArray();
            MatchCollection matches = regex.Matches(login);
            Exception exceptions = null;
            string errors = null;
            foreach (string item in logins)
            {
                if (item == login)
                {
                    errors += "Пользователь с таким логином уже существует!";
                }
            }
            if (matches.Count != login.Length)
            {
                if (errors != null) errors += "\n";
                errors += "Вводить можно только латиницу, цифры и нижнее подчёркивание!";

            }
            if (login.Length > 20)
            {
                if (errors != null) errors += "\n";
                errors += "Логин не должен быть длиннее 20 символов!";

            }
            if (login.Length < 3)
            {
                if (errors != null) errors += "\n";
                errors += "Логин не должен быть короче 3 символов!";
            }
            if (errors != null) exceptions = new Exception(errors);
            return exceptions;
        }
        public static Exception CheckLogInLogin(string login)
        {
            string[] logins = File.ReadAllLines(@"..\..\Users.txt").Where(pair => pair.Length > 0).Select(pair => pair.Substring(0, pair.IndexOf(':'))).ToArray();
            MatchCollection matches = regex.Matches(login);
            Exception exceptions = null;
            string errors = null;
            bool isAlreadyBeen = false;
            foreach (string item in logins)
            {
                if (item == login)
                {
                    isAlreadyBeen = true;
                }
            }
            if (!isAlreadyBeen) errors += "Пользователя с таким ником не существует!";
            if (matches.Count != login.Length)
            {
                if (errors != null) errors += "\n";
                errors += "Вводить можно только латиницу, цифры и нижнее подчёркивание!";
            }
            if (login.Length > 20)
            {
                if (errors != null) errors += "\n";
                errors += "Логин не должен быть длиннее 20 символов!";
            }
            if (login.Length < 3)
            {
                if (errors != null) errors += "\n";
                errors += "Логин не должен быть короче 3 символов!";
            }
            if (errors != null) exceptions = new Exception(errors);
            return exceptions;
        }
        public static Exception CheckAndComparePasswords(string password, string confirmpassword)
        {
            Exception exceptions = null;
            string errors = null;
            Exception passwordEx = CheckPassword(password);
            Exception confirmpasswordEx = CheckPassword(confirmpassword);
            if (passwordEx == null && confirmpasswordEx == null)
            {
                if (password != confirmpassword)
                {
                    errors += "Введённые пароли не совпадают";
                }
            }
            else
            {
                if (passwordEx != null) errors += CheckPassword(password).Message + "\n";
                if (confirmpassword != null) errors += CheckPassword(confirmpassword).Message;
            }
            if (errors != null) exceptions = new Exception(errors);
            return exceptions;
        }
    }
}
