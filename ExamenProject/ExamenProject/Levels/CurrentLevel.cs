using ExamenProject.Characters;
using ExamenProject.Interfaces;
using ExamenProject.Map.Nature;
using ExamenProject.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject.Levels
{
    internal class CurrentLevel
    {
        ILevelState level1;
        ILevelState level2;
        ILevelState state;

        public Hero hero;
        public List<Enemy> enemies = new();
        public List<Character> characters = new();
        public List<Block> blocks = new();
        public List<Building> buildings = new();
        public List<Tree> trees = new();

        public CurrentLevel(Hero hero)
        {
            this.hero = hero;
            characters.Add(hero); 
            level1 = new Level1(this);
            level2 = new Level2(this);
            state = level1;

        }
        public void setState(ILevelState state)
        {
            this.state = state;
        }
        public ILevelState getState()
        {
            return state;
        }

        public ILevelState getLevel1()
        {
            return level1;
        }
        public ILevelState getLevel2()
        {
            return level2;
        }
    }
}
