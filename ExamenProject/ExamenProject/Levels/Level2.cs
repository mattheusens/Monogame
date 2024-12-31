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

namespace ExamenProject.Levels
{
    internal class Level2 : ILevelState
    {
        CurrentLevel level;

        Hero hero;
        List<Enemy> enemies;
        Texture2D enemyTexture;

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
        }

        public void init()
        {
            MapLoader.LoadMap(2, blocks, buildings, trees);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Enemy en in enemies) if (Collision.CheckCollision(hero.rectangleHitbox, en.rectangleWeaponR)) en.counting = true;

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
