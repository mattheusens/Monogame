using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExamenProject.Characters
{
    internal class Hero : Character
    {
        private Texture2D heart;

        public Hero(Texture2D texture):base(texture)
        {
            ContentManager Content = ContentLoader.getInstance().contentM;
            heart = Content.Load<Texture2D>("Heart");

            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height / 8 * 3, 12, 3);
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;

            move.posX = 120; //graphics.PreferredBackBufferWidth / 2 - texture.Width / 24;
            move.posY = 100; //graphics.PreferredBackBufferHeight / 2 - texture.Height / 16;
            position = new Vector2(move.posX, move.posY);

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

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F)) moveAnimation.Fighting();
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
            rectangleFeet = new Rectangle((int)positionFeet.X, (int)positionFeet.Y, rectangle.Width / 2 - 75, rectangle.Height / 2 - 90);
            rectangleHitbox = new Rectangle((int)positionHitbox.X, (int)positionHitbox.Y, rectangle.Width / 2 - 40, rectangle.Height / 2 - 32);
            rectangleWeaponR = new Rectangle((int)positionWeaponR.X, (int)positionWeaponR.Y, rectangle.Width / 2 - 30, rectangle.Height / 2 + 15);
            rectangleWeaponL = new Rectangle((int)positionWeaponL.X, (int)positionWeaponL.Y, rectangle.Width / 2 - 30, rectangle.Height / 2 + 15);

            base.Draw(spriteBatch);

            for (int i = 0; i < health; i++)
            {
                spriteBatch.Draw(heart, new(30 + 110 * i, 800), new(0, 0, heart.Width, heart.Height), Color.White, 0, new(0, 0), 0.3f, SpriteEffects.None, 0);
            }
        }

        public override void Move()
        {
            base.Move();
            move.MoveInputs();
        }
    }
}
