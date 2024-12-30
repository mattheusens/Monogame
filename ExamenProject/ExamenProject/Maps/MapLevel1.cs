using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ExamenProject.Map;
using ExamenProject.Map.Nature;

namespace ExamenProject.Maps
{
    internal class MapLevel1
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
        private static void CreateBuildings(List<Building> bds)
        {
            bds.Add(new Building(new Rectangle(590, 20, 320, 256), "castle"));
            bds.Add(new Building(new Rectangle(484, 20, 128, 256), "tower"));
            bds.Add(new Building(new Rectangle(888, 20, 128, 256), "tower"));
            bds.Add(new Building(new Rectangle(279, 300, 128, 192), "house"));
            bds.Add(new Building(new Rectangle(686, 300, 128, 192), "house"));
            bds.Add(new Building(new Rectangle(1093, 300, 128, 192), "house"));
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

            //Bottom side trees
            for (int i = -72; i < 1611; i += 111)
            {
                for (int j = -2; j <= 0; j++)
                {
                    trs.Add(new Tree(new(i, 78 * (11 + j))));
                }
            }
        }
    }
}
