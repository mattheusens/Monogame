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
        public static bool CheckCollision(Rectangle rectPlayer, Rectangle rectTile)
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
                    if (Collision.CheckCollision(hero.rectangleFeet, blocks[i].BoundingBox))
                    {
                        hero.move.posX = hero.posXBefore;
                        hero.move.posY = hero.posYBefore;
                    }

                }
            }
        }

        public static void CheckCollisionOnEnemies(List<Enemy> enemies, Hero hero)
        {
            bool inHit = false;
            for (int i = 0; i < enemies.Count; i++)
            {
                bool collisionR = Collision.CheckCollision(hero.rectangleWeaponR, enemies[i].rectangleHitbox) && hero.moveAnimation.fighting && !inHit && hero.move.lastMove == "right";
                bool collisionL = Collision.CheckCollision(hero.rectangleWeaponL, enemies[i].rectangleHitbox) && hero.moveAnimation.fighting && !inHit && hero.move.lastMove == "left";
                if (collisionR || collisionL)
                {
                    Debug.Write("hit");
                    enemies[i].health--;
                    if (enemies[i].health == 0) enemies.Remove(enemies[i]);
                    inHit = true;
                }
                if (!hero.moveAnimation.fighting) inHit = false;
            }
        }

        public static void CheckCollisionOnHero(List<Enemy> enemies, Hero hero)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                if(CheckCollision(hero.rectangleHitbox, enemies[i].rectangleHitbox) /*&& enemies[i].moveAnimation.fighting*/)
                {
                    Debug.Write("auwch");
                    hero.health--;
                }
            }
        }
    }
}
