﻿using ExamenProject.Animation;
using ExamenProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ExamenProject
{
    internal class Hero:IGameObject
    {
        private GraphicsDeviceManager graphics;

        private Texture2D heroTexture;
        private Texture2D hitboxTexture;

        private Animatie moveAnimation;
        private Movement move;

        private Vector2 position;
        private Vector2 positionHitbox;
        private Rectangle rectangle;
        private Rectangle rectangleHitbox;

        public Hero(Texture2D texture, GraphicsDeviceManager graphics, GraphicsDevice graphicsDevice)
        {
            this.graphics = graphics;
            this.heroTexture = texture;
            this.move = new Movement();

            moveAnimation = new Animatie(move);
            moveAnimation.GetFramesFromTextureProperties(texture.Width, texture.Height/4, 12, 2);

            move.posX = 50;//graphics.PreferredBackBufferWidth / 2 - texture.Width / 24;
            move.posY = 50;//graphics.PreferredBackBufferHeight / 2 - texture.Height / 16;
            position = new Vector2(move.posX, move.posY);

            hitboxTexture = new Texture2D(graphicsDevice, 1, 1);
            hitboxTexture.SetData(new[] { Color.White });
            positionHitbox = new Vector2(move.posX, move.posY);
        }

        public void Update(GameTime gameTime)
        {
            moveAnimation.Update(gameTime);
            Fighting();
            Move();
        }

        public void Fighting()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            rectangle = moveAnimation.CurrentFrame.SourceRectangle;
            rectangleHitbox = new Rectangle((int)position.X, (int)position.Y, rectangle.Width/2, rectangle.Height/2);

            spriteBatch.Draw(hitboxTexture, positionHitbox, rectangleHitbox, Color.Red);
            spriteBatch.Draw(heroTexture, position, rectangle, Color.White);
        }

        public void Move()
        {
            move.MoveInputs();
            move.MoveBoundaries(graphics, heroTexture);

            position = new Vector2(move.posX, move.posY);
            positionHitbox = new Vector2(move.posX + rectangle.Width/4 , move.posY + rectangle.Height/4);
        }
    }
}