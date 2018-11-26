using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication.PlanetPacket
{
    class Mars : Planet
    {
        public int[,] MarsMap = new int[15, 15];

        public override int[,] Map()
        {
            return MarsMap;
        }

    }
}
