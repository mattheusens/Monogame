using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProject
{
    internal class Movement
    {
        public int speed;
        public int posX = 0;
        public int posY = 0;

        public bool moveUp = false;
        public bool moveDown = false;
        public bool moveLeft = false;
        public bool moveRight = false;
        public string lastMove = "right";

        //Movement for enemy
        public void FollowPlayer(Movement movePlayer)
        {
            if (movePlayer.posX >= posX){ //Player is rechts van enemy
                posX++;
                moveLeft = false;
                moveRight = true;
                lastMove = "right";
            }else{
                posX--;
                moveRight = false;
                moveLeft = true;
                lastMove = "left";
            }
            if (movePlayer.posY > posY){  //Player is onder enemy
                posY++;
                moveUp = false;
                moveDown = true;
            }else{
                moveDown = false;
                moveUp = true;
                posY--;
            }
        }

        //Movement for player
        public void MoveInputs()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                speed = 4;
            else
                speed = 2;

            if (Keyboard.GetState().IsKeyDown(Keys.Up)){
                posY -= speed;
                moveUp = true;
            }else moveUp = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)){
                posY += speed;
                moveDown = true;
            }else moveDown = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)){
                posX -= speed;
                moveLeft = true;
                lastMove = "left";
            }else moveLeft = false;
            if (Keyboard.GetState().IsKeyDown(Keys.Right)){
                posX += speed;
                moveRight = true;
                lastMove = "right";
            }else moveRight = false;
        } 

        public void MoveBoundaries(GraphicsDeviceManager graphics, Texture2D heroTexture)
        {
            if (graphics.PreferredBackBufferWidth - heroTexture.Width / 12 < posX)
                posX = graphics.PreferredBackBufferWidth - heroTexture.Width / 12;
            if (posX < 10)
                posX = 10;
            if (graphics.PreferredBackBufferHeight - heroTexture.Height / 8 < posY)
                posY = graphics.PreferredBackBufferHeight - heroTexture.Height / 8;
            if (posY < 10)
                posY = 10;
        }
    }
}
