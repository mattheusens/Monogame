using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

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

        Texture2D castle;
        Texture2D house;
        Texture2D tower;

        int coins = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 900;
            //graphics.IsFullScreen = true;

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
            castle = Content.Load<Texture2D>("Background/Buildings/Blue/Castle");
            house = Content.Load<Texture2D>("Background/Buildings/Blue/House");
            tower = Content.Load<Texture2D>("Background/Buildings/Blue/Tower");

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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Maps.CreateBlocks(blocks, 0, waterTexture, grassTexture);
            hero.Update(gameTime);

            foreach(Enemy en in enemies) en.Update(gameTime);
            Collision.CheckCollisionOnEnemies(enemies, hero);

            Collision.CheckCollisionWater(blocks, hero);
            MenuScreen.CheckPause();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            for (int i = 0; i < blocks.Count; i++)  if (blocks[i].Type == "Water") blocks[i].Draw(spriteBatch);
            for (int i = 0; i < blocks.Count; i++) if (blocks[i].Type == "Grass") blocks[i].Draw(spriteBatch);


            spriteBatch.Draw(castle, new Rectangle(500, 20, 320, 256), Color.White);
            spriteBatch.Draw(house, new Rectangle(1000, 200, 128, 192), Color.White);
            spriteBatch.Draw(tower, new Rectangle(500, 500, 128, 256), Color.White);

            hero.Draw(spriteBatch);

            foreach (Enemy enemy in enemies) enemy.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Coins: " + coins, new Vector2(20, 20), Color.White);

            MenuScreen.Draw(spriteBatch, Content);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
