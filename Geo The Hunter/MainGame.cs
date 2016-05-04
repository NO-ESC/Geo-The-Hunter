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

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1024;
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
            menuManager = new Menu(this);
            GameAudio.Instance(this);
            player = new Player(this, mainCamera, graphics);
            menuManager.addDev("Brennan", "wanker");
            menuManager.addDev("Adam", "Another wanker");
            menuManager.addDev("Jack", "Team wanker");
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
            GameAudio.LoadContent();
            player.LoadContent();

            

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
            player.Update(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                GameMap.CurrentMap = GameMap.GetMap("map");
            else if (Keyboard.GetState().IsKeyDown(Keys.B))
                GameMap.CurrentMap = GameMap.GetMap("map2");
            // TODO: Add your update logic here

            int index = GameAudio.GetAudio("song");

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                GameAudio.PlaySong(index);
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
                GameAudio.PauseSong(index);
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
                GameAudio.StopSong(index);

            
                
            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var viewMatrix = mainCamera.GetViewMatrix();

            spriteBatch.Begin(transformMatrix: viewMatrix);

            GameMap.Draw(spriteBatch);
            player.Draw(spriteBatch);
            menuManager.showDevs(spriteBatch);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
