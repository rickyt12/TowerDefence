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
using Engine;

namespace Template.CodeGame
{
    internal class MovingEnemy : Sprite
    {
        private Level map;

        public MovingEnemy(Vector2 pos, Vector2 vel, Level map)
        {
            this.map = map;
            GM.engineM.AddSprite(this);
            Frame.Define(Tex.Circle16by16);
            Position2D = pos;
            Velocity2D = vel;

            UpdateCallBack += checkMap;


        }

        private void checkMap()
        {
            if (map.ActorAtCentre(this, 2))
            {
                if (map.DirectionTile(this))
                {
                    map.ChangeDirection(this);
                }
            }
        }
    }
}