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

namespace Gemini.Graphics
{
    public abstract class Image
    {
        #region Fields
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle? sourceRectangle;
        protected Color color;
        protected float rotation;
        protected Vector2 origin;
        protected Vector2 scale;
        protected SpriteEffects effects;
        protected float depth;

        protected bool visible;
        #endregion

        #region Properties
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion

        #region Constructors
        public Image(Texture2D texture)
            :this(texture, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f)
        {
        }

        public Image(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float depth)
        {
            this.texture = texture;
            this.position = position;
            this.sourceRectangle = sourceRectangle;
            this.color = color;
            this.rotation = rotation;
            this.origin = origin;
            this.scale = scale;
            this.effects = effects;
            this.depth = depth;
        }

        #endregion

        #region Public Methods
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (visible)
                spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, depth);
        }
        #endregion
    }
}
