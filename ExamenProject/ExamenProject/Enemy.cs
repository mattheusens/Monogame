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
        private Texture2D hitboxTexture;

        private Animatie moveAnimation;
        private Movement move;
        Movement movePlayer;

        private Vector2 position;
        public Vector2 positionHitbox;
        private Vector2 offsetHitbox;
        private Rectangle rectangle;
        public Rectangle rectangleHitbox;

        public int health = 2;

        public Enemy(Texture2D texture, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice, Movement movePlayer)
        {
            this.enemyTexture = texture;
            this.graphics = graphics;
            this.movePlayer = movePlayer;
            this.move = new Movement();

            moveAnimation = new Animatie(move);
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height / 5 * 2, 12, 2);
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;

            offsetHitbox.X = rectangle.Width / 4 + 30;
            offsetHitbox.Y = rectangle.Height / 4 + 22;

            move.posX = 400;
            move.posY = 400;
            position = new Vector2(move.posX, move.posY);

            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });
            positionHitbox = new Vector2(move.posX, move.posY);
        }

        public void Update(GameTime gameTime)
        {
            moveAnimation.Update(gameTime);
            Move(movePlayer);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
            rectangleHitbox = new Rectangle((int)positionHitbox.X, (int)positionHitbox.Y, rectangle.Width / 2 - 60, rectangle.Height / 2 - 40);

            spriteBatch.Draw(hitboxTexture, positionHitbox, rectangleHitbox, Color.Red);
            spriteBatch.Draw(enemyTexture, position, rectangle, Color.White);
        }
        public void Move(Movement movePlayer)
        {
            move.FollowPlayer(movePlayer);
            position = new Vector2(move.posX, move.posY);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
        }
    }
}
