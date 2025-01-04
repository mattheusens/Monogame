using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ExamenProject.Interfaces;
using ExamenProject.Loaders;
using ExamenProject.Characters;
using ExamenProject.Levels;

namespace ExamenProject.Screens
{
    internal class GameScreen : IScreenState
    {
        Screen screen;
        public CurrentLevel levels;

        Hero hero; 
        Texture2D heroTexture;

        private bool menuPressed = false;

        public static string color = "Red";

        public static int coins = 0;

        public GameScreen(Screen screen)
        {
            this.screen = screen;

            ContentManager Content = ContentLoader.getInstance().contentM;
            heroTexture = Content.Load<Texture2D>($"Characters/{GameScreen.color}/Hero"); 

            hero = new Hero(heroTexture, new(750, 450));
            levels = new CurrentLevel(hero);
            levels.getState().initMap();
            levels.getState().initEnemies();
        }

        public void Update(GameTime gameTime)
        {
            levels.getState().Update(gameTime);

            if (coins >= 200) goToGameWonScreen();

            if (hero.health == 0) goToGameOverScreen();

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

            spriteBatch.DrawString(MedievalFont.getInstance().font, "Coins: " + coins, new Vector2(20, 20), Color.White);
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
        public void goToGameWonScreen()
        {
            resetGame();

            screen.setState(screen.getGameWonScreen());
        }
        public void goToGameOverScreen() 
        {
            resetGame();

            screen.setState(screen.getGameOverScreen());
        }
        public void exitGame() 
        {
            // Impossible
        }
        private void resetGame()
        {
            hero.move.posX = 750;
            hero.move.posY = 450;
            hero.health = 3;
            coins = 0;

            levels.setState(levels.getLevel1());
            levels.getLevel1().initMap();
            levels.getLevel1().initEnemies();
        }
    }
}
