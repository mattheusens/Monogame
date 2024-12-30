using ExamenProject.Interfaces;
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

namespace ExamenProject.Levels
{
    internal class Level1 : ILevelState
    {
        CurrentLevel level;

        Hero hero;
        List<Enemy> enemies;
        List<Character> characters;
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

            enemyTexture = Content.Load<Texture2D>("Torch_Blue_Fixed_Full");

            hero = level.hero;
            enemies = level.enemies;
            characters = level.characters;
            blocks = level.blocks;
            buildings = level.buildings;
            trees = level.trees;
        }
        public void init()
        {
            enemies.Add(new Enemy(enemyTexture, hero.move, true));

            foreach (Enemy en in enemies) characters.Add(en);

            MapLoader.LoadMap(levelNr, blocks, buildings, trees);
        }
        public void Update(GameTime gameTime)
        {
            foreach (Enemy en in enemies) if (Collision.CheckCollision(hero.rectangleHitbox, en.rectangleWeaponR)) en.counting = true;

            hero.Update(gameTime);
            foreach (Enemy en in enemies) en.Update(gameTime);
            foreach (Tree tr in trees) tr.Update(gameTime);

            Collision.CheckAllCollisions(hero, enemies, blocks, buildings, trees);

            if (!enemies.Any() && !gateOpen) RemoveTrees();
            if (hero.move.posY > 900) goNextLevel();
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
        public void goNextLevel()
        {
            level.setState(level.getLevel2());
            level.getState().init();
            hero.move.posY = -50;
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
