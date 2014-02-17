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
    struct Tile
    {

        public int index;
        public Vector2 position;
        public Rectangle crop;
        public Tile(int index, Vector2 position, Rectangle crop)
        {
            this.index = index;
            this.position = position;
            this.crop = crop;
        }
    }
}
