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
    public class pawns : Sprite
    {
        public int speed;
        public int direction = 0;
        public int prevdi = -1;
        public int moves = 0;
        public float _health;
        public float _attack;
        public int prevspeed;
        public SoundEffect Hit;
        public TimeSpan untilattack;
        public TimeSpan waitattack;
        private SoundEffectInstance currentSoundEffect { get; set; }

        Random dichose = new Random();
        public pawns(Texture2D image, Vector2 location, Color color, int Speed, float health, float attack, SoundEffect hit, TimeSpan tillattack)
            : base(image, location, Color.White)
        {
            speed = Speed;
            Hit = hit;
            prevspeed = Speed;
            _health = health;
            _attack = attack;
            untilattack = tillattack;
        }
        public void update(GameTime gt)
        {
            Hitbox = new Rectangle((int)_location.X, (int)_location.Y, _image.Width, _image.Height);
            waitattack += gt.ElapsedGameTime;
            if (moves >= 90)
            {
                direction = dichose.Next(0, 4);
                moves = 0;
            }
            if (direction == 0)
            {
                _location.X += speed;
                _rotation = MathHelper.PiOver2;
                moves += speed;
            }
            if (direction == 1)
            {
                _location.X -= speed;
                _rotation = -MathHelper.PiOver2;
                moves += speed;
            }
            if (direction == 2)
            {
                _location.Y += speed;
                _rotation = MathHelper.Pi;
                moves += speed;
            }
            if (direction == 3)
            {
                _location.Y -= speed;
                _rotation = 0;
                moves += speed;
            }
            prevdi = direction;
        }

        public void PlaySound()
        {
            StopSound();

            currentSoundEffect = Hit.CreateInstance();
            currentSoundEffect.Play();
        }

        public void StopSound()
        {
            if (currentSoundEffect != null && currentSoundEffect.State == SoundState.Playing)
            {
                currentSoundEffect.Stop(true);
            }
        }
    }
}
