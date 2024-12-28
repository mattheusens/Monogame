using ExamenProject.Interfaces;
using ExamenProject.Nature;
using ExamenProject.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace ExamenProject
{
    internal class GraphicsDeviceLoader
    {
        private static GraphicsDeviceLoader GDL = new GraphicsDeviceLoader();
        public GraphicsDevice graphicsDevice;

        public static GraphicsDeviceLoader getInstance()
        {
            return GDL;
        }

        public void init(GraphicsDevice GD)
        {
            graphicsDevice = GD;
        }
    }
}
