using ExamenProject.Characters;
using ExamenProject.Interfaces;
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

        public CurrentLevel(Hero hero)
        {
            this.hero = hero;
            level1 = new Level1(this);
            level2 = new Level2();
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
