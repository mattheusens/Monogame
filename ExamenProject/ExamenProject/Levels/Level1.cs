using ExamenProject.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenProject.Characters;
using Microsoft.Xna.Framework.Content;
using ExamenProject.Map.Nature;
using ExamenProject.Map;
using ExamenProject.Loaders;
using System.Diagnostics;
using ExamenProject.Maps;
using ExamenProject.Screens;
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
        public override void init()
        {
            base.init();

            if (!gateOpen)
            {
                enemies.Add(new CloseEnemy(enemyTexture, new(200, 180), 300, hero.move));
                enemies.Add(new DistanceEnemy(enemyTexture, new(200, 180), 600, hero.move));
                enemies.Add(new RandomEnemy(enemyTexture, new(200, 180), 900, false));
                enemies.Add(new RandomEnemy(enemyTexture, new(200, 180), 1200, true));
                enemies.Add(new FightingEnemy(enemyTexture, new(200, 180), 1500, hero.move));
            }
            else RemoveTrees();

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
            level.setState(level.getLevel2());
            level.getState().init();
            hero.move.posY = -90;
        }
        public void goLastLevel()
        { 
            // Impossible
        }
    }
}
