using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using ExamenProject.Interfaces;
using ExamenProject.Characters;
using ExamenProject.Map.Nature;
using ExamenProject.Map;
using ExamenProject.Maps;
using ExamenProject.Loaders;
using ExamenProject.Characters.Enemies;
using ExamenProject.Screens;

namespace ExamenProject.Levels
{
    internal class Level2 : BaseLevel, ILevelState
    {
        Random rng = new Random();

        List<Vector2> enemySpawns = new();

        public Level2(CurrentLevel level) : base(level)
        {
            this.level = level;
            levelNr = 2;

            enemySpawns.Add(new(200, 180));
            enemySpawns.Add(new(1100, 180));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (enemies.Count < 4) SpawnRandomEnemy();
            if (hero.move.posY < -90) goLastLevel();
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
        public void initEnemies() { } // Does nothing
        public void goNextLevel()
        {
            // Impossible
        }
        public void goLastLevel()
        {
            level.setState(level.getLevel1());
            level.getState().initMap();

            hero.move.posY = 900;
        }
    }
}
