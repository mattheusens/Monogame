using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ExamenProject.Map.Nature
{
    internal class Nature
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle rectangle;

        public Nature(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            rectangle = new((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public Nature(Vector2 position)
        {
            this.position = position;
        }

        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
            rectangle = new((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, rectangle, Color.White);
        }
    }
}
