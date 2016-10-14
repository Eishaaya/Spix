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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Random random;
        int playerchose;
        int number;
        Sprite stanbutt;
        Sprite killbutt;
        Sprite soldierbutt;
        Sprite regbutt;
        Sprite trapbutt;
        Sprite huntbutt;
        Sprite movebutt;
        List<Texture2D> players;
        List<int> speeds;
        Random playerrand = new Random();
        public int colorselect;
        List<Color> colors;
        Grid grid;

        KeyboardState prevKs;
        KeyboardState ks;
        bool menu = true;

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

            playerchose = number;
            players = new List<Texture2D>();
            players.Add(Content.Load<Texture2D>("killer"));
            players.Add(Content.Load<Texture2D>("mover"));
            players.Add(Content.Load<Texture2D>("circle"));
            players.Add(Content.Load<Texture2D>("stanmode"));
            players.Add(Content.Load<Texture2D>("soldier"));
            players.Add(Content.Load<Texture2D>("trapper"));
            players.Add(Content.Load<Texture2D>("hunter"));
            speeds = new List<int>();
            speeds.Add(3);
            speeds.Add(15);
            speeds.Add(10);
            speeds.Add(5);
            speeds.Add(6);
            speeds.Add(6);
            speeds.Add(6);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            grid = new Grid(GraphicsDevice.Viewport.Width / 30, GraphicsDevice.Viewport.Height / 30, Content.Load<Texture2D>("CellBlock"));



            Texture2D playerImage = players[0];
            Vector2 playerPos = new Vector2((random.Next(0, 64) * 30) + 15, (random.Next(0, 36) * 30) + 15);
            killbutt = new Sprite(Content.Load<Texture2D>("killbutt"), new Vector2(200, 200), Color.White);
            movebutt = new Sprite(Content.Load<Texture2D>("movebutt"), new Vector2(500, 200), Color.White);
            stanbutt = new Sprite(Content.Load<Texture2D>("stanbutt"), new Vector2(800, 200), Color.White);
            trapbutt = new Sprite(Content.Load<Texture2D>("trapper butt"), new Vector2(1700, 200), Color.White);
            regbutt = new Sprite(Content.Load<Texture2D>("circlebutt"), new Vector2(1100, 200), Color.White);
            soldierbutt = new Sprite(Content.Load<Texture2D>("soldierbutt"), new Vector2(1400, 200), Color.White);
            huntbutt = new Sprite(Content.Load<Texture2D>("huntbutt"), new Vector2(1000, 500), Color.White);
            player = new Player(playerImage, new Vector2(playerPos.X, playerPos.Y), colors[colorselect], speeds[0], Content.Load<Texture2D>("tail"), Content.Load<Texture2D>("capturedcell"), Content.Load<Texture2D>("pixel"));
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            prevKs = ks;
            ks = Keyboard.GetState();
            if (menu)
            {
                if (ks.IsKeyDown(Keys.NumPad1))
                {
                    number = 0;
                }
                if (ks.IsKeyDown(Keys.NumPad2))
                {
                    number = 1;
                }
                if (ks.IsKeyDown(Keys.NumPad3))
                {
                    number = 3;
                }
                if (ks.IsKeyDown(Keys.NumPad4))
                {
                    number = 2;
                }
                if (ks.IsKeyDown(Keys.NumPad5))
                {
                    number = 4;
                }
                if (ks.IsKeyDown(Keys.NumPad6))
                {
                    number = 5;
                }
                if (ks.IsKeyDown(Keys.NumPad7))
                {
                    number = 6;
                }
                if (ks.IsKeyDown(Keys.Enter))
                {
                    if (number == -1)
                    {
                        number = playerrand.Next(0, 7);
                    }

                    playerchose = number;
                    player.Image = players[playerchose];
                    player.speed = speeds[playerchose];

                    menu = false;
                }
            }
            else
            {
                player.Update(gameTime, ks, prevKs);
            }
            base.Update(gameTime);
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
            }
            else
            {
                grid.Draw(spriteBatch);
                player.draw(spriteBatch);
                //player.debugDraw(spriteBatch, Content.Load<Texture2D>("pixel"));
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
