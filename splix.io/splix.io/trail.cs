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
    class trail
    {
        List<Sprite> _tails;
        Sprite _trailSprite;

        public trail(Sprite trailSprite)
        {
            _tails = new List<Sprite>();
            _trailSprite = trailSprite;
        }

        public void update(GameTime gametime)
        {

        }

        public void AddTrail(Vector2 position)
        {
            _tails.Add(new Sprite(_trailSprite.Image, position, _trailSprite.Color));
        }

        public bool HitTrail(Sprite sprite)
        {
            for (int i = 0; i < _tails.Count - 1; i++)
            {
                if (_tails[i].Hitbox.Intersects(sprite.Hitbox))
                {
                    return true;
                }
            }

            return false;
        }

        public void ClearTrail()
        {
            _tails.Clear();
        }
        public void draw(SpriteBatch batch)
        {
            for (int i = 0; i < _tails.Count; i++)
            {
                _tails[i].draw(batch);
            }
        }
    }
}
