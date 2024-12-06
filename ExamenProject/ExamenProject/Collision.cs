using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ExamenProject
{
    static class Collision
    {
        public static bool CheckTileCollision(Rectangle rectPlayer, Rectangle rectTile)
        {
            if (rectTile.Top < rectPlayer.Bottom && rectTile.Right > rectPlayer.Left && rectTile.Left < rectPlayer.Right) return true;
            if (rectTile.Top < rectPlayer.Bottom && rectTile.Bottom > rectPlayer.Top && rectTile.Left < rectPlayer.Right) return true;
            //if (rectTile.Top < rectPlayer.Bottom && rectTile.Bottom > rectPlayer.Top && rectTile.Right > rectPlayer.Left) return true; WERKT NIET
            //if (rectTile.Bottom > rectPlayer.Top && rectTile.Right > rectPlayer.Left && rectTile.Left < rectPlayer.Right) return true; WERKT NIET
            return false;
        }
    }
}
