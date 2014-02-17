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
    class Map
    {
        Texture2D texture;
        int size = 0;
        int[,] tiles;

        Tile[] tilesCached = { };

        public Map(Texture2D texture, int size)
        {
            this.texture = texture;
            this.size = size;
        }

        public void SetTiles(int[,] tiles)
        {
            this.tiles = tiles;
            CacheTiles();
        }
        public void CacheTiles()
        {
            tilesCached = new Tile[tiles.Length];


            int i = 0;
            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    int index = tiles[y, x];
                    int cols = texture.Width / size;
                    int row = index / cols;
                    int col = index % cols;

                    Rectangle crop = new Rectangle(col * size, row * size, size, size);
                    Vector2 position = new Vector2(x, y) * size;
                    tilesCached[i] = new Tile(index, position, crop);
                    i++;

                } // inner loop
            } // outer loop
        }
        public void Draw(SpriteBatch sb)
        {
            foreach (Tile t in tilesCached)
            {
                sb.Draw(texture, t.position, t.crop, Color.White);
            }
        }
        public bool CheckCollide(int x, int y)
        {
            if (y < 0 || x < 0) return true;
            if (y >= tiles.GetLength(0) || x >= tiles.GetLength(1)) return true;

            int t = tiles[y, x];

            if (t == 1) return false;

            return true;
        }
    }
}
