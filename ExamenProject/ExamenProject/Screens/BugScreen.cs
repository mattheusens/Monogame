using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using ExamenProject.Interfaces;

namespace ExamenProject.Screens
{
    internal class BugScreen : IScreenState
    {
        Screen screen;

        private Texture2D backgroundTexture;

        public Button returnButton;
        private Texture2D returnTexture;
        private Vector2 basePositionReturn;
        private Vector2 offsetReturn;

        private Texture2D background;
        private SpriteFont font;
        private string text;

        public BugScreen(Screen screen)
        {
            this.screen = screen;

            font = MedievalFont.getInstance().font;
            ContentManager Content = ContentLoader.getInstance().contentM;

            backgroundTexture = Content.Load<Texture2D>("Screens/MainBackground");
            background = Content.Load<Texture2D>("Screens/BigScreen");
            returnTexture = Content.Load<Texture2D>("Screens/Return");

            returnButton = new Button(returnTexture, new(1040, 80), 1.5f);
            text = "- When you collide with a solid object" +
                "\n(buildings, trees, water), you get stuck." +
                "\nIf you collided without sprint, just go in" +
                "\nthe direction opposite of the solid object." +
                "\nIf you collided with sprint, do the same" +
                "\nbut with sprint.";
        }

        public void Update(GameTime gameTime)
        {
            returnButton.Update();
            if (returnButton.clicked) goToStartScreen();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1500, 900), Color.White);

            spriteBatch.Draw(background, new Vector2(1500 / 2, 900 / 2), null, Color.White, 0.0f, new Vector2(96, 96), 4.5f, SpriteEffects.None, 1.0f);
            returnButton.Draw(spriteBatch);
            spriteBatch.DrawString(font, text, new(400, 150), Color.White, 0, new(0, 0), 1.5f, SpriteEffects.None, 0);
        }

        public void goToStartScreen() 
        {
            returnButton.clicked = false;
            screen.state = screen.getStartScreen();
        }
        public void goToBugScreen() 
        {
            // Already here
        }
        public void goToGame() 
        {
            // Impossible
        }
        public void goToMenuScreen() 
        {
            // Need to make this
        }
        public void goToEndScreen() 
        {
            // Impossible
        }
        public void exitGame() 
        {
            // Impossible
        }
    }
}
