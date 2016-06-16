using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Geo_The_Hunter
{
    class Menu
    {
        enum MenuStates
        {
            MAIN_MENU = 1,
            MENU_CREDITS = 2
        }

        private MenuStates menuState = MenuStates.MAIN_MENU;
        protected Game gameRef;
        private List<Tuple<string, string>> devs = new List<Tuple<string, string>>();
        private SpriteFont Font;
        private List<Vector2> menuButtons = new List<Vector2>();
        Texture2D mainMenu;
        Texture2D button;
        float last_y = 0.0f;

        public Menu(Game game)
        {
            gameRef = game;
        }

        public void LoadContent()
        {
            Font = this.gameRef.Content.Load<SpriteFont>("creditFont");
            button = gameRef.Content.Load<Texture2D>("menubutton");

            mainMenu = gameRef.Content.Load<Texture2D>("mainmenu");
            menuButtons.Add(new Vector2(250, 98));
            menuButtons.Add(new Vector2(1200, 98));
        }

        public void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                menuState = MenuStates.MENU_CREDITS;
            }
        }
        public void addDev(string name, string position)
        {
            devs.Add(new Tuple<string, string>(name, position));
        }

        public void showDevs(SpriteBatch batch)
        {

            if(menuState == MenuStates.MENU_CREDITS)
            {
                batch.DrawString(Font, "Press Y to go back", new Vector2(10, 10), Color.White);
                for (int i = 0; i < devs.Count; i++)
                {
                    batch.DrawString(Font, devs[i].Item1 + "  - " + devs[i].Item2, new Vector2(700, i * 100 + last_y), Color.White, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.None, 0.0f);
                    last_y += 0.1f;
                }
            }


            if(menuState == MenuStates.MAIN_MENU)
            {
                batch.Draw(mainMenu, new Vector2(0, 0), Color.White);
                batch.DrawString(Font, "Press start button to start the game", new Vector2(750, 470), Color.White);
                batch.DrawString(Font, "Press the A button to see credits", new Vector2(755, 490), Color.White);
                // Another button to show control layout?
            }

        }

    }
}
