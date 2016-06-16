using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Geo_The_Hunter
{
    class Editor
    {
        static Game gameRef;

        private static int currentSelected;
        private static List<Texture2D> assets = new List<Texture2D>();
        private static List<Tuple<Texture2D, int, int>> gameObjects = new List<Tuple<Texture2D, int, int>>();

        static Editor()
        {

        }

        public static void Initialize(Game game)
        {
            gameRef = game;
            currentSelected = 0;
        }

        public static void LoadContent()
        {
            assets.Add(gameRef.Content.Load<Texture2D>("player"));
        }
        public static void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if(keyboard.IsKeyDown(Keys.NumPad0))
            {
                // Select a different object to place
            }

            if(mouse.LeftButton == ButtonState.Pressed)
            {
                int x = mouse.X;
                int y = mouse.Y;

                //gameObjects.Add(Tuple.Create<Texture2D, int, int>(assets[0], x, y));
            }

        }

        public static void Draw(SpriteBatch batch)
        {
            for(int i = 0; i < gameObjects.Count; i++)
            {
                batch.Draw(gameObjects[i].Item1, new Vector2(gameObjects[i].Item2, gameObjects[i].Item3));
            }
        }
    }
}
