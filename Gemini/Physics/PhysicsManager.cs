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


namespace Gemini.Physics
{
    /// <summary>
    /// Updates, controls, and stores IPhysicsObjects.
    /// </summary>
    public class PhysicsManager : Microsoft.Xna.Framework.GameComponent
    {
        private PhysicsObjectCollection objects = new PhysicsObjectCollection();

        public PhysicsObjectCollection Objects
        {
            get { return objects; }
        }

        public PhysicsManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            objects.UpdateAll(gameTime);

            base.Update(gameTime);
        }
    }
}
