using CuriosityApplication.PlanetPacket;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication.ExplorerP
{
    abstract class Explorer
    {
        public int _InitialX { get; set; }
        public int _InitialY { get; set; }
        public string _Orientation { get; set; }

        private Planet _Planet;




        public Explorer(int InitialX, int InitialY, string Orientation, Planet planet)
        {
            _InitialX = InitialX;
            _InitialY = InitialY;
            _Orientation = Orientation;
            _Planet = planet;
        }




        /* Set where the explorer is situated when program starts*/
        public void ExplorerSetInitialPosition(int Width, int Height)
        {

            _Planet.SetPostion(_InitialX, _InitialY, _Planet.Map(), Width, Height);

        }




        /* When a movment was executed move the explorer on map and set its initial positions with actual ones*/
        public void ExplorerToMovePosition(int x, int y, int Width, int Height)
        {

                _Planet.SetPostion(x, y, _Planet.Map(), Width, Height);
                _InitialX = x;
                _InitialY = y;
            
        }




        /* Display current position of the explorer*/
        public void ExplorerDisplayCurrentPosition(int[,] PlanetMap, int Width, int Height)
        {
            for (int i = 0; i < Width; i++)
            {
                if (i >= 10)
                {
                    Console.Write(i + " ");
                }
                else
                {
                    Console.Write(i + "  ");
                }
                for (int j = 0; j < Height; j++)
                {

                    Console.Write(PlanetMap[i, j] + " ");
                }
                Console.WriteLine();
            }
        }




        public string GetExplorerType(Explorer explorer)
        {
            if(explorer is CuriosityExplorer)
            {
                return "Curiosity";
            }
            else
            {
                return "Not know exploerer";
            }
        }
    }
}
