using ExamenProject.Animation;
using ExamenProject.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace ExamenProject.Nature
{
    internal class Tree : Nature
    {
        private Texture2D hitboxTexture;
        private Vector2 offsetHitbox;
        public Rectangle hitboxRectangle;

        public Animatie moveAnimation;
        public Movement move;

        public Tree(Vector2 position, GraphicsDevice graphicsDevice) : base(position)
        {
            ContentManager Content = ContentLoader.getInstance().contentM;
            setTexture(Content.Load<Texture2D>("Background/Tree"));

            this.move = new Movement();
            moveAnimation = new Animatie(move, 3);
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height / 3 * 2, 4, 2); // 192x192
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;

            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });
            offsetHitbox = new(43, 94);
            hitboxRectangle = new((int)(position.X + offsetHitbox.X), (int)(position.Y + offsetHitbox.Y), 111, 78);
        }

        public void Update(GameTime gameTime)
        {
            moveAnimation.Update(gameTime);
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
            sb.Draw(hitboxTexture, position + offsetHitbox, hitboxRectangle, Color.Transparent);
        }
    }
}
