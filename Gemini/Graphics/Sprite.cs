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
    public class Sprite : Image
    {
        #region Fields
        private string currentAnimation = "default";
        private Dictionary<string, SpriteAnimation> animations = new Dictionary<string, SpriteAnimation>();
        #endregion

        #region Properties
        public string CurrentAnimation
        {
            get 
            {
                return currentAnimation; 
            }
            set
            {
                if (animations.ContainsKey(value))
                {
                    currentAnimation = value;
                }
                else
                {
                    throw new KeyNotFoundException("The given animation \"" + value + "\" does not exist in the current context.");
                }
            }
        }

        public Dictionary<string, SpriteAnimation> Animations
        {
            get { return animations; }
            protected set { animations = value; }
        }
        #endregion

        #region Constructors
        public Sprite(Texture2D texture)
            :base(texture)
        {
            SpriteAnimation anim = new SpriteAnimation(new Point(0, 0), new Point(0, 0), new Point(texture.Width, texture.Height), new Point(0, 0), new Point(0, 0), 0);
            animations.Add("default", anim);
        }

        public Sprite(Texture2D texture, SpriteAnimation defaultAnimation)
            : base(texture)
        {
            animations.Add("default", defaultAnimation);
        }
        #endregion

        #region Public Methods
        public virtual void Update(GameTime gameTime)
        {
            animations[currentAnimation].Update(gameTime);
        }

        public new virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (visible)
                spriteBatch.Draw(texture, position, animations[currentAnimation].CurrentFrameRectangle, color, rotation, origin, scale, effects, depth);
        }
        #endregion
    }
}
