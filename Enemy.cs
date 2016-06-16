using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Diagnostics;

namespace Geo_The_Hunter
{
    class Enemy
    {

        private Player playerRef = null;
        private Game gameRef = null;
        public List<Tuple<Vector2, Texture2D>> Enemies = new List<Tuple<Vector2, Texture2D>>();
        private List<Texture2D> enemyTextures = new List<Texture2D>();
        private SpriteFont enemyCountFont;
        private int enemyCount = 0;
        private long timeSinceSpawn = 0;

        public List<Rectangle> enemyCollision = new List<Rectangle>();

        double time = 0;

        private List<Vector2> enemySpawns = new List<Vector2>()
        {
            new Vector2(0, 310),
            new Vector2(1650, 310),
            new Vector2(825, 0),
            new Vector2(825, 620)
        };

        public Enemy(Player player, Game game)
        {
            gameRef = game;
            playerRef = player;
        }


        public void LoadContent()
        {
            enemyTextures.Add(gameRef.Content.Load<Texture2D>("Right"));

            enemyCountFont = gameRef.Content.Load<SpriteFont>("enemyCount");
        }

        public void SpawnEnemy()
        {
            if ((Stopwatch.GetTimestamp() - timeSinceSpawn) > (9999999 / (Enemies.Count + 1)) && Enemies.Count < 70 || timeSinceSpawn == 0)
            {
                timeSinceSpawn = Stopwatch.GetTimestamp();
                Random randomTexture = new Random();
                int index = randomTexture.Next(1, 5);
                Random randomPos = new Random();
                int pos = randomPos.Next(0, 4);

                Enemies.Add(Tuple.Create<Vector2, Texture2D>(enemySpawns[pos], enemyTextures[0]));
                enemyCollision.Add(new Rectangle((int)Enemies[Enemies.Count - 1].Item1.X, (int)Enemies[Enemies.Count - 1].Item1.Y, enemyTextures[0].Width, enemyTextures[0].Height));
                
            }
        }

        public void Update(GameTime gameTime)
        {
            SpawnEnemy();
            Vector2 playerPosition = playerRef.playerPosition;
            time = gameTime.TotalGameTime.Seconds;
            for(int i = 0; i < Enemies.Count; i++)
            {
                float finalX = Enemies[i].Item1.X - playerPosition.X;
                float finalY = Enemies[i].Item1.Y - playerPosition.Y;
                //Console.WriteLine("finalX {0} finalY {1}", finalX, finalY);
                if(finalX > 0)
                {
                    Vector2 newVec = new Vector2(Enemies[i].Item1.X - 1, Enemies[i].Item1.Y);
                    
                    Enemies[i] = new Tuple<Vector2, Texture2D>(newVec, Enemies[i].Item2);
                }
                else if(finalX < 0)
                {
                    Vector2 newVec = new Vector2(Enemies[i].Item1.X + 1, Enemies[i].Item1.Y);

                    Enemies[i] = new Tuple<Vector2, Texture2D>(newVec, Enemies[i].Item2);
                }

                if(finalY > 0)
                {
                    Vector2 newVec = new Vector2(Enemies[i].Item1.X, Enemies[i].Item1.Y - 1 );

                    Enemies[i] = new Tuple<Vector2, Texture2D>(newVec, Enemies[i].Item2);

                }
                else if(finalY < 0)
                {
                    Vector2 newVec = new Vector2(Enemies[i].Item1.X, Enemies[i].Item1.Y + 1);

                    Enemies[i] = new Tuple<Vector2, Texture2D>(newVec, Enemies[i].Item2);
                }

                enemyCollision[i] = new Rectangle((int)Enemies[i].Item1.X, (int)Enemies[i].Item1.Y, Enemies[i].Item2.Width, Enemies[i].Item2.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < Enemies.Count; i++)
            {
                spriteBatch.Draw(Enemies[i].Item2, Enemies[i].Item1, Color.White);
            }
            string countString = "Enemies: " + Enemies.Count;
            spriteBatch.DrawString(enemyCountFont, countString, new Vector2(1550, 10), Color.White);
        }
    }
}
