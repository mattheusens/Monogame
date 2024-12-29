using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ExamenProject.Characters
{
    internal abstract class Character : IGameObject
    {
        protected Texture2D characterTexture;
        protected Texture2D hitboxTexture;
        protected Texture2D feetTexture;
        protected Texture2D weaponTexture;

        public Animatie moveAnimation;
        public Movement moveBefore;
        public Movement move;

        public int posXBefore;
        public int posYBefore;

        protected Vector2 position;
        protected Vector2 positionHitbox;
        protected Vector2 offsetHitbox;
        protected Vector2 positionFeet;
        protected Vector2 offsetFeet;
        protected Vector2 positionWeaponR;
        protected Vector2 offsetWeaponR;
        protected Vector2 positionWeaponL;
        protected Vector2 offsetWeaponL;

        public Rectangle rectangle;
        public Rectangle rectangleHitbox;
        public Rectangle rectangleFeet;
        public Rectangle rectangleWeaponR;
        public Rectangle rectangleWeaponL;

        public int health = 3;

        public Character(Texture2D texture)
        {
            GraphicsDevice graphicsDevice = GraphicsDeviceLoader.getInstance().graphicsDevice;

            characterTexture = texture;
            move = new Movement();

            moveAnimation = new Animatie(move, 6);

            feetTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            weaponTexture = new Texture2D(graphicsDevice, 1, 1);

            feetTexture.SetData(new[] { Color.White });
            hitboxTexture.SetData(new[] { Color.White });
            weaponTexture.SetData(new[] { Color.White });
        }
        public virtual void Update(GameTime gameTime)
        {
            moveAnimation.Update(gameTime);
            Move();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(characterTexture, position, rectangle, Color.White);
            spriteBatch.Draw(feetTexture, positionFeet, rectangleFeet, Color.Red);
            spriteBatch.Draw(hitboxTexture, positionHitbox, rectangleHitbox, Color.Transparent);
            spriteBatch.Draw(weaponTexture, positionWeaponR, rectangleWeaponR, Color.Transparent);
            spriteBatch.Draw(weaponTexture, positionWeaponL, rectangleWeaponL, Color.Transparent);
        }

        public virtual void Move()
        {
            position = new Vector2(move.posX, move.posY);
            positionFeet = new Vector2(move.posX + offsetFeet.X, move.posY + offsetFeet.Y);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
            positionWeaponR = new Vector2(move.posX + offsetWeaponR.X, move.posY + offsetWeaponR.Y);
            positionWeaponL = new Vector2(move.posX + offsetWeaponL.X, move.posY + offsetWeaponL.Y);

            posXBefore = move.posX;
            posYBefore = move.posY;
        }
    }
}
