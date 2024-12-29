using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ExamenProject.Map
{
    internal class Building
    {
        public Texture2D texture;
        public Rectangle rectangle;
        private Texture2D hitboxTexture;
        public Rectangle hitboxRectangle;
        public Color Color;

        public Building(Rectangle rectangle, Texture2D texture, string type, GraphicsDevice graphicsDevice)
        {
            this.rectangle = rectangle;
            this.texture = texture;
            Color = Color.White;

            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });

            if (type == "house")
            {
                hitboxRectangle = new Rectangle(rectangle.X + 10, rectangle.Y + 24, rectangle.Width - 20, rectangle.Height - 50);
            }
            else if (type == "tower")
            {
                hitboxRectangle = new Rectangle(rectangle.X + 7, rectangle.Y + 52, rectangle.Width - 14, rectangle.Height - 84);
            }
            else if (type == "castle")
            {
                hitboxRectangle = new Rectangle(rectangle.X + 16, rectangle.Y + 45, rectangle.Width - 32, rectangle.Height - 60);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color);
            spriteBatch.Draw(hitboxTexture, hitboxRectangle, Color.Transparent);
        }
    }
}
