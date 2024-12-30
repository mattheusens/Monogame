using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ExamenProject.Animation
{
    static class SpriteSplitter
    {
        public static void GetFramesFromTexture(List<FrameHolder> list, int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;
            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    list.Add(new FrameHolder(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }
    }
}
