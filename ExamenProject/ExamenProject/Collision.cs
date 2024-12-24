using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExamenProject
{
    static class Collision
    {
        public static bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect2.Top - 3 < rect1.Bottom && rect2.Right > rect1.Left && rect2.Left < rect1.Right && rect2.Bottom > rect1.Bottom)
            {
                return true;
            } // van boven naar onder
            if (rect2.Top < rect1.Bottom && rect2.Bottom > rect1.Top && rect2.Left - 3 < rect1.Right && rect2.Right > rect1.Right)
            {
                return true;
            } // van links naar rechts
            if (rect2.Top < rect1.Bottom && rect2.Bottom > rect1.Top && rect2.Right + 3 > rect1.Left && rect2.Left < rect1.Left)
            {
                return true;
            } // van rechts naar links
            if (rect2.Bottom + 3 > rect1.Top && rect2.Right > rect1.Left && rect2.Left < rect1.Right && rect2.Top < rect1.Top)
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
                    if (CheckCollision(hero.rectangleFeet, blocks[i].BoundingBox))
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
                    if (CheckCollision(enemy.rectangleFeet, blocks[i].BoundingBox))
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
                if (CheckCollision(hero.rectangleFeet, buildings[i].HitboxRectangle))
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
                if (CheckCollision(enemy.rectangleFeet, buildings[i].HitboxRectangle))
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
                bool collisionR = CheckCollision(enemies[i].rectangleHitbox, hero.rectangleWeaponR) && hero.move.lastMove == "right";
                bool collisionL = CheckCollision(enemies[i].rectangleHitbox, hero.rectangleWeaponL) && hero.move.lastMove == "left";

                //Debug.WriteLine(collisionR + " " + collisionL);

                if ((collisionR || collisionL) && !hitEnemies.Contains(enemies[i]))
                {
                    hitEnemies.Add(enemies[i]);
                    enemies[i].health--;
                    Debug.WriteLine("hit");

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
                if (!enemies[i].moveAnimation.fighting) continue;

                bool collisionR = CheckCollision(hero.rectangleHitbox, enemies[i].rectangleWeaponR) && enemies[i].move.lastMove == "right";
                bool collisionL = CheckCollision(hero.rectangleHitbox, enemies[i].rectangleWeaponL) && enemies[i].move.lastMove == "left";

                if (collisionR || collisionL)
                {
                    Debug.Write("auwch");
                    hero.health--;
                }
            }
        }
    }
}
