using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ExamenProject.Screens
{
    internal class StartScreen
    {
        public static Button button;
        public static bool startScreen = true;
        public static void Update()
        {
            if (button.clicked) startScreen = false;
            button.Update();
        }
        public static void Draw(SpriteBatch spriteBatch, SpriteFont font, Texture2D texture, Texture2D backgroundTexture)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1500, 900), Color.White);
            spriteBatch.DrawString(font, "Start", new(0, 0), Color.White);
            button.Draw(spriteBatch);
        }
    }
}
