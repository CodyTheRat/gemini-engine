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
    public struct CollisionBox : ICollisionBounds
    {
        #region Fields
        internal BoundingBox volume;

        private Vector2 position;
        private Vector2 size;
        private Vector2 offset;
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

        public Vector2 Size
        {
            get { return size; }
            set
            {
                size = value;

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

        public float Width
        {
            get { return size.X; }
            set 
            {
                size.X = value; 
                Realign(); 
            }
        }

        public float Height
        {
            get { return size.Y; }
            set
            {
                size.Y = value;

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

        public float Y
        {
            get { return position.Y; }
            set
            {
                position.Y = value;

                Realign();
            }
        }
        #endregion

        #region Constructors
        public CollisionBox(Vector2 position, Vector2 size, Vector2 offset)
        {
            this.position = position;
            this.size = size;
            this.offset = offset;

            this.volume = new BoundingBox(new Vector3(this.position + this.offset, -0.5f), new Vector3(this.position + this.size + this.offset, 0.5f));
        }

        public CollisionBox(Vector2 position, Vector2 size)
            : this(position, size, Vector2.Zero)
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

            //If all else fails, return false.
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
            //TODO: See if translating the vectors will work better.
            volume.Min = new Vector3(position + offset, -0.5f);
            volume.Max = new Vector3(position + size + offset, 0.5f);
        }
        #endregion
    }
}
