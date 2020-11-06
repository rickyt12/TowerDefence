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
        const int WALL = 1;
        const int TREE = 2;
        const int START = 3;
        const int END = 4;


        private int[,] levelMap =
        {
            { 1, 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 2 },
            { 1, 0, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
            { 2, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 2 },
            { 1, 0, 1, 2, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 1, 1, 2, 0, 1, 1, 0, 2, 1, 1, 0, 1, 1, 0, 1 },
            { 2, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 2, 0, 1 },
            { 2, 0, 1, 1, 0, 1, 2, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 },
            { 1, 0, 2, 1, 0, 1, 2, 1, 0, 2, 1, 0, 1, 1, 2, 0, 2, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 },
            { 1, 0, 1, 1, 0, 1, 1, 2, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 2 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },

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
            };
        }
    }
}