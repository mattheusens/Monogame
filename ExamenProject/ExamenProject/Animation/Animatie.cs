using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ExamenProject.Animation
{
    internal class Animatie
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private AnimationFrame idleFrame;
        private Movement move;

        private double secondCounter = 0;
        private int counter;
        private int lowBoundaryCounter;
        private int highBoundaryCounter;

        public Animatie(Movement move)
        {
            this.move = move;
            frames = new List<AnimationFrame>();
        }

        public void Update(GameTime gameTime)
        {
            ChooseFrames();
            if (counter < lowBoundaryCounter || highBoundaryCounter < counter)
                counter = lowBoundaryCounter;
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 15;
            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= highBoundaryCounter)
            {
                counter = lowBoundaryCounter;
            }
        }

        public void ChooseFrames()
        {
            if (move.moveDown)
            {
                lowBoundaryCounter = 0;
                highBoundaryCounter = 3;
            }
            else if (move.moveUp)
            {
                lowBoundaryCounter = 9;
                highBoundaryCounter = 12;
            }
            else if (move.moveLeft)
            {
                lowBoundaryCounter = 3;
                highBoundaryCounter = 6;
            }
            else if (move.moveRight)
            {
                lowBoundaryCounter = 6;
                highBoundaryCounter = 9;
            }
            else
            {
                lowBoundaryCounter = 1;
                highBoundaryCounter = 2;
            }
        }

        public void GetFramesFromTextureProperties (int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;
            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
            CurrentFrame = frames[0];
            idleFrame = frames[1];
        }
    }
}
