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

        public MovingEnemy(Vector2 pos, Vector2 vel)
        {
            GM.engineM.AddSprite(this);
            Frame.Define(Tex.Circle32by32);
            Position2D = pos;
            Velocity2D = vel;

            if (pos = 60)
            {

            }


            

        }
    }
}