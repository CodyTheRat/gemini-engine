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

namespace Gemini.Sys
{
    /// <summary>
    /// Class containing game-specific information.
    /// </summary>
    /// <remarks>
    /// Only one should exist per game, at a Game level.
    /// Pass by reference in methods, such as constructors.
    /// </remarks>
    public abstract class GameConfig
    {
        public enum MachineType
        {
            State,
            Physics
        }

        protected Dictionary<string, Keys> controls = new Dictionary<string, Keys>();
        protected Dictionary<MachineType, IGeminiMachine> machines = new Dictionary<MachineType, IGeminiMachine>();

        public Dictionary<string, Keys> Controls
        {
            get { return controls; }
            protected set { controls = value; }
        }

        public Dictionary<MachineType, IGeminiMachine> Machines
        {
            get { return machines; }
            protected set { machines = value; }
        }
    }
}
