using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Geo_The_Hunter
{
    class Player
    {

        private Texture2D playerSprite;
        private Vector2 playerPosition;
        private Game gameRef;
        private Camera cameraInstance;
        private GraphicsDeviceManager graphics;

        public Player(Game game, Camera cam, GraphicsDeviceManager gfx)
        {
            gameRef = game;
            cameraInstance = cam;
            graphics = gfx;
            playerPosition = new Vector2(0, 0);
        }

        public void LoadContent()
        {
            playerSprite = gameRef.Content.Load<Texture2D>("player");
        }

        public void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            cameraInstance.Origin = playerPosition;

            Vector2 mapSize = GameMap.GetMapSize(GameMap.CurrentMap);

            // Plus 5 pixels from edges to keep camera jumping out of bounds
            mapSize.X -= graphics.PreferredBackBufferWidth + 5;
            mapSize.Y -= graphics.PreferredBackBufferHeight + 5;

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (cameraInstance.Position.X < mapSize.X && !graphics.IsFullScreen
                    || cameraInstance.Position.X < mapSize.X && graphics.IsFullScreen)
                {
                    playerPosition += new Vector2(250, 0) * deltaTime;
                    cameraInstance.Origin = playerPosition;
                    cameraInstance.Position += new Vector2(250, 0) * deltaTime;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (cameraInstance.Position.X > 0)
                {
                    playerPosition -= new Vector2(250, 0) * deltaTime;
                    cameraInstance.Origin = playerPosition;
                    cameraInstance.Position -= new Vector2(250, 0) * deltaTime;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (cameraInstance.Position.Y < mapSize.Y && !graphics.IsFullScreen
                    || cameraInstance.Position.Y < mapSize.Y && graphics.IsFullScreen)
                {
                    playerPosition += new Vector2(0, 250) * deltaTime;
                    cameraInstance.Origin = playerPosition;
                    cameraInstance.Position += new Vector2(0, 250) * deltaTime;
                }
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (cameraInstance.Position.Y > 0)
                {
                    playerPosition -= new Vector2(0, 250) * deltaTime;
                    cameraInstance.Origin = playerPosition;
                    cameraInstance.Position -= new Vector2(0, 250) * deltaTime;
                }
            }
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(playerSprite, playerPosition, Color.White);
        }


    }
}
