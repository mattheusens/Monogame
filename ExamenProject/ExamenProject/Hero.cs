using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamenProject
{
    internal class Hero:IGameObject
    {
        private Texture2D heroTexture;
        private Animatie animation;
        private Vector2 position;

        private int posX = 10;
        private int posY = 10;

        public Hero(Texture2D texture)
        {
            this.heroTexture = texture;
            animation = new Animatie();
            animation.GetFramesFromTextureProperties(texture.Width/4, texture.Height/4, 3, 1);
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
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                posY--;;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                posY++;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                posX--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                posX++;
            position = new Vector2(posX, posY);
        }
    }
}
