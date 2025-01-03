using System.Linq;
using Microsoft.Xna.Framework;
using ExamenProject.Interfaces;
using ExamenProject.Characters.Enemies;

namespace ExamenProject.Levels
{
    internal class Level1 : BaseLevel, ILevelState
    {
        bool gateOpen = false;

        public Level1(CurrentLevel level) : base(level)
        {
            this.level = level;
            levelNr = 1;
        }
        public override void initMap()
        {
            base.initMap();

            gateOpen = false;
        }
        public void initEnemies()
        {
            //enemies.Add(new CloseEnemy(enemyTexture, new(200, 180), 300, hero.move));
            //enemies.Add(new DistanceEnemy(enemyTexture, new(200, 180), 600, hero.move));
            //enemies.Add(new RandomEnemy(enemyTexture, new(200, 180), 900, false));
            //enemies.Add(new RandomEnemy(enemyTexture, new(200, 180), 100, true));
            enemies.Add(new FightingEnemy(enemyTexture, new(200, 180), 100, hero.move));
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!enemies.Any() && !gateOpen) RemoveTrees();
            if (hero.move.posY > 900) goNextLevel();
        }
        private void RemoveTrees()
        {
            for (int i = 0; i < 6; i++) trees.RemoveAt(98);
            gateOpen = true;
        }
        public void goNextLevel()
        {
            enemies.Clear();

            level.setState(level.getLevel2());
            level.getState().initMap();

            hero.move.posY = -90;
        }
        public void goLastLevel()
        { 
            // Impossible
        }
    }
}
