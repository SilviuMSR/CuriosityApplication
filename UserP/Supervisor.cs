using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CuriosityApplication.UserP;

namespace CuriosityApplication
{
    class Supervisor : User , ISupervisorRoles
    {

        private string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files");




        public Supervisor(string Username, string Password) : base(Username, Password)
        {

        }




        public void WriteToFile(string filename, string name)
        {

            string line = "";

            try
            {
                using (StreamReader inputFile = new StreamReader(Path.Combine(FilePath, filename)))
                {
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        // TODO string[] = line.Split(Convert.ToChar(" "))
                        string[] words = line.Split(Convert.ToChar(" "));
                        // TODO traverse and take last element
                        if (words[0] == name)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("We can't read from this file");
            }
        }



        /* Get all failed login attempts*/
        public void GetFailedLoginAttempts()
        { 
            try
            {
                using (StreamReader inputFile = new StreamReader(Path.Combine(FilePath, "FailedLoggin.txt")))
                {
                    string line = inputFile.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.Write("We can't read from this file");
            }
        }



        /* Get all success and failed movments for a specific user*/
        public void GetUserCommands(User UserName)
        {
            if(UserName is Supervisor)
            {
                throw new InvalidDataException();
            }

            Console.WriteLine("Successuflly commands:");
            WriteToFile("SuccessMovments.txt", UserName._Username);

            Console.WriteLine("Failed commands:");
            WriteToFile("FailedMovments.txt", UserName._Username);

        }



        /* Get all success and failed movments for all users*/
        public void GetAllUserCommands()
        {
            string line = "";

            try
            {
                using (StreamReader inputFile = new StreamReader(Path.Combine(FilePath, "AllCommands.txt")))
                {
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("We can't read from this file");
            }

        }
    }
}
