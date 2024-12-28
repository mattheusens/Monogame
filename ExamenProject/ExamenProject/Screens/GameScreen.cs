using ExamenProject.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Screens
{
    internal class GameScreen : IScreenState
    {
        Screen screen;
        public GameScreen(Screen screen)
        {
            this.screen = screen;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void goToGame() { }
        public void goToStartScreen() { 
            
        }
        public void goToBugScreen() { }
        public void goToEndScreen() { }
        public void goToMenuScreen() { 
        
        }
    }
}
