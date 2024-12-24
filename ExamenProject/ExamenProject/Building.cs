using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ExamenProject
{
    internal class Building
    {
        public Rectangle DestinationRectangle { get; set; }
        public Rectangle HitboxRectangle { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public string Type { get; set; }
        private Texture2D hitTexture;

        public Building(Rectangle rectangle, Texture2D texture, String type, GraphicsDevice graphicsDevice)
        {
            DestinationRectangle = rectangle;
            Texture = texture;
            Type = type;
            Color = Color.White;


            hitTexture = new Texture2D(graphicsDevice, 1, 1);
            hitTexture.SetData(new[] { Color.White });

            if (Type == "house")
            {
                HitboxRectangle = new Rectangle(rectangle.X + 10, rectangle.Y + 24, rectangle.Width - 20, rectangle.Height - 50);
            }
            else if(Type == "tower")
            {
                HitboxRectangle = new Rectangle(rectangle.X + 7, rectangle.Y + 52, rectangle.Width - 14, rectangle.Height - 84);
            }
            else if(Type == "castle")
            {
                HitboxRectangle = new Rectangle(rectangle.X + 16, rectangle.Y + 45, rectangle.Width - 32, rectangle.Height - 60);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hitTexture, HitboxRectangle, Color.Transparent);
            spriteBatch.Draw(Texture, DestinationRectangle, Color);
        }
    }
}
