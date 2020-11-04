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
        private int enemyHP;
        private int enemySpeed;
        private int enemyArmour;
        private int enemyReward;
        private int[,] enemyAtts;
        private int enemyTypes;
        private int e;
        /// enemy details (Types, Health, Speed, Armour, Reward)


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
        private void Enemies()
        {
            int[,] enemyAtts = new int[,]
            {
                {1, 50, 50, 1, 5},
                {2, 100, 30, 2, 10},
                {3, 150, 80, 2, 20},
                {4, 350, 20, 3, 50},
                {5, 500, 50, 3, 100},
            };

            enemyTypes = enemyAtts[e, 0];
            enemyHP = enemyAtts[e, 1];
            enemySpeed = enemyAtts[e, 2];
            enemyArmour = enemyAtts[e, 3];
            enemyReward = enemyAtts[e, 4];


            
        }
        private void Towers()
        {
            int[,] towerAtts = new int[,]
            {
                {1, 60, 20, 80, 250, 1},
                {2, 120, 10, 100, 125, 2},
                {3, 200, 25, 200, 175, 2},
                {4, 360, 100, 400, 400, 3},
                {5, 600, 55, 300, 50, 3},
            };

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
