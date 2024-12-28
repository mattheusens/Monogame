using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExamenProject.Screens
{
    internal class MenuScreen : IScreenState
    {
        private static MenuScreen menuScreen = new MenuScreen();

        static bool pause = false;
        static bool pPressed = false;
        static Texture2D bigScreen;
        static Texture2D backgroundFilter;
        
        static SpriteFont font;

        private MenuScreen()
        {
            font = MedievalFont.getInstance().font;

            ContentManager Content = ContentLoader.getInstance().contentM;

            bigScreen = Content.Load<Texture2D>("Screens/BigScreen");
            backgroundFilter = Content.Load<Texture2D>("Screens/BackgroundFilter");
        }

        public static MenuScreen getInstance()
        {
            return menuScreen;
        }

        public void Update()
        {
            CheckPause();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (pause)
            {
                spriteBatch.Draw(backgroundFilter, new Vector2(0, 0), null, Color.White, 0.0f, new Vector2(0, 0), 2.0f, SpriteEffects.None, 0.0f);
                spriteBatch.Draw(bigScreen, new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2), null, Color.White, 0.0f, new Vector2(96, 96), 4.5f, SpriteEffects.None, 1.0f);

                spriteBatch.DrawString(font, "Menu", new Vector2(750, 200), Color.White, 0, new Vector2(50, 50), 2f, SpriteEffects.None, 0);
            }
        }

        public void CheckPause()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) && !pPressed)
            {
                pause = !pause;
                pPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.P)) pPressed = false;
        }

        public void goToGame() { }
        public void goToStartScreen() { }
        public void goToBugScreen() { }
        public void goToEndScreen() { }
        public void goToMenuScreen() { }
    }
}
