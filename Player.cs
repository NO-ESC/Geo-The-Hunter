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
        enum PlayerState
        {
            PLAYER_STATE_IDLE = 1,
            PLAYER_STATE_RUNNING_LEFT = 2,
            PLAYER_STATE_RUNNING_RIGHT = 3,
            PLAYER_STATE_SHOOTING = 4,
            PLAYER_STATE_DEAD = 5
        }

        private PlayerState playerState = PlayerState.PLAYER_STATE_IDLE;

        enum FacingDirection
        {
            PLAYER_FACING_LEFT = 1,
            PLAYER_FACING_RIGHT = 2
        }

        private FacingDirection playerFacingDirection = FacingDirection.PLAYER_FACING_RIGHT;


        private Texture2D playerSprite;
        private Texture2D bullet;
        public Vector2 playerPosition { get; set; }
        private Game gameRef;
        private Camera cameraInstance;
        private GraphicsDeviceManager graphics;
        public List<Tuple<Vector2, bool>> projectiles = new List<Tuple<Vector2, bool>>();
        public List<Rectangle> projectileCollision = new List<Rectangle>();
        public Rectangle playerCollision;
        public double playerHealth = 100;

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
            bullet = gameRef.Content.Load<Texture2D>("bullet");

        }

        public void Shoot()
        {
            playerState = PlayerState.PLAYER_STATE_SHOOTING;
            Vector2 offset = new Vector2(0, 0);

            Vector2 origin = offset + playerPosition;

            if(playerFacingDirection == FacingDirection.PLAYER_FACING_RIGHT)
            {
                Vector2 projectileVel = new Vector2(origin.X + 5, origin.Y);
                projectiles.Add(Tuple.Create<Vector2, bool>(projectileVel, true));
                projectileCollision.Add(new Rectangle((int)projectiles[projectiles.Count -1].Item1.X, (int)projectiles[projectiles.Count -1].Item1.Y, bullet.Width, bullet.Height));
            }
            else
            {
                Vector2 projectileVel = new Vector2(origin.X, origin.Y + 5);
                projectiles.Add(Tuple.Create<Vector2, bool>(projectileVel, false));
                projectileCollision.Add(new Rectangle((int)projectiles[projectiles.Count - 1].Item1.X, (int)projectiles[projectiles.Count - 1].Item1.Y, bullet.Width, bullet.Height));
            }
        }

        public void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            playerCollision = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerSprite.Width + 50, playerSprite.Height + 50);

           // cameraInstance.Origin = playerPosition;

            Vector2 mapSize = GameMap.GetMapSize(GameMap.CurrentMap);

            // Plus 5 pixels from edges to keep camera jumping out of bounds
            mapSize.X -= graphics.PreferredBackBufferWidth + 10;
            mapSize.Y -= graphics.PreferredBackBufferHeight + 10;
            
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Shoot();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                    playerPosition += new Vector2(200, 0) * deltaTime;
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (playerPosition.X > 0)
                {
                    playerPosition -= new Vector2(200, 0) * deltaTime;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                playerPosition += new Vector2(0, 200) * deltaTime;
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                playerPosition -= new Vector2(0, 200) * deltaTime;
            }


        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(playerSprite, playerPosition, Color.White);

            for(int i = 0; i < projectiles.Count; i++)
            {
                if(projectiles[i].Item2)
                {
                    Vector2 newVel = new Vector2(projectiles[i].Item1.X + 5, projectiles[i].Item1.Y);
                    projectiles[i] = new Tuple<Vector2,bool>(newVel, true);
                    batch.Draw(bullet, projectiles[i].Item1, Color.White);
                }
                else
                {
                    Vector2 newVel = new Vector2(projectiles[i].Item1.X + 5, projectiles[i].Item1.Y);
                    projectiles[i] = new Tuple<Vector2, bool>(newVel, true);
                    batch.Draw(bullet, projectiles[i].Item1, Color.White);
                }
            }
        }


    }
}
