using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ExamenProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D textureHero;
        Hero hero;

        List<Block> blocks = new();
        private Texture2D grassTexture;
        private Texture2D waterTexture;

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
            //grassTexture = Content.Load<Texture2D>("Grass1x1");
            //waterTexture = Content.Load<Texture2D>("Water");
            grassTexture = new Texture2D(GraphicsDevice, 1, 1);
            grassTexture.SetData(new[] { Color.Green });
            waterTexture = new Texture2D(GraphicsDevice, 1, 1);
            waterTexture.SetData(new[] { Color.LightBlue });

            Maps.MakeMaps();

            CreateBlocks(0);

            InitializeGameObject();
        }

        public void InitializeGameObject()
        {
            hero = new Hero(textureHero, graphics, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            for (int i = 0; i < blocks.Count; i++) blocks[i].Draw(spriteBatch);
            hero.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        
        private void CreateBlocks(int level)
        {
            blocks.Clear();
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
                        blocks.Add(new Block(pos, rec, waterTexture, "Water"));
                    }
                }
            }
        }
    }
}
