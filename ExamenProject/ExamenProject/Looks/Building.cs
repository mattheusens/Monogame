using ExamenProject.Loaders;
using ExamenProject.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ExamenProject.Map
{
    internal class Building
    {
        public Texture2D texture;
        public Rectangle rectangle;
        private Texture2D hitboxTexture;
        public Rectangle hitboxRectangle;

        public Building(Rectangle rectangle, string type)
        {
            ContentManager Content = ContentLoader.getInstance().contentM;
            GraphicsDevice graphicsDevice = GraphicsDeviceLoader.getInstance().graphicsDevice;

            this.rectangle = rectangle;

            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });

            if (type == "house")
            {
                texture = Content.Load<Texture2D>($"Background/Buildings/{GameScreen.Color}/House"); // 128x192
                hitboxRectangle = new Rectangle(rectangle.X + 10, rectangle.Y + 24, rectangle.Width - 20, rectangle.Height - 50);
            }
            else if (type == "tower")
            {
                texture = Content.Load<Texture2D>($"Background/Buildings/{GameScreen.Color}/Tower"); // 128x256
                hitboxRectangle = new Rectangle(rectangle.X + 7, rectangle.Y + 52, rectangle.Width - 14, rectangle.Height - 84);
            }
            else if (type == "castle")
            {
                texture = Content.Load<Texture2D>($"Background/Buildings/{GameScreen.Color}/Castle"); // 320x256
                hitboxRectangle = new Rectangle(rectangle.X + 16, rectangle.Y + 45, rectangle.Width - 32, rectangle.Height - 60);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.Draw(hitboxTexture, hitboxRectangle, Color.Transparent);
        }
    }
}
