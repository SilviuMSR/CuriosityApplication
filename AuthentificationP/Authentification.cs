using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CuriosityApplication
{
    class Authentification : IAuthentification
    {

        public static int LoggedIn = 0;
        public static int Position = 0; /* used to keep the position of the logged in user because we need to know what kind of user it is*/

        private string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files");


        /* Function used to verify if inserted user exist in initial list*/
        public void Login(string Username, string Password, List<User> Users)
        {
            /* Check current list of Users to see if there is a user with the given input*/
            foreach(var user in Users)
            {
                /* If we find in that list an user with that username and password, means that login is ok*/
                if(user._Username == Username && user._Password == Password)
                {
                    Console.WriteLine("Successfully logged in!");
                    LoggedIn = 1;
                    break;
                }
                Position++;
            }

            if(LoggedIn == 0)
            {
                /* Write inside file all failed login sessions */
                string FileInput = $"{Username}" + " " + $"{Password}";

                try
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(FilePath, "FailedLoggin.txt"), append: true))
                    {
                        outputFile.WriteLine(FileInput);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Could not write to file");
                }
                
                return;
            }
        }



        public int GetPosition()
        {
            return Position;
        }



        public int GetLoggedIn()
        {
            return LoggedIn;
        }

    }
}
