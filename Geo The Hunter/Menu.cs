using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Geo_The_Hunter
{
    class Menu
    {

        protected Game gameRef;
        private List<Tuple<string, string>> devs = new List<Tuple<string, string>>();
        private SpriteFont creditFont;
        float last_y = 0.0f;

        public Menu(Game game)
        {
            gameRef = game;
        }

        public void LoadContent()
        {
            creditFont = this.gameRef.Content.Load<SpriteFont>("creditFont");

        }

        public void Update(GameTime gameTime)
        {
            //GameMap.EnableMap(GameMap.GetMap("map"));
            Console.WriteLine("THIS HAS HAPPENED!!");
        }
        public void addDev(string name, string position)
        {
            devs.Add(new Tuple<string, string>(name, position));
        }

        public void showDevs(SpriteBatch batch)
        {
            batch.Begin();

            for (int i = 0; i < devs.Count; i++)
            {
                batch.DrawString(creditFont, devs[i].Item1 + "  - " + devs[i].Item2, new Vector2(960, i*50+last_y), Color.White);
                last_y += 0.1f;
            }

            batch.End();
        }

    }
}
