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

namespace Gemini.Graphics
{
    public class SpriteCollection : List<Sprite>
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Sprite s in this)
            {
                s.Draw(gameTime, spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite s in this)
            {
                s.Update(gameTime);
            }
        }
    }
}
