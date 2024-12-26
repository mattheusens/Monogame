using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ExamenProject.Screens
{
    internal class BugScreen
    {
        private static BugScreen bugScreen = new BugScreen();

        public Button returnButton;
        private Texture2D returnTexture;
        private Vector2 basePositionReturn;
        private Vector2 offsetReturn;

        private Texture2D background;
        private SpriteFont font;
        private string text;

        private BugScreen()
        {
            font = MedievalFont.getInstance().font;
            ContentManager Content = ContentLoader.getInstance().contentM;

            background = Content.Load<Texture2D>("Screens/BigScreen");
            returnTexture = Content.Load<Texture2D>("Screens/Return");

            returnButton = new Button(returnTexture, new(1040, 80), 1.5f);
            text = "- Collisions\n- Others";
        }

        public static BugScreen getInstance()
        {
            return bugScreen;
        }

        public void Update()
        {
            returnButton.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(1500 / 2, 900 / 2), null, Color.White, 0.0f, new Vector2(96, 96), 4.5f, SpriteEffects.None, 1.0f);
            returnButton.Draw(spriteBatch);
        }
    }
}
