using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace splix.io
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        int playerchose2 = 0;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TimeSpan tillshoot = new TimeSpan(0, 0, 0, 0, 750);
        TimeSpan waitshoot;
        Player player;
        Random random;
        int playerchose;
        Player otherplayer;
        int number;
        int startlife;
        int startlife2;
        Sprite stanbutt;
        Sprite killbutt;
        Sprite soldierbutt;
        Sprite regbutt;
        Sprite trapbutt;
        Sprite huntbutt;
        Sprite movebutt;
        Sprite wizbutt;
        Sprite rules;
        Sprite health;
        Sprite death;
        int menuleft = 2;
        Sprite ninjabutt;
        Sprite phantombutt;
        List<boom> booms;
        List<Texture2D> playerImages;
        //we need a list of players (not just texture2ds, the player class)
        //then we should add both players to it, and we can make the screen work with that
        List<Player> players;
        List<int> speeds;
        Random playerrand = new Random();
        public int colorselect;
        List<Color> colors;
        Grid grid;
        int number2;
        bool isboom2 = false;
        KeyboardState prevKs;
        KeyboardState ks;
        bool menu = true;
        int count = 0;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            random = new Random();
            colorselect = random.Next(0, 18);
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
            number = -1;
            number2 = -1;
            playerchose = number;
            playerImages = new List<Texture2D>();
            booms = new List<boom>();
            playerImages.Add(Content.Load<Texture2D>("killer"));
            playerImages.Add(Content.Load<Texture2D>("mover"));
            playerImages.Add(Content.Load<Texture2D>("circle"));
            playerImages.Add(Content.Load<Texture2D>("stanmode"));
            playerImages.Add(Content.Load<Texture2D>("soldier"));
            playerImages.Add(Content.Load<Texture2D>("trapper"));
            playerImages.Add(Content.Load<Texture2D>("hunter"));
            playerImages.Add(Content.Load<Texture2D>("wiz"));
            playerImages.Add(Content.Load<Texture2D>("ninja"));
            playerImages.Add(Content.Load<Texture2D>("phantom"));
            speeds = new List<int>();
            speeds.Add(2);
            speeds.Add(30);
            speeds.Add(15);
            speeds.Add(5);
            speeds.Add(6);
            speeds.Add(6);
            speeds.Add(6);
            speeds.Add(5);
            speeds.Add(3);
            speeds.Add(10);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            grid = new Grid(GraphicsDevice.Viewport.Width / 30, GraphicsDevice.Viewport.Height / 30, Content.Load<Texture2D>("CellBlock"));
            Texture2D playerImage = playerImages[0];
            Vector2 playerPos = new Vector2((random.Next(0, 64) * 30) + 15, (random.Next(0, 36) * 30) + 15);
            killbutt = new Sprite(Content.Load<Texture2D>("killbutt"), new Vector2(200, 200), Color.White);
            health = new Sprite(Content.Load<Texture2D>("health"), new Vector2(850, 30), colors[colorselect]);
            health.Scale = new Vector2(1, 1);
            death = new Sprite(Content.Load<Texture2D>("death"), new Vector2(850, 30), colors[colorselect]);
            rules = new Sprite(Content.Load<Texture2D>("rules"), new Vector2(960, 500), Color.White);
            wizbutt = new Sprite(Content.Load<Texture2D>("wizbutt"), new Vector2(500, 500), Color.White);
            movebutt = new Sprite(Content.Load<Texture2D>("movebutt"), new Vector2(500, 200), Color.White);
            stanbutt = new Sprite(Content.Load<Texture2D>("stanbutt"), new Vector2(800, 200), Color.White);
            trapbutt = new Sprite(Content.Load<Texture2D>("trapper butt"), new Vector2(1700, 200), Color.White);
            regbutt = new Sprite(Content.Load<Texture2D>("circlebutt"), new Vector2(1100, 200), Color.White);
            phantombutt = new Sprite(Content.Load<Texture2D>("phantombutt"), new Vector2(1700, 500), Color.White);
            ninjabutt = new Sprite(Content.Load<Texture2D>("ninjabutt"), new Vector2(1400, 500), Color.White);
            soldierbutt = new Sprite(Content.Load<Texture2D>("soldierbutt"), new Vector2(1400, 200), Color.White);
            huntbutt = new Sprite(Content.Load<Texture2D>("huntbutt"), new Vector2(200, 500), Color.White);
            player = new Player(playerImage, new Vector2(playerPos.X, playerPos.Y), colors[colorselect], speeds[0], Content.Load<Texture2D>("tail"), Content.Load<Texture2D>("capturedcell"), Content.Load<Texture2D>("pixel"), Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Space);
            otherplayer = new Player(playerImages[playerchose2], new Vector2(playerPos.X, playerPos.Y), colors[colorselect], speeds[playerchose2], Content.Load<Texture2D>("tail"), Content.Load<Texture2D>("capturedcell"), Content.Load<Texture2D>("pixel"), Keys.W, Keys.S, Keys.A, Keys.D, Keys.Tab);
            players = new List<Player>();
            players.Add(player);
            players.Add(otherplayer);
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            //for(int i =)
            prevKs = ks;
            ks = Keyboard.GetState();
            if (menu)
            {

                if (ks.IsKeyDown(Keys.NumPad1))
                {
                    number = 0;
                    players[count].lives = 1;

                }
                if (ks.IsKeyDown(Keys.NumPad2))
                {
                    number = 1;
                    players[count].lives = 1;

                }
                if (ks.IsKeyDown(Keys.NumPad3))
                {
                    number = 3;
                    players[count].lives = 3;

                }
                if (ks.IsKeyDown(Keys.NumPad4))
                {
                    number = 2;
                    players[count].lives = 1;

                }
                if (ks.IsKeyDown(Keys.NumPad5))
                {
                    number = 4;
                    players[count].lives = 3;

                }
                if (ks.IsKeyDown(Keys.NumPad6))
                {
                    number = 5;
                    players[count].isboom = true;
                    players[count].lives = 2;
                }
                if (ks.IsKeyDown(Keys.NumPad7))
                {
                    number = 6;
                    players[count].isboom = true;
                    players[count].lives = 1;
                }
                if (ks.IsKeyDown(Keys.NumPad8))
                {
                    number = 7;
                    players[count].isboom = true;
                    players[count].lives = 1;
                }
                if (ks.IsKeyDown(Keys.NumPad9))
                {
                    number = 8;
                    players[count].isboom = true;
                    players[count].lives = 1;
                }
                if (ks.IsKeyDown(Keys.NumPad0))
                {
                    number = 9;
                    players[count].lives = 1;
                }
                if (ks.IsKeyDown(Keys.Enter) && prevKs.IsKeyUp(Keys.Enter))
                {
                    if (number == -1)
                    {
                        number = playerrand.Next(0, 10);
                        players[count].lives = 1;
                    }
                    if (number == 5)
                    {
                        players[count].isboom = true;
                        players[count].lives = 2;
                    }
                    if (number == 8)
                    {
                        players[count].isboom = true;
                        players[count].lives = 1;
                    }
                    if (number == 6)
                    {
                        players[count].isboom = true;
                    }
                    if (number == 7)
                    {
                        players[count].isboom = true;
                        players[count].lives = 3;
                    }
                    if (number == 4)
                    {
                        players[count].lives = 3;
                    }
                    if (number == 3)
                    {
                        players[count].lives = 3;
                    }
                    playerchose = number;
                    players[count].Image = playerImages[playerchose];
                    players[count].speed = speeds[playerchose];
                    count++;
                    if (count >= 2)
                    {
                        menu = false;
                    }
                    //if (menuleft >= 2)
                    //{
                    //    menuleft--;
                    //}
                    //}
                }
                //if (menuleft == 1)
                //{
                //    if (ks.IsKeyDown(Keys.NumPad1))
                //    {
                //        number2 = 0;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad2))
                //    {
                //        number2 = 1;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad3))
                //    {
                //        number2 = 3;
                //        otherplayer.lives = 3;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad4))
                //    {
                //        number2 = 2;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad5))
                //    {
                //        number2 = 4;
                //        otherplayer.lives = 3;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad6))
                //    {
                //        number2 = 5;
                //        isboom2 = true;
                //        otherplayer.lives = 2;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad7))
                //    {
                //        number2 = 6;
                //        isboom2 = true;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad8))
                //    {
                //        number2 = 7;
                //        isboom2 = true;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad9))
                //    {
                //        number2 = 8;
                //        isboom2 = true;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.NumPad0))
                //    {
                //        number2 = 9;
                //        otherplayer.lives = 1;
                //    }
                //    if (ks.IsKeyDown(Keys.Enter))
                //    {
                //        if (number2 == -1)
                //        {
                //            number2 = playerrand.Next(0, 10);
                //            otherplayer.lives = 1;
                //        }
                //        if (number2 == 5)
                //        {
                //            isboom2 = true;
                //            otherplayer.lives = 2;
                //        }
                //        if (number2 == 8)
                //        {
                //            isboom2 = true;
                //            otherplayer.lives = 1;
                //        }
                //        if (number2 == 6)
                //        {
                //            isboom2 = true;
                //        }
                //        if (number2 == 7)
                //        {
                //            isboom2 = true;
                //            otherplayer.lives = 3;
                //        }
                //        if (number2 == 4)
                //        {
                //            otherplayer.lives = 3;
                //        }
                //        if (number2 == 3)
                //        {
                //            otherplayer.lives = 3;
                //        }
                //        otherplayer.Image = players[number2];
                //        otherplayer.speed = speeds[number2];
                //        startlife2 = otherplayer.lives;
                //        menuleft--;
                //        if (menuleft <= 0)
                //        {
                //            menu = false;
                //        }
                //    }
            }
            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].isboom)
                    {
                        waitshoot += gameTime.ElapsedGameTime;
                    }
                    if (players[i].isdead == false)
                    {
                        players[i].Update(gameTime, ks, prevKs, health);
                    }
                }
                if (waitshoot >= tillshoot)
                {
                    for (int i = 0; i < players.Count; i++)
                    {
                        if (ks.IsKeyDown(players[i].shootkey))
                        {
                            if (number == 6)
                            {
                                boom bulletToAdd = new boom(Content.Load<Texture2D>("ammo"), new Vector2(players[i].Location.X, players[i].Location.Y), colors[colorselect], Type.Bullet, 60);
                                bulletToAdd.number = players[i].direction;
                                booms.Add(bulletToAdd);
                            }
                            if (number == 5)
                            {
                                boom traptoadd = new boom(Content.Load<Texture2D>("trap"), new Vector2(players[i].Location.X, players[i].Location.Y), colors[colorselect], Type.Trap, 0);
                                traptoadd.number = players[i].direction;
                                booms.Add(traptoadd);
                            }
                            if (number == 7)
                            {
                                boom firetoadd = new boom(Content.Load<Texture2D>("fire"), new Vector2(players[i].Location.X, players[i].Location.Y), colors[colorselect], Type.Fire, 30);
                                firetoadd.number = players[i].direction;
                                booms.Add(firetoadd);
                            }
                            if (number == 8)
                            {
                                boom shurktoadd = new boom(Content.Load<Texture2D>("sh"), new Vector2(players[i].Location.X, players[i].Location.Y), colors[colorselect], Type.shurk, 25);
                                shurktoadd.number = players[i].direction;
                                booms.Add(shurktoadd);
                            }
                            waitshoot = TimeSpan.Zero;
                        }
                    }
                    //if (waitshoot >= tillshoot)
                    //{
                    //    if (ks.IsKeyDown(Keys.LeftControl))
                    //    {
                    //        if (number2 == 6)
                    //        {
                    //            boom bulletToAdd = new boom(Content.Load<Texture2D>("ammo"), new Vector2(otherplayer.Location.X, otherplayer.Location.Y), colors[colorselect], Type.Bullet, 60);
                    //            bulletToAdd.number = player.direction;
                    //            booms.Add(bulletToAdd);
                    //        }
                    //        if (number2 == 5)
                    //        {
                    //            boom traptoadd = new boom(Content.Load<Texture2D>("trap"), new Vector2(otherplayer.Location.X, otherplayer.Location.Y), colors[colorselect], Type.Trap, 0);
                    //            traptoadd.number = player.direction;
                    //            booms.Add(traptoadd);
                    //        }
                    //        if (number2 == 7)
                    //        {
                    //            boom firetoadd = new boom(Content.Load<Texture2D>("fire"), new Vector2(otherplayer.Location.X, otherplayer.Location.Y), colors[colorselect], Type.Fire, 30);
                    //            firetoadd.number = player.direction;
                    //            booms.Add(firetoadd);
                    //        }
                    //        if (number2 == 8)
                    //        {
                    //            boom shurktoadd = new boom(Content.Load<Texture2D>("sh"), new Vector2(otherplayer.Location.X, otherplayer.Location.Y), colors[colorselect], Type.shurk, 25);
                    //            shurktoadd.number = player.direction;
                    //            booms.Add(shurktoadd);
                    //        }
                    //        waitshoot = TimeSpan.Zero;
                    //    }

                    //}
                }
                for (int i = 0; i < booms.Count; i++)
                {
                    booms[i].Update(gameTime);
                }
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (menu)
            {
                GraphicsDevice.Clear(colors[colorselect]);
                killbutt.draw(spriteBatch);
                movebutt.draw(spriteBatch);
                stanbutt.draw(spriteBatch);
                regbutt.draw(spriteBatch);
                soldierbutt.draw(spriteBatch);
                trapbutt.draw(spriteBatch);
                huntbutt.draw(spriteBatch);
                wizbutt.draw(spriteBatch);
                ninjabutt.draw(spriteBatch);
                phantombutt.draw(spriteBatch);
                rules.draw(spriteBatch);
            }
            else
            {
                grid.Draw(spriteBatch);
                health.draw(spriteBatch);
                for (int e = 0; e < players.Count; e++)
                {
                    if (players[e].isdead == false)
                    {
                        players[e].draw(spriteBatch);
                    }
                    for (int i = 0; i < booms.Count; i++)
                    {
                        booms[i].draw(spriteBatch);
                    }
                    if (players[e].isdead)
                    {
                        death.draw(spriteBatch);
                    }
                }
                // players[e].debugDraw(spriteBatch, Content.Load<Texture2D>("pixel"));
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
