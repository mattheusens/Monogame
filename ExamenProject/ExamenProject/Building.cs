using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ExamenProject
{
    internal class Building
    {
        public Rectangle DestinationRectangle { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public string Type { get; set; }

        public Building(Rectangle rectangle, Texture2D texture, String type)
        {
            DestinationRectangle = rectangle;
            Texture = texture;
            Type = type;
            Color = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, DestinationRectangle, Color);
        }
    }
}
