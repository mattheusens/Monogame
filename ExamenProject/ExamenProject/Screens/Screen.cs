using ExamenProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Screens
{
    public class Screen
    {
        IScreenState bugScreen;
        IScreenState gameOverScreen;
        IScreenState startScreen;
        IScreenState menuScreen;
        IScreenState gameScreen;
        IScreenState state;

        public Screen()
        {
            bugScreen = BugScreen.getInstance();
            gameOverScreen = GameOverScreen.getInstance();
            startScreen = StartScreen.getInstance();
            menuScreen = MenuScreen.getInstance();
            gameScreen = new GameScreen(this);
            state = startScreen;
        }

        void setState(IScreenState state)
        {
            this.state = state;
        }
    }
}
