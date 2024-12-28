using ExamenProject.Interfaces;
using ExamenProject.Nature;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ExamenProject.Screens
{
    internal class GameScreen : IScreenState
    {
        Screen screen;
        GraphicsDevice graphicsDevice;
        SpriteFont font;

        Hero hero;
        List<Enemy> enemies = new();

        List<Building> buildings = new();
        List<Block> blocks = new();
        List<Tree> trees = new();

        int level = 0;
        int coins = 0;

        Texture2D heroTexture;
        Texture2D enemyTexture;
        Texture2D waterTexture;
        Texture2D grassTexture;
        Texture2D castleTexture;
        Texture2D houseTexture;
        Texture2D towerTexture;

        public GameScreen(Screen screen)
        {
            this.screen = screen;

            ContentManager Content = ContentLoader.getInstance().contentM;
            graphicsDevice = GraphicsDeviceLoader.getInstance().graphicsDevice;
            font = MedievalFont.getInstance().font;

            heroTexture = Content.Load<Texture2D>("Warrior_Blue_Full");
            enemyTexture = Content.Load<Texture2D>("Torch_Blue_Fixed_Full");
            grassTexture = Content.Load<Texture2D>("Background/Grass_Big");
            waterTexture = Content.Load<Texture2D>("Background/Water");
            castleTexture = Content.Load<Texture2D>("Background/Buildings/Blue/Castle");
            houseTexture = Content.Load<Texture2D>("Background/Buildings/Blue/House");
            towerTexture = Content.Load<Texture2D>("Background/Buildings/Blue/Tower");

            Maps.MakeMaps();

            hero = new Hero(heroTexture, graphicsDevice);
            enemies.Add(new Enemy(enemyTexture, graphicsDevice, hero.move, true));

            Maps.CreateTrees(trees, 0, graphicsDevice);
            Maps.CreateBlocks(blocks, level, waterTexture, grassTexture);
            Maps.CreateBuildings(buildings, level, castleTexture, houseTexture, towerTexture, graphicsDevice);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Enemy en in enemies) if (Collision.CheckCollision(hero.rectangleHitbox, en.rectangleWeaponR)) en.counting = true;

            hero.Update(gameTime);
            foreach (Enemy en in enemies) en.Update(gameTime);
            foreach (Tree tr in trees) tr.Update(gameTime);

            Collision.CheckCollisionOnBuilding(buildings, hero);
            foreach (Enemy en in enemies) Collision.CheckCollisionOnBuilding(buildings, en);

            Collision.CheckCollisionOnTree(trees, hero);
            foreach (Enemy en in enemies) Collision.CheckCollisionOnTree(trees, en);

            Collision.CheckCollisionOnEnemies(enemies, hero);
            Collision.CheckCollisionOnHero(enemies, hero);

            Collision.CheckCollisionOnBlock(blocks, hero);
            foreach (Enemy en in enemies) Collision.CheckCollisionOnBlock(blocks, en);

            if (hero.health == 0) goToEndScreen();
            if (Keyboard.GetState().IsKeyDown(Keys.P)) goToMenuScreen();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < blocks.Count; i++) if (blocks[i].Type == "Water") blocks[i].Draw(spriteBatch);
            for (int i = 0; i < blocks.Count; i++) if (blocks[i].Type == "Grass") blocks[i].Draw(spriteBatch);
            foreach (Tree tr in trees) tr.Draw(spriteBatch);
            for (int i = 0; i < buildings.Count; i++) buildings[i].Draw(spriteBatch);

            hero.Draw(spriteBatch);
            foreach (Enemy enemy in enemies) enemy.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Coins: " + coins, new Vector2(20, 20), Color.White);
        }

        public void goToStartScreen() 
        { 
            // Impossible
        }
        public void goToBugScreen() 
        { 
            // Impossible
        }
        public void goToGame() 
        {
            // Already here
        }
        public void goToMenuScreen() 
        {
            screen.state = screen.getMenuScreen();
        }
        public void goToEndScreen() 
        {
            screen.state = screen.getGameOverScreen();
        }
        public void exitGame() 
        {
            // Impossible
        }
    }
}
