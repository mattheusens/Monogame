using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace ExamenProject.Screens
{
    internal class StartScreen
    {
        private static StartScreen startScreen = new StartScreen();
        private Texture2D backgroundTexture;

        public bool startScreenOn = true;
        public bool bugScreenOn = false;
        public bool quit = false;

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


        private StartScreen()
        {
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

        public static StartScreen getInstance()
        {
            return startScreen;
        }

        public void Update()
        {
            if (startButton.clicked) startScreenOn = false;
            if (bugsButton.clicked)
            {
                bugScreenOn = !bugScreenOn;
                bugsButton.clicked = false;
            }
            if (quitButton.clicked) quit = true;
            startButton.Update();
            bugsButton.Update();
            quitButton.Update();
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
    }
}
