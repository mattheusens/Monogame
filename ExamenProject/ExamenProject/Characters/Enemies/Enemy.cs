using ExamenProject.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace ExamenProject.Characters.Enemies
{
    abstract class Enemy : Character
    {
        protected int delay;
        protected int delayCounter = 0;

        public Enemy(Texture2D texture, Vector2 spawnPosition, int delay) : base(texture, spawnPosition)
        {
            this.delay = delay;
            
            SpriteSplitter.GetFramesFromTexture(moveAnimation.frames, texture.Width, texture.Height / 5 * 3, 12, 3);
            moveAnimation.setFirst();
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;

            offsetFeet.X = rectangle.Width / 4 + 37;
            offsetFeet.Y = rectangle.Height / 4 + 76;
            offsetHitbox.X = rectangle.Width / 4 + 30;
            offsetHitbox.Y = rectangle.Height / 4 + 22;
            offsetWeaponR.X = rectangle.Width / 4 + 84;
            offsetWeaponR.Y = rectangle.Height / 4 + 20;
            offsetWeaponL.X = rectangle.Width / 4 - 30;
            offsetWeaponL.Y = rectangle.Height / 4 + 20;

            position = new Vector2(move.posX, move.posY);

            positionFeet = new Vector2(move.posX + offsetFeet.X, move.posY + offsetFeet.Y);
            positionHitbox = new Vector2(move.posX + offsetHitbox.X, move.posY + offsetHitbox.Y);
            positionWeaponR = new Vector2(move.posX + offsetWeaponR.X, move.posY + offsetWeaponR.Y);
            positionWeaponL = new Vector2(move.posX + offsetWeaponL.X, move.posY + offsetWeaponL.Y);
        }

        public override void Update(GameTime gameTime)
        {
            if (delayCounter >= delay) base.Update(gameTime);
            else delayCounter++;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (delayCounter >= delay) {
                rectangle = moveAnimation.CurrentFrame.SourceRectangle;
                rectangleFeet = new Rectangle((int)positionFeet.X, (int)positionFeet.Y, rectangle.Width / 2 - 75, rectangle.Height / 2 - 90);
                rectangleHitbox = new Rectangle((int)positionHitbox.X, (int)positionHitbox.Y, rectangle.Width / 2 - 60, rectangle.Height / 2 - 40);
                rectangleWeaponR = new Rectangle((int)positionWeaponR.X, (int)positionWeaponR.Y, rectangle.Width / 2 - 50, rectangle.Height / 2 - 29);
                rectangleWeaponL = new Rectangle((int)positionWeaponL.X, (int)positionWeaponL.Y, rectangle.Width / 2 - 50, rectangle.Height / 2 - 29);

                base.Draw(spriteBatch);
            }
        }
        public override void Move()
        {
            base.Move();
        }
    }
}
