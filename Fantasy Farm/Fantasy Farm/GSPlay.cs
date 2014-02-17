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
    class GSPlay : GameState
    {

        Map map;
        Player player;
        Camera camera;

        

        public GSPlay()
        {

            
            map = new Map(Content.Load<Texture2D>("terrain"), 64);
            map.SetTiles(new int[,]{
                          {0,0,0,0,0,0,0,0,0,0},
                          {0,1,1,1,1,1,1,1,1,0},
                          {0,1,1,1,1,1,1,1,1,0},
                          {0,1,1,1,1,1,1,1,1,0},
                          {0,1,1,1,1,1,1,1,1,0},
                          {0,1,1,1,1,1,1,1,1,0},
                          {0,1,1,1,1,1,1,1,1,0},
                          {0,1,1,1,1,1,1,1,1,0},
                          {0,1,1,1,1,1,1,1,1,0},
                          {0,0,0,0,0,0,0,0,0,0},
                      });

            player = new Player(Content);
            player.Teleport(3, 2);

            camera = new Camera();
        }
        public override void Update(GameTime gameTime)
        {
            UpdateKeyboardState();

            if (IsPressed(Keys.Up)) player.Move(this, Direction.North);
            if (IsPressed(Keys.Down)) player.Move(this, Direction.South);
            if (IsPressed(Keys.Right)) player.Move(this, Direction.East);
            if (IsPressed(Keys.Left)) player.Move(this, Direction.West);

            if (OnPress(Keys.F1))
            {//go to quit state
                GameStateManager.SwitchToTitle();
            }
            if (OnPress(Keys.F3))
            {//go to pause state
                GameStateManager.SwitchToPause();
            }
            if (OnPress(Keys.F4))
            {//go to title state
                GameStateManager.SwitchToQuit();
            }

            player.Update(gameTime);

            camera.Update(player.position);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.matrix);
            map.Draw(sb);
            player.Draw(sb);
            sb.End();

            
        }

        public bool CheckCollide(int x, int y)
        {
            return map.CheckCollide(x, y);


        }
    }
}