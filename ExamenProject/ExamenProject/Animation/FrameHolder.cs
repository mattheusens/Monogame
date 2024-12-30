using Microsoft.Xna.Framework;

namespace ExamenProject.Animation
{
    internal class FrameHolder
    {

        public Rectangle SourceRectangle { get; set; }

        public FrameHolder(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }
}
