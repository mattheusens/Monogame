using ExamenProject.Characters;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ExamenProject.Animation
{
    internal class Animatie
    {
        public FrameHolder CurrentFrame { get; set; }
        public List<FrameHolder> frames = new();
        private Movement move;

        private double secondCounter = 0;
        private int counter;
        private int lowBoundaryCounter;
        private int highBoundaryCounter;
        public bool fighting = false;
        private int framesPerWidth; 

        public Animatie(Movement move, int framesPerWidth)
        {
            this.move = move;
            this.framesPerWidth = framesPerWidth;
        }

        public void Update(GameTime gameTime)
        {
            ChooseFrames();
            if(move.lastMove == "right")
            {
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

                if (counter > highBoundaryCounter)
                {
                    fighting = false;
                    counter = lowBoundaryCounter;
                }
            }
            else
            {
                if (counter < lowBoundaryCounter || highBoundaryCounter < counter)
                    counter = highBoundaryCounter;
                CurrentFrame = frames[counter];

                secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
                int fps = 15;
                if (secondCounter >= 1d / fps)
                {
                    counter--;
                    secondCounter = 0;
                }

                if (counter <= lowBoundaryCounter)
                {
                    fighting = false;
                    counter = highBoundaryCounter;
                }
            }
        }

        public void Fighting()
        {
            fighting = true;
        }

        public void ChooseFrames()
        {
            if (fighting && move.lastMove == "right")
            {
                lowBoundaryCounter = framesPerWidth * 4;
                highBoundaryCounter = framesPerWidth * 5 - 1;
            }
            else if (fighting && move.lastMove == "left")
            {
                lowBoundaryCounter = framesPerWidth * 5;
                highBoundaryCounter = framesPerWidth * 6 - 1;
            }
            else
            {
                if (move.moveRight || (move.moveUp || move.moveDown) && move.lastMove == "right")
                {
                    lowBoundaryCounter = framesPerWidth * 2;
                    highBoundaryCounter = framesPerWidth * 3 - 1;
                }
                else if (move.moveLeft || (move.moveUp || move.moveDown) && move.lastMove == "left")
                {
                    lowBoundaryCounter = framesPerWidth * 3;
                    highBoundaryCounter = framesPerWidth * 4 - 1;
                }
                else
                {
                    if (move.lastMove == "right")
                    {
                        lowBoundaryCounter = 0;
                        highBoundaryCounter = framesPerWidth * 1 - 1;
                    }
                    else
                    {
                        lowBoundaryCounter = framesPerWidth * 1;
                        highBoundaryCounter = framesPerWidth * 2 - 1;
                    }
                }
            }
        }

        public void setFirst()
        {
            CurrentFrame = frames[0];
        }
    }
}