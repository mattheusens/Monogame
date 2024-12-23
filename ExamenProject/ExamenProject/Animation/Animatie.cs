﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ExamenProject.Animation
{
    internal class Animatie
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private Movement move;

        private double secondCounter = 0;
        private int counter;
        private int lowBoundaryCounter;
        private int highBoundaryCounter;
        public bool fighting = false;

        public Animatie(Movement move)
        {
            this.move = move;
            frames = new List<AnimationFrame>();
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

                if (counter >= highBoundaryCounter)
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
                lowBoundaryCounter = 24;
                highBoundaryCounter = 29;
            }
            else if (fighting && move.lastMove == "left")
            {
                lowBoundaryCounter = 30;
                highBoundaryCounter = 35;
            }
            else
            {
                if (move.moveRight || (move.moveUp || move.moveDown) && move.lastMove == "right")
                {
                    lowBoundaryCounter = 12;
                    highBoundaryCounter = 17;
                }
                else if (move.moveLeft || (move.moveUp || move.moveDown) && move.lastMove == "left")
                {
                    lowBoundaryCounter = 18;
                    highBoundaryCounter = 23;
                }
                else
                {
                    if (move.lastMove == "right")
                    {
                        lowBoundaryCounter = 0;
                        highBoundaryCounter = 5;
                    }
                    else
                    {
                        lowBoundaryCounter = 6;
                        highBoundaryCounter = 11;
                    }
                }
            }
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
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
        }
    }
}