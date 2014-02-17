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
    static class GameStateManager
    {
        static GameState currentGameState;
        static GSPlay playState;
        public static IServiceProvider Services;

        public static void Update(GameTime gameTime)
        {
            if (currentGameState != null) currentGameState.Update(gameTime);
        }
        
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (currentGameState != null) currentGameState.Draw(spriteBatch);
        }

        public static void SwitchToPlay()
        {
            if (playState == null) { playState = new GSPlay(); }
            currentGameState = playState;
        }
        
        public static void SwitchToTitle()
        {
            currentGameState = new GSTitle();
            playState = null;
        }
        
        public static void SwitchToQuit()
        {
            currentGameState = new GSQuit();
            playState = null;
        }

        public static void SwitchToPause()
        {
            currentGameState = new GSPause();
        }
    }
}