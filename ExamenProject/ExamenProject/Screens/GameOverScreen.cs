using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ExamenProject.Interfaces;

namespace ExamenProject.Screens
{
    internal class GameOverScreen : IScreenState
    {
        private static GameOverScreen gameOverScreen = new GameOverScreen();

        public Button restartButton;
        private Texture2D restartTexture;
        private Vector2 basePositionRestart;
        private Vector2 offsetRestart;

        private Texture2D backgroundFilter;
        private SpriteFont font;
        private string text;

        private GameOverScreen()
        {
            font = MedievalFont.getInstance().font;
            ContentManager Content = ContentLoader.getInstance().contentM;

            backgroundFilter = Content.Load<Texture2D>("Screens/BackgroundFilterGameOver");
            restartTexture = Content.Load<Texture2D>("Screens/Button");

            restartButton = new Button(restartTexture, new(750 - restartTexture.Width / 4 * 3, 500), 1.5f);
        }

        public static GameOverScreen getInstance()
        {
            return gameOverScreen;
        }

        public void Update()
        {
            restartButton.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundFilter, new Vector2(0, 0), null, Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
            restartButton.Draw(spriteBatch);
            spriteBatch.DrawString(font, "GAME OVER", new(440, 250), Color.White, 0, new(0, 0), 3, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Restart", new(650, 515), Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
        }

        public void goToGame() { }
        public void goToStartScreen() { }
        public void goToBugScreen() { }
        public void goToEndScreen() { }
        public void goToMenuScreen() { }
    }
}
