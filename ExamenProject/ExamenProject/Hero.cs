using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamenProject
{
    internal class Hero:IGameObject
    {
        private Texture2D heroTexture;
        private Animatie animation;

        public Hero(Texture2D texture)
        {
            this.heroTexture = texture;
            animation = new Animatie();
            animation.GetFramesFromTextureProperties(texture.Width/4, texture.Height/4, 3, 1);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);  
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(10, 10), animation.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
