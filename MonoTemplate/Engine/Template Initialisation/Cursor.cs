﻿using System;
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

namespace Template
{
    ///// <summary>
    ///// defines a cursor sprite
    ///// </summary>
    //class Cursor : Sprite
    //{
    //    /// <summary>
    //    /// an event to control operational logic for this sprite
    //    /// </summary>
    //    private Event evLogic;

    //    /// <summary>
    //    /// creates a new cursor that tracks the mouse
    //    /// </summary>
    //    public Cursor()
    //    {
    //        GM.engineM.AddSprite(this);

    //        Frame.Define(Tex.Triangle);
    //        RotationAngle = -35;
    //        Align = Engine.Align.topLeft;
    //        Layer = RenderLayer.hud;
    //        Position2D = PointHelper.Vector2FromPoint(GM.screenSize.Center);
    //        Z = 50000;
    //        WorldCoordinates = false;
    //        //add mouse logic to fire as fast as engine is updating
    //        GM.eventM.AddEvent(evLogic = new Event(GM.eventM.MaximumRate, "mouse cursor", Logic));
    //    }
    //    /// <summary>
    //    /// make sure the event is removed when this object is destroyed
    //    /// </summary>
    //    public override void CleanUp()
    //    {
    //        GM.eventM.Remove(evLogic);
    //    }

    //    /// <summary>
    //    /// allows a starting position to be specified
    //    /// </summary>
    //    /// <param name="start">the start position</param>
    //    public Cursor(Point start)
    //        :this()
    //    { 
    //        GM.inputM.MouseReset(start);
    //        Position2D = PointHelper.Vector2FromPoint(start);
    //    }

    //    /// <summary>
    //    /// update logic that needs to be performed
    //    /// </summary>
    //    private void Logic()
    //    {
    //        //add on mouse movement to sprites position
    //        Position2D += GM.inputM.MouseDistance;
    //    }
    //    /// <summary>
    //    /// set the new position of the cursor
    //    /// </summary>
    //    /// <param name="newPosition">position to set cursor</param>
    //    public static void Reset(Vector2 newPosition)
    //    {
    //        GM.inputM.MouseReset(newPosition);
    //    }

    //}
}
