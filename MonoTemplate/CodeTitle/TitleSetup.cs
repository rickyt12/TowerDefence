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
using Template.CodeGame;

namespace Template.CodeTitle
{
    /// <summary>
    /// 
    /// </summary>
    public class TitleSetup : IGameMode
    {

        /// hey its ricky
        /// <summary>
        /// reference to logic event
        /// </summary>
        private Event evLogic;
        private Level t;

        //private MouseManager mouse;

        /// <summary>
        /// implements interface property using get form
        /// to set the mode text
        /// </summary>
        public string Description { get { return "Title Mode"; } }

        /// <summary>
        /// constructor startpoint for mode create initial actions here
        /// </summary>
        public TitleSetup() 
        {
            GM.engineM.DebugDisplay = Debug.version;
            GM.engineM.ScreenColour = Color.Black;
                        
            //setup an event to check for logic every frame
            GM.eventM.AddEvent(evLogic = new Event(GM.eventM.MaximumRate, "container logic", Logic));
        }


        /// <summary>
        /// general logic loop for mode
        /// any general non object specific stuff should be performed here
        /// </summary>
        private void Logic()
        {
            //dynamic text needs to be repeatidly drawn onto the screen
            GM.textM.Draw(FontBank.mappy, "TITLE SCREEN~press 1 to start game~ESC to quit", GM.screenSize.Center.X, GM.screenSize.Center.Y, TextAtt.Centred);


            //launch game mode
            if (GM.inputM.KeyPressed(Keys.D1))
            {
                StartGame();
            }

            //check for quit key
            if (GM.inputM.KeyPressed(Keys.Escape))
            {
                GM.eventM.Remove(evLogic);
                GM.ClearAllManagedObjects();
                GM.CloseSystem();
            }

        }

        private void StartGame()
        {
            //tidy up before moving to another mode
            GM.eventM.Remove(evLogic);
            GM.ClearAllManagedObjects();
            GM.active = new GameSetup();
        }
    }
}
