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

        private Button startButton;
        private Vector2 basePositionStart;
        private Vector2 offsetStart;

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

            basePositionStart = new(750 - buttonTexture.Width / 4 * 3, 450);
            startButton = new Button(buttonTexture, basePositionStart, 1.5f);
            offsetStart = new(85, 13);

            basePositionRestart = new(750 - buttonTexture.Width / 4 * 3, 600);
            restartButton = new Button(buttonTexture, basePositionRestart, 1.5f);
            offsetRestart = new(44, 13);
        }


        public void Update(GameTime gameTime)
        {
            startButton.Update();
            restartButton.Update();

            if (startButton.clicked) goToStartScreen();
            if (restartButton.clicked) goToGame();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
            
            startButton.Draw(spriteBatch);
            restartButton.Draw(spriteBatch);
            
            spriteBatch.DrawString(font, "GAME OVER", new(440, 250), Color.White, 0, new(0, 0), 3, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Start", basePositionStart + offsetStart, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Restart", basePositionRestart + offsetRestart, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
        }

        public void goToStartScreen() 
        {
            startButton.clicked = false;
            screen.setState(screen.getStartScreen());
        }
        public void goToBugScreen() 
        {
            // Impossible
        }
        public void goToGame() 
        {
            restartButton.clicked = false;
            screen.setState(screen.getGameScreen());
        }
        public void goToMenuScreen() 
        {
            // Impossible
        }
        public void goToGameWonScreen()
        {
            // Impossible
        }
        public void goToGameOverScreen()
        {
            // Already here
        }
        public void exitGame() 
        {
            screen.quit = true;
        }
    }
}
