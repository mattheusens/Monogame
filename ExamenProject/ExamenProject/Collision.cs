using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

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
            if (rectTile.Top < rectPlayer.Bottom && rectTile.Bottom > rectPlayer.Top && rectTile.Right + 3 > rectPlayer.Left && rectTile.Left < rectPlayer.Left)
            {
                return true;
            } // van rechts naar links
            if (rectTile.Bottom + 3 > rectPlayer.Top && rectTile.Right > rectPlayer.Left && rectTile.Left < rectPlayer.Right && rectTile.Top < rectPlayer.Top)
            {
                return true;
            } // van onder naar boven
            return false;
        }

        public static void CheckCollisionOnBlock(List<Block> blocks, Hero hero)
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

        public static void CheckCollisionOnBlock(List<Block> blocks, Enemy enemy)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].Type == "Water")
                {
                    if (Collision.CheckCollision(enemy.rectangleFeet, blocks[i].BoundingBox))
                    {
                        enemy.move.posX = enemy.posXBefore;
                        enemy.move.posY = enemy.posYBefore;
                    }

                }
            }
        }

        public static void CheckCollisionOnBuilding(List<Building> buildings, Hero hero)
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                if (Collision.CheckCollision(hero.rectangleFeet, buildings[i].HitboxRectangle))
                {
                    hero.move.posX = hero.posXBefore;
                    hero.move.posY = hero.posYBefore;
                }
            }
        }

        public static void CheckCollisionOnBuilding(List<Building> buildings, Enemy enemy)
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                if (Collision.CheckCollision(enemy.rectangleHitbox, buildings[i].HitboxRectangle))
                {
                    enemy.move.posX = enemy.posXBefore;
                    enemy.move.posY = enemy.posYBefore;
                }
            }
        }

        public static List<Enemy> hitEnemies = new();

        public static void CheckCollisionOnEnemies(List<Enemy> enemies, Hero hero)
        {

            if (!hero.moveAnimation.fighting)
            {
                hitEnemies.Clear();
                return;
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                bool collisionR = CheckCollision(hero.rectangleWeaponR, enemies[i].rectangleHitbox) && hero.move.lastMove == "right";
                bool collisionL = CheckCollision(hero.rectangleWeaponL, enemies[i].rectangleHitbox) && hero.move.lastMove == "left";

                if ((collisionR || collisionL) && !hitEnemies.Contains(enemies[i]))
                {
                    hitEnemies.Add(enemies[i]);
                    enemies[i].health--;

                    if (enemies[i].health <= 0)
                    {
                        enemies.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        public static void CheckCollisionOnHero(List<Enemy> enemies, Hero hero)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (CheckCollision(hero.rectangleHitbox, enemies[i].rectangleHitbox) /*&& enemies[i].moveAnimation.fighting*/)
                {
                    Debug.Write("auwch");
                    hero.health--;
                }
            }
        }
    }
}
