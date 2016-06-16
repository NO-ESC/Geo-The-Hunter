using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;



namespace Geo_The_Hunter
{
    static class GameAudio
    {
        /*private static Game gameRef;

        // SoundEffect         - SoundEffect the actual SoundEffect
        // string              - The name of the song
        // int                 - Priority ID for being louder than other low priority sounds
        // bool                - Set the song looping or not
        // SoundEffectInstance - SoundEffectInstance used to control sounds  
          
        private static List<Tuple<SoundEffect, string, int, bool, SoundEffectInstance>> lSongs = 
                         new List<Tuple<SoundEffect, string, int, bool, SoundEffectInstance>>();

        static GameAudio()
        {

        }

        public static void Instance(Game game)
        {
            gameRef = game;
        }

        public static void LoadContent()
        {
            lSongs.Add(Tuple.Create<SoundEffect, string, int, bool, SoundEffectInstance>
                (gameRef.Content.Load<SoundEffect>("music"), "music", 0, false, null));

            // Last song added
            int index = lSongs.Count - 1;

            // Create an instance so we can manage the song
            var instance = lSongs[index].Item1.CreateInstance();
            lSongs[index] = new Tuple<SoundEffect, string, int, bool, SoundEffectInstance>
                (lSongs[index].Item1, lSongs[index].Item2, lSongs[index].Item3, lSongs[index].Item4, instance);
        }

        public static int GetAudio(string name)
        {
            return lSongs.FindIndex(x => x.Item2.Equals(name));
        }
        */
        /*
         * Background/Ambience music - Priority 0
         * Sound Effects - Priority 1
         * Voices? - Priority 2
         * 
         * */
        /*
        public static void Priority(int index, int p)
        {
            lSongs[index] = new Tuple<SoundEffect, string, int, bool, SoundEffectInstance>
                (lSongs[index].Item1, lSongs[index].Item2, p, lSongs[index].Item4, lSongs[index].Item5);
        }

        public static void SetLooping(int index, bool flag)
        {
            lSongs[index].Item5.IsLooped = flag;
        }

        public static void PlaySong(int index)
        {
            if(lSongs[index].Item5.State == SoundState.Stopped)
            {
                lSongs[index].Item5.Play();
            }
            else if(lSongs[index].Item5.State == SoundState.Paused)
            {
                lSongs[index].Item5.Resume();
            }

        }

        public static void PauseSong(int index)
        {
            lSongs[index].Item5.Pause();
        }

        public static void StopSong(int index)
        {
            lSongs[index].Item5.Stop();
        }
         */
    }
}
