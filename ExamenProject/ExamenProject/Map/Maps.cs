using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.ComponentModel;
using ExamenProject.Nature;
using System.Diagnostics;

namespace ExamenProject.Map
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
            for (int l = 0; l < maps[level].GetLength(0); l++)
            {
                for (int c = 0; c < maps[level].GetLength(1); c++)
                {
                    int width = 100; int height = 100;
                    Vector2 pos = new Vector2(c * width, l * height);
                    Vector2 pos2 = pos - new Vector2(10, 10);
                    Rectangle rec = new Rectangle(c * width, l * height, width, height);
                    int number = maps[level][l, c];
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

        public static void CreateBuildings(List<Building> buildings, int level, Texture2D textureC, Texture2D textureH, Texture2D textureT, GraphicsDevice graphicsD)
        {
            switch (level)
            {
                case 0:
                    BuildingsLevel1(buildings, textureC, textureH, textureT, graphicsD);
                    break;
            }
        }

        public static void CreateTrees(List<Tree> tr, int level, GraphicsDevice gd)
        {
            switch (level)
            {
                case 0:
                    TreesLevel1(tr, gd);
                    break;
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

        public static void BuildingsLevel1(List<Building> bd, Texture2D tC, Texture2D tH, Texture2D tT, GraphicsDevice gd)
        {
            bd.Add(new Building(new Rectangle(590, 20, 320, 256), tC, "castle", gd));
            bd.Add(new Building(new Rectangle(484, 20, 128, 256), tT, "tower", gd));
            bd.Add(new Building(new Rectangle(888, 20, 128, 256), tT, "tower", gd));
            bd.Add(new Building(new Rectangle(279, 300, 128, 192), tH, "house", gd));
            bd.Add(new Building(new Rectangle(686, 300, 128, 192), tH, "house", gd));
            bd.Add(new Building(new Rectangle(1093, 300, 128, 192), tH, "house", gd));
        }

        public static void TreesLevel1(List<Tree> tr, GraphicsDevice gd)
        {
            //Top side trees
            for (int i = -72; i < 1611; i += 111)
            {
                for (int j = -2; j <= 0; j++)
                {
                    tr.Add(new Tree(new(i, 78 * j), gd));
                }
            }

            //Left side trees
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tr.Add(new Tree(new(-72 + 111 * j, 78 * i), gd));
                }
            }

            //Right side trees
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tr.Add(new Tree(new(1260 + 111 * j, 78 * i), gd));
                }
            }

            //Bottom side trees
            for (int i = -72; i < 1611; i += 111)
            {
                for (int j = -2; j <= 0; j++)
                {
                    tr.Add(new Tree(new(i, 78 * (11 + j)), gd));
                }
            }
        }
    }
}
