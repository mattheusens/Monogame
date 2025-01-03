using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExamenProject.Characters.Enemies
{
    internal class DistanceEnemy : Enemy
    {
        Movement movePlayer;

        public DistanceEnemy(Texture2D texture, Vector2 spawnPosition, int delay, Movement movePlayer) : base(texture, spawnPosition, delay)
        {
            this.movePlayer = movePlayer;
        }

        public override void Move()
        {
            posXBefore = move.posX;
            posYBefore = move.posY;
            move.FollowDistancePlayer(movePlayer);
            base.Move();
        }
    }
}
