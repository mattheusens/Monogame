using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ExamenProject.Interfaces;
using ExamenProject.Loaders;
using ExamenProject.Characters;
using ExamenProject.Levels;
using System.Diagnostics;

namespace ExamenProject.Screens
{
    internal class GameScreen : IScreenState
    {
        Screen screen;
        CurrentLevel levels;

        Hero hero; 
        Texture2D heroTexture;

        private bool menuPressed = false;

        public static string Color = "Blue";

        public GameScreen(Screen screen)
        {
            this.screen = screen;

            ContentManager Content = ContentLoader.getInstance().contentM;
            heroTexture = Content.Load<Texture2D>($"Warrior_{Color}_Full"); 

            hero = new Hero(heroTexture, new(750, 450));
            levels = new CurrentLevel(hero);
            levels.getState().init();
        }

        public void Update(GameTime gameTime)
        {
            levels.getState().Update(gameTime);

            if (hero.health == 0) goToEndScreen();

            if (Keyboard.GetState().IsKeyDown(Keys.P)) menuPressed = true;
            if (Keyboard.GetState().IsKeyUp(Keys.P) && menuPressed) 
            {
                goToMenuScreen();
                menuPressed = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            levels.getState().Draw(spriteBatch);
        }

        public void goToStartScreen() 
        { 
            // Impossible
        }
        public void goToBugScreen() 
        { 
            // Impossible
        }
        public void goToGame() 
        {
            // Already here
        }
        public void goToMenuScreen() 
        {
            screen.setState(screen.getMenuScreen());
        }
        public void goToEndScreen() 
        {
            screen.setState(screen.getGameOverScreen());
        }
        public void exitGame() 
        {
            // Impossible
        }
    }
}
