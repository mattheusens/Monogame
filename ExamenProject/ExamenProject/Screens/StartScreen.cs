using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ExamenProject.Screens
{
    internal class StartScreen
    {
        private static StartScreen startScreen = new StartScreen();

        public bool startScreenOn = true;
        private Button startButton;
        private SpriteFont font;

        private StartScreen()
        {
            font = MedievalFont.getInstance().font;
            ContentManager Content = ContentLoader.getInstance().contentM;

            Texture2D buttonTexture = Content.Load<Texture2D>("MenuScreen/MenuTitle");
            startButton = new Button(buttonTexture, new Vector2(100, 100), font);
        }

        public static StartScreen getInstance()
        {
            return startScreen;
        }

        public void Update()
        {
            if (startButton.clicked) startScreenOn = false;
            startButton.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Texture2D backgroundTexture)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1500, 900), Color.White);
            spriteBatch.DrawString(font, "Start", new(0, 0), Color.White);
            startButton.Draw(spriteBatch);
        }
    }
}
