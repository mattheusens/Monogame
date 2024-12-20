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
        Texture2D weaponTexture;

        public Animatie moveAnimation;
        public Movement moveBefore;
        public Movement move;

        public int posXBefore;
        public int posYBefore;

        Vector2 position;
        Vector2 positionHitbox;
        Vector2 offsetHitbox;
        Vector2 positionFeet;
        Vector2 offsetFeet;
        Vector2 positionWeaponR;
        Vector2 offsetWeaponR;
        Vector2 positionWeaponL;
        Vector2 offsetWeaponL;

        public Rectangle rectangle;
        public Rectangle rectangleHitbox;
        public Rectangle rectangleFeet;
        public Rectangle rectangleWeaponR;
        public Rectangle rectangleWeaponL;

        public int health = 3;

        public Hero(Texture2D texture, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice)
        {
            this.graphics = graphics;
            this.heroTexture = texture;
            this.move = new Movement();

            moveAnimation = new Animatie(move);
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height / 8 * 3, 12, 3);
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;

            offsetHitbox.X = rectangle.Width / 4 + 20;
            offsetHitbox.Y = rectangle.Height / 4 + 20;
            offsetFeet.X = rectangle.Width / 4 + 37;
            offsetFeet.Y = rectangle.Height / 4 + 76;
            offsetWeaponR.X = rectangle.Width / 4 + 70;
            offsetWeaponR.Y = rectangle.Height / 4 - 20;
            offsetWeaponL.X = rectangle.Width / 4 - 40;
            offsetWeaponL.Y = rectangle.Height / 4 - 20;

            move.posX = 50; //graphics.PreferredBackBufferWidth / 2 - texture.Width / 24;
            move.posY = 50; //graphics.PreferredBackBufferHeight / 2 - texture.Height / 16;
            position = new Vector2(move.posX, move.posY);

            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });
            positionHitbox = new Vector2(move.posX, move.posY);

            feetTexture = new Texture2D(graphicsDevice, 1, 1);
            feetTexture.SetData(new[] { Color.White });
            positionFeet = new Vector2(move.posX, move.posY);

            weaponTexture = new Texture2D(graphicsDevice, 1, 1);
            weaponTexture.SetData(new[] { Color.White });
            positionWeaponR = new Vector2(move.posX, move.posY);
            positionWeaponL = new Vector2(move.posX, move.posY);
        }

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.F)) moveAnimation.Fighting();
            moveAnimation.Update(gameTime);
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
            rectangleWeaponL = new Rectangle((int)positionWeaponL.X, (int)positionWeaponL.Y, rectangle.Width / 2 - 30, rectangle.Height / 2 + 15);
            rectangleWeaponR = new Rectangle((int)positionWeaponR.X, (int)positionWeaponR.Y, rectangle.Width / 2 - 30, rectangle.Height / 2 + 15);
            rectangleFeet = new Rectangle((int)positionFeet.X, (int)positionFeet.Y, rectangle.Width / 2 - 75, rectangle.Height / 2 - 90);
            rectangleHitbox = new Rectangle((int)positionHitbox.X, (int)positionHitbox.Y, rectangle.Width/2 - 40, rectangle.Height/2 - 32);

            spriteBatch.Draw(heroTexture, position, rectangle, Color.White);
            spriteBatch.Draw(weaponTexture, positionWeaponL, rectangleWeaponL, Color.Transparent);
            spriteBatch.Draw(weaponTexture, positionWeaponR, rectangleWeaponR, Color.Transparent);
            spriteBatch.Draw(feetTexture, positionFeet, rectangleFeet, Color.Transparent);
            spriteBatch.Draw(hitboxTexture, positionHitbox, rectangleHitbox, Color.Transparent);
        }

        public void Move()
        {
            posXBefore = move.posX;
            posYBefore = move.posY;
            move.MoveInputs();
            move.MoveBoundaries(graphics, heroTexture);

            position = new Vector2(move.posX, move.posY);
            positionWeaponL = new Vector2(move.posX + offsetWeaponL.X, move.posY + offsetWeaponL.Y);
            positionWeaponR = new Vector2(move.posX + offsetWeaponR.X, move.posY + offsetWeaponR.Y);
            positionFeet = new Vector2(move.posX + offsetFeet.X, move.posY + offsetFeet.Y);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
        }
    }
}
