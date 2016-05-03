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

        public static int CurrentMap { get; set; }

        public static Vector2 GetMapSize(int map)
        {
            return new Vector2(maps[map].Item1.Width, maps[map].Item1.Height);
        }

        public static void Draw(SpriteBatch batch)
        {
            if (CurrentMap != -1)
            {
                batch.Draw(maps[CurrentMap].Item1, destinationRectangle: new Rectangle(0, 0, maps[CurrentMap].Item1.Width, maps[CurrentMap].Item1.Height), color: Color.White);
            }
        }
    }
}
