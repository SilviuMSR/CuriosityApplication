using CuriosityApplication.ExplorerP;
using CuriosityApplication.PlanetPacket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CuriosityApplication
{
    class ProgramInitializer
    {

        /* Initial list of users */
        public List<User> _Users = new List<User>()
        {
            new Supervisor("Mircea", "123"),
            new Staff("Cristi", "1234"),
            new Staff("Silviu", "aaaa"),
            new Supervisor("Patricia", "bbbb"),
        };



        public Authentification Auth;
        public Planet planet;
        public Explorer explorer;


        public void CreateUserAccount(string username, string password, string userType)
        {
            if (userType.ToLower() == "staff")
            {
                _Users.Add(new Staff(username, password));
            }
            else if (userType.ToLower() == "supervisor")
            {
                _Users.Add(new Supervisor(username, password));
            }

            Console.WriteLine("Your account was successfully created. Please Login now");
        }

        /* Method to authentificate client */
        public void AuthToAcount()
        {
            Auth = new Authentification();

            Console.WriteLine("Insert username:");
            string Username = Console.ReadLine();
            Console.WriteLine("Insert password:");
            string Password = Console.ReadLine();

            Auth.Login(Username, Password, _Users);
            if (Auth.GetLoggedIn() == 0)
            {
                Console.WriteLine("Sorry, you don't have an account!");
            }

        }


        /* Method to initialize the planet */
        public void CreatePlanet()
        {
            planet = new Mars();
            Console.WriteLine("Planet was successfully initialized....");
        }


        /* Method to initialize and create the explorer */
        public void CreateExplorer()
        {

            if (_Users.ElementAt(Auth.GetPosition()) is Staff)
            {
                
                Console.WriteLine("Insert initial x position");
                int Initialx = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Insert initial y position");
                int Initialy = Convert.ToInt32(Console.ReadLine());

                if (Initialx > 15 || Initialy > 15)
                {
                    throw new IndexOutOfRangeException();
                }

                Console.WriteLine("Insert initial orientation w/s/n/e");
                string InitialOrientation = Console.ReadLine();


                Console.WriteLine("Explorer successfully initialized....");
                explorer = new CuriosityExplorer(Initialx, Initialy, InitialOrientation, planet);
                explorer.ExplorerSetInitialPosition(15, 15);
                explorer.ExplorerDisplayCurrentPosition(planet.Map(), 15, 15);
            }
        }



        public void DisplayRoles()
        {
            User user = _Users.ElementAt(Auth.GetPosition());

            if (user is Staff)
            {

                while (true)
                {
                    Console.WriteLine("1.Move Position");
                    Console.WriteLine("2.Move History");
                    Console.WriteLine("3.Get Orientation");
                    Console.WriteLine("4.Change Orientation");

                    string option = "-1";
                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Insert new x coordinate");
                            int NewX = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Insert new y coordinate");
                            int NewY = Convert.ToInt32(Console.ReadLine());
                            
                            ((Staff)user).MovePosititon(NewX, NewY, planet, explorer, user._Username, 15, 15);
                            break;

                        case "2":
                            ((Staff)user).MoveHistory();
                            break;

                        case "3":
                            Console.WriteLine(((Staff)user).GetOrientation(explorer));
                            break;

                        case "4":
                            Console.WriteLine("Insert new orientation");
                            string NewOrientation = Console.ReadLine();
                            ((Staff)user).ChangeOrientation(explorer, NewOrientation);
                            break;

                        case "5":
                            return;
                    }
                }

            }
            else if (user is Supervisor)
            {

                while (true)
                {

                    Console.WriteLine("1.Get failed loggin attempts");
                    Console.WriteLine("2.Get user command for a speecific user");
                    Console.WriteLine("3.Get user command for all users");

                    string option = "-1";
                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            ((Supervisor)user).GetFailedLoginAttempts();
                            break;

                        case "2":
                            Console.WriteLine("You need commands of which user?");
                            string name = Console.ReadLine();
                            int FindPosition = 0;

                            foreach (var u in _Users)
                            {
                                if (u._Username == name)
                                {
                                    break;
                                }
                                FindPosition++;
                            }
                            try
                            {
                                ((Supervisor)user).GetUserCommands(_Users.ElementAt(FindPosition));
                            }
                            catch (InvalidDataException)
                            {
                                Console.WriteLine("You can't find commands about this user");
                            }

                            break;

                        case "3":
                            ((Supervisor)user).GetAllUserCommands();
                            break;

                        case "4":
                            return;
                    }
                }

            }
            else
            {
                Console.WriteLine("Unknown");
            }
        }


    }
}
