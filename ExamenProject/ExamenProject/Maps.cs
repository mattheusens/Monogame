using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ExamenProject
{
    internal class Maps
    {
        public static List<int[,]> maps { get; set; } = new();

        public static void MakeMaps()
        {
            maps.Add(map1);
        }

        public static void CreateBlocks(List<Block> blocks, int level, Texture2D texture1, Texture2D texture2)
        {
            blocks.Clear();
            for (int l = 0; l < Maps.maps[level].GetLength(0); l++)
            {
                for (int c = 0; c < Maps.maps[level].GetLength(1); c++)
                {
                    int width = 100; int height = 100;
                    Vector2 pos = new Vector2((c * width), (l * height));
                    Rectangle rec = new Rectangle((c * width), (l * height), width, height);
                    if (Maps.maps[level][l, c] == 0)
                    {
                        blocks.Add(new Block(pos, rec, texture2, "Water"));
                    }
                    else if (Maps.maps[level][l, c] == 1)
                    {
                        blocks.Add(new Block(pos, rec, texture1, "Grass"));
                    }
                }
            }
        }

        private static int[,] map1 = new int[,]
        {
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,0,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };
    }
}
