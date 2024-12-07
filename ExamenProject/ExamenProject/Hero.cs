using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ExamenProject
{
    internal class Hero:IGameObject
    {
        GraphicsDeviceManager graphics;

        Texture2D heroTexture;
        Texture2D hitboxTexture;
        Texture2D feetTexture;

        Animatie moveAnimation;
        Animatie fightAnimation;
        public Movement moveBefore;
        public Movement move;

        public int posXBefore;
        public int posYBefore;

        Vector2 position;
        Vector2 positionHitbox;
        Vector2 offsetHitbox;
        Vector2 positionFeet;
        public Vector2 offsetFeet;

        public Rectangle rectangle;
        Rectangle rectangleHitbox;
        public Rectangle rectangleFeet;

        public Hero(Texture2D texture, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice)
        {
            this.graphics = graphics;
            this.heroTexture = texture;
            this.move = new Movement();

            moveAnimation = new Animatie(move);
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height / 8 * 3, 12, 3);

            move.posX = 50; //graphics.PreferredBackBufferWidth / 2 - texture.Width / 24;
            move.posY = 50; //graphics.PreferredBackBufferHeight / 2 - texture.Height / 16;
            position = new Vector2(move.posX, move.posY);

            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });
            positionHitbox = new Vector2(move.posX, move.posY);

            feetTexture = new Texture2D(graphicsDevice, 1, 1);
            feetTexture.SetData(new[] { Color.White });
            positionFeet = new Vector2(move.posX, move.posY);
        }

        public void Update(GameTime gameTime)
        {
            moveAnimation.Fighting();
            moveAnimation.Update(gameTime);
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
            rectangleHitbox = new Rectangle((int)positionHitbox.X, (int)positionHitbox.Y, rectangle.Width/2 - 40, rectangle.Height/2 - 32);
            rectangleFeet = new Rectangle((int)positionFeet.X, (int)positionFeet.Y, rectangle.Width / 2 - 75, rectangle.Height / 2 - 90);

            spriteBatch.Draw(feetTexture, positionFeet, rectangleFeet, Color.Red);
            spriteBatch.Draw(heroTexture, position, rectangle, Color.White);
            spriteBatch.Draw(hitboxTexture, positionHitbox, rectangleHitbox, Color.Transparent);
        }

        public void Move()
        {
            posXBefore = move.posX;
            posYBefore = move.posY;
            move.MoveInputs();
            move.MoveBoundaries(graphics, heroTexture);

            offsetHitbox.X = rectangle.Width / 4 + 20;
            offsetHitbox.Y = rectangle.Height / 4 + 20;
            offsetFeet.X = rectangle.Width / 4 + 37;
            offsetFeet.Y = rectangle.Height / 4 + 76;

            position = new Vector2(move.posX, move.posY);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
            positionFeet = new Vector2(move.posX + offsetFeet.X, move.posY + offsetFeet.Y);
        }
    }
}
