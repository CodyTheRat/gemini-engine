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
    public struct CollisionCircle : ICollisionBounds
    {
        #region Fields
        internal BoundingSphere volume;

        private Vector2 position;
        private Vector2 offset;
        private float radius;
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

        public float Radius
        {
            get { return radius; }
            set
            {
                radius = value;

                Realign();
            }
        }

        public float Diameter
        {
            get { return radius * 2; }
            set
            {
                radius = value / 2;

                Realign();
            }
        }

        public float X
        {
            get { return position.X; }
            set
            {
                position.X = value;

                Realign();
            }
        }
        #endregion

        #region Constructors
        public CollisionCircle(Vector2 position, Vector2 offset, float radius)
        {
            this.position = position;
            this.offset = offset;
            this.radius = radius;

            this.volume = new BoundingSphere(new Vector3(position + offset, 0f), radius);
        }

        public CollisionCircle(Vector2 position, float radius)
            : this(position, Vector2.Zero, radius)
        {
        }
        #endregion

        #region Public Methods
        public bool Contains(BaseCollisionType collisionType, ICollisionBounds other, Vector2? location)
        {
            switch (collisionType)
            {
                case BaseCollisionType.Box:
                    if (other != null)
                        return ContainsBox((CollisionBox)other);
                    else
                        return false;

                case BaseCollisionType.Circle:
                    if (other != null)
                        return ContainsCircle((CollisionCircle)other);
                    else
                        return false;

                case BaseCollisionType.Point:
                    if (location != null)
                        return ContainsPoint((Vector2)location);
                    else
                        return false;
            }

            return false;
        }

        public bool ContainsBox(CollisionBox other)
        {
            return (volume.Contains(other.volume) == ContainmentType.Contains);
        }

        public bool ContainsCircle(CollisionCircle other)
        {
            return (volume.Contains(other.volume) == ContainmentType.Contains);
        }

        public bool ContainsPoint(Vector2 location)
        {
            return (volume.Contains(new Vector3(location, 0f)) == ContainmentType.Contains);
        }

        public bool Intersects(BaseCollisionType collisionType, ICollisionBounds other)
        {
            if (other == null)
                return false;

            switch (collisionType)
            {
                case BaseCollisionType.Box:
                    return IntersectsBox((CollisionBox)other);

                case BaseCollisionType.Circle:
                    return IntersectsCircle((CollisionCircle)other);

                case BaseCollisionType.Ray:
                    return IntersectsRay((CollisionRay)other);
            }

            return false;
        }

        public bool IntersectsBox(CollisionBox other)
        {
            return (volume.Intersects(other.volume));
        }

        public bool IntersectsCircle(CollisionCircle other)
        {
            return (volume.Intersects(other.volume));
        }

        public bool IntersectsRay(CollisionRay other)
        {
            return (other.volume.Intersects(volume) != null);
        }
        #endregion

        #region Private Methods
        private void Realign()
        {
            //TODO: See if translating the vector will work better.
            volume.Center = new Vector3(position + offset, 0f);
            volume.Radius = radius;
        }
        #endregion
    }
}
