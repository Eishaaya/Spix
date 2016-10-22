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
    public class Player : Sprite
    {
        protected int _speed;
        public int direction = 1;
        public int lives;
        public bool isdead = false;
        public int directionToChangeTo = 0;
        List<Vector2> _points;
        KeyboardState lastKS;
        public int speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        bool _changedDirection = false;
        trail _trail;
        territory _terra;
        Texture2D pix;
        float scaleX;
        float scaleY;
        int hitCount;
        public Keys UpKey;
        public Keys Downkey;
        public Keys Leftkey;
        public Keys Rightkey;
        public Keys shootkey;
        public bool isboom = false;
        public Player(Texture2D image, Vector2 location, Color color, int speed, Texture2D trail, Texture2D terraimage, Texture2D pixel, Keys upKey, Keys downkey, Keys leftkey, Keys rightkey, Keys Shootkey)
            : base(image, location, color)
        {
            UpKey = upKey;
            Downkey = downkey;
            Leftkey = leftkey;
            Rightkey = rightkey;
            shootkey = Shootkey;
            pix = pixel;
            _points = new List<Vector2>();
            _speed = speed;
            _terra = new territory(new Sprite(terraimage, new Vector2(location.X + _origin.X, location.Y + _origin.Y), color), _location);
            
            _trail = new trail(new Sprite(trail, new Vector2(location.X, location.Y), color));
            scaleX = 1f;
            scaleY = 1f;
            hitCount = 1;
        }

        public void Update(GameTime gametime, KeyboardState ks, KeyboardState prevKs, Sprite healthBar)
        {
            if (ks.IsKeyDown(Leftkey) && prevKs.IsKeyUp(Leftkey) && direction != 2)
            {
                directionToChangeTo = 0;
                _changedDirection = true;
                _rotation = -MathHelper.PiOver2;
            }
            if (ks.IsKeyDown(UpKey) && prevKs.IsKeyUp(UpKey) && direction != 3)
            {
                directionToChangeTo = 1;
                _changedDirection = true;
                _rotation = 0;
            }
            if (ks.IsKeyDown(Rightkey) && prevKs.IsKeyUp(Rightkey) && direction != 0)
            {
                directionToChangeTo = 2;
                _changedDirection = true;
                _rotation = MathHelper.PiOver2;
            }
            if (ks.IsKeyDown(Downkey) && prevKs.IsKeyUp(Downkey) && direction != 1)
            {
                directionToChangeTo = 3;
                _changedDirection = true;
                _rotation = MathHelper.Pi;
            }

            //keep moving till you can change direction
            if (_changedDirection)
            {
                if ((_location.X - 15) % 30 == 0 && (_location.Y - 15) % 30 == 0)
                {
                    //_points.Add(new Vector2(_hitbox.X, _hitbox.Y));
                    _changedDirection = false;
                    direction = directionToChangeTo;
                }
            }
            if ((_location.X - 15) % 30 == 0 && (_location.Y - 15) % 30 == 0)
            {
                if (!_terra.PositionIntersects(this))
                {
                    _trail.AddTrail(_location);
                    _points.Add(_location);
                }
            }

            move();

            if (_trail.HitTrail(this))
            {
                hitCount++;
                scaleX = 1 / (float)hitCount;
                //hitcount makes life bar smalLer IT WORKS PERFECTLY DON'T GET RID OF IT!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //had to use hitcount to make it so ratio goes up and makes bar smaller
                lives -= 1;
                if (lives > 0)
                {
                    
                    healthBar.Scale = new Vector2(scaleX, scaleY);
                    
                }

                _trail.ClearTrail();
            }
            if(lives <= 0)
            {
                isdead = true;
            }
            if (_terra.PositionIntersects(this))
            { 
                _trail.ClearTrail();
                if (_points.Count >= 1)
                {
                    _terra.AddTerritory(_points);
                }
                _points.Clear();
            }

            lastKS = ks;
        }

        void move()
        {

            if (direction == 0)
            {
                //LocationX -= _speed;
                _location.X -= _speed;
            }
            if (direction == 1)
            {
                //LocationY -= _speed;
                _location.Y -= _speed;
            }
            if (direction == 2)
            {
                //LocationX += _speed;
                _location.X += speed;
            }
            if (direction == 3)
            {
                //LocationY += _speed;
                _location.Y += _speed;
            }
            _hitbox.X = (int)(_location.X - (_image.Width / 2)) + 15;
            _hitbox.Y = (int)(_location.Y - (_image.Height / 2)) + 15;
        }

        public override void draw(SpriteBatch spbt)
        {
            _terra.Draw(spbt);
            _trail.draw(spbt);
            //debugDraw(spbt, pix);
            base.draw(spbt);
        }

    }
}
