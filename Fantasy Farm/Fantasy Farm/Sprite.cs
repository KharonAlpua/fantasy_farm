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
    public class Sprite
    {

        protected Texture2D texture;
        public Vector2 position = new Vector2(0, 0);
        public Vector2 origin = new Vector2(0, 0);
        public float rotation = 0;
        public float scale = 1;
        public Rectangle crop;
        public Color color = Color.White;
        public SpriteEffects spriteEffects = SpriteEffects.None;

        public Sprite(Texture2D texture) : this(texture, Vector2.Zero) { }
        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            crop = texture.Bounds;
            origin = new Vector2(texture.Width, texture.Height);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, crop, color, rotation, origin, scale, spriteEffects, 0);
        }
    }
}
