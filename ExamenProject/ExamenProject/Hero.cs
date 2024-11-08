using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamenProject
{
    internal class Hero:IGameObject
    {
        private GraphicsDeviceManager graphics;
        private Texture2D heroTexture;
        private Animatie animation;
        private Vector2 position;

        private int posX = 350;
        private int posY = 400;
        private int speed = 1;

        public Hero(Texture2D texture, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.heroTexture = texture;

            animation = new Animatie();
            animation.GetFramesFromTextureProperties(texture.Width/4, texture.Height/4, 3, 1);

            posX = graphics.PreferredBackBufferWidth / 2 - texture.Width / 12;
            posY = graphics.PreferredBackBufferHeight / 2 - texture.Height / 4;
            position = new Vector2(posX, posY);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                speed = 2;
            else
                speed = 1;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                posY -= speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                posY += speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                posX -= speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                posX += speed;

            Boundaries();

            position = new Vector2(posX, posY);
        }

        private void Boundaries()
        {
            if (graphics.PreferredBackBufferWidth - heroTexture.Width / 12 < posX)
                posX = graphics.PreferredBackBufferWidth - heroTexture.Width / 12;
            if (posX < 10)
                posX = 10;
            if (graphics.PreferredBackBufferHeight - heroTexture.Height / 4 < posY)
                posY = graphics.PreferredBackBufferHeight - heroTexture.Height / 4;
            if (posY < 10)
                posY = 10;
        }
    }
}
