using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ExamenProject
{
    internal class Button
    {
        private Texture2D texture;

        private Rectangle rectangle;
        private Vector2 position;
        private Color shade;
        private Rectangle rectangleShade;
        private MouseState lastState;

        private float buttonSize;
        public bool clicked;

        public Button(Texture2D texture, Vector2 position, float buttonSize)
        {
            this.texture = texture;
            this.position = position;
            this.buttonSize = buttonSize;

            shade = Color.White;
            clicked = false;

            rectangle = new(0, 0, (int)(texture.Width * buttonSize), (int)(texture.Height * buttonSize));
            rectangleShade = new((int)position.X, (int)position.Y, (int)(texture.Width * buttonSize), (int)(texture.Height * buttonSize));
        }

        public void Update()
        {
            MouseState ms = Mouse.GetState();
            Rectangle cursor = new(ms.Position.X, ms.Position.Y, 1, 1);

            if (cursor.Intersects(rectangleShade))
            {
                shade = Color.DarkGray;
                if (ms.LeftButton == ButtonState.Pressed && lastState.LeftButton == ButtonState.Released) clicked = true;
            }
            else shade = Color.White;
            lastState = ms;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangle, shade, 0, new(0, 0), buttonSize, SpriteEffects.None, 0);
        }
    }
}
