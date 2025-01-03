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
        private SpriteFont font;
        private Texture2D buttonTexture;

        private Texture2D background;
        private Texture2D bigScreen;
        
        private bool menuPressed = false;

        private Button restartLevelButton;
        private Vector2 basePositionRestartL;
        private Vector2 offsetTextRL;

        private Button startButton;
        private Vector2 basePositionStart;
        private Vector2 offsetTextS;

        private Button bugsButton;
        private Vector2 basePositionBugs;
        private Vector2 offsetTextB;

        private Button quitButton;
        private Vector2 basePositionQuit;
        private Vector2 offsetTextQ;

        public MenuScreen(Screen screen)
        {
            this.screen = screen;

            font = MedievalFont.getInstance().font;

            ContentManager Content = ContentLoader.getInstance().contentM;
            
            background = Content.Load<Texture2D>("Screens/MainBackground");
            bigScreen = Content.Load<Texture2D>("Screens/BigScreen");
            buttonTexture = Content.Load<Texture2D>("Screens/Button");

            float buttonSize = 1.5f;
            basePositionRestartL = new(750 - buttonTexture.Width * 2 + 50, 350);
            basePositionStart = new(750 + buttonTexture.Width / 2 - 50, 350);
            basePositionBugs = new(750 - buttonTexture.Width * 2 + 50, 550);
            basePositionQuit = new(750 + buttonTexture.Width / 2 - 50, 550);

            offsetTextRL = new(45, 13);
            offsetTextS = new(85, 13);
            offsetTextB = new(72, 13);
            offsetTextQ = new(85, 13);

            restartLevelButton = new Button(buttonTexture, basePositionRestartL, buttonSize);
            startButton = new Button(buttonTexture, basePositionStart, buttonSize);
            bugsButton = new Button(buttonTexture, basePositionBugs, buttonSize);
            quitButton = new Button(buttonTexture, basePositionQuit, buttonSize);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P)) menuPressed = true;
            if (Keyboard.GetState().IsKeyUp(Keys.P) && menuPressed) 
            {
                goToGame();
                menuPressed = false;
            }

            restartLevelButton.Update();
            startButton.Update();
            bugsButton.Update();
            quitButton.Update();

            if (startButton.clicked) goToStartScreen();
            if (bugsButton.clicked) goToBugScreen();
            if (quitButton.clicked) exitGame();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 1500, 900), Color.White);
            spriteBatch.Draw(bigScreen, new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2), null, Color.White, 0.0f, new Vector2(96, 96), 4.5f, SpriteEffects.None, 1.0f);

            spriteBatch.DrawString(font, "Menu", new Vector2(750, 200), Color.White, 0, new Vector2(50, 50), 2f, SpriteEffects.None, 0);

            restartLevelButton.Draw(spriteBatch);
            startButton.Draw(spriteBatch);
            bugsButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Restart", basePositionRestartL + offsetTextRL, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Start", basePositionStart + offsetTextS, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Bugs", basePositionBugs + offsetTextB, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Quit", basePositionQuit + offsetTextQ, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
        }

        public void goToStartScreen() 
        {
            startButton.clicked = false;
            screen.setState(screen.getStartScreen());
        }
        public void goToBugScreen() 
        {
            bugsButton.clicked = false;
            screen.setState(screen.getBugScreen());
        }
        public void goToGame() 
        {
            screen.setState(screen.getGameScreen());
        }
        public void goToMenuScreen() 
        { 
            // Already here
        }
        public void goToGameWonScreen()
        {
            // Impossible
        }
        public void goToGameOverScreen()
        {
            // Impossible
        }
        public void exitGame()
        {
            screen.quit = true;
        }
    }
}
