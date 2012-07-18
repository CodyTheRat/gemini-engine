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

namespace Gemini.Physics.Collisions
{
    public enum BaseCollisionType
    {
        Box,
        Circle,
        Ray,
        Point
    }

    public interface ICollisionBounds
    {
        Vector2 Position
        {
            get;
        }

        Vector2 Offset
        {
            get;
        }

        bool Contains(BaseCollisionType collisionType, ICollisionBounds other, Vector2? location);
        bool Intersects(BaseCollisionType collisionType, ICollisionBounds other);
    }
}
