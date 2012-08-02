using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Gemini.Sys;

namespace Gemini.Physics
{
    public class PhysicsObjectCollection : List<IPhysicsObject>
    {
        public void UpdateAll(GameTime gameTime)
        {
            foreach (IPhysicsObject obj in this)
            {
                obj.Update(gameTime);
            }
        }

        public void SimulateAll(GameTime gameTime)
        {
            foreach (IPhysicsObject obj in this)
            {
                obj.Simulate(gameTime);
            }
        }

        public void SimulateStepAll()
        {
            foreach (IPhysicsObject obj in this)
            {
                obj.SimulateStep();
            }
        }
    }
}
