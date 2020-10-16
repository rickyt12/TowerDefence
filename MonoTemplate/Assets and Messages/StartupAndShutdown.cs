using System;
using System.IO;
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
using Template;
using Template.CodeTitle;

/// <summary>
/// container for all systems code
/// </summary>
namespace Template
{
    /// <summary>
    /// Contains the code that setsup and closes the system
    /// </summary>
    public partial class GM
    {
        /*************************************************
        ************ all code AFTER this line ***********
        *************************************************/

        internal static void LoadToTexture(ref Texture2D backTexture, string fileName)
        {

        }
        /// <summary>
        /// starts the game off with the title screen
        /// </summary>
        private void StartSystem()
        {
           // SetUIvalues();


            //start title setup in 1 second
            GM.eventM.DelayCall(1, delegate()
            {
                GM.ClearAllManagedObjects();
                active = new TitleSetup();
            });
        }

        /// <summary>
        /// Any code to save dat into files should go here
        /// </summary>
        private void ShutDown()
        {

        }

        /*************************************************
        ************ all code before this line ***********
        *************************************************/
    }
}