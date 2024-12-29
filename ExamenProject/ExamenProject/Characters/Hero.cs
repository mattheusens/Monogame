using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExamenProject.Characters
{
    internal class Hero : IGameObject
    {
        Texture2D characterTexture;
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

        private Texture2D heart;
        public int health = 3;

        public Hero(Texture2D texture)
        {
            GraphicsDevice graphicsDevice = GraphicsDeviceLoader.getInstance().graphicsDevice;
            characterTexture = texture;
            move = new Movement();

            ContentManager Content = ContentLoader.getInstance().contentM;
            heart = Content.Load<Texture2D>("Heart");

            moveAnimation = new Animatie(move, 6);
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height / 8 * 3, 12, 3);
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;

            move.posX = 120; //graphics.PreferredBackBufferWidth / 2 - texture.Width / 24;
            move.posY = 100; //graphics.PreferredBackBufferHeight / 2 - texture.Height / 16;
            position = new Vector2(move.posX, move.posY);

            feetTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            weaponTexture = new Texture2D(graphicsDevice, 1, 1);

            feetTexture.SetData(new[] { Color.White });
            hitboxTexture.SetData(new[] { Color.White });
            weaponTexture.SetData(new[] { Color.White });

            offsetFeet.X = rectangle.Width / 4 + 37;
            offsetFeet.Y = rectangle.Height / 4 + 76;
            offsetHitbox.X = rectangle.Width / 4 + 20;
            offsetHitbox.Y = rectangle.Height / 4 + 20;
            offsetWeaponR.X = rectangle.Width / 4 + 70;
            offsetWeaponR.Y = rectangle.Height / 4 - 20;
            offsetWeaponL.X = rectangle.Width / 4 - 40;
            offsetWeaponL.Y = rectangle.Height / 4 - 20;

            positionFeet = new Vector2(move.posX + offsetFeet.X, move.posY + offsetFeet.Y);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
            positionWeaponR = new Vector2(move.posX + offsetWeaponR.X, move.posY + offsetWeaponR.Y);
            positionWeaponL = new Vector2(move.posX + offsetWeaponL.X, move.posY + offsetWeaponL.Y);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F)) moveAnimation.Fighting();
            moveAnimation.Update(gameTime);
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
            rectangleFeet = new Rectangle((int)positionFeet.X, (int)positionFeet.Y, rectangle.Width / 2 - 75, rectangle.Height / 2 - 90);
            rectangleHitbox = new Rectangle((int)positionHitbox.X, (int)positionHitbox.Y, rectangle.Width / 2 - 40, rectangle.Height / 2 - 32);
            rectangleWeaponR = new Rectangle((int)positionWeaponR.X, (int)positionWeaponR.Y, rectangle.Width / 2 - 30, rectangle.Height / 2 + 15);
            rectangleWeaponL = new Rectangle((int)positionWeaponL.X, (int)positionWeaponL.Y, rectangle.Width / 2 - 30, rectangle.Height / 2 + 15);

            spriteBatch.Draw(characterTexture, position, rectangle, Color.White);
            spriteBatch.Draw(feetTexture, positionFeet, rectangleFeet, Color.Transparent);
            spriteBatch.Draw(hitboxTexture, positionHitbox, rectangleHitbox, Color.Transparent);
            spriteBatch.Draw(weaponTexture, positionWeaponR, rectangleWeaponR, Color.Transparent);
            spriteBatch.Draw(weaponTexture, positionWeaponL, rectangleWeaponL, Color.Transparent);

            for (int i = 0; i < health; i++)
            {
                spriteBatch.Draw(heart, new(30 + 110 * i, 800), new(0, 0, heart.Width, heart.Height), Color.White, 0, new(0, 0), 0.3f, SpriteEffects.None, 0);
            }
        }

        public void Move()
        {
            posXBefore = move.posX;
            posYBefore = move.posY;
            move.MoveInputs();

            position = new Vector2(move.posX, move.posY);
            positionFeet = new Vector2(move.posX + offsetFeet.X, move.posY + offsetFeet.Y);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
            positionWeaponR = new Vector2(move.posX + offsetWeaponR.X, move.posY + offsetWeaponR.Y);
            positionWeaponL = new Vector2(move.posX + offsetWeaponL.X, move.posY + offsetWeaponL.Y);
        }
    }
}
