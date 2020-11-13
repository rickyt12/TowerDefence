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
using Engine;

namespace Template.CodeGame
{

    class Wave
    {
        public int enemy { get; private set; }
        public float start { get; private set; }
        public float interval { get; private set; }
        public int total { get; private set; }

        public Wave(int enemynum, float starttime, float interval, int count)
        {
            this.enemy = enemynum;
            this.start = starttime;
            this.interval = interval;
            this.total = count;
        }
    }


    internal class SpawnSystem
    {
        private TileMap t;

        /// <summary>
        /// enemy num, start after, interval, count of enemy
        /// </summary>
        List<List<Wave>> wavepatterns = new List<List<Wave>>()
        {
            new List<Wave>() {new Wave(0,0,1.1f,5) } ,//0
            new List<Wave>() {new Wave(0,0,1.1f,5), new Wave(0,8,1.1f,10) } ,//1
            new List<Wave>() {new Wave(0,0,1.1f,6), new Wave(1,15,1.1f,3) } ,//2
            new List<Wave>() {new Wave(0,0,1.1f,12), new Wave(1,15,1.1f,6) } ,//3
            new List<Wave>() {new Wave(1,0,1.1f,12) } ,//4
            new List<Wave>() {new Wave(2,0,1.5f,4) } ,//5
            new List<Wave>() {new Wave(1,0,1.1f,5), new Wave(2,10,1.2f,6) } ,//6
            new List<Wave>() {new Wave(1,0,1.1f,10), new Wave(2,13,1.1f,10) } ,//7

        };


        public SpawnSystem(TileMap t, int wave)
        {
            this.t = t;

            for (int i = 0; i < wavepatterns[wave].Count; i++)
            {
                new GenWave(wavepatterns[wave][i]);
            }


        }
    }
}