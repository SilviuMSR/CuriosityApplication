using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication
{
    abstract class User
    {

        public string _Username { get; private set; }
        public string _Password { get; private set; }

        public User(string Username, string Password)
        {
            _Username = Username;
            _Password = Password;
        }

    }
}
