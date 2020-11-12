using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//system threading in use for sleep method
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
        private int wave;
        private int balance;
        private int baseHP;
        /// running counters

        private int ib;
        /// total enemies of one type for the wave
        
        private int enemyHP;
        private int enemySpeed;
        private int enemyArmour;
        private int enemyReward;
        private int[,] enemyAtts;
        private int enemyType;
        private int e;
        /// enemy details (Types, Health, Speed, Armour, Reward)

        private bool passed;
        /// true when level 20 is beaten


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
            //array for enemy attributes

            enemyType = enemyAtts[e, 0];
            enemyHP = enemyAtts[e, 1];
            enemySpeed = enemyAtts[e, 2];
            enemyArmour = enemyAtts[e, 3];
            enemyReward = enemyAtts[e, 4];
            //assigned new variables (functioning as a column)
            //e determines tower type in reference


            
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
            GM.textM.Draw(FontBank.vector, "B 100   W 1   H 1000", 0, 600, TextAtt.BottomLeft);
            //counters for balance, wave, health

            //check for quit key
            if (GM.inputM.KeyPressed(Keys.Escape))
            {
                BackToTitle();
            }
            
            
        }

        private void WaveCheck()
        {
            if (wave < 3)
            {
                e = 1;
                for (int ib = 0; ib < (wave * 5); ib++)
                {
                    SpawnEnemy();
                }
            }
            else if (wave >= 3 && wave < 6)
            {
                e = 1;
                for (int ib = 0; ib < (wave * 6); ib++)
                {
                    SpawnEnemy();
                }
                Thread.Sleep(2500);
                e = 2;
                for (int ib = 0; ib < (wave); ib++)
                {
                    SpawnEnemy();
                }
            }
            else if (wave >= 6 && wave < 10)
            {
                e = 2;
                for (int ib = 0; ib < (wave); ib++)
                {
                    SpawnEnemy();
                }
                Thread.Sleep(2500);
                e = 3;
                for (int ib = 0; ib < (wave * 2); ib++)
                {
                    SpawnEnemy();
                }
            }
            else if (wave >= 10 && wave < 15)
            {
                e = 2;
                for (int ib = 0; ib < (wave - 3); ib++)
                {
                    SpawnEnemy();
                }
                Thread.Sleep(2500);
                e = 4;
                for (int ib = 0; ib < (wave - 9); ib++)
                {
                    SpawnEnemy();
                }
            }
            else if (wave == 15)
            {
                e = 1;
                for (int ib = 0; ib < 50; ib++)
                {
                    SpawnEnemy();
                }
            }
            else if (wave >= 16 && wave < 21)
            {
                e = 3;
                for (int ib = 0; ib < (wave - 10); ib++)
                {
                    SpawnEnemy();
                }
                Thread.Sleep(2500);
                e = 4;
                for (int ib = 0; ib < (wave - 13); ib++)
                {
                    SpawnEnemy();
                }
            }
            //preset first 20 waves of enemies
            //no type 5s
            else
            {
                passed = true;
                Random r = new Random();
                int genRand = r.Next(1, 4);
                e = genRand;
                for (int ib = 0; ib < (wave - 10); ib++)
                {
                    SpawnEnemy();
                }
                e = 5;
                for (int ib = 0; ib < (wave - 20); ib++)
                {
                    SpawnEnemy();
                }
            }
            //for any wave past 20, gradually increasing amount of type 5 enemies
            //additionally: gradually increasing amount of a random enemy type
        }

        private void BackToTitle()
        {
            //tidy up before moving to another mode
            GM.eventM.Remove(evLogic);
            GM.ClearAllManagedObjects();
            GM.active = new TitleSetup();
        }

        private void SpawnEnemy()
        {


        }
    }
}
