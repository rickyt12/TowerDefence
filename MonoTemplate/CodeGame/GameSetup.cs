using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
//--engine import
using Engine;
using Template.CodeTitle;

namespace Template.CodeGame
{
    class GameSetup : IGameMode
    {
        /// <summary>
        /// kkkkk
        /// reference to logic event
        /// </summary>
        private Event evLogic;


        /// <summary>
        /// implements interface property using short form
        /// to set the mode text
        /// </summary>        
        public string Description => "Game Mode";

        /// <summary>
        /// constructor startpoint for mode create initial actions here
        /// </summary>
        public GameSetup()
        {
            GM.engineM.DebugDisplay = Debug.none;
            GM.engineM.ScreenColour = Color.Purple;
            TileMap t = new Level("This is where the fun begins");

            new MovingEnemy(new Vector2(540, 20), new Vector2(0, 40));

            //setup an event to check for logic
            GM.eventM.AddEvent(evLogic = new Event(GM.eventM.MaximumRate, "container logic", Logic));
        }

        /// <summary>
        /// general logic loop for mode
        /// any general non object specific stuff should be performed here
        /// </summary>
        private void Logic()
        {
            //dynamic text needs to be repeatidly drawn onto the screen
            //GM.textM.Draw(FontBank.mappy, "GAME SCREEN~esc - back to title", GM.screenSize.Center.X, GM.screenSize.Center.Y, TextAtt.Centred);

            //check for quit key
            if (GM.inputM.KeyPressed(Keys.Escape))
            {
                BackToTitle();
            }
        }

        private void BackToTitle()
        {
            //tidy up before moving to another mode
            GM.eventM.Remove(evLogic);
            GM.ClearAllManagedObjects();
            GM.active = new TitleSetup();
        }
    }
}
