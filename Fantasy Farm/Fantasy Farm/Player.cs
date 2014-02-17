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
            : base(Content.Load<Texture2D>("fergal_spritesheet"))
        {
            crop = new Rectangle(0, 0, 120, 100);
            origin = new Vector2(0,32);

            animWalkN = MakeAnimSequence(64, 96, new int[] { 06, 07, 06, 08 });
            animWalkS = MakeAnimSequence(64, 96, new int[] { 00, 01, 00, 02 });
            animWalkW = MakeAnimSequence(64, 96, new int[] { 03, 04, 03, 05 });
            animWalkE = MakeAnimSequence(64, 96, new int[] { 03, 04, 03, 05 });

            animIdleN = MakeAnimSequence(64, 96, new int[] { 06 });
            animIdleS = MakeAnimSequence(64, 96, new int[] { 00 });
            animIdleW = MakeAnimSequence(64, 96, new int[] { 03 });
            animIdleE = MakeAnimSequence(64, 96, new int[] { 03 });
        }
    }
}