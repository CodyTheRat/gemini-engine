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
    public class SpriteAnimation
    {
        #region Fields
        private Point currentFrame;
        private Point defaultFrame;
        private Point sheetSize;
        private Point frameSize;
        private Point framePadding;
        private Point cellOffset;

        private int[] timePerFrame;
        private int timeSinceLastFrame;
        private const int defaultTimePerFrame = 1000 / 30;

        private bool rewindOnEnd = false;
        private bool rewinding = false;
        #endregion

        #region Properties
        public Rectangle CurrentFrameRectangle
        {
            get
            {
                return new Rectangle(
                    ((currentFrame.X * frameSize.X) + (currentFrame.X * framePadding.X)) + ((cellOffset.X * frameSize.X) + (cellOffset.X * framePadding.X)),
                    ((currentFrame.Y * frameSize.Y) + (currentFrame.Y * framePadding.Y)) + ((cellOffset.Y * frameSize.Y) + (cellOffset.Y * framePadding.Y)),
                    frameSize.X, frameSize.Y);
            }
        }

        public int AnimationLength
        {
            get { return sheetSize.X * sheetSize.Y; }
        }

        public int CurrentFrame
        {
            get { return currentFrame.X * currentFrame.Y; }
            //TODO: Figure out an integer based "set" algorithm.
        }

        public Point FrameSize
        {
            get { return frameSize; }
        }

        public int CurrentFrameRate
        {
            get { return timePerFrame[currentFrame.X * currentFrame.Y]; }
        }

        public bool RewindOnEnd
        {
            get { return rewindOnEnd; }
            set { rewindOnEnd = value; }
        }
        #endregion

        #region Constructors
        public SpriteAnimation(Point defaultFrame, Point sheetSize, Point frameSize, Point framePadding, Point cellOffset, int[] timePerFrame)
        {
            this.defaultFrame = defaultFrame;
            this.currentFrame = defaultFrame;
            this.sheetSize = sheetSize;
            this.frameSize = frameSize;
            this.framePadding = framePadding;
            this.cellOffset = cellOffset;
            this.timePerFrame = timePerFrame;
        }

        public SpriteAnimation(Point defaultFrame, Point currentFrame, Point sheetSize, Point frameSize, Point framePadding, Point cellOffset, int[] timePerFrame)
        {
            this.defaultFrame = defaultFrame;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.frameSize = frameSize;
            this.framePadding = framePadding;
            this.cellOffset = cellOffset;
            this.timePerFrame = timePerFrame;
        }

        public SpriteAnimation(Point defaultFrame, Point sheetSize, Point frameSize, Point framePadding, Point cellOffset, int timePerFrame)
        {
            this.defaultFrame = defaultFrame;
            this.currentFrame = defaultFrame;
            this.sheetSize = sheetSize;
            this.frameSize = frameSize;
            this.framePadding = framePadding;
            this.cellOffset = cellOffset;

            this.timePerFrame = new int[sheetSize.X * sheetSize.Y];

            for (int i = 0; i < this.timePerFrame.Length; i++)
            {
                this.timePerFrame[i] = timePerFrame;
            }
        }

        public SpriteAnimation(Point defaultFrame, Point currentFrame, Point sheetSize, Point frameSize, Point framePadding, Point cellOffset, int timePerFrame)
        {
            this.defaultFrame = defaultFrame;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.frameSize = frameSize;
            this.framePadding = framePadding;
            this.cellOffset = cellOffset;

            this.timePerFrame = new int[sheetSize.X * sheetSize.Y];

            for (int i = 0; i < this.timePerFrame.Length; i++)
            {
                this.timePerFrame[i] = timePerFrame;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Updates the animation, keeping rewinding in mind.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            /* Keeping this in, in case I decide it works better.
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame >= timePerFrame[CurrentFrame])
            {
                timeSinceLastFrame = 0;

                if (rewinding)
                    DecrementFrame();
                else
                    IncrementFrame();
            }
            //*/

            if (!rewinding)
                UpdateForwards(gameTime);
            else
                UpdateBackwards(gameTime);
        }

        public void UpdateForwards(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame >= timePerFrame[CurrentFrame])
            {
                timeSinceLastFrame = 0;

                IncrementFrame();
            }
        }

        public void UpdateBackwards(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame >= timePerFrame[CurrentFrame])
            {
                timeSinceLastFrame = 0;

                DecrementFrame();
            }
        }

        public void IncrementFrame()
        {
            ++currentFrame.X;

            if (currentFrame.X > sheetSize.X)
            {
                currentFrame.X = 0;

                ++currentFrame.Y;

                if (currentFrame.Y > sheetSize.Y)
                {
                    currentFrame.Y = 0;

                    if (rewindOnEnd)
                        rewinding = true;
                }
            }
        }

        public void DecrementFrame()
        {
            --currentFrame.X;

            if (currentFrame.X < 0)
            {
                currentFrame.X = sheetSize.X;

                --currentFrame.Y;

                if (currentFrame.Y < 0)
                {
                    currentFrame.Y = sheetSize.Y;

                    if (rewindOnEnd && rewinding)
                        rewinding = false;
                }
            }
        }

        public void Reset()
        {
            timeSinceLastFrame = 0;
            currentFrame.X = defaultFrame.X;
            currentFrame.Y = defaultFrame.Y;
        }
        #endregion
    }
}
