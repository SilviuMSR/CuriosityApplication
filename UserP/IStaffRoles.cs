using CuriosityApplication.ExplorerP;
using CuriosityApplication.PlanetPacket;
using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication.UserP
{
    interface IStaffRoles
    {
        void MovePosititon(int x, int y, Planet planet, Explorer explorer, string user, int Width, int Height);
        void MoveHistory();
        string GetOrientation(Explorer explorer);
        void ChangeOrientation(Explorer explorer, string NewOrientation);

    }
}
