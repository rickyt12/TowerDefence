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

        const int TOWER = 10;




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

            GM.engineM.WorldSize(this.Area);

            LevelInfo();

            GM.eventM.AddEvent(tileModder = new Event(GM.eventM.MaximumRate, "TileModder", ProcessTiles));
            
        }

        public override void CleanUp()
        {
            GM.eventM.Remove(tileModder);

            base.CleanUp();
        }

        Point clickTile;
        private int chosen;
        private bool validselection;

        /*
         * 
                         if (GM.inputM.KeyPressed(Keys.F5))
                {
                    if (clickTile != null)
                    {
                        new Tower(this, this.PixelLocationCentre(clickTile));

                    }
                }
         */

        private void ProcessTiles()
        {
            

            if (GM.inputM.MouseLeftButtonPressed())
            {
                Vector2 mp = GM.inputM.MouseLocation;

                clickTile = this.Location(mp.X, mp.Y);
                int chosen = GetGraphic(clickTile);
                this.Highlight(clickTile, Color.Silver, 1, 0.5f);


                if (chosen == WALL)
                {
                    validselection = true;
                }
                else
                {
                    validselection = false;
                }
                


            }



            if (GM.inputM.KeyPressed(Keys.F6) && validselection)
            {
                validselection = false;
                new Tower(this, this.PixelLocationCentre(clickTile));
            }

                   
        }


        TextAtt taLevelInfo = new TextAtt(2.5f, 1, Color.Crimson, Align.bottom);
        //Sets text colour externally
        private void LevelInfo()
        {
            GM.textM.DrawAsSprites(FontBank.arcadePixel, "Wave   Bal   HP  ",
                GM.screenSize.Center.X - 240, GM.screenSize.Bottom,
                taLevelInfo, 1000, null);
        }
        //Draws up text at bottom left corner of screen

        private void CreateTiles()
        {
            this.MyTileList = new List<Tile>
            {
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Black), //0
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Green), //1
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Red), //2
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Blue), //3
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Gold), //4
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Gray), //5
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Black), //6
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Black), //7
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Black), //8
                new Tile(Tex.Rectangle50by50, new Rectangle(0, 0, 40, 40), Color.Black), //9

            };
        }
    }
}