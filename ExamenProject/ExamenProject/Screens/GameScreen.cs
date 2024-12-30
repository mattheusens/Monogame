using ExamenProject.Characters;
using ExamenProject.Interfaces;
using ExamenProject.Map;
using ExamenProject.Map.Nature;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using ExamenProject.Levels;
using System.Diagnostics;
using ExamenProject.Loaders;

namespace ExamenProject.Screens
{
    internal class GameScreen : IScreenState
    {
        Screen screen;
        CurrentLevel levels;

        Hero hero; 
        Texture2D heroTexture; 

        public GameScreen(Screen screen)
        {
            this.screen = screen;

            ContentManager Content = ContentLoader.getInstance().contentM; 
            heroTexture = Content.Load<Texture2D>("Warrior_Blue_Full"); 

            Maps.MakeMaps(); 

            hero = new Hero(heroTexture);
            levels = new CurrentLevel(hero);
            levels.getState().init();
        }

        public void Update(GameTime gameTime)
        {
            levels.getState().Update(gameTime);

            if (hero.health == 0) goToEndScreen();
            if (Keyboard.GetState().IsKeyDown(Keys.P)) goToMenuScreen();
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
