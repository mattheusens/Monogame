using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ExamenProject
{
    internal class Maps
    {
        public static List<int[,]> maps { get; set; } = new();
        public static List<Rectangle> framesGrass = new();

        public static void MakeMaps()
        {
            maps.Add(map1);
        }

        public static void CreateBlocks(List<Block> blocks, int level, Texture2D texture1, Texture2D texture2)
        {
            blocks.Clear();
            GetFramesFromTextureProperties(texture2.Width, texture2.Height, 3, 3);
            for (int l = 0; l < Maps.maps[level].GetLength(0); l++)
            {
                for (int c = 0; c < Maps.maps[level].GetLength(1); c++)
                {
                    int width = 100; int height = 100;
                    Vector2 pos = new Vector2((c * width), (l * height));
                    Vector2 pos2 = pos - new Vector2(10, 10);
                    Rectangle rec = new Rectangle((c * width), (l * height), width, height);
                    int number = Maps.maps[level][l, c];
                    switch (number)
                    {
                        case 0:
                            blocks.Add(new Block(pos, rec, texture1, "Water"));
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            blocks.Add(new Block(pos2, framesGrass[number - 1], texture2, "Grass"));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;
            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    framesGrass.Add(new Rectangle(x, y, widthOfFrame, heightOfFrame));
                }
            }
        }

        private static int[,] map1 = new int[,]
        {
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},
        };
    }
}
