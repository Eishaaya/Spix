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
    public class territory
    {
        public List<Sprite> _points;
        Sprite _terrasprite;
        int rectCount = 0;

        float layer = 0.1f;

        public territory(Sprite terraSprite, Vector2 playerPos)
        {
            _points = new List<Sprite>();
            _terrasprite = terraSprite;
            Vector2 position = playerPos;

            //add premade positions to draw
            for (int i = 0; i < 5; i++)
            {
                for (int a = 0; a < 5; a++)
                {
                    _points.Add(new Sprite(_terrasprite.Image, new Vector2(position.X, position.Y), terraSprite.Color));
                    _points[_points.Count - 1].Layer = layer;
                    position.X += 30;
                }
                position.X = playerPos.X;
                position.Y += 30;
            }
        }

        public void AddTerritory(List<Vector2> positions)
        {
            float bottom = positions[0].Y, top = positions[0].Y, left = positions[0].X, right = positions[0].X;



            foreach (Vector2 point in positions)
            {
                if (point.X > right)
                {
                    right = point.X;
                }
                else if (point.X < left)
                {
                    left = point.X;
                }
                if (point.Y > bottom)
                {
                    bottom = point.Y;
                }
                else if (point.Y < top)
                {
                    top = point.Y;
                }
            }

            //THIS SETS THE TERRITORYS INNER SPRITES
            for (int x = (int)left; x <= (int)right; x += 30)
            {
                for (int y = (int)top; y <= (int)bottom; y += 30)
                {
                    _points.Add(new Sprite(_terrasprite.Image, new Vector2(x, y), _terrasprite.Color));
                    _points[_points.Count - 1].Layer = layer;
                }
            }
            layer += 0.0001f;
        }
        public bool PositionIntersects(Rectangle hitBox)
        {
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i].Hitbox.Intersects(hitBox))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _points.Count; i++)
            {
                _points[i].draw(spriteBatch);
            }
        }
    }
}
