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

namespace ExamenProject.Levels
{
    internal class Level1 : ILevelState
    {
        CurrentLevel level;

        Hero hero;
        List<Enemy> enemies = new();
        List<Character> characters = new();
        Texture2D enemyTexture;

        List<Block> blocks = new();
        List<Building> buildings = new();
        List<Tree> trees = new();

        int levelNr = 1;
        bool gateOpen = false;

        public Level1(CurrentLevel level)
        {
            this.level = level;

            ContentManager Content = ContentLoader.getInstance().contentM;

            enemyTexture = Content.Load<Texture2D>("Torch_Blue_Fixed_Full");

            hero = level.hero;
        }
        public void init()
        {
            enemies.Add(new Enemy(enemyTexture, hero.move, true));

            characters.Add(hero);
            foreach (Enemy en in enemies) characters.Add(en);

            Maps.CreateMap(blocks, buildings, trees, levelNr - 1);
        }
        public void Update(GameTime gameTime)
        {
            foreach (Enemy en in enemies) if (Collision.CheckCollision(hero.rectangleHitbox, en.rectangleWeaponR)) en.counting = true;

            hero.Update(gameTime);
            foreach (Enemy en in enemies) en.Update(gameTime);
            foreach (Tree tr in trees) tr.Update(gameTime);

            foreach (Character chr in characters) Collision.CheckCollisionOnBuilding(buildings, chr);
            foreach (Character chr in characters) Collision.CheckCollisionOnBlock(blocks, chr);

            Collision.CheckCollisionOnTree(trees, hero);

            Collision.CheckCollisionOnEnemies(enemies, hero);
            Collision.CheckCollisionOnHero(enemies, hero);

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
