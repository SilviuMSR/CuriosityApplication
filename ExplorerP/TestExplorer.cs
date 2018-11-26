using CuriosityApplication.PlanetPacket;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication.ExplorerP
{
    class TestExplorer : Explorer
    {
        public TestExplorer(int InitialX, int InitialY, string Orientation, Planet planet) : base(InitialX, InitialY, Orientation, planet)
        {

        }
    }
}
