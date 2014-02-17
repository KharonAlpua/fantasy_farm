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
    class Camera
    {
        Vector2 position = Vector2.Zero;
        public Matrix matrix = new Matrix();
        public int screenHalfW = 360;
        public int screenHalfH = 240;

        public Matrix imatrix = new Matrix();

        public Camera()
        {

        }

        public void Update(Vector2 target)
        {
            position = target;
            matrix = Matrix.Identity;
            matrix *= Matrix.CreateTranslation(-position.X, -position.Y, 0);
            matrix *= Matrix.CreateTranslation(screenHalfW, screenHalfH, 0);
        }
    }
}