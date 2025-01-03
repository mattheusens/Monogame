﻿using ExamenProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenProject.Characters;
using Microsoft.Xna.Framework.Content;
using ExamenProject.Map.Nature;
using ExamenProject.Map;
using ExamenProject.Loaders;
using System.Diagnostics;
using ExamenProject.Maps;
using ExamenProject.Screens;
using ExamenProject.Characters.Enemies;

namespace ExamenProject.Levels
{
    internal class Level1 : ILevelState
    {
        CurrentLevel level;

        Hero hero;
        List<Enemy> enemies;
        Texture2D enemyTexture;

        List<Block> blocks;
        List<Building> buildings;
        List<Tree> trees;

        int levelNr = 1;
        bool gateOpen = false;

        public Level1(CurrentLevel level)
        {
            this.level = level;

            ContentManager Content = ContentLoader.getInstance().contentM;

            enemyTexture = Content.Load<Texture2D>($"Torch_{GameScreen.color}_Fixed_Full");

            hero = level.hero;
            enemies = level.enemies;
            blocks = level.blocks;
            buildings = level.buildings;
            trees = level.trees;
        }
        public void init()
        {
            MapLoader.LoadMap(levelNr, blocks, buildings, trees);

            if (!gateOpen)
            {
                enemies.Add(new CloseEnemy(enemyTexture, new(200, 180), 300, hero.move));
                enemies.Add(new DistanceEnemy(enemyTexture, new(200, 180), 600, hero.move));
                enemies.Add(new RandomEnemy(enemyTexture, new(200, 180), 900, false));
                enemies.Add(new RandomEnemy(enemyTexture, new(200, 180), 1200, true));
                enemies.Add(new FightingEnemy(enemyTexture, new(200, 180), 1500, hero.move));
            }
            else RemoveTrees();

        }
        public void Update(GameTime gameTime)
        {
            foreach (Enemy en in enemies) { 
                if (Collision.CheckCollision(hero.rectangleHitbox, en.rectangleWeaponR) && en is FightingEnemy) {
                    FightingEnemy en2 = en as FightingEnemy;
                    en2.counting = true;
                }
            }   

            hero.Update(gameTime);

            foreach (Enemy en in enemies) en.Update(gameTime);

            foreach (Tree tr in trees) tr.Update(gameTime);

            Collision.CheckAllCollisions(hero, enemies, blocks, buildings, trees);

            if (!enemies.Any() && !gateOpen) RemoveTrees();
            if (hero.move.posY > 900) goNextLevel();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block bl in blocks) if (bl.Type == "Water") bl.Draw(spriteBatch);
            foreach(Block bl in blocks) if (bl.Type == "Grass") bl.Draw(spriteBatch);

            foreach (Tree tr in trees) tr.Draw(spriteBatch);
            foreach (Building bd in buildings) bd.Draw(spriteBatch);
            foreach (Enemy enemy in enemies) enemy.Draw(spriteBatch);

            hero.Draw(spriteBatch);
        }
        public void goNextLevel()
        {
            level.setState(level.getLevel2());
            level.getState().init();
            hero.move.posY = -90;
        }
        public void goLastLevel()
        { 
            // Impossible
        }
        private void RemoveTrees()
        {
            for (int i = 0; i < 6; i++) trees.RemoveAt(98);
            gateOpen = true;
        }
    }
}
