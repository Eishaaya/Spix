﻿using System;
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
    public class Cell
    {
        private Sprite _cellSprite;

        public Sprite CellSprite
        {
            get { return _cellSprite; }
            set { _cellSprite = value; }
        }

        public Cell(Sprite cellSprite)
        {
            _cellSprite = cellSprite;
            _cellSprite.Layer = 0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _cellSprite.draw(spriteBatch);
        }
    }
}
