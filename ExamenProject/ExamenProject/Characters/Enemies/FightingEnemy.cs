using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExamenProject.Characters.Enemies
{
    internal class FightingEnemy : Enemy
    {
        Movement movePlayer;

        public bool counting = false;
        protected int counter = 0;

        public FightingEnemy(Texture2D texture, Vector2 spawnPosition, int delay, Movement movePlayer) : base(texture, spawnPosition, delay)
        {
            this.movePlayer = movePlayer;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Counter();
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

        public override void Move()
        {
            posXBefore = move.posX;
            posYBefore = move.posY;
            move.FollowPlayer(movePlayer);
            base.Move();
        }
    }
}
