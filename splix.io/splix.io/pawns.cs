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
        public TimeSpan untilshoot = new TimeSpan(0, 0, 0, 1, 0);
        public TimeSpan waitshoot;
        public TimeSpan untilshoot2 = new TimeSpan(0, 0, 0, 0, 200);
        public TimeSpan waitshoot2;
        public float _health;
        public float _attack;
        public int prevspeed;
        public SoundEffect Hit;
        public TimeSpan untilattack;
        public TimeSpan waitattack;
        public List<boom> arrows;
        public Texture2D arrowimage;
        public List<boom> balls;
        public Texture2D ballimage;
        public List<boom> bullets;
        public Texture2D bulletimage;
        public bool isgun = false;
        public bool iscannon = false;
        public bool isarcher = false;
        bool issmall = false;
        public Texture2D ammo;
        public List<boom> shots;
        public bool isevil;
        public Sprite rotor;
        public Texture2D heli;
        public Texture2D blade;
        private SoundEffectInstance currentSoundEffect { get; set; }

        Random dichose = new Random();
        public pawns(Texture2D image, Vector2 location, Color color, int Speed, float health, float attack, SoundEffect hit, TimeSpan tillattack)
            : base(image, location, Color.White)
        {
            speed = Speed;
            Hit = hit;
            prevspeed = Speed;
            _location = location;
            _health = health;
            _color = color;
            _attack = attack;
            _image = image;
            untilattack = tillattack;
            arrows = new List<boom>();
            bullets = new List<boom>();
            balls = new List<boom>();
            shots = new List<boom>();
            if (heli == image)
            {
                Layer = 0.0f;
                rotor = new Sprite(blade, location, Color.White);
                rotor.Layer = 0.0f;
            }
        }
        public void update(GameTime gt)
        {
            if (heli == _image)
            {
                rotor.Location = _location;
                rotor._rotation += 1.35f;
            }
            Hitbox = new Rectangle((int)_location.X, (int)_location.Y, _image.Width, _image.Height);
            waitattack += gt.ElapsedGameTime;
            if (Image.Height <= 500)
            {
                issmall = true;
            }
            if (moves >= Image.Height * 3 && issmall)
            {
                direction = dichose.Next(0, 4);
                moves = 0;
            }
            if (issmall == false)
            {
                if (moves >= 750)
                {
                    direction = dichose.Next(0, 4);
                    moves = 0;
                }
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
            if (isarcher || iscannon || isgun)
            {
                waitshoot += gt.ElapsedGameTime;

                if (waitshoot >= untilshoot)
                {
                    if (isarcher)
                    {
                        boom arrow = new boom(arrowimage, _location, _color, Type.arrow, 3);
                        if (direction == 2)
                        {
                            arrow.number = 3;
                            arrow._rotation = MathHelper.PiOver2;
                        }
                        if (direction == 3)
                        {
                            arrow.number = 1;
                            arrow._rotation = -MathHelper.PiOver2;
                        }
                        if (direction == 0)
                        {
                            arrow.number = 2;
                            arrow._rotation = 0;
                        }
                        if (direction == 1)
                        {
                            arrow.number = 0;
                            arrow._rotation = MathHelper.Pi;
                        }
                        arrows.Add(arrow);
                    }
                    if (isgun)
                    {
                        boom bullet = new boom(bulletimage, _location, _color, Type.Bullet, 7);
                        if (direction == 2)
                        {
                            bullet.number = 3;
                        }
                        if (direction == 3)
                        {
                            bullet.number = 1;
                        }
                        if (direction == 0)
                        {
                            bullet.number = 2;
                        }
                        if (direction == 1)
                        {
                            bullet.number = 0;
                        }
                        bullets.Add(bullet);
                    }
                    if (iscannon)
                    {
                        boom ball = new boom(ballimage, _location, _color, Type.Bullet, 5);
                        if (direction == 2)
                        {
                            ball.number = 3;
                        }
                        if (direction == 3)
                        {
                            ball.number = 1;
                        }
                        if (direction == 0)
                        {
                            ball.number = 2;
                        }
                        if (direction == 1)
                        {
                            ball.number = 0;
                        }
                        balls.Add(ball);
                    }
                    waitshoot = TimeSpan.Zero;
                }
                if (isevil)
                {

                }
                for (int i = 0; i < arrows.Count; i++)
                {
                    arrows[i].Update(gt);
                }
                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].Update(gt);
                }
                for (int i = 0; i < balls.Count; i++)
                {
                    balls[i].Update(gt);
                }
            }
        }
        public void PlaySound()
        {
            StopSound();

            currentSoundEffect = Hit.CreateInstance();
            currentSoundEffect.Play();
        }
        public void arrowdraw(SpriteBatch batch)
        {
            for (int i = 0; i < arrows.Count; i++)
            {
                arrows[i].draw(batch);
            }
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].draw(batch);
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].draw(batch);
            }
        }
        public void rotordraw(SpriteBatch batch)
        {
            if (heli == Image)
            {
                rotor.draw(batch);
            }
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
