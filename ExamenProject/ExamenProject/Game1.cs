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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Song song;

        Texture2D textureHero;
        Hero hero;
        Texture2D enemyTexture;
        Enemy enemy;

        List<Block> blocks = new();
        private Texture2D grassTexture;
        private Texture2D waterTexture;

        Texture2D menuScreen;
        Texture2D menuBackground;
        bool pause = false;
        bool pPressed = false;

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

            menuScreen = Content.Load<Texture2D>("MenuScreen/MenuScreen");
            menuBackground = Content.Load<Texture2D>("MenuScreen/MenuBackground");

            font = Content.Load<SpriteFont>("Font");
            song = Content.Load<Song>("Audio/MedievelBackground");
            #endregion

            //grassTexture = Content.Load<Texture2D>("Grass1x1");

            MediaPlayer.Play(song);
            Maps.MakeMaps();
            Maps.CreateBlocks(blocks, 0, grassTexture, waterTexture);

            InitializeGameObject();
        }

        public void InitializeGameObject()
        {
            hero = new Hero(textureHero, graphics, GraphicsDevice);
            enemy = new Enemy(enemyTexture, graphics, GraphicsDevice, hero.move);

            grassTexture = new Texture2D(GraphicsDevice, 1, 1);
            grassTexture.SetData(new[] { Color.Green });
            waterTexture = new Texture2D(GraphicsDevice, 1, 1);
            waterTexture.SetData(new[] { Color.LightBlue });
        }

        private Color clr = Color.Gray;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);
            enemy.Update(gameTime);
            Collision.CheckCollisionWater(blocks, hero);
            CheckPause();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            for (int i = 0; i < blocks.Count; i++) blocks[i].Draw(spriteBatch);

            hero.Draw(spriteBatch);
            //enemy.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Coins: " + coins, new Vector2(20, 20), Color.White);

            if (pause)
            {
                spriteBatch.Draw(menuBackground, new Vector2(0, 0), null, Color.White, 0.0f, new Vector2(0, 0), 2.0f, SpriteEffects.None, 0.0f);
                spriteBatch.Draw(menuScreen, new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2), null, Color.White, 0.0f, new Vector2(96, 96), 4.5f, SpriteEffects.None, 1.0f);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        void CheckPause()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P) && !pPressed)
            {
                pause = !pause;
                pPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.P)) pPressed = false;
        }
    }
}
