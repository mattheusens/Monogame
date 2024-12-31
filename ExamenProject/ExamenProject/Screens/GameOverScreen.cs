using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ExamenProject.Interfaces;
using ExamenProject.Loaders;
using System.Diagnostics;

namespace ExamenProject.Screens
{
    internal class GameOverScreen : IScreenState
    {
        Screen screen;

        private Texture2D buttonTexture;
        private Button restartButton;
        private Vector2 basePositionRestart;
        private Vector2 offsetRestart;

        private Texture2D background;
        private SpriteFont font;

        public GameOverScreen(Screen screen)
        {
            this.screen = screen;

            font = MedievalFont.getInstance().font;
            ContentManager Content = ContentLoader.getInstance().contentM;

            background = Content.Load<Texture2D>("Screens/BackgroundFilterGameOver");
            buttonTexture = Content.Load<Texture2D>("Screens/Button");

            basePositionRestart = new(750 - buttonTexture.Width / 4 * 3, 450);
            restartButton = new Button(buttonTexture, basePositionRestart, 1.5f);
            offsetRestart = new(650, 465);
            offsetRestart = new(44, 15);
        }


        public void Update(GameTime gameTime)
        {
            restartButton.Update();
            if (restartButton.clicked) goToStartScreen();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
            restartButton.Draw(spriteBatch);
            spriteBatch.DrawString(font, "GAME OVER", new(440, 250), Color.White, 0, new(0, 0), 3, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Restart", basePositionRestart + offsetRestart, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
        }

        public void goToStartScreen() 
        {
            restartButton.clicked = false;
            screen.setState(screen.getStartScreen());
        }
        public void goToBugScreen() 
        {
            // Impossible
        }
        public void goToGame() 
        {

            screen.setState(screen.getGameScreen());
        }
        public void goToMenuScreen() 
        {
            // Impossible
        }
        public void goToEndScreen() 
        {
            // Already here
        }
        public void exitGame() 
        {
            screen.quit = true;
        }
    }
}
