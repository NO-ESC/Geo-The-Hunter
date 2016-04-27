using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Geo_The_Hunter
{
    public class GameMap
    {
        protected Game gameRef;
        public GameMap(Game game)
        {
            gameRef = game;
        }

        private static List<Tuple<Texture2D, string>> maps = new List<Tuple<Texture2D, string>>();
        private int currentMap = -1;

        public int getMap(string mapName)
        {
            return maps.FindIndex(x => x.Item2.Equals(mapName));
        }
        public virtual void LoadContent()
        {
            maps.Add(Tuple.Create<Texture2D,string>(this.gameRef.Content.Load<Texture2D>("map"), "map"));
            maps.Add(Tuple.Create<Texture2D, string>(this.gameRef.Content.Load<Texture2D>("map2"), "map2"));
        }

        public void enableMap(int map)
        {
            currentMap = map;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (currentMap != -1)
            {
                batch.Begin();

                batch.Draw(maps[this.currentMap].Item1, destinationRectangle: new Rectangle(0, 0, maps[this.currentMap].Item1.Width, maps[this.currentMap].Item1.Height), color: Color.White);

                batch.End();
            }
        }
    }
}
