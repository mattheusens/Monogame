using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics.Metrics;

namespace ExamenProject.Characters.Enemies
{
    internal class RandomEnemy : Enemy
    {
        public bool fighting = false;

        public bool counting = false;
        public bool counterReset = false;
        protected int counter = 0;

        public RandomEnemy(Texture2D texture, Vector2 spawnPosition, int delay, bool fighting) : base(texture, spawnPosition, delay)
        {
            this.fighting = fighting;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(fighting) Counter();
        }

        void Counter()
        {
            if (counting) counter++;

            if (counter >= 100)
            {
                moveAnimation.Fighting();
                counter = 0;
                counterReset = true;
                counting = false;
            }
        }

        public override void Move()
        {
            posXBefore = move.posX;
            posYBefore = move.posY;
            move.Random();
            base.Move();
        }
    }
}
