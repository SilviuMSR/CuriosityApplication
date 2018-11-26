using CuriosityApplication.ExplorerP;
using CuriosityApplication.PlanetPacket;
using CuriosityApplication.UserP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;

namespace CuriosityApplication
{
    class Staff : User , IStaffRoles
    {

        private string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files");


        public Staff(string Username, string Password) : base(Username, Password)
        {

        }




        /* Function used to write failed or success movments to a specific file*/
        public void WriteToFile(int x, int y, Explorer explorer, Planet planet, string filename, string user)
        {

            string FileInput = "";


            if (filename == "FailedMovments.txt")
            {
                FileInput = $"{user}" + " Wrong movment from " + $"{x}" + " to " + $"{y}" + " at " + $"{planet.GetPlanetType(planet)}" + " made by " + $"{explorer.GetExplorerType(explorer)}" + " with " + $"{explorer._Orientation}" + " orientation";
            }
            else if (filename == "SuccessMovments.txt")
            {
                FileInput = $"{user}" + " Success movment from " + $"{x}" + " to " + $"{y}" + " at " + $"{planet.GetPlanetType(planet)}" + " made by " + $"{explorer.GetExplorerType(explorer)}" + " with " + $"{explorer._Orientation}" + " orientation";
            }
            
            try
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(FilePath, filename), append: true))
                {
                    outputFile.WriteLine(FileInput);
                    outputFile.Close();
                }

                using (StreamWriter allcommandsFile = new StreamWriter(Path.Combine(FilePath, "AllCommands.txt"), append: true))
                {
                    allcommandsFile.WriteLine(FileInput);
                    allcommandsFile.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Could not write to file WrongMovments");
            }
        }




        public void ReadFromFile(string filename)
        {

            string[] FileContent = new string[128];
            string line = "";
            int FileSize = 0;

            try
            {
                using (StreamReader inputFile = new StreamReader(Path.Combine(FilePath, filename)))
                {
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        FileContent[FileSize++] = line;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("We can't read from this file");
            }

            for(int i = 0; i < FileSize; i++)
            {
                Console.WriteLine(FileContent[i]);
            }
        }




        /* Option of staff to move the explorer on planet
            Width = MapWidth and Height = MapHeight*/
        public void MovePosititon(int x, int y, Planet planet, Explorer explorer, string user, int Width, int Height)
        {
            /* First get orientation type */
            if (GetOrientation(explorer).Equals("n"))
            {
                /* If position where we want to move the explorer is ok with the orientation.*/
                if (y == explorer._InitialY && (x == explorer._InitialX - 1))
                {
                    /* Move the explorer and save its new coordinates*/
                    explorer.ExplorerToMovePosition(x, y, Width, Height);
                    /* Display updated map */
                    explorer.ExplorerDisplayCurrentPosition(planet.Map(), Width, Height);
                    /* Write to file as success movment */
                    WriteToFile(x, y, explorer, planet, "SuccessMovments.txt", user);
                    WriteToFile(x, y, explorer, planet, "AllComands.txt", user);
                }
                else
                {
                    Console.WriteLine("Invalid move, try again");
                    /* Write to file as failed movment */
                    WriteToFile(x, y, explorer, planet, "FailedMovments.txt", user);
                    WriteToFile(x, y, explorer, planet, "AllComands.txt", user);
                    explorer.ExplorerDisplayCurrentPosition(planet.Map(), Width, Height);
                }
            }
            else if (GetOrientation(explorer).Equals("s"))
            {
                if (y == explorer._InitialY && (x == explorer._InitialX + 1))
                {
                    explorer.ExplorerToMovePosition(x, y, Width, Height);
                    explorer.ExplorerDisplayCurrentPosition(planet.Map(), Width, Height);

                    WriteToFile(x, y, explorer, planet, "SuccessMovments.txt", user);
                    WriteToFile(x, y, explorer, planet, "AllComands.txt", user);
                }
                else
                {
                    Console.WriteLine("Invalid move, try again");
                    WriteToFile(x, y, explorer, planet, "FailedMovments.txt", user);
                    WriteToFile(x, y, explorer, planet, "AllComands.txt", user);
                    explorer.ExplorerDisplayCurrentPosition(planet.Map(), Width, Height);
                }
            }
            else if (GetOrientation(explorer).Equals("e"))
            {
                if (x == explorer._InitialX && (y == explorer._InitialY + 1))
                {
                    explorer.ExplorerToMovePosition(x, y, Width, Height);
                    explorer.ExplorerDisplayCurrentPosition(planet.Map(), Width, Height);

                    WriteToFile(x, y, explorer, planet, "SuccessMovments.txt", user);
                    WriteToFile(x, y, explorer, planet, "AllComands.txt", user);
                }
                else
                {
                    Console.WriteLine("Invalid move, try again");
                    WriteToFile(x, y, explorer, planet, "FailedMovments.txt", user);
                    WriteToFile(x, y, explorer, planet, "AllComands.txt", user);
                    explorer.ExplorerDisplayCurrentPosition(planet.Map(), Width, Height);
                }
            }
            else if (GetOrientation(explorer).Equals("w"))
            {
                if (x == explorer._InitialX && (y == explorer._InitialY - 1))
                {
                    explorer.ExplorerToMovePosition(x, y, Width, Height);
                    explorer.ExplorerDisplayCurrentPosition(planet.Map(), Width, Height);

                    WriteToFile(x, y, explorer, planet, "SuccessMovments.txt", user);
                    WriteToFile(x, y, explorer, planet, "AllComands.txt", user);
                }
                else
                {
                    Console.WriteLine("Invalid move, try again");
                    WriteToFile(x, y, explorer, planet, "FailedMovments.txt", user);
                    WriteToFile(x, y, explorer, planet, "AllComands.txt", user);
                    explorer.ExplorerDisplayCurrentPosition(planet.Map(), Width, Height);
                }
            }
            
        }



        /* Display all commands made by all users */
        public void MoveHistory()
        {
            ReadFromFile("AllCommands.txt");
        }



        /* Get current orientation of the explorer */
        public string GetOrientation(Explorer explorer)
        {

            return "Explorer current orientation is " + explorer._Orientation;
            
        }



        /* Change current orientation of the explorer with a new one*/
        public void ChangeOrientation(Explorer explorer, string NewOrientation)
        {
            
            if (NewOrientation != "s" && NewOrientation != "w" && NewOrientation != "e" && NewOrientation != "n")
            {
                Console.WriteLine("This orientation is not in list, sorry but you need to insert a good one in order to continue!");
            }
            else
            {
                explorer._Orientation = NewOrientation;
                Console.WriteLine("Your current orientation is " + NewOrientation);
            }
        }
    }
}
