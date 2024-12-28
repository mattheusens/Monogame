using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Interfaces
{
    internal interface IScreenState
    {
        void goToGame();
        void goToStartScreen();
        void goToBugScreen();
        void goToEndScreen();
        void goToMenuScreen();
    }
}
