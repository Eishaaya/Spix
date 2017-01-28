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
    public enum Type
    {
        Bullet,
        Trap,
        Fire,
        shurk,
        arrow
    }
    public class boom : Sprite
    {
        protected int speed;
        public int number = 3;
        protected KeyboardState ks;
        Type type;
        public boom(Texture2D image, Vector2 location, Color color, Type type, int speed)
            : base(image, location, color)
        {
            this.speed = speed;
            _layer = 0.8f;
        }
        public void Update(GameTime gt)
        {
            _hitbox = new Rectangle((int)(_location.X - (_image.Width / 2)), (int)(_location.Y), _image.Width / 2, _image.Height / 2);
            if (number == 3)
            {
                _location = new Vector2(_location.X, _location.Y + speed);
            }
            if (number == 2)
            {
                _location = new Vector2(_location.X + speed, _location.Y);
            }
            if (number == 1)
            {
                _location = new Vector2(_location.X, _location.Y - speed);
            }
            if (number == 0)
            {
                _location = new Vector2(_location.X - speed, _location.Y);
            }
        }
        public void dicheck()
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down))
            {
                number = 3;
            }
            if (ks.IsKeyDown(Keys.Right))
            {
                number = 2;
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                number = 1;
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                number = 0;
            }
        }
    }
}

