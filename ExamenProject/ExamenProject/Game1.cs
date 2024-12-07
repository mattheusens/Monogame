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
        List<Block> waterBlocks = new();
        private Texture2D grassTexture;
        private Texture2D waterTexture;

        Texture2D pauseScreen;

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
            
            textureHero = Content.Load<Texture2D>("Warrior_Blue_Full");
            enemyTexture = Content.Load<Texture2D>("Torch_Blue_Fixed_Full");
            pauseScreen = Content.Load<Texture2D>("Carved_3Slides");
            font = Content.Load<SpriteFont>("Font");
            song = Content.Load<Song>("Audio/MedievelBackground");

            //grassTexture = Content.Load<Texture2D>("Grass1x1");
            grassTexture = new Texture2D(GraphicsDevice, 1, 1);
            grassTexture.SetData(new[] { Color.Green });
            waterTexture = new Texture2D(GraphicsDevice, 1, 1);
            waterTexture.SetData(new[] { Color.LightBlue });

            MediaPlayer.Play(song);
            Maps.MakeMaps();
            CreateBlocks(0);

            InitializeGameObject();
        }

        public void InitializeGameObject()
        {
            hero = new Hero(textureHero, graphics, GraphicsDevice);
            enemy = new Enemy(enemyTexture, graphics, GraphicsDevice, hero.move);
        }

        private Color clr = Color.Gray;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);
            enemy.Update(gameTime);

            for(int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].Type == "Water")
                {
                    if (Collision.CheckTileCollision(hero.rectangleFeet, blocks[i].BoundingBox)) {
                        hero.move.posX = hero.posXBefore;
                        hero.move.posY = hero.posYBefore;
                    } 
                }
            }

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

            /*if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                spriteBatch.Draw(pauseScreen, )
            }*/

            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        private void CreateBlocks(int level)
        {
            blocks.Clear();
            waterBlocks.Clear();
            for (int l = 0; l < Maps.maps[level].GetLength(0); l++)
            {
                for (int c = 0; c < Maps.maps[level].GetLength(1); c++)
                {
                    int width = 100; int height = 100;
                    Vector2 pos = new Vector2((c * width), (l * height));
                    Rectangle rec = new Rectangle((c * width), (l * height), width, height);
                    if (Maps.maps[level][l, c] == 0)
                    {
                        blocks.Add(new Block(pos, rec, grassTexture, "Grass"));
                    }
                    else if (Maps.maps[level][l, c] == 1)
                    {
                        Block wb = new Block(pos, rec, waterTexture, "Water");
                        blocks.Add(wb);
                        waterBlocks.Add(wb);
                    }
                }
            }
        }
    }
}
