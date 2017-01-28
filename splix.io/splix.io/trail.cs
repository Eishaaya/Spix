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
    public class trail
    {
        public List<Sprite> _tails;
        public Dictionary<int, int> _tailsHit;
        Sprite _trailSprite;
        public Color nextTrailColor;

        int hitIndex = -1;

        public trail(Sprite trailSprite)
        {
            _tails = new List<Sprite>();
            _tailsHit = new Dictionary<int, int>();

            _trailSprite = trailSprite;
        }

        public void update(GameTime gametime)
        {

        }

        public void AddTrail(Vector2 position)
        {
            _tails.Add(new Sprite(_trailSprite.Image, position, nextTrailColor));
            _tails[_tails.Count - 1].Layer = 0.99f;
            _tailsHit.Add(_tails.Count - 1, 0);
        }

        public bool HitTrail(Sprite sprite)
        {
            for (int i = 0; i < _tails.Count - 1; i++)
            {
                if (_tails[i].Hitbox.Intersects(sprite.Hitbox))
                {
                    hitIndex = i;
                    _tailsHit[hitIndex]++;
                    return true;
                }
            }

            return false;
        }

        public bool HasPieceBeenHit(int index)
        {
            return _tailsHit[index] > 1;
        }

        public int GetHitIndex()
        {
            return hitIndex;
        }

        public void ClearTrail()
        {
            _tails.Clear();
            _tailsHit.Clear();
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
