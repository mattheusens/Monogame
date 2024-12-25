using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ExamenProject
{
    internal class MedievalFont
    {
        private static MedievalFont uniqueInstance = new MedievalFont();
        public SpriteFont font;

        public static MedievalFont getInstance()
        {
            return uniqueInstance;
        }

        public void init()
        {
            ContentManager Content = ContentLoader.getInstance().contentM;
            font = Content.Load<SpriteFont>("Font");
        }
    }
}
