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
    class Player : NPC
    {
        public Player(ContentManager Content)
            : base(Content.Load<Texture2D>("player"))
        {
            crop = new Rectangle(0, 0, 120, 100);
            origin = Vector2.Zero;

            animWalkN = MakeAnimSequence(120, new int[] {00});
            animWalkS = MakeAnimSequence(120, new int[] {01});
            animWalkW = MakeAnimSequence(120, new int[] {02});
            animWalkE = MakeAnimSequence(120, new int[] {03});

            animIdleN = MakeAnimSequence(120, new int[] {00});
            animIdleS = MakeAnimSequence(120, new int[] {01});
            animIdleW = MakeAnimSequence(120, new int[] {02});
            animIdleE = MakeAnimSequence(120, new int[] {03});
        }
    }
}