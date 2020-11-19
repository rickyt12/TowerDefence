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
            new List<Wave>() {new Wave(0,0,1.1f,6), new Wave(1,10,1.1f,3) } ,//2
            new List<Wave>() {new Wave(0,0,1.1f,12), new Wave(1,15,1.1f,6) } ,//3
            new List<Wave>() {new Wave(1,0,1.1f,12) } ,//4
            new List<Wave>() {new Wave(2,3,1.5f,4) } ,//5
            new List<Wave>() {new Wave(1,0,1.1f,5), new Wave(2,10,1.2f,6) } ,//6
            new List<Wave>() {new Wave(1,0,1.1f,10), new Wave(2,13,1.1f,10) } ,//7
            new List<Wave>() {new Wave(1,0,1.1f,5), new Wave(2,8,1.2f,5), new Wave(1,14,1.1f,5) } ,//8
            new List<Wave>() {new Wave(2,0,2f,20) } ,//9
            new List<Wave>() {new Wave(3,3,1.3f,2) } ,//10
            new List<Wave>() {new Wave(1,0,1.1f,3), new Wave(0,5,1.1f,9), new Wave(3,15,1.3f,1) } ,//11
            new List<Wave>() {new Wave(2,0,1.1f,5), new Wave(3,7,1.2f,3) } ,//12
            new List<Wave>() {new Wave(0,0,1.1f,25) } ,//13
            new List<Wave>() {new Wave(0,0,1f,9), new Wave(1,10,1f,9), new Wave(2,20,1f,9), new Wave(3,30,1f,9) } ,//14
            new List<Wave>() {new Wave(0,0,1f,10), new Wave(4,15,1f,1) } ,//15
            new List<Wave>() {new Wave(4,3,5f,3) } ,//16
        };


        public SpawnSystem(Level t, int wave)
        {
            this.t = t;

            for (int i = 0; i < wavepatterns[wave].Count; i++)
            {
                new GenWave(wavepatterns[wave][i], t);
            }


        }
    }
}