using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Gemini.Graphics
{
    /// <summary>
    /// Helper class for Isometric coordinate transformation.
    /// Doesn't have a whole lot in it at the moment.
    /// </summary>
    public static class Isometric
    {

        #region Transform Function
        /// <summary>
        /// Transforms 3D isometric coordinates into 2D cartesian coordinates.
        /// </summary>
        /// <param name="coords">Vector of the coordinates to transform.</param>
        /// <param name="origin">The origin point for the iso coord system to start at.</param>
        /// <returns></returns>
        public static Vector2 Transform(Vector3 coords, Vector2 origin)
        {
            float newX;
            float newY;

            /* Isometric calculations usually use 0.46365.
             * I'm using 0.46 because it gives cleaner lines.
             * Also, yes, all the casts are really ugly, but I couldn't find a better way to do it.
             * Math taken from this place: http://www.kirupa.com/developer/actionscript/isometric_transforms.htm
             */
            newX = ((-coords.Y - -coords.X) * (float)Math.Cos(0.46));
            newY = (-(coords.Z + (-coords.Y + -coords.X) * (float)Math.Sin(0.46)));

            newX += origin.X;
            newY += origin.Y;

            return new Vector2(newX, newY);
        }

        /// <summary>
        /// Transforms 3D isometric coordinates into 2D cartesian coordinates.
        /// </summary>
        /// <param name="coords">Vector of the coordinates to transform.</param>
        /// <param name="xOrigin">2D X-axis origin for the iso system to start.</param>
        /// <param name="yOrigin">2D Y-axis origin for the iso system to start.</param>
        /// <returns></returns>
        public static Vector2 Transform(Vector3 coords, float xOrigin, float yOrigin)
        {
            float newX;
            float newY;

            newX = ((-coords.Y - -coords.X) * (float)Math.Cos(0.46));
            newY = (-(coords.Z + (-coords.Y + -coords.X) * (float)Math.Sin(0.46)));

            newX += xOrigin;
            newY += yOrigin;

            return new Vector2(newX, newY);
        }

        /// <summary>
        /// Transforms 3D isometric coordinates into 2D cartesian coordinates.
        /// </summary>
        /// <param name="isoX">Isometric X coordinate.</param>
        /// <param name="isoY">Isometric Y coordinate.</param>
        /// <param name="isoZ">Isometric Z coordinate.</param>
        /// <param name="xOrigin">X-axis origin for the iso system to start at.</param>
        /// <param name="yOrigin">Y-axis origin for the iso system to start at.</param>
        /// <returns></returns>
        public static Vector2 Transform(float isoX, float isoY, float isoZ, float xOrigin, float yOrigin)
        {
            float newX;
            float newY;

            newX = (((-isoY - -isoX) * (float)Math.Cos(0.46)));
            newY = ((-(isoZ + (-isoY + -isoX) * (float)Math.Sin(0.46))));

            newX += xOrigin;
            newY += yOrigin;

            return new Vector2(newX, newY);
        }
        #endregion
    }
}
