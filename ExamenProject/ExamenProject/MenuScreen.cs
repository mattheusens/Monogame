using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject
{
    static class MenuScreen
    {
        static bool pause = false;
        static bool pPressed = false;
        static Texture2D menuScreen;
        static Texture2D menuBackground;
        static Texture2D menuTitle;

        public static void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            menuScreen = content.Load<Texture2D>("MenuScreen/MenuScreen");
            menuBackground = content.Load<Texture2D>("MenuScreen/MenuBackground");
            menuTitle = content.Load<Texture2D>("MenuScreen/MenuTitle");

            if (pause)
            {
                spriteBatch.Draw(menuBackground, new Vector2(0, 0), null, Color.White, 0.0f, new Vector2(0, 0), 2.0f, SpriteEffects.None, 0.0f);
                spriteBatch.Draw(menuScreen, new Vector2(Game1.graphics.PreferredBackBufferWidth / 2, Game1.graphics.PreferredBackBufferHeight / 2), null, Color.White, 0.0f, new Vector2(96, 96), 4.5f, SpriteEffects.None, 1.0f);
                //spriteBatch.Draw(menuTitle, new Vector2(730, 137), null, Color.White, 0.0f, new Vector2(96, 32), 1.2f, SpriteEffects.None, 1.0f);

                spriteBatch.DrawString(Game1.font, "Menu", new Vector2(750, 200), Color.White, 0, new Vector2(50, 50), 2f, SpriteEffects.None, 0);
            }
        }

        public static void CheckPause()
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
