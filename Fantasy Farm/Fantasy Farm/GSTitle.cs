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
    class GSTitle : GameState
    {        Sprite title;
        public GSTitle()
            : base()
        {
            Texture2D img = Content.Load<Texture2D>("title");
            title = new Sprite(img, new Vector2(800, 480));
        }
        public override void Update(GameTime gameTime)
        {

            UpdateKeyboardState();

            if (OnPress(Keys.F2))
            {//go to play state
                GameStateManager.SwitchToPlay();
            } 
            if (OnPress(Keys.F3))
            {//go to quit state
                GameStateManager.SwitchToPause();
            }
            if (OnPress(Keys.F4))
            {//go to pause state
                GameStateManager.SwitchToQuit();
            }
            base.Update(gameTime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            title.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
