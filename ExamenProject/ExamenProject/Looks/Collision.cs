using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using ExamenProject.Characters;
using ExamenProject.Map.Nature;
using ExamenProject.Characters.Enemies;
using ExamenProject.Screens;

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

        public static void CheckAllCollisions(Hero hero, List<Enemy> ens, List<Block> bls, List<Building> bds, List<Tree> trs)
        {
            List<Character> chs = new();
            chs.Add(hero);
            foreach (Enemy en in ens) chs.Add(en);

            foreach (Character chr in chs)
            {
                CheckCollisionOnBlock(bls, chr); 
                CheckCollisionOnBuilding(bds, chr); 
                CheckCollisionOnTree(trs, chr);
            }

            CheckCollisionOnEnemies(ens, hero);
            CheckCollisionOnHero(ens, hero);

        }

        private static void CheckCollisionOnBlock(List<Block> blocks, Character character)
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

        private static void CheckCollisionOnBuilding(List<Building> buildings, Character character)
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
        private static void CheckCollisionOnTree(List<Tree> trees, Character character)
        {
            for (int i = 0; i < trees.Count; i++)
            {
                if (CheckCollision(character.rectangleFeet, trees[i].hitboxRectangle))
                {
                    character.move.posX = character.posXBefore;
                    character.move.posY = character.posYBefore;
                }
            }
        }

        private static List<Enemy> hitEnemies = new();
        private static void CheckCollisionOnEnemies(List<Enemy> enemies, Hero hero)
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
                        GameScreen.coins += 10;
                        i--;
                    }
                }
            }
        }

        private static bool heroHit = false;
        private static void CheckCollisionOnHero(List<Enemy> enemies, Hero hero)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (!(enemies[i] is FightingEnemy || enemies[i] is RandomEnemy)) continue;

                bool collisionR = CheckCollision(hero.rectangleHitbox, enemies[i].rectangleWeaponR) && enemies[i].move.lastMove == "right";
                bool collisionL = CheckCollision(hero.rectangleHitbox, enemies[i].rectangleWeaponL) && enemies[i].move.lastMove == "left";
                bool collision = (collisionR || collisionL) && !heroHit;

                if (enemies[i] is FightingEnemy FE)
                {
                    if (collision)
                    {
                        FE.counting = true;
                        heroHit = true;
                        continue;
                    }
                    if (!FE.moveAnimation.fighting && heroHit && FE.counterReset && !hero.invincible)
                    {
                        hero.hit = true;
                        heroHit = false;
                        FE.counterReset = false;
                    }
                }
                if (enemies[i] is RandomEnemy RE)
                {
                    if (!RE.fighting) continue;

                    if (collision)
                    {
                        RE.counting = true;
                        heroHit = true;
                        continue;
                    }
                    if (!RE.moveAnimation.fighting && heroHit && RE.counterReset && !hero.invincible)
                    {
                        hero.hit = true;
                        heroHit = false;
                        RE.counterReset = false;
                    }
                }
            }
        }
    }
}
