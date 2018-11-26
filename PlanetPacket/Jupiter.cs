using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication.PlanetPacket
{
    class Jupiter : Planet
    {

        public int[,] JupiterMap = new int[12, 12];
        public override int[,] Map()
        {
            return JupiterMap;
        }

    }
}
