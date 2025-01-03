using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenProject.Interfaces;
using ExamenProject.Characters;
using ExamenProject.Map.Nature;
using ExamenProject.Map;
using ExamenProject.Maps;
using ExamenProject.Loaders;
using Microsoft.Xna.Framework.Content;
using ExamenProject.Characters.Enemies;

namespace ExamenProject.Levels
{
    internal class Level2 : ILevelState
    {
        Random rng = new Random();
        CurrentLevel level;

        Hero hero;
        List<Enemy> enemies;
        Texture2D enemyTexture;
        List<Vector2> enemySpawns = new();

        List<Block> blocks;
        List<Building> buildings;
        List<Tree> trees;

        int levelNr = 2;

        public Level2(CurrentLevel level)
        {
            this.level = level;

            ContentManager Content = ContentLoader.getInstance().contentM;

            enemyTexture = Content.Load<Texture2D>("Torch_Blue_Fixed_Full");

            hero = level.hero;
            enemies = level.enemies;
            blocks = level.blocks;
            buildings = level.buildings;
            trees = level.trees;

            enemySpawns.Add(new(200, 180));
            enemySpawns.Add(new(1100, 180));
        }

        public void init()
        {
            MapLoader.LoadMap(levelNr, blocks, buildings, trees);
        }

        public void Update(GameTime gameTime)
        {
            if (enemies.Count < 4) SpawnRandomEnemy();

            foreach (Enemy en in enemies)
            {
                if (Collision.CheckCollision(hero.rectangleHitbox, en.rectangleWeaponR) && en is FightingEnemy)
                {
                    FightingEnemy en2 = en as FightingEnemy;
                    en2.counting = true;
                }
            }

            hero.Update(gameTime);

            foreach (Enemy en in enemies) en.Update(gameTime);

            foreach (Tree tr in trees) tr.Update(gameTime);

            Collision.CheckAllCollisions(hero, enemies, blocks, buildings, trees);

            if (hero.move.posY < -90) goLastLevel();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < blocks.Count; i++) if (blocks[i].Type == "Water") blocks[i].Draw(spriteBatch);
            for (int i = 0; i < blocks.Count; i++) if (blocks[i].Type == "Grass") blocks[i].Draw(spriteBatch);
            foreach (Tree tr in trees) tr.Draw(spriteBatch);
            for (int i = 0; i < buildings.Count; i++) buildings[i].Draw(spriteBatch);

            hero.Draw(spriteBatch);
            foreach (Enemy enemy in enemies) enemy.Draw(spriteBatch);
        }

        private void SpawnRandomEnemy()
        {
            int number = rng.Next(1, 8);

            switch (number)
            {
                case 1:
                    enemies.Add(new CloseEnemy(enemyTexture, enemySpawns[rng.Next(0, 2)], 0, hero.move));
                    break;
                case 2:
                    enemies.Add(new DistanceEnemy(enemyTexture, enemySpawns[rng.Next(0, 2)], 0, hero.move));
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                    enemies.Add(new FightingEnemy(enemyTexture, enemySpawns[rng.Next(0, 2)], 0, hero.move));
                    break;
                case 7:
                    if (rng.Next(1, 3) == 1) enemies.Add(new RandomEnemy(enemyTexture, enemySpawns[rng.Next(0, 2)], 0, true));
                    else enemies.Add(new RandomEnemy(enemyTexture, enemySpawns[rng.Next(0, 2)], 0, false));
                    break;
            }
        }
        public void goNextLevel()
        {

        }
        public void goLastLevel()
        {
            level.setState(level.getLevel1());
            level.getState().init();
            hero.move.posY = 900;
        }
    }
}
