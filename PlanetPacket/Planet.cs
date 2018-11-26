using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication.PlanetPacket
{
    abstract class Planet
    {
        public abstract int[,] Map();




        /* Set the current map with 0 at all positions, only where the explorer is situated put 1*/
        public void SetPostion(int x, int y, int[,] PlanetMap, int Width, int Height)
        {
            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    if(i == x && j == y)
                    {
                        PlanetMap[i, j] = 1;                
                    }
                    else
                    {
                        PlanetMap[i, j] = 0;
                    }
                }
            }
        }




        public string GetPlanetType(Planet planet)
        {
            if(planet is Mars)
            {
                return "Mars";
            }
            else if(planet is Jupiter)
            {
                return "Jupiter";
            }
            else
            {
                return "Not know planet";
            }
        }
    }
}
