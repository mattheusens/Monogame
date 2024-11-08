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
        private Movement move;
        private Vector2 position;

        public Hero(Texture2D texture, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.heroTexture = texture;
            this.move = new Movement();

            animation = new Animatie(move);
            animation.GetFramesFromTextureProperties(texture.Width/4, texture.Height, 3, 4);

            move.posX = graphics.PreferredBackBufferWidth / 2 - texture.Width / 24;
            move.posY = graphics.PreferredBackBufferHeight / 2 - texture.Height / 8;
            position = new Vector2(move.posX, move.posY);
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
            move.MoveInputs();
            move.MoveBoundaries(graphics, heroTexture);

            position = new Vector2(move.posX, move.posY);
        }
    }
}
