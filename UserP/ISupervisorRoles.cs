using System;
using System.Collections.Generic;
using System.Text;

namespace CuriosityApplication.UserP
{
    interface ISupervisorRoles
    {
        void GetFailedLoginAttempts();
        void GetUserCommands(User UserName);
        void GetAllUserCommands();

    }
}
