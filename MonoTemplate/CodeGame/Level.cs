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

        const int GOUP = 6;
        const int GODOWN = 7;
        const int GOLEFT = 8;
        const int GORIGHT = 9;
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
        private Event tileModder;

        internal void ChangeDirection(Sprite actor)
        {
            Point tile = this.Location(actor);
            int tileType = GetGraphic(tile);

            switch (tileType)
            {
                case GORIGHT:
                    if (!(actor.Velocity.X > 0))
                    {
                        this.SetActorAtCentre(actor);
                        actor.Velocity = new Vector3(80, 0, 0);
                    }
                    break;
                case GODOWN:
                    if (!(actor.Velocity.Y > 0))
                    {
                        this.SetActorAtCentre(actor);
                        actor.Velocity = new Vector3(0, 80, 0);
                    }
                    break;
                case GOLEFT:
                    if (!(actor.Velocity.X < 0))
                    {
                        this.SetActorAtCentre(actor);
                        actor.Velocity = new Vector3(-80, 0, 0);
                    }
                    break;
                case GOUP:
                    if (!(actor.Velocity.Y < 0))
                    {
                        this.SetActorAtCentre(actor);
                        actor.Velocity = new Vector3(0, -80, 0);
                    }
                    break;
            }
 
        }

        internal bool DirectionTile(Sprite actor)
        {
            Point tile = this.Location(actor);
            int tileType = GetGraphic(tile);
            return tileType >= GOUP || tileType <= GORIGHT;
        }

        public Level(string debugName) : base(debugName)
        {
            //800x600
            GM.tileMapM.Add(this);
            this.SetMap(40, 40, levelMap);

            CreateTiles();

            GM.eventM.AddEvent(tileModder = new Event(GM.eventM.MaximumRate, "TileModder", ProcessTiles));
            
        }

        public override void CleanUp()
        {
            GM.eventM.Remove(tileModder);

            base.CleanUp();
        }
        Point clickTile;
        private int chosen;

        private void ProcessTiles()
        {
            
            if (GM.inputM.MouseLeftButtonPressed())
            {
                Vector2 mp = GM.inputM.MouseLocation;

                clickTile = this.Location(mp.X, mp.Y);

                this.Highlight(clickTile, Color.Silver, 1, 0.5f);
                int chosen = GetGraphic(clickTile);
            }
            
            switch (chosen)
            {
                case WALL:
                    if (GM.inputM.KeyPressed(Keys.T))
                    {
                        if (clickTile != null)
                        {
                            
                        }
                    }
                    break;
            }
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
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Orange),
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Orange),
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Orange),
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Orange),

            };
        }
    }
}