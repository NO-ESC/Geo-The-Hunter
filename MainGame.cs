using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Geo_The_Hunter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu menuManager;
        Camera mainCamera;
        Player player;
        Enemy enemies;
        SpriteFont health;
        int score = 0;

        enum GameStates
        {
            GAME_STATE_MENU = 1,
            GAME_STATE_PLAYING = 2
        }

        GameStates gameState = GameStates.GAME_STATE_MENU;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 620;
            graphics.PreferredBackBufferWidth = 1650;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            mainCamera = new Camera(GraphicsDevice.Viewport);
            GameMap.Instance(this);
            Timer.Instance(this);
            menuManager = new Menu(this);
            //GameAudio.Instance(this);
            Editor.Initialize(this);
            player = new Player(this, mainCamera, graphics);
            menuManager.addDev("Brennan", "Programmer");
            menuManager.addDev("Adam", "Another wanker");
            menuManager.addDev("Jack", "Team wanker");

            enemies = new Enemy(player, this);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            GameMap.LoadContent();
            menuManager.LoadContent();
           // GameAudio.LoadContent();
            player.LoadContent();
            player.playerPosition = new Vector2(200, 200);
            Editor.LoadContent();
            enemies.LoadContent();
            Timer.LoadContent();

            health = Content.Load<SpriteFont>("health");

           // int music = GameAudio.GetAudio("music");

           // GameAudio.SetLooping(music, true);
          //  GameAudio.PlaySong(music);




            //GameAudio.PlaySong(index);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (Keyboard.GetState().IsKeyDown(Keys.B))
                gameState = GameStates.GAME_STATE_PLAYING;
            // TODO: Add your update logic here

            if(gameState == GameStates.GAME_STATE_PLAYING)
            {
                player.Update(gameTime);
                Editor.Update(gameTime);
                enemies.Update(gameTime);
                Timer.Update(gameTime);
            }
            else
            {
                menuManager.Update(gameTime);
            }


            for (int i = 0; i < player.projectileCollision.Count; i++)
            {
                for (int j = 0; j < enemies.enemyCollision.Count; j++)
                {
                    
                    if (player.projectileCollision[i].Intersects(enemies.enemyCollision[j]))
                    {
                        Console.WriteLine("this has worked");
                        enemies.Enemies.RemoveAt(j);
                        //player.projectiles.RemoveAt(i);
                        score++;
                    }
                }
            }

            for (int i = 0; i < enemies.Enemies.Count; i++)
            {
                if(player.playerCollision.Intersects(enemies.enemyCollision[i]))
                {
                    player.playerHealth -= 0.5;

                    if(player.playerHealth <= 0)
                    {
                        gameState = GameStates.GAME_STATE_MENU;
                        player.playerHealth = 100;
                        enemies.Enemies.Clear();
                    }
                }
            }


            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var viewMatrix = mainCamera.GetViewMatrix();

            spriteBatch.Begin(transformMatrix: viewMatrix);

            if(gameState == GameStates.GAME_STATE_PLAYING)
            {
                GameMap.Draw(spriteBatch);
                player.Draw(spriteBatch);
                Editor.Draw(spriteBatch);
                enemies.Draw(spriteBatch);
                Timer.Draw(spriteBatch);

                spriteBatch.DrawString(health, "Health " + player.playerHealth, new Vector2(10, 10), Color.White);
            }
            else
            {
                menuManager.showDevs(spriteBatch);
            }



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
