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
        public enum playerType
        {
            human,
            CPU
        }
        protected int _speed;
        public TimeSpan tillshoot = new TimeSpan(0, 0, 0, 0, 750);
        public TimeSpan waitshoot;
        public TimeSpan tillspawn = new TimeSpan(0, 0, 0, 1, 250);
        public bool isbr = false;
        public TimeSpan waitspawn;
        playerType type;
        public int number;
        public int colorselect;
        public List<Color> colors;
        public List<boom> booms;
        public int direction = 1;
        public int lives;
        public bool isdead = false;
        public int directionToChangeTo = 0;
        List<Vector2> _points;
        KeyboardState lastKS;
        public int prevlives;
        public int boomspeed;
        public bool ispawner = false;
        bool spawnready = true;
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
        public List<pawns> pawns;
        bool _changedDirection = false;
        public trail _trail;
        public territory _terra;
        Texture2D pix;
        float scaleX;
        float scaleY;
        int hitCount;
        Random random = new Random();
        public Keys UpKey;
        public Keys Downkey;
        public Keys Leftkey;
        public Keys Rightkey;
        public Keys shootkey;
        public bool isboom = false;
        public Texture2D boomimage;
        public Texture2D pawnimage;
        public int pawnhealth;
        public float pawnattack;
        public bool captured = false;
        public bool ishitsoundplaying = false;
        public bool hassoundstarted = false;
        public SoundEffect pawnhit;
        public Player(Texture2D image, Vector2 location, int speed, Texture2D trail, Texture2D terraimage, Texture2D pixel, playerType Type)
            : base(image, location, Color.White)
        {
            _layer = 0.999f;
            colors = new List<Color>()
            {
                Color.Maroon,
                Color.Navy,
                Color.Gold,
                Color.OrangeRed,
                Color.Violet,
                Color.Wheat,
                Color.DarkOliveGreen,
                Color.SaddleBrown,
                Color.DarkSalmon,
                Color.Yellow,
                Color.Pink,
                Color.BlueViolet,
                Color.BlanchedAlmond,
                Color.Khaki,
                Color.Turquoise,
                Color.Crimson,
                Color.White,
                Color.White,
                Color.White
            };
            colorselect = random.Next(0, 18);
            Color = colors[colorselect];
            pix = pixel;
            type = Type;
            _points = new List<Vector2>();
            _speed = speed;
            _terra = new territory(new Sprite(terraimage, new Vector2(location.X + _origin.X, location.Y + _origin.Y), Color), _location);
            _trail = new trail(new Sprite(trail, new Vector2(location.X, location.Y), Color));
            scaleX = 1f;
            scaleY = 1f;
            hitCount = 1;
            pawns = new List<pawns>();
            number = -1;
            booms = new List<boom>();

        }
        public void Update(GameTime gametime, KeyboardState ks, KeyboardState prevKs, Sprite healthBar, GameTime gt)
        {
            move();
            if (type == playerType.human)
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
            }
            if (isboom)
            {
                waitshoot += gt.ElapsedGameTime;
            }
            if(ispawner)// OVER HERE IDIOT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                for (int i = 0; i < pawns.Count; i++)
                {
                    pawns[i].update(gametime);
                    if(pawns[i]._health <= 0)
                    {
                        pawns.RemoveAt(i);
                    }
                }
                waitspawn += gametime.ElapsedGameTime;
                if (ks.IsKeyDown(shootkey) && waitspawn >= tillspawn)
                {
                    spawnready = true;
                }
                if (_location.X % 30 == 15 && _location.Y % 30 == 15 && spawnready == true)
                {
                    if (isbr == false)
                    {
                        pawns.Add(new pawns(pawnimage, _location, colors[colorselect], 3, pawnhealth, pawnattack, pawnhit, new TimeSpan(0, 0, 0, 1, 0)));
                    }
                    else if(isbr)
                    {
                        pawns.Add(new pawns(pawnimage, _location, Color.Green, 1, pawnhealth - 15, pawnattack, pawnhit, new TimeSpan(0, 0, 0, 1, 500)));
                    }
                    spawnready = false;
                    waitspawn = TimeSpan.Zero;
                }
            }
            if (waitshoot >= tillshoot)
            {
                if (ks.IsKeyDown(shootkey))
                {
                    boom bulletToAdd = new boom(boomimage, new Vector2(Location.X, Location.Y), colors[colorselect], Type.Bullet, boomspeed);
                    bulletToAdd.number = direction;
                    booms.Add(bulletToAdd);
                    waitshoot = TimeSpan.Zero;
                }
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
                if (!_terra.PositionIntersects(this.Hitbox))
                {
                    _trail.AddTrail(_location);
                    _points.Add(_location);
                }
            }
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
            if (lives <= 0)
            {
                isdead = true;
            }
            if (_terra.PositionIntersects(this.Hitbox))
            {
                captured = true;
                _trail.ClearTrail();
                if (_points.Count >= 1)
                {
                    _terra.AddTerritory(_points);
                }
                _points.Clear();
            }

            lastKS = ks;
        }

        public bool IntersectsWithTrail(Sprite sprite)
        {
            return _trail.HitTrail(sprite) && !_trail.HasPieceBeenHit(_trail.GetHitIndex());
        }

        public bool IntersectsWithTerritory(Rectangle hitBox)
        {
            return _terra.PositionIntersects(hitBox);
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

        public void Playerdraw(SpriteBatch spbt)
        {
            //debugDraw(spbt, pix);
            base.draw(spbt);
        }
        public void TerraDraw(SpriteBatch spbt)
        {
            _terra.Draw(spbt);
        }
        public void TrailDraw(SpriteBatch spbt)
        {
            _trail.draw(spbt);
        }
        public void Pawndraw(SpriteBatch spbt)
        {
            for (int e = 0; e < pawns.Count; e++)
            {
                pawns[e].draw(spbt);
            }
        }
        public void CaptureTerra(Player enemy)
        {
            for (int i = 0; i < enemy._terra._points.Count; i++)
            {
                if (_terra.PositionIntersects(enemy._terra._points[i].Hitbox))
                {
                    enemy._terra._points.RemoveAt(i);
                }
            }
        }

    }
}