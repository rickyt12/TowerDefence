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
//--engine import
using Engine;
using Template.Title;
using System.Collections.ObjectModel;

namespace Template.Game
{
    internal class Player : Sprite
    {
        private float speed = 200;
        private Weapon activeWeapon;
        private Event tiShoot;
        private bool autofire;

        public Player()
        {
            GM.engineM.AddSprite(this);
            Frame.Define(Tex.Triangle);
            Y = GM.screenSize.Bottom;
            X = GM.screenSize.Center.X;
            activeWeapon = new StandardShot();// new QuinnShot();// new TripleShot();// new DoubleShot();// new Standard();
            UpdateCallBack += Move;
            UpdateCallBack += Display;
            CollisionActive = true;
            CollisionPrimary = true;
            CollisionCallBack += Collection;

            //GM.eventM.AddTimer(tiShoot = new Event(0.25f, "autofire"));
            //autofire = true;
        }

        private void Display()
        {
            GM.textM.Draw(FontBank.arcadeLarge, activeWeapon.Name, 10, GM.screenSize.Bottom, TextAtt.BottomLeft);
        }

        private void Collection(Sprite hit)
        {
            if (hit is WeaponUpgrade wu)
            {
                activeWeapon = wu.myWeapon;
                wu.Kill();
            }
        }

        private void Move()
        {
            if (GM.inputM.KeyDown(Keys.Left))
                X -= speed * GM.eventM.Delta;
            if (GM.inputM.KeyDown(Keys.Right))
                X += speed * GM.eventM.Delta;
            if (GM.inputM.KeyDown(Keys.Up))
                Y -= speed * GM.eventM.Delta;
            if (GM.inputM.KeyDown(Keys.Down))
                Y += speed * GM.eventM.Delta;

            if ((GM.inputM.KeyDown(Keys.X) || autofire) && GM.eventM.Elapsed(tiShoot))
                activeWeapon.Shoot(this, 300);
        }
    }
}