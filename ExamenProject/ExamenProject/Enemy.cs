using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ExamenProject.Animation;

namespace ExamenProject
{
    internal class Enemy:IGameObject
    {
        private GraphicsDeviceManager graphics;

        private Texture2D enemyTexture;
        //private Texture2D hitboxTexture;

        private Animatie moveAnimation;
        private Movement move;
        Movement movePlayer;

        private Vector2 position;
        //private Vector2 positionHitbox;
        private Rectangle rectangle;
        //public Rectangle rectangleHitbox;

        public Enemy(Texture2D texture, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, Movement movePlayer)
        {
            this.enemyTexture = texture;
            this.graphics = graphics;
            this.movePlayer = movePlayer;
            this.move = new Movement();

            moveAnimation = new Animatie(move);
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height / 5 * 2, 12, 2);
            move.posX = 400;
            move.posY = 400;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
            spriteBatch.Draw(enemyTexture, position, rectangle, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            moveAnimation.Update(gameTime);
            Move(movePlayer);
        }
        public void Move(Movement movePlayer)
        {
            move.FollowPlayer(movePlayer);
            position = new Vector2(move.posX, move.posY);
        }
    }
}
