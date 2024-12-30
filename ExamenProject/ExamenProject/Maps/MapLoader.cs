using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ExamenProject.Loaders;
using ExamenProject.Animation;
using ExamenProject.Map;
using ExamenProject.Map.Nature;

namespace ExamenProject.Maps
{
    class MapLoader
    {
        private static MapLevel1 ML1;
        private MapLoader()
        {
            ML1 = new MapLevel1();
        }
        public static void LoadMap(int levelNr, List<Block> bls, List<Building> bds, List<Tree> trs)
        {
            bls.Clear();
            bds.Clear();
            trs.Clear();

            int[,] map = new int[0, 0];
            switch (levelNr)
            {
                case 1:
                    map = MapLevel1.LoadMap(bds, trs);
                    break;
                case 2:
                    map = MapLevel2.LoadMap(bds, trs);
                    break;
            }
            CreateBlocks(bls, map);
        }


        private static List<FrameHolder> framesGrass = new();
        private static void CreateBlocks(List<Block> bls, int[,] map)
        {
            ContentManager Content = ContentLoader.getInstance().contentM;
            Texture2D grassTexture = Content.Load<Texture2D>("Background/Grass_Big");
            Texture2D waterTexture = Content.Load<Texture2D>("Background/Water");

            SpriteSplitter.GetFramesFromTexture(framesGrass, grassTexture.Width, grassTexture.Height, 3, 3);

            for (int l = 0; l < map.GetLength(0); l++)
            {
                for (int c = 0; c < map.GetLength(1); c++)
                {
                    int width = 100; int height = 100;
                    Vector2 pos = new Vector2(c * width, l * height);
                    Vector2 pos2 = pos - new Vector2(10, 10);
                    Rectangle rec = new Rectangle(c * width, l * height, width, height);
                    int number = map[l, c];
                    switch (number)
                    {
                        case 0:
                            bls.Add(new Block(pos, rec, waterTexture, "Water"));
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
                            bls.Add(new Block(pos2, framesGrass[number - 1].SourceRectangle, grassTexture, "Grass"));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
