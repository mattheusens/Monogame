using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
        Enemy enemy;

        List<Block> blocks = new();
        Texture2D grassTexture;
        Texture2D waterTexture;

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
            grassTexture = Content.Load<Texture2D>("Background/Grass");
            waterTexture = Content.Load<Texture2D>("Background/Water");

            font = Content.Load<SpriteFont>("Font");
            song = Content.Load<Song>("Audio/MedievelBackground");
            #endregion

            MediaPlayer.Play(song);
            Maps.MakeMaps();

            InitializeGameObject();
        }

        public void InitializeGameObject()
        {
            hero = new Hero(textureHero, graphics, GraphicsDevice);
            enemy = new Enemy(enemyTexture, graphics, GraphicsDevice, hero.move);

            Maps.CreateBlocks(blocks, 0, waterTexture, grassTexture);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);
            enemy.Update(gameTime);
            Collision.CheckCollisionWater(blocks, hero);
            MenuScreen.CheckPause();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            for (int i = 0; i < blocks.Count; i++) blocks[i].Draw(spriteBatch);

            hero.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Coins: " + coins, new Vector2(20, 20), Color.White);

            MenuScreen.Draw(spriteBatch, Content);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
