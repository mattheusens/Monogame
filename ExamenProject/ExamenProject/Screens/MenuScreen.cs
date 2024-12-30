using ExamenProject.Interfaces;
using ExamenProject.Loaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExamenProject.Screens
{
    internal class MenuScreen : IScreenState
    {
        Screen screen;

        static bool pause = false;
        static bool pPressed = false;
        static Texture2D bigScreen;
        static Texture2D backgroundFilter;
        
        static SpriteFont font;

        public MenuScreen(Screen screen)
        {
            this.screen = screen;

            font = MedievalFont.getInstance().font;

            ContentManager Content = ContentLoader.getInstance().contentM;

            bigScreen = Content.Load<Texture2D>("Screens/BigScreen");
            backgroundFilter = Content.Load<Texture2D>("Screens/BackgroundFilter");
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P)) goToGame();
        }

        public void Draw(SpriteBatch spriteBatch)
        {   
            spriteBatch.Draw(backgroundFilter, new Vector2(0, 0), null, Color.White, 0.0f, new Vector2(0, 0), 2.0f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(bigScreen, new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2), null, Color.White, 0.0f, new Vector2(96, 96), 4.5f, SpriteEffects.None, 1.0f);

            spriteBatch.DrawString(font, "Menu", new Vector2(750, 200), Color.White, 0, new Vector2(50, 50), 2f, SpriteEffects.None, 0);   
        }

        public void goToStartScreen() 
        { 
            // Need to make this
        }
        public void goToBugScreen() 
        {
            // Need to make this
        }
        public void goToGame() 
        {
            screen.setState(screen.getGameScreen());
        }
        public void goToMenuScreen() 
        { 
            // Already here
        }
        public void goToEndScreen() 
        {
            // Impossible
        }
        public void exitGame()
        {
            // Need to make this
        }
    }
}
