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

namespace Fantasy_Farm
{
    class SpriteSheet : Sprite
    {
        protected Rectangle[] animFrames = { };

        int animIndex = 0;
        float frameRate = 1f / 10;
        float frameTimer = 0f;

        public SpriteSheet(Texture2D texture)
            : base(texture)
        {

        }
        public virtual void UpdateAnim(GameTime gameTime)
        {//if enough time has passed, switch to next frame
            frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (frameTimer >= frameRate)
            {
                animIndex++;
                frameTimer -= frameRate;
            }
            if (animIndex >= animFrames.Length) animIndex = 0;
            crop = animFrames[animIndex];
        }

        /// <summary>
        /// Returns a rectangle for a square animation frame
        /// </summary>
        /// <param name="size">The size of the square's X and Y dimensions</param>
        /// <param name="num"></param>
        /// <returns>Returns a square rectangle for an animaiton frame.</returns>
        public Rectangle GetRectForFrame(int size, int num)
        {
            // returns a rectangle for a frame for SQUARE sprites
            int cols = texture.Width / size;
            int x = (num % cols) * size;
            int y = (num / cols) * size;

            return new Rectangle(x, y, size, size);
        }
        /// <summary>
        /// Returns a rectangle for a frame for sprites.
        /// </summary>
        /// <param name="sizeX">The X dimension for the sprite size</param>
        /// <param name="sizeY">The Y dimension for the sprite size</param>
        /// <param name="num"></param>
        /// <returns>Returns a rectangle of an animation frame</returns>
        public Rectangle GetRectForFrame(int sizeX, int sizeY, int num)
        {
            // 
            int cols = texture.Width / sizeX;
            int x = (num % cols) * sizeX;
            int y = (num / cols) * sizeY;

            return new Rectangle(x, y, sizeX, sizeY);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="frames"></param>
        /// <returns></returns>
        public Rectangle[] MakeAnimSequence(int size, int[] frames)
        {
            Rectangle[] rects = new Rectangle[frames.Length];

            for (int i = 0; i < rects.Length; i++)
            {
                rects[i] = GetRectForFrame(size, frames[i]);
            }

            return rects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="frames"></param>
        /// <returns></returns>
        public Rectangle[] MakeAnimSequence(int sizeX, int sizeY, int[] frames)
        {
            Rectangle[] rects = new Rectangle[frames.Length];

            for (int i = 0; i < rects.Length; i++)
            {
                rects[i] = GetRectForFrame(sizeX, sizeY, frames[i]);
            }

            return rects;
        }
    }
}

