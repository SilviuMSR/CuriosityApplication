using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication
{
    interface IAuthentification
    {
        void Login(string Username, string Password, List<User> Users);

    }
}
