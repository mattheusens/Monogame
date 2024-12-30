using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Interfaces
{
    internal interface ILevelState
    {
        void goNextLevel();
        void goLastLevel();
        void init();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);

    }
}
