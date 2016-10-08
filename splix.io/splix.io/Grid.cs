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

namespace splix.io
{
    public class Grid
    {
        private int _width;
        private int _height;
        private Texture2D _empty;
        public Texture2D Empty
        {
            get
            {
                return _empty;
            }
        }
        public int Width
        {
            get
            {
                return _width;
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
        }

        List<Cell> blocks;

        public Grid(int width, int height, Texture2D emptyCellImage)
        {
            _width = width;
            _height = height;
            _empty = emptyCellImage;
             
            blocks = new List<Cell>();

            int x = 0;
            int y = 0;
            for (int a = 0; a < _height; a++)
            {
                for (int i = 0; i < _width; i++)
                {
                    blocks.Add(new Cell(new Sprite(_empty, new Vector2(x, y), Color.White)));
                    x += _empty.Width;
                }
                x = 0;
                y += _empty.Height;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].Draw(batch);
            }
        }
    }
}
