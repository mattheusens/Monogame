using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExamenProject
{
    internal class Enemy : IGameObject
    {
        Texture2D enemyTexture;
        Texture2D hitboxTexture;
        Texture2D feetTexture;
        Texture2D weaponTexture;

        public Animatie moveAnimation;
        public Movement movePlayer;
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

        public Enemy(Texture2D texture, GraphicsDevice graphicsDevice, Movement movePlayer)
        {
            this.enemyTexture = texture;
            this.movePlayer = movePlayer;
            this.move = new Movement();

            moveAnimation = new Animatie(move);
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height / 5 * 3, 12, 3);
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;

            move.posX = 400; //graphics.PreferredBackBufferWidth / 2 - texture.Width / 24;
            move.posY = 400; //graphics.PreferredBackBufferHeight / 2 - texture.Height / 16;
            position = new Vector2(move.posX, move.posY);

            feetTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            weaponTexture = new Texture2D(graphicsDevice, 1, 1);
            
            feetTexture.SetData(new[] { Color.White });
            hitboxTexture.SetData(new[] { Color.White });
            weaponTexture.SetData(new[] { Color.White });

            offsetFeet.X = rectangle.Width / 4 + 37;
            offsetFeet.Y = rectangle.Height / 4 + 76;
            offsetHitbox.X = rectangle.Width / 4 + 30;
            offsetHitbox.Y = rectangle.Height / 4 + 22;
            
            offsetWeaponR.X = rectangle.Width / 4 + 84;
            offsetWeaponR.Y = rectangle.Height / 4 + 20;
            offsetWeaponL.X = rectangle.Width / 4 - 30;
            offsetWeaponL.Y = rectangle.Height / 4 + 20;

            positionFeet = new Vector2(move.posX + offsetFeet.X, move.posY + offsetFeet.Y);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
            positionWeaponR = new Vector2(move.posX + offsetWeaponR.X, move.posY + offsetWeaponR.Y);
            positionWeaponL = new Vector2(move.posX + offsetWeaponL.X, move.posY + offsetWeaponL.Y);
        }

        public bool counting = false;
        int counter = 0;

        public void Update(GameTime gameTime)
        {
            Counter();
            moveAnimation.Update(gameTime);
            Move(movePlayer);
        }

        void Counter()
        {
            if (counting) counter++;

            if (counter >= 100)
            {
                moveAnimation.Fighting();
                counter = 0;
                counting = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
            rectangleFeet = new Rectangle((int)positionFeet.X, (int)positionFeet.Y, rectangle.Width / 2 - 75, rectangle.Height / 2 - 90);
            rectangleHitbox = new Rectangle((int)positionHitbox.X, (int)positionHitbox.Y, rectangle.Width / 2 - 60, rectangle.Height / 2 - 40);
            rectangleWeaponR = new Rectangle((int)positionWeaponR.X, (int)positionWeaponR.Y, rectangle.Width / 2 - 50, rectangle.Height / 2 - 29);
            rectangleWeaponL = new Rectangle((int)positionWeaponL.X, (int)positionWeaponL.Y, rectangle.Width / 2 - 50, rectangle.Height / 2 - 29);

            spriteBatch.Draw(enemyTexture, position, rectangle, Color.White);
            spriteBatch.Draw(feetTexture, positionFeet, rectangleFeet, Color.Transparent);
            spriteBatch.Draw(hitboxTexture, positionHitbox, rectangleHitbox, Color.Transparent);
            spriteBatch.Draw(weaponTexture, positionWeaponR, rectangleWeaponR, Color.Transparent);
            spriteBatch.Draw(weaponTexture, positionWeaponL, rectangleWeaponL, Color.Transparent);
        }
        public void Move(Movement movePlayer)
        {
            posXBefore = move.posX;
            posYBefore = move.posY;
            move.FollowPlayer(movePlayer);

            position = new Vector2(move.posX, move.posY);
            positionFeet = new Vector2(move.posX + offsetFeet.X, move.posY + offsetFeet.Y);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
            positionWeaponR = new Vector2(move.posX + offsetWeaponR.X, move.posY + offsetWeaponR.Y);
            positionWeaponL = new Vector2(move.posX + offsetWeaponL.X, move.posY + offsetWeaponL.Y);
        }
    }
}
