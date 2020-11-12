using Engine;

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

namespace Template.CodeGame
{
    internal class Level : TileMap
    {
        const int FLOOR = 0;
        const int WALL = 1; //enemies cannot pass
        const int TREE = 2; //cannot build towers on
        const int START = 3; //enemy spawn
        const int END = 4; //base enterance
        const int EXT = 5;

        const int UP = 6;
        const int DOWN = 7;
        const int LEFT = 8;
        const int RIGHT = 9;
        //redirect tiles for enemies




        private int[,] levelMap =
        {
            { 1, 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 5 },
            { 1, 9, 0, 0, 0, 0, 6, 1, 1, 1, 1, 1, 1, 9, 0, 0, 0, 0, 7, 2, 5 },
            { 1, 0, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 5 },
            { 2, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 0, 1, 5 },
            { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 2, 5 },
            { 1, 0, 1, 2, 7, 0, 0, 0, 8, 1, 1, 7, 0, 0, 0, 8, 1, 1, 0, 1, 5 },
            { 1, 0, 1, 1, 0, 1, 1, 2, 0, 1, 1, 0, 2, 1, 1, 0, 1, 1, 0, 1, 5 },
            { 2, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 2, 0, 1, 5 },
            { 2, 0, 1, 1, 0, 1, 2, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 5 },
            { 1, 0, 2, 1, 0, 1, 2, 1, 0, 2, 1, 0, 1, 1, 2, 0, 2, 1, 0, 1, 5 },
            { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 5 },
            { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 5 },
            { 1, 0, 1, 1, 0, 1, 1, 2, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 5 },
            { 1, 6, 0, 0, 8, 1, 1, 1, 6, 0, 0, 8, 1, 2, 1, 6, 0, 0, 8, 2, 5 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5 },
            { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },

        };
        public Level(string debugName) : base(debugName)
        {
            GM.tileMapM.Add(this);
            this.SetMap(40, 40, levelMap);

            CreateTiles();
        }

        private void CreateTiles()
        {
            this.MyTileList = new List<Tile>
                {
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Black),
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Green),
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Red),
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Blue),
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Gold),
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Gray),

            };
        }
    }
}