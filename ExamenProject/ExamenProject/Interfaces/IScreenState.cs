using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Interfaces
{
    public interface IScreenState
    {
        void goToGame();
        void goToStartScreen();
        void goToBugScreen();
        void goToEndScreen();
        void goToMenuScreen();
        void exitGame();

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
