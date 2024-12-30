using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Loaders
{
    internal class ContentLoader
    {
        private static ContentLoader contentL = new ContentLoader();
        public ContentManager contentM;

        public static ContentLoader getInstance()
        {
            return contentL;
        }

        public void init(ContentManager ct)
        {
            contentM = ct;
        }
    }
}
