using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using ExamenProject.Interfaces;

namespace ExamenProject.Screens
{
    internal class StartScreen : IScreenState
    {
        Screen screen;

        private Texture2D backgroundTexture;

        private SpriteFont font;
        private Texture2D buttonTexture;

        private Button startButton;
        private Vector2 basePositionStart;
        private Vector2 offsetTextS;

        private Button bugsButton;
        private Vector2 basePositionBugs;
        private Vector2 offsetTextB;

        private Button quitButton;
        private Vector2 basePositionQuit;
        private Vector2 offsetTextQ;

        public bool startScreenOn = true;
        public bool bugScreenOn = false;
        public bool quit = false;

        public StartScreen(Screen screen)
        {
            this.screen = screen;

            font = MedievalFont.getInstance().font;
            ContentManager Content = ContentLoader.getInstance().contentM;

            backgroundTexture = Content.Load<Texture2D>("Screens/MainBackground");
            buttonTexture = Content.Load<Texture2D>("Screens/Button");

            float buttonSize = 1.5f;
            basePositionStart = new(750 - buttonTexture.Width * buttonSize / 2, 450 - buttonTexture.Height * buttonSize / 2);
            basePositionBugs = new(750 - buttonTexture.Width * buttonSize / 2, 450 - buttonTexture.Height * buttonSize / 2 + 150);
            basePositionQuit = new(750 - buttonTexture.Width * buttonSize / 2, 450 - buttonTexture.Height * buttonSize / 2 + 300);

            offsetTextS = new(85, 13);
            offsetTextB = new(72, 13);
            offsetTextQ = new(85, 13);

            startButton = new Button(buttonTexture, basePositionStart, buttonSize);
            bugsButton = new Button(buttonTexture, basePositionBugs, buttonSize);
            quitButton = new Button(buttonTexture, basePositionQuit, buttonSize);
        }

        public void Update(GameTime gameTime)
        {
            startButton.Update();
            bugsButton.Update();
            quitButton.Update();

            if (startButton.clicked) goToGame();
            if (bugsButton.clicked) goToBugScreen();
            if (quitButton.clicked) exitGame();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1500, 900), Color.White);
            
            startButton.Draw(spriteBatch);
            bugsButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Start", basePositionStart + offsetTextS, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Bugs", basePositionBugs + offsetTextB, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, "Quit", basePositionQuit + offsetTextQ, Color.White, 0, new(0, 0), 2, SpriteEffects.None, 0);
        }

        public void goToStartScreen()
        { 
            // Already here
        }
        public void goToBugScreen() 
        {
            bugsButton.clicked = false;
            screen.state = screen.getBugScreen();
        }
        public void goToGame() 
        {
            startButton.clicked = false;
            screen.state = screen.getGameScreen();
        }
        public void goToMenuScreen() 
        {
            // Impossible
        }
        public void goToEndScreen() 
        { 
            // Impossible
        }
        public void exitGame() 
        {
            quit = true;
        }
    }
}
