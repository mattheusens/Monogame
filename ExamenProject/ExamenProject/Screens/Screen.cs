using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Screens
{
    public class Screen
    {
        IScreenState startScreen;
        IScreenState bugScreen;
        IScreenState gameScreen;
        IScreenState menuScreen;
        IScreenState gameOverScreen;
        public IScreenState state;

        public Screen()
        {
            startScreen = new StartScreen(this);
            bugScreen = new BugScreen(this);
            gameScreen = new GameScreen(this);
            menuScreen = new MenuScreen(this);
            gameOverScreen = new GameOverScreen(this);
            state = startScreen;
        }

        public void setState(IScreenState state)
        {
            this.state = state;
        }


        public IScreenState getStartScreen()
        {
            return startScreen;
        }
        public IScreenState getBugScreen()
        {
            return bugScreen;
        }
        public IScreenState getGameScreen()
        {
            return gameScreen;
        }
        public IScreenState getMenuScreen()
        {
            return menuScreen;
        }
        public IScreenState getGameOverScreen()
        {
            return gameOverScreen; 
        }
    }
}
