using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using ExamenProject.Characters;
using ExamenProject.Map.Nature;

namespace ExamenProject.Map
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

        public static void CheckCollisionOnBlock(List<Block> blocks, Character character)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].Type == "Water")
                {
                    if (CheckCollision(character.rectangleFeet, blocks[i].BoundingBox))
                    {
                        character.move.posX = character.posXBefore;
                        character.move.posY = character.posYBefore;
                    }

                }
            }
        }

        public static void CheckCollisionOnBuilding(List<Building> buildings, Character character)
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                if (CheckCollision(character.rectangleFeet, buildings[i].hitboxRectangle))
                {
                    character.move.posX = character.posXBefore;
                    character.move.posY = character.posYBefore;
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

        public static bool heroHit = false;
        public static void CheckCollisionOnHero(List<Enemy> enemies, Hero hero)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!enemies[i].moveAnimation.fighting)
                {
                    if (heroHit) hero.health--;
                    heroHit = false;
                    continue;
                }

                bool collisionR = CheckCollision(hero.rectangleHitbox, enemies[i].rectangleWeaponR) && enemies[i].move.lastMove == "right";
                bool collisionL = CheckCollision(hero.rectangleHitbox, enemies[i].rectangleWeaponL) && enemies[i].move.lastMove == "left";

                if ((collisionR || collisionL) && !heroHit)
                {
                    heroHit = true;
                }
            }
        }

        public static void CheckCollisionOnTree(List<Tree> trees, Hero hero)
        {
            for (int i = 0; i < trees.Count; i++)
            {
                if (CheckCollision(hero.rectangleFeet, trees[i].hitboxRectangle))
                {
                    hero.move.posX = hero.posXBefore;
                    hero.move.posY = hero.posYBefore;
                }
            }
        }
    }
}
