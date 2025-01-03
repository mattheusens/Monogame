using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Characters.Enemies
{
    internal class CloseEnemy : Enemy
    {
        Movement movePlayer;

        public CloseEnemy(Texture2D texture, Vector2 spawnPosition, int delay, Movement movePlayer) : base(texture, spawnPosition, delay)
        {
            this.movePlayer = movePlayer;
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
