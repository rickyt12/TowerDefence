﻿using System;
using System.Collections.Generic;
using System.Linq;
using Engine;
//system threading in use for sleep method
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Template.CodeGame
{
    internal class Tower : Sprite
    {
        private Level level;
        private Vector2 vector2;

        public bool canAttack;


        public Tower(Level level, Vector2 build)
        {
            this.level = level;
            this.vector2 = build;
            GM.engineM.AddSprite(this);

            Frame.Define(Tex.Triangle);
            Wash = Color.Aqua;

            Align = Align.centre;
            Position2D = build;



        }

        public void Range()
        {
            
        }
        public virtual void Shoot()
        {

        }
    }//end of tower


}