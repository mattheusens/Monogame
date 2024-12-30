using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using ExamenProject.Map.Nature;
using ExamenProject.Animation;
using ExamenProject.Loaders;

namespace ExamenProject.Map
{
    internal class Maps
    {
        public static List<int[,]> maps { get; set; } = new();
        private static List<FrameHolder> framesGrass = new();

        public static void MakeMaps()
        {
            maps.Add(map1);
        }

        public static void CreateMap(List<Block> bl, List<Building> bd, List<Tree> tr, int levelNr)
        {
            CreateBlocks(bl, levelNr);
            CreateBuildings(bd, levelNr);
            CreateTrees(tr, levelNr);
        }

        private static void CreateBlocks(List<Block> blocks, int level)
        {
            blocks.Clear();

            ContentManager Content = ContentLoader.getInstance().contentM;
            Texture2D grassTexture = Content.Load<Texture2D>("Background/Grass_Big");
            Texture2D waterTexture = Content.Load<Texture2D>("Background/Water");

            SpriteSplitter.GetFramesFromTexture(framesGrass, grassTexture.Width, grassTexture.Height, 3, 3);

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
                            blocks.Add(new Block(pos, rec, waterTexture, "Water"));
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
                            blocks.Add(new Block(pos2, framesGrass[number - 1].SourceRectangle, grassTexture, "Grass"));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void CreateBuildings(List<Building> buildings, int level)
        {
            buildings.Clear();
            switch (level)
            {
                case 0:
                    BuildingsLevel1(buildings);
                    break;
            }
        }

        private static void CreateTrees(List<Tree> trees, int level)
        {
            trees.Clear();
            switch (level)
            {
                case 0:
                    TreesLevel1(trees);
                    break;
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

        private static void BuildingsLevel1(List<Building> bd)
        {
            bd.Add(new Building(new Rectangle(590, 20, 320, 256), "castle"));
            bd.Add(new Building(new Rectangle(484, 20, 128, 256), "tower"));
            bd.Add(new Building(new Rectangle(888, 20, 128, 256), "tower"));
            bd.Add(new Building(new Rectangle(279, 300, 128, 192), "house"));
            bd.Add(new Building(new Rectangle(686, 300, 128, 192), "house"));
            bd.Add(new Building(new Rectangle(1093, 300, 128, 192), "house"));
        }

        private static void TreesLevel1(List<Tree> tr)
        {
            //Top side trees
            for (int i = -72; i < 1611; i += 111)
            {
                for (int j = -2; j <= 0; j++)
                {
                    tr.Add(new Tree(new(i, 78 * j)));
                }
            }

            //Left side trees
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tr.Add(new Tree(new(-72 + 111 * j, 78 * i)));
                }
            }

            //Right side trees
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tr.Add(new Tree(new(1260 + 111 * j, 78 * i)));
                }
            }

            //Bottom side trees
            for (int i = -72; i < 1611; i += 111)
            {
                for (int j = -2; j <= 0; j++)
                {
                    tr.Add(new Tree(new(i, 78 * (11 + j))));
                }
            }
        }
    }
}
