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
        ICollisionBounds Volume
        {
            get;
        }

        int Index
        {
            get;
        }

        string Mask
        {
            get;
        }

        void Update(GameTime gameTime);

        void Simulate(GameTime gameTime);
        void SimulateStep();
    }
}
