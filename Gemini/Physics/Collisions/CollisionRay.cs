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

namespace Gemini.Physics.Collisions
{
    public struct CollisionRay : ICollisionBounds
    {
        #region Fields
        internal Ray volume;

        private Vector2 position;
        private Vector2 offset;
        private Vector2 direction;
        #endregion

        #region Properties
        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                Realign();
            }
        }

        public Vector2 Offset
        {
            get { return offset; }
            set
            {
                offset = value;
                Realign();
            }
        }

        public Vector2 Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                Realign();
            }
        }
        #endregion

        #region Constructors
        public CollisionRay(Vector2 position, Vector2 offset, Vector2 direction)
        {
            this.position = position;
            this.offset = offset;
            this.direction = direction;

            this.volume = new Ray(new Vector3(position + offset, 0f), new Vector3(direction, 0f));
        }

        public CollisionRay(Vector2 position, Vector2 direction)
            : this(position, Vector2.Zero, direction)
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// By definition, Rays cannot contain anything.
        /// So this will always return false.
        /// </summary>
        /// <param name="collisionType"></param>
        /// <param name="other"></param>
        /// <param name="location"></param>
        /// <returns>False</returns>
        public bool Contains(BaseCollisionType collisionType, ICollisionBounds other, Vector2? location)
        {
            return false;
        }

        public bool Intersects(BaseCollisionType collisionType, ICollisionBounds other)
        {
            if (other == null)
                return false;

            switch (collisionType)
            {
                case BaseCollisionType.Box:
                    return (IntersectsBox((CollisionBox)other) != null);

                case BaseCollisionType.Circle:
                    return (IntersectsCircle((CollisionCircle)other) != null);
            }

            return false;
        }

        public float? IntersectsBox(CollisionBox other)
        {
            return volume.Intersects(other.volume);
        }

        public float? IntersectsCircle(CollisionCircle other)
        {
            return volume.Intersects(other.volume);
        }
        #endregion

        #region Private Methods
        private void Realign()
        {
            //TODO: See if translating the vectors will work better.
            volume.Position = new Vector3(position + offset, 0f);
            volume.Direction = new Vector3(direction, 0f);
        }
        #endregion
    }
}
