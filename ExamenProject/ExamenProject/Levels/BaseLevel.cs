using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ExamenProject.Characters;
using ExamenProject.Characters.Enemies;
using ExamenProject.Map.Nature;
using ExamenProject.Map;
using ExamenProject.Loaders;
using Microsoft.Xna.Framework.Content;
using ExamenProject.Maps;
using ExamenProject.Screens;

namespace ExamenProject.Levels
{
    abstract class BaseLevel
    {
        protected CurrentLevel level;

        protected Hero hero;
        protected List<Enemy> enemies;
        protected Texture2D enemyTexture;

        protected List<Block> blocks;
        protected List<Building> buildings;
        protected List<Tree> trees;

        protected int levelNr = 2;

        public BaseLevel(CurrentLevel level)
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

        public virtual void initMap()
        {
            enemies.Clear();
            MapLoader.LoadMap(levelNr, blocks, buildings, trees);
        }

        public virtual void Update(GameTime gameTime)
        {
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
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block block in blocks) if (block.Type == "Water") block.Draw(spriteBatch);
            foreach (Block block in blocks) if (block.Type == "Grass") block.Draw(spriteBatch);

            foreach (Tree tr in trees) tr.Draw(spriteBatch);
            foreach (Building bd in buildings) bd.Draw(spriteBatch);
            foreach (Enemy enemy in enemies) enemy.Draw(spriteBatch);

            hero.Draw(spriteBatch);
        }
    }
}
