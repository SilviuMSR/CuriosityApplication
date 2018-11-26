using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CuriosityApplication.PlanetPacket;
using CuriosityApplication.ExplorerP;

namespace CuriosityApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            ProgramInitializer Init = new ProgramInitializer();


            string option = "-1";
            Console.WriteLine("1.Create account");
            Console.WriteLine("2.Login to an existing account");
            option = Console.ReadLine();

            if (option == "1")
            {
                Console.WriteLine("Insert user type, you can choose between Staff and Supervisor");
                string type = Console.ReadLine();
                Console.WriteLine("Insert username");
                string username = Console.ReadLine();
                Console.WriteLine("Insert password");
                string password = Console.ReadLine();
                Init.CreateUserAccount(username, password, type);
            }

            Init.AuthToAcount();
            Init.CreatePlanet();
            try
            {
                Init.CreateExplorer();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("You are out of planet bounds");
            }

            Init.DisplayRoles();



            Console.Read();
        }
    }
}
