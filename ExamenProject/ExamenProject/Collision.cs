using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace ExamenProject
{
    static class Collision
    {
        public static bool CheckTileCollision(Rectangle rectPlayer, Rectangle rectTile)
        {
            if (rectTile.Top - 3 < rectPlayer.Bottom && rectTile.Right > rectPlayer.Left && rectTile.Left < rectPlayer.Right && rectTile.Bottom > rectPlayer.Bottom)
            {
                return true;
            } // van boven naar onder
            if (rectTile.Top < rectPlayer.Bottom && rectTile.Bottom > rectPlayer.Top && rectTile.Left - 3 < rectPlayer.Right && rectTile.Right > rectPlayer.Right) 
            { 
                return true;
            } // van links naar rechts
            if (rectTile.Top < rectPlayer.Bottom && rectTile.Bottom > rectPlayer.Top && rectTile.Right + 3> rectPlayer.Left && rectTile.Left < rectPlayer.Left) 
            { 
                return true; 
            } // van rechts naar links
            if (rectTile.Bottom + 3 > rectPlayer.Top && rectTile.Right > rectPlayer.Left && rectTile.Left < rectPlayer.Right && rectTile.Top < rectPlayer.Top)
            {
                return true;
            } // van onder naar boven
            return false;
        }

        public static void CheckCollisionWater(List<Block> blocks, Hero hero)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].Type == "Water")
                {
                    if (Collision.CheckTileCollision(hero.rectangleFeet, blocks[i].BoundingBox))
                    {
                        hero.move.posX = hero.posXBefore;
                        hero.move.posY = hero.posYBefore;
                    }

                }
            }
        }
    }
}
