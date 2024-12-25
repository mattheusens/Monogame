using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExamenProject
{
    internal class Button
    {
        private Texture2D texture;

        private SpriteFont font;

        private Rectangle rectangle;
        private Vector2 position;
        private Color shade;
        private MouseState lastState;

        public bool clicked;

        public Button(Texture2D texture, Vector2 position, SpriteFont font)
        {
            this.texture = texture;
            this.position = position;
            this.font = font;

            shade = Color.White;
            clicked = false;

            rectangle = new((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Update()
        {
            MouseState ms = Mouse.GetState();
            Rectangle cursor = new(ms.Position.X, ms.Position.Y, 1, 1);

            if (cursor.Intersects(rectangle))
            {
                shade = Color.DarkGray;
                if (ms.LeftButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released) clicked = true;
            }
            else shade = Color.White;
            
            lastState = ms;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, shade);
        }
    }
}
