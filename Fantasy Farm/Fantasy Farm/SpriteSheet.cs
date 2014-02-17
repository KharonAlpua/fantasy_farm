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
        public Rectangle GetRectForFrame(int size, int num)
        {
            int cols = texture.Width / size;
            int x = (num % cols) * size;
            int y = (num / cols) * size;

            return new Rectangle(x, y, size, size);
        }
        public Rectangle[] MakeAnimSequence(int size, int[] frames)
        {
            Rectangle[] rects = new Rectangle[frames.Length];

            for (int i = 0; i < rects.Length; i++)
            {
                rects[i] = GetRectForFrame(size, frames[i]);
            }

            return rects;
        }
    }
}

