using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExamenProject
{
    internal class Character
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

        public Character(Texture2D texture, GraphicsDevice graphicsDevice)
        {
            this.enemyTexture = texture;
            this.move = new Movement();

            moveAnimation = new Animatie(move);

            feetTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            weaponTexture = new Texture2D(graphicsDevice, 1, 1);

            feetTexture.SetData(new[] { Color.White });
            hitboxTexture.SetData(new[] { Color.White });
            weaponTexture.SetData(new[] { Color.White });
        }
        public void Update(GameTime gameTime)
        {
            moveAnimation.Update(gameTime);
        }
    }
}
