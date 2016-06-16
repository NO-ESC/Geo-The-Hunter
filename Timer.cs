using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Geo_The_Hunter
{

    class Timer
    {

        private static Game gameRef;
        private static SpriteFont timerFont;
        static double time;

        static Timer()
        {
        }

        public static void LoadContent()
        {
            timerFont = gameRef.Content.Load<SpriteFont>("Timer");
        }

        public static void Instance(Game game)
        {
            gameRef = game;
        }

        public static void Update(GameTime gameTime)
        {
            time = gameTime.TotalGameTime.Seconds;
        }
        
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(timerFont, "Time: " + time.ToString(), new Vector2(1550, 40), Color.White);
        }

    }
}
