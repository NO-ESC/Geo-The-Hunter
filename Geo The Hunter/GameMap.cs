using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Geo_The_Hunter
{
    static class GameMap
    {
        private static Game gameRef;
        static GameMap()
        {
        }

        private static List<Tuple<Texture2D, string>> maps = new List<Tuple<Texture2D, string>>();
        private static int currentMap = -1;

        public static void Instance(Game game)
        {
            gameRef = game;
        }

        public static int GetMap(string mapName)
        {
            return maps.FindIndex(x => x.Item2.Equals(mapName));
        }
        public static void LoadContent()
        {
            maps.Add(Tuple.Create<Texture2D,string>(gameRef.Content.Load<Texture2D>("map"), "map"));
            maps.Add(Tuple.Create<Texture2D, string>(gameRef.Content.Load<Texture2D>("map2"), "map2"));
        }

        public static void EnableMap(int map)
        {
            currentMap = map;
        }

        public static void Draw(SpriteBatch batch)
        {
            if (currentMap != -1)
            {
                batch.Begin();

                batch.Draw(maps[currentMap].Item1, destinationRectangle: new Rectangle(0, 0, maps[currentMap].Item1.Width, maps[currentMap].Item1.Height), color: Color.White);

                batch.End();
            }
        }
    }
}
