using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ExamenProject.Loaders;
using ExamenProject.Screens;

namespace ExamenProject
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Song song;

        Screen screen;

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
            ContentLoader.getInstance().init(Content);
            MedievalFont.getInstance().init();
            GraphicsDeviceLoader.getInstance().init(GraphicsDevice);
    
            screen = new();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            song = Content.Load<Song>("Audio/MedievelBackground");
            //MediaPlayer.Play(song);

            InitializeGameObject();
        }

        public void InitializeGameObject()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            screen.getState().Update(gameTime);

            if(screen.getState() == screen.getStartScreen())
            {
                StartScreen sc = screen.getState() as StartScreen;
                if (sc.quit) Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            screen.getState().Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
