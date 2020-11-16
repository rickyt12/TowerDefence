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
namespace Template.CodeGame
{
    internal class GenWave
    {
        private Wave wave;
        private int Tally;
        private Event evSpawner;

        public GenWave(Wave wave)
        {
            this.wave = wave;
            this.Tally = 0;
            GM.eventM.DelayCall(wave.start, StartSpawn);
        }

        private void StartSpawn()
        {
            GM.eventM.AddEvent(evSpawner = new Event(wave.interval, "generate " + wave.enemy, Spitout));
        }

        private void Spitout()
        {
            if (Tally < wave.total)
            {
                Tally++;
                new MovingEnemy(new Vector2(540, 20), new Vector2(0, 40));

            }
            else
                GM.eventM.Remove(evSpawner);
        }
    }
}