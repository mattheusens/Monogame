using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ExamenProject.Map;
using ExamenProject.Map.Nature;

namespace ExamenProject.Maps
{
    internal class MapLevel2
    {
        public static int[,] LoadMap(List<Building> bds, List<Tree> trs)
        {
            CreateBuildings(bds);
            CreateTrees(trs);
            return CreateMap();
        }

        private static int[,] CreateMap()
        {
            return new int[,]
            {
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
            {5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
            {7,8,8,8,8,8,8,8,8,8,8,8,8,8,9},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            };
        }
        private static void CreateBuildings(List<Building> bds)
        {
            bds.Add(new Building(new Rectangle(170, 150, 192, 128), "cave"));
            bds.Add(new Building(new Rectangle(1120, 150, 192, 128), "cave"));
        }
        private static void CreateTrees(List<Tree> trs)
        {
            //Top side trees
            for (int i = -72; i < 1611; i += 111)
            {
                for (int j = -2; j <= 0; j++)
                {
                    trs.Add(new Tree(new(i, 78 * j)));
                }
            }

            for (int i = 0; i < 6; i++) trs.RemoveAt(trs.Count / 2 - 3);

            //Left side trees
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    trs.Add(new Tree(new(-72 + 111 * j, 78 * i)));
                }
            }

            //Right side trees
            for (int i = 1; i < 9; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    trs.Add(new Tree(new(1260 + 111 * j, 78 * i)));
                }
            }
        }
    }
}
