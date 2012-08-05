using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Gemini.Physics.Collisions;

namespace Gemini.Physics
{
    public interface IPhysicsObject
    {
        /// <summary>
        /// The PhysicsManager that this object belongs to.
        /// Usually going to want to do a protected set for this.
        /// </summary>
        PhysicsManager Manager
        {
            get;
            set;
        }

        /// <summary>
        /// The collision volume that this object uses.
        /// </summary>
        ICollisionBounds Volume
        {
            get;
        }

        /// <summary>
        /// A series of strings saying what the object can and can't collide with.
        /// Other objects with the same Mask values can't collide.
        /// </summary>
        string[] Mask
        {
            get;
        }

        /// <summary>
        /// Actually move after simulating, amongst doing other things.
        /// </summary>
        /// <param name="gameTime">Snapshot of current timing values.</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Simulate movement.
        /// </summary>
        /// <param name="gameTime">Snapshot of current timing values.</param>
        void Simulate(GameTime gameTime);

        /// <summary>
        /// Simulate movment by one frame.
        /// </summary>
        void SimulateStep();
    }
}
