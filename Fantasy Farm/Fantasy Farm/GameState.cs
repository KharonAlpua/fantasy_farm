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
    class GameState {

        protected ContentManager Content;
        protected KeyboardState ksCurr;
        protected KeyboardState ksPrev;

        public GameState()
        {
            Content = new ContentManager(GameStateManager.Services, "Content");
        }

        public virtual void Update(GameTime gameTime)
        {
            ksPrev = ksCurr;

        }

        protected void UpdateKeyboardState()
        {
            ksCurr = Keyboard.GetState();
        }
        protected bool IsPressed(Keys key)
        {
            if (ksCurr == null) return false;
            return ksCurr.IsKeyDown(key);
        }

        protected bool OnPress(Keys key)
        {
            if (ksCurr == null && ksPrev == null) return false;

            return (ksCurr.IsKeyDown(key) && ksPrev.IsKeyUp(key));

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}