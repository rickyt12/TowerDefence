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
using Engine;//--engine import

/// <summary>
/// container for all systems code
/// </summary>
namespace Template
{
    /// <summary>
    /// holds all game assets and code to set up those assets
    /// </summary>
    public partial class GM
    {
        /*********** all code AFTER this line ***********/
        /// <summary>
        /// determines if game is being throttled (DEFAULT), 
        /// this links rendering to the refresh rate of the monitor (which prevents tearing)
        /// </summary>
        public static bool THROTTLE = true;
        /// <summary>
        /// how many times a second do you want the internal clocks and logic to operate at defaults to 100
        /// </summary>
        public static int UPDATE_RATE = 100;

        /// <summary>
        /// reference to screen size - smaller is better as this will be quickler
        /// </summary>
        public static Rectangle screenSize = new Rectangle(0, 0, 840,640);
        /*************************************************
        ************   STORAGE FOR TEXTURES    ***********
        *************************************************/
        /// <summary>
        /// holds the example sprite
        /// </summary>
        public static Texture2D txSprite;

        /// <summary>
        /// specifies what assets are being loaded
        /// </summary>
        public void StartPreLoader()
        {
            GM.gameState = GM.LOADING_ASSETS;
            //load image files and copy to textures for easy reference
            //tell preloader to load the following textures
            GM.loadM.AddTexture(delegate (Texture2D t, string f) { txSprite = t; }, "Sprites");
            
            //sound effects have to be explicitly loaded
            //call sound fruitpick form file friut
            GM.loadM.AddSoundEffect("fruitpick", "fruit");
            //call sound extra from file extra man
            GM.loadM.AddSoundEffect("extra", "extra man");
            //call sound shoot from file fire
            GM.loadM.AddSoundEffect("shoot", "fire");
            //call sound explosion from file explode
            GM.loadM.AddSoundEffect("explosion", "explode");

            //start background loader waiting 1 milliseconds between each load
            GM.loadM.Start(1);

        } // end StartPreLoader

    }
}
