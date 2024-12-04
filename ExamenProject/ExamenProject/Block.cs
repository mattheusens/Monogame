using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject
{
    internal class Block
    {
        public Rectangle BoundingBox { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public string Type { get; set; }

        public Block(Vector2 position, Rectangle rectangle, Texture2D texture, String type)
        {
            Position = position;
            BoundingBox = rectangle;
            Texture = texture;
            Type = type;
            Color = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, BoundingBox, Color);
        }
    }
}
