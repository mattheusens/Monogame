using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ExamenProject.Map
{
    internal class Block
    {
        public Rectangle BoundingBox { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public string Type { get; set; }

        public Block(Vector2 position, Rectangle rectangle, Texture2D texture, string type)
        {
            Position = position;
            BoundingBox = rectangle;
            Texture = texture;
            Type = type;
            Color = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Type == "Grass") spriteBatch.Draw(Texture, Position, BoundingBox, Color, 0.0f, new Vector2(0, 0), 1.74f, SpriteEffects.None, 0f);
            else if (Type == "Water") spriteBatch.Draw(Texture, Position, BoundingBox, Color);
        }
    }
}
