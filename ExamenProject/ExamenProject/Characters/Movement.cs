using System;
using Microsoft.Xna.Framework.Input;

namespace ExamenProject.Characters
{
    internal class Movement
    {
        public int speed;
        public int posX;
        public int posY;

        public bool moveUp = false;
        public bool moveDown = false;
        public bool moveLeft = false;
        public bool moveRight = false;
        public string lastMove = "right";

        public Movement(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        //Movement for enemy
        public void FollowPlayer(Movement movePlayer)
        {   
            if (movePlayer.posX - 60 >= posX)
            { //Player is rechts van enemy
                posX++;
                moveLeft = false;
                moveRight = true;
            }
            else if (movePlayer.posX + 60 <= posX)
            {
                posX--;
                moveRight = false;
                moveLeft = true;
            }

            if (movePlayer.posY > posY)
            { //Player is onder enemy
                posY++;
                moveUp = false;
                moveDown = true;
            }
            else if (movePlayer.posY < posY)
            {
                moveDown = false;
                moveUp = true;
                posY--;
            }

            if (movePlayer.posX >= posX) lastMove = "right";
            else if (movePlayer.posX <= posX) lastMove = "left";
        }

        public void FollowDistancePlayer(Movement movePlayer)
        {
            if (movePlayer.posX - 150 >= posX)
            { //Player is rechts van enemy
                posX++;
                moveLeft = false;
                moveRight = true;
                lastMove = "right";
            }
            else if (movePlayer.posX + 150 <= posX)
            {
                posX--;
                moveRight = false;
                moveLeft = true;
                lastMove = "left";
            }

            if (movePlayer.posY + 150 > posY)
            { //Player is onder enemy
                posY++;
                moveUp = false;
                moveDown = true;
            }
            else if (movePlayer.posY - 150 < posY)
            {
                moveDown = false;
                moveUp = true;
                posY--;
            }
        }

        Random rng = new Random();
        int counter = 0;
        int randomNr = 0;

        public void Random()
        {
            if (counter == 0) randomNr = rng.Next(1, 5);
            counter++;
            if (counter == 20) counter = 0;

            switch (randomNr)
            {
                case 1:
                    moveRight = true;
                    moveLeft = false;
                    lastMove = "right";
                    posX++;
                    break;
                case 2:
                    moveRight = false;
                    moveLeft = true;
                    lastMove = "left";
                    posX--;
                    break;
                case 3:
                    moveUp = false;
                    moveDown = true;
                    posY++;
                    break;
                case 4:
                    moveUp = true;
                    moveDown = false;
                    posY--;
                    break;
            }
        }

        //Movement for player
        public void MoveInputs()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                speed = 4;
            else
                speed = 2;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                posY -= speed;
                moveUp = true;
            }
            else moveUp = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                posY += speed;
                moveDown = true;
            }
            else moveDown = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                posX -= speed;
                moveLeft = true;
                lastMove = "left";
            }
            else moveLeft = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                posX += speed;
                moveRight = true;
                lastMove = "right";
            }
            else moveRight = false;
        }
    }
}
