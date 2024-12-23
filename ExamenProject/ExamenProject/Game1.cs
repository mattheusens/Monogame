using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace ExamenProject
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static SpriteFont font;
        private Song song;

        Texture2D textureHero;
        Hero hero;
        Texture2D enemyTexture;
        List<Enemy> enemies = new();

        List<Block> blocks = new();
        Texture2D grassTexture;
        Texture2D waterTexture;

        List<Building> buildings = new();
        Texture2D castleTexture; // 320x256
        Texture2D houseTexture; // 128x192
        Texture2D towerTexture; // 128x256

        public int level = 0;
        public int coins = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 900;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Content Loads
            textureHero = Content.Load<Texture2D>("Warrior_Blue_Full");
            enemyTexture = Content.Load<Texture2D>("Torch_Blue_Fixed_Full");
            grassTexture = Content.Load<Texture2D>("Background/Grass_Big");
            waterTexture = Content.Load<Texture2D>("Background/Water");
            castleTexture = Content.Load<Texture2D>("Background/Buildings/Blue/Castle");
            houseTexture = Content.Load<Texture2D>("Background/Buildings/Blue/House");
            towerTexture = Content.Load<Texture2D>("Background/Buildings/Blue/Tower");

            font = Content.Load<SpriteFont>("Font");
            song = Content.Load<Song>("Audio/MedievelBackground");
            #endregion

            //MediaPlayer.Play(song);
            Maps.MakeMaps();

            InitializeGameObject();
        }

        public void InitializeGameObject()
        {
            hero = new Hero(textureHero, graphics, GraphicsDevice);
            enemies.Add(new Enemy(enemyTexture, graphics, GraphicsDevice, hero.move));
            Maps.CreateBuildings(buildings, level, castleTexture, houseTexture, towerTexture, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Maps.CreateBlocks(blocks, level, waterTexture, grassTexture);

            hero.Update(gameTime);

            foreach (Enemy en in enemies) en.Update(gameTime);

            Collision.CheckCollisionOnBuilding(buildings, hero);
            Collision.CheckCollisionOnEnemies(enemies, hero);
            Collision.CheckCollisionOnBlock(blocks, hero);

            MenuScreen.CheckPause();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            for (int i = 0; i < blocks.Count; i++) if (blocks[i].Type == "Water") blocks[i].Draw(spriteBatch);
            for (int i = 0; i < blocks.Count; i++) if (blocks[i].Type == "Grass") blocks[i].Draw(spriteBatch);

            for (int i = 0; i < buildings.Count; i++) buildings[i].Draw(spriteBatch);

            hero.Draw(spriteBatch);

            foreach (Enemy enemy in enemies) enemy.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Coins: " + coins, new Vector2(20, 20), Color.White);

            MenuScreen.Draw(spriteBatch, Content);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
