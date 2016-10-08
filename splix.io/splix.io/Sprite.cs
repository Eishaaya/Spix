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
    public class Sprite
    {
        protected Vector2 _location;
        protected Color _color;
        protected Texture2D _image;
        protected Vector2 _scale;
        protected SpriteEffects _effects;
        protected float _rotation;
        protected Vector2 _origin;
        protected Rectangle _hitbox;

        public Vector2 Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                //_hitbox.X = (int)(_location.X - _origin.X);
                //_hitbox.Y = (int)(_location.Y - _origin.Y);
            }
        }
        public float LocationX
        {
            get { return this._location.X; }
            set
            {
                this._location.X = value;
            }
        }
        public float LocationY
        {
            get { return this._location.Y; }
            set
            {
                this._location.Y = value;
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public Rectangle Hitbox
        {
            get
            {
                return _hitbox;
            }
            set
            {
                _hitbox = value;
            }
        }

        public Texture2D Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        public Vector2 Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }

        public Sprite(Texture2D image, Vector2 position, Color color)
        {
            _image = image;
            _location = position;
            _color = color;
            _scale = Vector2.One;
            _origin = new Vector2(image.Width / 2, image.Height / 2);
            _hitbox = new Rectangle((int)(position.X - (image.Width / 2)), (int)(position.Y), _image.Width/2, _image.Height/2);
        }

        public virtual void draw(SpriteBatch spbt)
        {
            spbt.Draw(_image, _location, null, _color, _rotation, _origin, _scale, _effects, 1f);
        }
        public void debugDraw(SpriteBatch batch, Texture2D pixel)
        {
            batch.Draw(pixel, this.Hitbox, Color.Red);
        }
    }
}
